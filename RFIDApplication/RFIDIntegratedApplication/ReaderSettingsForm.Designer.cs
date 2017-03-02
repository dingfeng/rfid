namespace RFIDIntegratedApplication
{
    partial class ReaderSettingsForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tcReaderSettings = new System.Windows.Forms.TabControl();
            this.tpBasic = new System.Windows.Forms.TabPage();
            this.cbResetToFactoryDefault = new System.Windows.Forms.CheckBox();
            this.gbTagFilter = new System.Windows.Forms.GroupBox();
            this.cbExtraMask = new System.Windows.Forms.ComboBox();
            this.cbMask = new System.Windows.Forms.ComboBox();
            this.lblExtraMask = new System.Windows.Forms.Label();
            this.lblMask = new System.Windows.Forms.Label();
            this.gbFrequencyInfo = new System.Windows.Forms.GroupBox();
            this.nudHop = new System.Windows.Forms.NumericUpDown();
            this.clbFreqSet = new System.Windows.Forms.CheckedListBox();
            this.lblHop = new System.Windows.Forms.Label();
            this.lblFreqSet = new System.Windows.Forms.Label();
            this.cbFreqMode = new System.Windows.Forms.ComboBox();
            this.lblFreqMode = new System.Windows.Forms.Label();
            this.gbReadMode = new System.Windows.Forms.GroupBox();
            this.lblMs = new System.Windows.Forms.Label();
            this.tbxDuration = new System.Windows.Forms.TextBox();
            this.lblDuration = new System.Windows.Forms.Label();
            this.rbtnTimerReadMode = new System.Windows.Forms.RadioButton();
            this.rbtnManualReadMode = new System.Windows.Forms.RadioButton();
            this.gbAddress = new System.Windows.Forms.GroupBox();
            this.btnSearchIP = new System.Windows.Forms.Button();
            this.lblMAC3 = new System.Windows.Forms.Label();
            this.tbxMAC3 = new System.Windows.Forms.TextBox();
            this.lblMAC2 = new System.Windows.Forms.Label();
            this.lblMAC4 = new System.Windows.Forms.Label();
            this.tbxMAC2 = new System.Windows.Forms.TextBox();
            this.tbxMAC1 = new System.Windows.Forms.TextBox();
            this.lblMAC1 = new System.Windows.Forms.Label();
            this.rbtnHostname = new System.Windows.Forms.RadioButton();
            this.rbtnIP = new System.Windows.Forms.RadioButton();
            this.tbxIP = new System.Windows.Forms.TextBox();
            this.tpAntenna = new System.Windows.Forms.TabPage();
            this.tabControlAntenna = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.gbRFReceiver1 = new System.Windows.Forms.GroupBox();
            this.lblReceiverSensitivity1 = new System.Windows.Forms.Label();
            this.cbReceiverSensitivity1 = new System.Windows.Forms.ComboBox();
            this.gbRFTransmiter1 = new System.Windows.Forms.GroupBox();
            this.cbTransmiterPower1 = new System.Windows.Forms.ComboBox();
            this.lblTransmiterPower1 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.gbRFReceiver2 = new System.Windows.Forms.GroupBox();
            this.lblReceiverSensitivity2 = new System.Windows.Forms.Label();
            this.cbReceiverSensitivity2 = new System.Windows.Forms.ComboBox();
            this.gbRFTransmiter2 = new System.Windows.Forms.GroupBox();
            this.cbTransmiterPower2 = new System.Windows.Forms.ComboBox();
            this.lblTransmiterPower2 = new System.Windows.Forms.Label();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.gbRFReceiver3 = new System.Windows.Forms.GroupBox();
            this.lblReceiverSensitivity3 = new System.Windows.Forms.Label();
            this.cbReceiverSensitivity3 = new System.Windows.Forms.ComboBox();
            this.gbRFTransmiter3 = new System.Windows.Forms.GroupBox();
            this.cbTransmiterPower3 = new System.Windows.Forms.ComboBox();
            this.lblTransmiterPower3 = new System.Windows.Forms.Label();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.gbRFReceiver4 = new System.Windows.Forms.GroupBox();
            this.lblReceiverSensitivity4 = new System.Windows.Forms.Label();
            this.cbReceiverSensitivity4 = new System.Windows.Forms.ComboBox();
            this.gbRFTransmiter4 = new System.Windows.Forms.GroupBox();
            this.cbTransmiterPower4 = new System.Windows.Forms.ComboBox();
            this.lblTransmiterPower4 = new System.Windows.Forms.Label();
            this.cbAntenna4 = new System.Windows.Forms.CheckBox();
            this.gbC1G2InventoryCommand = new System.Windows.Forms.GroupBox();
            this.gbImpinj = new System.Windows.Forms.GroupBox();
            this.lblScope2 = new System.Windows.Forms.Label();
            this.lblScope1 = new System.Windows.Forms.Label();
            this.cbImpinjLowDutyCycleMode = new System.Windows.Forms.CheckBox();
            this.lblEmptyFieldTimeout = new System.Windows.Forms.Label();
            this.tbxEmptyFieldTimeout = new System.Windows.Forms.TextBox();
            this.tbxFieldPingInterval = new System.Windows.Forms.TextBox();
            this.lblFieldPingInterval = new System.Windows.Forms.Label();
            this.tbxReducedChannelList = new System.Windows.Forms.TextBox();
            this.lblReducedChannelList = new System.Windows.Forms.Label();
            this.cbImpinjReducedPowerFrequencyMode = new System.Windows.Forms.CheckBox();
            this.cbImpiJSearchMode = new System.Windows.Forms.ComboBox();
            this.lblImpinjInventorySearchMode = new System.Windows.Forms.Label();
            this.gbC1G2SingulationControl = new System.Windows.Forms.GroupBox();
            this.lblScope3 = new System.Windows.Forms.Label();
            this.tbxTagTransitTime = new System.Windows.Forms.TextBox();
            this.lblTagTransmiteTime = new System.Windows.Forms.Label();
            this.tbxTagPopulation = new System.Windows.Forms.TextBox();
            this.lblTagPopulation = new System.Windows.Forms.Label();
            this.cbSession = new System.Windows.Forms.ComboBox();
            this.lblSession = new System.Windows.Forms.Label();
            this.gbC1G2RFControl = new System.Windows.Forms.GroupBox();
            this.tbxTari = new System.Windows.Forms.TextBox();
            this.lblTari = new System.Windows.Forms.Label();
            this.cbModeIndex = new System.Windows.Forms.ComboBox();
            this.lblModeIndex = new System.Windows.Forms.Label();
            this.lblTagInventoryStateAware = new System.Windows.Forms.Label();
            this.cbTagInventoryStateAware = new System.Windows.Forms.ComboBox();
            this.cbAntenna3 = new System.Windows.Forms.CheckBox();
            this.cbAntenna2 = new System.Windows.Forms.CheckBox();
            this.cbAntenna1 = new System.Windows.Forms.CheckBox();
            this.lblAntennaID = new System.Windows.Forms.Label();
            this.tpRoSpec = new System.Windows.Forms.TabPage();
            this.gbImpinjTagReportContentSelector = new System.Windows.Forms.GroupBox();
            this.cbImpinjEnableSerializedTID = new System.Windows.Forms.CheckBox();
            this.cbImpinjEnableRFPhaseAngle = new System.Windows.Forms.CheckBox();
            this.cbImpinjEnableRFDopplerFrequency = new System.Windows.Forms.CheckBox();
            this.cbImpinjEnablePeakRSSI = new System.Windows.Forms.CheckBox();
            this.cbImpinjEnableOptimizedRead = new System.Windows.Forms.CheckBox();
            this.cbImpinjEnableGPSCoordinates = new System.Windows.Forms.CheckBox();
            this.gbTagReportContentSelector = new System.Windows.Forms.GroupBox();
            this.gbC1G2EPCMemorySelector = new System.Windows.Forms.GroupBox();
            this.cbEnablePCBits = new System.Windows.Forms.CheckBox();
            this.cbEnableCRC = new System.Windows.Forms.CheckBox();
            this.cbEnableTagSeenCount = new System.Windows.Forms.CheckBox();
            this.cbEnableSpecIndex = new System.Windows.Forms.CheckBox();
            this.cbEnableROSpecID = new System.Windows.Forms.CheckBox();
            this.cbEnablePeakRSSI = new System.Windows.Forms.CheckBox();
            this.cbEnableLastSeenTimestamp = new System.Windows.Forms.CheckBox();
            this.cbEnableAccessSpecID = new System.Windows.Forms.CheckBox();
            this.cbEnableChannelIndex = new System.Windows.Forms.CheckBox();
            this.cbEnableInventoryParameterSpecID = new System.Windows.Forms.CheckBox();
            this.cbEnableAntennaID = new System.Windows.Forms.CheckBox();
            this.cbEnableFirstSeenTimestamp = new System.Windows.Forms.CheckBox();
            this.nudN = new System.Windows.Forms.NumericUpDown();
            this.lblN = new System.Windows.Forms.Label();
            this.cbROReportTrigger = new System.Windows.Forms.ComboBox();
            this.lblROReportTrigger = new System.Windows.Forms.Label();
            this.tcReaderSettings.SuspendLayout();
            this.tpBasic.SuspendLayout();
            this.gbTagFilter.SuspendLayout();
            this.gbFrequencyInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudHop)).BeginInit();
            this.gbReadMode.SuspendLayout();
            this.gbAddress.SuspendLayout();
            this.tpAntenna.SuspendLayout();
            this.tabControlAntenna.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.gbRFReceiver1.SuspendLayout();
            this.gbRFTransmiter1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.gbRFReceiver2.SuspendLayout();
            this.gbRFTransmiter2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.gbRFReceiver3.SuspendLayout();
            this.gbRFTransmiter3.SuspendLayout();
            this.tabPage4.SuspendLayout();
            this.gbRFReceiver4.SuspendLayout();
            this.gbRFTransmiter4.SuspendLayout();
            this.gbC1G2InventoryCommand.SuspendLayout();
            this.gbImpinj.SuspendLayout();
            this.gbC1G2SingulationControl.SuspendLayout();
            this.gbC1G2RFControl.SuspendLayout();
            this.tpRoSpec.SuspendLayout();
            this.gbImpinjTagReportContentSelector.SuspendLayout();
            this.gbTagReportContentSelector.SuspendLayout();
            this.gbC1G2EPCMemorySelector.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudN)).BeginInit();
            this.SuspendLayout();
            // 
            // tcReaderSettings
            // 
            this.tcReaderSettings.Controls.Add(this.tpBasic);
            this.tcReaderSettings.Controls.Add(this.tpAntenna);
            this.tcReaderSettings.Controls.Add(this.tpRoSpec);
            this.tcReaderSettings.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tcReaderSettings.Location = new System.Drawing.Point(0, 0);
            this.tcReaderSettings.Margin = new System.Windows.Forms.Padding(4);
            this.tcReaderSettings.Name = "tcReaderSettings";
            this.tcReaderSettings.SelectedIndex = 0;
            this.tcReaderSettings.Size = new System.Drawing.Size(379, 875);
            this.tcReaderSettings.TabIndex = 0;
            // 
            // tpBasic
            // 
            this.tpBasic.Controls.Add(this.cbResetToFactoryDefault);
            this.tpBasic.Controls.Add(this.gbTagFilter);
            this.tpBasic.Controls.Add(this.gbFrequencyInfo);
            this.tpBasic.Controls.Add(this.gbReadMode);
            this.tpBasic.Controls.Add(this.gbAddress);
            this.tpBasic.Location = new System.Drawing.Point(4, 25);
            this.tpBasic.Margin = new System.Windows.Forms.Padding(4);
            this.tpBasic.Name = "tpBasic";
            this.tpBasic.Padding = new System.Windows.Forms.Padding(4);
            this.tpBasic.Size = new System.Drawing.Size(371, 846);
            this.tpBasic.TabIndex = 0;
            this.tpBasic.Text = "Basic";
            this.tpBasic.UseVisualStyleBackColor = true;
            // 
            // cbResetToFactoryDefault
            // 
            this.cbResetToFactoryDefault.AutoSize = true;
            this.cbResetToFactoryDefault.Location = new System.Drawing.Point(17, 10);
            this.cbResetToFactoryDefault.Margin = new System.Windows.Forms.Padding(4);
            this.cbResetToFactoryDefault.Name = "cbResetToFactoryDefault";
            this.cbResetToFactoryDefault.Size = new System.Drawing.Size(221, 19);
            this.cbResetToFactoryDefault.TabIndex = 11;
            this.cbResetToFactoryDefault.Text = "Reset To Factory Default";
            this.cbResetToFactoryDefault.UseVisualStyleBackColor = true;
            this.cbResetToFactoryDefault.CheckedChanged += new System.EventHandler(this.cbResetToFactoryDefault_CheckedChanged);
            // 
            // gbTagFilter
            // 
            this.gbTagFilter.Controls.Add(this.cbExtraMask);
            this.gbTagFilter.Controls.Add(this.cbMask);
            this.gbTagFilter.Controls.Add(this.lblExtraMask);
            this.gbTagFilter.Controls.Add(this.lblMask);
            this.gbTagFilter.Location = new System.Drawing.Point(11, 644);
            this.gbTagFilter.Margin = new System.Windows.Forms.Padding(4);
            this.gbTagFilter.Name = "gbTagFilter";
            this.gbTagFilter.Padding = new System.Windows.Forms.Padding(4);
            this.gbTagFilter.Size = new System.Drawing.Size(347, 88);
            this.gbTagFilter.TabIndex = 10;
            this.gbTagFilter.TabStop = false;
            this.gbTagFilter.Text = "Tag Filter";
            // 
            // cbExtraMask
            // 
            this.cbExtraMask.FormattingEnabled = true;
            this.cbExtraMask.Location = new System.Drawing.Point(100, 55);
            this.cbExtraMask.Margin = new System.Windows.Forms.Padding(4);
            this.cbExtraMask.Name = "cbExtraMask";
            this.cbExtraMask.Size = new System.Drawing.Size(236, 23);
            this.cbExtraMask.TabIndex = 5;
            this.cbExtraMask.SelectedIndexChanged += new System.EventHandler(this.cbExtraMask_SelectedIndexChanged);
            // 
            // cbMask
            // 
            this.cbMask.FormattingEnabled = true;
            this.cbMask.Location = new System.Drawing.Point(100, 22);
            this.cbMask.Margin = new System.Windows.Forms.Padding(4);
            this.cbMask.Name = "cbMask";
            this.cbMask.Size = new System.Drawing.Size(236, 23);
            this.cbMask.TabIndex = 4;
            this.cbMask.SelectedIndexChanged += new System.EventHandler(this.cbMask_SelectedIndexChanged);
            // 
            // lblExtraMask
            // 
            this.lblExtraMask.AutoSize = true;
            this.lblExtraMask.Location = new System.Drawing.Point(12, 59);
            this.lblExtraMask.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblExtraMask.Name = "lblExtraMask";
            this.lblExtraMask.Size = new System.Drawing.Size(87, 15);
            this.lblExtraMask.TabIndex = 1;
            this.lblExtraMask.Text = "Extra Mask";
            // 
            // lblMask
            // 
            this.lblMask.AutoSize = true;
            this.lblMask.Location = new System.Drawing.Point(12, 26);
            this.lblMask.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblMask.Name = "lblMask";
            this.lblMask.Size = new System.Drawing.Size(39, 15);
            this.lblMask.TabIndex = 0;
            this.lblMask.Text = "Mask";
            // 
            // gbFrequencyInfo
            // 
            this.gbFrequencyInfo.Controls.Add(this.nudHop);
            this.gbFrequencyInfo.Controls.Add(this.clbFreqSet);
            this.gbFrequencyInfo.Controls.Add(this.lblHop);
            this.gbFrequencyInfo.Controls.Add(this.lblFreqSet);
            this.gbFrequencyInfo.Controls.Add(this.cbFreqMode);
            this.gbFrequencyInfo.Controls.Add(this.lblFreqMode);
            this.gbFrequencyInfo.Location = new System.Drawing.Point(11, 342);
            this.gbFrequencyInfo.Margin = new System.Windows.Forms.Padding(4);
            this.gbFrequencyInfo.Name = "gbFrequencyInfo";
            this.gbFrequencyInfo.Padding = new System.Windows.Forms.Padding(4);
            this.gbFrequencyInfo.Size = new System.Drawing.Size(347, 294);
            this.gbFrequencyInfo.TabIndex = 9;
            this.gbFrequencyInfo.TabStop = false;
            this.gbFrequencyInfo.Text = "Frequency Information";
            // 
            // nudHop
            // 
            this.nudHop.Location = new System.Drawing.Point(100, 258);
            this.nudHop.Margin = new System.Windows.Forms.Padding(4);
            this.nudHop.Name = "nudHop";
            this.nudHop.Size = new System.Drawing.Size(237, 25);
            this.nudHop.TabIndex = 7;
            this.nudHop.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudHop.ValueChanged += new System.EventHandler(this.nudHop_ValueChanged);
            // 
            // clbFreqSet
            // 
            this.clbFreqSet.FormattingEnabled = true;
            this.clbFreqSet.Location = new System.Drawing.Point(100, 74);
            this.clbFreqSet.Margin = new System.Windows.Forms.Padding(4);
            this.clbFreqSet.Name = "clbFreqSet";
            this.clbFreqSet.Size = new System.Drawing.Size(236, 164);
            this.clbFreqSet.TabIndex = 5;
            // 
            // lblHop
            // 
            this.lblHop.AutoSize = true;
            this.lblHop.Location = new System.Drawing.Point(13, 260);
            this.lblHop.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblHop.Name = "lblHop";
            this.lblHop.Size = new System.Drawing.Size(71, 15);
            this.lblHop.TabIndex = 4;
            this.lblHop.Text = "Hop Step";
            // 
            // lblFreqSet
            // 
            this.lblFreqSet.AutoSize = true;
            this.lblFreqSet.Location = new System.Drawing.Point(13, 74);
            this.lblFreqSet.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblFreqSet.Name = "lblFreqSet";
            this.lblFreqSet.Size = new System.Drawing.Size(71, 15);
            this.lblFreqSet.TabIndex = 2;
            this.lblFreqSet.Text = "Freq Set";
            // 
            // cbFreqMode
            // 
            this.cbFreqMode.FormattingEnabled = true;
            this.cbFreqMode.Location = new System.Drawing.Point(100, 31);
            this.cbFreqMode.Margin = new System.Windows.Forms.Padding(4);
            this.cbFreqMode.Name = "cbFreqMode";
            this.cbFreqMode.Size = new System.Drawing.Size(236, 23);
            this.cbFreqMode.TabIndex = 1;
            this.cbFreqMode.SelectedIndexChanged += new System.EventHandler(this.cbFreqMode_SelectedIndexChanged);
            // 
            // lblFreqMode
            // 
            this.lblFreqMode.AutoSize = true;
            this.lblFreqMode.Location = new System.Drawing.Point(13, 35);
            this.lblFreqMode.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblFreqMode.Name = "lblFreqMode";
            this.lblFreqMode.Size = new System.Drawing.Size(79, 15);
            this.lblFreqMode.TabIndex = 0;
            this.lblFreqMode.Text = "Freq Mode";
            // 
            // gbReadMode
            // 
            this.gbReadMode.Controls.Add(this.lblMs);
            this.gbReadMode.Controls.Add(this.tbxDuration);
            this.gbReadMode.Controls.Add(this.lblDuration);
            this.gbReadMode.Controls.Add(this.rbtnTimerReadMode);
            this.gbReadMode.Controls.Add(this.rbtnManualReadMode);
            this.gbReadMode.Location = new System.Drawing.Point(11, 196);
            this.gbReadMode.Margin = new System.Windows.Forms.Padding(4);
            this.gbReadMode.Name = "gbReadMode";
            this.gbReadMode.Padding = new System.Windows.Forms.Padding(4);
            this.gbReadMode.Size = new System.Drawing.Size(347, 139);
            this.gbReadMode.TabIndex = 8;
            this.gbReadMode.TabStop = false;
            this.gbReadMode.Text = "Read Mode";
            // 
            // lblMs
            // 
            this.lblMs.AutoSize = true;
            this.lblMs.Location = new System.Drawing.Point(227, 100);
            this.lblMs.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblMs.Name = "lblMs";
            this.lblMs.Size = new System.Drawing.Size(23, 15);
            this.lblMs.TabIndex = 4;
            this.lblMs.Text = "ms";
            // 
            // tbxDuration
            // 
            this.tbxDuration.Location = new System.Drawing.Point(125, 96);
            this.tbxDuration.Margin = new System.Windows.Forms.Padding(4);
            this.tbxDuration.Name = "tbxDuration";
            this.tbxDuration.Size = new System.Drawing.Size(91, 25);
            this.tbxDuration.TabIndex = 3;
            this.tbxDuration.TextChanged += new System.EventHandler(this.tbxDuration_TextChanged);
            // 
            // lblDuration
            // 
            this.lblDuration.AutoSize = true;
            this.lblDuration.Location = new System.Drawing.Point(39, 100);
            this.lblDuration.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblDuration.Name = "lblDuration";
            this.lblDuration.Size = new System.Drawing.Size(71, 15);
            this.lblDuration.TabIndex = 2;
            this.lblDuration.Text = "Duration";
            // 
            // rbtnTimerReadMode
            // 
            this.rbtnTimerReadMode.AutoSize = true;
            this.rbtnTimerReadMode.Location = new System.Drawing.Point(16, 65);
            this.rbtnTimerReadMode.Margin = new System.Windows.Forms.Padding(4);
            this.rbtnTimerReadMode.Name = "rbtnTimerReadMode";
            this.rbtnTimerReadMode.Size = new System.Drawing.Size(148, 19);
            this.rbtnTimerReadMode.TabIndex = 1;
            this.rbtnTimerReadMode.Text = "Timer Read Mode";
            this.rbtnTimerReadMode.UseVisualStyleBackColor = true;
            this.rbtnTimerReadMode.CheckedChanged += new System.EventHandler(this.rbtnTimerReadMode_CheckedChanged);
            // 
            // rbtnManualReadMode
            // 
            this.rbtnManualReadMode.AutoSize = true;
            this.rbtnManualReadMode.Checked = true;
            this.rbtnManualReadMode.Location = new System.Drawing.Point(16, 32);
            this.rbtnManualReadMode.Margin = new System.Windows.Forms.Padding(4);
            this.rbtnManualReadMode.Name = "rbtnManualReadMode";
            this.rbtnManualReadMode.Size = new System.Drawing.Size(156, 19);
            this.rbtnManualReadMode.TabIndex = 0;
            this.rbtnManualReadMode.TabStop = true;
            this.rbtnManualReadMode.Text = "Manual Read Mode";
            this.rbtnManualReadMode.UseVisualStyleBackColor = true;
            this.rbtnManualReadMode.CheckedChanged += new System.EventHandler(this.rbtnManualReadMode_CheckedChanged);
            // 
            // gbAddress
            // 
            this.gbAddress.Controls.Add(this.btnSearchIP);
            this.gbAddress.Controls.Add(this.lblMAC3);
            this.gbAddress.Controls.Add(this.tbxMAC3);
            this.gbAddress.Controls.Add(this.lblMAC2);
            this.gbAddress.Controls.Add(this.lblMAC4);
            this.gbAddress.Controls.Add(this.tbxMAC2);
            this.gbAddress.Controls.Add(this.tbxMAC1);
            this.gbAddress.Controls.Add(this.lblMAC1);
            this.gbAddress.Controls.Add(this.rbtnHostname);
            this.gbAddress.Controls.Add(this.rbtnIP);
            this.gbAddress.Controls.Add(this.tbxIP);
            this.gbAddress.Location = new System.Drawing.Point(11, 45);
            this.gbAddress.Margin = new System.Windows.Forms.Padding(4);
            this.gbAddress.Name = "gbAddress";
            this.gbAddress.Padding = new System.Windows.Forms.Padding(4);
            this.gbAddress.Size = new System.Drawing.Size(347, 144);
            this.gbAddress.TabIndex = 7;
            this.gbAddress.TabStop = false;
            this.gbAddress.Text = "Address";
            // 
            // btnSearchIP
            // 
            this.btnSearchIP.Location = new System.Drawing.Point(219, 32);
            this.btnSearchIP.Margin = new System.Windows.Forms.Padding(4);
            this.btnSearchIP.Name = "btnSearchIP";
            this.btnSearchIP.Size = new System.Drawing.Size(100, 29);
            this.btnSearchIP.TabIndex = 17;
            this.btnSearchIP.Text = "Search";
            this.btnSearchIP.UseVisualStyleBackColor = true;
            // 
            // lblMAC3
            // 
            this.lblMAC3.AutoSize = true;
            this.lblMAC3.Location = new System.Drawing.Point(203, 112);
            this.lblMAC3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblMAC3.Name = "lblMAC3";
            this.lblMAC3.Size = new System.Drawing.Size(15, 15);
            this.lblMAC3.TabIndex = 16;
            this.lblMAC3.Text = "-";
            // 
            // tbxMAC3
            // 
            this.tbxMAC3.Location = new System.Drawing.Point(220, 106);
            this.tbxMAC3.Margin = new System.Windows.Forms.Padding(4);
            this.tbxMAC3.MaxLength = 2;
            this.tbxMAC3.Name = "tbxMAC3";
            this.tbxMAC3.Size = new System.Drawing.Size(27, 25);
            this.tbxMAC3.TabIndex = 13;
            // 
            // lblMAC2
            // 
            this.lblMAC2.AutoSize = true;
            this.lblMAC2.Location = new System.Drawing.Point(153, 111);
            this.lblMAC2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblMAC2.Name = "lblMAC2";
            this.lblMAC2.Size = new System.Drawing.Size(15, 15);
            this.lblMAC2.TabIndex = 15;
            this.lblMAC2.Text = "-";
            // 
            // lblMAC4
            // 
            this.lblMAC4.AutoSize = true;
            this.lblMAC4.Location = new System.Drawing.Point(253, 112);
            this.lblMAC4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblMAC4.Name = "lblMAC4";
            this.lblMAC4.Size = new System.Drawing.Size(55, 15);
            this.lblMAC4.TabIndex = 14;
            this.lblMAC4.Text = ".local";
            // 
            // tbxMAC2
            // 
            this.tbxMAC2.Location = new System.Drawing.Point(171, 106);
            this.tbxMAC2.Margin = new System.Windows.Forms.Padding(4);
            this.tbxMAC2.MaxLength = 2;
            this.tbxMAC2.Name = "tbxMAC2";
            this.tbxMAC2.Size = new System.Drawing.Size(28, 25);
            this.tbxMAC2.TabIndex = 12;
            // 
            // tbxMAC1
            // 
            this.tbxMAC1.Location = new System.Drawing.Point(123, 106);
            this.tbxMAC1.Margin = new System.Windows.Forms.Padding(4);
            this.tbxMAC1.MaxLength = 2;
            this.tbxMAC1.Name = "tbxMAC1";
            this.tbxMAC1.Size = new System.Drawing.Size(27, 25);
            this.tbxMAC1.TabIndex = 11;
            // 
            // lblMAC1
            // 
            this.lblMAC1.AutoSize = true;
            this.lblMAC1.Location = new System.Drawing.Point(35, 111);
            this.lblMAC1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblMAC1.Name = "lblMAC1";
            this.lblMAC1.Size = new System.Drawing.Size(87, 15);
            this.lblMAC1.TabIndex = 10;
            this.lblMAC1.Text = "SpeedwayR-";
            // 
            // rbtnHostname
            // 
            this.rbtnHostname.AutoSize = true;
            this.rbtnHostname.Location = new System.Drawing.Point(16, 76);
            this.rbtnHostname.Margin = new System.Windows.Forms.Padding(4);
            this.rbtnHostname.Name = "rbtnHostname";
            this.rbtnHostname.Size = new System.Drawing.Size(92, 19);
            this.rbtnHostname.TabIndex = 3;
            this.rbtnHostname.Text = "Hostname";
            this.rbtnHostname.UseVisualStyleBackColor = true;
            this.rbtnHostname.CheckedChanged += new System.EventHandler(this.rbtnHostname_CheckedChanged);
            // 
            // rbtnIP
            // 
            this.rbtnIP.AutoSize = true;
            this.rbtnIP.Checked = true;
            this.rbtnIP.Location = new System.Drawing.Point(16, 36);
            this.rbtnIP.Margin = new System.Windows.Forms.Padding(4);
            this.rbtnIP.Name = "rbtnIP";
            this.rbtnIP.Size = new System.Drawing.Size(44, 19);
            this.rbtnIP.TabIndex = 2;
            this.rbtnIP.TabStop = true;
            this.rbtnIP.Text = "IP";
            this.rbtnIP.UseVisualStyleBackColor = true;
            this.rbtnIP.CheckedChanged += new System.EventHandler(this.rbtnIP_CheckedChanged);
            // 
            // tbxIP
            // 
            this.tbxIP.Location = new System.Drawing.Point(73, 34);
            this.tbxIP.Margin = new System.Windows.Forms.Padding(4);
            this.tbxIP.Name = "tbxIP";
            this.tbxIP.Size = new System.Drawing.Size(132, 25);
            this.tbxIP.TabIndex = 1;
            // 
            // tpAntenna
            // 
            this.tpAntenna.Controls.Add(this.tabControlAntenna);
            this.tpAntenna.Controls.Add(this.cbAntenna4);
            this.tpAntenna.Controls.Add(this.gbC1G2InventoryCommand);
            this.tpAntenna.Controls.Add(this.cbAntenna3);
            this.tpAntenna.Controls.Add(this.cbAntenna2);
            this.tpAntenna.Controls.Add(this.cbAntenna1);
            this.tpAntenna.Controls.Add(this.lblAntennaID);
            this.tpAntenna.Location = new System.Drawing.Point(4, 25);
            this.tpAntenna.Margin = new System.Windows.Forms.Padding(4);
            this.tpAntenna.Name = "tpAntenna";
            this.tpAntenna.Padding = new System.Windows.Forms.Padding(4);
            this.tpAntenna.Size = new System.Drawing.Size(371, 846);
            this.tpAntenna.TabIndex = 1;
            this.tpAntenna.Text = "Antenna";
            this.tpAntenna.UseVisualStyleBackColor = true;
            // 
            // tabControlAntenna
            // 
            this.tabControlAntenna.Controls.Add(this.tabPage1);
            this.tabControlAntenna.Controls.Add(this.tabPage2);
            this.tabControlAntenna.Controls.Add(this.tabPage3);
            this.tabControlAntenna.Controls.Add(this.tabPage4);
            this.tabControlAntenna.Location = new System.Drawing.Point(8, 668);
            this.tabControlAntenna.Margin = new System.Windows.Forms.Padding(4);
            this.tabControlAntenna.Name = "tabControlAntenna";
            this.tabControlAntenna.SelectedIndex = 0;
            this.tabControlAntenna.Size = new System.Drawing.Size(349, 165);
            this.tabControlAntenna.TabIndex = 19;
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tabPage1.Controls.Add(this.gbRFReceiver1);
            this.tabPage1.Controls.Add(this.gbRFTransmiter1);
            this.tabPage1.Location = new System.Drawing.Point(4, 25);
            this.tabPage1.Margin = new System.Windows.Forms.Padding(4);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(4);
            this.tabPage1.Size = new System.Drawing.Size(341, 136);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Antenna1";
            // 
            // gbRFReceiver1
            // 
            this.gbRFReceiver1.Controls.Add(this.lblReceiverSensitivity1);
            this.gbRFReceiver1.Controls.Add(this.cbReceiverSensitivity1);
            this.gbRFReceiver1.Location = new System.Drawing.Point(8, 8);
            this.gbRFReceiver1.Margin = new System.Windows.Forms.Padding(4);
            this.gbRFReceiver1.Name = "gbRFReceiver1";
            this.gbRFReceiver1.Padding = new System.Windows.Forms.Padding(4);
            this.gbRFReceiver1.Size = new System.Drawing.Size(325, 56);
            this.gbRFReceiver1.TabIndex = 4;
            this.gbRFReceiver1.TabStop = false;
            this.gbRFReceiver1.Text = "RF Receiver";
            // 
            // lblReceiverSensitivity1
            // 
            this.lblReceiverSensitivity1.AutoSize = true;
            this.lblReceiverSensitivity1.Location = new System.Drawing.Point(9, 24);
            this.lblReceiverSensitivity1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblReceiverSensitivity1.Name = "lblReceiverSensitivity1";
            this.lblReceiverSensitivity1.Size = new System.Drawing.Size(215, 15);
            this.lblReceiverSensitivity1.TabIndex = 1;
            this.lblReceiverSensitivity1.Text = "Receiver Sensitivity (dBm)";
            // 
            // cbReceiverSensitivity1
            // 
            this.cbReceiverSensitivity1.FormattingEnabled = true;
            this.cbReceiverSensitivity1.Location = new System.Drawing.Point(232, 20);
            this.cbReceiverSensitivity1.Margin = new System.Windows.Forms.Padding(4);
            this.cbReceiverSensitivity1.Name = "cbReceiverSensitivity1";
            this.cbReceiverSensitivity1.Size = new System.Drawing.Size(87, 23);
            this.cbReceiverSensitivity1.TabIndex = 0;
            // 
            // gbRFTransmiter1
            // 
            this.gbRFTransmiter1.Controls.Add(this.cbTransmiterPower1);
            this.gbRFTransmiter1.Controls.Add(this.lblTransmiterPower1);
            this.gbRFTransmiter1.Location = new System.Drawing.Point(8, 66);
            this.gbRFTransmiter1.Margin = new System.Windows.Forms.Padding(4);
            this.gbRFTransmiter1.Name = "gbRFTransmiter1";
            this.gbRFTransmiter1.Padding = new System.Windows.Forms.Padding(4);
            this.gbRFTransmiter1.Size = new System.Drawing.Size(325, 60);
            this.gbRFTransmiter1.TabIndex = 5;
            this.gbRFTransmiter1.TabStop = false;
            this.gbRFTransmiter1.Text = "RF Transmiter";
            // 
            // cbTransmiterPower1
            // 
            this.cbTransmiterPower1.FormattingEnabled = true;
            this.cbTransmiterPower1.Location = new System.Drawing.Point(232, 24);
            this.cbTransmiterPower1.Margin = new System.Windows.Forms.Padding(4);
            this.cbTransmiterPower1.Name = "cbTransmiterPower1";
            this.cbTransmiterPower1.Size = new System.Drawing.Size(87, 23);
            this.cbTransmiterPower1.TabIndex = 5;
            // 
            // lblTransmiterPower1
            // 
            this.lblTransmiterPower1.AutoSize = true;
            this.lblTransmiterPower1.Location = new System.Drawing.Point(9, 28);
            this.lblTransmiterPower1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTransmiterPower1.Name = "lblTransmiterPower1";
            this.lblTransmiterPower1.Size = new System.Drawing.Size(183, 15);
            this.lblTransmiterPower1.TabIndex = 2;
            this.lblTransmiterPower1.Text = "Transmiter Power (dBm)";
            // 
            // tabPage2
            // 
            this.tabPage2.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tabPage2.Controls.Add(this.gbRFReceiver2);
            this.tabPage2.Controls.Add(this.gbRFTransmiter2);
            this.tabPage2.Location = new System.Drawing.Point(4, 25);
            this.tabPage2.Margin = new System.Windows.Forms.Padding(4);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(4);
            this.tabPage2.Size = new System.Drawing.Size(341, 136);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Antenna2";
            // 
            // gbRFReceiver2
            // 
            this.gbRFReceiver2.Controls.Add(this.lblReceiverSensitivity2);
            this.gbRFReceiver2.Controls.Add(this.cbReceiverSensitivity2);
            this.gbRFReceiver2.Location = new System.Drawing.Point(8, 8);
            this.gbRFReceiver2.Margin = new System.Windows.Forms.Padding(4);
            this.gbRFReceiver2.Name = "gbRFReceiver2";
            this.gbRFReceiver2.Padding = new System.Windows.Forms.Padding(4);
            this.gbRFReceiver2.Size = new System.Drawing.Size(325, 56);
            this.gbRFReceiver2.TabIndex = 6;
            this.gbRFReceiver2.TabStop = false;
            this.gbRFReceiver2.Text = "RF Receiver";
            // 
            // lblReceiverSensitivity2
            // 
            this.lblReceiverSensitivity2.AutoSize = true;
            this.lblReceiverSensitivity2.Location = new System.Drawing.Point(9, 24);
            this.lblReceiverSensitivity2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblReceiverSensitivity2.Name = "lblReceiverSensitivity2";
            this.lblReceiverSensitivity2.Size = new System.Drawing.Size(215, 15);
            this.lblReceiverSensitivity2.TabIndex = 1;
            this.lblReceiverSensitivity2.Text = "Receiver Sensitivity (dBm)";
            // 
            // cbReceiverSensitivity2
            // 
            this.cbReceiverSensitivity2.FormattingEnabled = true;
            this.cbReceiverSensitivity2.Location = new System.Drawing.Point(232, 20);
            this.cbReceiverSensitivity2.Margin = new System.Windows.Forms.Padding(4);
            this.cbReceiverSensitivity2.Name = "cbReceiverSensitivity2";
            this.cbReceiverSensitivity2.Size = new System.Drawing.Size(87, 23);
            this.cbReceiverSensitivity2.TabIndex = 0;
            // 
            // gbRFTransmiter2
            // 
            this.gbRFTransmiter2.Controls.Add(this.cbTransmiterPower2);
            this.gbRFTransmiter2.Controls.Add(this.lblTransmiterPower2);
            this.gbRFTransmiter2.Location = new System.Drawing.Point(8, 66);
            this.gbRFTransmiter2.Margin = new System.Windows.Forms.Padding(4);
            this.gbRFTransmiter2.Name = "gbRFTransmiter2";
            this.gbRFTransmiter2.Padding = new System.Windows.Forms.Padding(4);
            this.gbRFTransmiter2.Size = new System.Drawing.Size(325, 60);
            this.gbRFTransmiter2.TabIndex = 7;
            this.gbRFTransmiter2.TabStop = false;
            this.gbRFTransmiter2.Text = "RF Transmiter";
            // 
            // cbTransmiterPower2
            // 
            this.cbTransmiterPower2.FormattingEnabled = true;
            this.cbTransmiterPower2.Location = new System.Drawing.Point(232, 24);
            this.cbTransmiterPower2.Margin = new System.Windows.Forms.Padding(4);
            this.cbTransmiterPower2.Name = "cbTransmiterPower2";
            this.cbTransmiterPower2.Size = new System.Drawing.Size(87, 23);
            this.cbTransmiterPower2.TabIndex = 5;
            // 
            // lblTransmiterPower2
            // 
            this.lblTransmiterPower2.AutoSize = true;
            this.lblTransmiterPower2.Location = new System.Drawing.Point(9, 28);
            this.lblTransmiterPower2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTransmiterPower2.Name = "lblTransmiterPower2";
            this.lblTransmiterPower2.Size = new System.Drawing.Size(183, 15);
            this.lblTransmiterPower2.TabIndex = 2;
            this.lblTransmiterPower2.Text = "Transmiter Power (dBm)";
            // 
            // tabPage3
            // 
            this.tabPage3.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tabPage3.Controls.Add(this.gbRFReceiver3);
            this.tabPage3.Controls.Add(this.gbRFTransmiter3);
            this.tabPage3.Location = new System.Drawing.Point(4, 25);
            this.tabPage3.Margin = new System.Windows.Forms.Padding(4);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(4);
            this.tabPage3.Size = new System.Drawing.Size(341, 136);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Antenna3";
            // 
            // gbRFReceiver3
            // 
            this.gbRFReceiver3.Controls.Add(this.lblReceiverSensitivity3);
            this.gbRFReceiver3.Controls.Add(this.cbReceiverSensitivity3);
            this.gbRFReceiver3.Location = new System.Drawing.Point(8, 8);
            this.gbRFReceiver3.Margin = new System.Windows.Forms.Padding(4);
            this.gbRFReceiver3.Name = "gbRFReceiver3";
            this.gbRFReceiver3.Padding = new System.Windows.Forms.Padding(4);
            this.gbRFReceiver3.Size = new System.Drawing.Size(325, 56);
            this.gbRFReceiver3.TabIndex = 6;
            this.gbRFReceiver3.TabStop = false;
            this.gbRFReceiver3.Text = "RF Receiver";
            // 
            // lblReceiverSensitivity3
            // 
            this.lblReceiverSensitivity3.AutoSize = true;
            this.lblReceiverSensitivity3.Location = new System.Drawing.Point(9, 24);
            this.lblReceiverSensitivity3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblReceiverSensitivity3.Name = "lblReceiverSensitivity3";
            this.lblReceiverSensitivity3.Size = new System.Drawing.Size(215, 15);
            this.lblReceiverSensitivity3.TabIndex = 1;
            this.lblReceiverSensitivity3.Text = "Receiver Sensitivity (dBm)";
            // 
            // cbReceiverSensitivity3
            // 
            this.cbReceiverSensitivity3.FormattingEnabled = true;
            this.cbReceiverSensitivity3.Location = new System.Drawing.Point(232, 20);
            this.cbReceiverSensitivity3.Margin = new System.Windows.Forms.Padding(4);
            this.cbReceiverSensitivity3.Name = "cbReceiverSensitivity3";
            this.cbReceiverSensitivity3.Size = new System.Drawing.Size(87, 23);
            this.cbReceiverSensitivity3.TabIndex = 0;
            // 
            // gbRFTransmiter3
            // 
            this.gbRFTransmiter3.Controls.Add(this.cbTransmiterPower3);
            this.gbRFTransmiter3.Controls.Add(this.lblTransmiterPower3);
            this.gbRFTransmiter3.Location = new System.Drawing.Point(8, 66);
            this.gbRFTransmiter3.Margin = new System.Windows.Forms.Padding(4);
            this.gbRFTransmiter3.Name = "gbRFTransmiter3";
            this.gbRFTransmiter3.Padding = new System.Windows.Forms.Padding(4);
            this.gbRFTransmiter3.Size = new System.Drawing.Size(327, 60);
            this.gbRFTransmiter3.TabIndex = 7;
            this.gbRFTransmiter3.TabStop = false;
            this.gbRFTransmiter3.Text = "RF Transmiter";
            // 
            // cbTransmiterPower3
            // 
            this.cbTransmiterPower3.FormattingEnabled = true;
            this.cbTransmiterPower3.Location = new System.Drawing.Point(232, 24);
            this.cbTransmiterPower3.Margin = new System.Windows.Forms.Padding(4);
            this.cbTransmiterPower3.Name = "cbTransmiterPower3";
            this.cbTransmiterPower3.Size = new System.Drawing.Size(87, 23);
            this.cbTransmiterPower3.TabIndex = 5;
            // 
            // lblTransmiterPower3
            // 
            this.lblTransmiterPower3.AutoSize = true;
            this.lblTransmiterPower3.Location = new System.Drawing.Point(9, 28);
            this.lblTransmiterPower3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTransmiterPower3.Name = "lblTransmiterPower3";
            this.lblTransmiterPower3.Size = new System.Drawing.Size(183, 15);
            this.lblTransmiterPower3.TabIndex = 2;
            this.lblTransmiterPower3.Text = "Transmiter Power (dBm)";
            // 
            // tabPage4
            // 
            this.tabPage4.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tabPage4.Controls.Add(this.gbRFReceiver4);
            this.tabPage4.Controls.Add(this.gbRFTransmiter4);
            this.tabPage4.Location = new System.Drawing.Point(4, 25);
            this.tabPage4.Margin = new System.Windows.Forms.Padding(4);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(4);
            this.tabPage4.Size = new System.Drawing.Size(341, 136);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "Antenna4";
            // 
            // gbRFReceiver4
            // 
            this.gbRFReceiver4.Controls.Add(this.lblReceiverSensitivity4);
            this.gbRFReceiver4.Controls.Add(this.cbReceiverSensitivity4);
            this.gbRFReceiver4.Location = new System.Drawing.Point(8, 8);
            this.gbRFReceiver4.Margin = new System.Windows.Forms.Padding(4);
            this.gbRFReceiver4.Name = "gbRFReceiver4";
            this.gbRFReceiver4.Padding = new System.Windows.Forms.Padding(4);
            this.gbRFReceiver4.Size = new System.Drawing.Size(327, 56);
            this.gbRFReceiver4.TabIndex = 6;
            this.gbRFReceiver4.TabStop = false;
            this.gbRFReceiver4.Text = "RF Receiver";
            // 
            // lblReceiverSensitivity4
            // 
            this.lblReceiverSensitivity4.AutoSize = true;
            this.lblReceiverSensitivity4.Location = new System.Drawing.Point(9, 24);
            this.lblReceiverSensitivity4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblReceiverSensitivity4.Name = "lblReceiverSensitivity4";
            this.lblReceiverSensitivity4.Size = new System.Drawing.Size(215, 15);
            this.lblReceiverSensitivity4.TabIndex = 1;
            this.lblReceiverSensitivity4.Text = "Receiver Sensitivity (dBm)";
            // 
            // cbReceiverSensitivity4
            // 
            this.cbReceiverSensitivity4.FormattingEnabled = true;
            this.cbReceiverSensitivity4.Location = new System.Drawing.Point(232, 20);
            this.cbReceiverSensitivity4.Margin = new System.Windows.Forms.Padding(4);
            this.cbReceiverSensitivity4.Name = "cbReceiverSensitivity4";
            this.cbReceiverSensitivity4.Size = new System.Drawing.Size(87, 23);
            this.cbReceiverSensitivity4.TabIndex = 0;
            // 
            // gbRFTransmiter4
            // 
            this.gbRFTransmiter4.Controls.Add(this.cbTransmiterPower4);
            this.gbRFTransmiter4.Controls.Add(this.lblTransmiterPower4);
            this.gbRFTransmiter4.Location = new System.Drawing.Point(8, 66);
            this.gbRFTransmiter4.Margin = new System.Windows.Forms.Padding(4);
            this.gbRFTransmiter4.Name = "gbRFTransmiter4";
            this.gbRFTransmiter4.Padding = new System.Windows.Forms.Padding(4);
            this.gbRFTransmiter4.Size = new System.Drawing.Size(327, 60);
            this.gbRFTransmiter4.TabIndex = 7;
            this.gbRFTransmiter4.TabStop = false;
            this.gbRFTransmiter4.Text = "RF Transmiter";
            // 
            // cbTransmiterPower4
            // 
            this.cbTransmiterPower4.FormattingEnabled = true;
            this.cbTransmiterPower4.Location = new System.Drawing.Point(232, 24);
            this.cbTransmiterPower4.Margin = new System.Windows.Forms.Padding(4);
            this.cbTransmiterPower4.Name = "cbTransmiterPower4";
            this.cbTransmiterPower4.Size = new System.Drawing.Size(83, 23);
            this.cbTransmiterPower4.TabIndex = 5;
            // 
            // lblTransmiterPower4
            // 
            this.lblTransmiterPower4.AutoSize = true;
            this.lblTransmiterPower4.Location = new System.Drawing.Point(9, 28);
            this.lblTransmiterPower4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTransmiterPower4.Name = "lblTransmiterPower4";
            this.lblTransmiterPower4.Size = new System.Drawing.Size(183, 15);
            this.lblTransmiterPower4.TabIndex = 2;
            this.lblTransmiterPower4.Text = "Transmiter Power (dBm)";
            // 
            // cbAntenna4
            // 
            this.cbAntenna4.AllowDrop = true;
            this.cbAntenna4.AutoSize = true;
            this.cbAntenna4.Location = new System.Drawing.Point(227, 640);
            this.cbAntenna4.Margin = new System.Windows.Forms.Padding(4);
            this.cbAntenna4.Name = "cbAntenna4";
            this.cbAntenna4.Size = new System.Drawing.Size(37, 19);
            this.cbAntenna4.TabIndex = 18;
            this.cbAntenna4.Text = "4";
            this.cbAntenna4.UseVisualStyleBackColor = true;
            // 
            // gbC1G2InventoryCommand
            // 
            this.gbC1G2InventoryCommand.Controls.Add(this.gbImpinj);
            this.gbC1G2InventoryCommand.Controls.Add(this.gbC1G2SingulationControl);
            this.gbC1G2InventoryCommand.Controls.Add(this.gbC1G2RFControl);
            this.gbC1G2InventoryCommand.Controls.Add(this.lblTagInventoryStateAware);
            this.gbC1G2InventoryCommand.Controls.Add(this.cbTagInventoryStateAware);
            this.gbC1G2InventoryCommand.Location = new System.Drawing.Point(11, 8);
            this.gbC1G2InventoryCommand.Margin = new System.Windows.Forms.Padding(4);
            this.gbC1G2InventoryCommand.Name = "gbC1G2InventoryCommand";
            this.gbC1G2InventoryCommand.Padding = new System.Windows.Forms.Padding(4);
            this.gbC1G2InventoryCommand.Size = new System.Drawing.Size(347, 612);
            this.gbC1G2InventoryCommand.TabIndex = 14;
            this.gbC1G2InventoryCommand.TabStop = false;
            this.gbC1G2InventoryCommand.Text = "C1G2 Inventory Command";
            // 
            // gbImpinj
            // 
            this.gbImpinj.Controls.Add(this.lblScope2);
            this.gbImpinj.Controls.Add(this.lblScope1);
            this.gbImpinj.Controls.Add(this.cbImpinjLowDutyCycleMode);
            this.gbImpinj.Controls.Add(this.lblEmptyFieldTimeout);
            this.gbImpinj.Controls.Add(this.tbxEmptyFieldTimeout);
            this.gbImpinj.Controls.Add(this.tbxFieldPingInterval);
            this.gbImpinj.Controls.Add(this.lblFieldPingInterval);
            this.gbImpinj.Controls.Add(this.tbxReducedChannelList);
            this.gbImpinj.Controls.Add(this.lblReducedChannelList);
            this.gbImpinj.Controls.Add(this.cbImpinjReducedPowerFrequencyMode);
            this.gbImpinj.Controls.Add(this.cbImpiJSearchMode);
            this.gbImpinj.Controls.Add(this.lblImpinjInventorySearchMode);
            this.gbImpinj.Location = new System.Drawing.Point(8, 311);
            this.gbImpinj.Margin = new System.Windows.Forms.Padding(4);
            this.gbImpinj.Name = "gbImpinj";
            this.gbImpinj.Padding = new System.Windows.Forms.Padding(4);
            this.gbImpinj.Size = new System.Drawing.Size(328, 291);
            this.gbImpinj.TabIndex = 4;
            this.gbImpinj.TabStop = false;
            this.gbImpinj.Text = "Impinj";
            // 
            // lblScope2
            // 
            this.lblScope2.AutoSize = true;
            this.lblScope2.Location = new System.Drawing.Point(163, 255);
            this.lblScope2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblScope2.Name = "lblScope2";
            this.lblScope2.Size = new System.Drawing.Size(63, 15);
            this.lblScope2.TabIndex = 13;
            this.lblScope2.Text = "0-65000";
            // 
            // lblScope1
            // 
            this.lblScope1.AutoSize = true;
            this.lblScope1.Location = new System.Drawing.Point(159, 210);
            this.lblScope1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblScope1.Name = "lblScope1";
            this.lblScope1.Size = new System.Drawing.Size(63, 15);
            this.lblScope1.TabIndex = 12;
            this.lblScope1.Text = "0-65000";
            // 
            // cbImpinjLowDutyCycleMode
            // 
            this.cbImpinjLowDutyCycleMode.AutoSize = true;
            this.cbImpinjLowDutyCycleMode.Location = new System.Drawing.Point(7, 158);
            this.cbImpinjLowDutyCycleMode.Margin = new System.Windows.Forms.Padding(4);
            this.cbImpinjLowDutyCycleMode.Name = "cbImpinjLowDutyCycleMode";
            this.cbImpinjLowDutyCycleMode.Size = new System.Drawing.Size(237, 19);
            this.cbImpinjLowDutyCycleMode.TabIndex = 9;
            this.cbImpinjLowDutyCycleMode.Text = "Impinj Low Duty Cycle Mode";
            this.cbImpinjLowDutyCycleMode.UseVisualStyleBackColor = true;
            this.cbImpinjLowDutyCycleMode.CheckedChanged += new System.EventHandler(this.cbImpinjLowDutyCycleMode_CheckedChanged);
            // 
            // lblEmptyFieldTimeout
            // 
            this.lblEmptyFieldTimeout.AutoSize = true;
            this.lblEmptyFieldTimeout.Enabled = false;
            this.lblEmptyFieldTimeout.Location = new System.Drawing.Point(28, 181);
            this.lblEmptyFieldTimeout.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblEmptyFieldTimeout.Name = "lblEmptyFieldTimeout";
            this.lblEmptyFieldTimeout.Size = new System.Drawing.Size(199, 15);
            this.lblEmptyFieldTimeout.TabIndex = 10;
            this.lblEmptyFieldTimeout.Text = "Empty Field Timeout (ms)";
            // 
            // tbxEmptyFieldTimeout
            // 
            this.tbxEmptyFieldTimeout.Enabled = false;
            this.tbxEmptyFieldTimeout.Location = new System.Drawing.Point(48, 202);
            this.tbxEmptyFieldTimeout.Margin = new System.Windows.Forms.Padding(4);
            this.tbxEmptyFieldTimeout.Name = "tbxEmptyFieldTimeout";
            this.tbxEmptyFieldTimeout.Size = new System.Drawing.Size(101, 25);
            this.tbxEmptyFieldTimeout.TabIndex = 11;
            // 
            // tbxFieldPingInterval
            // 
            this.tbxFieldPingInterval.Enabled = false;
            this.tbxFieldPingInterval.Location = new System.Drawing.Point(48, 251);
            this.tbxFieldPingInterval.Margin = new System.Windows.Forms.Padding(4);
            this.tbxFieldPingInterval.Name = "tbxFieldPingInterval";
            this.tbxFieldPingInterval.Size = new System.Drawing.Size(101, 25);
            this.tbxFieldPingInterval.TabIndex = 10;
            // 
            // lblFieldPingInterval
            // 
            this.lblFieldPingInterval.AutoSize = true;
            this.lblFieldPingInterval.Enabled = false;
            this.lblFieldPingInterval.Location = new System.Drawing.Point(28, 232);
            this.lblFieldPingInterval.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblFieldPingInterval.Name = "lblFieldPingInterval";
            this.lblFieldPingInterval.Size = new System.Drawing.Size(199, 15);
            this.lblFieldPingInterval.TabIndex = 9;
            this.lblFieldPingInterval.Text = "Field Ping Interval (ms)";
            // 
            // tbxReducedChannelList
            // 
            this.tbxReducedChannelList.Enabled = false;
            this.tbxReducedChannelList.Location = new System.Drawing.Point(48, 124);
            this.tbxReducedChannelList.Margin = new System.Windows.Forms.Padding(4);
            this.tbxReducedChannelList.Name = "tbxReducedChannelList";
            this.tbxReducedChannelList.Size = new System.Drawing.Size(168, 25);
            this.tbxReducedChannelList.TabIndex = 8;
            // 
            // lblReducedChannelList
            // 
            this.lblReducedChannelList.AutoSize = true;
            this.lblReducedChannelList.Enabled = false;
            this.lblReducedChannelList.Location = new System.Drawing.Point(27, 102);
            this.lblReducedChannelList.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblReducedChannelList.Name = "lblReducedChannelList";
            this.lblReducedChannelList.Size = new System.Drawing.Size(215, 15);
            this.lblReducedChannelList.TabIndex = 7;
            this.lblReducedChannelList.Text = "Channel List (e.g.1,3,6,7)";
            // 
            // cbImpinjReducedPowerFrequencyMode
            // 
            this.cbImpinjReducedPowerFrequencyMode.AutoSize = true;
            this.cbImpinjReducedPowerFrequencyMode.Location = new System.Drawing.Point(7, 78);
            this.cbImpinjReducedPowerFrequencyMode.Margin = new System.Windows.Forms.Padding(4);
            this.cbImpinjReducedPowerFrequencyMode.Name = "cbImpinjReducedPowerFrequencyMode";
            this.cbImpinjReducedPowerFrequencyMode.Size = new System.Drawing.Size(309, 19);
            this.cbImpinjReducedPowerFrequencyMode.TabIndex = 6;
            this.cbImpinjReducedPowerFrequencyMode.Text = "Impinj Reduced Power Frequency Mode";
            this.cbImpinjReducedPowerFrequencyMode.UseVisualStyleBackColor = true;
            this.cbImpinjReducedPowerFrequencyMode.CheckedChanged += new System.EventHandler(this.cbImpinjReducedPowerFrequencyMode_CheckedChanged);
            // 
            // cbImpiJSearchMode
            // 
            this.cbImpiJSearchMode.FormattingEnabled = true;
            this.cbImpiJSearchMode.Location = new System.Drawing.Point(31, 45);
            this.cbImpiJSearchMode.Margin = new System.Windows.Forms.Padding(4);
            this.cbImpiJSearchMode.Name = "cbImpiJSearchMode";
            this.cbImpiJSearchMode.Size = new System.Drawing.Size(245, 23);
            this.cbImpiJSearchMode.TabIndex = 1;
            // 
            // lblImpinjInventorySearchMode
            // 
            this.lblImpinjInventorySearchMode.AutoSize = true;
            this.lblImpinjInventorySearchMode.Location = new System.Drawing.Point(5, 26);
            this.lblImpinjInventorySearchMode.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblImpinjInventorySearchMode.Name = "lblImpinjInventorySearchMode";
            this.lblImpinjInventorySearchMode.Size = new System.Drawing.Size(175, 15);
            this.lblImpinjInventorySearchMode.TabIndex = 0;
            this.lblImpinjInventorySearchMode.Text = "Inventory Search Mode";
            // 
            // gbC1G2SingulationControl
            // 
            this.gbC1G2SingulationControl.Controls.Add(this.lblScope3);
            this.gbC1G2SingulationControl.Controls.Add(this.tbxTagTransitTime);
            this.gbC1G2SingulationControl.Controls.Add(this.lblTagTransmiteTime);
            this.gbC1G2SingulationControl.Controls.Add(this.tbxTagPopulation);
            this.gbC1G2SingulationControl.Controls.Add(this.lblTagPopulation);
            this.gbC1G2SingulationControl.Controls.Add(this.cbSession);
            this.gbC1G2SingulationControl.Controls.Add(this.lblSession);
            this.gbC1G2SingulationControl.Location = new System.Drawing.Point(8, 149);
            this.gbC1G2SingulationControl.Margin = new System.Windows.Forms.Padding(4);
            this.gbC1G2SingulationControl.Name = "gbC1G2SingulationControl";
            this.gbC1G2SingulationControl.Padding = new System.Windows.Forms.Padding(4);
            this.gbC1G2SingulationControl.Size = new System.Drawing.Size(328, 155);
            this.gbC1G2SingulationControl.TabIndex = 3;
            this.gbC1G2SingulationControl.TabStop = false;
            this.gbC1G2SingulationControl.Text = "C1G2 Singulation Control";
            // 
            // lblScope3
            // 
            this.lblScope3.AutoSize = true;
            this.lblScope3.Location = new System.Drawing.Point(180, 74);
            this.lblScope3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblScope3.Name = "lblScope3";
            this.lblScope3.Size = new System.Drawing.Size(63, 15);
            this.lblScope3.TabIndex = 14;
            this.lblScope3.Text = "0-65000";
            // 
            // tbxTagTransitTime
            // 
            this.tbxTagTransitTime.Location = new System.Drawing.Point(31, 121);
            this.tbxTagTransitTime.Margin = new System.Windows.Forms.Padding(4);
            this.tbxTagTransitTime.Name = "tbxTagTransitTime";
            this.tbxTagTransitTime.Size = new System.Drawing.Size(133, 25);
            this.tbxTagTransitTime.TabIndex = 5;
            // 
            // lblTagTransmiteTime
            // 
            this.lblTagTransmiteTime.AutoSize = true;
            this.lblTagTransmiteTime.Location = new System.Drawing.Point(8, 102);
            this.lblTagTransmiteTime.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTagTransmiteTime.Name = "lblTagTransmiteTime";
            this.lblTagTransmiteTime.Size = new System.Drawing.Size(175, 15);
            this.lblTagTransmiteTime.TabIndex = 4;
            this.lblTagTransmiteTime.Text = "Tag Transit Time (ms)";
            // 
            // tbxTagPopulation
            // 
            this.tbxTagPopulation.Location = new System.Drawing.Point(31, 70);
            this.tbxTagPopulation.Margin = new System.Windows.Forms.Padding(4);
            this.tbxTagPopulation.Name = "tbxTagPopulation";
            this.tbxTagPopulation.Size = new System.Drawing.Size(133, 25);
            this.tbxTagPopulation.TabIndex = 3;
            // 
            // lblTagPopulation
            // 
            this.lblTagPopulation.AutoSize = true;
            this.lblTagPopulation.Location = new System.Drawing.Point(8, 51);
            this.lblTagPopulation.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTagPopulation.Name = "lblTagPopulation";
            this.lblTagPopulation.Size = new System.Drawing.Size(119, 15);
            this.lblTagPopulation.TabIndex = 2;
            this.lblTagPopulation.Text = "Tag Population";
            // 
            // cbSession
            // 
            this.cbSession.FormattingEnabled = true;
            this.cbSession.Location = new System.Drawing.Point(128, 22);
            this.cbSession.Margin = new System.Windows.Forms.Padding(4);
            this.cbSession.Name = "cbSession";
            this.cbSession.Size = new System.Drawing.Size(193, 23);
            this.cbSession.TabIndex = 1;
            // 
            // lblSession
            // 
            this.lblSession.AutoSize = true;
            this.lblSession.Location = new System.Drawing.Point(9, 26);
            this.lblSession.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblSession.Name = "lblSession";
            this.lblSession.Size = new System.Drawing.Size(63, 15);
            this.lblSession.TabIndex = 0;
            this.lblSession.Text = "Session";
            // 
            // gbC1G2RFControl
            // 
            this.gbC1G2RFControl.Controls.Add(this.tbxTari);
            this.gbC1G2RFControl.Controls.Add(this.lblTari);
            this.gbC1G2RFControl.Controls.Add(this.cbModeIndex);
            this.gbC1G2RFControl.Controls.Add(this.lblModeIndex);
            this.gbC1G2RFControl.Location = new System.Drawing.Point(8, 52);
            this.gbC1G2RFControl.Margin = new System.Windows.Forms.Padding(4);
            this.gbC1G2RFControl.Name = "gbC1G2RFControl";
            this.gbC1G2RFControl.Padding = new System.Windows.Forms.Padding(4);
            this.gbC1G2RFControl.Size = new System.Drawing.Size(328, 89);
            this.gbC1G2RFControl.TabIndex = 2;
            this.gbC1G2RFControl.TabStop = false;
            this.gbC1G2RFControl.Text = "C1G2 RF Control";
            // 
            // tbxTari
            // 
            this.tbxTari.Location = new System.Drawing.Point(128, 55);
            this.tbxTari.Margin = new System.Windows.Forms.Padding(4);
            this.tbxTari.Name = "tbxTari";
            this.tbxTari.Size = new System.Drawing.Size(193, 25);
            this.tbxTari.TabIndex = 3;
            // 
            // lblTari
            // 
            this.lblTari.AutoSize = true;
            this.lblTari.Location = new System.Drawing.Point(8, 60);
            this.lblTari.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTari.Name = "lblTari";
            this.lblTari.Size = new System.Drawing.Size(79, 15);
            this.lblTari.TabIndex = 2;
            this.lblTari.Text = "Tari (ns)";
            // 
            // cbModeIndex
            // 
            this.cbModeIndex.FormattingEnabled = true;
            this.cbModeIndex.Location = new System.Drawing.Point(128, 22);
            this.cbModeIndex.Margin = new System.Windows.Forms.Padding(4);
            this.cbModeIndex.Name = "cbModeIndex";
            this.cbModeIndex.Size = new System.Drawing.Size(193, 23);
            this.cbModeIndex.TabIndex = 1;
            // 
            // lblModeIndex
            // 
            this.lblModeIndex.AutoSize = true;
            this.lblModeIndex.Location = new System.Drawing.Point(8, 29);
            this.lblModeIndex.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblModeIndex.Name = "lblModeIndex";
            this.lblModeIndex.Size = new System.Drawing.Size(119, 15);
            this.lblModeIndex.TabIndex = 0;
            this.lblModeIndex.Text = "Inventory Mode";
            // 
            // lblTagInventoryStateAware
            // 
            this.lblTagInventoryStateAware.AutoSize = true;
            this.lblTagInventoryStateAware.Location = new System.Drawing.Point(5, 24);
            this.lblTagInventoryStateAware.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTagInventoryStateAware.Name = "lblTagInventoryStateAware";
            this.lblTagInventoryStateAware.Size = new System.Drawing.Size(207, 15);
            this.lblTagInventoryStateAware.TabIndex = 1;
            this.lblTagInventoryStateAware.Text = "Tag Inventory State Aware";
            // 
            // cbTagInventoryStateAware
            // 
            this.cbTagInventoryStateAware.FormattingEnabled = true;
            this.cbTagInventoryStateAware.Items.AddRange(new object[] {
            "false",
            "true"});
            this.cbTagInventoryStateAware.Location = new System.Drawing.Point(233, 20);
            this.cbTagInventoryStateAware.Margin = new System.Windows.Forms.Padding(4);
            this.cbTagInventoryStateAware.Name = "cbTagInventoryStateAware";
            this.cbTagInventoryStateAware.Size = new System.Drawing.Size(96, 23);
            this.cbTagInventoryStateAware.TabIndex = 0;
            this.cbTagInventoryStateAware.Text = "false";
            // 
            // cbAntenna3
            // 
            this.cbAntenna3.AutoSize = true;
            this.cbAntenna3.Location = new System.Drawing.Point(183, 640);
            this.cbAntenna3.Margin = new System.Windows.Forms.Padding(4);
            this.cbAntenna3.Name = "cbAntenna3";
            this.cbAntenna3.Size = new System.Drawing.Size(37, 19);
            this.cbAntenna3.TabIndex = 17;
            this.cbAntenna3.Text = "3";
            this.cbAntenna3.UseVisualStyleBackColor = true;
            // 
            // cbAntenna2
            // 
            this.cbAntenna2.AutoSize = true;
            this.cbAntenna2.Enabled = false;
            this.cbAntenna2.Location = new System.Drawing.Point(139, 640);
            this.cbAntenna2.Margin = new System.Windows.Forms.Padding(4);
            this.cbAntenna2.Name = "cbAntenna2";
            this.cbAntenna2.Size = new System.Drawing.Size(37, 19);
            this.cbAntenna2.TabIndex = 16;
            this.cbAntenna2.Text = "2";
            this.cbAntenna2.UseVisualStyleBackColor = true;
            // 
            // cbAntenna1
            // 
            this.cbAntenna1.AutoSize = true;
            this.cbAntenna1.Location = new System.Drawing.Point(97, 640);
            this.cbAntenna1.Margin = new System.Windows.Forms.Padding(4);
            this.cbAntenna1.Name = "cbAntenna1";
            this.cbAntenna1.Size = new System.Drawing.Size(37, 19);
            this.cbAntenna1.TabIndex = 15;
            this.cbAntenna1.Text = "1";
            this.cbAntenna1.UseVisualStyleBackColor = true;
            // 
            // lblAntennaID
            // 
            this.lblAntennaID.AutoSize = true;
            this.lblAntennaID.Location = new System.Drawing.Point(11, 641);
            this.lblAntennaID.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblAntennaID.Name = "lblAntennaID";
            this.lblAntennaID.Size = new System.Drawing.Size(79, 15);
            this.lblAntennaID.TabIndex = 13;
            this.lblAntennaID.Text = "AntennaID";
            // 
            // tpRoSpec
            // 
            this.tpRoSpec.Controls.Add(this.gbImpinjTagReportContentSelector);
            this.tpRoSpec.Controls.Add(this.gbTagReportContentSelector);
            this.tpRoSpec.Controls.Add(this.nudN);
            this.tpRoSpec.Controls.Add(this.lblN);
            this.tpRoSpec.Controls.Add(this.cbROReportTrigger);
            this.tpRoSpec.Controls.Add(this.lblROReportTrigger);
            this.tpRoSpec.Location = new System.Drawing.Point(4, 25);
            this.tpRoSpec.Margin = new System.Windows.Forms.Padding(4);
            this.tpRoSpec.Name = "tpRoSpec";
            this.tpRoSpec.Size = new System.Drawing.Size(371, 846);
            this.tpRoSpec.TabIndex = 2;
            this.tpRoSpec.Text = "RoSpec";
            this.tpRoSpec.UseVisualStyleBackColor = true;
            // 
            // gbImpinjTagReportContentSelector
            // 
            this.gbImpinjTagReportContentSelector.Controls.Add(this.cbImpinjEnableSerializedTID);
            this.gbImpinjTagReportContentSelector.Controls.Add(this.cbImpinjEnableRFPhaseAngle);
            this.gbImpinjTagReportContentSelector.Controls.Add(this.cbImpinjEnableRFDopplerFrequency);
            this.gbImpinjTagReportContentSelector.Controls.Add(this.cbImpinjEnablePeakRSSI);
            this.gbImpinjTagReportContentSelector.Controls.Add(this.cbImpinjEnableOptimizedRead);
            this.gbImpinjTagReportContentSelector.Controls.Add(this.cbImpinjEnableGPSCoordinates);
            this.gbImpinjTagReportContentSelector.Location = new System.Drawing.Point(13, 539);
            this.gbImpinjTagReportContentSelector.Margin = new System.Windows.Forms.Padding(4);
            this.gbImpinjTagReportContentSelector.Name = "gbImpinjTagReportContentSelector";
            this.gbImpinjTagReportContentSelector.Padding = new System.Windows.Forms.Padding(4);
            this.gbImpinjTagReportContentSelector.Size = new System.Drawing.Size(336, 195);
            this.gbImpinjTagReportContentSelector.TabIndex = 12;
            this.gbImpinjTagReportContentSelector.TabStop = false;
            this.gbImpinjTagReportContentSelector.Text = "Impinj Tag Report Content Selector";
            // 
            // cbImpinjEnableSerializedTID
            // 
            this.cbImpinjEnableSerializedTID.AutoSize = true;
            this.cbImpinjEnableSerializedTID.Location = new System.Drawing.Point(9, 25);
            this.cbImpinjEnableSerializedTID.Margin = new System.Windows.Forms.Padding(4);
            this.cbImpinjEnableSerializedTID.Name = "cbImpinjEnableSerializedTID";
            this.cbImpinjEnableSerializedTID.Size = new System.Drawing.Size(253, 19);
            this.cbImpinjEnableSerializedTID.TabIndex = 5;
            this.cbImpinjEnableSerializedTID.Text = "Impinj Enable Serialized TID";
            this.cbImpinjEnableSerializedTID.UseVisualStyleBackColor = true;
            // 
            // cbImpinjEnableRFPhaseAngle
            // 
            this.cbImpinjEnableRFPhaseAngle.AutoSize = true;
            this.cbImpinjEnableRFPhaseAngle.Location = new System.Drawing.Point(8, 52);
            this.cbImpinjEnableRFPhaseAngle.Margin = new System.Windows.Forms.Padding(4);
            this.cbImpinjEnableRFPhaseAngle.Name = "cbImpinjEnableRFPhaseAngle";
            this.cbImpinjEnableRFPhaseAngle.Size = new System.Drawing.Size(253, 19);
            this.cbImpinjEnableRFPhaseAngle.TabIndex = 4;
            this.cbImpinjEnableRFPhaseAngle.Text = "Impinj Enable RF Phase Angle";
            this.cbImpinjEnableRFPhaseAngle.UseVisualStyleBackColor = true;
            // 
            // cbImpinjEnableRFDopplerFrequency
            // 
            this.cbImpinjEnableRFDopplerFrequency.AutoSize = true;
            this.cbImpinjEnableRFDopplerFrequency.Location = new System.Drawing.Point(8, 164);
            this.cbImpinjEnableRFDopplerFrequency.Margin = new System.Windows.Forms.Padding(4);
            this.cbImpinjEnableRFDopplerFrequency.Name = "cbImpinjEnableRFDopplerFrequency";
            this.cbImpinjEnableRFDopplerFrequency.Size = new System.Drawing.Size(301, 19);
            this.cbImpinjEnableRFDopplerFrequency.TabIndex = 3;
            this.cbImpinjEnableRFDopplerFrequency.Text = "Impinj Enable RF Doppler Frequency";
            this.cbImpinjEnableRFDopplerFrequency.UseVisualStyleBackColor = true;
            // 
            // cbImpinjEnablePeakRSSI
            // 
            this.cbImpinjEnablePeakRSSI.AutoSize = true;
            this.cbImpinjEnablePeakRSSI.Location = new System.Drawing.Point(8, 81);
            this.cbImpinjEnablePeakRSSI.Margin = new System.Windows.Forms.Padding(4);
            this.cbImpinjEnablePeakRSSI.Name = "cbImpinjEnablePeakRSSI";
            this.cbImpinjEnablePeakRSSI.Size = new System.Drawing.Size(213, 19);
            this.cbImpinjEnablePeakRSSI.TabIndex = 2;
            this.cbImpinjEnablePeakRSSI.Text = "Impinj Enable Peak RSSI";
            this.cbImpinjEnablePeakRSSI.UseVisualStyleBackColor = true;
            // 
            // cbImpinjEnableOptimizedRead
            // 
            this.cbImpinjEnableOptimizedRead.AutoSize = true;
            this.cbImpinjEnableOptimizedRead.Location = new System.Drawing.Point(9, 136);
            this.cbImpinjEnableOptimizedRead.Margin = new System.Windows.Forms.Padding(4);
            this.cbImpinjEnableOptimizedRead.Name = "cbImpinjEnableOptimizedRead";
            this.cbImpinjEnableOptimizedRead.Size = new System.Drawing.Size(253, 19);
            this.cbImpinjEnableOptimizedRead.TabIndex = 1;
            this.cbImpinjEnableOptimizedRead.Text = "Impinj Enable Optimized Read";
            this.cbImpinjEnableOptimizedRead.UseVisualStyleBackColor = true;
            // 
            // cbImpinjEnableGPSCoordinates
            // 
            this.cbImpinjEnableGPSCoordinates.AutoSize = true;
            this.cbImpinjEnableGPSCoordinates.Location = new System.Drawing.Point(9, 109);
            this.cbImpinjEnableGPSCoordinates.Margin = new System.Windows.Forms.Padding(4);
            this.cbImpinjEnableGPSCoordinates.Name = "cbImpinjEnableGPSCoordinates";
            this.cbImpinjEnableGPSCoordinates.Size = new System.Drawing.Size(261, 19);
            this.cbImpinjEnableGPSCoordinates.TabIndex = 0;
            this.cbImpinjEnableGPSCoordinates.Text = "Impinj Enable GPS Coordinates";
            this.cbImpinjEnableGPSCoordinates.UseVisualStyleBackColor = true;
            // 
            // gbTagReportContentSelector
            // 
            this.gbTagReportContentSelector.Controls.Add(this.gbC1G2EPCMemorySelector);
            this.gbTagReportContentSelector.Controls.Add(this.cbEnableTagSeenCount);
            this.gbTagReportContentSelector.Controls.Add(this.cbEnableSpecIndex);
            this.gbTagReportContentSelector.Controls.Add(this.cbEnableROSpecID);
            this.gbTagReportContentSelector.Controls.Add(this.cbEnablePeakRSSI);
            this.gbTagReportContentSelector.Controls.Add(this.cbEnableLastSeenTimestamp);
            this.gbTagReportContentSelector.Controls.Add(this.cbEnableAccessSpecID);
            this.gbTagReportContentSelector.Controls.Add(this.cbEnableChannelIndex);
            this.gbTagReportContentSelector.Controls.Add(this.cbEnableInventoryParameterSpecID);
            this.gbTagReportContentSelector.Controls.Add(this.cbEnableAntennaID);
            this.gbTagReportContentSelector.Controls.Add(this.cbEnableFirstSeenTimestamp);
            this.gbTagReportContentSelector.Location = new System.Drawing.Point(8, 112);
            this.gbTagReportContentSelector.Margin = new System.Windows.Forms.Padding(4);
            this.gbTagReportContentSelector.Name = "gbTagReportContentSelector";
            this.gbTagReportContentSelector.Padding = new System.Windows.Forms.Padding(4);
            this.gbTagReportContentSelector.Size = new System.Drawing.Size(341, 408);
            this.gbTagReportContentSelector.TabIndex = 11;
            this.gbTagReportContentSelector.TabStop = false;
            this.gbTagReportContentSelector.Text = "Tag Report Content Selector";
            // 
            // gbC1G2EPCMemorySelector
            // 
            this.gbC1G2EPCMemorySelector.Controls.Add(this.cbEnablePCBits);
            this.gbC1G2EPCMemorySelector.Controls.Add(this.cbEnableCRC);
            this.gbC1G2EPCMemorySelector.Location = new System.Drawing.Point(9, 311);
            this.gbC1G2EPCMemorySelector.Margin = new System.Windows.Forms.Padding(4);
            this.gbC1G2EPCMemorySelector.Name = "gbC1G2EPCMemorySelector";
            this.gbC1G2EPCMemorySelector.Padding = new System.Windows.Forms.Padding(4);
            this.gbC1G2EPCMemorySelector.Size = new System.Drawing.Size(324, 80);
            this.gbC1G2EPCMemorySelector.TabIndex = 10;
            this.gbC1G2EPCMemorySelector.TabStop = false;
            this.gbC1G2EPCMemorySelector.Text = "C1G2 EPC Memory Selector";
            // 
            // cbEnablePCBits
            // 
            this.cbEnablePCBits.AutoSize = true;
            this.cbEnablePCBits.Location = new System.Drawing.Point(9, 50);
            this.cbEnablePCBits.Margin = new System.Windows.Forms.Padding(4);
            this.cbEnablePCBits.Name = "cbEnablePCBits";
            this.cbEnablePCBits.Size = new System.Drawing.Size(141, 19);
            this.cbEnablePCBits.TabIndex = 1;
            this.cbEnablePCBits.Text = "Enable PC Bits";
            this.cbEnablePCBits.UseVisualStyleBackColor = true;
            // 
            // cbEnableCRC
            // 
            this.cbEnableCRC.AutoSize = true;
            this.cbEnableCRC.Location = new System.Drawing.Point(9, 26);
            this.cbEnableCRC.Margin = new System.Windows.Forms.Padding(4);
            this.cbEnableCRC.Name = "cbEnableCRC";
            this.cbEnableCRC.Size = new System.Drawing.Size(109, 19);
            this.cbEnableCRC.TabIndex = 0;
            this.cbEnableCRC.Text = "Enable CRC";
            this.cbEnableCRC.UseVisualStyleBackColor = true;
            // 
            // cbEnableTagSeenCount
            // 
            this.cbEnableTagSeenCount.AutoSize = true;
            this.cbEnableTagSeenCount.Location = new System.Drawing.Point(8, 255);
            this.cbEnableTagSeenCount.Margin = new System.Windows.Forms.Padding(4);
            this.cbEnableTagSeenCount.Name = "cbEnableTagSeenCount";
            this.cbEnableTagSeenCount.Size = new System.Drawing.Size(189, 19);
            this.cbEnableTagSeenCount.TabIndex = 9;
            this.cbEnableTagSeenCount.Text = "Enable TagSeen Count";
            this.cbEnableTagSeenCount.UseVisualStyleBackColor = true;
            // 
            // cbEnableSpecIndex
            // 
            this.cbEnableSpecIndex.AutoSize = true;
            this.cbEnableSpecIndex.Location = new System.Drawing.Point(8, 55);
            this.cbEnableSpecIndex.Margin = new System.Windows.Forms.Padding(4);
            this.cbEnableSpecIndex.Name = "cbEnableSpecIndex";
            this.cbEnableSpecIndex.Size = new System.Drawing.Size(165, 19);
            this.cbEnableSpecIndex.TabIndex = 8;
            this.cbEnableSpecIndex.Text = "Enable Spec Index";
            this.cbEnableSpecIndex.UseVisualStyleBackColor = true;
            // 
            // cbEnableROSpecID
            // 
            this.cbEnableROSpecID.AutoSize = true;
            this.cbEnableROSpecID.Location = new System.Drawing.Point(8, 28);
            this.cbEnableROSpecID.Margin = new System.Windows.Forms.Padding(4);
            this.cbEnableROSpecID.Name = "cbEnableROSpecID";
            this.cbEnableROSpecID.Size = new System.Drawing.Size(165, 19);
            this.cbEnableROSpecID.TabIndex = 7;
            this.cbEnableROSpecID.Text = "Enable RO Spec ID";
            this.cbEnableROSpecID.UseVisualStyleBackColor = true;
            // 
            // cbEnablePeakRSSI
            // 
            this.cbEnablePeakRSSI.AutoSize = true;
            this.cbEnablePeakRSSI.Location = new System.Drawing.Point(8, 172);
            this.cbEnablePeakRSSI.Margin = new System.Windows.Forms.Padding(4);
            this.cbEnablePeakRSSI.Name = "cbEnablePeakRSSI";
            this.cbEnablePeakRSSI.Size = new System.Drawing.Size(157, 19);
            this.cbEnablePeakRSSI.TabIndex = 6;
            this.cbEnablePeakRSSI.Text = "Enable Peak RSSI";
            this.cbEnablePeakRSSI.UseVisualStyleBackColor = true;
            // 
            // cbEnableLastSeenTimestamp
            // 
            this.cbEnableLastSeenTimestamp.AutoSize = true;
            this.cbEnableLastSeenTimestamp.Location = new System.Drawing.Point(8, 228);
            this.cbEnableLastSeenTimestamp.Margin = new System.Windows.Forms.Padding(4);
            this.cbEnableLastSeenTimestamp.Name = "cbEnableLastSeenTimestamp";
            this.cbEnableLastSeenTimestamp.Size = new System.Drawing.Size(229, 19);
            this.cbEnableLastSeenTimestamp.TabIndex = 5;
            this.cbEnableLastSeenTimestamp.Text = "Enable LastSeen Timestamp";
            this.cbEnableLastSeenTimestamp.UseVisualStyleBackColor = true;
            // 
            // cbEnableAccessSpecID
            // 
            this.cbEnableAccessSpecID.AutoSize = true;
            this.cbEnableAccessSpecID.Location = new System.Drawing.Point(8, 282);
            this.cbEnableAccessSpecID.Margin = new System.Windows.Forms.Padding(4);
            this.cbEnableAccessSpecID.Name = "cbEnableAccessSpecID";
            this.cbEnableAccessSpecID.Size = new System.Drawing.Size(197, 19);
            this.cbEnableAccessSpecID.TabIndex = 0;
            this.cbEnableAccessSpecID.Text = "Enable Access Spec ID";
            this.cbEnableAccessSpecID.UseVisualStyleBackColor = true;
            // 
            // cbEnableChannelIndex
            // 
            this.cbEnableChannelIndex.AutoSize = true;
            this.cbEnableChannelIndex.Location = new System.Drawing.Point(8, 142);
            this.cbEnableChannelIndex.Margin = new System.Windows.Forms.Padding(4);
            this.cbEnableChannelIndex.Name = "cbEnableChannelIndex";
            this.cbEnableChannelIndex.Size = new System.Drawing.Size(189, 19);
            this.cbEnableChannelIndex.TabIndex = 2;
            this.cbEnableChannelIndex.Text = "Enable Channel Index";
            this.cbEnableChannelIndex.UseVisualStyleBackColor = true;
            // 
            // cbEnableInventoryParameterSpecID
            // 
            this.cbEnableInventoryParameterSpecID.AutoSize = true;
            this.cbEnableInventoryParameterSpecID.Location = new System.Drawing.Point(8, 82);
            this.cbEnableInventoryParameterSpecID.Margin = new System.Windows.Forms.Padding(4);
            this.cbEnableInventoryParameterSpecID.Name = "cbEnableInventoryParameterSpecID";
            this.cbEnableInventoryParameterSpecID.Size = new System.Drawing.Size(301, 19);
            this.cbEnableInventoryParameterSpecID.TabIndex = 4;
            this.cbEnableInventoryParameterSpecID.Text = "Enable Inventory Parameter Spec ID";
            this.cbEnableInventoryParameterSpecID.UseVisualStyleBackColor = true;
            // 
            // cbEnableAntennaID
            // 
            this.cbEnableAntennaID.AutoSize = true;
            this.cbEnableAntennaID.Location = new System.Drawing.Point(8, 112);
            this.cbEnableAntennaID.Margin = new System.Windows.Forms.Padding(4);
            this.cbEnableAntennaID.Name = "cbEnableAntennaID";
            this.cbEnableAntennaID.Size = new System.Drawing.Size(165, 19);
            this.cbEnableAntennaID.TabIndex = 1;
            this.cbEnableAntennaID.Text = "Enable Antenna ID";
            this.cbEnableAntennaID.UseVisualStyleBackColor = true;
            // 
            // cbEnableFirstSeenTimestamp
            // 
            this.cbEnableFirstSeenTimestamp.AutoSize = true;
            this.cbEnableFirstSeenTimestamp.Location = new System.Drawing.Point(8, 200);
            this.cbEnableFirstSeenTimestamp.Margin = new System.Windows.Forms.Padding(4);
            this.cbEnableFirstSeenTimestamp.Name = "cbEnableFirstSeenTimestamp";
            this.cbEnableFirstSeenTimestamp.Size = new System.Drawing.Size(237, 19);
            this.cbEnableFirstSeenTimestamp.TabIndex = 3;
            this.cbEnableFirstSeenTimestamp.Text = "Enable FirstSeen Timestamp";
            this.cbEnableFirstSeenTimestamp.UseVisualStyleBackColor = true;
            // 
            // nudN
            // 
            this.nudN.Location = new System.Drawing.Point(33, 66);
            this.nudN.Margin = new System.Windows.Forms.Padding(4);
            this.nudN.Name = "nudN";
            this.nudN.Size = new System.Drawing.Size(48, 25);
            this.nudN.TabIndex = 10;
            this.nudN.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // lblN
            // 
            this.lblN.AutoSize = true;
            this.lblN.Location = new System.Drawing.Point(11, 69);
            this.lblN.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblN.Name = "lblN";
            this.lblN.Size = new System.Drawing.Size(15, 15);
            this.lblN.TabIndex = 9;
            this.lblN.Text = "N";
            // 
            // cbROReportTrigger
            // 
            this.cbROReportTrigger.FormattingEnabled = true;
            this.cbROReportTrigger.Location = new System.Drawing.Point(21, 34);
            this.cbROReportTrigger.Margin = new System.Windows.Forms.Padding(4);
            this.cbROReportTrigger.Name = "cbROReportTrigger";
            this.cbROReportTrigger.Size = new System.Drawing.Size(297, 23);
            this.cbROReportTrigger.TabIndex = 8;
            // 
            // lblROReportTrigger
            // 
            this.lblROReportTrigger.AutoSize = true;
            this.lblROReportTrigger.Location = new System.Drawing.Point(11, 15);
            this.lblROReportTrigger.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblROReportTrigger.Name = "lblROReportTrigger";
            this.lblROReportTrigger.Size = new System.Drawing.Size(127, 15);
            this.lblROReportTrigger.TabIndex = 7;
            this.lblROReportTrigger.Text = "ROReportTrigger";
            // 
            // ReaderSettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(379, 875);
            this.Controls.Add(this.tcReaderSettings);
            this.DockAreas = ((WeifenLuo.WinFormsUI.Docking.DockAreas)(((WeifenLuo.WinFormsUI.Docking.DockAreas.Float | WeifenLuo.WinFormsUI.Docking.DockAreas.DockLeft) 
            | WeifenLuo.WinFormsUI.Docking.DockAreas.DockRight)));
            this.Font = new System.Drawing.Font("SimSun", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.HideOnClose = true;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "ReaderSettingsForm";
            this.ShowIcon = false;
            this.Text = "Reader Settings";
            this.DockStateChanged += new System.EventHandler(this.ReaderSettingsFrom_DockStateChanged);
            this.Load += new System.EventHandler(this.ReaderSettingsFrom_Load);
            this.tcReaderSettings.ResumeLayout(false);
            this.tpBasic.ResumeLayout(false);
            this.tpBasic.PerformLayout();
            this.gbTagFilter.ResumeLayout(false);
            this.gbTagFilter.PerformLayout();
            this.gbFrequencyInfo.ResumeLayout(false);
            this.gbFrequencyInfo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudHop)).EndInit();
            this.gbReadMode.ResumeLayout(false);
            this.gbReadMode.PerformLayout();
            this.gbAddress.ResumeLayout(false);
            this.gbAddress.PerformLayout();
            this.tpAntenna.ResumeLayout(false);
            this.tpAntenna.PerformLayout();
            this.tabControlAntenna.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.gbRFReceiver1.ResumeLayout(false);
            this.gbRFReceiver1.PerformLayout();
            this.gbRFTransmiter1.ResumeLayout(false);
            this.gbRFTransmiter1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.gbRFReceiver2.ResumeLayout(false);
            this.gbRFReceiver2.PerformLayout();
            this.gbRFTransmiter2.ResumeLayout(false);
            this.gbRFTransmiter2.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.gbRFReceiver3.ResumeLayout(false);
            this.gbRFReceiver3.PerformLayout();
            this.gbRFTransmiter3.ResumeLayout(false);
            this.gbRFTransmiter3.PerformLayout();
            this.tabPage4.ResumeLayout(false);
            this.gbRFReceiver4.ResumeLayout(false);
            this.gbRFReceiver4.PerformLayout();
            this.gbRFTransmiter4.ResumeLayout(false);
            this.gbRFTransmiter4.PerformLayout();
            this.gbC1G2InventoryCommand.ResumeLayout(false);
            this.gbC1G2InventoryCommand.PerformLayout();
            this.gbImpinj.ResumeLayout(false);
            this.gbImpinj.PerformLayout();
            this.gbC1G2SingulationControl.ResumeLayout(false);
            this.gbC1G2SingulationControl.PerformLayout();
            this.gbC1G2RFControl.ResumeLayout(false);
            this.gbC1G2RFControl.PerformLayout();
            this.tpRoSpec.ResumeLayout(false);
            this.tpRoSpec.PerformLayout();
            this.gbImpinjTagReportContentSelector.ResumeLayout(false);
            this.gbImpinjTagReportContentSelector.PerformLayout();
            this.gbTagReportContentSelector.ResumeLayout(false);
            this.gbTagReportContentSelector.PerformLayout();
            this.gbC1G2EPCMemorySelector.ResumeLayout(false);
            this.gbC1G2EPCMemorySelector.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudN)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tcReaderSettings;
        private System.Windows.Forms.TabPage tpBasic;
        private System.Windows.Forms.TabPage tpAntenna;
        private System.Windows.Forms.TabPage tpRoSpec;
        private System.Windows.Forms.CheckBox cbResetToFactoryDefault;
        private System.Windows.Forms.GroupBox gbTagFilter;
        private System.Windows.Forms.ComboBox cbExtraMask;
        private System.Windows.Forms.ComboBox cbMask;
        private System.Windows.Forms.Label lblExtraMask;
        private System.Windows.Forms.Label lblMask;
        private System.Windows.Forms.GroupBox gbFrequencyInfo;
        private System.Windows.Forms.NumericUpDown nudHop;
        private System.Windows.Forms.CheckedListBox clbFreqSet;
        private System.Windows.Forms.Label lblHop;
        private System.Windows.Forms.Label lblFreqSet;
        private System.Windows.Forms.ComboBox cbFreqMode;
        private System.Windows.Forms.Label lblFreqMode;
        private System.Windows.Forms.GroupBox gbReadMode;
        private System.Windows.Forms.Label lblMs;
        private System.Windows.Forms.TextBox tbxDuration;
        private System.Windows.Forms.Label lblDuration;
        private System.Windows.Forms.RadioButton rbtnTimerReadMode;
        private System.Windows.Forms.RadioButton rbtnManualReadMode;
        private System.Windows.Forms.GroupBox gbAddress;
        private System.Windows.Forms.Button btnSearchIP;
        private System.Windows.Forms.Label lblMAC3;
        private System.Windows.Forms.TextBox tbxMAC3;
        private System.Windows.Forms.Label lblMAC2;
        private System.Windows.Forms.Label lblMAC4;
        private System.Windows.Forms.TextBox tbxMAC2;
        private System.Windows.Forms.TextBox tbxMAC1;
        private System.Windows.Forms.Label lblMAC1;
        private System.Windows.Forms.RadioButton rbtnHostname;
        private System.Windows.Forms.RadioButton rbtnIP;
        private System.Windows.Forms.TextBox tbxIP;
        private System.Windows.Forms.TabControl tabControlAntenna;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.GroupBox gbRFReceiver1;
        private System.Windows.Forms.Label lblReceiverSensitivity1;
        private System.Windows.Forms.ComboBox cbReceiverSensitivity1;
        private System.Windows.Forms.GroupBox gbRFTransmiter1;
        private System.Windows.Forms.ComboBox cbTransmiterPower1;
        private System.Windows.Forms.Label lblTransmiterPower1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.GroupBox gbRFReceiver2;
        private System.Windows.Forms.Label lblReceiverSensitivity2;
        private System.Windows.Forms.ComboBox cbReceiverSensitivity2;
        private System.Windows.Forms.GroupBox gbRFTransmiter2;
        private System.Windows.Forms.ComboBox cbTransmiterPower2;
        private System.Windows.Forms.Label lblTransmiterPower2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.GroupBox gbRFReceiver3;
        private System.Windows.Forms.Label lblReceiverSensitivity3;
        private System.Windows.Forms.ComboBox cbReceiverSensitivity3;
        private System.Windows.Forms.GroupBox gbRFTransmiter3;
        private System.Windows.Forms.ComboBox cbTransmiterPower3;
        private System.Windows.Forms.Label lblTransmiterPower3;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.GroupBox gbRFReceiver4;
        private System.Windows.Forms.Label lblReceiverSensitivity4;
        private System.Windows.Forms.ComboBox cbReceiverSensitivity4;
        private System.Windows.Forms.GroupBox gbRFTransmiter4;
        private System.Windows.Forms.ComboBox cbTransmiterPower4;
        private System.Windows.Forms.Label lblTransmiterPower4;
        private System.Windows.Forms.CheckBox cbAntenna4;
        private System.Windows.Forms.GroupBox gbC1G2InventoryCommand;
        private System.Windows.Forms.GroupBox gbImpinj;
        private System.Windows.Forms.Label lblScope2;
        private System.Windows.Forms.Label lblScope1;
        private System.Windows.Forms.CheckBox cbImpinjLowDutyCycleMode;
        private System.Windows.Forms.Label lblEmptyFieldTimeout;
        private System.Windows.Forms.TextBox tbxEmptyFieldTimeout;
        private System.Windows.Forms.TextBox tbxFieldPingInterval;
        private System.Windows.Forms.Label lblFieldPingInterval;
        private System.Windows.Forms.TextBox tbxReducedChannelList;
        private System.Windows.Forms.Label lblReducedChannelList;
        private System.Windows.Forms.CheckBox cbImpinjReducedPowerFrequencyMode;
        private System.Windows.Forms.ComboBox cbImpiJSearchMode;
        private System.Windows.Forms.Label lblImpinjInventorySearchMode;
        private System.Windows.Forms.GroupBox gbC1G2SingulationControl;
        private System.Windows.Forms.Label lblScope3;
        private System.Windows.Forms.TextBox tbxTagTransitTime;
        private System.Windows.Forms.Label lblTagTransmiteTime;
        private System.Windows.Forms.TextBox tbxTagPopulation;
        private System.Windows.Forms.Label lblTagPopulation;
        private System.Windows.Forms.ComboBox cbSession;
        private System.Windows.Forms.Label lblSession;
        private System.Windows.Forms.GroupBox gbC1G2RFControl;
        private System.Windows.Forms.TextBox tbxTari;
        private System.Windows.Forms.Label lblTari;
        private System.Windows.Forms.ComboBox cbModeIndex;
        private System.Windows.Forms.Label lblModeIndex;
        private System.Windows.Forms.Label lblTagInventoryStateAware;
        private System.Windows.Forms.ComboBox cbTagInventoryStateAware;
        private System.Windows.Forms.CheckBox cbAntenna3;
        private System.Windows.Forms.CheckBox cbAntenna2;
        private System.Windows.Forms.CheckBox cbAntenna1;
        private System.Windows.Forms.Label lblAntennaID;
        private System.Windows.Forms.GroupBox gbImpinjTagReportContentSelector;
        private System.Windows.Forms.CheckBox cbImpinjEnableSerializedTID;
        private System.Windows.Forms.CheckBox cbImpinjEnableRFPhaseAngle;
        private System.Windows.Forms.CheckBox cbImpinjEnableRFDopplerFrequency;
        private System.Windows.Forms.CheckBox cbImpinjEnablePeakRSSI;
        private System.Windows.Forms.CheckBox cbImpinjEnableOptimizedRead;
        private System.Windows.Forms.CheckBox cbImpinjEnableGPSCoordinates;
        private System.Windows.Forms.GroupBox gbTagReportContentSelector;
        private System.Windows.Forms.GroupBox gbC1G2EPCMemorySelector;
        private System.Windows.Forms.CheckBox cbEnablePCBits;
        private System.Windows.Forms.CheckBox cbEnableCRC;
        private System.Windows.Forms.CheckBox cbEnableTagSeenCount;
        private System.Windows.Forms.CheckBox cbEnableSpecIndex;
        private System.Windows.Forms.CheckBox cbEnableROSpecID;
        private System.Windows.Forms.CheckBox cbEnablePeakRSSI;
        private System.Windows.Forms.CheckBox cbEnableLastSeenTimestamp;
        private System.Windows.Forms.CheckBox cbEnableAccessSpecID;
        private System.Windows.Forms.CheckBox cbEnableChannelIndex;
        private System.Windows.Forms.CheckBox cbEnableInventoryParameterSpecID;
        private System.Windows.Forms.CheckBox cbEnableAntennaID;
        private System.Windows.Forms.CheckBox cbEnableFirstSeenTimestamp;
        private System.Windows.Forms.NumericUpDown nudN;
        private System.Windows.Forms.Label lblN;
        private System.Windows.Forms.ComboBox cbROReportTrigger;
        private System.Windows.Forms.Label lblROReportTrigger;
    }
}