using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RFIDIntegratedApplication.rfidControl.structs;
using RFIDIntegratedApplication.rfidControl.enums;
using System.Threading;
namespace RFIDIntegratedApplication.rfidControl
{
    public class RFIDMove
    {
        //静态常量
        public static readonly int AXIS_NUM = 2;
        public static readonly int X_AXIS_MAX_SPEED = 8000;
        public static readonly int Y_AXIS_MAX_SPEED = 8000;
        public static readonly int Z_AXIS_MAX_SPEED = 8000;
        public static readonly int A_AXIS_MAX_SPEED = 8000;
        public static readonly int X_AXIS_HOME_MAX_SPEED = 1000;
        public static readonly int Y_AXIS_HOME_MAX_SPEED = 1000;
        public static readonly int Z_AXIS_HOME_MAX_SPEED = 1000;
        public static readonly int A_AXIS_HOME_MAX_SPEED = 1000;
        public static readonly int WAIT_TIMER = 100;
        public static readonly ushort X = 0;
        public static readonly ushort Y = 1;
        public static readonly ushort Z = 2;
        public static readonly ushort LOW = 0;
        public static readonly ushort HIGH = 1;
        public static readonly ushort CCW = 0; //顺时针
        public static readonly ushort CW = 1; //逆时针
        public static readonly ushort ORG_OK=0;  //获取零点信号
        public static readonly ushort NO_ORG=1;  //没有零点信息
        public static readonly ushort RUN = 0;
        public static readonly ushort STOP = 1;
        public static readonly ushort DEC_STOP = 0;
        public static readonly ushort DIRECT_STOP = 1;
        public static readonly ushort REL_MODE = 0;
        public static readonly ushort ABS_MODE = 1;
        public static readonly int SEVORRATIO = 1000;
        public static readonly int PERIMETER = 40;
        public static readonly int CICLE_WHEELRATIO = 90;
        public static readonly float line_coefficient = SEVORRATIO / (PERIMETER);
        public static readonly float cicle_coefficient = (float)SEVORRATIO / (360 * 60 / CICLE_WHEELRATIO);
        //静态变量
        public static AxisInfo[] mAxis = new AxisInfo[AXIS_NUM];
        public static InterpolaType mInpterplaType;
        public static ServoInputStatus mServoIo;
        public static int goHomeFlag;
        public static int startGoHome;
        public static bool key_emg_press_flag = false;
        public static bool started;

        public static short initBoard()//初始化办卡  返回值：-1：没有卡号   0：正常
        {
            short m = RFIDControl.dmc_board_init();
            if (m <= 0)  //控制卡的初始化操作
            {
                //未找到控制卡
                Console.WriteLine("未找到控制卡");
                return -1;
            }
            for (int i = 0; i < AXIS_NUM; ++i)
            {
                mAxis[i] = new AxisInfo();
                mAxis[i].m_card_num = 0;
                mAxis[i].m_axis_num = (ushort)i;
                mAxis[i].m_home_mode = 1; //一次回零加回找
                mAxis[i].m_home_flag = 0;
                mAxis[i].m_acc_time = 0.4;
                mAxis[i].m_dcc_time = 0.4;
                mAxis[i].m_home_dir = MoveDir.FOR_WORD;
                mAxis[i].m_speed_max = 10000;//dispenser_para.motor_speed;
                mAxis[i].m_speed_max_home = 2000;//dispenser_para.go_home_speed;
                mAxis[i].m_pulse_mode = 3;
                mAxis[i].m_speed_min = 0;
                mAxis[i].m_speed_min_home = 0;
                mAxis[i].m_run_status = STOP;//停止状态
                if (i < 2)
                {
                    RFIDControl.dmc_set_inp_mode(mAxis[i].m_card_num, mAxis[i].m_axis_num, HIGH, LOW);
                    RFIDControl.dmc_set_alm_mode(mAxis[i].m_card_num, mAxis[i].m_axis_num, HIGH, HIGH, 0);//设置 伺服ALM 高电平有效   松下伺服正常情况下输出低电平
                    RFIDControl.dmc_set_counter_inmode(mAxis[i].m_card_num, mAxis[i].m_axis_num, 1);//设置编码器的计数方式   1倍频
                    RFIDControl.dmc_set_encoder(mAxis[i].m_card_num, mAxis[i].m_axis_num, 0);//设置初始值为0
                }
            }

            //两轴查补
            mInpterplaType.axis_cout = 2;//2个轴查补
            mInpterplaType.car_num = 0;//坐标系号
            mInpterplaType.card_num = 0;//卡号
            mInpterplaType.line_type = 0;//线型
            mInpterplaType.posi_mode = PositionMode.ABS_MODE;//位置模式
            mInpterplaType.m_acc_time = 3;
            mInpterplaType.m_dcc_time = 3;
            mInpterplaType.m_speed_max = X_AXIS_MAX_SPEED;
            mInpterplaType.arc_dir = CCW;
            return 0;
        }


        public static ushort startSearchHome(ref AxisInfo axisInfo)
        {
            ulong axisStatus;
            ushort orignCount = 0;
            axisInfo.m_acc_time = 0.1;
            axisInfo.m_dcc_time = 0.1;
            orign_begin:
            axisInfo.m_home_flag = 0;
            RFIDControl.dmc_set_home_pin_logic(axisInfo.m_card_num, axisInfo.m_axis_num, LOW, 0);//原点信号 低电平有效
            RFIDControl.dmc_set_pulse_outmode(axisInfo.m_card_num, axisInfo.m_axis_num, axisInfo.m_pulse_mode);  //设置脉冲输出模式
            RFIDControl.dmc_set_profile(axisInfo.m_card_num, axisInfo.m_axis_num, axisInfo.m_speed_min_home, axisInfo.m_speed_max_home, axisInfo.m_acc_time, axisInfo.m_dcc_time, 500);//设置速度曲线
            RFIDControl.dmc_set_homemode(axisInfo.m_card_num, axisInfo.m_axis_num, (ushort)axisInfo.m_home_dir, 1, (ushort)axisInfo.m_home_mode, 0);//设置回零方式  反向回原点
            orignCount++;
            axisStatus = RFIDControl.dmc_axis_io_status(axisInfo.m_card_num, axisInfo.m_axis_num);//读取轴的状态
            if (getStatus(axisStatus, (int)AxisStatus.MOTOR_ORG) != 0)//开始回原点时正在原点位置上
            {
                //		dmc_set_profile(m_axis->m_card_num,m_axis->m_axis_num,m_axis->m_speed_min_home,m_axis->m_speed_max_home,m_axis->m_acc_time,m_axis->m_dcc_time,500);//设置速度曲线
                RFIDControl.dmc_vmove(axisInfo.m_card_num, axisInfo.m_axis_num, (ushort)(axisInfo.m_home_dir == MoveDir.FOR_WORD ? MoveDir.BACK_WORD : MoveDir.FOR_WORD));//反向运动
                delayTime(WAIT_TIMER);//延时

                do
                {
                    axisStatus = RFIDControl.dmc_axis_io_status(axisInfo.m_card_num, axisInfo.m_axis_num);//读取轴的状态
                    if (startGoHome == 0)
                    {
                        return NO_ORG;
                    }
                } while (getStatus(axisStatus, (int)AxisStatus.MOTOR_ORG) != 0);//等到原点信号 变高
                RFIDControl.dmc_stop(axisInfo.m_card_num, axisInfo.m_axis_num, DIRECT_STOP);
            }

            if (getStatus(axisStatus, (int)AxisStatus.MOTOR_EL_B) != 0)//开始时在负限位
            {
                RFIDControl.dmc_vmove(axisInfo.m_card_num, axisInfo.m_axis_num, (ushort)(axisInfo.m_home_dir == MoveDir.FOR_WORD ? MoveDir.BACK_WORD : MoveDir.FOR_WORD));//反向运动
                delayTime(WAIT_TIMER);//延时
                do
                {
                    axisStatus = RFIDControl.dmc_axis_io_status(axisInfo.m_card_num, axisInfo.m_axis_num);//读取轴的状态
                    if (startGoHome == 0)
                    {
                        return NO_ORG;
                    }
                } while (getStatus(axisStatus, (int)AxisStatus.MOTOR_ORG) == 0);//查询原点信号

                do
                {
                    axisStatus = RFIDControl.dmc_axis_io_status(axisInfo.m_card_num, axisInfo.m_axis_num);//读取轴的状态
                    if (startGoHome == 0)
                    {
                        return NO_ORG;
                    }
                } while (getStatus(axisStatus, (int)AxisStatus.MOTOR_ORG) != 0);//查询消失原点信号
                RFIDControl.dmc_stop(axisInfo.m_card_num, axisInfo.m_axis_num, DIRECT_STOP);
            }

            delayTime(100);//延时

            RFIDControl.dmc_home_move(axisInfo.m_card_num, axisInfo.m_axis_num);//回零动作
            delayTime(WAIT_TIMER);//延时
            while (RFIDControl.dmc_check_done(axisInfo.m_card_num, axisInfo.m_axis_num) == RUN)      //判断当前轴状态
            {
                //遇到极限自动返回
                axisStatus = RFIDControl.dmc_axis_io_status(axisInfo.m_card_num, axisInfo.m_axis_num);//读取轴的状态
                if (getStatus(axisStatus, (int)AxisStatus.MOTOR_EL_B) != 0)//负向极限
                {
                    RFIDControl.dmc_stop(axisInfo.m_card_num, axisInfo.m_axis_num, DIRECT_STOP);
                    delayTime(WAIT_TIMER);//延时
                    RFIDControl.dmc_vmove(axisInfo.m_card_num, axisInfo.m_axis_num, (ushort)(axisInfo.m_home_dir == MoveDir.BACK_WORD ? MoveDir.FOR_WORD : MoveDir.BACK_WORD));//反向运动

                    delayTime(WAIT_TIMER);//延时
                    do
                    {
                        axisStatus = RFIDControl.dmc_axis_io_status(axisInfo.m_card_num, axisInfo.m_axis_num);//读取轴的状态
                        if (startGoHome == 0)
                        {
                            return NO_ORG;
                        }
                    } while (getStatus(axisStatus, (int)AxisStatus.MOTOR_ORG) == 0);//查询原点信号

                    do
                    {
                        axisStatus = RFIDControl.dmc_axis_io_status(axisInfo.m_card_num, axisInfo.m_axis_num);//读取轴的状态
                        if (startGoHome == 0)
                        {
                            return NO_ORG;
                        }
                    } while (getStatus(axisStatus, (int)AxisStatus.MOTOR_ORG) != 0);//查询消失原点信号
                    RFIDControl.dmc_stop(axisInfo.m_card_num, axisInfo.m_axis_num, DIRECT_STOP);
                    delayTime(100);//延时
                    RFIDControl.dmc_home_move(axisInfo.m_card_num, axisInfo.m_axis_num);//重新开始回零动作
                }
                if (getStatus(axisStatus, (int)AxisStatus.MOTOR_EL_F) != 0)//负向极限
                {
                    if (orignCount < 3)
                    {
                        goto orign_begin;
                    }
                    RFIDControl.dmc_stop(axisInfo.m_card_num, axisInfo.m_axis_num, DIRECT_STOP);
                    return NO_ORG;//没有原信号
                }
                if (startGoHome == 0)
                {
                    return NO_ORG;
                }
            }
            if (startGoHome == 0)
            {
                return NO_ORG;
            }
            delayTime(100);
            RFIDControl.dmc_set_position(axisInfo.m_card_num, axisInfo.m_axis_num, 0);         //设置零点
            axisInfo.m_home_flag = 1;


            //设定脉冲模式及逻辑方向（此处脉冲模式固定为P+D方向：脉冲+方向）	
            RFIDControl.dmc_set_pulse_outmode(axisInfo.m_card_num, axisInfo.m_axis_num, axisInfo.m_pulse_mode);

            RFIDControl.dmc_set_profile(axisInfo.m_card_num, axisInfo.m_axis_num, axisInfo.m_speed_min, axisInfo.m_speed_max, axisInfo.m_acc_time, axisInfo.m_dcc_time, 0);
            //设定S段时间
            RFIDControl.dmc_set_s_profile(axisInfo.m_card_num, axisInfo.m_axis_num, 0, 0.4);


            RFIDControl.dmc_set_encoder(axisInfo.m_card_num, axisInfo.m_axis_num, 0);//设置初始值为0
            RFIDControl.dmc_set_position(axisInfo.m_card_num, axisInfo.m_axis_num, 0);//初始位置设为零
            RFIDControl.dmc_set_equiv(axisInfo.m_card_num, axisInfo.m_axis_num, 1);
            axisInfo.m_pulse_mode = 3;
            axisInfo.m_home_flag = 1;

            return ORG_OK;

        }

        public static short singleAxisMove(ref AxisInfo axisInfo, long pos, ushort positionMode)
        {
            short m=0;
            if (axisInfo.m_run_status == RUN)
            {
                return -1;
            }
            RFIDControl.dmc_set_pulse_outmode(axisInfo.m_card_num, axisInfo.m_axis_num, axisInfo.m_pulse_mode);

            RFIDControl.dmc_set_profile(axisInfo.m_card_num, axisInfo.m_axis_num, axisInfo.m_speed_min, axisInfo.m_speed_max, axisInfo.m_acc_time, axisInfo.m_dcc_time, 100);
            //设定S段时间
            RFIDControl.dmc_set_s_profile(axisInfo.m_card_num, axisInfo.m_axis_num, 0, 0.4);
            m = RFIDControl.dmc_pmove(axisInfo.m_card_num, axisInfo.m_axis_num, pos, positionMode);
            
            checkDmcMessage(m);
            axisInfo.m_run_status = RUN;
            return m;
        }

        public static short lineInterpolation()
        {
            short m;
            if (mInpterplaType.run_flag == RUN)
            {
                return -1;
            }
            ushort[] axis = new ushort[] { 0, 1, 2, 3 };
            RFIDControl.dmc_set_vector_profile_multicoor(mInpterplaType.card_num, mInpterplaType.car_num, mInpterplaType.m_speed_min, mInpterplaType.m_speed_max, mInpterplaType.m_acc_time, mInpterplaType.m_dcc_time, 0);      //设置插补速度
                                                                                                                                                                                                                                 //运行到起点
            mInpterplaType.m_ndist[X] = mInpterplaType.m_start[X] - mAxis[X].m_positon;
            mInpterplaType.m_ndist[Y] = mInpterplaType.m_start[Y] - mAxis[Y].m_positon;
            m = RFIDControl.dmc_line_multicoor(mInpterplaType.card_num, mInpterplaType.car_num, mInpterplaType.axis_cout, axis, mInpterplaType.m_ndist, REL_MODE);  //执行
            mInpterplaType.run_flag = RUN;
            checkDmcMessage(m);
            while (mInpterplaType.run_flag == RUN);
            //运行到终点
            mInpterplaType.m_ndist[X] = mInpterplaType.m_end[X] - mInpterplaType.m_start[X];
            mInpterplaType.m_ndist[Y] = mInpterplaType.m_end[Y] - mInpterplaType.m_start[Y];
            m = RFIDControl.dmc_line_multicoor(mInpterplaType.card_num, mInpterplaType.car_num, mInpterplaType.axis_cout, axis, mInpterplaType.m_ndist, REL_MODE);  //执行
            mInpterplaType.run_flag = RUN;
            checkDmcMessage(m);
            return m;
        }

        public static short arcInterpolation(long[] targetPos, long[] centerPos, ushort arcDir, PositionMode positionMode) // 圆弧查补
        {
            short m;
            if (mInpterplaType.run_flag == RUN)
            {
                return -1;
            }
            //运行到起点坐标
            ushort[] axis1 = new ushort[] { 0, 1, 2, 3 };
            RFIDControl.dmc_set_vector_profile_multicoor(mInpterplaType.card_num, mInpterplaType.car_num, mInpterplaType.m_speed_min, mInpterplaType.m_speed_max, mInpterplaType.m_acc_time, mInpterplaType.m_dcc_time, 0);      //设置插补速度
                                                                                                                                                                                                                                 //运行到起点
            mInpterplaType.m_ndist[X] = mInpterplaType.m_start[X] - mAxis[X].m_positon;
            mInpterplaType.m_ndist[Y] = mInpterplaType.m_start[Y] - mAxis[Y].m_positon;
            m = RFIDControl.dmc_line_multicoor(mInpterplaType.card_num, mInpterplaType.car_num, mInpterplaType.axis_cout, axis1, mInpterplaType.m_ndist, REL_MODE);  //执行
            mInpterplaType.run_flag = RUN;
            checkDmcMessage(m);
            while (mInpterplaType.run_flag == RUN) ;
            //开始画轨迹
            RFIDControl.dmc_set_vector_profile_multicoor(mInpterplaType.card_num, mInpterplaType.car_num, mInpterplaType.m_speed_min, mInpterplaType.m_speed_max, mInpterplaType.m_acc_time, mInpterplaType.m_dcc_time, 0);      //设置插补速度
            ushort[] axis = new ushort[] { X, Y };

            m = RFIDControl.dmc_arc_move_multicoor(mInpterplaType.card_num, mInpterplaType.car_num, axis, targetPos, centerPos, arcDir, (ushort)positionMode); //以当前点为起点，半径为2000 pulse,顺时针走一个半圆，相对模式
            mInpterplaType.run_flag = RUN;
            checkDmcMessage(m);

            return m;
        }

        public static void emgStop()  //紧急停止
        {
            if (RFIDControl.dmc_check_done_multicoor(mInpterplaType.card_num, mInpterplaType.car_num) == RUN)
            {
                RFIDControl.dmc_stop_multicoor(0, 0, 1);
            }
            RFIDControl.dmc_stop(0, 0, DIRECT_STOP);//直接停止
            RFIDControl.dmc_stop(0, 1, DIRECT_STOP);//直接停止
            RFIDControl.dmc_stop(0, 2, DIRECT_STOP);//直接停止
            mInpterplaType.run_flag = STOP;
            startGoHome = 0;
        }

        public static void motorStopMulti() //插补停止
        {
            RFIDControl.dmc_stop_multicoor(mInpterplaType.card_num, mInpterplaType.car_num, DIRECT_STOP);      //减速停止
        }

        public static void motorStop(ref AxisInfo axisInfo)
        {
            RFIDControl.dmc_stop(axisInfo.m_card_num, axisInfo.m_axis_num, DIRECT_STOP);//直接停止
        }

        public static void servoErc(ref AxisInfo axisInfo)
        {
            RFIDControl.dmc_write_erc_pin(axisInfo.m_card_num, axisInfo.m_axis_num, LOW);
            Thread.Sleep(100);
            RFIDControl.dmc_write_erc_pin(axisInfo.m_card_num, axisInfo.m_axis_num, HIGH);
        }

        public static void closeBoard()
        {
            mServoIo.check_flag = 1;
            for (int i = 0; i < AXIS_NUM; ++i)
            {
                RFIDControl.dmc_write_sevon_pin(mAxis[i].m_card_num, mAxis[i].m_axis_num, HIGH);//伺服OFF
                RFIDControl.dmc_set_inp_mode(mAxis[i].m_card_num, mAxis[i].m_axis_num, LOW, LOW);//设置伺服 INP 低电平有效
                RFIDControl.dmc_set_alm_mode(mAxis[i].m_card_num, mAxis[i].m_axis_num, LOW, HIGH, 0);//设置 伺服ALM 高电平有效   松下伺服正常情况下输出低电平
            }
            RFIDControl.dmc_board_close();
        }

        public static string checkDmcMessage(short m)
        {
            string str = "";
            switch (m)
            {
                case 0:
                    return str;
                case 1:
                    str = "未知错误";
                    break;
                case 2:
                    str = "参数错误";
                    emgStop();//紧急停止
                    break;
                case 3:
                    str = "PCI通讯超时";
                    break;
                case 4:
                    str = "轴正在运动";
                    break;
                case 6:
                    str = "连续插补错误";
                    break;
                case 8:
                    str = "无法连接错误";
                    break;
                case 9:
                    str = "卡号链接错误";
                    break;
                case 10:
                    str = "PCI异常，请检查PCI槽位是否松动";
                    break;
                case 12:
                    str = "固件文件错误";
                    break;
                case 14:
                    str = "固件不匹配";
                    break;
                case 20:
                    str = "固件参数错误";
                    break;
                case 22:
                    str = "固件当前状态不允许操作";
                    emgStop();//紧急停止
                    break;
                case 24:
                    str = "固件不支持的功能";
                    break;
                case 25:
                    str = "密码错误";
                    break;
                case 26:
                    str = "密码错误输入次数受限";
                    break;
                default:
                    str = "错误码为：" + m;
                    break;
            }
            return str;
        }

        public static ulong delayTime(int t)
        {
            Thread.Sleep(t);
            return 0;
        }


        public static void moveEventHandle()
        {
            while (started)
            {
                if (goHomeFlag != 0)
                {
                    if (startGoHome != 0)
                    {
                        if (NO_ORG == startSearchHome(ref mAxis[X]))
                        {
                            // AfxMessageBox(_T("X轴没有找到原点！"), MB_OK, MB_ICONEXCLAMATION);
                            //m_axis[0].m_home_flag=false;
                            Console.WriteLine("X轴没有找到原点");
                        }
                        else
                        {
                            delayTime(100);
                            RFIDControl.dmc_write_sevon_pin(0, 0, LOW);
                            singleAxisMove(ref mAxis[X], (long)(-42 * line_coefficient), ABS_MODE);
                            while (RFIDControl.dmc_check_done(mAxis[X].m_card_num, mAxis[X].m_axis_num) == RUN) ;
                            RFIDControl.dmc_write_sevon_pin(0, 0, HIGH);
                            delayTime(100);
                            RFIDControl.dmc_set_position(mAxis[X].m_card_num, mAxis[X].m_axis_num, 0);         //设置零点
                            RFIDControl.dmc_set_encoder(0, 0, 0);//设置初始值为0
                        }
                            ;//m_axis[0].m_home_flag=true;
                    }
                    if (startGoHome != 0)
                    {
                        if (NO_ORG == startSearchHome(ref mAxis[Y]))
                        {
                            // AfxMessageBox(_T("U轴没有找到原点！"), MB_OK, MB_ICONEXCLAMATION);
                            Console.WriteLine("U轴没有找到原点");
                        }
                        else
                        {
                            delayTime(100);
                            RFIDControl.dmc_write_sevon_pin(0, 1, LOW);
                            singleAxisMove(ref mAxis[Y], (long)(820 * cicle_coefficient), ABS_MODE);
                            while (RFIDControl.dmc_check_done(mAxis[Y].m_card_num, mAxis[Y].m_axis_num) == RUN) ;
                            RFIDControl.dmc_write_sevon_pin(0, 1, HIGH);
                            delayTime(100);
                            RFIDControl.dmc_set_position(mAxis[Y].m_card_num, mAxis[Y].m_axis_num, 0);         //设置零点
                            RFIDControl.dmc_set_encoder(0, 1, 0);//设置初始值为0
                        }
                    }

                    delayTime(100);
                    startGoHome = 0;
                    goHomeFlag = 0;
                }
            }
        }

        public static void checkInputStatus()
        {
            ulong axisStatus;
            while (started)
            {
                Thread.Sleep(100);
                if (mServoIo.check_flag != 0)
                {
                    return;
                }
                //X轴
                axisStatus = RFIDControl.dmc_axis_io_status(0, 0);//读取轴的状态
                mServoIo.servo1_alm = (int)getStatus(axisStatus, (int)AxisStatus.MOTOR_ALM);
                mServoIo.servo1_el_b = (int)getStatus(axisStatus, (int)AxisStatus.MOTOR_EL_B);
                mServoIo.servo1_el_f = (int)getStatus(axisStatus, (int)AxisStatus.MOTOR_EL_F);
                mServoIo.servo1_emg = (int)getStatus(axisStatus, (int)AxisStatus.MOTOR_EMG);
                mServoIo.servo1_org = (int)getStatus(axisStatus, (int)AxisStatus.MOTOR_ORG);
                mServoIo.servo1_ez = (int)getStatus(axisStatus, (int)AxisStatus.MOTOR_EZ);
                mServoIo.servo1_inp = (int)getStatus(axisStatus, (int)AxisStatus.MOTOR_INP);
                mServoIo.servo1_rdy = (int)getStatus(axisStatus, (int)AxisStatus.MOTOR_RDY);
                mServoIo.servo1_home_flag = mAxis[0].m_home_flag;//原点状态
                                                                 //Y轴
                axisStatus = RFIDControl.dmc_axis_io_status(0, 1);//读取轴的状态
                mServoIo.servo2_alm = (int)getStatus(axisStatus, (int)AxisStatus.MOTOR_ALM);
                mServoIo.servo2_el_b = (int)getStatus(axisStatus, (int)AxisStatus.MOTOR_EL_B);
                mServoIo.servo2_el_f = (int)getStatus(axisStatus, (int)AxisStatus.MOTOR_EL_F);
                mServoIo.servo2_emg = (int)getStatus(axisStatus, (int)AxisStatus.MOTOR_EMG);
                mServoIo.servo2_org = (int)getStatus(axisStatus, (int)AxisStatus.MOTOR_ORG);
                mServoIo.servo2_ez = (int)getStatus(axisStatus, (int)AxisStatus.MOTOR_EZ);
                mServoIo.servo2_inp = (int)getStatus(axisStatus, (int)AxisStatus.MOTOR_INP);
                mServoIo.servo2_rdy = (int)getStatus(axisStatus, (int)AxisStatus.MOTOR_RDY);
                mServoIo.servo2_home_flag = mAxis[1].m_home_flag;//原点状态
                //not exist z axis
                //Z轴
                //各个轴的运动状态
                mAxis[0].m_run_status = (ushort)RFIDControl.dmc_check_done(mAxis[0].m_card_num, mAxis[0].m_axis_num);
                mAxis[1].m_run_status = (ushort)RFIDControl.dmc_check_done(mAxis[1].m_card_num, mAxis[1].m_axis_num);
                mAxis[0].m_positon = RFIDControl.dmc_get_encoder(mAxis[0].m_card_num, mAxis[0].m_axis_num);
                mAxis[1].m_positon = RFIDControl.dmc_get_encoder(mAxis[1].m_card_num, mAxis[1].m_axis_num);
                mInpterplaType.run_flag = RFIDControl.dmc_check_done_multicoor(mInpterplaType.card_num, mInpterplaType.car_num);
                if ((RFIDControl.dmc_read_inbit(0, 0) == LOW) && (key_emg_press_flag == false))
                {
                    key_emg_press_flag = true;
                    emgStop();
                }
                else
                {
                    key_emg_press_flag = false;
                }
            }
        }



        public static ulong BV(int bit)
        {
            return (ulong)(1 << bit);
        }

        public static ulong getStatus(ulong d, int bit)
        {
            return (d & BV(bit)) >> bit;
        }
    }
}
