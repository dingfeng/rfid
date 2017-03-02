using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RFIDIntegratedApplication.Analysis
{
    //从导轨中读取的
    public class PositionRecord
    {
        public float x;
        public float angle;
        public ulong timestamp;
        public PositionRecord(float x, float angle, ulong timestamp)
        {
            this.x = x;
            this.angle = angle;
            this.timestamp = timestamp;
        }
    }
}
