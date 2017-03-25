using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Org.LLRP.LTK.LLRPV1.DataType;
using Org.LLRP.LTK.LLRPV1;
using System.ServiceModel;
using System.Runtime.Serialization;
using Org.LLRP.LTK.LLRPV1.Impinj;
namespace ImpinjControl
{
    [ServiceContract]
    public interface IImpinjControlService
    {
        [OperationContract]
        ConnectResponse connect(string address); //连接读写器
        [OperationContract]
        void startInventory(AntennaConfiguration antennaConfiguration, ROReportSpec rOReportSpec);
        [OperationContract]
        void updateEpc(string oldEpc, string newEpc);  //修改epc
        [OperationContract]
        void stopInventory();
        [OperationContract]
        List<TagInfo> tryDeque();
        [OperationContract]
        void disconnect();
    }

    [DataContract]
    public class AntennaConfiguration
    {
        [DataMember]
        public ushort MaxNumberOfAntennaSupported { get; set; }
        [DataMember]
        public ushort NumberOfAntennaConnected { get; set; }
        [DataMember]
        public ushort[] AntennaID { get; set; }
        [DataMember]
        public bool[] AntennaConnected { get; set; }
        [DataMember]
        public ushort[] SelectedReceiverSensitivityIndex { get; set; }
        [DataMember]
        public short[] SelectedReceiverSensitivity { get; set; }
        [DataMember]
        public bool Hopping { get; set; }
        [DataMember]
        public ushort HopTableID { get; set; }
        [DataMember]
        public ushort HoppingStep { get; set; }
        [DataMember]
        public ushort ChannelIndex { get; set; }
        [DataMember]
        public double Frequency { get; set; }
        [DataMember]
        public ushort[] SelectedTransmiterPowerIndex { get; set; }
        [DataMember]
        public double[] SelectedTransmiterPower { get; set; }
        [DataMember]
        public bool TagInventoryStateAware { get; set; }
        [DataMember]
        public ushort ModeIndex { get; set; }
        [DataMember]
        public ushort Tari { get; set; }
        [DataMember]
        public ushort SelectedSessionIndex { get; set; }
        [DataMember]
        public string SelectedSession { get; set; }
        [DataMember]
        public ushort TagPopulation { get; set; }
        [DataMember]
        public ushort TagTransitTime { get; set; }
        [DataMember]
        public string SelectedSearchMode { get; set; }
        [DataMember]
        public string FixedFrequencyMode { get; set; }
        [DataMember]
        public UInt16Array FixedChannelList { get; set; }
        [DataMember]
        public UInt16Array FrequencyHopList { get; set; }
        [DataMember]
        public bool ReducedPowerFrequencyMode { get; set; }
        [DataMember]
        public UInt16Array ReducedPowerChannelList { get; set; }
        [DataMember]
        public bool LowDutyCycleMode { get; set; }
        [DataMember]
        public ushort EmptyFieldTimeout { get; set; }
        [DataMember]
        public ushort FieldPingInterval { get; set; }
        [DataMember]
        public string mask { get; set; } = String.Empty;
        [DataMember]
        public string extraMask { get; set; } = String.Empty;

        public void init(ReaderCapabilities readerCapabilities)
        {
            //Antenna Configuration
            this.Hopping = false;
            this.HopTableID = 0;
            this.HoppingStep = 0;
            this.ChannelIndex = 1;
            this.TagInventoryStateAware = false;
            this.ModeIndex = 1000;
            this.Tari = 0;
            this.SelectedSession = "Session 0";
            this.SelectedSessionIndex = 1;
            this.TagPopulation = 32;
            this.TagTransitTime = 0;
            this.SelectedSearchMode = "Dual_Target";
            this.FixedFrequencyMode = "Disabled";
            this.FixedChannelList = UInt16Array.FromString("");
            this.FrequencyHopList = UInt16Array.FromString("");
            this.ReducedPowerFrequencyMode = false;
            this.ReducedPowerChannelList = UInt16Array.FromString(string.Empty);
            this.LowDutyCycleMode = false;
            this.EmptyFieldTimeout = 2000;
            this.FieldPingInterval = 250;
            this.MaxNumberOfAntennaSupported = readerCapabilities.MaxNumberOfAntennaSupported;
            this.AntennaID =
                new ushort[readerCapabilities.MaxNumberOfAntennaSupported];
            this.AntennaConnected =
                new bool[readerCapabilities.MaxNumberOfAntennaSupported];
            this.SelectedReceiverSensitivity =
                new short[readerCapabilities.MaxNumberOfAntennaSupported];
            this.SelectedReceiverSensitivityIndex =
                new ushort[readerCapabilities.MaxNumberOfAntennaSupported];
            this.SelectedTransmiterPower =
                new double[readerCapabilities.MaxNumberOfAntennaSupported];
            this.SelectedTransmiterPowerIndex =
                new ushort[readerCapabilities.MaxNumberOfAntennaSupported];
            for (int i = 0; i < readerCapabilities.MaxNumberOfAntennaSupported; i++)
            {
                this.AntennaID[i] = (ushort)(i + 1);

                if (i == 0)
                    this.AntennaConnected[i] = true;
                else
                    this.AntennaConnected[i] = false;

                this.SelectedReceiverSensitivity[i] = -70;
                this.SelectedReceiverSensitivityIndex[i] =
                readerCapabilities.ReceiveSensitivityDic[-70];
                this.SelectedTransmiterPower[i] = 30;
                this.SelectedTransmiterPowerIndex[i] =
                readerCapabilities.TransmiterPowerDic[30];
            }
        }
    }

    [DataContract]
    public class ROReportSpec
    {
        public ROReportSpec()
        {
            this.SelectedROReportTrigger = "Upon_N_Tags_Or_End_Of_ROSpec";
            this.ROReportTriggerN = 1;
            this.EnableROSpecID = false;
            this.EnableSpecIndex = false;
            this.EnableInventoryParameterSPecID = false;
            this.EnableAntennaID = true;
            this.EnableChannelIndex = true;
            this.EnablePeakRSSI = true;
            this.EnableFirstSeenTimestamp = true;
            this.EnableLastSeenTimestamp = false;
            this.EnableTagSeenCount = true;
            this.EnableAccessSpecID = false;
            this.EnableCRC = false;
            this.EnablePCbits = false;
            this.ImpinJEnableSerializedTID = false;
            this.ImpinJEnableRFPhaseAngle = true;
            this.ImpinJEnablePeakRSSI = true;
            this.ImpinJEnableGPSCoordinates = false;
            this.ImpinJEnableOptimizedRead = false;
            this.ImpinJEnableRFDopplerFrequency = true;
        }
        [DataMember]
        public string SelectedROReportTrigger { get; set; }
        [DataMember]
        public ushort ROReportTriggerN { get; set; }
        [DataMember]
        public bool EnableROSpecID { get; set; }
        [DataMember]
        public bool EnableSpecIndex { get; set; }
        [DataMember]
        public bool EnableInventoryParameterSPecID { get; set; }
        [DataMember]
        public bool EnableAntennaID { get; set; }
        [DataMember]
        public bool EnableChannelIndex { get; set; }
        [DataMember]
        public bool EnablePeakRSSI { get; set; }
        [DataMember]
        public bool EnableFirstSeenTimestamp { get; set; }
        [DataMember]
        public bool EnableLastSeenTimestamp { get; set; }
        [DataMember]
        public bool EnableTagSeenCount { get; set; }
        [DataMember]
        public bool EnableAccessSpecID { get; set; }
        [DataMember]
        public bool EnableCRC { get; set; }
        [DataMember]
        public bool EnablePCbits { get; set; }
        [DataMember]
        public bool ImpinJEnableSerializedTID { get; set; }
        [DataMember]
        public bool ImpinJEnableRFPhaseAngle { get; set; }
        [DataMember]
        public bool ImpinJEnablePeakRSSI { get; set; }
        [DataMember]
        public bool ImpinJEnableGPSCoordinates { get; set; }
        [DataMember]
        public bool ImpinJEnableOptimizedRead { get; set; }
        [DataMember]
        public bool ImpinJEnableRFDopplerFrequency { get; set; }
    }

    [DataContract]
    public class TagInfo
    {
        [DataMember]
        public string EPC { get; set; }
        [DataMember]
        public ulong FirstSeenTime { get; set; }   //The time of the first tag read for the EPC conveyed in this tag report
        [DataMember]
        public ulong LastSeenTime { get; set; }    //The time of the last tag read for the EPC conveyed in this tag report
        [DataMember]
        public ulong TimeStamp { get; set; }       //The time between first tag read and this tag read conveyed in each round
        [DataMember]
        public ushort Antenna { get; set; }
        [DataMember]
        public double TxPower { get; set; }
        [DataMember]
        public ushort ChannelIndex { get; set; }
        [DataMember]
        public int Frequency { get; set; }         // in units of Hz
        [DataMember]
        public double RSSI { get; set; }
        [DataMember]
        public ushort RawPhase { get; set; }             //Phase value without handling
        [DataMember]
        public double AcutalPhaseInRadian { get; set; }  //AcutalPhaseInRadian = 2*pi-2*pi*RawPhase/4096  Actual Phase value in the form of Radian
        [DataMember]
        public int DopplerShift { get; set; }
        [DataMember]
        public double Velocity { get; set; }
        [DataMember]
        public int TagSeenCount { get; set; }       //The number of tag reads of this EPC conveyed in this tag report
        [DataMember]
        public int TotalTagCount { get; set; }     //The number of total tag reports
    }

    [DataContract]
    public class ReaderCapabilities
    {
        public ReaderCapabilities()
        {
            this.PreDefinedModeTable = new Dictionary<string, ushort>();
            this.PreDefinedModeTable.Add("Max Throughput", 0);         //Not supported on R220
            this.PreDefinedModeTable.Add("Hybrid Mode (M=2)", 1);      //Also called High throughput (M=2), Not supported on R220
            this.PreDefinedModeTable.Add("Dense Reader (M=4)", 2);
            this.PreDefinedModeTable.Add("Dense Reader (M=8)", 3);
            this.PreDefinedModeTable.Add("Max Miller(M=4)", 4);        //Also called High throughput (M=4), Not supported by regions that support mode 5.ETSI, China, India, Japan, Korea, and South Africa, Not supported on R220
            this.PreDefinedModeTable.Add("Dense Reader 2 (M=4)", 5);   //Faster forward link than mode 2 Only available with regions: ETSI, China, India, Japan, Korea, and South Africa.
            this.PreDefinedModeTable.Add("AutoSet", 1000);
            this.PreDefinedModeTable.Add("AutoSet Static", 1002);      //Not supported on R220
            this.PreDefinedModeTable.Add("AutoSet Static Fast", 1003); //Not supported on R220
            this.PreDefinedModeTable.Add("AutoSet Static DRM", 1004);  //Not supported on R220
            this.Sessions = new Dictionary<string, ushort>();
            this.Sessions.Add("Session 0", 1);
            this.Sessions.Add("Session 1", 2);
            this.Sessions.Add("Session 2", 3);
            this.Sessions.Add("Session 3", 4);
        }
        [DataMember]
        public  ushort MaxNumberOfAntennaSupported { get; set; }
        [DataMember]
        public Dictionary<string, ushort> PreDefinedModeTable { get; set; }
        [DataMember]
        public ushort[] SupportedModeIndex { get; set; }
        [DataMember]
        public Dictionary<string, ushort> Sessions { get; set; }
        [DataMember]
        public string[] SearchModeTable
        {
            get
            {
                return Enum.GetNames(typeof(ENUM_ImpinjInventorySearchType));
            }
        }
        [DataMember]
        public Dictionary<short, ushort> ReceiveSensitivityDic { get; set; }
        [DataMember]
        public Dictionary<ushort, double> FrequencyDic { get; set; }
        [DataMember]
        public string[] FixedFrequencyModeTable
        {
            get
            {
                return Enum.GetNames(typeof(ENUM_ImpinjFixedFrequencyMode)); ;
            }
        }
        [DataMember]
        public Dictionary<double, ushort> TransmiterPowerDic { get; set; }
        [DataMember]
        public string[] ROReportTrigger
        {
            get
            {
                return Enum.GetNames(typeof(ENUM_ROReportTriggerType));
            }
        }
    }

    [DataContract]
    public class ConnectResponse
    {
        [DataMember]
        public   AntennaConfiguration antennaConfiguration;
        [DataMember]
        public  ReaderCapabilities readerCapabilities;
        [DataMember]
        public ROReportSpec rOReportSpec;
        public ConnectResponse(AntennaConfiguration antennaConfiguration, ReaderCapabilities readerCapabilities, ROReportSpec rOReportSpec)
        {
            this.antennaConfiguration = antennaConfiguration;
            this.readerCapabilities = readerCapabilities;
            this.rOReportSpec = rOReportSpec;
        }
    }
}
