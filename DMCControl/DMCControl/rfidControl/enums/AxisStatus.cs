using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RFIDIntegratedApplication.rfidControl.enums
{
    public enum AxisStatus
    {
        MOTOR_ALM,//表示伺服报警信号 ALM 为 ON； 0：OFF
        MOTOR_EL_F,//表示正硬限位信号 +EL 为 ON； 0：OFF
        MOTOR_EL_B,//表示正硬限位信号 -EL 为 ON； 0：OFF
        MOTOR_EMG,//表示急停信号 EMG 为 ON； 0：OFF
        MOTOR_ORG,//表示原点信号 ORG 为 ON； 0：OFF
        MOTOR_SL_F,//表示正软限位信号+SL 为 ON； 0：OFF
        MOTOR_SL_B,//表示负软件限位信号-SL 为 ON； 0：OF
        MOTOR_INP,//表示伺服到位信号 INP 为 ON； 0：OFF
        MOTOR_EZ,//表示 EZ 信号为 ON； 0：OFF
        MOTOR_RDY,// 表示伺服准备信号 RDY 为 ON （DMC5800 卡专用） ；0：OFF
        MOTOR_DSTP,//1： 表示减速停止信号 DSTP 为 ON （DMC5800 卡专用） ；	0：OFF
        MOTOR_RE//
    }
}
