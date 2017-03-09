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
using RFIDIntegratedApplication.ServiceReference3;
using RFIDIntegratedApplication.service;
namespace RFIDIntegratedApplication.HolographicsForms
{
    public partial class SortingBooksForm : DockContent, IFormable
    {

        public SortingBooksForm()
        {
            InitializeComponent();
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
            Tuple<double, double, double> position;
            if (SARParameter.Trajectory.TryDequeue(out position))
            {
                string algorithmType = tssbtnAlgorithms.Text.Trim();
                CalculateType calculateType = getTypeByStr(algorithmType);
                ICalculateService iCalculateService = ServiceManager.getCalculateService(calculateType);
                if (!SARParameter.epcSet.Contains(tagInfo.EPC))
                {
                    iCalculateService.init(tagInfo.EPC, SARParameter.confParam);
                    SARParameter.epcSet.Add(tagInfo.EPC);
                }
                CalculateServiceClient client = (CalculateServiceClient)iCalculateService;
                iCalculateService.calculate(tagInfo.EPC, position.Item1, position.Item2, position.Item3, tagInfo.Frequency, tagInfo.AcutalPhaseInRadian);
                ServiceManager.closeService(iCalculateService);
                //DisplayLocalizationResult(tagInfo);
            }
        }

        //从队列中去除一个TagPos
        public void SAR(TagPos tagPos)
        {
            TagInfo tagInfo = tagPos.tagInfo;
            string algorithmType = tssbtnAlgorithms.Text.Trim();
            CalculateType calculateType = getTypeByStr(algorithmType);
            ICalculateService iCalculateService = ServiceManager.getCalculateService(calculateType);
            if (!SARParameter.epcSet.Contains(tagInfo.EPC))
            {
                iCalculateService.init(tagInfo.EPC, SARParameter.confParam);
                SARParameter.epcSet.Add(tagInfo.EPC);
            }
            Tuple<double, double, double> position = tagPos.pos;
            iCalculateService.calculate(tagInfo.EPC, position.Item1, position.Item2, position.Item3, tagInfo.Frequency, tagInfo.AcutalPhaseInRadian);
            ServiceManager.closeService(iCalculateService);
        }

        private CalculateType getTypeByStr(string calculateTypeStr)
        {
            string[] calTypeStrArray = new string[] { "Origin SAR", "Tagoram-AH", "Tagoram-DAH", "MobiTagbot" };
            CalculateType[] calTypes = new CalculateType[] { CalculateType.ORIGIN_SAR };
            for (int i = 0; i < calTypeStrArray.Length; ++i)
            {
                if (calculateTypeStr.Equals(calTypeStrArray[i]))
                {
                    return calTypes[i];
                }
            }
            return CalculateType.NOT_EXIST;
        }



        /* private void DisplayLocalizationResult(TagInfo tagInfo)
          {
              //   tbxDisplay.AppendText("Round " + tagInfo.TotalTagCount + ": " + tagInfo.EPC + " (" + SARParameter.PredictedX + "," + SARParameter.PredictedY+ ","+SARParameter.PredictedZ+ ")" + "\r\n");
              this.BeginInvoke(method: new Action(() =>
              {
                  tbxDisplay.SelectionStart = tbxDisplay.Text.Length;
                  tbxDisplay.ScrollToCaret();
              }));
          }*/

        /// <summary>
        /// Clear all components created by this form before inventroring 
        /// </summary>
        public void Clear()
        {
            tbxDisplay.Clear();
            string algorithmType = tssbtnAlgorithms.Text.Trim();
            CalculateType calculateType = getTypeByStr(algorithmType);
            ICalculateService iCalculateService = ServiceManager.getCalculateService(calculateType);
            iCalculateService.clearAll();
            ServiceManager.closeService(iCalculateService);
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

        private void btnBook7_Click(object sender, EventArgs e)
        {

        }
    }
}
