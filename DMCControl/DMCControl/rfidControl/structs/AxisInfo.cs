using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RFIDIntegratedApplication.rfidControl.enums;
namespace RFIDIntegratedApplication.rfidControl.structs
{
    public struct AxisInfo
    {
        public ushort m_card_num;//控制卡的号码
        public ushort m_axis_num;//轴号
        public ushort m_pulse_mode;//脉冲形式
        public int m_home_flag;//有没有找到零点
        public ushort m_run_status;//轴的运动状态
        public MoveDir m_home_dir;//回零方向   0:正向  1:反向
        public short m_home_mode;//回零方式
        public AxisStatus m_status;//该轴的运动信号的状态
        public int m_speed_min;//最小速度
        public int m_speed_max;//最大速度
        public int m_speed_min_home;
        public int m_speed_max_home;
        public double m_acc_time;//加速时间
        public double m_dcc_time;//减速时间
        public long m_positon;//当前脉冲数
    }
}
