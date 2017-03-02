using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RFIDIntegratedApplication.rfidControl.enums;
namespace RFIDIntegratedApplication.rfidControl.structs
{
    public struct InterpolaType
    {
        public int run_flag;//RUN  
        public ushort card_num;//卡号
        public ushort car_num;//坐标系号
        public ushort axis_cout;//几轴插补
        public ushort line_type;//曲线类型
        public ushort arc_dir;//圆弧方向
        public PositionMode posi_mode;//运动模式
        public int m_speed_min;//最小速度
        public int m_speed_max;//最大速度
        public double m_acc_time;//加速时间
        public double m_dcc_time;//减速时间
        public long[] m_ndist;//直线距离  len = 4
        public long[] m_end;//圆弧终点坐标  len = 2
        public long[] m_cen;//圆心  len = 2
        public long[] m_start;//圆弧起点坐标 len = 2
    }
}
