using Org.LLRP.LTK.LLRPV1;
using Org.LLRP.LTK.LLRPV1.DataType;
using Org.LLRP.LTK.LLRPV1.Impinj;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RFIDIntegratedApplication.ServiceReference1;
namespace RFIDIntegratedApplication.Reader
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
        public static bool Reset { get; set; } = true;
        //Address: Both IP Address and Hostname can be used to connect to the reader
        public static string IP { get; set; }        //Default IP will be stored in Properties,Settings.settings after each modification
        public static string MAC { get; set; }
        public static string Hostname { get; set; }
        public static bool IsConnected { get; set; } = false;

        public static string ReadMode { get; set; } = "Manual";  //Decide to choose Manual Read Mode or Timer Read Mode
        public static uint Duration { get; set; } = 90000;     //Duration of Timer Read Mode

        //Tag Filter
        public static string Mask { get; set; } = String.Empty;
        public static string ExtraMask { get; set; } = String.Empty;

        public static ReaderCapabilities readerCapabilities;
        public static AntennaConfiguration antennaConfiguration;
        public static ROReportSpec rOReportSpec;
    }
}
