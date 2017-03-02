using RFIDIntegratedApplication.Analysis;
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

namespace RFIDIntegratedApplication.HolographicsForms
{
    public partial class SearchRegionForm : DockContent, IFormable
    {
        public SearchRegionForm()
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
            if(flag == 0)
            {
                tbxSRXStart.Enabled = false;
                tbxSRXInterval.Enabled = false;
                tbxSRXEnd.Enabled = false;
                tbxSRYStart.Enabled = false;
                tbxSRYInterval.Enabled = false;
                tbxSRYEnd.Enabled = false;
                tbxSRZStart.Enabled = false;
                tbxSRZInterval.Enabled = false;
                tbxSRZEnd.Enabled = false;
            }
            else
            {
                tbxSRXStart.Enabled = true;
                tbxSRXInterval.Enabled = true;
                tbxSRXEnd.Enabled = true;
                tbxSRYStart.Enabled = true;
                tbxSRYInterval.Enabled = true;
                tbxSRYEnd.Enabled = true;
                tbxSRZStart.Enabled = true;
                tbxSRZInterval.Enabled = true;
                tbxSRZEnd.Enabled = true;
            }
        }

        /// <summary>
        /// Initialize sar paprameter related with search region
        /// </summary>
        public void InitializeSearchRegion()
        {
            // Calculate the number of grids in each axis
            int gridNumX = (int)((Convert.ToInt32(tbxSRXEnd.Text.Trim()) - Convert.ToInt32(tbxSRXStart.Text.Trim())) / Convert.ToDouble(tbxSRXInterval.Text.Trim())) + 1;
            int gridNumY = (int)((Convert.ToInt32(tbxSRYEnd.Text.Trim()) - Convert.ToInt32(tbxSRYStart.Text.Trim())) / Convert.ToDouble(tbxSRYInterval.Text.Trim())) + 1;
            int gridNumZ = (int)((Convert.ToInt32(tbxSRZEnd.Text.Trim()) - Convert.ToInt32(tbxSRZStart.Text.Trim())) / Convert.ToDouble(tbxSRZInterval.Text.Trim())) + 1;
            
            for (int i = 0; i < gridNumX; i++)
            {
                SARParameter.GridX.Add(Convert.ToDouble(tbxSRXStart.Text.Trim()) + i * Convert.ToDouble(tbxSRXInterval.Text.Trim()));
                
            }
            //Console.WriteLine("****X" + SARParameter.GridX.Count);

            for (int i = 0; i < gridNumY; i++)
            {
                SARParameter.GridY.Add(Convert.ToDouble(tbxSRYStart.Text.Trim()) + i * Convert.ToDouble(tbxSRYInterval.Text.Trim()));
                //Console.WriteLine("****Y" + SARParameter.GridY[i]);
            }
            //Console.WriteLine("****Y" + SARParameter.GridY.Count);

            for (int i = 0; i < gridNumZ; i++)
            {
                SARParameter.GridZ.Add(Convert.ToDouble(tbxSRZStart.Text.Trim()) + i * Convert.ToDouble(tbxSRZInterval.Text.Trim()));
                //Console.WriteLine("****Z" + SARParameter.GridZ[i]);
            }
        }

        /// <summary>
        /// Clear all components created by this form before Inventroring 
        /// </summary>
        public void Clear()
        {
            SARParameter.GridX.Clear();
            SARParameter.GridY.Clear();
            SARParameter.GridZ.Clear();
        }

        private void SearchRegionForm_DockStateChanged(object sender, EventArgs e)
        {
            if (this.DockState == DockState.Unknown || this.DockState == DockState.Hidden)
            {
                return;
            }
            AppConfig.searchRegionDockState = this.DockState;
        }

        private void SearchRegionForm_Load(object sender, EventArgs e)
        {
            // Initialize search region
            SARParameter.GridX = new List<double>();
            SARParameter.GridY = new List<double>();
            SARParameter.GridZ = new List<double>();     // ?
        }

        private void tbxSRXEnd_TextChanged(object sender, EventArgs e)
        {

        }

        private void tbxSRXInterval_TextChanged(object sender, EventArgs e)
        {

        }

        private void tbxSRYInterval_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
