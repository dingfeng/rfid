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
    public partial class HologramForm : DockContent, IFormable
    {
        HeatMap _heatmap;
        static int _refreshIndex;

        public HologramForm()
        {
            InitializeComponent();

            _refreshIndex = 1;
        }

        /// <summary>
        /// Initialize heatmap when starting inventorying
        /// </summary>
        public void InitializeHeatMap()
        {
            _heatmap = new HeatMap(pbHeatMap, SARParameter.GridY.Count, SARParameter.GridX.Count);

            SARParameter.Hologram = new List<List<double>>();
            for (int i = 0; i < SARParameter.GridY.Count; i++)
            {
                SARParameter.Hologram.Add(new List<double>());
                for (int j = 0; j < SARParameter.GridX.Count; j++)
                {
                    SARParameter.Hologram[i].Add(0);
                }
            }
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
                tstbxRefreshInterval.Enabled = false;
            }
            else
            {
                tstbxRefreshInterval.Enabled = true;
            }
        }

        /// <summary>
        /// Display hologram in the picturebox
        /// </summary>
        /// <param name="data">Hologram data</param>
        public void DisplayHologram(List<List<double>> data, TagInfo tagInfo)
        {
            if (!tscbTagEPCForHologram.Items.Contains(tagInfo.EPC))
            {
                if (tscbTagEPCForHologram.Text == String.Empty)
                    tscbTagEPCForHologram.Text = tagInfo.EPC;
                tscbTagEPCForHologram.Items.Add(tagInfo.EPC);
            }
            else
            {
                //Console.WriteLine("***" + (int)tagInfo.TimeStamp / (int)(1000000 * Convert.ToDouble(tstbxRefreshInterval.Text.Trim())));
                if (tagInfo.EPC == tscbTagEPCForHologram.Text && (int)tagInfo.TimeStamp / (int)(1000000 * Convert.ToDouble(tstbxRefreshInterval.Text.Trim())) >= _refreshIndex)
                {
                    _heatmap.DrawHeatMap(data);
                    _refreshIndex++;
                    //Console.WriteLine("****" + _factor);
                }
            }
        }

        /// <summary>
        /// Clear all components created by this form before Inventroring 
        /// </summary>
        public void Clear()
        {
            if (SARParameter.Hologram != null)
                SARParameter.Hologram.Clear();

            pbHeatMap.Image = null;

            _refreshIndex = 1;
        }

        private void HologramForm_DockStateChanged(object sender, EventArgs e)
        {
            if (this.DockState == DockState.Unknown || this.DockState == DockState.Hidden)
            {
                return;
            }
            AppConfig.hologramDockState = this.DockState;
        }

        private void tslblRefreshInterval_Click(object sender, EventArgs e)
        {

        }

        private void tslblTagEPCForHologram_Click(object sender, EventArgs e)
        {

        }
    }
}
