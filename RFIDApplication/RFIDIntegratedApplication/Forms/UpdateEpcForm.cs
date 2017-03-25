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
using RFIDIntegratedApplication.Utility;
using RFIDIntegratedApplication.service;
using RFIDIntegratedApplication.ServiceReference1;
namespace RFIDIntegratedApplication.Forms
{
    public partial class UpdateEpcForm :  DockContent
    {
        public UpdateEpcForm()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.CurrentEpcTextBox.Text = "";
            this.newEpcTextBox.Text = "";
        }

        private void CurrentEpcTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void newEpcTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            string oldEpc = this.CurrentEpcTextBox.Text;
            string newEpc = this.newEpcTextBox.Text;
            IImpinjControlService service = ServiceManager.getOneImpinjControlService();
            service.updateEpc(oldEpc, newEpc);
            ServiceManager.closeService(service);
        }
    }
}
