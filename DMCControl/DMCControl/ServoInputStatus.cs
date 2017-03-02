using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DMCControl
{
    public struct ServoInputStatus
    {
        public int check_flag;//检测标志
        public int servo1_home_flag; //轴回过原点  1：回过
        public int servo1_alm;//伺服报警   0:没有报警   1：报警
        public int servo1_el_f;//正限位
        public int servo1_el_b;//负限位
        public int servo1_emg;//急停信号
        public int servo1_org;//原点信号
        public int servo1_inp;//伺服到位信号  0：停止  1：运行
        public int servo1_ez;//ez信号
        public int servo1_rdy;//伺服准备好
        public int servo2_home_flag; //轴回过原点  1：回过
        public int servo2_alm;//伺服报警
        public int servo2_el_f;//正限位
        public int servo2_el_b;//负限位
        public int servo2_emg;//急停信号
        public int servo2_org;//原点信号
        public int servo2_inp;//伺服到位信号
        public int servo2_ez;//ez信号
        public int servo2_rdy;//伺服准备好
        public int servo3_home_flag; //轴回过原点  1：回过
        public int servo3_alm;//伺服报警
        public int servo3_el_f;//正限位
        public int servo3_el_b;//负限位
        public int servo3_emg;//急停信号
        public int servo3_org;//原点信号
        public int servo3_inp;//伺服到位信号
        public int servo3_ez;//ez信号
        public int servo3_rdy;//伺服准备好	
    }
}
