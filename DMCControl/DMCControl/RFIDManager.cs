using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
namespace DMCControl
{
   public  class RFIDManager
    {
        //启动
        public static void begin()
        {
            //标记为启动状态
            RFIDMove.started = true;
            short tmp =  RFIDMove.initBoard();
            if (tmp == -1)
            {
                //没有检测到控制卡
                Console.WriteLine("没有检测到控制卡！");
            }
            else
            {
                Thread moveEventThread = new Thread(new ThreadStart(RFIDMove.moveEventHandle));
                moveEventThread.Name = "move event handle";
                moveEventThread.Start();
                Thread checkInputThread = new Thread(new ThreadStart(RFIDMove.checkInputStatus));
                checkInputThread.Name = "check input status";
                checkInputThread.Start();
            }
        }
        //停止
        public static void shutdown()
        {
            //标记为停止状态 Move.moveEventHandle与Move.checkInputStatus中的循环将停止
            RFIDMove.started = false;
            RFIDMove.closeBoard();
        }


    }
}
