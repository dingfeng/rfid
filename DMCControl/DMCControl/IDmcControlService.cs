using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.ServiceModel;
namespace DMCControl
{
    [ServiceContract]
    public interface IDmcControlService
    {
        [OperationContract]
        void rotatingRun(double finalAngle, double speed);  //旋转运动
        [OperationContract]
        void horizontalRun(double finalPos, double speed);   //水平运动
        [OperationContract]
        void resetHorizontalPos();   //水平位置清零
        [OperationContract]
        void resetRotatingPos();     //旋转位置清零
        [OperationContract]
        float[] getCurrentPos(); //获得当前位置
        [OperationContract]
        void originPoint();          //原点回归
        [OperationContract]
        void emergencyStop();        //紧急停止
        [OperationContract]
        List<DMCPosDto> tryDequeue();  //获得一个位置信息
        [OperationContract]
        void shutdown(); //关闭导轨
        [OperationContract]
        void begin();//开启导轨
    }

    [DataContract]
    public class DMCPosDto
    {
        [DataMember]
        public float x { set; get; }
        [DataMember]
        public float y { set; get; }
        [DataMember]
        public ulong microSecond { set; get; }
        public DMCPosDto(float x, float y, long microSecond)
        {
            this.x = x;
            this.y = y;
            this.microSecond = (ulong)microSecond;
        }
    }
}
