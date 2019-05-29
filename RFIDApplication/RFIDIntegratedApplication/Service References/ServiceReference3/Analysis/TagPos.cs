using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RFIDIntegratedApplication.Tag;
using RFIDIntegratedApplication.ServiceReference1;
namespace RFIDIntegratedApplication.Analysis
{
    public  class TagPos
    {
        public TagInfo tagInfo;  //标签信息
        public Tuple<double, double, double> pos; //位置信息
        public TagPos(TagInfo tagInfo, Tuple<double,double,double> pos)
        {
            this.tagInfo = tagInfo;
            this.pos = pos;
        }
    }
}
