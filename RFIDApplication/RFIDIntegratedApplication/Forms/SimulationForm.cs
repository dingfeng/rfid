using RFIDIntegratedApplication.Analysis;
using RFIDIntegratedApplication.Tag;
using RFIDIntegratedApplication.Utility;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WeifenLuo.WinFormsUI.Docking;
using RFIDIntegratedApplication.ServiceReference1;
namespace RFIDIntegratedApplication.HolographicsForms
{
    public partial class SimulationForm : DockContent, IFormable
    {
        System.Timers.Timer _timers;                   // Timer for generating measured phase
        static MainForm _mainform;                     // Invoke functions from MainForm
        static LinearGuideForm _linearGuideForm;       // Obtain trajectory of objects
        static int _simulationTotalTagCount;           // Tag count for simulation

        public SimulationForm(MainForm mainform, LinearGuideForm linearGuideForm)
        {
            InitializeComponent();

            _mainform = mainform;
            _linearGuideForm = linearGuideForm;

            _simulationTotalTagCount = 1;
        }

        /// <summary>
        /// Update component status
        /// </summary>
        /// <param name="flag">Indicates starting or stoping inventorying</param>
        /// <param name="isSimulation">Indicates whether it is simulation</param>
        public void UpdateComponentStatus(int flag, bool isSimulation)
        {
            if (isSimulation)
            {
                if (flag == 0)
                {
                    // Starting inventorying
                    tsbtnSimulationStart.Enabled = false;
                    tsbtnSimulationStop.Enabled = true;

                    cbPhaseAmbiguity.Enabled = false;
                    gbSimulationTag.Enabled = false;
                    gbReader.Enabled = false;
                    gbMultipath.Enabled = false;
                }
                else
                {
                    // Stoping inventorying
                    tsbtnSimulationStart.Enabled = true;
                    tsbtnSimulationStop.Enabled = false;

                    cbPhaseAmbiguity.Enabled = true;
                    gbSimulationTag.Enabled = true;
                    gbReader.Enabled = true;
                    gbMultipath.Enabled = true;
                }
            }
            else
            {
                tsbtnSimulationStart.Enabled = false;
                tsbtnSimulationStop.Enabled = false;

                cbPhaseAmbiguity.Enabled = false;
                gbSimulationTag.Enabled = false;
                gbReader.Enabled = false;
                gbMultipath.Enabled = false;
            }
        }

        /// <summary>
        /// Generate phase ambiguity according to random number
        /// </summary>
        /// <param name="phase">pure phase</param>
        /// <returns>phase with ambiguity</returns>
        private double GeneratePhaseAmbiguity(double phase)
        {
            Random random = new Random();
            int flag = random.Next(0, 50);
            if (flag < 3)
            {
                phase += Math.PI;
            }

            return phase;
        }

        /// <summary>
        /// Calculate the measured phase for simulation 
        /// </summary>
        /// <param name="antX">Antenna position x</param>
        /// <param name="antY">Antenna position y</param>
        /// <param name="tagX">Tag position x</param>
        /// <param name="tagY">Tag position y</param>
        /// <param name="freq">Frequency</param>
        /// <returns>Measured Phase</returns>
        public double CaculatingSimulationMeasuredPhase(double antX, double antY, double antZ, double tagX, double tagY, double tagZ, int freq)
        {
            double simulationMeasuredPhase = Double.MinValue;

            double waveLength = SARParameter.C / Convert.ToDouble(freq);
            double distance = Math.Sqrt(Math.Pow(antX - tagX, 2) + Math.Pow(antY - tagY, 2) + Math.Pow(antZ - tagZ, 2));
            if (cbPhaseAmbiguity.Checked)
            {
                // Phase with ambiguity
                simulationMeasuredPhase = GeneratePhaseAmbiguity(4 * Math.PI * distance / waveLength) % (2 * Math.PI);
            }
            else
            {
                // Phase without ambiguity
                simulationMeasuredPhase = (4 * Math.PI * distance / waveLength) % (2 * Math.PI);
            }

            simulationMeasuredPhase = AppMath.GetNormalDistribution(simulationMeasuredPhase + Convert.ToDouble(tbxMu.Text.Trim()), Convert.ToDouble(tbxSigma.Text.Trim()));
            return simulationMeasuredPhase;
        }

        private void tsbtnSimulationStart_Click(object sender, EventArgs e)
        {
            if (dgvSimulationTagPosition.RowCount == 0)
            {
                MessageBox.Show("Please at least input one tag information!");
                return;
            }

            SARParameter.IsSimulation = true;

            this.Invoke(method: new Action(() =>
            {
                _mainform.UpdateComponentStatus(0, SARParameter.IsSimulation);
                _mainform.StartDequeueThread();
            }));

            for (int i = 0; i < dgvSimulationTagPosition.RowCount; i++)
            {
                SARParameter.Simulation.Tags.Add((string)dgvSimulationTagPosition.Rows[i].Cells[0].Value);
                SARParameter.Simulation.TagXs.Add(Convert.ToDouble(dgvSimulationTagPosition.Rows[i].Cells[1].Value));
                SARParameter.Simulation.TagYs.Add(Convert.ToDouble(dgvSimulationTagPosition.Rows[i].Cells[2].Value));
                SARParameter.Simulation.TagZs.Add(Convert.ToDouble(dgvSimulationTagPosition.Rows[i].Cells[3].Value));
            }

            // Define a timer to simulate the online situation
            _timers = new System.Timers.Timer();
            _timers.Enabled = true;
            _timers.Interval = Convert.ToDouble(tbxSamplingInterval.Text.Trim()) * 1000;
            _timers.Elapsed += new System.Timers.ElapsedEventHandler(Timers_Elapsed);
            _timers.Start();
        }

        private void Timers_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            this.Invoke(method: new Action(() =>
            {
                _linearGuideForm.CalculateTrajectory(Convert.ToDouble(tbxSamplingInterval.Text.Trim()));
            }));

            Tuple<double, double, double> point;
            if (SARParameter.Trajectory.TryPeek(out point))
            {
                TagInfo tagInfo = new TagInfo();
                tagInfo.Frequency = (int)(1000000 * Convert.ToDouble(tbxSimulationInitialFrequency.Text.Trim()) +
                    (_simulationTotalTagCount % (Convert.ToInt32(nudSimulationHopStep.Text.Trim()) + 1)) * SARParameter.FrequencyHoppingInterval);

                tagInfo.EPC = SARParameter.Simulation.Tags[_simulationTotalTagCount % SARParameter.Simulation.Tags.Count];
                double tagX = SARParameter.Simulation.TagXs[_simulationTotalTagCount % SARParameter.Simulation.TagXs.Count];
                double tagY = SARParameter.Simulation.TagYs[_simulationTotalTagCount % SARParameter.Simulation.TagYs.Count];
                double tagZ = SARParameter.Simulation.TagZs[_simulationTotalTagCount % SARParameter.Simulation.TagZs.Count];
                tagInfo.AcutalPhaseInRadian = CaculatingSimulationMeasuredPhase(point.Item1, point.Item2, point.Item3, tagX, tagY,tagZ, tagInfo.Frequency);
                tagInfo.FirstSeenTime = (ulong)(1000000 * _simulationTotalTagCount * Convert.ToDouble(tbxSamplingInterval.Text.Trim()));
                tagInfo.TimeStamp = tagInfo.FirstSeenTime;
                tagInfo.TotalTagCount = _simulationTotalTagCount++;
                
                //Console.WriteLine("*****" + point.Item1 + tagInfo.AcutalPhaseInRadian);

                this.Invoke(method: new Action(() =>
                {
                    _mainform.EnqueueTagInfo(tagInfo);
                }));
            }
        }

        private void tsbtnSimulationStop_Click(object sender, EventArgs e)
        {
            _timers.Stop();

            this.Invoke(method: new Action(() =>
            {
                _mainform.StopDequeueThread();
                _mainform.UpdateComponentStatus(1, SARParameter.IsSimulation);
            }));
        }

        public void Clear()
        {
            _simulationTotalTagCount = 1;

            SARParameter.Simulation.Tags.Clear();
            SARParameter.Simulation.TagXs.Clear();
            SARParameter.Simulation.TagYs.Clear();
            SARParameter.Simulation.TagZs.Clear();
        }

        private void SearchRegionForm_DockStateChanged(object sender, EventArgs e)
        {
            if (this.DockState == DockState.Unknown || this.DockState == DockState.Hidden)
            {
                return;
            }
            AppConfig.simulationDockState = this.DockState;
        }

        private void btnAddTag_Click(object sender, EventArgs e)
        {
            int index = dgvSimulationTagPosition.Rows.Add();
        }

        private void btnDeleteTag_Click(object sender, EventArgs e)
        {
            if (dgvSimulationTagPosition.SelectedRows == null)
            {
                MessageBox.Show("Please select the row you want to delete!");
            }
            else
            {
                dgvSimulationTagPosition.Rows.RemoveAt(dgvSimulationTagPosition.CurrentRow.Index);
            }

        }

        private void dgvSimulationTagPosition_RowStateChanged(object sender, DataGridViewRowStateChangedEventArgs e)
        {
            e.Row.HeaderCell.Value = string.Format("{0}", e.Row.Index);
        }

        private void SimulationForm_Load(object sender, EventArgs e)
        {
            SARParameter.Simulation.Tags = new List<string>();
            SARParameter.Simulation.TagXs = new List<double>();
            SARParameter.Simulation.TagYs = new List<double>();
            SARParameter.Simulation.TagZs = new List<double>();

            if (dgvSimulationTagPosition.RowCount <= 1)
            {
                dgvSimulationTagPosition.Rows.Add();
                dgvSimulationTagPosition.Rows[0].Cells[0].Value = "1";
                dgvSimulationTagPosition.Rows[0].Cells[1].Value = "0";
                dgvSimulationTagPosition.Rows[0].Cells[2].Value = "0";
                dgvSimulationTagPosition.Rows[0].Cells[3].Value = "0";
                //dgvSimulationTagPosition.Rows[0].Cells[4].Value = "[]"
            }

            tsbtnSimulationStart.Enabled = true;
            tsbtnSimulationStop.Enabled = false;
        }

        private void nudSimulationHopStep_ValueChanged(object sender, EventArgs e)
        {

        }

        private void dgvSimulationTagPosition_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
