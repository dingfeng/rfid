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
namespace RFIDIntegratedApplication
{
    public partial class TagTableForm : DockContent
    {
        public TagTableForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Given the column number and column valuem, find the corresponding row
        /// </summary>
        /// <param name="dgv"></param>
        /// <param name="colNumber"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public int FindRowWithCell(DataGridView dgv, int colNumber, string value)
        {
            for (int i = 0; i < dgv.Rows.Count; i++)
            {
                if (value == dgv.Rows[i].Cells[colNumber].Value.ToString())
                {
                    return i;
                }
            }
            return Int32.MinValue;
        }

        /// <summary>
        /// When a new tag report comes, update the datagridview in TagTableForm
        /// </summary>
        /// <param name="tagInfo">an object containing all information of a tag in one tag report</param>
        public void UpdateTagTable(TagInfo tagInfo)
        {
            int foundRowIndex = FindRowWithCell(dgvTagTable, 0, tagInfo.EPC);

            if (foundRowIndex != Int32.MinValue)
            {
                dgvTagTable.Rows[foundRowIndex].Cells[0].Value = tagInfo.EPC;
                dgvTagTable.Rows[foundRowIndex].Cells[1].Value = tagInfo.Antenna.ToString();
                dgvTagTable.Rows[foundRowIndex].Cells[2].Value = tagInfo.ChannelIndex.ToString();
                dgvTagTable.Rows[foundRowIndex].Cells[3].Value = tagInfo.RSSI.ToString();
                dgvTagTable.Rows[foundRowIndex].Cells[4].Value = Math.Round(tagInfo.AcutalPhaseInRadian, 3).ToString();
                dgvTagTable.Rows[foundRowIndex].Cells[5].Value = tagInfo.DopplerShift.ToString();
                dgvTagTable.Rows[foundRowIndex].Cells[6].Value = tagInfo.Velocity.ToString();
                dgvTagTable.Rows[foundRowIndex].Cells[7].Value = Convert.ToString(Convert.ToInt32(dgvTagTable.Rows[foundRowIndex].Cells[7].Value)+1);
            }
            else
            {
                int index = dgvTagTable.Rows.Add();
                dgvTagTable.Rows[index].Cells[0].Value = tagInfo.EPC;
                dgvTagTable.Rows[index].Cells[1].Value = tagInfo.Antenna.ToString();
                dgvTagTable.Rows[index].Cells[2].Value = tagInfo.ChannelIndex.ToString();
                dgvTagTable.Rows[index].Cells[3].Value = tagInfo.RSSI.ToString();
                dgvTagTable.Rows[index].Cells[4].Value = tagInfo.AcutalPhaseInRadian.ToString();
                dgvTagTable.Rows[index].Cells[5].Value = tagInfo.DopplerShift.ToString();
                dgvTagTable.Rows[index].Cells[6].Value = tagInfo.Velocity.ToString();
                dgvTagTable.Rows[index].Cells[7].Value = Convert.ToString(1);
            }
        }

        /// <summary>
        /// Clear all rows in the datagridview
        /// </summary>
        public void ClearDataGridView()
        {
            dgvTagTable.Rows.Clear();
        }

        private void TagTableForm_DockStateChanged(object sender, EventArgs e)
        {
            if (this.DockState == DockState.Unknown || this.DockState == DockState.Hidden)
            {
                return;
            }
            AppConfig.tagTableDockState = this.DockState;
        }

        /// <summary>
        /// Mark the index in front of each row
        /// </summary>
        private void dgvTagTable_RowStateChanged(object sender, DataGridViewRowStateChangedEventArgs e)
        {
            e.Row.HeaderCell.Value = string.Format("{0}", e.Row.Index);
        }
    }
}
