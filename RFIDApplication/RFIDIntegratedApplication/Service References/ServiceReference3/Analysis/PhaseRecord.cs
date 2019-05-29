using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RFIDIntegratedApplication.Tag;
using RFIDIntegratedApplication.ServiceReference1;
namespace RFIDIntegratedApplication.Analysis
{
    //从读写器读取的相位记录
    public class PhaseRecord
    {
        public string epc;  //标签id
        public double phase; //相位
        public float x; //水平位置
        public float angle; //角度，弧分
        public ulong timestamp; //时间戳
        public int windowValue; //窗口值
        public TagInfo tagInfo;
        public PhaseRecord(TagInfo tagInfo)
        {
            this.epc = tagInfo.EPC;
            this.phase = tagInfo.AcutalPhaseInRadian;
            this.timestamp = tagInfo.FirstSeenTime;
            this.tagInfo = tagInfo;
        }

    }
}
