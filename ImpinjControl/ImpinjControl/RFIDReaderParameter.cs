using Org.LLRP.LTK.LLRPV1;
using Org.LLRP.LTK.LLRPV1.DataType;
using Org.LLRP.LTK.LLRPV1.Impinj;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImpinjControl
{
    public enum ReaderStatus
    {
        Ready,
        Connecting,
        Connected,
        Inventorying,
        TimedInventorying,
        Stop,
        Failed,
        Saved
    };

    public class RFIDReaderParameter
    {
        #region Reader parameter for one specific Reader-to-Tag Connection
        //Use the factory default LLRP configuration to ensure that the Reader is in a known state.
        public static bool Reset { get; set; } = true;
        //Address: Both IP Address and Hostname can be used to connect to the reader
        public static string IP { get; set; }        //Default IP will be stored in Properties,Settings.settings after each modification
        public static string MAC { get; set; }
        public static string Hostname { get; set; }

        public static string ReadMode { get; set; } = "Maunal";  //Decide to choose Manual Read Mode or Timer Read Mode
        public static uint Duration { get; set; } = 90000;   //Duration of Timer Read Mode
        #endregion

    }
}
