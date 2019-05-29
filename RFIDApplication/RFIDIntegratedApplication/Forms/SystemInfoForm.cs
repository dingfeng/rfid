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

namespace RFIDIntegratedApplication.Forms
{
    public partial class SystemInfoForm : DockContent
    {
        public const long BASE_TIME = 130000000000000000;
        public SystemInfoForm()
        {
            InitializeComponent();
            /*  long time = 1484287144123018;
              DateTime dateTime = DateTime.FromFileTimeUtc(131484287144123018);
              Console.WriteLine(dateTime.ToUniversalTime().ToString());*/
        }

        private void SystemInfoForm_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        public void updateTime(long time)
        {
            if (this.Visible)
            {
                time += BASE_TIME;
                DateTime dateTime = DateTime.FromFileTimeUtc(time);
                this.readerTimeValue.BeginInvoke(method: new Action(() =>
                {
                    this.readerTimeValue.Text = dateTime.ToLocalTime().ToString() + " " + dateTime.Millisecond.ToString();
                }));

            }
        }
    }
}
