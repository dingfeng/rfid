using BasicApplication.Reader;
using Org.LLRP.LTK.LLRPV1;
using Org.LLRP.LTK.LLRPV1.DataType;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BasicApplication
{
    public partial class MoreSettingsForm : Form
    {
        MainForm _mainform;

        public MoreSettingsForm()
        {
            InitializeComponent();
        }

        public MoreSettingsForm(MainForm mainform)
        {
            InitializeComponent();
            this._mainform = mainform;
        }

        /// <summary>
        /// Get Antenna Indepedent Settings
        /// </summary>
        /// <param name="check">Coresponding Antenna CheckBox</param>
        /// <param name="comboRece">Coresponding Receiver Sensitivity ComboBox</param>
        /// <param name="comboTrans">Coresponding Transimter Power ComboBox</param>
        /// <param name="antennaID">Coresponding Antenna ID</param>
        public void GetAntennaIndependentSettings(CheckBox[] check, ComboBox[] comboRece, ComboBox[] comboTrans)
        {
            if (RFIDReaderParameter.AntennaConfiguration.AntennaID != null)
            {
                for (int i = 0; i < RFIDReaderParameter.AntennaConfiguration.AntennaID.Length; i++)
                {
                    check[i].Checked = RFIDReaderParameter.AntennaConfiguration.AntennaConnected[i];
                    if (!check[i].Checked)
                    {
                        comboRece[i].Enabled = false;
                        comboTrans[i].Enabled = false;
                    }
                    else
                    {
                        tabControlAntenna.SelectedIndex = i;
                        foreach (KeyValuePair<short, ushort> rs in RFIDReaderParameter.ReaderCapabilities.ReceiveSensitivityDic)
                        {
                            if (rs.Value == RFIDReaderParameter.AntennaConfiguration.SelectedReceiverSensitivityIndex[i])
                                comboRece[i].Text = rs.Key.ToString();
                            comboRece[i].Items.Add(rs.Key.ToString());
                        }

                        foreach (KeyValuePair<double, ushort> power in RFIDReaderParameter.ReaderCapabilities.TransmiterPowerDic)
                        {
                            if (power.Value == RFIDReaderParameter.AntennaConfiguration.SelectedTransmiterPowerIndex[i])
                                comboTrans[i].Text = power.Key.ToString();
                            comboTrans[i].Items.Add(power.Key.ToString());
                        }
                    }


                }
            }
        }

        /// <summary>
        /// Receive Configurations from Mainfrom through RFIDReaderParameter
        /// </summary>
        public void ReceiveConfigFromMainForm()
        {
            //Initialize More Settings
            CheckBox[] checkboxs = new CheckBox[] { cbAntenna1, cbAntenna2, cbAntenna3, cbAntenna4 };
            ComboBox[] comboboxReces = new ComboBox[] { cbReceiverSensitivity1, cbReceiverSensitivity2, cbReceiverSensitivity3, cbReceiverSensitivity4 };
            ComboBox[] comboboxTrans = new ComboBox[] { cbTransmiterPower1, cbTransmiterPower2, cbTransmiterPower3, cbTransmiterPower4 };
            GetAntennaIndependentSettings(checkboxs, comboboxReces, comboboxTrans);

            foreach (uint index in RFIDReaderParameter.ReaderCapabilities.SupportedModeIndex)
            {
                foreach (KeyValuePair<string, ushort> mode in RFIDReaderParameter.ReaderCapabilities.PreDefinedModeTable)
                {
                    if (mode.Value == index)
                    {
                        if (index == RFIDReaderParameter.AntennaConfiguration.ModeIndex)
                            cbModeIndex.Text = mode.Key;
                        cbModeIndex.Items.Add(mode.Key);
                    }
                }
            }

            for (int i = 0; i < RFIDReaderParameter.ReaderCapabilities.SearchModeTable.Length; i++)
            {
                if (RFIDReaderParameter.ReaderCapabilities.SearchModeTable[i] == RFIDReaderParameter.AntennaConfiguration.SelectedSearchMode)
                    cbImpiJSearchMode.Text = RFIDReaderParameter.AntennaConfiguration.SelectedSearchMode;
                cbImpiJSearchMode.Items.Add(RFIDReaderParameter.ReaderCapabilities.SearchModeTable[i]);
            }

            foreach (string session in RFIDReaderParameter.ReaderCapabilities.Sessions.Keys)
            {
                if (session == RFIDReaderParameter.AntennaConfiguration.SelectedSession)
                    cbSession.Text = RFIDReaderParameter.AntennaConfiguration.SelectedSession;
                cbSession.Items.Add(session);
            }

            for (int i = 0; i < RFIDReaderParameter.ReaderCapabilities.ROReportTrigger.Length; i++)
            {
                if (RFIDReaderParameter.ReaderCapabilities.ROReportTrigger[i] == RFIDReaderParameter.ROReportSpec.SelectedROReportTrigger)
                    cbROReportTrigger.Text = RFIDReaderParameter.ROReportSpec.SelectedROReportTrigger;
                cbROReportTrigger.Items.Add(RFIDReaderParameter.ReaderCapabilities.ROReportTrigger[i]);
            }

            tbxTari.Text = RFIDReaderParameter.AntennaConfiguration.Tari.ToString();
            tbxTagPopulation.Text = RFIDReaderParameter.AntennaConfiguration.TagPopulation.ToString();
            tbxTagTransitTime.Text = RFIDReaderParameter.AntennaConfiguration.TagTransitTime.ToString();
            cbTagInventoryStateAware.Text = RFIDReaderParameter.AntennaConfiguration.TagInventoryStateAware.ToString();
            cbImpinjReducedPowerFrequencyMode.Checked = RFIDReaderParameter.AntennaConfiguration.ReducedPowerFrequencyMode;
            if (RFIDReaderParameter.AntennaConfiguration.ReducedPowerChannelList != null)
                tbxReducedChannelList.Text = RFIDReaderParameter.AntennaConfiguration.ReducedPowerChannelList.ToString();
            cbImpinjLowDutyCycleMode.Checked = RFIDReaderParameter.AntennaConfiguration.LowDutyCycleMode;
            tbxEmptyFieldTimeout.Text = RFIDReaderParameter.AntennaConfiguration.EmptyFieldTimeout.ToString();
            tbxFieldPingInterval.Text = RFIDReaderParameter.AntennaConfiguration.FieldPingInterval.ToString();


            //-----Reader Operation Report Sepc-------
            cbEnableROSpecID.Checked = RFIDReaderParameter.ROReportSpec.EnableROSpecID; 
            cbEnableSpecIndex.Checked =  RFIDReaderParameter.ROReportSpec.EnableSpecIndex;
            cbEnableInventoryParameterSpecID.Checked = RFIDReaderParameter.ROReportSpec.EnableInventoryParameterSPecID;
            cbEnableAntennaID.Checked = RFIDReaderParameter.ROReportSpec.EnableAntennaID;
            cbEnableChannelIndex.Checked = RFIDReaderParameter.ROReportSpec.EnableChannelIndex;
            cbEnablePeakRSSI.Checked = RFIDReaderParameter.ROReportSpec.EnablePeakRSSI;
            cbEnableFirstSeenTimestamp.Checked = RFIDReaderParameter.ROReportSpec.EnableFirstSeenTimestamp;
            cbEnableLastSeenTimestamp.Checked = RFIDReaderParameter.ROReportSpec.EnableLastSeenTimestamp;
            cbEnableTagSeenCount.Checked = RFIDReaderParameter.ROReportSpec.EnableTagSeenCount;
            cbEnableAccessSpecID.Checked = RFIDReaderParameter.ROReportSpec.EnableAccessSpecID;
            cbEnableCRC.Checked = RFIDReaderParameter.ROReportSpec.EnableCRC;
            cbEnablePCBits.Checked = RFIDReaderParameter.ROReportSpec.EnablePCbits;

            cbImpinjEnableSerializedTID.Checked = RFIDReaderParameter.ROReportSpec.ImpinJEnableSerializedTID;
            cbImpinjEnableRFPhaseAngle.Checked = RFIDReaderParameter.ROReportSpec.ImpinJEnableRFPhaseAngle;
            cbImpinjEnablePeakRSSI.Checked = RFIDReaderParameter.ROReportSpec.ImpinJEnablePeakRSSI;
            cbImpinjEnableGPSCoordinates.Checked = RFIDReaderParameter.ROReportSpec.ImpinJEnableGPSCoordinates;
            cbImpinjEnableOptimizedRead.Checked = RFIDReaderParameter.ROReportSpec.ImpinJEnableOptimizedRead;
            cbImpinjEnableRFDopplerFrequency.Checked = RFIDReaderParameter.ROReportSpec.ImpinJEnableRFDopplerFrequency;
        }

        /// <summary>
        /// Set Antenna Indepedent Settings
        /// </summary>
        /// <param name="check">Coresponding Antenna CheckBox</param>
        /// <param name="comboRece">Coresponding Receiver Sensitivity ComboBox</param>
        /// <param name="comboTrans">Coresponding Antenna ID</param>
        public void SetAntennaIndependentSettings(CheckBox[] check, ComboBox[] comboRece, ComboBox[] comboTrans)
        {
            for (int i = 0; i < check.Length; i++)
            {
                if (check[i].Checked)
                {
                    ushort antennaID = (ushort)(i + 1);
                    RFIDReaderParameter.AntennaConfiguration.AntennaID[i] = antennaID;
                    RFIDReaderParameter.AntennaConfiguration.AntennaConnected[i] = true;
                    RFIDReaderParameter.AntennaConfiguration.SelectedReceiverSensitivity[i] = Convert.ToInt16(comboRece[i].Text.Trim());
                    RFIDReaderParameter.AntennaConfiguration.SelectedReceiverSensitivityIndex[i] =
                                             RFIDReaderParameter.ReaderCapabilities.ReceiveSensitivityDic[RFIDReaderParameter.AntennaConfiguration.SelectedReceiverSensitivity[i]];
                    RFIDReaderParameter.AntennaConfiguration.SelectedTransmiterPower[i] = Convert.ToDouble(comboTrans[i].Text.Trim());
                    RFIDReaderParameter.AntennaConfiguration.SelectedTransmiterPowerIndex[i] =
                                             RFIDReaderParameter.ReaderCapabilities.TransmiterPowerDic[RFIDReaderParameter.AntennaConfiguration.SelectedTransmiterPower[i]];
                }

            }
        }

        /// <summary>
        /// Send Configurations to Mainfrom through RFIDReaderParameter
        /// </summary>
        public void SendConfigToMainForm()
        {
            //Get parameterd from MoreSettings form
            //------Antenna Confiuration------
            RFIDReaderParameter.AntennaConfiguration.TagInventoryStateAware = Convert.ToBoolean(cbTagInventoryStateAware.Text);
            RFIDReaderParameter.AntennaConfiguration.ModeIndex = RFIDReaderParameter.ReaderCapabilities.PreDefinedModeTable[cbModeIndex.Text];
            RFIDReaderParameter.AntennaConfiguration.Tari = Convert.ToUInt16(tbxTari.Text);
            RFIDReaderParameter.AntennaConfiguration.SelectedSession = cbSession.Text;
            RFIDReaderParameter.AntennaConfiguration.SelectedSessionIndex = RFIDReaderParameter.ReaderCapabilities.Sessions[cbSession.Text];
            RFIDReaderParameter.AntennaConfiguration.TagPopulation = Convert.ToUInt16(tbxTagPopulation.Text);
            RFIDReaderParameter.AntennaConfiguration.TagTransitTime = Convert.ToUInt16(tbxTagTransitTime.Text);
            RFIDReaderParameter.AntennaConfiguration.SelectedSearchMode = cbImpiJSearchMode.Text;

            RFIDReaderParameter.AntennaConfiguration.ReducedPowerFrequencyMode = cbImpinjReducedPowerFrequencyMode.Checked;
            if (cbImpinjReducedPowerFrequencyMode.Checked)
            {
                string[] strs = tbxReducedChannelList.Text.Trim().Split(',');
                UInt16Array channels = new UInt16Array();
                for (int i = 0; i < strs.Length; i++)
                {
                    channels.Add(Convert.ToUInt16(strs[i]));
                }
                RFIDReaderParameter.AntennaConfiguration.ReducedPowerChannelList = channels;
            }
            else
            {
                RFIDReaderParameter.AntennaConfiguration.ReducedPowerChannelList = UInt16Array.FromString(String.Empty);
            }

            RFIDReaderParameter.AntennaConfiguration.LowDutyCycleMode = cbImpinjLowDutyCycleMode.Checked;       
            if (cbImpinjLowDutyCycleMode.Checked)
            {
                RFIDReaderParameter.AntennaConfiguration.EmptyFieldTimeout = Convert.ToUInt16(tbxEmptyFieldTimeout.Text);
                RFIDReaderParameter.AntennaConfiguration.FieldPingInterval = Convert.ToUInt16(tbxFieldPingInterval.Text);
            }
            else
            {
                RFIDReaderParameter.AntennaConfiguration.EmptyFieldTimeout = 0;
                RFIDReaderParameter.AntennaConfiguration.FieldPingInterval = 0;
            }

            CheckBox[] checkboxs = new CheckBox[] { cbAntenna1, cbAntenna2, cbAntenna3, cbAntenna4 };
            ComboBox[] comboboxReces = new ComboBox[] { cbReceiverSensitivity1, cbReceiverSensitivity2, cbReceiverSensitivity3, cbReceiverSensitivity4 };
            ComboBox[] comboboxTrans = new ComboBox[] { cbTransmiterPower1, cbTransmiterPower2, cbTransmiterPower3, cbTransmiterPower4 };
            SetAntennaIndependentSettings(checkboxs, comboboxReces, comboboxTrans);
            //------Antenna Confiuration------

            //-----Reader Operation Report Sepc-------
            RFIDReaderParameter.ROReportSpec.SelectedROReportTrigger = cbROReportTrigger.Text;
            RFIDReaderParameter.ROReportSpec.ROReportTriggerN = Convert.ToUInt16(nudN.Value);

            RFIDReaderParameter.ROReportSpec.EnableROSpecID = cbEnableROSpecID.Checked;
            RFIDReaderParameter.ROReportSpec.EnableSpecIndex = cbEnableSpecIndex.Checked;
            RFIDReaderParameter.ROReportSpec.EnableInventoryParameterSPecID = cbEnableInventoryParameterSpecID.Checked;
            RFIDReaderParameter.ROReportSpec.EnableAntennaID = cbEnableAntennaID.Checked;
            RFIDReaderParameter.ROReportSpec.EnableChannelIndex = cbEnableChannelIndex.Checked;
            RFIDReaderParameter.ROReportSpec.EnablePeakRSSI = cbEnablePeakRSSI.Checked;
            RFIDReaderParameter.ROReportSpec.EnableFirstSeenTimestamp = cbEnableFirstSeenTimestamp.Checked;
            RFIDReaderParameter.ROReportSpec.EnableLastSeenTimestamp = cbEnableLastSeenTimestamp.Checked;
            RFIDReaderParameter.ROReportSpec.EnableTagSeenCount = cbEnableTagSeenCount.Checked;
            RFIDReaderParameter.ROReportSpec.EnableAccessSpecID = cbEnableAccessSpecID.Checked;
            RFIDReaderParameter.ROReportSpec.EnableCRC = cbEnableCRC.Checked;
            RFIDReaderParameter.ROReportSpec.EnablePCbits = cbEnablePCBits.Checked;

            RFIDReaderParameter.ROReportSpec.ImpinJEnableSerializedTID = cbImpinjEnableSerializedTID.Checked;
            RFIDReaderParameter.ROReportSpec.ImpinJEnableRFPhaseAngle = cbImpinjEnableRFPhaseAngle.Checked;
            RFIDReaderParameter.ROReportSpec.ImpinJEnablePeakRSSI = cbImpinjEnablePeakRSSI.Checked;
            RFIDReaderParameter.ROReportSpec.ImpinJEnableGPSCoordinates = cbImpinjEnableGPSCoordinates.Checked;
            RFIDReaderParameter.ROReportSpec.ImpinJEnableOptimizedRead = cbImpinjEnableOptimizedRead.Checked;
            RFIDReaderParameter.ROReportSpec.ImpinJEnableRFDopplerFrequency = cbImpinjEnableRFDopplerFrequency.Checked;
            //-----Reader Operation Report Sepc-------
        }

        private void MoreSettings_Load(object sender, EventArgs e)
        {
            ReceiveConfigFromMainForm();
        }

        private void tsbtnSave_Click(object sender, EventArgs e)
        {
            if (tbxTari.Text.Trim() == String.Empty)
            {
                MessageBox.Show("Please Input Tari!");
                return;
            }

            if (tbxTagPopulation.Text.Trim() == String.Empty)
            {
                MessageBox.Show("Please Input Tag Population!");
                return;
            }

            if (tbxTagTransitTime.Text.Trim() == String.Empty)
            {
                MessageBox.Show("Please Input Tag Transit Time!");
                return;
            }

            if (cbImpinjReducedPowerFrequencyMode.Checked)
            {
                if (tbxReducedChannelList.Text.Trim() == String.Empty)
                {
                    MessageBox.Show("Please Input Channel List!");
                    return;
                }
            }

            if (cbImpinjLowDutyCycleMode.Checked)
            {
                if (tbxEmptyFieldTimeout.Text.Trim() == String.Empty)
                {
                    MessageBox.Show("Please Input Empty Field Timeout!");
                    return;
                }

                if (tbxFieldPingInterval.Text.Trim() == String.Empty)
                {
                    MessageBox.Show("Please Input Field Ping Interval!");
                    return;
                }
            }

            if (!cbAntenna1.Checked && !cbAntenna2.Checked && !cbAntenna3.Checked && !cbAntenna4.Checked)
            {
                MessageBox.Show("Please choose at least one Antenna!");
                return;
            }

            SendConfigToMainForm();
            this.Close();
        }

        private void cbImpinjLowDutyCycle_CheckedChanged(object sender, EventArgs e)
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

        private void cbImpinjReducedPowerFrequencyList_CheckedChanged(object sender, EventArgs e)
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
    }
}
