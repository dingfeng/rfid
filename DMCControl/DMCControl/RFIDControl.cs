using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;

namespace DMCControl
{
    public class RFIDControl
    {
        [DllImport("LTDMC.dll")]
        public static extern short dmc_board_init();    //初始化控制卡
        [DllImport("LTDMC.dll")]
        public static extern short dmc_board_close();   //关闭控制卡
        [DllImport("LTDMC.dll")]
        public static extern short dmc_board_reset(); //硬件复位
        [DllImport("LTDMC.dll")]
        public static extern short dmc_get_CardInfList(ref ushort CardNun, ref uint CardTypeList, ref ushort CardIdList);//读取初始化完成后的卡信息列表
        [DllImport("LTDMC.dll")]
        public static extern short dmc_get_CardNo_version(ushort CardNo, ref uint CardVersion);    //读取控制卡硬件版本
        [DllImport("LTDMC.dll")]
        public static extern short dmc_get_CardNo_soft_version(ushort CardNo, ref uint FirmID, ref uint SubFirmID);   //读取控制卡硬件的固件版本
        [DllImport("LTDMC.dll")]
        public static extern short dmc_get_CardNo_lib_version(ref uint LibVer);    //读取控制卡动态库版本
        [DllImport("LTDMC.dll")]
        public static extern short dmc_get_total_axes(ushort CardNo, ref uint TotalAxis);  //读取指定卡轴数
        [DllImport("LTDMC.dll")]
        public static extern short dmc_set_debug_mode(ushort mode, string FileName);
        [DllImport("LTDMC.dll")]
        public static extern short dmc_get_debug_mode(ref ushort mode, string FileName);
        [DllImport("LTDMC.dll")]
        public static extern short dmc_set_AxisIoMap(ushort CardNo, ushort Axis, ushort MsgType, ushort MapPortType, ushort MapPortIndex, uint Filter);
        [DllImport("LTDMC.dll")]
        public static extern short dmc_get_AxisIoMap(ushort CardNo, ushort Axis, ushort MsgType, ref ushort MapPortType, ref ushort MapPortIndex, ref uint Filter);
        [DllImport("LTDMC.dll")]
        public static extern short dmc_set_axis_io_map(ushort CardNo, ushort Axis, ushort IoType, ushort MapIoType, ushort MapIoIndex, double filter_time);
        [DllImport("LTDMC.dll")]
        public static extern short dmc_get_axis_io_map(ushort CardNo, ushort Axis, ushort IoType, ref ushort MapIoType, ref ushort MapIoIndex, ref double filter_time);
        [DllImport("LTDMC.dll")]
        public static extern short dmc_set_special_input_filter(ushort CardNo, double filter_time);//设置所有专用IO滤波时间
        [DllImport("LTDMC.dll")]
        public static extern short dmc_download_configfile(ushort CardNo, string FileName);
        [DllImport("LTDMC.dll")]
        public static extern short dmc_download_firmware(ushort CardNo, string FileName);
        [DllImport("LTDMC.dll")]
        public static extern short dmc_set_softlimit(ushort CardNo, ushort axis, ushort enable, ushort source_sel, ushort SL_action, long N_limit, long P_limit);   //设置软限位参数
        [DllImport("LTDMC.dll")]
        public static extern short dmc_get_softlimit(ushort CardNo, ushort axis, ref ushort enable, ref ushort source_sel, ref ushort SL_action, ref long N_limit, ref long P_limit);    //读取软限位参数
        [DllImport("LTDMC.dll")]
        public static extern short dmc_set_el_mode(ushort CardNo, ushort axis, ushort el_enable, ushort el_logic, ushort el_mode);  //设置EL信号
        [DllImport("LTDMC.dll")]
        public static extern short dmc_get_el_mode(ushort CardNo, ushort axis, ref ushort el_enable, ref ushort el_logic, ref ushort el_mode);   //读取设置EL信号
        [DllImport("LTDMC.dll")]
        public static extern short dmc_set_emg_mode(ushort CardNo, ushort axis, ushort enable, ushort emg_logic);   //设置EMG信号
        [DllImport("LTDMC.dll")]
        public static extern short dmc_get_emg_mode(ushort CardNo, ushort axis, ref ushort enable, ref ushort emg_logic);     //读取设置EMG信号
        [DllImport("LTDMC.dll")]
        public static extern short dmc_set_dstp_mode(ushort CardNo, ushort axis, ushort enable, ushort logic, uint time);
        [DllImport("LTDMC.dll")]
        public static extern short dmc_get_dstp_mode(ushort CardNo, ushort axis, ref ushort enable, ref ushort logic, ref uint time);
        [DllImport("LTDMC.dll")]
        public static extern short dmc_set_dstp_time(ushort CardNo, ushort axis, uint time);
        [DllImport("LTDMC.dll")]
        public static extern short dmc_get_dstp_time(ushort CardNo, ushort axis, ref uint time);
        [DllImport("LTDMC.dll")]
        public static extern short dmc_set_io_dstp_mode(ushort CardNo, ushort axis, ushort enable, ushort logic); //设置外部IO触发减速停止模式
        [DllImport("LTDMC.dll")]
        public static extern short dmc_get_io_dstp_mode(ushort CardNo, ushort axis, ref ushort enable, ref ushort logic);
        [DllImport("LTDMC.dll")]
        public static extern short dmc_set_dec_stop_time(ushort CardNo, ushort axis, double stop_time);//设置全局减速停止时间
        [DllImport("LTDMC.dll")]
        public static extern short dmc_get_dec_stop_time(ushort CardNo, ushort axis, ref double stop_time);
        [DllImport("LTDMC.dll")]
        public static extern short dmc_set_profile(ushort CardNo, ushort axis, double Min_Vel, double Max_Vel, double Tacc, double Tdec, double stop_vel);  //设定速度曲线参数
        [DllImport("LTDMC.dll")]
        public static extern short dmc_get_profile(ushort CardNo, ushort axis, ref double Min_Vel, ref double Max_Vel, ref double Tacc, ref double Tdec, ref double stop_vel);  //读取速度曲线参数
        [DllImport("LTDMC.dll")]
        public static extern short dmc_set_s_profile(ushort CardNo, ushort axis, ushort s_mode, double s_para); //设置平滑速度曲线参数
        [DllImport("LTDMC.dll")]
        public static extern short dmc_get_s_profile(ushort CardNo, ushort axis, ushort s_mode, ref double s_para); //读取平滑速度曲线参数
        [DllImport("LTDMC.dll")]
        public static extern short dmc_set_vector_profile_multicoor(ushort CardNo, ushort Crd, double Min_Vel, double Max_Vel, double Tacc, double Tdec = 0, double Stop_Vel = 0);
        [DllImport("LTDMC.dll")]
        public static extern short dmc_get_vector_profile_multicoor(ushort CardNo, ushort Crd, ref double Min_Vel, ref double Max_Vel, ref double Tacc, ref double Tdec, ref double Stop_Vel);
        [DllImport("LTDMC.dll")]
        public static extern short dmc_set_pulse_outmode(ushort CardNo, ushort axis, ushort outmode);   //设定脉冲输出模式
        [DllImport("LTDMC.dll")]
        public static extern short dmc_get_pulse_outmode(ushort CardNo, ushort axis, ref ushort outmode);  //读取脉冲输出模式
        [DllImport("LTDMC.dll")]
        public static extern short dmc_pmove(ushort CardNo, ushort axis, long dist, ushort posi_mode);  //指定轴做定长位移运动
        [DllImport("LTDMC.dll")]
        public static extern short dmc_vmove(ushort CardNo, ushort axis, ushort dir);   //指定轴做连续运动
        [DllImport("LTDMC.dll")]
        public static extern short dmc_PvtTable(ushort CardNo, ushort iaxis, uint count, ref double pTime, ref long pPos, ref double pVel);
        [DllImport("LTDMC.dll")]
        public static extern short dmc_PtsTable(ushort CardNo, ushort iaxis, uint count, ref double pTime, ref long pPos, ref double pPercent);
        [DllImport("LTDMC.dll")]
        public static extern short dmc_PvtsTable(ushort CardNo, ushort iaxis, uint count, ref double pTime, ref long pPos, double velBegin, double velEnd);
        [DllImport("LTDMC.dll")]
        public static extern short dmc_PttTable(ushort CardNo, ushort iaxis, uint count, ref double pTime, ref long pPos);
        [DllImport("LTDMC.dll")]
        public static extern short dmc_PvtMove(ushort CardNo, ushort AxisNum, ref ushort AxisList);
        [DllImport("LTDMC.dll")]
        public static extern short dmc_reset_target_position(ushort CardNo, ushort axis, long dist, ushort posi_mode = 0);  //运动中改变目标位置
        [DllImport("LTDMC.dll")]
        public static extern short dmc_change_speed(ushort CardNo, ushort axis, double Curr_Vel, double Taccdec);   //在线改变指定轴的当前运动速度及加减速时间
        [DllImport("LTDMC.dll")]
        public static extern short dmc_update_target_position(ushort CardNo, ushort axis, long dist, ushort posi_mode = 0); //强行改变目标位置
        [DllImport("LTDMC.dll")]
        public static extern short dmc_line_multicoor(ushort CardNo, ushort Crd, ushort axisNum,  ushort[] axisList, long[] DistList, ushort posi_mode);    //指定轴直线插补运动
        [DllImport("LTDMC.dll")]
        public static extern short dmc_arc_move_multicoor(ushort CardNo, ushort Crd,  ushort[] AxisList,  long[] Target_Pos, long[] Cen_Pos, ushort Arc_Dir, ushort posi_mode);
        [DllImport("LTDMC.dll")]
        public static extern short dmc_set_home_pin_logic(ushort CardNo, ushort axis, ushort org_logic, double filter = 0);     //设置HOME信号
        [DllImport("LTDMC.dll")]
        public static extern short dmc_get_home_pin_logic(ushort CardNo, ushort axis, ref ushort org_logic, ref double filter);     //读取设置HOME信号	
        [DllImport("LTDMC.dll")]
        public static extern short dmc_set_homemode(ushort CardNo, ushort axis, ushort home_dir, double vel_mode, ushort mode, ushort EZ_count = 0);//设定指定轴的回原点模式
        [DllImport("LTDMC.dll")]
        public static extern short dmc_get_homemode(ushort CardNo, ushort axis, ref ushort home_dir, ref double vel_mode, ref ushort home_mode, ref ushort EZ_count);//读取指定轴的回原点模式
        [DllImport("LTDMC.dll")]
        public static extern short dmc_home_move(ushort CardNo, ushort axis);
        [DllImport("LTDMC.dll")]
        public static extern short dmc_set_homelatch_mode(ushort CardNo, ushort axis, ushort enable, ushort logic, ushort source);//设置原点锁存模式
        [DllImport("LTDMC.dll")]
        public static extern short dmc_get_homelatch_mode(ushort CardNo, ushort axis, ref ushort enable, ref ushort logic, ref ushort source);
        [DllImport("LTDMC.dll")]
        public static extern int dmc_get_homelatch_flag(ushort CardNo, ushort axis);//读取锁存标志
        [DllImport("LTDMC.dll")]
        public static extern short dmc_reset_homelatch_flag(ushort CardNo, ushort axis);//复位原点锁存标志
        [DllImport("LTDMC.dll")]
        public static extern int dmc_get_homelatch_value(ushort CardNo, ushort axis);//读取锁存值
        [DllImport("LTDMC.dll")]
        public static extern short dmc_set_handwheel_channel(ushort CardNo, ushort index);
        [DllImport("LTDMC.dll")]
        public static extern short dmc_get_handwheel_channel(ushort CardNo, ref ushort index);
        [DllImport("LTDMC.dll")]
        public static extern short dmc_set_handwheel_inmode(ushort CardNo, ushort axis, ushort inmode, int multi, double vh = 0);  //设置输入手轮脉冲信号的工作方式 控制单轴
        [DllImport("LTDMC.dll")]
        public static extern short dmc_get_handwheel_inmode(ushort CardNo, ushort axis, ref ushort inmode, ref int multi, ref double vh);  //读取输入手轮脉冲信号的工作方式 控制单轴
        [DllImport("LTDMC.dll")]
        public static extern short dmc_set_handwheel_inmode_extern(ushort CardNo, ushort inmode, ushort AxisNum, ref ushort AxisList, ref int multi); //设置输入手轮脉冲信号的工作方式 控制多轴
        [DllImport("LTDMC.dll")]
        public static extern short dmc_get_handwheel_inmode_extern(ushort CardNo, ref ushort inmode, ref ushort AxisNum, ref ushort AxisList, ref int multi);
        [DllImport("LTDMC.dll")]
        public static extern short dmc_handwheel_move(ushort CardNo, ushort axis);
        [DllImport("LTDMC.dll")]
        public static extern short dmc_set_counter_inmode(ushort CardNo, ushort axis, ushort mode); //设定编码器的计数方式
        [DllImport("LTDMC.dll")]
        public static extern short dmc_get_counter_inmode(ushort CardNo, ushort axis, ref ushort mode);    //读取编码器的计数方式
        [DllImport("LTDMC.dll")]
        public static extern int dmc_get_encoder(ushort CardNo, ushort axis);
        [DllImport("LTDMC.dll")]
        public static extern short dmc_set_encoder(ushort CardNo, ushort axis, int encoder_value);
        [DllImport("LTDMC.dll")]
        public static extern short dmc_set_ez_mode(ushort CardNo, ushort axis, ushort ez_logic, ushort ez_mode = 0, double filter = 0); //设置EZ信号
        [DllImport("LTDMC.dll")]
        public static extern short dmc_get_ez_mode(ushort CardNo, ushort axis, ref ushort ez_logic, ref ushort ez_mode, ref double filter); //读取设置EZ信号
        [DllImport("LTDMC.dll")]
        public static extern short dmc_set_ltc_mode(ushort CardNo, ushort axis, ushort ltc_logic, ushort ltc_mode = 0, double filter = 0);  //设置LTC信号
        [DllImport("LTDMC.dll")]
        public static extern short dmc_get_ltc_mode(ushort CardNo, ushort axis, ref ushort ltc_logic, ref ushort ltc_mode, ref double filter);  //读取设置LTC信号
        [DllImport("LTDMC.dll")]
        public static extern short dmc_set_latch_mode(ushort CardNo, ushort axis, ushort all_enable, ushort latch_sourcee, ushort latch_channel = 0);   //设置锁存方式
        [DllImport("LTDMC.dll")]
        public static extern short dmc_get_latch_mode(ushort CardNo, ushort axis, ref ushort all_enable, ref ushort latch_sourcee, ref ushort latch_channel);
        [DllImport("LTDMC.dll")]
        public static extern short dmc_reset_latch_flag(ushort CardNo, ushort axis);    //复位锁存器标志
        [DllImport("LTDMC.dll")]
        public static extern short dmc_get_latch_flag(ushort CardNo, ushort axis);  //读取控制卡内有效锁存个数
        [DllImport("LTDMC.dll")]
        public static extern int dmc_get_latch_value(ushort CardNo, ushort axis);  //读取控制卡内锁存值，再连续锁存模式下读取一次控制卡内有效锁存个数将会自动减1,并将锁存值保存在PC缓冲区内
        [DllImport("LTDMC.dll")]
        public static extern short dmc_get_latch_flag_extern(ushort CardNo, ushort axis);   //读取锁存器已锁存个数
        [DllImport("LTDMC.dll")]
        public static extern int dmc_get_latch_value_extern(ushort CardNo, ushort axis, ushort index);     //按索引号读取PC缓冲区中已保存的锁存值，读的时候会将控制卡内的有效锁存值全部保存在PC缓冲区中
        [DllImport("LTDMC.dll")]
        public static extern short dmc_set_latch_stop_time(ushort CardNo, ushort axis, int stop_time);
        [DllImport("LTDMC.dll")]
        public static extern short dmc_get_latch_stop_time(ushort CardNo, ushort axis, ref int stop_time);
        [DllImport("LTDMC.dll")]
        public static extern short dmc_SetLtcOutMode(ushort CardNo, ushort axis, ushort enable, ushort bitno);//设置LTC反向输出模式
        [DllImport("LTDMC.dll")]
        public static extern short dmc_GetLtcOutMode(ushort CardNo, ushort axis, ref ushort enable, ref ushort bitno);
        [DllImport("LTDMC.dll")]
        public static extern short dmc_compare_set_config(ushort CardNo, ushort axis, ushort enable, ushort cmp_source);    //配置比较器
        [DllImport("LTDMC.dll")]
        public static extern short dmc_compare_get_config(ushort CardNo, ushort axis, ref ushort enable, ref ushort cmp_source);  //读取配置比较器
        [DllImport("LTDMC.dll")]
        public static extern short dmc_compare_clear_points(ushort CardNo, ushort axis);    //清除所有比较点
        [DllImport("LTDMC.dll")]
        public static extern short dmc_compare_add_point(ushort CardNo, ushort axis, long pos, ushort dir, ushort action, uint actpara);   //添加比较点
        [DllImport("LTDMC.dll")]
        public static extern short dmc_compare_get_current_point(ushort CardNo, ushort axis, ref long pos);     //读取当前比较点
        [DllImport("LTDMC.dll")]
        public static extern short dmc_compare_get_points_runned(ushort CardNo, ushort axis, ref long pointNum);    //查询已经比较过的点
        [DllImport("LTDMC.dll")]
        public static extern short dmc_compare_get_points_remained(ushort CardNo, ushort axis, ref long pointNum);  //查询可以加入的比较点数量
        [DllImport("LTDMC.dll")]
        public static extern short dmc_compare_set_config_extern(ushort CardNo, ushort enable, ushort cmp_source);  //配置比较器
        [DllImport("LTDMC.dll")]
        public static extern short dmc_compare_get_config_extern(ushort CardNo, ref ushort enable, ref ushort cmp_source);    //读取配置比较器
        [DllImport("LTDMC.dll")]
        public static extern short dmc_compare_clear_points_extern(ushort CardNo);  //清除所有比较点
        [DllImport("LTDMC.dll")]
        public static extern short dmc_compare_add_point_extern(ushort CardNo, ref ushort axis, ref long pos, ref ushort dir, ushort action, uint actpara);  //添加两轴位置比较点
        [DllImport("LTDMC.dll")]
        public static extern short dmc_compare_get_current_point_extern(ushort CardNo, ref long pos);   //读取当前比较点
        [DllImport("LTDMC.dll")]
        public static extern short dmc_compare_get_points_runned_extern(ushort CardNo, ref long pointNum);  //查询已经比较过的点
        [DllImport("LTDMC.dll")]
        public static extern short dmc_compare_get_points_remained_extern(ushort CardNo, ref long pointNum);    //查询可以加入的二维比较点数量
        [DllImport("LTDMC.dll")]
        public static extern short dmc_hcmp_set_mode(ushort CardNo, ushort hcmp, ushort cmp_mode);//设置高速比较模式
        [DllImport("LTDMC.dll")]
        public static extern short dmc_hcmp_get_mode(ushort CardNo, ushort hcmp, ref ushort cmp_mode);
        [DllImport("LTDMC.dll")]
        public static extern short dmc_hcmp_set_config(ushort CardNo, ushort hcmp, ushort axis, ushort cmp_source, ushort cmp_logic, long time);//配置高速比较相关参数
        [DllImport("LTDMC.dll")]
        public static extern short dmc_hcmp_get_config(ushort CardNo, ushort hcmp, ref ushort axis, ref ushort cmp_source, ref ushort cmp_logic, ref long time);
        [DllImport("LTDMC.dll")]
        public static extern short dmc_hcmp_add_point(ushort CardNo, ushort hcmp, long cmp_pos);//添加比较点
        [DllImport("LTDMC.dll")]
        public static extern short dmc_hcmp_set_liner(ushort CardNo, ushort hcmp, long Increment, long Count);//设置线性比较模式相关参数
        [DllImport("LTDMC.dll")]
        public static extern short dmc_hcmp_get_liner(ushort CardNo, ushort hcmp, ref long Increment, ref long Count);
        [DllImport("LTDMC.dll")]
        public static extern short dmc_hcmp_get_current_state(ushort CardNo, ushort hcmp, ref long remained_points, ref long current_point, ref long runned_points); //读取比较状态
        [DllImport("LTDMC.dll")]
        public static extern short dmc_hcmp_clear_points(ushort CardNo, ushort hcmp);   //清除比较点
        [DllImport("LTDMC.dll")]
        public static extern short dmc_read_cmp_pin(ushort CardNo, ushort hcmp); //读取高速比较输出口状态
        [DllImport("LTDMC.dll")]
        public static extern short dmc_write_cmp_pin(ushort CardNo, ushort hcmp, ushort on_off);
        [DllImport("LTDMC.dll")]
        public static extern short dmc_read_inbit(ushort CardNo, ushort bitno);     //读取输入口的状态
        [DllImport("LTDMC.dll")]
        public static extern short dmc_write_outbit(ushort CardNo, ushort bitno, ushort on_off);    //设置输出口的状态
        [DllImport("LTDMC.dll")]
        public static extern short dmc_read_outbit(ushort CardNo, ushort bitno);    //读取输出口的状态
        [DllImport("LTDMC.dll")]
        public static extern ulong dmc_read_inport(ushort CardNo, ushort portno);   //读取输入端口的值
        [DllImport("LTDMC.dll")]
        public static extern ulong dmc_read_outport(ushort CardNo, ushort portno = 0);  //读取输出端口的值
        [DllImport("LTDMC.dll")]
        public static extern short dmc_write_outport(ushort CardNo, ushort portno, uint outport_val);      //设置输出端口的值
        [DllImport("LTDMC.dll")]
        public static extern short dmc_IO_TurnOutDelay(ushort CardNo, ushort bitno, uint DelayTime);
        [DllImport("LTDMC.dll")]
        public static extern short dmc_reverse_outbit(ushort CardNo, ushort bitno, double reverse_time);
        [DllImport("LTDMC.dll")]
        public static extern short dmc_SetIoCountMode(ushort CardNo, ushort bitno, ushort mode, uint filter);
        [DllImport("LTDMC.dll")]
        public static extern short dmc_GetIoCountMode(ushort CardNo, ushort bitno, ref ushort mode, ref uint filter);
        [DllImport("LTDMC.dll")]
        public static extern short dmc_SetIoCountValue(ushort CardNo, ushort bitno, uint CountValue);
        [DllImport("LTDMC.dll")]
        public static extern short dmc_GetIoCountValue(ushort CardNo, ushort bitno, ref uint CountValue);
        [DllImport("LTDMC.dll")]
        public static extern short dmc_set_io_count_mode(ushort CardNo, ushort bitno, ushort mode, double filter_time);//设置IO计数模式
        [DllImport("LTDMC.dll")]
        public static extern short dmc_get_io_count_mode(ushort CardNo, ushort bitno, ref ushort mode, ref double filter_time);
        [DllImport("LTDMC.dll")]
        public static extern short dmc_set_io_count_value(ushort CardNo, ushort bitno, uint CountValue);//设置IO计数值
        [DllImport("LTDMC.dll")]
        public static extern short dmc_get_io_count_value(ushort CardNo, ushort bitno, ref uint CountValue);//读取IO计数值
        [DllImport("LTDMC.dll")]
        public static extern short dmc_set_alm_mode(ushort CardNo, ushort axis, ushort enable, ushort alm_logic, ushort alm_action);    //设置ALM信号
        [DllImport("LTDMC.dll")]
        public static extern short dmc_get_alm_mode(ushort CardNo, ushort axis, ref ushort enable, ref ushort alm_logic, ref ushort alm_action); //读取设置ALM信号
        [DllImport("LTDMC.dll")]
        public static extern short dmc_set_inp_mode(ushort CardNo, ushort axis, ushort enable, ushort inp_logic);   //设置INP信号
        [DllImport("LTDMC.dll")]
        public static extern short dmc_get_inp_mode(ushort CardNo, ushort axis, ref ushort enable, ref ushort inp_logic); //读取设置INP信号
        [DllImport("LTDMC.dll")]
        public static extern short dmc_read_rdy_pin(ushort CardNo, ushort axis);    //读取RDY状态
        [DllImport("LTDMC.dll")]
        public static extern short dmc_write_erc_pin(ushort CardNo, ushort axis, ushort on_off);    //控制ERC信号输出
        [DllImport("LTDMC.dll")]
        public static extern short dmc_read_erc_pin(ushort CardNo, ushort axis);
        [DllImport("LTDMC.dll")]
        public static extern short dmc_write_sevon_pin(ushort CardNo, ushort axis, ushort on_off);  //输出SEVON信号
        [DllImport("LTDMC.dll")]
        public static extern short dmc_read_sevon_pin(ushort CardNo, ushort axis);  //读取SEVON信号
        [DllImport("LTDMC.dll")]
        public static extern short dmc_set_io_map_virtual(ushort CardNo, ushort bitno, ushort MapIoType, ushort MapIoIndex, double Filter);
        [DllImport("LTDMC.dll")]
        public static extern short dmc_get_io_map_virtual(ushort CardNo, ushort bitno, ref ushort MapIoType, ref ushort MapIoIndex, ref double Filter);
        [DllImport("LTDMC.dll")]
        public static extern short dmc_read_inbit_virtual(ushort CardNo, ushort bitno);
        [DllImport("LTDMC.dll")]
        public static extern double dmc_read_current_speed(ushort CardNo, ushort axis); //读取指定轴的当前速度
        [DllImport("LTDMC.dll")]
        public static extern double dmc_read_vector_speed(ushort CardNo);   //读取当前卡的插补速度
        [DllImport("LTDMC.dll")]
        public static extern long dmc_get_position(ushort CardNo, ushort axis); //读取指定轴的当前位置
        [DllImport("LTDMC.dll")]
        public static extern short dmc_set_position(ushort CardNo, ushort axis, long current_position); //设定指定轴的当前位置
        [DllImport("LTDMC.dll")]
        public static extern long dmc_get_target_position(ushort CardNo, ushort axis);        //读取指定轴的目标位置
        [DllImport("LTDMC.dll")]
        public static extern short dmc_check_done(ushort CardNo, ushort axis);  //读取指定轴的运动状态
        [DllImport("LTDMC.dll")]
        public static extern ulong dmc_axis_io_status(ushort CardNo, ushort axis);  //读取指定轴有关运动信号的状态
        [DllImport("LTDMC.dll")]
        public static extern short dmc_stop(ushort CardNo, ushort axis, ushort stop_mode);  //单轴减速停止/立即停止
        [DllImport("LTDMC.dll")]
        public static extern short dmc_check_done_multicoor(ushort CardNo, ushort Crd); //调用插补运动，请使用该函数检测运动状态
        [DllImport("LTDMC.dll")]
        public static extern short dmc_stop_multicoor(ushort CardNo, ushort Crd, ushort stop_mode);//调用插补运动，请使用该函数停止运动状态
        [DllImport("LTDMC.dll")]
        public static extern short dmc_emg_stop(ushort CardNo); //紧急停止所有轴
        [DllImport("LTDMC.dll")]
        public static extern short dmc_set_factor_error(ushort CardNo, ushort axis, double factor, long error);//设置编码器系数、误差带
        [DllImport("LTDMC.dll")]
        public static extern short dmc_get_factor_error(ushort CardNo, ushort axis, ref double factor, ref long error);//读取编码器系数、误差带
        [DllImport("LTDMC.dll")]
        public static extern short dmc_check_success_pulse(ushort CardNo, ushort axis);//检测指令位置到位情况
        [DllImport("LTDMC.dll")]
        public static extern short dmc_check_success_encoder(ushort CardNo, ushort axis);//检测编码器反馈位置到位情况
        [DllImport("LTDMC.dll")]
        public static extern short dmc_LinkState(ushort CardNo, ref ushort State); //连接状态
        [DllImport("LTDMC.dll")]
        public static extern short dmc_check_sn(ushort CardNo, string check_sn);//验证密码，校验3次失败之后再次校验将返回校验失败
        [DllImport("LTDMC.dll")]
        public static extern short dmc_write_sn(ushort CardNo, string new_sn);//改写密码
        [DllImport("LTDMC.dll")]
        public static extern short dmc_get_axis_run_mode(ushort CardNo, ushort axis, ref ushort run_mode);//轴运动模式
        [DllImport("LTDMC.dll")]
        public static extern short dmc_get_equiv(ushort CardNo, ushort axis, ref double equiv);//脉冲当量
        [DllImport("LTDMC.dll")]
        public static extern short dmc_set_equiv(ushort CardNo, ushort axis, double equiv);
        [DllImport("LTDMC.dll")]
        public static extern short dmc_set_backlash_unit(ushort CardNo, ushort axis, double backlash);//反向间隙
        [DllImport("LTDMC.dll")]
        public static extern short dmc_get_backlash_unit(ushort CardNo, ushort axis, ref double backlash);
        [DllImport("LTDMC.dll")]
        public static extern short dmc_set_position_unit(ushort CardNo, ushort axis, double pos);//当前指令位置
        [DllImport("LTDMC.dll")]
        public static extern short dmc_get_position_unit(ushort CardNo, ushort axis, ref double pos);
        [DllImport("LTDMC.dll")]
        public static extern short dmc_set_encoder_unit(ushort CardNo, ushort axis, double pos);//当前反馈位置
        [DllImport("LTDMC.dll")]
        public static extern short dmc_get_encoder_unit(ushort CardNo, ushort axis, ref double pos);
        [DllImport("LTDMC.dll")]
        public static extern short dmc_pmove_unit(ushort CardNo, ushort axis, double Dist, ushort posi_mode);//定长
        [DllImport("LTDMC.dll")]
        public static extern short dmc_t_pmove_unit(ushort CardNo, ushort axis, double Dist, ushort posi_mode);//对称T型定长
        [DllImport("LTDMC.dll")]
        public static extern short dmc_ex_t_pmove_unit(ushort CardNo, ushort axis, double Dist, ushort posi_mode);//非对称T型定长
        [DllImport("LTDMC.dll")]
        public static extern short dmc_s_pmove_unit(ushort CardNo, ushort axis, double Dist, ushort posi_mode);//对称S型定长
        [DllImport("LTDMC.dll")]
        public static extern short dmc_ex_s_pmove_unit(ushort CardNo, ushort axis, double Dist, ushort posi_mode);//非对称S型定长
        [DllImport("LTDMC.dll")]
        public static extern short dmc_line_unit(ushort CardNo, ushort Crd, ushort AxisNum, ref ushort AxisList, ref double Target_Pos, ushort posi_mode);//单段直线
        [DllImport("LTDMC.dll")]
        public static extern short dmc_arc_move_center_unit(ushort CardNo, ushort Crd, ushort AxisNum, ref ushort AxisList, ref double Target_Pos, ref double Cen_Pos, ushort Arc_Dir, long Circle, ushort posi_mode);//单段圆心圆弧/螺旋线/渐开线
        [DllImport("LTDMC.dll")]
        public static extern short dmc_arc_move_radius_unit(ushort CardNo, ushort Crd, ushort AxisNum, ref ushort AxisList, ref double Target_Pos, double Arc_Radius, ushort Arc_Dir, long Circle, ushort posi_mode);//单段半径圆弧/螺旋线
        [DllImport("LTDMC.dll")]
        public static extern short dmc_arc_move_3points_unit(ushort CardNo, ushort Crd, ushort AxisNum, ref ushort AxisList, ref double Target_Pos, ref double Mid_Pos, long Circle, ushort posi_mode);//单段三点圆弧/螺旋线
        [DllImport("LTDMC.dll")]
        public static extern short dmc_rectangle_move_unit(ushort CardNo, ushort Crd, ushort AxisNum, ref ushort AxisList, ref double Target_Pos, ref double Mark_Pos, long num, ushort rect_mode, ushort posi_mode);//单段矩形插补
        [DllImport("LTDMC.dll")]
        public static extern short dmc_read_current_speed_unit(ushort CardNo, ushort axis, ref double current_speed);//轴当前运行速度
        [DllImport("LTDMC.dll")]
        public static extern short dmc_set_vector_profile_unit(ushort CardNo, ushort Crd, double Min_Vel, double Max_Vel, double Tacc, double Tdec, double Stop_Vel);//单段插补速度参数
        [DllImport("LTDMC.dll")]
        public static extern short dmc_get_vector_profile_unit(ushort CardNo, ushort Crd, ref double Min_Vel, ref double Max_Vel, ref double Tacc, ref double Tdec, ref double Stop_Vel);
        [DllImport("LTDMC.dll")]
        public static extern short dmc_set_vector_s_profile(ushort CardNo, ushort Crd, ushort s_mode, double s_para);   //设置S型速度曲线参数
        [DllImport("LTDMC.dll")]
        public static extern short dmc_get_vector_s_profile(ushort CardNo, ushort Crd, ushort s_mode, ref double s_para);
        [DllImport("LTDMC.dll")]
        public static extern short dmc_set_profile_unit(ushort CardNo, ushort axis, double Min_Vel, double Max_Vel, double Tacc, double Tdec, double Stop_Vel);//单轴速度参数
        [DllImport("LTDMC.dll")]
        public static extern short dmc_get_profile_unit(ushort CardNo, ushort axis, ref double Min_Vel, ref double Max_Vel, ref double Tacc, ref double Tdec, ref double Stop_Vel);
        [DllImport("LTDMC.dll")]
        public static extern short dmc_reset_target_position_unit(ushort CardNo, ushort axis, double New_Pos);//在线变位
        [DllImport("LTDMC.dll")]
        public static extern short dmc_update_target_position_unit(ushort CardNo, ushort axis, double New_Pos);//强行变位
        [DllImport("LTDMC.dll")]
        public static extern short dmc_change_speed_unit(ushort CardNo, ushort axis, double New_Vel, double Taccdec);//在线变速
        [DllImport("LTDMC.dll")]
        public static extern short dmc_conti_open_list(ushort CardNo, ushort Crd, ushort AxisNum, ref ushort AxisList); //打开连续缓存区
        [DllImport("LTDMC.dll")]
        public static extern short dmc_conti_close_list(ushort CardNo, ushort Crd); //关闭连续缓存区
        [DllImport("LTDMC.dll")]
        public static extern short dmc_conti_stop_list(ushort CardNo, ushort Crd, ushort stop_mode);    //连续插补中停止
        [DllImport("LTDMC.dll")]
        public static extern short dmc_conti_pause_list(ushort CardNo, ushort Crd); //连续插补中暂停
        [DllImport("LTDMC.dll")]
        public static extern short dmc_conti_start_list(ushort CardNo, ushort Crd); //开始连续插补
        [DllImport("LTDMC.dll")]
        public static extern long dmc_conti_remain_space(ushort CardNo, ushort Crd);    //查连续插补剩余缓存数
        [DllImport("LTDMC.dll")]
        public static extern long dmc_conti_read_current_mark(ushort CardNo, ushort Crd);   //读取当前连续插补段的标号
        [DllImport("LTDMC.dll")]
        public static extern short dmc_conti_set_blend(ushort CardNo, ushort Crd, ushort enable);//blend拐角过度模式
        [DllImport("LTDMC.dll")]
        public static extern short dmc_conti_get_blend(ushort CardNo, ushort Crd, ref ushort enable);
        [DllImport("LTDMC.dll")]
        public static extern short dmc_conti_set_profile_unit(ushort CardNo, ushort Crd, double Min_Vel, double Max_vel, double Tacc, double Tdec, double Stop_Vel);//设置连续插补速度
        [DllImport("LTDMC.dll")]
        public static extern short dmc_conti_set_s_profile(ushort CardNo, ushort Crd, ushort s_mode, double s_para);//设置连续插补平滑时间
        [DllImport("LTDMC.dll")]
        public static extern short dmc_conti_get_s_profile(ushort CardNo, ushort Crd, ushort s_mode, ref double s_para);
        [DllImport("LTDMC.dll")]
        public static extern short dmc_conti_set_pause_output(ushort CardNo, ushort Crd, ushort action, long mask, long state);//暂停时IO输出 action：0-不动作；1-暂停时输出；2-暂停时输出, 继续运行时恢复；3-停止时输出。
        [DllImport("LTDMC.dll")]
        public static extern short dmc_conti_get_pause_output(ushort CardNo, ushort Crd, ref ushort action, ref long mask, ref long state);
        [DllImport("LTDMC.dll")]
        public static extern short dmc_conti_set_override(ushort CardNo, ushort Crd, double Percent);//设置每段速度比例  缓冲区指令
        [DllImport("LTDMC.dll")]
        public static extern short dmc_conti_change_speed_ratio(ushort CardNo, ushort Crd, double percent);//连续插补动态变速
        [DllImport("LTDMC.dll")]
        public static extern short dmc_conti_get_run_state(ushort CardNo, ushort Crd);//读取连续插补状态：0-运行，1-暂停，2-正常停止，3-异常停止
        [DllImport("LTDMC.dll")]
        public static extern short dmc_conti_check_done(ushort CardNo, ushort Crd);//检测连续插补运动状态：0-运行，1-停止
        [DllImport("LTDMC.dll")]
        public static extern short dmc_conti_wait_input(ushort CardNo, ushort Crd, ushort bitno, ushort on_off, double TimeOut, long mark);//设置连续插补等待输入
        [DllImport("LTDMC.dll")]
        public static extern short dmc_conti_delay_outbit_to_start(ushort CardNo, ushort Crd, ushort bitno, ushort on_off, double delay_value, ushort delay_mode, double ReverseTime);//相对于轨迹段起点IO滞后输出
        [DllImport("LTDMC.dll")]
        public static extern short dmc_conti_delay_outbit_to_stop(ushort CardNo, ushort Crd, ushort bitno, ushort on_off, double delay_time, double ReverseTime);//相对于轨迹段终点IO滞后输出
        [DllImport("LTDMC.dll")]
        public static extern short dmc_conti_ahead_outbit_to_stop(ushort CardNo, ushort Crd, ushort bitno, ushort on_off, double ahead_value, ushort ahead_mode, double ReverseTime);//相对轨迹段终点IO提前输出
        [DllImport("LTDMC.dll")]
        public static extern short dmc_conti_accurate_outbit_unit(ushort CardNo, ushort Crd, ushort cmp_no, ushort on_off, ushort map_axis, double rel_dist, ushort pos_source, double ReverseTime);//确定位置精确输出
        [DllImport("LTDMC.dll")]
        public static extern short dmc_conti_write_outbit(ushort CardNo, ushort Crd, ushort bitno, ushort on_off, double ReverseTime);//缓冲区立即IO输出
        [DllImport("LTDMC.dll")]
        public static extern short dmc_conti_clear_io_action(ushort CardNo, ushort Crd, uint IoMask);//清除段内未执行完的IO动作,防止在下一段执行
        [DllImport("LTDMC.dll")]
        public static extern short dmc_conti_delay(ushort CardNo, ushort Crd, double delay_time, long mark);//添加延时指令
        [DllImport("LTDMC.dll")]
        public static extern short dmc_conti_line_unit(ushort CardNo, ushort Crd, ushort AxisNum, ref ushort AxisList, ref double Target_Pos, ushort posi_mode, long mark);//连续插补直线
        [DllImport("LTDMC.dll")]
        public static extern short dmc_conti_arc_move_center_unit(ushort CardNo, ushort Crd, ushort AxisNum, ref ushort AxisList, ref double Target_Pos, ref double Cen_Pos, ushort Arc_Dir, long Circle, ushort posi_mode, long mark);//圆心终点式圆弧/螺旋线/渐开线/同心圆
        [DllImport("LTDMC.dll")]
        public static extern short dmc_conti_arc_move_radius_unit(ushort CardNo, ushort Crd, ushort AxisNum, ref ushort AxisList, ref double Target_Pos, double Arc_Radius, ushort Arc_Dir, long Circle, ushort posi_mode, long mark);//半径终点式圆弧/螺旋线
        [DllImport("LTDMC.dll")]
        public static extern short dmc_conti_arc_move_3points_unit(ushort CardNo, ushort Crd, ushort AxisNum, ref ushort AxisList, ref double Target_Pos, ref double Mid_Pos, long Circle, ushort posi_mode, long mark);//三点式圆弧/螺旋线
        [DllImport("LTDMC.dll")]
        public static extern short dmc_conti_set_involute_mode(ushort CardNo, ushort Crd, ushort mode);//渐开线整圆封闭
        [DllImport("LTDMC.dll")]
        public static extern short dmc_conti_get_involute_mode(ushort CardNo, ushort Crd, ref ushort mode);
        [DllImport("LTDMC.dll")]
        public static extern short dmc_conti_rectangle_move_unit(ushort CardNo, ushort Crd, ushort AxisNum, ref ushort AxisList, ref double Target_Pos, ref double Mark_Pos, long num, ushort rect_mode, ushort posi_mode, long mark);//矩形插补
        [DllImport("LTDMC.dll")]
        public static extern short dmc_calculate_arclength_center(ref double start_pos, ref double target_pos, ref double cen_pos, ushort arc_dir, double circle, ref double ArcLength);//计算圆心圆弧弧长
        [DllImport("LTDMC.dll")]
        public static extern short dmc_calculate_arclength_radius(ref double start_pos, ref double target_pos, double arc_radius, ushort arc_dir, double circle, ref double ArcLength);//计算半径圆弧弧长
        [DllImport("LTDMC.dll")]
        public static extern short dmc_calculate_arclength_3point(ref double start_pos, ref double mid_pos, ref double end_pos, double circle, ref double ArcLength);//计算三点圆弧弧长
        [DllImport("LTDMC.dll")]
        public static extern short dmc_set_pwm_enable(ushort CardNo, ushort enable);//7号轴切换为PWM输出
        [DllImport("LTDMC.dll")]
        public static extern short dmc_get_pwm_enable(ushort CardNo, ref ushort enable);
        [DllImport("LTDMC.dll")]
        public static extern short dmc_conti_set_pwm_output(ushort CardNo, ushort Crd, ushort pwm_no, double fDuty, double fFre);//连续插补中设置PWM输出
        [DllImport("LTDMC.dll")]
        public static extern short dmc_set_pwm_output(ushort CardNo, ushort pwm_no, double fDuty, double fFre);//设置PWM输出
        [DllImport("LTDMC.dll")]
        public static extern short dmc_get_pwm_output(ushort CardNo, ushort pwm_no, ref double fDuty, ref double fFre);
        [DllImport("LTDMC.dll")]
        public static extern short dmc_conti_set_pwm_follow_speed(ushort CardNo, ushort Crd, ushort pwm_no, ushort mode, double MaxVel, double MaxValue, double OutValue);//PWM速度跟随
        [DllImport("LTDMC.dll")]
        public static extern short dmc_conti_get_pwm_follow_speed(ushort CardNo, ushort Crd, ushort pwm_no, ref ushort mode, ref double MaxVel, ref double MaxValue, ref double OutValue);
        [DllImport("LTDMC.dll")]
        public static extern short dmc_set_can_state(ushort CardNo, ushort NodeNum, ushort state, ushort Baud);//0-断开；1-连接；2-复位后自动连接
        [DllImport("LTDMC.dll")]
        public static extern short dmc_get_can_state(ushort CardNo, ref ushort NodeNum, ref ushort state);////0-断开；1-连接；2-异常
        [DllImport("LTDMC.dll")]
        public static extern short dmc_get_can_errcode(ushort CardNo, ref ushort Errcode);//读取CanIo通讯错误码
        [DllImport("LTDMC.dll")]
        public static extern short dmc_write_can_outbit(ushort CardNo, ushort Node, ushort bitno, ushort on_off);
        [DllImport("LTDMC.dll")]
        public static extern short dmc_read_can_outbit(ushort CardNo, ushort Node, ushort bitno);
        [DllImport("LTDMC.dll")]
        public static extern short dmc_read_can_inbit(ushort CardNo, ushort Node, ushort bitno);
        [DllImport("LTDMC.dll")]
        public static extern short dmc_write_can_outport(ushort CardNo, ushort Node, ushort portno, uint outport_val);//写CanIo输出口
        [DllImport("LTDMC.dll")]
        public static extern ulong dmc_read_can_outport(ushort CardNo, ushort Node, ushort portno);//读取CanIo输出端口
        [DllImport("LTDMC.dll")]
        public static extern ulong dmc_read_can_inport(ushort CardNo, ushort Node, ushort portno);//读取CanIo输入端口
        [DllImport("LTDMC.dll")]
        public static extern short dmc_get_stop_reason(ushort CardNo, ushort axis, ref long StopReason);//读取停止原因
        [DllImport("LTDMC.dll")]
        public static extern short dmc_clear_stop_reason(ushort CardNo, ushort axis);//清除停止原因
        [DllImport("LTDMC.dll")]
        public static extern short dmc_set_dec_stop_dist(ushort CardNo, ushort axis, long dist);  //设置减速停止距离
        [DllImport("LTDMC.dll")]
        public static extern short dmc_get_dec_stop_dist(ushort CardNo, ushort axis, ref long dist);
        [DllImport("LTDMC.dll")]
        public static extern short dmc_set_da_enable(ushort CardNo, ushort enable);//开启DA输出
        [DllImport("LTDMC.dll")]
        public static extern short dmc_get_da_enable(ushort CardNo, ref ushort enable);
        [DllImport("LTDMC.dll")]
        public static extern short dmc_set_da_output(ushort CardNo, ushort channel, double Vout);//设置DA输出
        [DllImport("LTDMC.dll")]
        public static extern short dmc_get_da_output(ushort CardNo, ushort channel, ref double Vout);
    }
}
