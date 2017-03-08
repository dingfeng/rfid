using RFIDIntegratedApplication.Analysis;
using RFIDIntegratedApplication.Utility;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WeifenLuo.WinFormsUI.Docking;
using System.Threading;
using RFIDIntegratedApplication.ServiceReference2;
using RFIDIntegratedApplication.service;
namespace RFIDIntegratedApplication.HolographicsForms
{
    public partial class LinearGuideForm : DockContent, IFormable
    {
        bool _isFirstPoint;
        double _x;
        double _y;
        double _z;
        double _angle;
        Thread _posThread;
        delegate void D(float x, float y);
        bool dmcConnected;
        public  LinearGuideForm()
        {
            InitializeComponent();

            SARParameter.Trajectory = new ConcurrentQueue<Tuple<double, double, double>>();
            SARParameter.tagPosQueue = new ConcurrentQueue<TagPos>();
        }

        public void updatePos()
        {
                while (true)
                {
                   
                    IDmcControlService service = ServiceManager.getOneDmcControlService();
                    List<DMCPosDto> posList = new List<DMCPosDto>(service.tryDequeue());
                    ServiceManager.closeService(service);
                    if (posList.Count > 0)
                    {
                        foreach (DMCPosDto dmcPosDto in posList)
                        {
                            PhaseLocating.getInstance().addPositionRecord(dmcPosDto.x, dmcPosDto.y, dmcPosDto.microSecond);
                        }
                        DMCPosDto lastPosDto = posList.Last();
                        D posD = new D(showPosition);
                        this.btnHorizontalRun.Invoke(posD, lastPosDto.x, lastPosDto.y);
                    }
                    Thread.Sleep(10);
                    
                }
            
        }

        /// <summary>
        /// Update component status
        /// </summary>
        /// <param name="flag">indicates starting or stoping inventorying</param>
        /// <param name="isSimulation">Indicates whether it is simulation</param>
        public void UpdateComponentStatus(int flag, bool isSimulation)
        {
            if (isSimulation)
            {
                rbtnProvidedByDevice.Enabled = false;
                tbxPort.Enabled = false;
                tbxSetHorizontalPos.Enabled = false;
                btnHorizontalRun.Enabled = false;
                tbxSetRotatingPos.Enabled = false;
                btnRotatingRun.Enabled = false;
                btnOriginPoint.Enabled = false;
                btnEmergencyStop.Enabled = false;
                btnResetHorizontalPos.Enabled = false;
                btnResetRotatingPos.Enabled = false;
            }

            if (flag == 0)
            {
                gbTrajectory.Enabled = false;
            }
            else
            {
                gbTrajectory.Enabled = true;
            }
        }

        /// <summary>
        /// Calculate trajectory
        /// </summary>
        /// <param name="time">The period between two sampling points</param>
        /// <returns>The coordinate of sampling points</returns>
        public void CalculateTrajectory(double time)
        {
            if (_isFirstPoint)
            {
                SARParameter.Trajectory.Enqueue(new Tuple<double, double, double>(_x, _y, _z));
                _isFirstPoint = false;
            }
            else
            {
                if (rbtnCalculatedByApplication.Checked)
                {
                    switch (cbHorizontalDirection.Text)
                    {
                        case "+X":
                            _x += Convert.ToDouble(tbxHorizontalSpeed.Text.Trim()) * time;
                            break;
                        case "-X":
                            _x -= Convert.ToDouble(tbxHorizontalSpeed.Text.Trim()) * time;
                            break;
                        case "+Y":
                            _y += Convert.ToDouble(tbxHorizontalSpeed.Text.Trim()) * time;
                            break;
                        case "-Y":
                            _y -= Convert.ToDouble(tbxHorizontalSpeed.Text.Trim()) * time;
                            break;
                        case "+Z":
                            _z += Convert.ToDouble(tbxHorizontalSpeed.Text.Trim()) * time;
                            break;
                        case "-Z":
                            _z -= Convert.ToDouble(tbxHorizontalSpeed.Text.Trim()) * time;
                            break;
                        default:
                            break;
                    }

                    switch (cbRotatingDirection.Text)
                    {
                        case "Clockwise":

                            break;
                        case "Counterclockwise":

                            break;
                        default:
                            break;
                    }
                }

                DisplayPositon();

                //Console.WriteLine("***linear" + _x);
                SARParameter.Trajectory.Enqueue(new Tuple<double, double, double>(_x, _y, _z));
            }
        }

        private void DisplayPositon()
        {
            lblDisplayHorizontalPosition.Text = "(" + _x + ", " + _y + ", " + _z + ")";
            lblDisplayRotatingPosition.Text = _angle.ToString();
        }

        /// <summary>
        /// Clear trajectory in the SARParameter
        /// </summary>
        /// <param name="trajctory">Trajectory of the SARParameter</param>
        private void ClearTrajctory(ConcurrentQueue<Tuple<double, double, double>> trajctory)
        {
            Tuple<double, double, double> garbage;
            while (trajctory.TryDequeue(out garbage))
            {

            }
        }

        private void ClearTagPos(ConcurrentQueue<TagPos> tagPosQueue)
        {
            TagPos tagPos;
            while(tagPosQueue.TryDequeue(out tagPos))
            {

            }
        }

        /// <summary>
        /// Clear all components created by this form before Inventroring  
        /// </summary>
        public void Clear()
        {
            _isFirstPoint = true;

            _x = Convert.ToDouble(tbxXStart.Text);
            _y = Convert.ToDouble(tbxYStart.Text);
            _z = Convert.ToDouble(tbxZStart.Text);

            _angle = Convert.ToDouble(tbxSetRotatingPos.Text);
            ClearTrajctory(SARParameter.Trajectory);
            ClearTagPos(SARParameter.tagPosQueue);
        }

        private void LinearGuideForm_DockStateChanged(object sender, EventArgs e)
        {
            if (this.DockState == DockState.Unknown || this.DockState == DockState.Hidden)
            {
                return;
            }
            AppConfig.linearGuideDockState = this.DockState;
        }

        private void LinearGuideForm_Load(object sender, EventArgs e)
        {

        }

        private void btnHorizontalRun_Click(object sender, EventArgs e)
        {
            double horizontalFinalPos = Convert.ToDouble(this.tbxSetHorizontalPos.Text);  //单位为m
            double horizontalSpeed = Convert.ToDouble(this.tbxHorizontalSpeed.Text);        //单位为m/s
            IDmcControlService service = ServiceManager.getOneDmcControlService();
            service.horizontalRun(horizontalFinalPos, horizontalSpeed);
            ServiceManager.closeService(service);
        }

        private void btnRotatingRun_Click(object sender, EventArgs e)
        {
            double rotatingFinalAngle = Convert.ToDouble(this.tbxSetRotatingPos.Text);
            double rotatingSpeed = Convert.ToDouble(this.tbxSetRotatingSpeed.Text);
            IDmcControlService service = ServiceManager.getOneDmcControlService();
            service.rotatingRun(rotatingFinalAngle, rotatingSpeed);
            ServiceManager.closeService(service);
        }


        private void showPosition(float x,float y)
        {
            this.lblDisplayRotatingPosition.Text = String.Format("{0:N1}", y);
            this.lblDisplayHorizontalPosition.Text = String.Format("{0:N1}", x);
        }

       

        private void enableBtnHorizontal()
        {
            this.btnHorizontalRun.Enabled = true;
        }

        private void enableBtnRotating()
        {
            this.btnRotatingRun.Enabled = true;
        }

        private void btnResetHorizontalPos_Click(object sender, EventArgs e)
        {
            //水平位置清零
            IDmcControlService service = ServiceManager.getOneDmcControlService();
            service.resetHorizontalPos();
            ServiceManager.closeService(service);
        }

        private void btnResetRotatingPos_Click(object sender, EventArgs e)
        {
            //旋转位置清零
            IDmcControlService service = ServiceManager.getOneDmcControlService();
            service.resetRotatingPos();
            ServiceManager.closeService(service);
        }

        private void btnOriginPoint_Click(object sender, EventArgs e)
        {
            IDmcControlService service = ServiceManager.getOneDmcControlService();
            service.originPoint();
            ServiceManager.closeService(service);
        }

        private void btnEmergencyStop_Click(object sender, EventArgs e)
        {
            IDmcControlService service = ServiceManager.getOneDmcControlService();
            service.emergencyStop();
            ServiceManager.closeService(service);
        }

        private void LinearGuideForm_FormClosed(object sender, FormClosedEventArgs e)
        {
         
        }

        private void LinearGuideForm_Shown(object sender, EventArgs e)
        {

        }

        public void stopDmc()
        {
            if (dmcConnected)
            {
                //关闭导轨控制板
                IDmcControlService service = ServiceManager.getOneDmcControlService();
                service.shutdown();
                ServiceManager.closeService(service);
                try
                {
                    this._posThread.Abort();
                }
                catch
                {

                }
                dmcConnected = false;
            }
        }

        private void lblDisplayHorizontalPosition_Click(object sender, EventArgs e)
        {

        }

        private void gbTrajectory_Enter(object sender, EventArgs e)
        {

        }

        private void tbxXStart_TextChanged(object sender, EventArgs e)
        {

        }

        private void tbxHorizontalSpeed_TextChanged(object sender, EventArgs e)
        {

        }

        private void tbxZStart_TextChanged(object sender, EventArgs e)
        {

        }

        private void LinearGuideForm_Leave(object sender, EventArgs e)
        {
            
        }

        private void LinearGuideForm_FormClosing(object sender, FormClosingEventArgs e)
        {
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //初始化导轨控制板
             IDmcControlService service = ServiceManager.getOneDmcControlService();
            service.beginAsync();
             ServiceManager.closeService(service);
            _posThread = new Thread(new ThreadStart(updatePos));
            _posThread.Start();
            dmcConnected = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //关闭导轨
            IDmcControlService service = ServiceManager.getOneDmcControlService();
            service.shutdownAsync();
            ServiceManager.closeService(service);
            try
            {
                if (_posThread != null)
                {
                    _posThread.Abort();
                }
            }
            catch
            {

            }
            dmcConnected = false;
        }

        private void tbxSetHorizontalPos_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
