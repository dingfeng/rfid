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
    public  interface  CalculateService
    {
        [OperationContract]
        void init(PhaseParam phaseParam);
        [OperationContract]
        void clear();
    }

    [DataContract]
    public enum AlgorithmType: byte
    {
        ORIGIN_SAR,TAGORAM
    }

    [DataContract]
    public class PhaseParam
    {
        [DataMember]
        public int x { get; set; }
        [DataMember]
        public int y { get; set; }
        [DataMember]
        public int z { get; set; }
        [DataMember]
        public AlgorithmType algorithmType { get; set; }
    }

}
