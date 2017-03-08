using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using System.Runtime.Serialization;
namespace CalculateApp
{
    [ServiceContract]
    public  interface  ICalculateService
    {
        [OperationContract]
        void init(string epc,ConfParam confParam);
        [OperationContract]
        void calculate(string epc,double antX, double antY, double Z, int freq, double measuredPhase);
        [OperationContract]
        void clear(string epc);
        [OperationContract]
        void clearAll();
    }

    [DataContract]
    public class ConfParam
    {
        [DataMember]
        public string epc;   //标签编号
        [DataMember]
        public int xStart;
        [DataMember]
        public int xEnd;
        [DataMember]
        public double xInterval;
        [DataMember]
        public int yStart;
        [DataMember]
        public int yEnd;
        [DataMember]
        public double yInterval;
        [DataMember]
        public int zStart;
        [DataMember]
        public int zEnd;
        [DataMember]
        public double zInterval;
        public ConfParam(int xStart, int xEnd, double xInterval, int yStart, int yEnd, double yInterval, int zStart,int zEnd, double zInterval)
        {
            this.xStart = xStart;
            this.xEnd = xEnd;
            this.xInterval = xInterval;
            this.yStart = yStart;
            this.yEnd = yEnd;
            this.yInterval = yInterval;
            this.zStart = zStart;
            this.zEnd = zEnd;
            this.zInterval = zInterval;
        }
    }

    [DataContract]
    public class PhaseParam
    {
        [DataMember]
        public double antX { get; set; }
        [DataMember]
        public double antY { get; set; }
        [DataMember]
        public double antZ { get; set; }
        [DataMember]
        public int freq { get; set; }
    }

}
