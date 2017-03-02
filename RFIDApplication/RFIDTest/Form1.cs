using RFIDIntegratedApplication.Analysis;
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

namespace RFIDTest
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            AppMath math = new AppMath();
            Console.WriteLine(math.CalculateVariance(1));
            Console.WriteLine(math.CalculateVariance(1));
            Console.WriteLine(math.CalculateVariance(1));
            Console.WriteLine(math.CalculateVariance(1));
            Console.WriteLine(math.CalculateVariance(1));
        }

        //public void ShowDockContent()
        //{
        //    var dockContent = new NewDockContent();
        //    dockContent.Show(this.dockPanel, DockState.Document);
        //}
    }
}
