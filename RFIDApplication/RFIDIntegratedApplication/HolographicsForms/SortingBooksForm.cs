using RFIDIntegratedApplication.Analysis;
using RFIDIntegratedApplication.Tag;
using RFIDIntegratedApplication.Utility;
using System;
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
    public partial class SortingBooksForm : DockContent, IFormable
    {
        Dictionary<string, SyntheticApertureRadar> _sar;     //Perform localization methods for each tag
        static HologramForm _hologramForm;

        public SortingBooksForm(HologramForm holo)
        {
            InitializeComponent();

            _hologramForm = holo;
            _sar = new Dictionary<string, SyntheticApertureRadar>();
        }

        /// <summary>
        /// Update component status
        /// </summary>
        /// <param name="flag">Indicates starting or stoping inventorying</param>
        /// <param name="isSimulation">Indicates whether it is simulation</param>
        public void UpdateComponentStatus(int flag, bool isSimulation)
        {
            if (flag == 0)
            {
                tssbtnAlgorithms.Enabled = false;
            }
            else
            {
                tssbtnAlgorithms.Enabled = true;
            }
        }

        public void SAR(TagInfo tagInfo)
        {
            if (!_sar.ContainsKey(tagInfo.EPC))
            {
                SyntheticApertureRadar sar = new SyntheticApertureRadar();

                _sar.Add(tagInfo.EPC, sar);
            }

            Tuple<double, double, double> position;
            if(SARParameter.Trajectory.TryDequeue(out position))
            {
                //Console.WriteLine("****sorting " + position.Item1 + "  " + tagInfo.AcutalPhaseInRadian);

                if (tssbtnAlgorithms.Text.Trim() == "Origin SAR")
                    _sar[tagInfo.EPC].OriginSAR(position.Item1, position.Item2, position.Item3,tagInfo.Frequency, tagInfo.AcutalPhaseInRadian);
                else if (tssbtnAlgorithms.Text.Trim() == "Tagoram-AH" || tssbtnAlgorithms.Text.Trim() == "Tagoram-DAH")
                    _sar[tagInfo.EPC].Tagoram(position.Item1, position.Item2, tagInfo.Frequency, tagInfo.AcutalPhaseInRadian);
                else if (tssbtnAlgorithms.Text.Trim() == "MobiTagbot")
                    _sar[tagInfo.EPC].MobiTagbot();

                DisplayLocalizationResult(tagInfo);

                this.Invoke(method: new Action(() =>
                {
                    _hologramForm.DisplayHologram(SARParameter.Hologram, tagInfo);
                }));
            }
        }

        //从队列中去除一个TagPos
        public void SAR()
        {
            TagPos tagPos;
            if(SARParameter.tagPosQueue.TryDequeue(out tagPos))
            {
                TagInfo tagInfo = tagPos.tagInfo;
                if (!_sar.ContainsKey(tagInfo.EPC))
                {
                    SyntheticApertureRadar sar = new SyntheticApertureRadar();

                    _sar.Add(tagInfo.EPC, sar);
                }
                Tuple<double, double, double> position = tagPos.pos;
                if (tssbtnAlgorithms.Text.Trim() == "Origin SAR")
                    _sar[tagInfo.EPC].OriginSAR(position.Item1, position.Item2, position.Item3, tagInfo.Frequency, tagInfo.AcutalPhaseInRadian);
                else if (tssbtnAlgorithms.Text.Trim() == "Tagoram-AH" || tssbtnAlgorithms.Text.Trim() == "Tagoram-DAH")
                    _sar[tagInfo.EPC].Tagoram(position.Item1, position.Item2, tagInfo.Frequency, tagInfo.AcutalPhaseInRadian);
                else if (tssbtnAlgorithms.Text.Trim() == "MobiTagbot")
                    _sar[tagInfo.EPC].MobiTagbot();
                DisplayLocalizationResult(tagInfo);
                this.Invoke(method: new Action(() =>
                {
                    _hologramForm.DisplayHologram(SARParameter.Hologram, tagInfo);
                }));
            }
        }

        private void DisplayLocalizationResult(TagInfo tagInfo)
        {
            tbxDisplay.AppendText("Round " + tagInfo.TotalTagCount + ": " + tagInfo.EPC + " (" + SARParameter.PredictedX + "," + SARParameter.PredictedY+ ","+SARParameter.PredictedZ+ ")" + "\r\n");
            tbxDisplay.SelectionStart = tbxDisplay.Text.Length;
            tbxDisplay.ScrollToCaret();
        }

        /// <summary>
        /// Clear all components created by this form before inventroring 
        /// </summary>
        public void Clear()
        {
            _sar.Clear();
            
            tbxDisplay.Clear();
        }

        private void tsmiOriginSAR_Click(object sender, EventArgs e)
        {
            tssbtnAlgorithms.Text = "Origin SAR";
        }

        private void tsmiAH_Click(object sender, EventArgs e)
        {
            tssbtnAlgorithms.Text = "Tagoram-AH";
        }

        private void tsmiDAH_Click(object sender, EventArgs e)
        {
            tssbtnAlgorithms.Text = "Tagoram-DAH";
        }

        private void tsmiMobiTagbot_Click(object sender, EventArgs e)
        {
            tssbtnAlgorithms.Text = "MobiTagbot";
        }

        private void tlpDisplayBooks_Paint(object sender, PaintEventArgs e)
        {

        }

        private void tbxDisplay_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
