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
using System.Windows.Forms.DataVisualization.Charting;
using WeifenLuo.WinFormsUI.Docking;
using RFIDIntegratedApplication.ServiceReference1;
namespace RFIDIntegratedApplication
{
    public partial class PhaseGraphForm : DockContent, IFormable
    {
        public PhaseGraphForm()
        {
            InitializeComponent();

            this.Dock = DockStyle.Fill;
        }

        /// <summary>
        /// Update tool strip status
        /// </summary>
        /// <param name="flag">Indicate starting or stoping inventorying</param>
        /// <param name="isSimulation">Indicates whether it is simulation</param>
        public void UpdateComponentStatus(int flag, bool isSimulation)
        {
            if (flag == 0)
            {
                // Disable tool strip
                tsPhaseSettings.Enabled = false;
            }
            else
            {
                // Enable tool strip
                tsPhaseSettings.Enabled = true;
            }
        }
        
        /// <summary>
        /// Update RSSI Graph
        /// </summary>
        /// <param name="tagInfo">an object containing all information of a tag in one tag report</param>
        public void UpdatePhaseGraph(TagInfo tagInfo)
        {
            string key = tagInfo.Antenna + "--" + tagInfo.EPC;
            if (tagInfo.TotalTagCount == 1)
            {
                //Chart title for Phase
                Title titlePhase = new Title("Phase", Docking.Top);
                titlePhase.Alignment = System.Drawing.ContentAlignment.MiddleCenter;
                titlePhase.Font = new System.Drawing.Font("Microsoft Sans Serif", 20, System.Drawing.FontStyle.Bold);
                chartPhase.Titles.Add(titlePhase);
            }

            if (chartPhase.Series.FindByName(key) != null)
            {
                if ((tagInfo.TotalTagCount - 1) % Convert.ToInt32(tscbPointFrequency.Text.Trim()) == 0)
                    chartPhase.Series[key].Points.AddXY(tagInfo.TimeStamp / 1000, tagInfo.AcutalPhaseInRadian);
            }
            else
            {
                //Create a new curve
                Series seriesPhase = new Series(key);
                //Set chart type
                //seriesPhase.ChartType = SeriesChartType.FastPoint;
                seriesPhase.ChartType = (SeriesChartType)Enum.Parse(typeof(SeriesChartType), tscbLineType.Text.Trim());
                //Set curve width
                seriesPhase.BorderWidth = Convert.ToInt32(tscbLineWidth.Text.Trim());
                //seriesPhase.MarkerSize = 5;
                chartPhase.Series.Add(seriesPhase);

                //Create a new legend
                Legend legendPhase = new Legend("Phase:" + key);
                //Set legend propertities
                legendPhase.Title = "EPC";
                legendPhase.Font = new System.Drawing.Font("Microsoft Sans Serif", 10, System.Drawing.FontStyle.Bold);
                legendPhase.TitleFont = new System.Drawing.Font("Microsoft Sans Serif", 12, System.Drawing.FontStyle.Bold);

                legendPhase.LegendStyle = LegendStyle.Table;
                legendPhase.Alignment = System.Drawing.StringAlignment.Center;
                legendPhase.IsDockedInsideChartArea = false;
                legendPhase.Docking = Docking.Bottom;

                legendPhase.BorderDashStyle = ChartDashStyle.Dash;
                legendPhase.BorderColor = System.Drawing.Color.LightBlue;
                legendPhase.BorderWidth = 3;

                chartPhase.Legends.Add(legendPhase);

                chartPhase.Legends["Phase:" + key].DockedToChartArea = "Phase";
                seriesPhase.Points.AddXY(tagInfo.TimeStamp / 1000, tagInfo.AcutalPhaseInRadian);
            }

        }

        /// <summary>
        /// Clear all components created by this form before Inventroring 
        /// </summary>
        public void Clear()
        {
            chartPhase.Titles.Clear();
            chartPhase.Series.Clear();
            chartPhase.Legends.Clear();
        }
        
        private void PhaseGraphForm_DockStateChanged(object sender, EventArgs e)
        {
            if (this.DockState == DockState.Unknown || this.DockState == DockState.Hidden)
            {
                return;
            }
            AppConfig.phaseGraphDockState = this.DockState;
        }

        private void PhaseGraphForm_Load(object sender, EventArgs e)
        {
            tscbLineType.Items.Add("FastLine");
            tscbLineType.Items.Add("StepLine");
            tscbLineType.Items.Add("FastPoint");
            tscbLineType.Text = "FastLine";

            for (int i = 0; i < 5; i++)
            {
                tscbLineWidth.Items.Add(i + 1);
            }
            tscbLineWidth.Text = Convert.ToString(3);

            for (int i = 0; i < 10; i++)
            {
                tscbPointFrequency.Items.Add(i + 1);
            }
            tscbPointFrequency.Text = Convert.ToString(1);
        }

        private void tscbLineType_Click(object sender, EventArgs e)
        {

        }

        private void chartPhase_Click(object sender, EventArgs e)
        {

        }
    }
}
