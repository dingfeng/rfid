using Org.LLRP.LTK.LLRPV1;
using Org.LLRP.LTK.LLRPV1.DataType;
using Org.LLRP.LTK.LLRPV1.Impinj;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Concurrent;
/* Application Flow:
 * 1. Initialize the Library.
 * 2. Connect to the Reader.
 * 3. Enable Impinj Extensions.
 * 4. Use the factory default LLRP configuration to ensure that the Reader is in a known state.
 * 5. GET_READER_CAPABILITIES to learn the maximum power that is supported by this Reader.
 * 6. GET_READER_CONFIG to get the hopTableID and channelIndex for use later when you set the RFTransmitter parameter.
 * 7. SET_READER_CONFIG with the appropriate InventorySearchMode, TagDirection, LowDutyCycleMode, RFTransmitter, and AutoSet values.
 * 8. ADD_ROSPEC to tell the Reader to perform an inventory.
 * 9. ENABLE_ROSPEC
 * 10. START_ROSPEC starts the inventory operation.
 * 11. Process RFID Data (EPC, RSSI, Timestamp) and direction data.
 * Reference:
 * Impinj_LTK_Programmers_Guide.pdf almost includes all the information we need
 * 1) How to setup the "Hello World" LLRP application in C#:
 *    https://support.impinj.com/hc/en-us/articles/202756168-Hello-LLRP-Low-Level-Reader-Protocol
 * 2) How to enable Impinj custom extensions to LLRP:
 *    https://support.impinj.com/hc/en-us/articles/202756348-Get-Low-Level-Reader-Data-with-LLRP
 * 3) UHF Gen2 filters allow you to specify which tags should respond in an inventor:
 *    https://support.impinj.com/hc/en-us/articles/202756568-EPC-Gen2-Tag-Filtering
 * 4) EPC Gen2 Search Modes and Sessions
 *    https://support.impinj.com/hc/en-us/articles/202756158-Understanding-EPC-Gen2-Search-Modes-and-Sessions
 * 5) Optimizing Tag Throughput Using Reader Mode
 *    https://support.impinj.com/hc/en-us/articles/202756368-Optimizing-Tag-Throughput-Using-ReaderMode
 * 6) Maintaining RFID Performance while Reducing RF-Emissions
 *    https://support.impinj.com/hc/en-us/articles/202756118-Maintaining-RFID-Performance-while-Reducing-RF-Emissions-VIDEO-
 * 7) EPC Gen2 Tag Filtering
 *    https://support.impinj.com/hc/en-us/articles/202756568-EPC-Gen2-Tag-Filtering
 *    llrp_1_1-standard-20101013.pdf
 */


namespace ImpinjControl
{
    public class ReaderSettings
    {
        LLRPClient _reader;        //Receive the LLRPClient instance created from _mainForm
        public   AntennaConfiguration antennaConfiguration;
        public   ROReportSpec rOReportSpec;
        public   ReaderCapabilities readerCapabilities;
        public  int TotalTagCount { get; set; }
        public ConcurrentQueue<TagInfo> tagInfoQueue = new ConcurrentQueue<TagInfo>();

        public void clearTagInfoQueue()
        {
            tagInfoQueue = new ConcurrentQueue<TagInfo>();
        }
        public ReaderSettings(LLRPClient r)
        {
            this._reader = r;

            TotalTagCount = 0;
        }

        #region  Get Settings
        /// <summary>
        /// Get Reader capbilities to set TransmitPower and Frequency
        /// </summary>
        public ReaderCapabilities GetReaderCapabilities()
        {
            ReaderCapabilities readerCapabilities = new ReaderCapabilities();
            Console.WriteLine("Getting reader capabilities...");

            MSG_GET_READER_CAPABILITIES_RESPONSE capabilities = null;
            MSG_GET_READER_CAPABILITIES cap_msg = new MSG_GET_READER_CAPABILITIES();
            cap_msg.RequestedData = ENUM_GetReaderCapabilitiesRequestedData.All;

            //Send the custom message and wait for 8 seconds
            MSG_ERROR_MESSAGE err_msg;
            capabilities = _reader.GET_READER_CAPABILITIES(cap_msg, out err_msg, 8000);
            if (capabilities != null)
            {
                Console.WriteLine(capabilities.LLRPStatus.StatusCode.ToString());
                if (capabilities.LLRPStatus.StatusCode != ENUM_StatusCode.M_Success)
                {
                    capabilities = null;
                    _reader.Close();
                    return null;
                }
            }
            else if (err_msg != null)
            {
                Console.WriteLine(err_msg.ToString());
                _reader.Close();
                return null;
            }
            else
            {
                Console.WriteLine("GET reader Capabilities Command Timed out!");
                _reader.Close();
                return null;
            }

            //Initialize some capabilities
            //Get the reader Available Frequency List to Initialize Mainform
            readerCapabilities.MaxNumberOfAntennaSupported =
                capabilities.GeneralDeviceCapabilities.MaxNumberOfAntennaSupported;

           
            uint[] availableFrequencyList = capabilities
                                            .RegulatoryCapabilities
                                            .UHFBandCapabilities
                                            .FrequencyInformation
                                            .FixedFrequencyTable
                                            .Frequency
                                            .data.ToArray();
            readerCapabilities.FrequencyDic = new Dictionary<ushort, double>();
            for (int i = 0; i < availableFrequencyList.Length; i++)
            {
                readerCapabilities.FrequencyDic.Add((ushort)(i + 1), availableFrequencyList[i] / 1000.0);
            }

            //Get the reader Available Transmit Power List to Initialize Mainform
            PARAM_TransmitPowerLevelTableEntry[] powerEntries = capabilities
                                                                .RegulatoryCapabilities
                                                                .UHFBandCapabilities
                                                                .TransmitPowerLevelTableEntry;
            readerCapabilities.TransmiterPowerDic = new Dictionary<double, ushort>();
            for (int i = 0; i < powerEntries.Length; i++)
            {
                readerCapabilities.TransmiterPowerDic.Add(powerEntries[i].TransmitPowerValue / 100.0, powerEntries[i].Index);
            }

            //Get supported mode of the reader
            PARAM_C1G2UHFRFModeTable modeTable = (PARAM_C1G2UHFRFModeTable)capabilities
                                                                           .RegulatoryCapabilities
                                                                           .UHFBandCapabilities
                                                                           .AirProtocolUHFRFModeTable[0];

            readerCapabilities.SupportedModeIndex = new ushort[modeTable.C1G2UHFRFModeTableEntry.Length];
            for (int i = 0; i < modeTable.C1G2UHFRFModeTableEntry.Length; i++)
            {
                readerCapabilities.SupportedModeIndex[i] = (ushort)modeTable.C1G2UHFRFModeTableEntry[i].ModeIdentifier;
            }

            ////Get Receive Sensitivity table of the reader
            PARAM_ReceiveSensitivityTableEntry[] sensitivityEntries = capabilities
                                                                      .GeneralDeviceCapabilities
                                                                      .ReceiveSensitivityTableEntry;
            readerCapabilities.ReceiveSensitivityDic = new Dictionary<short, ushort>();
            for (int i = 0; i < sensitivityEntries.Length; i++)
            {
                readerCapabilities.ReceiveSensitivityDic.Add((short)(sensitivityEntries[i].ReceiveSensitivityValue - 80), sensitivityEntries[i].Index);
            }
            this.readerCapabilities = readerCapabilities;
            return readerCapabilities;
        }

        /// <summary>
        /// Get reader configuration from the reader to get current configuration from reader.
        /// </summary>
        /// <returns></returns>
        public MSG_GET_READER_CONFIG_RESPONSE GetReaderConfigFromReader()
        {
            Console.WriteLine("Getting reader configuration from reader...");

            MSG_GET_READER_CONFIG cfg_msg = new MSG_GET_READER_CONFIG();
            cfg_msg.RequestedData = ENUM_GetReaderConfigRequestedData.All;

            MSG_ERROR_MESSAGE err_msg;
            MSG_GET_READER_CONFIG_RESPONSE rsp_msg = _reader.GET_READER_CONFIG(cfg_msg, out err_msg, 8000);

            StringBuilder builder = new StringBuilder();

            if (rsp_msg != null)
            {
                Console.WriteLine(rsp_msg.LLRPStatus.StatusCode.ToString());
                if (rsp_msg.LLRPStatus.StatusCode != ENUM_StatusCode.M_Success)
                {
                    _reader.Close();
                    return null;
                }

            }
            else if (err_msg != null)
            {
                Console.WriteLine(err_msg.ToString());
                _reader.Close();
                return null;
            }
            else
            {
                Console.WriteLine("GET reader Config Command Timed out");
                _reader.Close();
                return null;
            }

            //Console.WriteLine(builder.Append(rsp_msg.ToString()).AppendLine().AppendLine().ToString());

            return rsp_msg;
        }

        /// <summary>
        /// If ReaderConfig.XML exists, get reader configuration from XML file
        /// </summary>
        /// <param name="dir">filepath</param>
        /// <returns></returns>
        public Org.LLRP.LTK.LLRPV1.DataType.Message GetReaderConfigFromXML(string dir)
        {
            Console.WriteLine("Getting Reader Config From XML...");
            Org.LLRP.LTK.LLRPV1.DataType.Message obj;
            ENUM_LLRP_MSG_TYPE msg_type;

            // read the XML from a file and validate its a SET_READER_CONFIG
            string s = "";
            try
            {
                using (FileStream fs = new FileStream(dir + "\\ReaderConfig.xml", FileMode.Open, FileAccess.Read))
                {
                    using (StreamReader sr = new StreamReader(fs))
                    {
                        s = sr.ReadToEnd();
                    }
                }
                LLRPXmlParser.ParseXMLToLLRPMessage(s, out obj, out msg_type);
                if (obj == null || msg_type != ENUM_LLRP_MSG_TYPE.SET_READER_CONFIG)
                {
                    Console.WriteLine("Could not extract SET_READER_CONFIG message from XML");
                    _reader.Close();
                    return null;
                }
            }
            catch
            {
                Console.WriteLine("Unable to convert to valid XML!");
                _reader.Close();
                return null;
            }
            return obj;
        }
        #endregion

        #region RoSpec related Settings
        public void Enable_ROSpec(uint id)
        {
            Console.WriteLine("Enabling RoSpec...");

            MSG_ERROR_MESSAGE msg_err;
            MSG_ENABLE_ROSPEC msg = new MSG_ENABLE_ROSPEC();
            msg.ROSpecID = id;   // this better match the ROSpec we created above
            MSG_ENABLE_ROSPEC_RESPONSE rsp = _reader.ENABLE_ROSPEC(msg, out msg_err, 600000);
            if (rsp != null)
            {
                Console.WriteLine(rsp.LLRPStatus.StatusCode.ToString());
                if (rsp.LLRPStatus.StatusCode != ENUM_StatusCode.M_Success)
                {
                    _reader.Close();
                    return;
                }
            }
            else if (msg_err != null)
            {
                Console.WriteLine(msg_err.ToString());
                _reader.Close();
                return;
            }
            else
            {
                Console.WriteLine("ENABLE_ROSPEC Command Timed out!");
                _reader.Close();
                return;
            }
        }

        public void Enable_Impinj_Extensions()
        {
            Console.WriteLine("Enabling ImpinJ extensions...");

            MSG_ERROR_MESSAGE msg_err;
            MSG_IMPINJ_ENABLE_EXTENSIONS imp_msg = new MSG_IMPINJ_ENABLE_EXTENSIONS();
            MSG_CUSTOM_MESSAGE cust_rsp = _reader.CUSTOM_MESSAGE(imp_msg, out msg_err, 2000);
            MSG_IMPINJ_ENABLE_EXTENSIONS_RESPONSE rsp = cust_rsp as MSG_IMPINJ_ENABLE_EXTENSIONS_RESPONSE;

            if (rsp != null)
            {
                Console.WriteLine(rsp.LLRPStatus.StatusCode.ToString());
                if (rsp.LLRPStatus.StatusCode != ENUM_StatusCode.M_Success)
                {
                    _reader.Close();
                    return;
                }
            }
            else if (msg_err != null)
            {
                Console.WriteLine(msg_err.ToString());
                _reader.Close();
                return;
            }
            else
            {
                Console.WriteLine("IMPINJ_ENABLE_EXTENSIONS Timeout Error.");
                _reader.Close();
                return;
            }
        }

        public void Start_ROSpec(uint id)
        {
            Console.WriteLine("Starting RoSpec...");

            MSG_START_ROSPEC msg = new MSG_START_ROSPEC();
            MSG_ERROR_MESSAGE msg_err;
            msg.ROSpecID = id; // this better match the RoSpec we created above
            MSG_START_ROSPEC_RESPONSE rsp = _reader.START_ROSPEC(msg, out msg_err, 12000);
            if (rsp != null)
            {
                Console.WriteLine(rsp.LLRPStatus.StatusCode.ToString());
                if (rsp.LLRPStatus.StatusCode != ENUM_StatusCode.M_Success)
                {
                    _reader.Close();
                    return;
                }
            }
            else if (msg_err != null)
            {
                Console.WriteLine(msg_err.ToString());
                _reader.Close();
                return;
            }
            else
            {
                Console.WriteLine("START_ROSPEC Command Timed out!");
                _reader.Close();
                return;
            }
        }

        public void Stop_ROSpec(uint id)
        {
            Console.WriteLine("Stopping RoSpec ...");
            MSG_STOP_ROSPEC msg = new MSG_STOP_ROSPEC();
            MSG_ERROR_MESSAGE err_msg;
            msg.ROSpecID = id; // this better match the RoSpec we created above

            MSG_STOP_ROSPEC_RESPONSE stp_rsp = _reader.STOP_ROSPEC(msg, out err_msg, 12000);

            if (stp_rsp != null)
            {
                Console.WriteLine(stp_rsp.LLRPStatus.StatusCode.ToString());
                if (stp_rsp.LLRPStatus.StatusCode != ENUM_StatusCode.M_Success)
                {
                    _reader.Close();
                    return;
                }
            }
            else if (err_msg != null)
            {
                Console.WriteLine(err_msg.ToString());
                _reader.Close();
                return;
            }
            else
            {
                Console.WriteLine("STOP_ROSPEC Command Timed out!");
                _reader.Close();
                return;
            }
        }

        public MSG_GET_ROSPECS_RESPONSE GetROSpecFromReader()
        {
            Console.WriteLine("Getting ROSpec from reader...");

            MSG_GET_ROSPECS msg = new MSG_GET_ROSPECS();

            MSG_ERROR_MESSAGE err_msg;
            MSG_GET_ROSPECS_RESPONSE rsp_msg = _reader.GET_ROSPECS(msg, out err_msg, 8000);

            StringBuilder builder = new StringBuilder();

            if (rsp_msg != null)
            {
                Console.WriteLine(rsp_msg.LLRPStatus.StatusCode.ToString());
                if (rsp_msg.LLRPStatus.StatusCode != ENUM_StatusCode.M_Success)
                {
                    _reader.Close();
                    return null;
                }
            }
            else if (err_msg != null)
            {
                Console.WriteLine(err_msg.ToString());
                _reader.Close();
                return null;
            }
            else
            {
                Console.WriteLine("GET ROSpec Command Timed out");
                _reader.Close();
                return null;
            }

            //Console.WriteLine(builder.Append(rsp_msg.ToString()).AppendLine().AppendLine().ToString());

            return rsp_msg;
        }

        public Org.LLRP.LTK.LLRPV1.DataType.Message GetROSpecFromXML(string dir)
        {
            Console.WriteLine("Getting ROSpec From XML...");
            Org.LLRP.LTK.LLRPV1.DataType.Message obj;
            ENUM_LLRP_MSG_TYPE msg_type;

            // read the XML from a file and validate its an ADD_ROSPEC
            string s = "";
            try
            {
                using (FileStream fs = new FileStream(dir + "\\ROSpec.xml", FileMode.Open, FileAccess.Read))
                {
                    using (StreamReader sr = new StreamReader(fs))
                    {
                        s = sr.ReadToEnd();
                    }
                }
                LLRPXmlParser.ParseXMLToLLRPMessage(s, out obj, out msg_type);

                Console.WriteLine(msg_type.ToString());
                if (obj == null || msg_type != ENUM_LLRP_MSG_TYPE.ADD_ROSPEC)
                {
                    Console.WriteLine("Could not extract ADD_ROSPEC message from XML");
                    _reader.Close();
                    return null;
                }
            }
            catch
            {
                Console.WriteLine("Unable to convert to valid XML!");
                _reader.Close();
                return null;
            }
            return obj;
        }

        public MSG_ADD_ROSPEC GenerateROSpec(string dir)
        {
            Console.WriteLine("Generate RoSpec...");

            MSG_ADD_ROSPEC ros;
           // string filepath = dir + "\\ROSpec.xml";
          //  if (File.Exists(filepath))
         //   {
        //        ros = (MSG_ADD_ROSPEC)GetROSpecFromXML(dir);
        //        //make sure specID is not 0
      //          if (ros.ROSpec.ROSpecID >= uint.MaxValue)
      //              ros.ROSpec.ROSpecID = 1111;
      //          else if (++ros.ROSpec.ROSpecID == 0)
       //             ++ros.ROSpec.ROSpecID;
       //     }
        //    else
        //    {
                ros = new MSG_ADD_ROSPEC();
                if (ros.ROSpec == null)
                    ros.ROSpec = new PARAM_ROSpec();
                ros.ROSpec.ROSpecID = 1111;
      //      }

            //------ROSpec------
            ros.ROSpec.CurrentState = ENUM_ROSpecState.Disabled;
            ros.ROSpec.Priority = 0x00;


            // setup the start and stop triggers in the Boundary Spec
            if (ros.ROSpec.ROBoundarySpec == null)
                ros.ROSpec.ROBoundarySpec = new PARAM_ROBoundarySpec();
            if (ros.ROSpec.ROBoundarySpec.ROSpecStartTrigger == null)
                ros.ROSpec.ROBoundarySpec.ROSpecStartTrigger = new PARAM_ROSpecStartTrigger();
            ros.ROSpec.ROBoundarySpec.ROSpecStartTrigger.ROSpecStartTriggerType = ENUM_ROSpecStartTriggerType.Null;

            if (ros.ROSpec.ROBoundarySpec.ROSpecStopTrigger == null)
                ros.ROSpec.ROBoundarySpec.ROSpecStopTrigger = new PARAM_ROSpecStopTrigger();
            if (RFIDReaderParameter.ReadMode == "Timer")
            {
                if (RFIDReaderParameter.Duration > 0)
                {
                    ros.ROSpec.ROBoundarySpec.ROSpecStopTrigger.ROSpecStopTriggerType = ENUM_ROSpecStopTriggerType.Duration;
                    ros.ROSpec.ROBoundarySpec.ROSpecStopTrigger.DurationTriggerValue = RFIDReaderParameter.Duration;
                }
            }
            else
            {
                ros.ROSpec.ROBoundarySpec.ROSpecStopTrigger.ROSpecStopTriggerType = ENUM_ROSpecStopTriggerType.Null;
                ros.ROSpec.ROBoundarySpec.ROSpecStopTrigger.DurationTriggerValue = 0;
            }


            // ------Antenna Inventory Spec (AISpec)------
            // Specifies which antennas and protocol to use
            if (ros.ROSpec.SpecParameter == null)
                ros.ROSpec.SpecParameter = new UNION_SpecParameter();
            PARAM_AISpec aiSpec;
            bool flagSpecPara = false;
            if (ros.ROSpec.SpecParameter.Count > 0)
            {
                flagSpecPara = true;
                aiSpec = (PARAM_AISpec)ros.ROSpec.SpecParameter[0];
            }
            else
            {
                aiSpec = new PARAM_AISpec();
            }

            // No AISpec Stop trigger. It stops when the ROSpec stops
            if (aiSpec.AISpecStopTrigger == null)
                aiSpec.AISpecStopTrigger = new PARAM_AISpecStopTrigger();
            if (RFIDReaderParameter.ReadMode == "Timer")
            {
                if (RFIDReaderParameter.Duration > 0)
                {
                    aiSpec.AISpecStopTrigger.AISpecStopTriggerType = ENUM_AISpecStopTriggerType.Duration;
                    aiSpec.AISpecStopTrigger.DurationTrigger = RFIDReaderParameter.Duration;
                }
            }
            else
            {
                aiSpec.AISpecStopTrigger.AISpecStopTriggerType = ENUM_AISpecStopTriggerType.Null;
                aiSpec.AISpecStopTrigger.DurationTrigger = 0;
            }

            // use all the defaults from the reader. Just specify the minimum required
            if (aiSpec.InventoryParameterSpec == null)
                aiSpec.InventoryParameterSpec = new PARAM_InventoryParameterSpec[1];
            if (aiSpec.InventoryParameterSpec[0] == null)
                aiSpec.InventoryParameterSpec[0] = new PARAM_InventoryParameterSpec();
            aiSpec.InventoryParameterSpec[0].InventoryParameterSpecID = 1234;
            aiSpec.InventoryParameterSpec[0].ProtocolID = ENUM_AirProtocols.EPCGlobalClass1Gen2;

            if (aiSpec.AntennaIDs == null)
                aiSpec.AntennaIDs = new UInt16Array();
            if (aiSpec.InventoryParameterSpec[0].AntennaConfiguration == null)
                aiSpec.InventoryParameterSpec[0].AntennaConfiguration = new PARAM_AntennaConfiguration[this.antennaConfiguration.NumberOfAntennaConnected];
            // Enable all connected antennas
            int j = 0;
            for (int i = 0; i < this.antennaConfiguration.AntennaID.Length; i++)
            {
                if (this.antennaConfiguration.AntennaConnected[i] && j < this.antennaConfiguration.NumberOfAntennaConnected)
                {
                    //aiSpec.AntennaIDs.Add(0); // all antennas
                    if (!aiSpec.AntennaIDs.data.Contains(this.antennaConfiguration.AntennaID[i]))
                        aiSpec.AntennaIDs.Add(this.antennaConfiguration.AntennaID[i]);
                    if (aiSpec.InventoryParameterSpec[0].AntennaConfiguration[j] == null)
                        aiSpec.InventoryParameterSpec[0].AntennaConfiguration[j] = new PARAM_AntennaConfiguration();
                    aiSpec.InventoryParameterSpec[0].AntennaConfiguration[j].AntennaID = this.antennaConfiguration.AntennaID[i];
                    bool flagAirProtocol = false;
                    PARAM_C1G2InventoryCommand c1G2Command;
                    if (aiSpec.InventoryParameterSpec[0].AntennaConfiguration[j].AirProtocolInventoryCommandSettings.Count > 0)
                    {
                        flagAirProtocol = true;
                        c1G2Command = (PARAM_C1G2InventoryCommand)aiSpec.InventoryParameterSpec[0].AntennaConfiguration[j].AirProtocolInventoryCommandSettings[0];
                    }
                    else
                    {
                        c1G2Command = new PARAM_C1G2InventoryCommand();
                    }

                    PARAM_ImpinjFixedFrequencyList fixedFrequencyList;
                    bool flagC1G2Command = false;
                    if (c1G2Command.Custom.Count > 0)
                    {
                        flagC1G2Command = true;
                        fixedFrequencyList = (PARAM_ImpinjFixedFrequencyList)c1G2Command.Custom[0];
                    }
                    else
                    {
                        fixedFrequencyList = new PARAM_ImpinjFixedFrequencyList();
                    }
                    fixedFrequencyList.FixedFrequencyMode =
                        (ENUM_ImpinjFixedFrequencyMode)Enum.Parse(typeof(ENUM_ImpinjFixedFrequencyMode), this.antennaConfiguration.FixedFrequencyMode);
                    fixedFrequencyList.ChannelList = this.antennaConfiguration.FixedChannelList;
                    if (!flagC1G2Command)
                        c1G2Command.AddCustomParameter(fixedFrequencyList);
                    if (!flagAirProtocol)
                        aiSpec.InventoryParameterSpec[0].AntennaConfiguration[j].AirProtocolInventoryCommandSettings.Add(c1G2Command);
                    j = j + 1;
                }
            }
            if (!flagSpecPara)
                ros.ROSpec.SpecParameter.Add(aiSpec);

            if (ros.ROSpec.ROReportSpec == null)
                ros.ROSpec.ROReportSpec = new PARAM_ROReportSpec();
            ros.ROSpec.ROReportSpec.ROReportTrigger =
                (ENUM_ROReportTriggerType)Enum.Parse(typeof(ENUM_ROReportTriggerType), this.rOReportSpec.SelectedROReportTrigger);
            ros.ROSpec.ROReportSpec.N = this.rOReportSpec.ROReportTriggerN;

            if (ros.ROSpec.ROReportSpec.TagReportContentSelector == null)
                ros.ROSpec.ROReportSpec.TagReportContentSelector = new PARAM_TagReportContentSelector();
            ros.ROSpec.ROReportSpec.TagReportContentSelector.EnableROSpecID = this.rOReportSpec.EnableROSpecID;
            ros.ROSpec.ROReportSpec.TagReportContentSelector.EnableSpecIndex = this.rOReportSpec.EnableSpecIndex;
            ros.ROSpec.ROReportSpec.TagReportContentSelector.EnableInventoryParameterSpecID = this.rOReportSpec.EnableInventoryParameterSPecID;
            ros.ROSpec.ROReportSpec.TagReportContentSelector.EnableAntennaID = this.rOReportSpec.EnableAntennaID;
            ros.ROSpec.ROReportSpec.TagReportContentSelector.EnableChannelIndex = this.rOReportSpec.EnableChannelIndex;
            ros.ROSpec.ROReportSpec.TagReportContentSelector.EnablePeakRSSI = this.rOReportSpec.EnablePeakRSSI;
            ros.ROSpec.ROReportSpec.TagReportContentSelector.EnableFirstSeenTimestamp = this.rOReportSpec.EnableFirstSeenTimestamp;
            ros.ROSpec.ROReportSpec.TagReportContentSelector.EnableLastSeenTimestamp = this.rOReportSpec.EnableLastSeenTimestamp;
            ros.ROSpec.ROReportSpec.TagReportContentSelector.EnableTagSeenCount = this.rOReportSpec.EnableTagSeenCount;
            ros.ROSpec.ROReportSpec.TagReportContentSelector.EnableAccessSpecID = this.rOReportSpec.EnableAccessSpecID;

            PARAM_C1G2EPCMemorySelector c1G2EPCMemorySelector;
            bool flagC1G2EPCMem = false;
            if (ros.ROSpec.ROReportSpec.TagReportContentSelector.AirProtocolEPCMemorySelector.Count > 0)
            {
                flagC1G2EPCMem = true;
                c1G2EPCMemorySelector = (PARAM_C1G2EPCMemorySelector)ros.ROSpec.ROReportSpec.TagReportContentSelector.AirProtocolEPCMemorySelector[0];
            }
            else
            {
                c1G2EPCMemorySelector = new PARAM_C1G2EPCMemorySelector();
            }
            c1G2EPCMemorySelector.EnableCRC = this.rOReportSpec.EnableCRC;
            c1G2EPCMemorySelector.EnablePCBits = this.rOReportSpec.EnablePCbits;
            if (!flagC1G2EPCMem)
                ros.ROSpec.ROReportSpec.TagReportContentSelector.AirProtocolEPCMemorySelector.Add(c1G2EPCMemorySelector);

            PARAM_ImpinjTagReportContentSelector impinjTagData;
            bool flagImpinJTag = false;
            if (ros.ROSpec.ROReportSpec.Custom.Count > 0)
            {
                flagImpinJTag = true;
                impinjTagData = (PARAM_ImpinjTagReportContentSelector)ros.ROSpec.ROReportSpec.Custom[0];
            }
            else
            {
                impinjTagData = new PARAM_ImpinjTagReportContentSelector();
            }

            if (impinjTagData.ImpinjEnableSerializedTID == null)
                impinjTagData.ImpinjEnableSerializedTID = new PARAM_ImpinjEnableSerializedTID();
            impinjTagData.ImpinjEnableSerializedTID.SerializedTIDMode =
                        this.rOReportSpec.ImpinJEnableSerializedTID ? ENUM_ImpinjSerializedTIDMode.Enabled : ENUM_ImpinjSerializedTIDMode.Disabled;
            if (impinjTagData.ImpinjEnableRFPhaseAngle == null)
                impinjTagData.ImpinjEnableRFPhaseAngle = new PARAM_ImpinjEnableRFPhaseAngle();
            impinjTagData.ImpinjEnableRFPhaseAngle.RFPhaseAngleMode =
                        this.rOReportSpec.ImpinJEnableRFPhaseAngle ? ENUM_ImpinjRFPhaseAngleMode.Enabled : ENUM_ImpinjRFPhaseAngleMode.Disabled;
            if (impinjTagData.ImpinjEnablePeakRSSI == null)
                impinjTagData.ImpinjEnablePeakRSSI = new PARAM_ImpinjEnablePeakRSSI();
            impinjTagData.ImpinjEnablePeakRSSI.PeakRSSIMode =
                        this.rOReportSpec.ImpinJEnablePeakRSSI ? ENUM_ImpinjPeakRSSIMode.Enabled : ENUM_ImpinjPeakRSSIMode.Disabled;
            if (impinjTagData.ImpinjEnableGPSCoordinates == null)
                impinjTagData.ImpinjEnableGPSCoordinates = new PARAM_ImpinjEnableGPSCoordinates();
            impinjTagData.ImpinjEnableGPSCoordinates.GPSCoordinatesMode =
                        this.rOReportSpec.ImpinJEnableGPSCoordinates ? ENUM_ImpinjGPSCoordinatesMode.Enabled : ENUM_ImpinjGPSCoordinatesMode.Disabled;
            if (impinjTagData.ImpinjEnableOptimizedRead == null)
                impinjTagData.ImpinjEnableOptimizedRead = new PARAM_ImpinjEnableOptimizedRead();
            impinjTagData.ImpinjEnableOptimizedRead.OptimizedReadMode =
                        this.rOReportSpec.ImpinJEnableOptimizedRead ? ENUM_ImpinjOptimizedReadMode.Enabled : ENUM_ImpinjOptimizedReadMode.Disabled;
            if (impinjTagData.ImpinjEnableRFDopplerFrequency == null)
                impinjTagData.ImpinjEnableRFDopplerFrequency = new PARAM_ImpinjEnableRFDopplerFrequency();
            impinjTagData.ImpinjEnableRFDopplerFrequency.RFDopplerFrequencyMode =
                        this.rOReportSpec.ImpinJEnableRFDopplerFrequency ? ENUM_ImpinjRFDopplerFrequencyMode.Enabled : ENUM_ImpinjRFDopplerFrequencyMode.Disabled;

            // These are custom fields, so they get added this way
            if (!flagImpinJTag)
                ros.ROSpec.ROReportSpec.Custom.Add(impinjTagData);

            return ros;
        }

        public uint AddROSpec(string dir)
        {
            Console.WriteLine("Add Rospec...");
            MSG_ADD_ROSPEC msg = GenerateROSpec(dir);

            if (msg != null)
            {
                MSG_ERROR_MESSAGE err_msg;
                MSG_ADD_ROSPEC_RESPONSE rsp = _reader.ADD_ROSPEC(msg, out err_msg, 5000);

                if (rsp != null)
                {
                    Console.WriteLine(rsp.LLRPStatus.StatusCode.ToString());
                    if (rsp.LLRPStatus.StatusCode != ENUM_StatusCode.M_Success)
                    {
                        _reader.Close();
                        return 0;
                    }

                    //Save config to xml file
                    FileMode mode;
                    string filepath = dir + "\\ROSpec.xml";
                    if (File.Exists(filepath))
                    {
                        mode = FileMode.Truncate;
                    }
                    else
                    {
                        mode = FileMode.OpenOrCreate;
                    }
                    using (FileStream fs = new FileStream(filepath, mode, FileAccess.Write))
                    {
                        using (StreamWriter sw = new StreamWriter(fs))
                        {
                            sw.Write(msg);
                            sw.Flush();
                        }
                    }
                    return msg.ROSpec.ROSpecID;
                }
                else if (err_msg != null)
                {
                    Console.WriteLine(err_msg.ToString());
                    _reader.Close();
                    return 0;
                }
                else
                {
                    Console.WriteLine("ADD_ROSPEC Command Timed out!");
                    _reader.Close();
                    return 0;
                }
            }
            else
                return 0;
        }

        #region Event
        // LLRPClient object contains three event delegates to handle the three different types of messages initiated by the Reader:
        // • RO_ACCESS_REPORT:  
        //   These are the tag reports from both inventory and access operations. Reports are delivered through the delegate delegateRoAccessReport.
        // • READER_EVENT_NOTIFICATION:
        //   These asynchronous events describe the Reader’s status or health.One example includes the AntennaEvent, which reports when antennas
        //   are connected or disconnected.These reports are delivered via the delegate delegateReaderEventNotification.
        // • KEEPALIVE:
        //   These messages are sent by the Reader (configured by the client) and tell the Reader to periodically send messages to the client to validate connectivity.
        //   The Reader itself does not take action when these events are not delivered. 
        //   These messages are delivered through the delegate delegateKeepAlive.
        public void AddEventHandler()
        {
            Console.WriteLine("Adding Event Handlers...");
            _reader.OnRoAccessReportReceived += new delegateRoAccessReport(OnTagReportEvent);
            _reader.OnReaderEventNotification += new delegateReaderEventNotification(OnReaderEventNotification);
        }

        public void DeleteEventHandler()
        {
            Console.WriteLine("Deleting Event Handlers...");
            _reader.OnRoAccessReportReceived -= new delegateRoAccessReport(OnTagReportEvent);
            _reader.OnReaderEventNotification -= new delegateReaderEventNotification(OnReaderEventNotification);
        }

        /// <summary>
        /// Receive Tag Data Report from reader
        /// </summary>
        /// <param name="msg">message</param>
        public void OnTagReportEvent(MSG_RO_ACCESS_REPORT msg)
        {
            TagInfo _tagInfo = new TagInfo();          //Store information of every tag read conveyed in one tag report
            if (msg != null && msg.TagReportData != null)
            {
                //Loop through all the tags in the report
                for (int i = 0; i < msg.TagReportData.Length; i++)
                {
                    if (msg.TagReportData[i].EPCParameter.Count > 0)
                    {
                        // Two possible types of EPC: 96-bit and 128-bit
                        if (msg.TagReportData[i].EPCParameter[0].GetType() == typeof(PARAM_EPC_96))
                        {
                            _tagInfo.EPC = ((PARAM_EPC_96)(msg.TagReportData[i].EPCParameter[0])).EPC.ToHexString();
                        }
                        else
                        {
                            _tagInfo.EPC = ((PARAM_EPCData)(msg.TagReportData[i].EPCParameter[0])).EPC.ToHexString();
                        }
                    }
                    //Console.WriteLine("EPC:" + _tagInfo.EPC);
                    if (msg.TagReportData[i].FirstSeenTimestampUTC != null)
                    {
                        _tagInfo.FirstSeenTime = msg.TagReportData[i].FirstSeenTimestampUTC.Microseconds;
                    }
                   // Console.WriteLine("tagTime: "+ ( (long)_tagInfo.FirstSeenTime - CurrentMillis.MicroSeconds));
                    if (msg.TagReportData[i].LastSeenTimestampUTC != null)
                        _tagInfo.LastSeenTime = msg.TagReportData[i].LastSeenTimestampUTC.Microseconds;

                    if (msg.TagReportData[i].AntennaID != null)
                        _tagInfo.Antenna = msg.TagReportData[i].AntennaID.AntennaID;

                    if (msg.TagReportData[i].ChannelIndex != null)
                    {
                        _tagInfo.ChannelIndex = msg.TagReportData[i].ChannelIndex.ChannelIndex;
                        _tagInfo.Frequency = (int)(1000000 * readerCapabilities.FrequencyDic[_tagInfo.ChannelIndex]);
                    }

                    if (msg.TagReportData[i].TagSeenCount != null)
                        _tagInfo.TagSeenCount = msg.TagReportData[i].TagSeenCount.TagCount;

                    //Loop through all the custom fields
                    for (int j = 0; j < msg.TagReportData[i].Custom.Count; j++)
                    {
                        // Get RF Phase Angle and PeakRSSI
                        Object param = msg.TagReportData[i].Custom[j];
                        if (param is PARAM_ImpinjRFPhaseAngle)
                        {
                            _tagInfo.RawPhase = ((PARAM_ImpinjRFPhaseAngle)param).PhaseAngle;
                            _tagInfo.AcutalPhaseInRadian = 2 * Math.PI - 2 * Math.PI * _tagInfo.RawPhase / 4096;
                            //获得一条数据
                        }
                        else if (param is PARAM_ImpinjPeakRSSI)
                            _tagInfo.RSSI = Convert.ToDouble(((PARAM_ImpinjPeakRSSI)param).RSSI) / 100;
                        else if (param is PARAM_ImpinjRFDopplerFrequency)
                            _tagInfo.DopplerShift = ((PARAM_ImpinjRFDopplerFrequency)param).DopplerFrequency;
                    }

                    _tagInfo.TotalTagCount = ++TotalTagCount;
                    //增加队列
                    tagInfoQueue.Enqueue(_tagInfo);
                }
            }
        }

        /// <summary>
        /// Simple Handler for receiving the reader events from the reader
        /// </summary>
        /// <param name="msg">message</param>
        public void OnReaderEventNotification(MSG_READER_EVENT_NOTIFICATION msg)
        {
            // Events could be empty
            if (msg.ReaderEventNotificationData == null) return;

            // Just write out the LTK-XML for now

            // speedway readers always report UTC timestamp
            UNION_Timestamp t = msg.ReaderEventNotificationData.Timestamp;
            PARAM_UTCTimestamp ut = (PARAM_UTCTimestamp)t[0];
            double millis = (ut.Microseconds + 500) / 1000;

            // LLRP reports time in microseconds relative to the Unix Epoch
            DateTime epoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
            DateTime now = epoch.AddMilliseconds(millis);

            //Console.WriteLine("======Reader Event======" + now.ToString("O"));

            // this is how you would look for individual events of interest
            //This parameter carries the AISpec event details
            if (msg.ReaderEventNotificationData.AISpecEvent != null)
                Console.WriteLine(msg.ReaderEventNotificationData.AISpecEvent.ToString());

            //This event is generated when the Reader detects that an antenna is connected or disconnected.
            if (msg.ReaderEventNotificationData.AntennaEvent != null)
            {
                switch (msg.ReaderEventNotificationData.AntennaEvent.EventType)
                {
                    case ENUM_AntennaEventType.Antenna_Disconnected:
                        //MessageBox.Show("Antenna Disconnected! Please check it!");
                        break;
                    case ENUM_AntennaEventType.Antenna_Connected:
                        break;
                    default:
                        break;
                }
                Console.WriteLine(msg.ReaderEventNotificationData.AntennaEvent.ToString());
            }

            //This status report parameter establishes Reader connection status when the Client or Reader initiates a connection
            if (msg.ReaderEventNotificationData.ConnectionAttemptEvent != null)
            {
                switch (msg.ReaderEventNotificationData.ConnectionAttemptEvent.Status)
                {
                    case ENUM_ConnectionAttemptStatusType.Success:
                        break;
                    case ENUM_ConnectionAttemptStatusType.Failed_A_Reader_Initiated_Connection_Already_Exists:
                        //  MessageBox.Show("Failed! A reader initiated connection already exists!");
                        Console.WriteLine("Failed! A reader initiated connection already exists!");
                        break;
                    case ENUM_ConnectionAttemptStatusType.Failed_A_Client_Initiated_Connection_Already_Exists:
                        // MessageBox.Show("Failed! A client initiated connection already exists!");
                        Console.WriteLine("Failed! A client initiated connection already exists!");
                        break;
                    case ENUM_ConnectionAttemptStatusType.Failed_Reason_Other_Than_A_Connection_Already_Exists:
                        //  MessageBox.Show("Failed! Reason other than a connection already exists!");
                        Console.WriteLine("Failed! Reason other than a connection already exists!");
                        break;
                    case ENUM_ConnectionAttemptStatusType.Another_Connection_Attempted:
                        // MessageBox.Show("Another connection attempted!");
                        Console.WriteLine("Another connection attempted!");
                        break;
                    default:
                        break;
                }
                Console.WriteLine(msg.ReaderEventNotificationData.ConnectionAttemptEvent.ToString());
            }

            //This status report parameter informs the Client that, unsolicited by the Client, the Reader will close the connection between the Reader and Client.
            if (msg.ReaderEventNotificationData.ConnectionCloseEvent != null)
                Console.WriteLine(msg.ReaderEventNotificationData.ConnectionCloseEvent.ToString());

            //A reader reports this event every time an enabled GPI changes GPIstate
            if (msg.ReaderEventNotificationData.GPIEvent != null)
                Console.WriteLine(msg.ReaderEventNotificationData.GPIEvent.ToString());

            //A Reader reports this event every time it hops frequency.
            if (msg.ReaderEventNotificationData.HoppingEvent != null)
                Console.WriteLine(msg.ReaderEventNotificationData.HoppingEvent.ToString());

            //The reader exception status event notifies the client that an unexpected event has occurred on the reader.
            if (msg.ReaderEventNotificationData.ReaderExceptionEvent != null)
                Console.WriteLine(msg.ReaderEventNotificationData.ReaderExceptionEvent.ToString());

            //A Reader can warn the Client that the Reader’s report buffer is filling up.
            if (msg.ReaderEventNotificationData.ReportBufferLevelWarningEvent != null)
                Console.WriteLine(msg.ReaderEventNotificationData.ReportBufferLevelWarningEvent.ToString());

            if (msg.ReaderEventNotificationData.ReportBufferOverflowErrorEvent != null)
                Console.WriteLine(msg.ReaderEventNotificationData.ReportBufferOverflowErrorEvent.ToString());

            //This parameter carries the ROSpec event details. The EventType could be start or end of the ROSpec.
            if (msg.ReaderEventNotificationData.ROSpecEvent != null)
            {
                switch (msg.ReaderEventNotificationData.ROSpecEvent.EventType)
                {
                    case ENUM_ROSpecEventType.Start_Of_ROSpec:
                        Console.WriteLine("RoSpecEvent Start Of ROSpec");
                        break; 
                      case ENUM_ROSpecEventType.End_Of_ROSpec:
                        Console.WriteLine("RoSpecEvent End Of ROSpec");
                        break;
                    case ENUM_ROSpecEventType.Preemption_Of_ROSpec:
                        break;
                    default:
                        break;
                }
                Console.WriteLine(msg.ReaderEventNotificationData.ROSpecEvent.ToString());
            }

        }
        #endregion


        #endregion


        #region Set Settings
        /// <summary>
        /// Update parameters in RFIDReaderParameter
        /// </summary>
        public AntennaConfiguration getRFIDReaderPara(AntennaConfiguration antennaConfiguration, int MaxNumberOfAntennaSupported)
        {
            MSG_GET_READER_CONFIG_RESPONSE config;

            config = GetReaderConfigFromReader();

            //Get the MAC address of the reader
            RFIDReaderParameter.MAC = config.Identification.ReaderID.ToHexString();

            //Get the configuration of connected antennas
            ushort antConnectedCount = 0;
            for (int i = 0; i < MaxNumberOfAntennaSupported; i++)
            {
                if (config.AntennaProperties[i].AntennaConnected)
                {
                    antConnectedCount++;
                    antennaConfiguration.HopTableID = config.AntennaConfiguration[i].RFTransmitter.HopTableID;
                    antennaConfiguration.ChannelIndex = config.AntennaConfiguration[i].RFTransmitter.ChannelIndex;
                    PARAM_C1G2InventoryCommand C1G2Command = (PARAM_C1G2InventoryCommand)config.AntennaConfiguration[i].AirProtocolInventoryCommandSettings[0];
                    antennaConfiguration.TagInventoryStateAware = C1G2Command.TagInventoryStateAware;
                    antennaConfiguration.ModeIndex = C1G2Command.C1G2RFControl.ModeIndex;
                }

                antennaConfiguration.AntennaID[i] = config.AntennaProperties[i].AntennaID;
                antennaConfiguration.AntennaConnected[i] = config.AntennaProperties[i].AntennaConnected;
                antennaConfiguration.SelectedReceiverSensitivityIndex[i] =
                    config.AntennaConfiguration[i].RFReceiver.ReceiverSensitivity;
                antennaConfiguration.SelectedTransmiterPowerIndex[i] =
                    config.AntennaConfiguration[i].RFTransmitter.TransmitPower;
            }
            antennaConfiguration.NumberOfAntennaConnected = antConnectedCount;
            return antennaConfiguration;
        }

        /// <summary>
        /// Use the factory default LLRP configuration to ensure that the Reader is in a known state
        /// </summary>
        /// <returns></returns>
        public MSG_SET_READER_CONFIG ResetToFactoryDefault()
        {
            Console.WriteLine("Reset to factory default...");
            // factory default the reader
            MSG_SET_READER_CONFIG cfg_msg = new MSG_SET_READER_CONFIG();
            MSG_ERROR_MESSAGE cfg_err_msg;
            cfg_msg.ResetToFactoryDefault = true;

            //If SET_READER_CONFIG affects antennas it could take several seconds to return
            MSG_SET_READER_CONFIG_RESPONSE cfg_rsp = _reader.SET_READER_CONFIG(cfg_msg, out cfg_err_msg, 12000);

            if (cfg_rsp != null)
            {
                Console.WriteLine(cfg_rsp.LLRPStatus.StatusCode.ToString());
                if (cfg_rsp.LLRPStatus.StatusCode != ENUM_StatusCode.M_Success)
                {
                    _reader.Close();
                    return null;
                }
                return cfg_msg;
            }
            else if (cfg_err_msg != null)
            {
                Console.WriteLine(cfg_err_msg.ToString());
                _reader.Close();
                return null;
            }
            else
            {
                Console.WriteLine("SET_READER_CONFIG Timed out");
                _reader.Close();
                return null;
            }
        }

        /// <summary>
        /// There three different approached to add modified paremeters to generate reader config:
        /// 1) ResetToFactoryDefault is true
        ///    Get config from reader
        /// 2) ResetToFactoryDefault is false
        ///    2.1) ReaderConfig.xml exists
        ///         Get config from xml file
        ///    2.2) ReaderConfig.xml does not exist
        ///         Generate a new object
        /// </summary>
        /// <param name="dir"></param>
        /// <returns></returns>
        public MSG_SET_READER_CONFIG GenerateReaderConfig(string dir, AntennaConfiguration antennaConfiguration, ROReportSpec rOReportSpec)
        {
            Console.WriteLine("Generate Reader config...");
        //    antennaConfiguration.NumberOfAntennaConnected = 1;
            MSG_SET_READER_CONFIG config;
            if (RFIDReaderParameter.Reset)
            {
                Console.WriteLine("Reset");
                config = ResetToFactoryDefault();
            }
            else
            {
                Console.WriteLine("Without reset");
                string filepath = dir + "\\ReaderConfig.xml";
                if (File.Exists(filepath))
                {
                    config = (MSG_SET_READER_CONFIG)GetReaderConfigFromXML(dir);
                }
                else
                {
                    config = new MSG_SET_READER_CONFIG();
                }
            }

            #region Antennas
            if (config.AntennaConfiguration == null)
                config.AntennaConfiguration =
                    new PARAM_AntennaConfiguration[antennaConfiguration.NumberOfAntennaConnected];
            int j = 0;
            for (int i = 0; i < antennaConfiguration.MaxNumberOfAntennaSupported; i++)
            {
                if (antennaConfiguration.AntennaConnected[i] && j < antennaConfiguration.NumberOfAntennaConnected)
                {
                    if (config.AntennaConfiguration[j] == null)
                        config.AntennaConfiguration[j] = new PARAM_AntennaConfiguration();
                    config.AntennaConfiguration[j].AntennaID = antennaConfiguration.AntennaID[i];
                    if (config.AntennaConfiguration[j].RFReceiver == null)
                        config.AntennaConfiguration[j].RFReceiver = new PARAM_RFReceiver();
                    config.AntennaConfiguration[j].RFReceiver.ReceiverSensitivity =
                        antennaConfiguration.SelectedReceiverSensitivityIndex[i];
                    if (config.AntennaConfiguration[j].RFTransmitter == null)
                        config.AntennaConfiguration[j].RFTransmitter = new PARAM_RFTransmitter();
                    config.AntennaConfiguration[j].RFTransmitter.HopTableID = antennaConfiguration.HopTableID;
                    config.AntennaConfiguration[j].RFTransmitter.ChannelIndex = antennaConfiguration.ChannelIndex;
                    config.AntennaConfiguration[j].RFTransmitter.TransmitPower =
                        antennaConfiguration.SelectedTransmiterPowerIndex[i];

                    PARAM_C1G2InventoryCommand c1G2Command;
                    bool flagInventoryCommand = false;
                    if (config.AntennaConfiguration[j].AirProtocolInventoryCommandSettings.Count > 0)
                    {
                        flagInventoryCommand = true;
                        c1G2Command = (PARAM_C1G2InventoryCommand)config.AntennaConfiguration[j].AirProtocolInventoryCommandSettings[0];
                    }
                    else
                    {
                        c1G2Command = new PARAM_C1G2InventoryCommand();
                    }
                    c1G2Command.TagInventoryStateAware = antennaConfiguration.TagInventoryStateAware;

                    if (c1G2Command.C1G2RFControl == null)
                        c1G2Command.C1G2RFControl = new PARAM_C1G2RFControl();
                    c1G2Command.C1G2RFControl.ModeIndex = antennaConfiguration.ModeIndex;
                    c1G2Command.C1G2RFControl.Tari = antennaConfiguration.Tari;

                    if (c1G2Command.C1G2SingulationControl == null)
                        c1G2Command.C1G2SingulationControl = new PARAM_C1G2SingulationControl();
                    c1G2Command.C1G2SingulationControl.Session = new TwoBits(antennaConfiguration.SelectedSessionIndex);
                    c1G2Command.C1G2SingulationControl.TagPopulation = antennaConfiguration.TagPopulation;
                    c1G2Command.C1G2SingulationControl.TagTransitTime = antennaConfiguration.TagTransitTime;
                    

                    c1G2Command.C1G2Filter = new PARAM_C1G2Filter[2];

                    c1G2Command.C1G2Filter[0] = new PARAM_C1G2Filter();
                    c1G2Command.C1G2Filter[0].T = ENUM_C1G2TruncateAction.Do_Not_Truncate;
                    c1G2Command.C1G2Filter[0].C1G2TagInventoryMask = new PARAM_C1G2TagInventoryMask();
                    c1G2Command.C1G2Filter[0].C1G2TagInventoryMask.MB = new TwoBits(1);
                    c1G2Command.C1G2Filter[0].C1G2TagInventoryMask.Pointer = 32;
                    c1G2Command.C1G2Filter[0].C1G2TagInventoryMask.TagMask = LLRPBitArray.FromHexString(antennaConfiguration.mask);
                    //ToLLRPBitArray(RFIDReaderParameter.Mask);
                    c1G2Command.C1G2Filter[0].C1G2TagInventoryStateUnawareFilterAction = new PARAM_C1G2TagInventoryStateUnawareFilterAction();
                    c1G2Command.C1G2Filter[0].C1G2TagInventoryStateUnawareFilterAction.Action = ENUM_C1G2StateUnawareAction.Select_Unselect;

                    c1G2Command.C1G2Filter[1] = new PARAM_C1G2Filter();
                    c1G2Command.C1G2Filter[1].T = ENUM_C1G2TruncateAction.Do_Not_Truncate;
                    c1G2Command.C1G2Filter[1].C1G2TagInventoryMask = new PARAM_C1G2TagInventoryMask();
                    c1G2Command.C1G2Filter[1].C1G2TagInventoryMask.MB = new TwoBits(1);
                    c1G2Command.C1G2Filter[1].C1G2TagInventoryMask.Pointer = 32;
                    c1G2Command.C1G2Filter[1].C1G2TagInventoryMask.TagMask = LLRPBitArray.FromHexString(antennaConfiguration.extraMask);
                    //ToLLRPBitArray(RFIDReaderParameter.ExtraMask);
                    c1G2Command.C1G2Filter[1].C1G2TagInventoryStateUnawareFilterAction = new PARAM_C1G2TagInventoryStateUnawareFilterAction();
                    c1G2Command.C1G2Filter[1].C1G2TagInventoryStateUnawareFilterAction.Action = ENUM_C1G2StateUnawareAction.Select_DoNothing;

                    PARAM_ImpinjInventorySearchMode searchMode;
                    PARAM_ImpinjFixedFrequencyList fixedFrequencyList;
                    PARAM_ImpinjReducedPowerFrequencyList reducedPowerFrequencyList;
                    PARAM_ImpinjLowDutyCycle lowDutyCycle;
                    bool flagCustom = false;
                    if (c1G2Command.Custom.Count > 0)
                    {
                        flagCustom = true;
                        searchMode = (PARAM_ImpinjInventorySearchMode)c1G2Command.Custom[0];
                        fixedFrequencyList = (PARAM_ImpinjFixedFrequencyList)c1G2Command.Custom[1];
                        reducedPowerFrequencyList = (PARAM_ImpinjReducedPowerFrequencyList)c1G2Command.Custom[2];
                        lowDutyCycle = (PARAM_ImpinjLowDutyCycle)c1G2Command.Custom[3];
                    }
                    else
                    {
                        searchMode = new PARAM_ImpinjInventorySearchMode();
                        fixedFrequencyList = new PARAM_ImpinjFixedFrequencyList();
                        reducedPowerFrequencyList = new PARAM_ImpinjReducedPowerFrequencyList();
                        lowDutyCycle = new PARAM_ImpinjLowDutyCycle();
                    }

                    searchMode.InventorySearchMode =
                        (ENUM_ImpinjInventorySearchType)Enum.Parse(typeof(ENUM_ImpinjInventorySearchType), antennaConfiguration.SelectedSearchMode);

                    fixedFrequencyList.FixedFrequencyMode =
                        (ENUM_ImpinjFixedFrequencyMode)Enum.Parse(typeof(ENUM_ImpinjFixedFrequencyMode), antennaConfiguration.FixedFrequencyMode);
                    fixedFrequencyList.ChannelList = antennaConfiguration.FixedChannelList;

                    reducedPowerFrequencyList.ReducedPowerMode =
                        antennaConfiguration.ReducedPowerFrequencyMode ? ENUM_ImpinjReducedPowerMode.Enabled : ENUM_ImpinjReducedPowerMode.Disabled;
                    reducedPowerFrequencyList.ChannelList = antennaConfiguration.ReducedPowerChannelList;

                    lowDutyCycle.LowDutyCycleMode =
                        antennaConfiguration.LowDutyCycleMode ? ENUM_ImpinjLowDutyCycleMode.Enabled : ENUM_ImpinjLowDutyCycleMode.Disabled;
                    lowDutyCycle.EmptyFieldTimeout = antennaConfiguration.EmptyFieldTimeout;
                    lowDutyCycle.FieldPingInterval = antennaConfiguration.FieldPingInterval;

                    if (!flagCustom)
                    {
                        c1G2Command.AddCustomParameter(searchMode);
                        c1G2Command.AddCustomParameter(fixedFrequencyList);
                        c1G2Command.AddCustomParameter(reducedPowerFrequencyList);
                        c1G2Command.AddCustomParameter(lowDutyCycle);
                    }

                    if (!flagInventoryCommand)
                        config.AntennaConfiguration[j].AirProtocolInventoryCommandSettings.Add(c1G2Command);
                    j = j + 1;
                }
            }
            #endregion

            #region ReaderEventNotificationSpec
            if (config.ReaderEventNotificationSpec == null)
                config.ReaderEventNotificationSpec = new PARAM_ReaderEventNotificationSpec();
            if (config.ReaderEventNotificationSpec.EventNotificationState == null)
                config.ReaderEventNotificationSpec.EventNotificationState = new PARAM_EventNotificationState[9];
            for (int i = 0; i < 9; i++)
                config.ReaderEventNotificationSpec.EventNotificationState[i] = new PARAM_EventNotificationState();
            config.ReaderEventNotificationSpec.EventNotificationState[0].EventType = ENUM_NotificationEventType.Upon_Hopping_To_Next_Channel;
            config.ReaderEventNotificationSpec.EventNotificationState[0].NotificationState = false;
            config.ReaderEventNotificationSpec.EventNotificationState[1].EventType = ENUM_NotificationEventType.GPI_Event;
            config.ReaderEventNotificationSpec.EventNotificationState[1].NotificationState = false;
            config.ReaderEventNotificationSpec.EventNotificationState[2].EventType = ENUM_NotificationEventType.ROSpec_Event;
            config.ReaderEventNotificationSpec.EventNotificationState[2].NotificationState = true;
            config.ReaderEventNotificationSpec.EventNotificationState[3].EventType = ENUM_NotificationEventType.Report_Buffer_Fill_Warning;
            config.ReaderEventNotificationSpec.EventNotificationState[3].NotificationState = false;
            config.ReaderEventNotificationSpec.EventNotificationState[4].EventType = ENUM_NotificationEventType.Reader_Exception_Event;
            config.ReaderEventNotificationSpec.EventNotificationState[4].NotificationState = true;
            config.ReaderEventNotificationSpec.EventNotificationState[5].EventType = ENUM_NotificationEventType.RFSurvey_Event;
            config.ReaderEventNotificationSpec.EventNotificationState[5].NotificationState = false;
            config.ReaderEventNotificationSpec.EventNotificationState[6].EventType = ENUM_NotificationEventType.AISpec_Event;
            config.ReaderEventNotificationSpec.EventNotificationState[6].NotificationState = false;
            config.ReaderEventNotificationSpec.EventNotificationState[7].EventType = ENUM_NotificationEventType.AISpec_Event_With_Details;
            config.ReaderEventNotificationSpec.EventNotificationState[7].NotificationState = false;
            config.ReaderEventNotificationSpec.EventNotificationState[8].EventType = ENUM_NotificationEventType.Antenna_Event;
            config.ReaderEventNotificationSpec.EventNotificationState[8].NotificationState = true;
            #endregion


            #region ROReportSpec
            if (config.ROReportSpec == null)
                config.ROReportSpec = new PARAM_ROReportSpec();
            config.ROReportSpec.ROReportTrigger =
                        (ENUM_ROReportTriggerType)Enum.Parse(typeof(ENUM_ROReportTriggerType), rOReportSpec.SelectedROReportTrigger);
            config.ROReportSpec.N = rOReportSpec.ROReportTriggerN;
            if (config.ROReportSpec.TagReportContentSelector == null)
                config.ROReportSpec.TagReportContentSelector = new PARAM_TagReportContentSelector();
            config.ROReportSpec.TagReportContentSelector.EnableROSpecID = rOReportSpec.EnableROSpecID;
            config.ROReportSpec.TagReportContentSelector.EnableSpecIndex = rOReportSpec.EnableSpecIndex;
            config.ROReportSpec.TagReportContentSelector.EnableInventoryParameterSpecID = rOReportSpec.EnableInventoryParameterSPecID;
            config.ROReportSpec.TagReportContentSelector.EnableAntennaID = rOReportSpec.EnableAntennaID;
            config.ROReportSpec.TagReportContentSelector.EnableChannelIndex = rOReportSpec.EnableChannelIndex;
            config.ROReportSpec.TagReportContentSelector.EnablePeakRSSI = rOReportSpec.EnablePeakRSSI;
            config.ROReportSpec.TagReportContentSelector.EnableFirstSeenTimestamp = rOReportSpec.EnableFirstSeenTimestamp;
            config.ROReportSpec.TagReportContentSelector.EnableLastSeenTimestamp = rOReportSpec.EnableLastSeenTimestamp;
            config.ROReportSpec.TagReportContentSelector.EnableTagSeenCount = rOReportSpec.EnableTagSeenCount;
            config.ROReportSpec.TagReportContentSelector.EnableAccessSpecID = rOReportSpec.EnableAccessSpecID;
            PARAM_C1G2EPCMemorySelector c1G2EPCMemorySelector;
            bool flagC1G2EPCMem = false;
            if (config.ROReportSpec.TagReportContentSelector.AirProtocolEPCMemorySelector.Count > 0)
            {
                flagC1G2EPCMem = true;
                c1G2EPCMemorySelector = (PARAM_C1G2EPCMemorySelector)config.ROReportSpec.TagReportContentSelector.AirProtocolEPCMemorySelector[0];
            }
            else
            {
                c1G2EPCMemorySelector = new PARAM_C1G2EPCMemorySelector();
            }
            c1G2EPCMemorySelector.EnableCRC = rOReportSpec.EnableCRC;
            c1G2EPCMemorySelector.EnablePCBits = rOReportSpec.EnablePCbits;

            if (!flagC1G2EPCMem)
                config.ROReportSpec.TagReportContentSelector.AirProtocolEPCMemorySelector.Add(c1G2EPCMemorySelector);

            PARAM_ImpinjTagReportContentSelector impinjTagData;
            bool flagImpinJTag = false;
            if (config.ROReportSpec.Custom.Count > 0)
            {
                flagImpinJTag = true;
                impinjTagData = (PARAM_ImpinjTagReportContentSelector)config.ROReportSpec.Custom[0];
            }
            else
            {
                impinjTagData = new PARAM_ImpinjTagReportContentSelector();
            }

            if (impinjTagData.ImpinjEnableSerializedTID == null)
                impinjTagData.ImpinjEnableSerializedTID = new PARAM_ImpinjEnableSerializedTID();
            impinjTagData.ImpinjEnableSerializedTID.SerializedTIDMode =
                        rOReportSpec.ImpinJEnableSerializedTID ? ENUM_ImpinjSerializedTIDMode.Enabled : ENUM_ImpinjSerializedTIDMode.Disabled;
            if (impinjTagData.ImpinjEnableRFPhaseAngle == null)
                impinjTagData.ImpinjEnableRFPhaseAngle = new PARAM_ImpinjEnableRFPhaseAngle();
            impinjTagData.ImpinjEnableRFPhaseAngle.RFPhaseAngleMode =
                        rOReportSpec.ImpinJEnableRFPhaseAngle ? ENUM_ImpinjRFPhaseAngleMode.Enabled : ENUM_ImpinjRFPhaseAngleMode.Disabled;
            if (impinjTagData.ImpinjEnablePeakRSSI == null)
                impinjTagData.ImpinjEnablePeakRSSI = new PARAM_ImpinjEnablePeakRSSI();
            impinjTagData.ImpinjEnablePeakRSSI.PeakRSSIMode =
                        rOReportSpec.ImpinJEnablePeakRSSI ? ENUM_ImpinjPeakRSSIMode.Enabled : ENUM_ImpinjPeakRSSIMode.Disabled;
            if (impinjTagData.ImpinjEnableGPSCoordinates == null)
                impinjTagData.ImpinjEnableGPSCoordinates = new PARAM_ImpinjEnableGPSCoordinates();
            impinjTagData.ImpinjEnableGPSCoordinates.GPSCoordinatesMode =
                        rOReportSpec.ImpinJEnableGPSCoordinates ? ENUM_ImpinjGPSCoordinatesMode.Enabled : ENUM_ImpinjGPSCoordinatesMode.Disabled;
            if (impinjTagData.ImpinjEnableOptimizedRead == null)
                impinjTagData.ImpinjEnableOptimizedRead = new PARAM_ImpinjEnableOptimizedRead();
            impinjTagData.ImpinjEnableOptimizedRead.OptimizedReadMode =
                        rOReportSpec.ImpinJEnableOptimizedRead ? ENUM_ImpinjOptimizedReadMode.Enabled : ENUM_ImpinjOptimizedReadMode.Disabled;
            if (impinjTagData.ImpinjEnableRFDopplerFrequency == null)
                impinjTagData.ImpinjEnableRFDopplerFrequency = new PARAM_ImpinjEnableRFDopplerFrequency();
            impinjTagData.ImpinjEnableRFDopplerFrequency.RFDopplerFrequencyMode =
                        rOReportSpec.ImpinJEnableRFDopplerFrequency ? ENUM_ImpinjRFDopplerFrequencyMode.Enabled : ENUM_ImpinjRFDopplerFrequencyMode.Disabled;

            if (!flagImpinJTag)
                config.ROReportSpec.Custom.Add(impinjTagData);
            #endregion
            //Console.WriteLine("asdf" + config);
            return config;
        }

        /// <summary>
        /// Set Reader Configuration to RFID reader; Meanwhile, save to xml file
        /// </summary>
        /// <param name="dir">filepath</param>
        public void SetReaderConfiguration(string dir, AntennaConfiguration antennaConfiguration, ROReportSpec rOReportSpec)
        {
            Console.WriteLine("Set Reader Configuration...");
            MSG_SET_READER_CONFIG msg = GenerateReaderConfig(dir, antennaConfiguration, rOReportSpec);
            if (msg != null)
            {
                MSG_ERROR_MESSAGE err_msg;
                MSG_SET_READER_CONFIG_RESPONSE rsp = _reader.SET_READER_CONFIG(msg, out err_msg, 2000);
                if (rsp != null)
                {
                    Console.WriteLine(rsp.LLRPStatus.StatusCode.ToString());
                    if (rsp.LLRPStatus.StatusCode != ENUM_StatusCode.M_Success)
                    {
                        _reader.Close();
                        return;
                    }

                    //Save config to xml file
                    FileMode mode;
                    string filepath = dir + "\\ReaderConfig.xml";
                    if (File.Exists(filepath))
                    {
                        mode = FileMode.Truncate;
                    }
                    else
                    {
                        mode = FileMode.OpenOrCreate;
                    }
                    using (FileStream fs = new FileStream(filepath, mode, FileAccess.Write))
                    {
                        using (StreamWriter sw = new StreamWriter(fs))
                        {
                            sw.Write(msg);
                            sw.Flush();
                        }
                    }
                    this.antennaConfiguration = antennaConfiguration;
                    this.rOReportSpec = rOReportSpec;
                }
                else if (err_msg != null)
                {
                    Console.WriteLine(err_msg.ToString());
                    _reader.Close();
                    return;
                }
                else
                {
                    Console.WriteLine("SET_READER_CONFIG Command Timed out");
                    _reader.Close();
                    return;
                }
            }
        }
        #endregion
    }
}
