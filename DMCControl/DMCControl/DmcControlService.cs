using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Collections.Concurrent;
using System.ServiceModel;
namespace DMCControl
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single,
             ConcurrencyMode = ConcurrencyMode.Single)]
    public class DmcControlService : IDmcControlService
    {
        long xPos;
        long yPos;
        bool rotatingEnabled;  //是否可以进行旋转
        bool horizontalEnabled;  //是否可以进行水平运动
        int xNowPos = 0, yNowPos = 0;
        float xNowPosShow = 0;
        float yNowPosShow = 0;
        bool enqueable;
        ConcurrentQueue<DMCPosDto> posQueue = new ConcurrentQueue<DMCPosDto>();
        bool connected;
        public void begin()
        {
            if (connected)
            {
                Console.WriteLine("be begun before status : connected");
                return;
            }
            RFIDManager.begin();
            connected = true;
            Console.WriteLine("status: connected");
        }


        public List<DMCPosDto> tryDequeue()
        {
            DMCPosDto dmcPosDto;
            List<DMCPosDto> posList = new List<DMCPosDto>();
            while (posQueue.TryDequeue(out dmcPosDto))
            {
                posList.Add(dmcPosDto);
            }
            return posList;
        }

        public float[] getCurrentPos()
        {
            return new float[] { xNowPosShow, yNowPosShow };
        }



        public void emergencyStop()
        {
            RFIDMove.motorStop(ref RFIDMove.mAxis[0]);
            RFIDMove.motorStop(ref RFIDMove.mAxis[1]);
            RFIDMove.emgStop();
            Thread checkInputThread = new Thread(new ThreadStart(this.sendPos));
            checkInputThread.Name = "emg stop send pos";
            checkInputThread.Start();
            enqueable = false;
        }

        public void horizontalRun(double finalPos, double speed)
        {
            if (horizontalEnabled)
            {
                RFIDControl.dmc_write_sevon_pin(0, 0, 0);
                Thread.Sleep(10);
                horizontalEnabled = false;
                xPos = Convert.ToInt32((finalPos * 1000 * RFIDMove.line_coefficient));
                RFIDMove.mAxis[0].m_speed_max = Convert.ToInt32((speed * 1000 * RFIDMove.line_coefficient));
                RFIDMove.singleAxisMove(ref RFIDMove.mAxis[0], xPos, RFIDMove.ABS_MODE);
                // send pos thread 
                Thread checkInputThread = new Thread(new ThreadStart(this.sendPos));
                checkInputThread.Name = "horizontal send pos";
                checkInputThread.Start();
                enqueable = true;
            }
        }


        public void originPoint()
        {
            RFIDMove.goHomeFlag = 1;
            RFIDMove.startGoHome = 1;
            RFIDControl.dmc_write_sevon_pin(0, 0, 0);
            RFIDControl.dmc_write_sevon_pin(0, 1, 0);
            // send pos thread 
            Thread checkInputThread = new Thread(new ThreadStart(this.sendPos));
            checkInputThread.Name = "orgin point send pos";
            checkInputThread.Start();
            enqueable = false;
        }

        public void resetHorizontalPos()
        {
            //水平位置清零
            RFIDControl.dmc_set_encoder(RFIDMove.mAxis[0].m_card_num, RFIDMove.mAxis[0].m_axis_num, 0);
            RFIDControl.dmc_set_position(RFIDMove.mAxis[0].m_card_num, RFIDMove.mAxis[0].m_axis_num, 0);
        }

        public void resetRotatingPos()
        {
            //旋转位置清零
            RFIDControl.dmc_set_encoder(RFIDMove.mAxis[1].m_card_num, RFIDMove.mAxis[1].m_axis_num, 0);
            RFIDControl.dmc_set_position(RFIDMove.mAxis[1].m_card_num, RFIDMove.mAxis[1].m_axis_num, 0);
        }

        public void rotatingRun(double finalAngle, double speed)
        {
            if (rotatingEnabled)
            {
                RFIDControl.dmc_write_sevon_pin(0, 1, 0);
                Thread.Sleep(10);
                rotatingEnabled = false;
                RFIDMove.mAxis[1].m_speed_max = Convert.ToInt32((speed * 60 * RFIDMove.cicle_coefficient));
                yPos = Convert.ToInt32((finalAngle * 60 * RFIDMove.cicle_coefficient));
                RFIDMove.singleAxisMove(ref RFIDMove.mAxis[1], yPos, RFIDMove.ABS_MODE);
                // send pos thread 
                Thread checkInputThread = new Thread(new ThreadStart(this.sendPos));
                checkInputThread.Name = "rotating run send pos";
                checkInputThread.Start();
                enqueable = true;
            }
        }

        public void shutdown()
        {
            if (connected == true)
            {
                RFIDManager.shutdown();
                connected = false;
                enqueable = false;
            }
        }

        private void sendPos()
        {
            bool b = false;
            bool b_break_able = false; //第一次进入不退出
            long microSecond = 0;
            if (RFIDMove.goHomeFlag != 0)
            {
                b = true;
            }
            int period = 10;
            Thread.Sleep(period);
            while (true)
            {
                //进入临界区
                //获取位置信息 通过网络发送位置信息
                lock (this)
                {
                    if (enqueable)
                    {
                        xNowPos = RFIDControl.dmc_get_encoder(RFIDMove.mAxis[0].m_card_num, RFIDMove.mAxis[0].m_axis_num);
                        yNowPos = RFIDControl.dmc_get_encoder(RFIDMove.mAxis[1].m_card_num, RFIDMove.mAxis[1].m_axis_num);
                        xNowPosShow = xNowPos / RFIDMove.line_coefficient / 10; //mm
                        yNowPosShow = yNowPos / RFIDMove.cicle_coefficient / 10; //mm 
                        microSecond = CurrentMillis.MicroSeconds;
                        posQueue.Enqueue(new DMCPosDto(xNowPosShow, yNowPosShow, microSecond));
                    }
                }
                //离开临界区
                Thread.Sleep(10);
                if (b_break_able) //第一次循环必须读取一个位置信息，以便发送到目标IP
                {
                    if (b)
                    {
                        if (RFIDMove.goHomeFlag == 0)
                        {
                            break;
                        }
                    }
                    else if ((RFIDMove.mAxis[0].m_run_status != RFIDMove.RUN) && (RFIDMove.mAxis[1].m_run_status != RFIDMove.RUN))
                    {
                        RFIDControl.dmc_set_position(RFIDMove.mAxis[0].m_card_num, RFIDMove.mAxis[0].m_axis_num, xNowPos / 10);
                        RFIDControl.dmc_set_position(RFIDMove.mAxis[1].m_card_num, RFIDMove.mAxis[1].m_axis_num, yNowPos / 10);
                        RFIDMove.singleAxisMove(ref RFIDMove.mAxis[0], xPos, RFIDMove.ABS_MODE);
                        RFIDMove.singleAxisMove(ref RFIDMove.mAxis[1], yPos, RFIDMove.ABS_MODE);
                        Thread.Sleep(500);
                        break;
                    }
                }
                else b_break_able = true;
            }
            lock (this)
            {
                if (enqueable)
                {
                    xNowPos = RFIDControl.dmc_get_encoder(RFIDMove.mAxis[0].m_card_num, RFIDMove.mAxis[0].m_axis_num);
                    yNowPos = RFIDControl.dmc_get_encoder(RFIDMove.mAxis[1].m_card_num, RFIDMove.mAxis[1].m_axis_num);
                    xNowPosShow = xNowPos / RFIDMove.line_coefficient / 10; //mm
                    yNowPosShow = yNowPos / RFIDMove.cicle_coefficient / 10; //mm 
                    microSecond = CurrentMillis.MicroSeconds;
                    posQueue.Enqueue(new DMCPosDto(xNowPosShow, yNowPosShow, microSecond));
                }
            }
            RFIDControl.dmc_write_sevon_pin(0, 0, 1);
            RFIDControl.dmc_write_sevon_pin(0, 1, 1);
            rotatingEnabled = true;
            horizontalEnabled = true;
        }
    }
}
