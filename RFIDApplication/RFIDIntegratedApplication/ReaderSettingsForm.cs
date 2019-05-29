using Org.LLRP.LTK.LLRPV1.DataType;
using RFIDIntegratedApplication.Reader;
using RFIDIntegratedApplication.Tag;
using RFIDIntegratedApplication.Utility;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using WeifenLuo.WinFormsUI.Docking;
using RFIDIntegratedApplication.ServiceReference1;

namespace RFIDIntegratedApplication
{
    public partial class ReaderSettingsForm : DockContent
    {
        MainForm _mainform;

        public ReaderSettingsForm(MainForm mainform)
        {
            InitializeComponent();

            this._mainform = mainform;
        }

        /// <summary>
        /// Update the status of components in ReaderSettingsForm according to different situations
        /// </summary>
        /// <param name="flag">indicates inventorying state: 0: start inventorying; 1: stop inventorying</param>
        /// <param name="isInitial">indicates whether it is in an initial state</param>
        public void UpdateComponentStatus(int flag, bool isInitial)
        {
            if (flag == 0)
            {
                //------Initialize components when loading or Start inventorying------
                //Basic Settings
                cbResetToFactoryDefault.Enabled = false;
                gbReadMode.Enabled = false;
                gbFrequencyInfo.Enabled = false;

                //Antenna Settings
                gbC1G2InventoryCommand.Enabled = false;
                cbAntenna1.Enabled = false;
                cbAntenna2.Enabled = false;
                cbAntenna3.Enabled = false;
                cbAntenna4.Enabled = false;
                cbReceiverSensitivity1.Enabled = false;
                cbTransmiterPower1.Enabled = false;
                cbReceiverSensitivity2.Enabled = false;
                cbTransmiterPower2.Enabled = false;
                cbReceiverSensitivity3.Enabled = false;
                cbTransmiterPower3.Enabled = false;
                cbReceiverSensitivity4.Enabled = false;
                cbTransmiterPower4.Enabled = false;

                //RoSpec Settings
                cbROReportTrigger.Enabled = false;
                nudN.Enabled = false;
                gbTagReportContentSelector.Enabled = false;
                gbImpinjTagReportContentSelector.Enabled = false;

                if (isInitial)
                {
                    tbxMAC1.Enabled = false;
                    tbxMAC2.Enabled = false;
                    tbxMAC3.Enabled = false;

                    gbTagFilter.Enabled = false;
                 
                }
                else
                {
                    gbAddress.Enabled = false;
                }

                if (RFIDReaderParameter.ReadMode == "Timer")
                {
                    gbTagFilter.Enabled = false;
                }
            }
            else
            {
                //------Connect to the reader successfully or Stop inventorying------
                //Basic Settings
                cbResetToFactoryDefault.Enabled = true;
                gbReadMode.Enabled = true;
                gbFrequencyInfo.Enabled = true;
                gbTagFilter.Enabled = true;

                //Antenna Settings
                gbC1G2InventoryCommand.Enabled = true;
                //ImpinJ reader can tell which antenna is connected, so there is no need to set all antenna true
                // Frequency Independent Settings
                CheckBox[] checkboxs = new CheckBox[] { cbAntenna1, cbAntenna2, cbAntenna3, cbAntenna4 };
                ComboBox[] comboboxReces = new ComboBox[] { cbReceiverSensitivity1, cbReceiverSensitivity2, cbReceiverSensitivity3, cbReceiverSensitivity4 };
                ComboBox[] comboboxTrans = new ComboBox[] { cbTransmiterPower1, cbTransmiterPower2, cbTransmiterPower3, cbTransmiterPower4 };
                GetAntennaIndependentSettings(checkboxs, comboboxReces, comboboxTrans);

                //RoSpec Settings
                cbROReportTrigger.Enabled = true;
                nudN.Enabled = true;
                gbTagReportContentSelector.Enabled = true;
                gbImpinjTagReportContentSelector.Enabled = true;

                if (isInitial)
                {
                    gbAddress.Enabled = false;
                    tbxDuration.Enabled = false;
                }
            }

        }

        /// <summary>
        /// When a tag with new EPC comes, add it to the mask and extra mask combobox
        /// </summary>
        /// <param name="tagInfo"></param>
        public void UpdateTagFilter(TagInfo tagInfo)
        {
          /*  if (!cbMask.Items.Contains(tagInfo.EPC))
                cbMask.Items.Add(tagInfo.EPC);
            if (!cbExtraMask.Items.Contains(tagInfo.EPC))
                cbExtraMask.Items.Add(tagInfo.EPC);*/
        }

        /// <summary>
        /// Get reader address from ReaderSettingsForm
        /// </summary>
        public string GetReaderAddress()
        {
            string address = "";

            if (rbtnIP.Checked)
            {
                if (tbxIP.Text == String.Empty)
                {
                    MessageBox.Show("Please Input IP Address!");
                    return String.Empty;
                }
                RFIDReaderParameter.IP = tbxIP.Text.Trim();
                address = RFIDReaderParameter.IP;
            }
            else if (rbtnHostname.Checked)
            {
                if (tbxMAC1.Text == String.Empty || tbxMAC2.Text == String.Empty || tbxMAC3.Text == String.Empty)
                {
                    MessageBox.Show("Please complete Hostname!");
                    return String.Empty;
                }
                RFIDReaderParameter.Hostname = String.Format(@"speedwayr-{0}-{1}-{2}.local", tbxMAC1.Text.Trim(), tbxMAC2.Text.Trim(), tbxMAC3.Text.Trim());
                address = RFIDReaderParameter.Hostname;
            }

            return address;
        }

        /// <summary>
        /// Get Antenna Indepedent Settings
        /// </summary>
        /// <param name="check">Coresponding Antenna CheckBox</param>
        /// <param name="comboRece">Coresponding Receiver Sensitivity ComboBox</param>
        /// <param name="comboTrans">Coresponding Transimter Power ComboBox</param>
        /// <param name="antennaID">Coresponding Antenna ID</param>
        /// 
        bool firstSet = true;
        bool[] oldCheck;
        public void GetAntennaIndependentSettings(CheckBox[] check, ComboBox[] comboRece, ComboBox[] comboTrans)
        {
            if (firstSet)
            {
                oldCheck = new bool[RFIDReaderParameter.antennaConfiguration.AntennaConnected.Length];
                Array.Copy(RFIDReaderParameter.antennaConfiguration.AntennaConnected, oldCheck, oldCheck.Length);
            }
            firstSet = false;
            if (RFIDReaderParameter.antennaConfiguration.AntennaID != null)
            {
                for (int i = 0; i < RFIDReaderParameter.antennaConfiguration.AntennaID.Length; i++)
                {
                    check[i].Checked = RFIDReaderParameter.antennaConfiguration.AntennaConnected[i];
                    check[i].Enabled = oldCheck[i];
                    comboRece[i].Enabled = oldCheck[i];
                    comboTrans[i].Enabled = oldCheck[i];
                    if (check[i].Checked && comboRece[i].Items.Count == 0)
                    {
                        tabControlAntenna.SelectedIndex = i;
                        foreach (KeyValuePair<short, ushort> rs in RFIDReaderParameter.readerCapabilities.ReceiveSensitivityDic)
                        {
                            if (rs.Value == RFIDReaderParameter.antennaConfiguration.SelectedReceiverSensitivityIndex[i])
                                comboRece[i].Text = rs.Key.ToString();
                            comboRece[i].Items.Add(rs.Key.ToString());
                        }

                        foreach (KeyValuePair<double, ushort> power in RFIDReaderParameter.readerCapabilities.TransmiterPowerDic)
                        {
                            if (power.Value == RFIDReaderParameter.antennaConfiguration.SelectedTransmiterPowerIndex[i])
                                comboTrans[i].Text = power.Key.ToString();
                            comboTrans[i].Items.Add(power.Key.ToString());
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Receive Configurations from RFIDReaderParameter
        /// </summary>
        public void ReceiveConfigFromRFIDReaderPara()
        {
            //------Initialize Basic Settings------
            cbResetToFactoryDefault.Checked = RFIDReaderParameter.Reset;
            tbxDuration.Text = RFIDReaderParameter.Duration.ToString();

            if (cbFreqMode.Items.Count > 0)
            {
                cbFreqMode.Items.Clear();
            }
            // Frequency Mode
            for (int i = 0; i < RFIDReaderParameter.readerCapabilities.FixedFrequencyModeTable.Length; i++)
            {
                if (RFIDReaderParameter.readerCapabilities.FixedFrequencyModeTable[i] == "Disabled")
                {
                    cbFreqMode.Text = "Disabled";
                    nudHop.Enabled = false;
                }

                cbFreqMode.Items.Add(RFIDReaderParameter.readerCapabilities.FixedFrequencyModeTable[i]);
            }
            // Frequency Set
            if(clbFreqSet.Items.Count > 0)
            {
                clbFreqSet.Items.Clear();
            }
            foreach (KeyValuePair<ushort, double> freq in RFIDReaderParameter.readerCapabilities.FrequencyDic)
            {
                clbFreqSet.Items.Add(freq.Key + " - " + freq.Value + " MHz");
                if (freq.Key == 1)
                    clbFreqSet.SetItemChecked(clbFreqSet.Items.Count - 1, true);
            }
            //------Initialize Basic Settings------

            //------Initialize Antenna Settings------
            // Tag Inventory State Aware
            cbTagInventoryStateAware.Text = RFIDReaderParameter.antennaConfiguration.TagInventoryStateAware.ToString();
            // C1G2 RF Control
            RFIDReaderParameter.antennaConfiguration.ModeIndex = 0;
            foreach (uint index in RFIDReaderParameter.readerCapabilities.SupportedModeIndex)
            {
                foreach (KeyValuePair<string, ushort> mode in RFIDReaderParameter.readerCapabilities.PreDefinedModeTable)
                {
                    if (mode.Value == index)
                    {
                        if (index == RFIDReaderParameter.antennaConfiguration.ModeIndex)
                            cbModeIndex.Text = mode.Key;
                        cbModeIndex.Items.Add(mode.Key);
                    }
                }
            }
            tbxTari.Text = RFIDReaderParameter.antennaConfiguration.Tari.ToString();
            // C1G2 Sigulation Control
            if(cbSession.Items.Count > 0)
            {
                cbSession.Items.Clear();
            }
            foreach (string session in RFIDReaderParameter.readerCapabilities.Sessions.Keys)
            {
                cbSession.Items.Add(session);
            }
            cbSession.Text = RFIDReaderParameter.antennaConfiguration.SelectedSession;
            tbxTagPopulation.Text = RFIDReaderParameter.antennaConfiguration.TagPopulation.ToString();
            tbxTagTransitTime.Text = RFIDReaderParameter.antennaConfiguration.TagTransitTime.ToString();
            // ImpinJ
            if(cbImpiJSearchMode.Items.Count > 0)
            {
                cbImpiJSearchMode.Items.Clear();
            }
            for (int i = 0; i < RFIDReaderParameter.readerCapabilities.SearchModeTable.Length; i++)
            {
                cbImpiJSearchMode.Items.Add(RFIDReaderParameter.readerCapabilities.SearchModeTable[i]);
            }
            cbImpiJSearchMode.Text = RFIDReaderParameter.antennaConfiguration.SelectedSearchMode;

            cbImpinjReducedPowerFrequencyMode.Checked = RFIDReaderParameter.antennaConfiguration.ReducedPowerFrequencyMode;
            if (RFIDReaderParameter.antennaConfiguration.ReducedPowerChannelList != null)
                tbxReducedChannelList.Text = RFIDReaderParameter.antennaConfiguration.ReducedPowerChannelList.ToString();
            cbImpinjLowDutyCycleMode.Checked = RFIDReaderParameter.antennaConfiguration.LowDutyCycleMode;
            tbxEmptyFieldTimeout.Text = RFIDReaderParameter.antennaConfiguration.EmptyFieldTimeout.ToString();
            tbxFieldPingInterval.Text = RFIDReaderParameter.antennaConfiguration.FieldPingInterval.ToString();
            // Frequency Independent Settings
            CheckBox[] checkboxs = new CheckBox[] { cbAntenna1, cbAntenna2, cbAntenna3, cbAntenna4 };
            ComboBox[] comboboxReces = new ComboBox[] { cbReceiverSensitivity1, cbReceiverSensitivity2, cbReceiverSensitivity3, cbReceiverSensitivity4 };
            ComboBox[] comboboxTrans = new ComboBox[] { cbTransmiterPower1, cbTransmiterPower2, cbTransmiterPower3, cbTransmiterPower4 };
            GetAntennaIndependentSettings(checkboxs, comboboxReces, comboboxTrans);
            //------Initialize Antenna Settings------

            //-----Reader Operation Report Sepc-------
            // Reader Operation Report Trigger
            for (int i = 0; i < RFIDReaderParameter.readerCapabilities.ROReportTrigger.Length; i++)
            {
                cbROReportTrigger.Items.Add(RFIDReaderParameter.readerCapabilities.ROReportTrigger[i]);
            }
            cbROReportTrigger.Text = RFIDReaderParameter.rOReportSpec.SelectedROReportTrigger;
            // Tag Report Content Selector
            cbEnableROSpecID.Checked = RFIDReaderParameter.rOReportSpec.EnableROSpecID;
            cbEnableSpecIndex.Checked = RFIDReaderParameter.rOReportSpec.EnableSpecIndex;
            cbEnableInventoryParameterSpecID.Checked = RFIDReaderParameter.rOReportSpec.EnableInventoryParameterSPecID;
            cbEnableAntennaID.Checked = RFIDReaderParameter.rOReportSpec.EnableAntennaID;
            cbEnableChannelIndex.Checked = RFIDReaderParameter.rOReportSpec.EnableChannelIndex;
            cbEnablePeakRSSI.Checked = RFIDReaderParameter.rOReportSpec.EnablePeakRSSI;
            cbEnableFirstSeenTimestamp.Checked = RFIDReaderParameter.rOReportSpec.EnableFirstSeenTimestamp;
            cbEnableLastSeenTimestamp.Checked = RFIDReaderParameter.rOReportSpec.EnableLastSeenTimestamp;
            cbEnableTagSeenCount.Checked = RFIDReaderParameter.rOReportSpec.EnableTagSeenCount;
            cbEnableAccessSpecID.Checked = RFIDReaderParameter.rOReportSpec.EnableAccessSpecID;
            cbEnableCRC.Checked = RFIDReaderParameter.rOReportSpec.EnableCRC;
            cbEnablePCBits.Checked = RFIDReaderParameter.rOReportSpec.EnablePCbits;

            // ImpinJ Tag Report Content Selector
            cbImpinjEnableSerializedTID.Checked = RFIDReaderParameter.rOReportSpec.ImpinJEnableSerializedTID;
            cbImpinjEnableRFPhaseAngle.Checked = RFIDReaderParameter.rOReportSpec.ImpinJEnableRFPhaseAngle;
            cbImpinjEnablePeakRSSI.Checked = RFIDReaderParameter.rOReportSpec.ImpinJEnablePeakRSSI;
            cbImpinjEnableGPSCoordinates.Checked = RFIDReaderParameter.rOReportSpec.ImpinJEnableGPSCoordinates;
            cbImpinjEnableOptimizedRead.Checked = RFIDReaderParameter.rOReportSpec.ImpinJEnableOptimizedRead;
            cbImpinjEnableRFDopplerFrequency.Checked = RFIDReaderParameter.rOReportSpec.ImpinJEnableRFDopplerFrequency;
            //-----Reader Operation Report Sepc-------
        }

        /// <summary>
        /// Set Antenna Indepedent Settings
        /// </summary>
        /// <param name="check">Coresponding Antenna CheckBox</param>
        /// <param name="comboRece">Coresponding Receiver Sensitivity ComboBox</param>
        /// <param name="comboTrans">Coresponding Antenna ID</param>
        public void SetAntennaIndependentSettings(CheckBox[] check, ComboBox[] comboRece, ComboBox[] comboTrans)
        {
            RFIDReaderParameter.antennaConfiguration.NumberOfAntennaConnected = 0;
            for (int i = 0; i < check.Length; i++)
            {
                if (check[i].Checked)
                {
                    ushort antennaID = (ushort)(i + 1);
                    RFIDReaderParameter.antennaConfiguration.NumberOfAntennaConnected++;
                    RFIDReaderParameter.antennaConfiguration.AntennaID[i] = antennaID;
                    RFIDReaderParameter.antennaConfiguration.SelectedReceiverSensitivity[i] = Convert.ToInt16(comboRece[i].Text.Trim());
                    RFIDReaderParameter.antennaConfiguration.SelectedReceiverSensitivityIndex[i] =
                                             RFIDReaderParameter.readerCapabilities.ReceiveSensitivityDic[RFIDReaderParameter.antennaConfiguration.SelectedReceiverSensitivity[i]];
                    RFIDReaderParameter.antennaConfiguration.SelectedTransmiterPower[i] = Convert.ToDouble(comboTrans[i].Text.Trim());
                    RFIDReaderParameter.antennaConfiguration.SelectedTransmiterPowerIndex[i] =
                                             RFIDReaderParameter.readerCapabilities.TransmiterPowerDic[RFIDReaderParameter.antennaConfiguration.SelectedTransmiterPower[i]];
                }
                RFIDReaderParameter.antennaConfiguration.AntennaConnected[i] = check[i].Checked;
            }
        }

        /// <summary>
        /// Before starting inventorying, get parameters from ReaderSettingsFrom and Save them in the RFIDReaderParameter
        /// </summary>
        /// <returns>if sending successfully, return true; otherwise, return false</returns>
        public bool SendConfigToRFIDReaderPara()
        {
            //------Basic Settings------
            RFIDReaderParameter.Reset = cbResetToFactoryDefault.Checked;
            // Read Mode
            if (rbtnManualReadMode.Checked)
            {
                RFIDReaderParameter.ReadMode = "Manual";
            }
            else
            {
                RFIDReaderParameter.ReadMode = "Timer";
                if (tbxDuration.Text.Trim() == String.Empty)
                {
                    MessageBox.Show("Please input duration for timer mode", "Reader Settings Error");
                    return false;
                }
                else if (Convert.ToUInt32(tbxDuration.Text) == 0)
                {
                    MessageBox.Show("Duration for timer mode should be larger than 0", "Reader Settings Error");
                    return false;
                }
                else
                {
                    RFIDReaderParameter.Duration = Convert.ToUInt32(tbxDuration.Text);
                }
            }
            // Frequency Information
            RFIDReaderParameter.antennaConfiguration.FixedFrequencyMode = cbFreqMode.Text;
            if (RFIDReaderParameter.antennaConfiguration.FixedFrequencyMode != "Disabled")
            {
                RFIDReaderParameter.antennaConfiguration.Hopping = true;
                RFIDReaderParameter.antennaConfiguration.HoppingStep = Convert.ToUInt16(nudHop.Value);
                RFIDReaderParameter.antennaConfiguration.FixedChannelList = new UInt16Array();
                UInt16Array channelList = new UInt16Array();

                if (clbFreqSet.CheckedIndices.Count < 2)
                {
                    MessageBox.Show("Must choose at least 2 frequencies", "Reader Settings Error");
                    return false;
                }
                else
                {
                    for (int i = 0; i < clbFreqSet.CheckedIndices.Count; i++)
                    {
                        channelList.Add((ushort)(clbFreqSet.CheckedIndices[i] + 1));
                    }

                    if (RFIDReaderParameter.antennaConfiguration.HoppingStep <= 0)
                    {
                        MessageBox.Show("HoppingStep must be larger than 0", "Reader Settings Error");
                        return false;
                    }
                    else if (RFIDReaderParameter.antennaConfiguration.HoppingStep >= channelList.Count)
                    {
                        MessageBox.Show("HoppingStep must be smaller than Chosen List", "Reader Settings Error");
                        return false;
                    }
                    else
                    {
                        int len = channelList.Count;
                        RFIDReaderParameter.antennaConfiguration.FixedChannelList.Add(channelList[0]);
                        for (int i = 1; i < len; i++)
                        {
                            int nextIndex = (0 + i * RFIDReaderParameter.antennaConfiguration.HoppingStep) % len;
                            if (nextIndex == 0) break;
                            RFIDReaderParameter.antennaConfiguration.FixedChannelList.Add(channelList[nextIndex]);
                        }
                    }
                }
            }
            else
            {
                RFIDReaderParameter.antennaConfiguration.Hopping = false;
                RFIDReaderParameter.antennaConfiguration.HoppingStep = 0;
                if (clbFreqSet.CheckedIndices.Count < 1)
                {
                    MessageBox.Show("Please choose one frequency!");
                    return false;
                }
                else if (clbFreqSet.CheckedIndices.Count > 1)
                {
                    MessageBox.Show("Can only choose one frequency!");
                    return false;
                }
                else
                {
                    RFIDReaderParameter.antennaConfiguration.ChannelIndex = (ushort)(clbFreqSet.CheckedIndices[0] + 1);
                }
            }
            // Tag Filter
            RFIDReaderParameter.antennaConfiguration.mask = this.includeTextBox.Text;
          //  RFIDReaderParameter.antennaConfiguration.extraMask = this.excludeTextBox.Text;
            //------Basic Settings------

            //------Antenna Settings------
            RFIDReaderParameter.antennaConfiguration.TagInventoryStateAware = Convert.ToBoolean(cbTagInventoryStateAware.Text);
            // C1G2 RF Control
            RFIDReaderParameter.antennaConfiguration.ModeIndex = RFIDReaderParameter.readerCapabilities.PreDefinedModeTable[cbModeIndex.Text];
            if (tbxTari.Text.Trim() == String.Empty)
            {
                MessageBox.Show("Please Input Tari!", "Reader Settings Error");
                return false;
            }
            else
            {
                RFIDReaderParameter.antennaConfiguration.Tari = Convert.ToUInt16(tbxTari.Text);
            }
            // C1G2 Singulation Control
            RFIDReaderParameter.antennaConfiguration.SelectedSession = cbSession.Text;
            RFIDReaderParameter.antennaConfiguration.SelectedSessionIndex = RFIDReaderParameter.readerCapabilities.Sessions[cbSession.Text];
            if (tbxTagPopulation.Text.Trim() == String.Empty)
            {
                MessageBox.Show("Please Input Tag Population!", "Reader Settings Error");
                return false;
            }
            else
            {

                RFIDReaderParameter.antennaConfiguration.TagPopulation = Convert.ToUInt16(tbxTagPopulation.Text);
            }
            if (tbxTagTransitTime.Text.Trim() == String.Empty)
            {
                MessageBox.Show("Please Input Tag Transit Time!", "Reader Settings Error");
                return false;
            }
            else
            {
                RFIDReaderParameter.antennaConfiguration.TagTransitTime = Convert.ToUInt16(tbxTagTransitTime.Text);
            }
            //ImpinJ
            RFIDReaderParameter.antennaConfiguration.SelectedSearchMode = cbImpiJSearchMode.Text;
            RFIDReaderParameter.antennaConfiguration.ReducedPowerFrequencyMode = cbImpinjReducedPowerFrequencyMode.Checked;
            if (cbImpinjReducedPowerFrequencyMode.Checked)
            {
                if (tbxReducedChannelList.Text.Trim() == String.Empty)
                {
                    MessageBox.Show("Please Input Channel List!");
                    return false;
                }
                else
                {
                    string[] strs = tbxReducedChannelList.Text.Trim().Split(',');
                    UInt16Array channels = new UInt16Array();
                    for (int i = 0; i < strs.Length; i++)
                    {
                        channels.Add(Convert.ToUInt16(strs[i]));
                    }
                    RFIDReaderParameter.antennaConfiguration.ReducedPowerChannelList = channels;
                }
            }
            else
            {
                RFIDReaderParameter.antennaConfiguration.ReducedPowerChannelList = UInt16Array.FromString(String.Empty);
            }
            RFIDReaderParameter.antennaConfiguration.LowDutyCycleMode = cbImpinjLowDutyCycleMode.Checked;
            if (cbImpinjLowDutyCycleMode.Checked)
            {
                if (tbxEmptyFieldTimeout.Text.Trim() == String.Empty)
                {
                    MessageBox.Show("Please Input Empty Field Timeout!");
                    return false;
                }
                else
                {
                    RFIDReaderParameter.antennaConfiguration.EmptyFieldTimeout = Convert.ToUInt16(tbxEmptyFieldTimeout.Text);
                }

                if (tbxFieldPingInterval.Text.Trim() == String.Empty)
                {
                    MessageBox.Show("Please Input Field Ping Interval!");
                    return false;
                }
                else
                {
                    RFIDReaderParameter.antennaConfiguration.FieldPingInterval = Convert.ToUInt16(tbxFieldPingInterval.Text);
                }
            }
            else
            {
                RFIDReaderParameter.antennaConfiguration.EmptyFieldTimeout = 0;
                RFIDReaderParameter.antennaConfiguration.FieldPingInterval = 0;
            }
            // Antenna Independent Settings
            if (!cbAntenna1.Checked && !cbAntenna2.Checked && !cbAntenna3.Checked && !cbAntenna4.Checked)
            {
                MessageBox.Show("Please choose at least one Antenna!");
                return false;
            }
            else
            {
                CheckBox[] checkboxs = new CheckBox[] { cbAntenna1, cbAntenna2, cbAntenna3, cbAntenna4 };
                ComboBox[] comboboxReces = new ComboBox[] { cbReceiverSensitivity1, cbReceiverSensitivity2, cbReceiverSensitivity3, cbReceiverSensitivity4 };
                ComboBox[] comboboxTrans = new ComboBox[] { cbTransmiterPower1, cbTransmiterPower2, cbTransmiterPower3, cbTransmiterPower4 };
                SetAntennaIndependentSettings(checkboxs, comboboxReces, comboboxTrans);
            }
            //------Antenna Confiuration------

            //-----Reader Operation Report Sepc-------
            RFIDReaderParameter.rOReportSpec.SelectedROReportTrigger = cbROReportTrigger.Text;
            RFIDReaderParameter.rOReportSpec.ROReportTriggerN = Convert.ToUInt16(nudN.Value);
            // Tag Report Content Selector
            RFIDReaderParameter.rOReportSpec.EnableROSpecID = cbEnableROSpecID.Checked;
            RFIDReaderParameter.rOReportSpec.EnableSpecIndex = cbEnableSpecIndex.Checked;
            RFIDReaderParameter.rOReportSpec.EnableInventoryParameterSPecID = cbEnableInventoryParameterSpecID.Checked;
            RFIDReaderParameter.rOReportSpec.EnableAntennaID = cbEnableAntennaID.Checked;
            RFIDReaderParameter.rOReportSpec.EnableChannelIndex = cbEnableChannelIndex.Checked;
            RFIDReaderParameter.rOReportSpec.EnablePeakRSSI = cbEnablePeakRSSI.Checked;
            RFIDReaderParameter.rOReportSpec.EnableFirstSeenTimestamp = cbEnableFirstSeenTimestamp.Checked;
            RFIDReaderParameter.rOReportSpec.EnableLastSeenTimestamp = cbEnableLastSeenTimestamp.Checked;
            RFIDReaderParameter.rOReportSpec.EnableTagSeenCount = cbEnableTagSeenCount.Checked;
            RFIDReaderParameter.rOReportSpec.EnableAccessSpecID = cbEnableAccessSpecID.Checked;
            RFIDReaderParameter.rOReportSpec.EnableCRC = cbEnableCRC.Checked;
            RFIDReaderParameter.rOReportSpec.EnablePCbits = cbEnablePCBits.Checked;
            // ImpinJ Tag Report Content Selector
            RFIDReaderParameter.rOReportSpec.ImpinJEnableSerializedTID = cbImpinjEnableSerializedTID.Checked;
            RFIDReaderParameter.rOReportSpec.ImpinJEnableRFPhaseAngle = cbImpinjEnableRFPhaseAngle.Checked;
            RFIDReaderParameter.rOReportSpec.ImpinJEnablePeakRSSI = cbImpinjEnablePeakRSSI.Checked;
            RFIDReaderParameter.rOReportSpec.ImpinJEnableGPSCoordinates = cbImpinjEnableGPSCoordinates.Checked;
            RFIDReaderParameter.rOReportSpec.ImpinJEnableOptimizedRead = cbImpinjEnableOptimizedRead.Checked;
            RFIDReaderParameter.rOReportSpec.ImpinJEnableRFDopplerFrequency = cbImpinjEnableRFDopplerFrequency.Checked;
            //-----Reader Operation Report Sepc-------
            return true;
        }

        private void rbtnIP_CheckedChanged(object sender, EventArgs e)
        {
            tbxIP.Enabled = true;
            tbxMAC1.Enabled = false;
            tbxMAC2.Enabled = false;
            tbxMAC3.Enabled = false;
        }

        private void rbtnHostname_CheckedChanged(object sender, EventArgs e)
        {
            tbxIP.Enabled = false;
            tbxMAC1.Enabled = true;
            tbxMAC2.Enabled = true;
            tbxMAC3.Enabled = true;
        }

        private void rbtnManualReadMode_CheckedChanged(object sender, EventArgs e)
        {
            tbxDuration.Enabled = false;
        }

        private void rbtnTimerReadMode_CheckedChanged(object sender, EventArgs e)
        {
            tbxDuration.Enabled = true;
            if (tbxDuration.Text == "0")
            {
                MessageBox.Show("Duration should not be 0 ms!", "Timer Duration Error");
            }
        }

        private void cbFreqMode_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbFreqMode.Text.Trim() != "Disabled")
            {
                for (int i = 0; i < clbFreqSet.Items.Count; i++)
                {
                    clbFreqSet.SetItemChecked(i, true);
                }

                if (cbFreqMode.Text.Trim() == "Channel_List")
                {
                    clbFreqSet.Enabled = true;
                    nudHop.Enabled = true;
                    nudHop.Value = 1;
                    if (nudHop.Value == 0)
                    {
                        MessageBox.Show("Hop step should not be 0!");
                    }
                }
                else
                {
                    clbFreqSet.Enabled = false;
                    nudHop.Enabled = false;
                    nudHop.Value = 4;
                }


            }
            else
            {
                for (int i = 1; i < clbFreqSet.Items.Count; i++)
                {
                    clbFreqSet.SetItemChecked(i, false);
                }
                nudHop.Enabled = false;
            }
        }

        private void cbMask_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (RFIDReaderParameter.ReadMode != "Timer")
            {
                _mainform.stop();
                _mainform.start();
            }
        }

        private void cbExtraMask_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (RFIDReaderParameter.ReadMode != "Timer")
            {
                _mainform.stop();
                _mainform.start();
            }
        }

        private void cbImpinjReducedPowerFrequencyMode_CheckedChanged(object sender, EventArgs e)
        {
            if (cbImpinjReducedPowerFrequencyMode.Checked)
            {
                lblReducedChannelList.Enabled = true;
                tbxReducedChannelList.Enabled = true;
            }
            else
            {
                lblReducedChannelList.Enabled = false;
                tbxReducedChannelList.Enabled = false;
            }
        }

        private void cbImpinjLowDutyCycleMode_CheckedChanged(object sender, EventArgs e)
        {
            if (cbImpinjLowDutyCycleMode.Checked)
            {
                lblEmptyFieldTimeout.Enabled = true;
                tbxEmptyFieldTimeout.Enabled = true;
                lblFieldPingInterval.Enabled = true;
                tbxFieldPingInterval.Enabled = true;
            }
            else
            {
                lblEmptyFieldTimeout.Enabled = false;
                tbxEmptyFieldTimeout.Enabled = false;
                lblFieldPingInterval.Enabled = false;
                tbxFieldPingInterval.Enabled = false;
            }
        }

        private void ReaderSettingsFrom_DockStateChanged(object sender, EventArgs e)
        {
            if (this.DockState == DockState.Unknown || this.DockState == DockState.Hidden)
            {
                return;
            }
            AppConfig.readerSettingsDockState = this.DockState;
        }

        private void ReaderSettingsFrom_Load(object sender, EventArgs e)
        {
            //Properties.Settings.Default.Reset();
            //Retrieve information from user's settings
            tbxIP.Text = Properties.Settings.Default.IP;
            if (Properties.Settings.Default.Hostname != String.Empty)
            {
                string[] macs = Properties.Settings.Default.Hostname.Split('-');
                tbxMAC1.Text = macs[1];
                tbxMAC2.Text = macs[2];
                tbxMAC3.Text = macs[3].Split('.')[0];
            }

            //Set rfid reader parameter from user's settings
            RFIDReaderParameter.IP = Properties.Settings.Default.IP;
            RFIDReaderParameter.MAC = Properties.Settings.Default.MAC;
            RFIDReaderParameter.Hostname = Properties.Settings.Default.Hostname;
        }

        private void nudHop_ValueChanged(object sender, EventArgs e)
        {

        }

        private void cbResetToFactoryDefault_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void tbxDuration_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnSearchIP_Click(object sender, EventArgs e)
        {
            if (_mainform.connect())
            {
                ReceiveConfigFromRFIDReaderPara();
                UpdateComponentStatus(1, true);
            }
        }

        private void gbAddress_Enter(object sender, EventArgs e)
        {

        }

        private void cbAntenna1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void tbxReducedChannelList_TextChanged(object sender, EventArgs e)
        {

        }

        private void cbModeIndex_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cbTagInventoryStateAware_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void clbFreqSet_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cbSession_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cbImpiJSearchMode_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cbReceiverSensitivity1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
