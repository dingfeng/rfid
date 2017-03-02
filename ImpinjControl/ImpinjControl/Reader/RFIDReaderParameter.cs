using Org.LLRP.LTK.LLRPV1;
using Org.LLRP.LTK.LLRPV1.DataType;
using Org.LLRP.LTK.LLRPV1.Impinj;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        #region Reader parameter for one specific Reader-to-Tag Connection
        //Use the factory default LLRP configuration to ensure that the Reader is in a known state.
        public static bool Reset { get; set; }
        //Address: Both IP Address and Hostname can be used to connect to the reader
        public static string IP { get; set; }        //Default IP will be stored in Properties,Settings.settings after each modification
        public static string MAC { get; set; }
        public static string Hostname { get; set; }
        public static bool IsConnected { get; set; }

        public static string ReadMode { get; set; }  //Decide to choose Manual Read Mode or Timer Read Mode
        public static uint Duration { get; set; }     //Duration of Timer Read Mode

        //Tag Filter
        public static string Mask { get; set; }
        public static string ExtraMask { get; set; }

        //Per-Antenna Configuration
        //The following parameters must be configured the same for all enabled antennas in a particular AISpec or an error will be returned.
        //• C1G2RFControl parameter
        //– ModeIndex must be configured the same.
        //• RFTransmitter parameter
        //– HopTableID must be configured the same.
        //– ChannelIndex must be configured the same.
        //• C1G2Filter parameter
        //– All fields and sub-parameters must be configured the same.
        //• C1G2SingulationControl parameter
        //– Session must be configured the same.
        //– TagPopulation must be configured the same.
        //– TagTransitTime must be configured the same.
        internal class AntennaConfiguration
        {
            public static ushort MaxNumberOfAntennaSupported { get; set; }
            public static ushort NumberOfAntennaConnected { get; set; }
            public static ushort[] AntennaID { get; set; }
            public static bool[] AntennaConnected { get; set; }

            //------RF Receiver------
            public static ushort[] SelectedReceiverSensitivityIndex { get; set; }
            public static short[] SelectedReceiverSensitivity { get; set; }
            //------RF Receiver------

            //------RF Transmiter------
            public static bool Hopping { get; set; }
            //used when operating in frequency-hopping regulatory regions; otherwise, ignored 
            public static ushort HopTableID { get; set; }
            public static ushort HoppingStep { get; set; }
            //used when operating in non-frequency-hopping regulatory regions; otherwise, ignored 
            public static ushort ChannelIndex { get; set; }
            public static double Frequency { get; set; }
            //set the transmit power independently for each of the four antenna ports.
            public static ushort[] SelectedTransmiterPowerIndex { get; set; }
            public static double[] SelectedTransmiterPower { get; set; }
            //------RF Transmiter------

            //------C1G2 Inventory Command------
            //determine how to process all the C1G2Filter and C1G2Singulation parameters in this command.
            //read standard.pdf
            public static bool TagInventoryStateAware { get; set; }

            //---C1G2 RF Control---
            public static ushort ModeIndex { get; set; }
            //No Tari adjustment is necessary.Tari values passed by the client will be ignored.??
            public static ushort Tari { get; set; }

            //---C1G2 Singulation Control---
            public static ushort SelectedSessionIndex { get; set; }
            public static string SelectedSession { get; set; }
            //An estimate of the tag population in view of the RF field of the antenna.
            public static ushort TagPopulation { get; set; }
            //An estimate of the time a tag will typically remain in the RF field of the antenna specified in milliseconds.
            public static ushort TagTransitTime { get; set; }
            //------C1G2 Inventory Command------

            //------Impinj------
            //Impinj Inventory Search Mode 
            public static string SelectedSearchMode { get; set; }

            //---Impinj Fixed Frequency Mode---
            //Allows the client to control and configure automatic frequency selection for 
            //regulatory regions with fixed frequency operation.
            public static string FixedFrequencyMode { get; set; }
            public static UInt16Array FixedChannelList { get; set; }
            public static UInt16Array FrequencyHopList { get; set; }   

            //---Impinj Reduced Power Frequency List---
            //Provides Reduced Power operation level configurability on certain channels within 
            //the FCC regulatory region.
            public static bool ReducedPowerFrequencyMode { get; set; }
            public static UInt16Array ReducedPowerChannelList { get; set; }

            //---ImpinjLowDutyCycle---
            //LDC enables the reader to go into a low power and low transmit mode when tags are not visible 
            //in the antenna field of view. The reader then “pings” for tags at a set interval dramatically 
            //reducing power consumption and unnecessary transmissions. When its “ping” sees a tag in the 
            //field, the reader will automatically exit LDC and begin reading tags.
            public static bool LowDutyCycleMode { get; set; }
            public static ushort EmptyFieldTimeout { get; set; }
            public static ushort FieldPingInterval { get; set; }
            //------Impinj------
        }

        internal class ROReportSpec
        {
            //The ROReportTrigger within ROReportSpec selects when the Reader will automatically generate reports.
            public static string SelectedROReportTrigger { get; set; }
            public static ushort ROReportTriggerN { get; set; }

            //------Tag Report Content Selector------
            //This parameter is used to configure the contents that are of interest in TagReportData. 
            //If enabled, the field is reported along with the tag data in the TagReportData.
            public static bool EnableROSpecID { get; set; }
            public static bool EnableSpecIndex { get; set; }
            public static bool EnableInventoryParameterSPecID { get; set; }
            public static bool EnableAntennaID { get; set; }
            public static bool EnableChannelIndex { get; set; }
            public static bool EnablePeakRSSI { get; set; }
            public static bool EnableFirstSeenTimestamp { get; set; }
            public static bool EnableLastSeenTimestamp { get; set; }
            public static bool EnableTagSeenCount { get; set; }
            public static bool EnableAccessSpecID { get; set; }
            public static bool EnableCRC { get; set; }
            public static bool EnablePCbits { get; set; }

            //------ImpinJ Tag Report Content Selector------
            public static bool ImpinJEnableSerializedTID { get; set; }
            public static bool ImpinJEnableRFPhaseAngle { get; set; }
            public static bool ImpinJEnablePeakRSSI { get; set; }
            public static bool ImpinJEnableGPSCoordinates { get; set; }
            public static bool ImpinJEnableOptimizedRead { get; set; }
            public static bool ImpinJEnableRFDopplerFrequency { get; set; }
            //------ImpinJ Tag Report Content Selector------

        }
        #endregion

        #region Reader parameter for one specific reader
        internal class ReaderCapabilities
        {
            //Different readers suppoert different modes. Select according mode from predefined mode table
            //A couple of things it is important to note regarding reader mode settings:
            //1. Not all modes are available on all models or in all regions.
            //2. As a rule, there is an inverse relationship between data rate and sensitivity/interference 
            //   tolerance. Higher data rates generate, and are more susceptible to, interference whereas 
            //   lower data rates cause less interference and are more tolerant of it.
            public static Dictionary<string, ushort> PreDefinedModeTable { get; set; }
            public static ushort[] SupportedModeIndex { get; set; }

            //The EPC GEN 2 standard allows for up to four sessions; 
            //these sessions serve two purposes:
            //1) Determines how often a tag will respond to a query from the reader
            //2) Allows for multiple readers to conduct independent inventories
            //The RFID reader will select which session is to be used, 
            //each session's inventory flag can be independently set to 'A' or 'B' 
            public static Dictionary<string, ushort> Sessions { get; set; }

            //There are three search modes available on the Impinj Speedway Revolution reader:
            //1) Dual Target
            //   The reader reads all ‘A’ tags then moves all ‘A’ tags into ‘B’. Reader then reads all ‘B’ tags then moves all ‘B’ tags into ‘A’ and so on…
            //   Generates many reads and is good for small populations or static environments (i.e.smart shelf).
            //2) Single Target 
            //    the reader reads all ‘A’ tags then moves all ‘A’ tags into ‘B’ and allows tags to stay quiet once they are inventoried. 
            //    This mode is good for high population, dynamic environments (i.e. dock door portal).
            //3) Single Target with Suppression. 

            public static string[] SearchModeTable
            {
                get
                {
                    return Enum.GetNames(typeof(ENUM_ImpinjInventorySearchType));
                }
            }

            //The Speedway Reader references the RSSI sensitivity levels to an absolute sensitivity of -80 dBm.
            //In order to set a receive sensitivity level of -47 dBm, the user must identify the ReceiveSensitivityTableEntry
            //parameter within the GeneralDeviceCapabilities such that:
            //                      -80 dBm + ReceiveSensitivityValue = -47 dBm
            //In this case, the ReceiveSensitivityValue is calculated to be 33, which corresponds to Index 25 in
            //the Octane 5.8.0 LLRP capabilities.
            //Index 1   ReceiveSensitivityValue  0  the lowest, most sensitive setting (Default Setting)
            //Index 42  ReceiveSensitivityValue  50  the highest, least sensitive setting
            public static Dictionary<short, ushort> ReceiveSensitivityDic { get; set; }


            //Store all the available Frequency value for the reader after retrieving capabilities
            //ImpinJ R420: Available Frequency(MHz) [920.625:0.25:924.375], 16 different values in total
            public static Dictionary<ushort, double> FrequencyDic { get; set; }

            //The FixedFrequencyMode field determines how the Reader will select the active channel:
            // 1) 0 (disabled)
            //    The Reader ignores this parameter and instead uses the frequency information in the LLRP RFTransmitter parameter.
            // 2) 1 (Auto_Select)
            //    The Reader chooses the active channel automatically , based on the rules of the regulatory region.
            // 3) 2 (Channel_List)
            //    The Reader chooses the active channel from a configurable list of channel indices based on the ImpinjFrequencyCapabilities parameter advertised in the Reader’s capabilities.
            public static string[] FixedFrequencyModeTable
            {
                get
                {
                    return Enum.GetNames(typeof(ENUM_ImpinjFixedFrequencyMode)); ;
                }
            }

            //Store all the available Transmit Powers for the reader after retrieving capabilities
            //ImpinJ R420: Available Power(dbm) [10 : 0.25 : 32.5], 90 different values in total
            //An index setting of ‘1’ = TransmitPowerValue of 1000 or +10.00 dBm (the lowest transmit power on the 
            //Revolution reader). Each step in the index table increases the transmit power value by 0.25dB up to 
            //he max power of 32.5dBm (= index ‘91’) if using external power supply.
            //NOTE: Max power when using Power over Ethernet (PoE) is +30dBm (index of 81).
            public static Dictionary<double, ushort> TransmiterPowerDic { get; set; }

            //The ROReportTrigger within ROReportSpec selects when the Reader will automatically generate reports.
            //1) None = 0,   polls for reports every few seconds.
            //2) Upon_N_Tags_Or_End_Of_AISpec = 1,   Upon N TagReportData Parameters or End of AISpec
            //3) Upon_N_Tags_Or_End_Of_ROSpec = 2    Upon N TagReportData Parameters or End of ROSpec
            public static string[] ROReportTrigger
            {
                get
                {
                    return Enum.GetNames(typeof(ENUM_ROReportTriggerType));
                }
            }
        }
        #endregion

        public RFIDReaderParameter()
        {
            //------Initialize capabilities------
            // Predefine mode indentifier and official name by ImpinJ_Octane_LLRP.pdf
            RFIDReaderParameter.ReaderCapabilities.PreDefinedModeTable = new Dictionary<string, ushort>();
            RFIDReaderParameter.ReaderCapabilities.PreDefinedModeTable.Add("Max Throughput", 0);         //Not supported on R220
            RFIDReaderParameter.ReaderCapabilities.PreDefinedModeTable.Add("Hybrid Mode (M=2)", 1);      //Also called High throughput (M=2), Not supported on R220
            RFIDReaderParameter.ReaderCapabilities.PreDefinedModeTable.Add("Dense Reader (M=4)", 2);
            RFIDReaderParameter.ReaderCapabilities.PreDefinedModeTable.Add("Dense Reader (M=8)", 3);
            RFIDReaderParameter.ReaderCapabilities.PreDefinedModeTable.Add("Max Miller(M=4)", 4);        //Also called High throughput (M=4), Not supported by regions that support mode 5.ETSI, China, India, Japan, Korea, and South Africa, Not supported on R220
            RFIDReaderParameter.ReaderCapabilities.PreDefinedModeTable.Add("Dense Reader 2 (M=4)", 5);   //Faster forward link than mode 2 Only available with regions: ETSI, China, India, Japan, Korea, and South Africa.
            RFIDReaderParameter.ReaderCapabilities.PreDefinedModeTable.Add("AutoSet", 1000);
            RFIDReaderParameter.ReaderCapabilities.PreDefinedModeTable.Add("AutoSet Static", 1002);      //Not supported on R220
            RFIDReaderParameter.ReaderCapabilities.PreDefinedModeTable.Add("AutoSet Static Fast", 1003); //Not supported on R220
            RFIDReaderParameter.ReaderCapabilities.PreDefinedModeTable.Add("AutoSet Static DRM", 1004);  //Not supported on R220

            RFIDReaderParameter.ReaderCapabilities.Sessions = new Dictionary<string, ushort>();
            RFIDReaderParameter.ReaderCapabilities.Sessions.Add("Session 0", 1);
            RFIDReaderParameter.ReaderCapabilities.Sessions.Add("Session 1", 2);
            RFIDReaderParameter.ReaderCapabilities.Sessions.Add("Session 2", 3);
            RFIDReaderParameter.ReaderCapabilities.Sessions.Add("Session 3", 4);
            //------Initialize capabilities------



            //------Set Default value------
            RFIDReaderParameter.Reset = true;
            RFIDReaderParameter.IsConnected = false;

            RFIDReaderParameter.ReadMode = "Maunal";
            RFIDReaderParameter.Duration = 90000;

            RFIDReaderParameter.Mask = String.Empty;
            RFIDReaderParameter.ExtraMask = String.Empty;

            //Antenna Configuration
            RFIDReaderParameter.AntennaConfiguration.Hopping = false;
            RFIDReaderParameter.AntennaConfiguration.HopTableID = 0;
            RFIDReaderParameter.AntennaConfiguration.HoppingStep = 0;
            RFIDReaderParameter.AntennaConfiguration.ChannelIndex = 1;
            RFIDReaderParameter.AntennaConfiguration.TagInventoryStateAware = false;
            RFIDReaderParameter.AntennaConfiguration.ModeIndex = 1000;
            RFIDReaderParameter.AntennaConfiguration.Tari = 0;
            RFIDReaderParameter.AntennaConfiguration.SelectedSession = "Session 0";
            RFIDReaderParameter.AntennaConfiguration.SelectedSessionIndex = 1;
            RFIDReaderParameter.AntennaConfiguration.TagPopulation = 32;
            RFIDReaderParameter.AntennaConfiguration.TagTransitTime = 0;
            RFIDReaderParameter.AntennaConfiguration.SelectedSearchMode = "Dual_Target";
            RFIDReaderParameter.AntennaConfiguration.FixedFrequencyMode = "Disabled";
            RFIDReaderParameter.AntennaConfiguration.FixedChannelList = UInt16Array.FromString("");
            RFIDReaderParameter.AntennaConfiguration.FrequencyHopList = UInt16Array.FromString("");
            RFIDReaderParameter.AntennaConfiguration.ReducedPowerFrequencyMode = false;
            RFIDReaderParameter.AntennaConfiguration.ReducedPowerChannelList = UInt16Array.FromString(string.Empty);
            RFIDReaderParameter.AntennaConfiguration.LowDutyCycleMode = false;
            RFIDReaderParameter.AntennaConfiguration.EmptyFieldTimeout = 2000;
            RFIDReaderParameter.AntennaConfiguration.FieldPingInterval = 250;

            RFIDReaderParameter.AntennaConfiguration.AntennaID =
                new ushort[RFIDReaderParameter.AntennaConfiguration.MaxNumberOfAntennaSupported];
            RFIDReaderParameter.AntennaConfiguration.AntennaConnected =
                new bool[RFIDReaderParameter.AntennaConfiguration.MaxNumberOfAntennaSupported];
            RFIDReaderParameter.AntennaConfiguration.SelectedReceiverSensitivity =
                new short[RFIDReaderParameter.AntennaConfiguration.MaxNumberOfAntennaSupported];
            RFIDReaderParameter.AntennaConfiguration.SelectedReceiverSensitivityIndex =
                new ushort[RFIDReaderParameter.AntennaConfiguration.MaxNumberOfAntennaSupported];
            RFIDReaderParameter.AntennaConfiguration.SelectedTransmiterPower =
                new double[RFIDReaderParameter.AntennaConfiguration.MaxNumberOfAntennaSupported];
            RFIDReaderParameter.AntennaConfiguration.SelectedTransmiterPowerIndex =
                new ushort[RFIDReaderParameter.AntennaConfiguration.MaxNumberOfAntennaSupported];

            for (int i = 0; i < RFIDReaderParameter.AntennaConfiguration.MaxNumberOfAntennaSupported; i++)
            {
                RFIDReaderParameter.AntennaConfiguration.AntennaID[i] = (ushort)(i + 1);

                if (i == 0)
                    RFIDReaderParameter.AntennaConfiguration.AntennaConnected[i] = true;
                else
                    RFIDReaderParameter.AntennaConfiguration.AntennaConnected[i] = false;

                RFIDReaderParameter.AntennaConfiguration.SelectedReceiverSensitivity[i] = -70;
                RFIDReaderParameter.AntennaConfiguration.SelectedReceiverSensitivityIndex[i] =
                    RFIDReaderParameter.ReaderCapabilities.ReceiveSensitivityDic[-70];
                RFIDReaderParameter.AntennaConfiguration.SelectedTransmiterPower[i] = 30;
                RFIDReaderParameter.AntennaConfiguration.SelectedTransmiterPowerIndex[i] =
                    RFIDReaderParameter.ReaderCapabilities.TransmiterPowerDic[30];
            }

            RFIDReaderParameter.ROReportSpec.SelectedROReportTrigger = "Upon_N_Tags_Or_End_Of_ROSpec";
            RFIDReaderParameter.ROReportSpec.ROReportTriggerN = 1;
            RFIDReaderParameter.ROReportSpec.EnableROSpecID = false;
            RFIDReaderParameter.ROReportSpec.EnableSpecIndex = false;
            RFIDReaderParameter.ROReportSpec.EnableInventoryParameterSPecID = false;
            RFIDReaderParameter.ROReportSpec.EnableAntennaID = true;
            RFIDReaderParameter.ROReportSpec.EnableChannelIndex = true;
            RFIDReaderParameter.ROReportSpec.EnablePeakRSSI = true;
            RFIDReaderParameter.ROReportSpec.EnableFirstSeenTimestamp = true;
            RFIDReaderParameter.ROReportSpec.EnableLastSeenTimestamp = false;
            RFIDReaderParameter.ROReportSpec.EnableTagSeenCount = true;
            RFIDReaderParameter.ROReportSpec.EnableAccessSpecID = false;
            RFIDReaderParameter.ROReportSpec.EnableCRC = false;
            RFIDReaderParameter.ROReportSpec.EnablePCbits = false;

            RFIDReaderParameter.ROReportSpec.ImpinJEnableSerializedTID = false;
            RFIDReaderParameter.ROReportSpec.ImpinJEnableRFPhaseAngle = true;
            RFIDReaderParameter.ROReportSpec.ImpinJEnablePeakRSSI = true;
            RFIDReaderParameter.ROReportSpec.ImpinJEnableGPSCoordinates = false;
            RFIDReaderParameter.ROReportSpec.ImpinJEnableOptimizedRead = false;
            RFIDReaderParameter.ROReportSpec.ImpinJEnableRFDopplerFrequency = true;
            //------Set Default value------
        }
    }
}
