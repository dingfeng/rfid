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
    public partial class RSSIGraphFrom : DockContent, IFormable
    {
        public RSSIGraphFrom()
        {
            InitializeComponent();
            
        }

        /// <summary>
        /// Update tool strip status
        /// </summary>
        /// <param name="flag">Indicates starting or stoping inventorying</param>
        /// <param name="isSimulation">Indicates whether it is simulation</param>
        public void UpdateComponentStatus(int flag, bool isSimulation)
        {
            if (flag == 0)
            {
                // Disable tool strip
                tsRSSISettings.Enabled = false;
            }
            else
            {
                // Enable tool strip
                tsRSSISettings.Enabled = true;
            }
        }

        /// <summary>
        /// Update RSSI Graph
        /// </summary>
        /// <param name="tagInfo">an object containing all information of a tag in one tag report</param>
        public void UpdateRSSIGraph(TagInfo tagInfo)
        {
            if (tagInfo.TotalTagCount == 1)
            {
                //Chart title for RSSI
                Title titleRSSI = new Title("RSSI", Docking.Top);
                titleRSSI.Alignment = System.Drawing.ContentAlignment.MiddleCenter;
                titleRSSI.Font = new System.Drawing.Font("Microsoft Sans Serif", 20, System.Drawing.FontStyle.Bold);
                chartRSSI.Titles.Add(titleRSSI);
            }

            if (chartRSSI.Series.FindByName(tagInfo.EPC) != null)
            {
                if ((tagInfo.TotalTagCount - 1) % Convert.ToInt32(tscbPointFrequency.Text.Trim()) == 0)
                    chartRSSI.Series[tagInfo.EPC].Points.AddXY(tagInfo.TimeStamp / 1000, tagInfo.RSSI);
            }
            else
            {
                //Create a new curve
                Series seriesRSSI = new Series(tagInfo.EPC);
                //Set chart type
                seriesRSSI.ChartType = (SeriesChartType)Enum.Parse(typeof(SeriesChartType), tscbLineType.Text.Trim());
                //Set curve width
                seriesRSSI.BorderWidth = Convert.ToInt32(tscbLineWidth.Text.Trim());
                chartRSSI.Series.Add(seriesRSSI);

                //Create a new legend
                Legend legendRSSI = new Legend("RSSI:" + tagInfo.EPC);
                //Set legend propertities
                legendRSSI.Title = "EPC";
                legendRSSI.TitleFont = new System.Drawing.Font("Microsoft Sans Serif", 12, System.Drawing.FontStyle.Bold);
                legendRSSI.Font = new System.Drawing.Font("Microsoft Sans Serif", 10, System.Drawing.FontStyle.Bold);

                legendRSSI.LegendStyle = LegendStyle.Table;
                legendRSSI.Alignment = System.Drawing.StringAlignment.Center;
                legendRSSI.IsDockedInsideChartArea = false;
                legendRSSI.Docking = Docking.Bottom;

                legendRSSI.BorderDashStyle = ChartDashStyle.Dash;
                legendRSSI.BorderColor = System.Drawing.Color.LightBlue;
                legendRSSI.BorderWidth = 3;
                chartRSSI.Legends.Add(legendRSSI);
                //Set Docking of the legend chart to the Default Chart Area
                chartRSSI.Legends["RSSI:" + tagInfo.EPC].DockedToChartArea = "RSSI";
                seriesRSSI.Points.AddXY(tagInfo.TimeStamp / 1000, tagInfo.RSSI);
            }

        }

        /// <summary>
        /// Clear all components created by this form before inventroring 
        /// </summary>
        public void Clear()
        {
            chartRSSI.Titles.Clear();
            chartRSSI.Series.Clear();
            chartRSSI.Legends.Clear();
        }
        
        private void RSSIGraphFrom_DockStateChanged(object sender, EventArgs e)
        {
            if (this.DockState == DockState.Unknown || this.DockState == DockState.Hidden)
            {
                return;
            }
            AppConfig.rssiGraphDockState = this.DockState;
        }

        private void RSSIGraphFrom_Load(object sender, EventArgs e)
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

     
    }
}
