#ifndef _DMC_LIB_H
#define _DMC_LIB_H

#ifndef TRUE
#define TRUE  1
#endif

#ifndef FALSE
#define FALSE 0
#endif

#ifndef NULL
#ifdef  __cplusplus
#define NULL    0
#else
#define NULL    ((void *)0)
#endif
#endif

typedef unsigned long       DWORD;
typedef int                 BOOL;
typedef unsigned char       BYTE;
typedef unsigned short      WORD;
typedef float               FLOAT;

#define __DMC_EXPORTS

//定义输入和输出
#ifdef __DMC_EXPORTS
	#define DMC_API __declspec(dllexport)
#else
	#define DMC_API __declspec(dllimport)
#endif

#ifdef __cplusplus
extern "C" {
#endif

//板卡配置	
DMC_API short __stdcall dmc_board_init(void); 	//初始化控制卡
DMC_API short __stdcall dmc_board_close(void);	//关闭控制卡
DMC_API short __stdcall dmc_board_reset(void); //硬件复位
DMC_API short __stdcall	dmc_get_CardInfList(WORD* CardNun,DWORD* CardTypeList,WORD* CardIdList);//读取初始化完成后的卡信息列表
DMC_API short __stdcall dmc_get_CardNo_version(WORD CardNo,DWORD *CardVersion);	//读取控制卡硬件版本
DMC_API short __stdcall dmc_get_CardNo_soft_version(WORD CardNo,DWORD *FirmID,DWORD *SubFirmID);	//读取控制卡硬件的固件版本
DMC_API short __stdcall dmc_get_CardNo_lib_version(DWORD *LibVer);	//读取控制卡动态库版本
DMC_API short __stdcall dmc_get_total_axes(WORD CardNo,DWORD *TotalAxis); 	//读取指定卡轴数
//函数库打印输出功能 mode：0-不输出，1-输出
DMC_API short __stdcall dmc_set_debug_mode(WORD mode,const char *FileName);
DMC_API short __stdcall dmc_get_debug_mode(WORD* mode,char *FileName);
//3800专用 轴IO映射配置
DMC_API short __stdcall dmc_set_AxisIoMap(WORD CardNo,WORD Axis,WORD MsgType,WORD MapPortType,WORD MapPortIndex,DWORD Filter); 
DMC_API short __stdcall dmc_get_AxisIoMap(WORD CardNo,WORD Axis,WORD MsgType,WORD* MapPortType,WORD* MapPortIndex,DWORD* Filter); 
//以上函数以毫秒为单位可继续使用，新函数将时间统一到秒为单位
DMC_API short __stdcall dmc_set_axis_io_map(WORD CardNo,WORD Axis,WORD IoType,WORD MapIoType,WORD MapIoIndex,double filter_time);
DMC_API short __stdcall dmc_get_axis_io_map(WORD CardNo,WORD Axis,WORD IoType,WORD* MapIoType,WORD* MapIoIndex,double* filter_time);
DMC_API short __stdcall dmc_set_special_input_filter(WORD CardNo,double filter_time);//设置所有专用IO滤波时间

//下载参数文件
DMC_API short __stdcall dmc_download_configfile(WORD CardNo,const char *FileName);
//下载固件文件
DMC_API short __stdcall dmc_download_firmware(WORD CardNo,const char *FileName);
//限位/异常配置
DMC_API short __stdcall dmc_set_softlimit(WORD CardNo,WORD axis,WORD enable, WORD source_sel,WORD SL_action, long N_limit,long P_limit);	//设置软限位参数
DMC_API short __stdcall dmc_get_softlimit(WORD CardNo,WORD axis,WORD *enable, WORD *source_sel,WORD *SL_action,long *N_limit,long *P_limit);	//读取软限位参数
DMC_API short __stdcall dmc_set_el_mode(WORD CardNo,WORD axis,WORD el_enable,WORD el_logic,WORD el_mode); 	//设置EL信号
DMC_API short __stdcall dmc_get_el_mode(WORD CardNo,WORD axis,WORD *el_enable,WORD *el_logic,WORD *el_mode); 	//读取设置EL信号
DMC_API short __stdcall dmc_set_emg_mode(WORD CardNo,WORD axis,WORD enable,WORD emg_logic); 	//设置EMG信号
DMC_API short __stdcall dmc_get_emg_mode(WORD CardNo,WORD axis,WORD *enable,WORD *emg_logic); 	//读取设置EMG信号

//3800专用 外部减速停止信号及减速停止时间设置
DMC_API short __stdcall dmc_set_dstp_mode(WORD CardNo,WORD axis,WORD enable,WORD logic,DWORD time); 	
DMC_API short __stdcall dmc_get_dstp_mode(WORD CardNo,WORD axis,WORD *enable,WORD *logic,DWORD *time); 	
DMC_API short __stdcall dmc_set_dstp_time(WORD CardNo,WORD axis,DWORD time);
DMC_API short __stdcall dmc_get_dstp_time(WORD CardNo,WORD axis,DWORD *time);
//以上函数以毫秒为单位可继续使用，新函数将时间统一到秒为单位
DMC_API short __stdcall dmc_set_io_dstp_mode(WORD CardNo,WORD axis,WORD enable,WORD logic); //设置外部IO触发减速停止模式
DMC_API short __stdcall dmc_get_io_dstp_mode(WORD CardNo,WORD axis,WORD *enable,WORD *logic); 	
DMC_API short __stdcall dmc_set_dec_stop_time(WORD CardNo,WORD axis,double  stop_time);//设置全局减速停止时间
DMC_API short __stdcall dmc_get_dec_stop_time(WORD CardNo,WORD axis,double * stop_time);

//速度设置		
DMC_API short __stdcall dmc_set_profile(WORD CardNo,WORD axis,double Min_Vel,double Max_Vel,double Tacc,double Tdec,double stop_vel);	//设定速度曲线参数
DMC_API short __stdcall dmc_get_profile(WORD CardNo,WORD axis,double *Min_Vel,double *Max_Vel,double *Tacc,double *Tdec,double *stop_vel);	//读取速度曲线参数
DMC_API short __stdcall dmc_set_s_profile(WORD CardNo,WORD axis,WORD s_mode,double s_para);	//设置平滑速度曲线参数
DMC_API short __stdcall dmc_get_s_profile(WORD CardNo,WORD axis,WORD s_mode,double *s_para);	//读取平滑速度曲线参数
DMC_API short __stdcall dmc_set_vector_profile_multicoor(WORD CardNo,WORD Crd, double Min_Vel,double Max_Vel,double Tacc,double Tdec=0,double Stop_Vel=0);
DMC_API short __stdcall dmc_get_vector_profile_multicoor(WORD CardNo,WORD Crd, double *Min_Vel,double *Max_Vel,double *Tacc,double *Tdec=NULL,double *Stop_Vel=NULL);

//运动模块脉冲模式		
DMC_API short __stdcall dmc_set_pulse_outmode(WORD CardNo,WORD axis,WORD outmode);	//设定脉冲输出模式
DMC_API short __stdcall dmc_get_pulse_outmode(WORD CardNo,WORD axis,WORD* outmode);	//读取脉冲输出模式

//单轴运动		
DMC_API short __stdcall dmc_pmove(WORD CardNo,WORD axis,long dist,WORD posi_mode);	//指定轴做定长位移运动
DMC_API short __stdcall dmc_vmove(WORD CardNo,WORD axis,WORD dir);	//指定轴做连续运动

//PVT运动
DMC_API short __stdcall dmc_PvtTable(WORD CardNo,WORD iaxis,DWORD count,double *pTime,long *pPos,double *pVel);
DMC_API short __stdcall dmc_PtsTable(WORD CardNo,WORD iaxis,DWORD count,double *pTime,long *pPos,double *pPercent);
DMC_API short __stdcall dmc_PvtsTable(WORD CardNo,WORD iaxis,DWORD count,double *pTime,long *pPos,double velBegin,double velEnd);
DMC_API short __stdcall dmc_PttTable(WORD CardNo,WORD iaxis,DWORD count,double *pTime,long *pPos);
DMC_API short __stdcall dmc_PvtMove(WORD CardNo,WORD AxisNum,WORD* AxisList);

//在线变位/变速
DMC_API short __stdcall dmc_reset_target_position(WORD CardNo,WORD axis,long dist,WORD posi_mode=0);	//运动中改变目标位置
DMC_API short __stdcall dmc_change_speed(WORD CardNo,WORD axis,double Curr_Vel,double Taccdec);	//在线改变指定轴的当前运动速度及加减速时间
DMC_API short __stdcall dmc_update_target_position(WORD CardNo,WORD axis,long dist,WORD posi_mode=0);	//强行改变目标位置

//直线插补		
DMC_API short __stdcall dmc_line_multicoor(WORD CardNo,WORD Crd,WORD axisNum,WORD *axisList,long *DistList,WORD posi_mode);	//指定轴直线插补运动
DMC_API short __stdcall dmc_arc_move_multicoor(WORD CardNo,WORD Crd,WORD *AxisList,long *Target_Pos,long *Cen_Pos,WORD Arc_Dir,WORD posi_mode);

//回零运动	
DMC_API short __stdcall dmc_set_home_pin_logic(WORD CardNo,WORD axis,WORD org_logic,double filter=0); 	//设置HOME信号
DMC_API short __stdcall dmc_get_home_pin_logic(WORD CardNo,WORD axis,WORD *org_logic,double *filter=NULL); 	//读取设置HOME信号	
DMC_API short __stdcall dmc_set_homemode(WORD CardNo,WORD axis,WORD home_dir,double vel_mode,WORD mode,WORD EZ_count=0);//设定指定轴的回原点模式
DMC_API short __stdcall dmc_get_homemode(WORD CardNo,WORD axis,WORD *home_dir, double *vel_mode,WORD *home_mode,WORD *EZ_count=NULL);//读取指定轴的回原点模式
DMC_API short __stdcall dmc_home_move(WORD CardNo,WORD axis);	
//3410专用 回原点减速信号配置
//DMC_API short __stdcall dmc_set_sd_mode(WORD CardNo,WORD axis,WORD enable,WORD sd_logic,WORD sd_mode); 	//设置SD信号
//DMC_API short __stdcall dmc_get_sd_mode(WORD CardNo,WORD axis,WORD* enable,WORD *sd_logic,WORD *sd_mode); 	//读取设置SD信号
//3800专用 原点锁存
DMC_API short __stdcall dmc_set_homelatch_mode(WORD CardNo,WORD axis,WORD enable,WORD logic,WORD source);//设置原点锁存模式
DMC_API short __stdcall dmc_get_homelatch_mode(WORD CardNo,WORD axis,WORD* enable,WORD* logic,WORD* source);
DMC_API long __stdcall dmc_get_homelatch_flag(WORD CardNo,WORD axis);//读取锁存标志
DMC_API short __stdcall dmc_reset_homelatch_flag(WORD CardNo,WORD axis);//复位原点锁存标志
DMC_API long __stdcall dmc_get_homelatch_value(WORD CardNo,WORD axis);//读取锁存值

//手轮运动	
//3800专用 手轮通道选择	
DMC_API short __stdcall dmc_set_handwheel_channel(WORD CardNo,WORD index);
DMC_API short __stdcall dmc_get_handwheel_channel(WORD CardNo,WORD* index);
//一个手轮信号控制单个轴运动
DMC_API short __stdcall dmc_set_handwheel_inmode(WORD CardNo,WORD axis,WORD inmode,long multi,double vh=0);	//设置输入手轮脉冲信号的工作方式 控制单轴
DMC_API short __stdcall dmc_get_handwheel_inmode(WORD CardNo,WORD axis,WORD *inmode,long *multi,double *vh=NULL);	//读取输入手轮脉冲信号的工作方式 控制单轴
//一个手轮信号控制多个轴运动
DMC_API short __stdcall dmc_set_handwheel_inmode_extern(WORD CardNo,WORD inmode,WORD AxisNum,WORD* AxisList,long* multi);	//设置输入手轮脉冲信号的工作方式 控制多轴
DMC_API short __stdcall dmc_get_handwheel_inmode_extern(WORD CardNo,WORD* inmode,WORD* AxisNum,WORD* AxisList,long *multi);	
//启动指定轴的手轮脉冲运动
DMC_API short __stdcall dmc_handwheel_move(WORD CardNo,WORD axis);	

//编码器		
DMC_API short __stdcall dmc_set_counter_inmode(WORD CardNo,WORD axis,WORD mode);	//设定编码器的计数方式
DMC_API short __stdcall dmc_get_counter_inmode(WORD CardNo,WORD axis,WORD *mode);	//读取编码器的计数方式
DMC_API long __stdcall dmc_get_encoder(WORD CardNo,WORD axis);	
DMC_API short __stdcall dmc_set_encoder(WORD CardNo,WORD axis,long encoder_value);
DMC_API short __stdcall dmc_set_ez_mode(WORD CardNo,WORD axis,WORD ez_logic,WORD ez_mode=0,double filter=0);	//设置EZ信号
DMC_API short __stdcall dmc_get_ez_mode(WORD CardNo,WORD axis,WORD *ez_logic,WORD *ez_mode=NULL,double *filter=NULL);	//读取设置EZ信号

//高速锁存
DMC_API short __stdcall dmc_set_ltc_mode(WORD CardNo,WORD axis,WORD ltc_logic,WORD ltc_mode=0,double filter=0); 	//设置LTC信号
DMC_API short __stdcall dmc_get_ltc_mode(WORD CardNo,WORD axis,WORD*ltc_logic,WORD*ltc_mode=NULL,double *filter=NULL);	//读取设置LTC信号
DMC_API short __stdcall dmc_set_latch_mode(WORD CardNo,WORD axis,WORD all_enable,WORD latch_sourcee,WORD latch_channel=0); 	//设置锁存方式
DMC_API short __stdcall dmc_get_latch_mode(WORD CardNo,WORD axis,WORD *all_enable,WORD* latch_sourcee,WORD *latch_channel=NULL); 
DMC_API short __stdcall dmc_reset_latch_flag(WORD CardNo,WORD axis); 	//复位锁存器标志
DMC_API short __stdcall dmc_get_latch_flag(WORD CardNo,WORD axis); 	//读取控制卡内有效锁存个数
DMC_API long __stdcall dmc_get_latch_value(WORD CardNo,WORD axis); 	//读取控制卡内锁存值，再连续锁存模式下读取一次控制卡内有效锁存个数将会自动减1,并将锁存值保存在PC缓冲区内
DMC_API short __stdcall dmc_get_latch_flag_extern(WORD CardNo,WORD axis); 	//读取锁存器已锁存个数
DMC_API long __stdcall dmc_get_latch_value_extern(WORD CardNo,WORD axis,WORD index); 	//按索引号读取PC缓冲区中已保存的锁存值，读的时候会将控制卡内的有效锁存值全部保存在PC缓冲区中
//LTC端口触发延时急停时间 单位：微秒
DMC_API short __stdcall dmc_set_latch_stop_time(WORD CardNo,WORD axis,long stop_time); 
DMC_API short __stdcall dmc_get_latch_stop_time(WORD CardNo,WORD axis,long* stop_time);
//DMC3800专用 LTC反相输出
DMC_API short __stdcall dmc_SetLtcOutMode(WORD CardNo,WORD axis,WORD enable,WORD bitno);//设置LTC反向输出模式
DMC_API short __stdcall dmc_GetLtcOutMode(WORD CardNo,WORD axis,WORD *enable,WORD* bitno);

//单轴低速位置比较		
DMC_API short __stdcall dmc_compare_set_config(WORD CardNo,WORD axis,WORD enable, WORD cmp_source); 	//配置比较器
DMC_API short __stdcall dmc_compare_get_config(WORD CardNo,WORD axis,WORD *enable, WORD *cmp_source);	//读取配置比较器
DMC_API short __stdcall dmc_compare_clear_points(WORD CardNo,WORD axis); 	//清除所有比较点
DMC_API short __stdcall dmc_compare_add_point(WORD CardNo,WORD axis,long pos,WORD dir, WORD action,DWORD actpara); 	//添加比较点
DMC_API short __stdcall dmc_compare_get_current_point(WORD CardNo,WORD axis,long *pos); 	//读取当前比较点
DMC_API short __stdcall dmc_compare_get_points_runned(WORD CardNo,WORD axis,long *pointNum); 	//查询已经比较过的点
DMC_API short __stdcall dmc_compare_get_points_remained(WORD CardNo,WORD axis,long *pointNum); 	//查询可以加入的比较点数量

//二维低速位置比较
DMC_API short __stdcall dmc_compare_set_config_extern(WORD CardNo,WORD enable, WORD cmp_source); 	//配置比较器
DMC_API short __stdcall dmc_compare_get_config_extern(WORD CardNo,WORD *enable, WORD *cmp_source);	//读取配置比较器
DMC_API short __stdcall dmc_compare_clear_points_extern(WORD CardNo); 	//清除所有比较点
DMC_API short __stdcall dmc_compare_add_point_extern(WORD CardNo,WORD* axis,long* pos,WORD* dir, WORD action,DWORD actpara); 	//添加两轴位置比较点
DMC_API short __stdcall dmc_compare_get_current_point_extern(WORD CardNo,long *pos); 	//读取当前比较点
DMC_API short __stdcall dmc_compare_get_points_runned_extern(WORD CardNo,long *pointNum); 	//查询已经比较过的点
DMC_API short __stdcall dmc_compare_get_points_remained_extern(WORD CardNo,long *pointNum); 	//查询可以加入的二维比较点数量

//高速位置比较 
DMC_API short __stdcall dmc_hcmp_set_mode(WORD CardNo,WORD hcmp, WORD cmp_mode);//设置高速比较模式
DMC_API short __stdcall dmc_hcmp_get_mode(WORD CardNo,WORD hcmp, WORD* cmp_mode);
DMC_API short __stdcall dmc_hcmp_set_config(WORD CardNo,WORD hcmp,WORD axis, WORD cmp_source, WORD cmp_logic,long time);//配置高速比较相关参数
DMC_API short __stdcall dmc_hcmp_get_config(WORD CardNo,WORD hcmp,WORD* axis, WORD* cmp_source, WORD* cmp_logic,long* time);
DMC_API short __stdcall dmc_hcmp_add_point(WORD CardNo,WORD hcmp, long cmp_pos);//添加比较点
DMC_API short __stdcall dmc_hcmp_set_liner(WORD CardNo,WORD hcmp, long Increment,long Count);//设置线性比较模式相关参数
DMC_API short __stdcall dmc_hcmp_get_liner(WORD CardNo,WORD hcmp, long* Increment,long* Count);
DMC_API short __stdcall dmc_hcmp_get_current_state(WORD CardNo,WORD hcmp,long *remained_points,long *current_point=NULL,long *runned_points=NULL); //读取比较状态
DMC_API short __stdcall dmc_hcmp_clear_points(WORD CardNo,WORD hcmp); 	//清除比较点
DMC_API short __stdcall dmc_read_cmp_pin(WORD CardNo,WORD hcmp); //读取高速比较输出口状态
DMC_API short __stdcall dmc_write_cmp_pin(WORD CardNo,WORD hcmp, WORD on_off);

//通用IO		
DMC_API short __stdcall dmc_read_inbit(WORD CardNo,WORD bitno); 	//读取输入口的状态
DMC_API short __stdcall dmc_write_outbit(WORD CardNo,WORD bitno,WORD on_off); 	//设置输出口的状态
DMC_API short __stdcall dmc_read_outbit(WORD CardNo,WORD bitno);  	//读取输出口的状态
DMC_API DWORD __stdcall dmc_read_inport(WORD CardNo,WORD portno); 	//读取输入端口的值
DMC_API DWORD __stdcall dmc_read_outport(WORD CardNo,WORD portno=0); 	//读取输出端口的值
DMC_API short __stdcall dmc_write_outport(WORD CardNo,WORD portno,DWORD outport_val);  	//设置输出端口的值

//IO输出延时翻转
DMC_API short __stdcall dmc_IO_TurnOutDelay(WORD CardNo,WORD bitno,DWORD DelayTime);
//以上函数以毫秒为单位可继续使用，新函数将时间统一到秒为单位
DMC_API short __stdcall dmc_reverse_outbit(WORD CardNo,WORD bitno,double reverse_time);

//3800专用 IO计数功能
DMC_API short __stdcall dmc_SetIoCountMode(WORD CardNo,WORD bitno,WORD mode,DWORD filter);
DMC_API short __stdcall dmc_GetIoCountMode(WORD CardNo,WORD bitno,WORD *mode,DWORD* filter);
DMC_API short __stdcall dmc_SetIoCountValue(WORD CardNo,WORD bitno,DWORD CountValue);
DMC_API short __stdcall dmc_GetIoCountValue(WORD CardNo,WORD bitno,DWORD* CountValue);
//以上函数以毫秒为单位可继续使用，新函数将时间统一到秒为单位
DMC_API short __stdcall dmc_set_io_count_mode(WORD CardNo,WORD bitno,WORD mode,double filter_time);//设置IO计数模式
DMC_API short __stdcall dmc_get_io_count_mode(WORD CardNo,WORD bitno,WORD *mode,double* filter_time);
DMC_API short __stdcall dmc_set_io_count_value(WORD CardNo,WORD bitno,DWORD CountValue);//设置IO计数值
DMC_API short __stdcall dmc_get_io_count_value(WORD CardNo,WORD bitno,DWORD* CountValue);//读取IO计数值

//伺服专用IO		
DMC_API short __stdcall dmc_set_alm_mode(WORD CardNo,WORD axis,WORD enable,WORD alm_logic,WORD alm_action);	//设置ALM信号
DMC_API short __stdcall dmc_get_alm_mode(WORD CardNo,WORD axis,WORD *enable,WORD *alm_logic,WORD *alm_action);	//读取设置ALM信号
DMC_API short __stdcall dmc_set_inp_mode(WORD CardNo,WORD axis,WORD enable,WORD inp_logic);	//设置INP信号
DMC_API short __stdcall dmc_get_inp_mode(WORD CardNo,WORD axis,WORD *enable,WORD *inp_logic);	//读取设置INP信号
DMC_API short __stdcall dmc_read_rdy_pin(WORD CardNo,WORD axis); 	//读取RDY状态
DMC_API short __stdcall dmc_write_erc_pin(WORD CardNo,WORD axis,WORD on_off); 	//控制ERC信号输出
DMC_API short __stdcall dmc_read_erc_pin(WORD CardNo,WORD axis); 
DMC_API short __stdcall dmc_write_sevon_pin(WORD CardNo,WORD axis,WORD on_off); 	//输出SEVON信号
DMC_API short __stdcall dmc_read_sevon_pin(WORD CardNo,WORD axis); 	//读取SEVON信号

//DMC3800专用 虚拟IO映射  用于读取滤波后的IO口电平状态
DMC_API short __stdcall dmc_set_io_map_virtual(WORD CardNo,WORD bitno,WORD MapIoType,WORD MapIoIndex,double Filter);
DMC_API short __stdcall dmc_get_io_map_virtual(WORD CardNo,WORD bitno,WORD* MapIoType,WORD* MapIoIndex,double* Filter);
DMC_API short __stdcall dmc_read_inbit_virtual(WORD CardNo,WORD bitno); 	

//运动状态检测		
DMC_API double __stdcall dmc_read_current_speed(WORD CardNo,WORD axis);	//读取指定轴的当前速度
DMC_API double __stdcall dmc_read_vector_speed(WORD CardNo);	//读取当前卡的插补速度
DMC_API long __stdcall dmc_get_position(WORD CardNo,WORD axis);	//读取指定轴的当前位置
DMC_API short __stdcall dmc_set_position(WORD CardNo,WORD axis,long current_position);	//设定指定轴的当前位置
DMC_API long __stdcall dmc_get_target_position(WORD CardNo,WORD axis);        //读取指定轴的目标位置
DMC_API short __stdcall dmc_check_done(WORD CardNo,WORD axis);	//读取指定轴的运动状态
DMC_API DWORD __stdcall dmc_axis_io_status(WORD CardNo,WORD axis);	//读取指定轴有关运动信号的状态
DMC_API short __stdcall dmc_stop(WORD CardNo,WORD axis,WORD stop_mode);	//单轴减速停止/立即停止
DMC_API short __stdcall dmc_check_done_multicoor(WORD CardNo,WORD Crd); //调用插补运动，请使用该函数检测运动状态
DMC_API short __stdcall dmc_stop_multicoor(WORD CardNo,WORD Crd,WORD stop_mode);//调用插补运动，请使用该函数停止运动状态
DMC_API short __stdcall dmc_emg_stop(WORD CardNo);	//紧急停止所有轴
//检测轴到位状态
DMC_API short __stdcall  dmc_set_factor_error(WORD CardNo,WORD axis,double factor,long error);//设置编码器系数、误差带
DMC_API short __stdcall  dmc_get_factor_error(WORD CardNo,WORD axis,double* factor,long* error);//读取编码器系数、误差带
DMC_API short __stdcall  dmc_check_success_pulse(WORD CardNo,WORD axis);//检测指令位置到位情况
DMC_API short __stdcall  dmc_check_success_encoder(WORD CardNo,WORD axis);//检测编码器反馈位置到位情况

//3800专用 主卡与接线盒通讯状态
DMC_API short __stdcall dmc_LinkState(WORD CardNo,WORD* State);	//连接状态

//密码管理
DMC_API short __stdcall dmc_check_sn(WORD CardNo, const char * check_sn);//验证密码，校验3次失败之后再次校验将返回校验失败
DMC_API short __stdcall dmc_write_sn(WORD CardNo, const char * new_sn);//改写密码

//DMC5410 DMC5800专用
DMC_API short __stdcall dmc_get_axis_run_mode(WORD CardNo, WORD axis,WORD* run_mode);//轴运动模式
DMC_API short __stdcall dmc_get_equiv(WORD CardNo,WORD axis, double *equiv);//脉冲当量
DMC_API short __stdcall dmc_set_equiv(WORD CardNo,WORD axis, double equiv);
DMC_API short __stdcall dmc_set_backlash_unit(WORD CardNo,WORD axis,double backlash);//反向间隙
DMC_API short __stdcall dmc_get_backlash_unit(WORD CardNo,WORD axis,double *backlash);
DMC_API short __stdcall dmc_set_position_unit(WORD CardNo,WORD axis, double pos);//当前指令位置
DMC_API short __stdcall dmc_get_position_unit(WORD CardNo,WORD axis, double * pos);
DMC_API short __stdcall dmc_set_encoder_unit(WORD CardNo,WORD axis, double pos);//当前反馈位置
DMC_API short __stdcall dmc_get_encoder_unit(WORD CardNo,WORD axis, double * pos);
DMC_API short __stdcall dmc_pmove_unit(WORD CardNo,WORD axis,double Dist,WORD posi_mode);//定长
DMC_API short __stdcall dmc_t_pmove_unit(WORD CardNo,WORD axis,double Dist,WORD posi_mode);//对称T型定长
DMC_API short __stdcall dmc_ex_t_pmove_unit(WORD CardNo,WORD axis,double Dist,WORD posi_mode);//非对称T型定长
DMC_API short __stdcall dmc_s_pmove_unit(WORD CardNo,WORD axis,double Dist,WORD posi_mode);//对称S型定长
DMC_API short __stdcall dmc_ex_s_pmove_unit(WORD CardNo,WORD axis,double Dist,WORD posi_mode);//非对称S型定长
DMC_API short __stdcall dmc_line_unit(WORD CardNo,WORD Crd,WORD AxisNum,WORD* AxisList,double* Target_Pos,WORD posi_mode);//单段直线
DMC_API short __stdcall dmc_arc_move_center_unit(WORD CardNo,WORD Crd,WORD AxisNum,WORD* AxisList,double *Target_Pos,double *Cen_Pos,WORD Arc_Dir,long Circle,WORD posi_mode);//单段圆心圆弧/螺旋线/渐开线
DMC_API short __stdcall dmc_arc_move_radius_unit(WORD CardNo,WORD Crd,WORD AxisNum,WORD* AxisList,double *Target_Pos,double Arc_Radius,WORD Arc_Dir,long Circle,WORD posi_mode);//单段半径圆弧/螺旋线
DMC_API short __stdcall dmc_arc_move_3points_unit(WORD CardNo,WORD Crd,WORD AxisNum,WORD* AxisList,double *Target_Pos,double *Mid_Pos,long Circle,WORD posi_mode);//单段三点圆弧/螺旋线
DMC_API short __stdcall dmc_rectangle_move_unit(WORD CardNo,WORD Crd,WORD AxisNum,WORD* AxisList,double* Target_Pos,double* Mark_Pos,long num,WORD rect_mode,WORD posi_mode);//单段矩形插补
DMC_API short __stdcall dmc_read_current_speed_unit(WORD CardNo,WORD axis, double *current_speed);//轴当前运行速度
DMC_API short __stdcall dmc_set_vector_profile_unit(WORD CardNo,WORD Crd,double Min_Vel,double Max_Vel,double Tacc,double Tdec,double Stop_Vel);//单段插补速度参数
DMC_API short __stdcall dmc_get_vector_profile_unit(WORD CardNo,WORD Crd,double* Min_Vel,double* Max_Vel,double* Tacc,double* Tdec,double* Stop_Vel);
DMC_API short __stdcall dmc_set_vector_s_profile(WORD CardNo,WORD Crd,WORD s_mode,double s_para);	//设置S型速度曲线参数
DMC_API short __stdcall dmc_get_vector_s_profile(WORD CardNo,WORD Crd,WORD s_mode,double *s_para);
DMC_API short __stdcall dmc_set_profile_unit(WORD CardNo,WORD axis,double Min_Vel,double Max_Vel,double Tacc,double Tdec,double Stop_Vel);//单轴速度参数
DMC_API short __stdcall dmc_get_profile_unit(WORD CardNo,WORD axis,double* Min_Vel,double* Max_Vel,double* Tacc,double* Tdec,double* Stop_Vel);
DMC_API short __stdcall dmc_reset_target_position_unit(WORD CardNo,WORD axis, double New_Pos);//在线变位
DMC_API short __stdcall dmc_update_target_position_unit(WORD CardNo,WORD axis, double New_Pos);//强行变位
DMC_API short __stdcall dmc_change_speed_unit(WORD CardNo,WORD axis, double New_Vel,double Taccdec);//在线变速
//连续插补
DMC_API short __stdcall dmc_conti_open_list(WORD CardNo,WORD Crd,WORD AxisNum,WORD* AxisList); //打开连续缓存区
DMC_API short __stdcall dmc_conti_close_list(WORD CardNo,WORD Crd);	//关闭连续缓存区
DMC_API short __stdcall dmc_conti_stop_list(WORD CardNo,WORD Crd,WORD stop_mode);	//连续插补中停止
DMC_API short __stdcall dmc_conti_pause_list(WORD CardNo,WORD Crd);	//连续插补中暂停
DMC_API short __stdcall dmc_conti_start_list(WORD CardNo,WORD Crd);	//开始连续插补
DMC_API long __stdcall dmc_conti_remain_space(WORD CardNo,WORD Crd);	//查连续插补剩余缓存数
DMC_API long __stdcall dmc_conti_read_current_mark (WORD CardNo,WORD Crd);	//读取当前连续插补段的标号
DMC_API short __stdcall dmc_conti_set_blend(WORD CardNo,WORD Crd,WORD enable);//blend拐角过度模式
DMC_API short __stdcall dmc_conti_get_blend(WORD CardNo,WORD Crd,WORD* enable);
DMC_API short __stdcall dmc_conti_set_profile_unit(WORD CardNo,WORD Crd,double Min_Vel,double Max_vel,double Tacc,double Tdec,double Stop_Vel);//设置连续插补速度
DMC_API short __stdcall dmc_conti_set_s_profile(WORD CardNo,WORD Crd,WORD s_mode,double s_para);//设置连续插补平滑时间
DMC_API short __stdcall dmc_conti_get_s_profile(WORD CardNo,WORD Crd,WORD s_mode,double* s_para);
DMC_API short __stdcall dmc_conti_set_pause_output(WORD CardNo,WORD Crd,WORD action,long mask,long state);//暂停时IO输出 action：0-不动作；1-暂停时输出；2-暂停时输出, 继续运行时恢复；3-停止时输出。
DMC_API short __stdcall dmc_conti_get_pause_output(WORD CardNo,WORD Crd,WORD* action,long* mask,long* state);
DMC_API short __stdcall dmc_conti_set_override(WORD CardNo,WORD Crd,double Percent);//设置每段速度比例  缓冲区指令
DMC_API short __stdcall dmc_conti_change_speed_ratio (WORD CardNo,WORD Crd,double percent);//连续插补动态变速
DMC_API short __stdcall dmc_conti_get_run_state(WORD CardNo,WORD Crd);//读取连续插补状态：0-运行，1-暂停，2-正常停止，3-异常停止
DMC_API short __stdcall dmc_conti_check_done(WORD CardNo,WORD Crd);//检测连续插补运动状态：0-运行，1-停止
DMC_API short __stdcall dmc_conti_wait_input(WORD CardNo,WORD Crd,WORD bitno,WORD on_off,double TimeOut,long mark);//设置连续插补等待输入
DMC_API short __stdcall dmc_conti_delay_outbit_to_start(WORD CardNo, WORD Crd, WORD bitno,WORD on_off,double delay_value,WORD delay_mode,double ReverseTime);//相对于轨迹段起点IO滞后输出
DMC_API short __stdcall dmc_conti_delay_outbit_to_stop(WORD CardNo, WORD Crd, WORD bitno,WORD on_off,double delay_time,double ReverseTime);//相对于轨迹段终点IO滞后输出
DMC_API short __stdcall dmc_conti_ahead_outbit_to_stop(WORD CardNo, WORD Crd, WORD bitno,WORD on_off,double ahead_value,WORD ahead_mode,double ReverseTime);//相对轨迹段终点IO提前输出
DMC_API short __stdcall dmc_conti_accurate_outbit_unit(WORD CardNo, WORD Crd, WORD cmp_no,WORD on_off,WORD map_axis,double rel_dist,WORD pos_source,double ReverseTime);//确定位置精确输出
DMC_API short __stdcall dmc_conti_write_outbit(WORD CardNo, WORD Crd, WORD bitno,WORD on_off,double ReverseTime);//缓冲区立即IO输出
DMC_API short __stdcall dmc_conti_clear_io_action(WORD CardNo, WORD Crd, DWORD IoMask);//清除段内未执行完的IO动作,防止在下一段执行
DMC_API short __stdcall dmc_conti_delay(WORD CardNo, WORD Crd, double delay_time,long mark);//添加延时指令
DMC_API short __stdcall dmc_conti_line_unit(WORD CardNo,WORD Crd,WORD AxisNum,WORD* AxisList,double* Target_Pos,WORD posi_mode,long mark);//连续插补直线
DMC_API short __stdcall dmc_conti_arc_move_center_unit(WORD CardNo,WORD Crd,WORD AxisNum,WORD* AxisList,double *Target_Pos,double *Cen_Pos,WORD Arc_Dir,long Circle,WORD posi_mode,long mark);//圆心终点式圆弧/螺旋线/渐开线/同心圆
DMC_API short __stdcall dmc_conti_arc_move_radius_unit(WORD CardNo,WORD Crd,WORD AxisNum,WORD* AxisList,double *Target_Pos,double Arc_Radius,WORD Arc_Dir,long Circle,WORD posi_mode,long mark);//半径终点式圆弧/螺旋线
DMC_API short __stdcall dmc_conti_arc_move_3points_unit(WORD CardNo,WORD Crd,WORD AxisNum,WORD* AxisList,double *Target_Pos,double *Mid_Pos,long Circle,WORD posi_mode,long mark);//三点式圆弧/螺旋线
DMC_API short __stdcall dmc_conti_set_involute_mode(WORD CardNo,WORD Crd,WORD mode);//渐开线整圆封闭
DMC_API short __stdcall dmc_conti_get_involute_mode(WORD CardNo,WORD Crd,WORD* mode);
DMC_API short __stdcall dmc_conti_rectangle_move_unit(WORD CardNo,WORD Crd,WORD AxisNum,WORD* AxisList,double* Target_Pos,double* Mark_Pos,long num,WORD rect_mode,WORD posi_mode,long mark);//矩形插补
DMC_API short __stdcall dmc_calculate_arclength_center(double* start_pos,double *target_pos,double *cen_pos, WORD arc_dir,double circle,double* ArcLength);//计算圆心圆弧弧长
DMC_API short __stdcall dmc_calculate_arclength_radius(double* start_pos,double *target_pos,double arc_radius, WORD arc_dir,double circle,double* ArcLength);//计算半径圆弧弧长
DMC_API short __stdcall dmc_calculate_arclength_3point(double *start_pos,double *mid_pos, double *end_pos,double circle,double* ArcLength);//计算三点圆弧弧长
//DMC5800专用 PWM及CanIO
DMC_API short __stdcall dmc_set_pwm_enable(WORD CardNo,WORD enable);//7号轴切换为PWM输出
DMC_API short __stdcall dmc_get_pwm_enable(WORD CardNo,WORD* enable);
DMC_API short __stdcall dmc_conti_set_pwm_output(WORD CardNo,WORD Crd, WORD pwm_no,double fDuty, double fFre);//连续插补中设置PWM输出
DMC_API short __stdcall dmc_set_pwm_output(WORD CardNo,WORD pwm_no,double fDuty, double fFre);//设置PWM输出
DMC_API short __stdcall dmc_get_pwm_output(WORD CardNo,WORD pwm_no,double* fDuty, double* fFre);
DMC_API short __stdcall dmc_conti_set_pwm_follow_speed(WORD CardNo,WORD Crd,WORD pwm_no,WORD mode,double MaxVel,double MaxValue,double OutValue);//PWM速度跟随
DMC_API short __stdcall dmc_conti_get_pwm_follow_speed(WORD CardNo,WORD Crd,WORD pwm_no,WORD* mode,double* MaxVel,double* MaxValue,double* OutValue);

DMC_API short __stdcall dmc_set_can_state(WORD CardNo,WORD NodeNum,WORD state,WORD Baud);//0-断开；1-连接；2-复位后自动连接
DMC_API short __stdcall dmc_get_can_state(WORD CardNo,WORD* NodeNum,WORD* state);////0-断开；1-连接；2-异常
DMC_API short __stdcall dmc_get_can_errcode(WORD CardNo,WORD *Errcode);//读取CanIo通讯错误码
DMC_API short __stdcall dmc_write_can_outbit(WORD CardNo,WORD Node,WORD bitno,WORD on_off);
DMC_API short __stdcall dmc_read_can_outbit(WORD CardNo,WORD Node,WORD bitno);
DMC_API short __stdcall dmc_read_can_inbit(WORD CardNo,WORD Node,WORD bitno);
DMC_API short __stdcall dmc_write_can_outport(WORD CardNo,WORD Node,WORD portno,DWORD outport_val);//写CanIo输出口
DMC_API DWORD __stdcall dmc_read_can_outport(WORD CardNo,WORD Node,WORD portno);//读取CanIo输出端口
DMC_API DWORD __stdcall dmc_read_can_inport(WORD CardNo,WORD Node,WORD portno);//读取CanIo输入端口

DMC_API short __stdcall dmc_get_stop_reason(WORD CardNo,WORD axis,long* StopReason);//读取停止原因
DMC_API short __stdcall dmc_clear_stop_reason(WORD CardNo,WORD axis);//清除停止原因
//DMC3410 减速停止 对应 25 26 27 28输入口
//DMC_API short __stdcall dmc_set_io_dstp_mode(WORD CardNo,WORD axis,WORD enable,WORD logic); 	//启用减速停止IO及有效电平 //enable:0-禁用，1-按时间减速停止，2-按距离减速停止
//DMC_API short __stdcall dmc_get_io_dstp_mode(WORD CardNo,WORD axis,WORD *enable,WORD *logic); 
//DMC_API short __stdcall dmc_set_dec_stop_time(WORD CardNo,WORD axis,double time);
//DMC_API short __stdcall dmc_get_dec_stop_time(WORD CardNo,WORD axis,double *time); 
DMC_API short __stdcall dmc_set_dec_stop_dist(WORD CardNo,WORD axis,long dist);	//设置减速停止距离
DMC_API short __stdcall dmc_get_dec_stop_dist(WORD CardNo,WORD axis,long *dist);

//DMC5600定制接线盒
DMC_API short __stdcall dmc_set_da_enable(WORD CardNo,WORD enable);//开启DA输出
DMC_API short __stdcall dmc_get_da_enable(WORD CardNo,WORD* enable);
DMC_API short __stdcall dmc_set_da_output(WORD CardNo,WORD channel,double Vout);//设置DA输出
DMC_API short __stdcall dmc_get_da_output(WORD CardNo,WORD channel,double* Vout);
#ifdef __cplusplus
}
#endif

#endif