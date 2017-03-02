using System;

namespace BasicApplication
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea3 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea4 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle14 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle13 = new System.Windows.Forms.DataGridViewCellStyle();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tssbtnSave = new System.Windows.Forms.ToolStripSplitButton();
            this.SaveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.SaveAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbtnConnect = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbtnStart = new System.Windows.Forms.ToolStripButton();
            this.tsbtnStop = new System.Windows.Forms.ToolStripButton();
            this.tsbtnClear = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbtnMoreSettings = new System.Windows.Forms.ToolStripButton();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.tsslRunTime = new System.Windows.Forms.ToolStripStatusLabel();
            this.tsslblCounter = new System.Windows.Forms.ToolStripStatusLabel();
            this.tsslblStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.lvBasicInfo = new System.Windows.Forms.ListView();
            this.colHeaderIndex = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colHeaderEPC = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colHeaderAntenna = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colHeaderChannel = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colHeaderRSSI = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colHeaderPhase = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colHeaderDoppler = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colHeaderVelocity = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colHeaderCount = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tlpAll = new System.Windows.Forms.TableLayoutPanel();
            this.tlpResultDisplay = new System.Windows.Forms.TableLayoutPanel();
            this.tabControlChart = new System.Windows.Forms.TabControl();
            this.tpRSSI = new System.Windows.Forms.TabPage();
            this.chartRSSI = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.tabPhase = new System.Windows.Forms.TabPage();
            this.chartPhase = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.scHolographics = new System.Windows.Forms.SplitContainer();
            this.gbHoloSettings = new System.Windows.Forms.GroupBox();
            this.gbHologram = new System.Windows.Forms.GroupBox();
            this.cbDisplayHologram = new System.Windows.Forms.CheckBox();
            this.nudTagIndexForHologram = new System.Windows.Forms.NumericUpDown();
            this.lblTagIndexForHologram = new System.Windows.Forms.Label();
            this.lblRefreshTime = new System.Windows.Forms.Label();
            this.tbxRefreshInterval = new System.Windows.Forms.TextBox();
            this.btnHolographicsConfirm = new System.Windows.Forms.Button();
            this.cbAlgorithms = new System.Windows.Forms.ComboBox();
            this.lblAlgorithms = new System.Windows.Forms.Label();
            this.tcHolographics = new System.Windows.Forms.TabControl();
            this.tpOnline = new System.Windows.Forms.TabPage();
            this.tpOffline = new System.Windows.Forms.TabPage();
            this.tpSimulation = new System.Windows.Forms.TabPage();
            this.btnSimulationStop = new System.Windows.Forms.Button();
            this.btnSimulationStart = new System.Windows.Forms.Button();
            this.gbSimulationTagPosition = new System.Windows.Forms.GroupBox();
            this.dgvSimulationTagPosition = new System.Windows.Forms.DataGridView();
            this.colSimulationEPC = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSimulationTagX = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSimulationTagY = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSimulationTagZ = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gbSimulationFrequncy = new System.Windows.Forms.GroupBox();
            this.tbxSimulationHoppingNumber = new System.Windows.Forms.TextBox();
            this.lblSimulationHoppingFrequencyNumber = new System.Windows.Forms.Label();
            this.tbxSimulationInitialFrequency = new System.Windows.Forms.TextBox();
            this.lblSimulationInitialFrequency = new System.Windows.Forms.Label();
            this.gbSearchRegion = new System.Windows.Forms.GroupBox();
            this.tbxSRZStart = new System.Windows.Forms.TextBox();
            this.tbxSRYEnd = new System.Windows.Forms.TextBox();
            this.tbxSRXEnd = new System.Windows.Forms.TextBox();
            this.tbxSRZInterval = new System.Windows.Forms.TextBox();
            this.tbxSRYInterval = new System.Windows.Forms.TextBox();
            this.tbxSRXInterval = new System.Windows.Forms.TextBox();
            this.lblSREndPoint = new System.Windows.Forms.Label();
            this.lblSRZ = new System.Windows.Forms.Label();
            this.lblSRInterval = new System.Windows.Forms.Label();
            this.labelSRStartPoint = new System.Windows.Forms.Label();
            this.tbxSRYStart = new System.Windows.Forms.TextBox();
            this.tbxSRZEnd = new System.Windows.Forms.TextBox();
            this.lblSRY = new System.Windows.Forms.Label();
            this.lblSRX = new System.Windows.Forms.Label();
            this.tbxSRXStart = new System.Windows.Forms.TextBox();
            this.gbAntennaTrack = new System.Windows.Forms.GroupBox();
            this.tbxSimulationSamplingTime = new System.Windows.Forms.TextBox();
            this.lblSamplingInterval = new System.Windows.Forms.Label();
            this.tbxSamplingAntennaSpeed = new System.Windows.Forms.TextBox();
            this.lblAntennaSpeed = new System.Windows.Forms.Label();
            this.tbxAntZStart = new System.Windows.Forms.TextBox();
            this.lblAntennaZ = new System.Windows.Forms.Label();
            this.tbxAntXStart = new System.Windows.Forms.TextBox();
            this.tbxAntYStart = new System.Windows.Forms.TextBox();
            this.lblAntennaX = new System.Windows.Forms.Label();
            this.lblAntStartPoint = new System.Windows.Forms.Label();
            this.lblAntennaY = new System.Windows.Forms.Label();
            this.tlpHeatMap = new System.Windows.Forms.TableLayoutPanel();
            this.pbHeatMap = new System.Windows.Forms.PictureBox();
            this.lblLocalizationResult = new System.Windows.Forms.Label();
            this.tbxLocalizationResult = new System.Windows.Forms.TextBox();
            this.gbBasicSettings = new System.Windows.Forms.GroupBox();
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
            this.toolStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.tlpAll.SuspendLayout();
            this.tlpResultDisplay.SuspendLayout();
            this.tabControlChart.SuspendLayout();
            this.tpRSSI.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartRSSI)).BeginInit();
            this.tabPhase.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartPhase)).BeginInit();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.scHolographics)).BeginInit();
            this.scHolographics.Panel1.SuspendLayout();
            this.scHolographics.Panel2.SuspendLayout();
            this.scHolographics.SuspendLayout();
            this.gbHoloSettings.SuspendLayout();
            this.gbHologram.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudTagIndexForHologram)).BeginInit();
            this.tcHolographics.SuspendLayout();
            this.tpSimulation.SuspendLayout();
            this.gbSimulationTagPosition.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSimulationTagPosition)).BeginInit();
            this.gbSimulationFrequncy.SuspendLayout();
            this.gbSearchRegion.SuspendLayout();
            this.gbAntennaTrack.SuspendLayout();
            this.tlpHeatMap.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbHeatMap)).BeginInit();
            this.gbBasicSettings.SuspendLayout();
            this.gbTagFilter.SuspendLayout();
            this.gbFrequencyInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudHop)).BeginInit();
            this.gbReadMode.SuspendLayout();
            this.gbAddress.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tssbtnSave,
            this.toolStripSeparator5,
            this.tsbtnConnect,
            this.toolStripSeparator4,
            this.tsbtnStart,
            this.tsbtnStop,
            this.tsbtnClear,
            this.toolStripSeparator2,
            this.tsbtnMoreSettings});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1276, 25);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // tssbtnSave
            // 
            this.tssbtnSave.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.SaveToolStripMenuItem,
            this.SaveAsToolStripMenuItem});
            this.tssbtnSave.Image = ((System.Drawing.Image)(resources.GetObject("tssbtnSave.Image")));
            this.tssbtnSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tssbtnSave.Name = "tssbtnSave";
            this.tssbtnSave.Size = new System.Drawing.Size(67, 22);
            this.tssbtnSave.Text = "Save";
            this.tssbtnSave.ButtonClick += new System.EventHandler(this.tssbtnSave_ButtonClick);
            // 
            // SaveToolStripMenuItem
            // 
            this.SaveToolStripMenuItem.Name = "SaveToolStripMenuItem";
            this.SaveToolStripMenuItem.Size = new System.Drawing.Size(120, 22);
            this.SaveToolStripMenuItem.Text = "Save";
            this.SaveToolStripMenuItem.Click += new System.EventHandler(this.SaveToolStripMenuItem_Click);
            // 
            // SaveAsToolStripMenuItem
            // 
            this.SaveAsToolStripMenuItem.Name = "SaveAsToolStripMenuItem";
            this.SaveAsToolStripMenuItem.Size = new System.Drawing.Size(120, 22);
            this.SaveAsToolStripMenuItem.Text = "Save as";
            this.SaveAsToolStripMenuItem.Click += new System.EventHandler(this.SaveAsToolStripMenuItem_Click);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(6, 25);
            // 
            // tsbtnConnect
            // 
            this.tsbtnConnect.Image = ((System.Drawing.Image)(resources.GetObject("tsbtnConnect.Image")));
            this.tsbtnConnect.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnConnect.Name = "tsbtnConnect";
            this.tsbtnConnect.Size = new System.Drawing.Size(75, 22);
            this.tsbtnConnect.Text = "Connect";
            this.tsbtnConnect.Click += new System.EventHandler(this.tsbtnConnect_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 25);
            // 
            // tsbtnStart
            // 
            this.tsbtnStart.Image = ((System.Drawing.Image)(resources.GetObject("tsbtnStart.Image")));
            this.tsbtnStart.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnStart.Name = "tsbtnStart";
            this.tsbtnStart.Size = new System.Drawing.Size(55, 22);
            this.tsbtnStart.Text = "Start";
            this.tsbtnStart.Click += new System.EventHandler(this.tsbtnStart_Click);
            // 
            // tsbtnStop
            // 
            this.tsbtnStop.Image = ((System.Drawing.Image)(resources.GetObject("tsbtnStop.Image")));
            this.tsbtnStop.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnStop.Name = "tsbtnStop";
            this.tsbtnStop.Size = new System.Drawing.Size(55, 22);
            this.tsbtnStop.Text = "Stop";
            this.tsbtnStop.Click += new System.EventHandler(this.tsbtnStop_Click);
            // 
            // tsbtnClear
            // 
            this.tsbtnClear.Image = ((System.Drawing.Image)(resources.GetObject("tsbtnClear.Image")));
            this.tsbtnClear.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnClear.Name = "tsbtnClear";
            this.tsbtnClear.Size = new System.Drawing.Size(58, 22);
            this.tsbtnClear.Text = "Clear";
            this.tsbtnClear.Click += new System.EventHandler(this.tsbtnClear_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // tsbtnMoreSettings
            // 
            this.tsbtnMoreSettings.Image = ((System.Drawing.Image)(resources.GetObject("tsbtnMoreSettings.Image")));
            this.tsbtnMoreSettings.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnMoreSettings.Name = "tsbtnMoreSettings";
            this.tsbtnMoreSettings.Size = new System.Drawing.Size(110, 22);
            this.tsbtnMoreSettings.Text = "More Settings";
            this.tsbtnMoreSettings.Click += new System.EventHandler(this.tsbtnMoreSettings_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsslRunTime,
            this.tsslblCounter,
            this.tsslblStatus});
            this.statusStrip1.Location = new System.Drawing.Point(0, 901);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.statusStrip1.Size = new System.Drawing.Size(1276, 26);
            this.statusStrip1.TabIndex = 11;
            this.statusStrip1.Text = "status";
            // 
            // tsslRunTime
            // 
            this.tsslRunTime.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.tsslRunTime.BorderStyle = System.Windows.Forms.Border3DStyle.Etched;
            this.tsslRunTime.Image = ((System.Drawing.Image)(resources.GetObject("tsslRunTime.Image")));
            this.tsslRunTime.Name = "tsslRunTime";
            this.tsslRunTime.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.tsslRunTime.Size = new System.Drawing.Size(82, 21);
            this.tsslRunTime.Text = "Run Time";
            // 
            // tsslblCounter
            // 
            this.tsslblCounter.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.tsslblCounter.BorderStyle = System.Windows.Forms.Border3DStyle.Etched;
            this.tsslblCounter.Image = ((System.Drawing.Image)(resources.GetObject("tsslblCounter.Image")));
            this.tsslblCounter.Name = "tsslblCounter";
            this.tsslblCounter.Size = new System.Drawing.Size(74, 21);
            this.tsslblCounter.Text = "Counter";
            this.tsslblCounter.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            // 
            // tsslblStatus
            // 
            this.tsslblStatus.Image = ((System.Drawing.Image)(resources.GetObject("tsslblStatus.Image")));
            this.tsslblStatus.Name = "tsslblStatus";
            this.tsslblStatus.Size = new System.Drawing.Size(60, 21);
            this.tsslblStatus.Text = "Ready";
            this.tsslblStatus.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            // 
            // lvBasicInfo
            // 
            this.lvBasicInfo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.lvBasicInfo.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colHeaderIndex,
            this.colHeaderEPC,
            this.colHeaderAntenna,
            this.colHeaderChannel,
            this.colHeaderRSSI,
            this.colHeaderPhase,
            this.colHeaderDoppler,
            this.colHeaderVelocity,
            this.colHeaderCount});
            this.lvBasicInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvBasicInfo.ForeColor = System.Drawing.SystemColors.WindowText;
            this.lvBasicInfo.GridLines = true;
            this.lvBasicInfo.Location = new System.Drawing.Point(3, 3);
            this.lvBasicInfo.Name = "lvBasicInfo";
            this.lvBasicInfo.Size = new System.Drawing.Size(985, 155);
            this.lvBasicInfo.TabIndex = 9;
            this.lvBasicInfo.UseCompatibleStateImageBehavior = false;
            this.lvBasicInfo.View = System.Windows.Forms.View.Details;
            // 
            // colHeaderIndex
            // 
            this.colHeaderIndex.Text = "Index";
            this.colHeaderIndex.Width = 45;
            // 
            // colHeaderEPC
            // 
            this.colHeaderEPC.Text = "EPC";
            this.colHeaderEPC.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.colHeaderEPC.Width = 160;
            // 
            // colHeaderAntenna
            // 
            this.colHeaderAntenna.Text = "Antenna";
            this.colHeaderAntenna.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // colHeaderChannel
            // 
            this.colHeaderChannel.Text = "Channel";
            this.colHeaderChannel.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // colHeaderRSSI
            // 
            this.colHeaderRSSI.Text = "RSSI (dBm)";
            this.colHeaderRSSI.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.colHeaderRSSI.Width = 96;
            // 
            // colHeaderPhase
            // 
            this.colHeaderPhase.Text = "Phase (rad)";
            this.colHeaderPhase.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.colHeaderPhase.Width = 94;
            // 
            // colHeaderDoppler
            // 
            this.colHeaderDoppler.Text = "Doppler Shift";
            this.colHeaderDoppler.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.colHeaderDoppler.Width = 95;
            // 
            // colHeaderVelocity
            // 
            this.colHeaderVelocity.Text = "Velcity";
            this.colHeaderVelocity.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.colHeaderVelocity.Width = 91;
            // 
            // colHeaderCount
            // 
            this.colHeaderCount.Text = "Tag Count";
            this.colHeaderCount.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.colHeaderCount.Width = 69;
            // 
            // tlpAll
            // 
            this.tlpAll.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.InsetDouble;
            this.tlpAll.ColumnCount = 2;
            this.tlpAll.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 270F));
            this.tlpAll.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpAll.Controls.Add(this.tlpResultDisplay, 1, 0);
            this.tlpAll.Controls.Add(this.gbBasicSettings, 0, 0);
            this.tlpAll.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpAll.ForeColor = System.Drawing.SystemColors.ControlText;
            this.tlpAll.Location = new System.Drawing.Point(0, 25);
            this.tlpAll.Name = "tlpAll";
            this.tlpAll.RowCount = 1;
            this.tlpAll.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpAll.Size = new System.Drawing.Size(1276, 876);
            this.tlpAll.TabIndex = 15;
            // 
            // tlpResultDisplay
            // 
            this.tlpResultDisplay.ColumnCount = 1;
            this.tlpResultDisplay.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpResultDisplay.Controls.Add(this.lvBasicInfo, 0, 0);
            this.tlpResultDisplay.Controls.Add(this.tabControlChart, 0, 1);
            this.tlpResultDisplay.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpResultDisplay.Location = new System.Drawing.Point(279, 6);
            this.tlpResultDisplay.Name = "tlpResultDisplay";
            this.tlpResultDisplay.RowCount = 2;
            this.tlpResultDisplay.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 18.67853F));
            this.tlpResultDisplay.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 81.32147F));
            this.tlpResultDisplay.Size = new System.Drawing.Size(991, 864);
            this.tlpResultDisplay.TabIndex = 2;
            // 
            // tabControlChart
            // 
            this.tabControlChart.Controls.Add(this.tpRSSI);
            this.tabControlChart.Controls.Add(this.tabPhase);
            this.tabControlChart.Controls.Add(this.tabPage2);
            this.tabControlChart.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlChart.Location = new System.Drawing.Point(3, 164);
            this.tabControlChart.Name = "tabControlChart";
            this.tabControlChart.SelectedIndex = 0;
            this.tabControlChart.Size = new System.Drawing.Size(985, 697);
            this.tabControlChart.TabIndex = 10;
            // 
            // tpRSSI
            // 
            this.tpRSSI.Controls.Add(this.chartRSSI);
            this.tpRSSI.Location = new System.Drawing.Point(4, 22);
            this.tpRSSI.Name = "tpRSSI";
            this.tpRSSI.Padding = new System.Windows.Forms.Padding(3);
            this.tpRSSI.Size = new System.Drawing.Size(977, 671);
            this.tpRSSI.TabIndex = 0;
            this.tpRSSI.Text = "RSSI";
            this.tpRSSI.ToolTipText = "RSSI";
            this.tpRSSI.UseVisualStyleBackColor = true;
            // 
            // chartRSSI
            // 
            this.chartRSSI.BorderlineColor = System.Drawing.Color.DodgerBlue;
            chartArea3.AxisX.IntervalAutoMode = System.Windows.Forms.DataVisualization.Charting.IntervalAutoMode.VariableCount;
            chartArea3.AxisX.IsLabelAutoFit = false;
            chartArea3.AxisX.LabelStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            chartArea3.AxisX.LabelStyle.Interval = 0D;
            chartArea3.AxisX.LineWidth = 2;
            chartArea3.AxisX.MajorGrid.LineColor = System.Drawing.Color.Gainsboro;
            chartArea3.AxisX.MajorGrid.LineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Dash;
            chartArea3.AxisX.MajorTickMark.Interval = 0D;
            chartArea3.AxisX.MajorTickMark.IntervalOffset = 0D;
            chartArea3.AxisX.MajorTickMark.IntervalOffsetType = System.Windows.Forms.DataVisualization.Charting.DateTimeIntervalType.Milliseconds;
            chartArea3.AxisX.MajorTickMark.IntervalType = System.Windows.Forms.DataVisualization.Charting.DateTimeIntervalType.Milliseconds;
            chartArea3.AxisX.Minimum = 0D;
            chartArea3.AxisX.MinorGrid.LineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Dash;
            chartArea3.AxisX.ScaleView.MinSizeType = System.Windows.Forms.DataVisualization.Charting.DateTimeIntervalType.Milliseconds;
            chartArea3.AxisX.Title = "Time (ms)";
            chartArea3.AxisX.TitleFont = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            chartArea3.AxisY.IntervalAutoMode = System.Windows.Forms.DataVisualization.Charting.IntervalAutoMode.VariableCount;
            chartArea3.AxisY.IsLabelAutoFit = false;
            chartArea3.AxisY.LabelStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            chartArea3.AxisY.LineWidth = 2;
            chartArea3.AxisY.MajorGrid.LineColor = System.Drawing.Color.Gainsboro;
            chartArea3.AxisY.MajorGrid.LineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Dash;
            chartArea3.AxisY.MajorTickMark.Interval = 0D;
            chartArea3.AxisY.Title = "RSSI Value (dBm)";
            chartArea3.AxisY.TitleFont = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            chartArea3.BackColor = System.Drawing.Color.White;
            chartArea3.CursorX.IsUserEnabled = true;
            chartArea3.CursorX.IsUserSelectionEnabled = true;
            chartArea3.CursorX.SelectionColor = System.Drawing.Color.DeepSkyBlue;
            chartArea3.CursorY.IsUserEnabled = true;
            chartArea3.CursorY.IsUserSelectionEnabled = true;
            chartArea3.CursorY.SelectionColor = System.Drawing.Color.DeepSkyBlue;
            chartArea3.Name = "RSSI";
            chartArea3.Position.Auto = false;
            chartArea3.Position.Height = 70F;
            chartArea3.Position.Width = 95F;
            chartArea3.Position.X = 1F;
            chartArea3.Position.Y = 10F;
            this.chartRSSI.ChartAreas.Add(chartArea3);
            this.chartRSSI.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chartRSSI.Location = new System.Drawing.Point(3, 3);
            this.chartRSSI.Name = "chartRSSI";
            this.chartRSSI.Size = new System.Drawing.Size(971, 665);
            this.chartRSSI.TabIndex = 0;
            this.chartRSSI.Text = "RSSI";
            // 
            // tabPhase
            // 
            this.tabPhase.Controls.Add(this.chartPhase);
            this.tabPhase.Location = new System.Drawing.Point(4, 22);
            this.tabPhase.Name = "tabPhase";
            this.tabPhase.Size = new System.Drawing.Size(977, 671);
            this.tabPhase.TabIndex = 2;
            this.tabPhase.Text = "Phase";
            this.tabPhase.ToolTipText = "Phase";
            this.tabPhase.UseVisualStyleBackColor = true;
            // 
            // chartPhase
            // 
            this.chartPhase.BorderlineColor = System.Drawing.Color.DodgerBlue;
            chartArea4.AxisX.IntervalAutoMode = System.Windows.Forms.DataVisualization.Charting.IntervalAutoMode.VariableCount;
            chartArea4.AxisX.IsLabelAutoFit = false;
            chartArea4.AxisX.LabelStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            chartArea4.AxisX.LabelStyle.Interval = 0D;
            chartArea4.AxisX.LineWidth = 2;
            chartArea4.AxisX.MajorGrid.LineColor = System.Drawing.Color.Gainsboro;
            chartArea4.AxisX.MajorGrid.LineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Dash;
            chartArea4.AxisX.MajorTickMark.Interval = 0D;
            chartArea4.AxisX.MajorTickMark.IntervalOffset = 0D;
            chartArea4.AxisX.MajorTickMark.IntervalOffsetType = System.Windows.Forms.DataVisualization.Charting.DateTimeIntervalType.Milliseconds;
            chartArea4.AxisX.MajorTickMark.IntervalType = System.Windows.Forms.DataVisualization.Charting.DateTimeIntervalType.Milliseconds;
            chartArea4.AxisX.Minimum = 0D;
            chartArea4.AxisX.MinorGrid.LineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Dash;
            chartArea4.AxisX.ScaleView.MinSizeType = System.Windows.Forms.DataVisualization.Charting.DateTimeIntervalType.Milliseconds;
            chartArea4.AxisX.Title = "Time (ms)";
            chartArea4.AxisX.TitleFont = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            chartArea4.AxisY.IntervalAutoMode = System.Windows.Forms.DataVisualization.Charting.IntervalAutoMode.VariableCount;
            chartArea4.AxisY.IsLabelAutoFit = false;
            chartArea4.AxisY.LabelStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            chartArea4.AxisY.LineWidth = 2;
            chartArea4.AxisY.MajorGrid.LineColor = System.Drawing.Color.Gainsboro;
            chartArea4.AxisY.MajorGrid.LineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Dash;
            chartArea4.AxisY.MajorTickMark.Interval = 0D;
            chartArea4.AxisY.Maximum = 6.5D;
            chartArea4.AxisY.Minimum = -0.5D;
            chartArea4.AxisY.Title = "Phase Value (rad)";
            chartArea4.AxisY.TitleFont = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            chartArea4.BackColor = System.Drawing.Color.White;
            chartArea4.CursorX.IsUserEnabled = true;
            chartArea4.CursorX.IsUserSelectionEnabled = true;
            chartArea4.CursorX.LineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.NotSet;
            chartArea4.CursorX.SelectionColor = System.Drawing.Color.DeepSkyBlue;
            chartArea4.CursorY.IsUserEnabled = true;
            chartArea4.CursorY.IsUserSelectionEnabled = true;
            chartArea4.CursorY.SelectionColor = System.Drawing.Color.DeepSkyBlue;
            chartArea4.Name = "Phase";
            chartArea4.Position.Auto = false;
            chartArea4.Position.Height = 70F;
            chartArea4.Position.Width = 95F;
            chartArea4.Position.X = 1F;
            chartArea4.Position.Y = 10F;
            this.chartPhase.ChartAreas.Add(chartArea4);
            this.chartPhase.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chartPhase.Location = new System.Drawing.Point(0, 0);
            this.chartPhase.Name = "chartPhase";
            this.chartPhase.Size = new System.Drawing.Size(977, 671);
            this.chartPhase.TabIndex = 1;
            this.chartPhase.Text = "Phase";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.scHolographics);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(977, 671);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Holographics";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // scHolographics
            // 
            this.scHolographics.Dock = System.Windows.Forms.DockStyle.Fill;
            this.scHolographics.Location = new System.Drawing.Point(3, 3);
            this.scHolographics.Name = "scHolographics";
            // 
            // scHolographics.Panel1
            // 
            this.scHolographics.Panel1.Controls.Add(this.gbHoloSettings);
            // 
            // scHolographics.Panel2
            // 
            this.scHolographics.Panel2.Controls.Add(this.tlpHeatMap);
            this.scHolographics.Size = new System.Drawing.Size(971, 665);
            this.scHolographics.SplitterDistance = 305;
            this.scHolographics.TabIndex = 0;
            // 
            // gbHoloSettings
            // 
            this.gbHoloSettings.Controls.Add(this.gbHologram);
            this.gbHoloSettings.Controls.Add(this.btnHolographicsConfirm);
            this.gbHoloSettings.Controls.Add(this.cbAlgorithms);
            this.gbHoloSettings.Controls.Add(this.lblAlgorithms);
            this.gbHoloSettings.Controls.Add(this.tcHolographics);
            this.gbHoloSettings.Controls.Add(this.gbSearchRegion);
            this.gbHoloSettings.Controls.Add(this.gbAntennaTrack);
            this.gbHoloSettings.Location = new System.Drawing.Point(3, 3);
            this.gbHoloSettings.Name = "gbHoloSettings";
            this.gbHoloSettings.Size = new System.Drawing.Size(296, 659);
            this.gbHoloSettings.TabIndex = 0;
            this.gbHoloSettings.TabStop = false;
            this.gbHoloSettings.Text = "Settings";
            // 
            // gbHologram
            // 
            this.gbHologram.Controls.Add(this.cbDisplayHologram);
            this.gbHologram.Controls.Add(this.nudTagIndexForHologram);
            this.gbHologram.Controls.Add(this.lblTagIndexForHologram);
            this.gbHologram.Controls.Add(this.lblRefreshTime);
            this.gbHologram.Controls.Add(this.tbxRefreshInterval);
            this.gbHologram.Location = new System.Drawing.Point(3, 38);
            this.gbHologram.Name = "gbHologram";
            this.gbHologram.Size = new System.Drawing.Size(281, 94);
            this.gbHologram.TabIndex = 8;
            this.gbHologram.TabStop = false;
            this.gbHologram.Text = "Hologram";
            // 
            // cbDisplayHologram
            // 
            this.cbDisplayHologram.AutoSize = true;
            this.cbDisplayHologram.Location = new System.Drawing.Point(8, 21);
            this.cbDisplayHologram.Name = "cbDisplayHologram";
            this.cbDisplayHologram.Size = new System.Drawing.Size(120, 16);
            this.cbDisplayHologram.TabIndex = 7;
            this.cbDisplayHologram.Text = "Display Hologram";
            this.cbDisplayHologram.UseVisualStyleBackColor = true;
            this.cbDisplayHologram.CheckedChanged += new System.EventHandler(this.cbDisplayHologram_CheckedChanged);
            // 
            // nudTagIndexForHologram
            // 
            this.nudTagIndexForHologram.Location = new System.Drawing.Point(179, 65);
            this.nudTagIndexForHologram.Name = "nudTagIndexForHologram";
            this.nudTagIndexForHologram.Size = new System.Drawing.Size(51, 21);
            this.nudTagIndexForHologram.TabIndex = 6;
            this.nudTagIndexForHologram.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lblTagIndexForHologram
            // 
            this.lblTagIndexForHologram.AutoSize = true;
            this.lblTagIndexForHologram.Location = new System.Drawing.Point(30, 69);
            this.lblTagIndexForHologram.Name = "lblTagIndexForHologram";
            this.lblTagIndexForHologram.Size = new System.Drawing.Size(137, 12);
            this.lblTagIndexForHologram.TabIndex = 5;
            this.lblTagIndexForHologram.Text = "Tag Index For Hologram";
            // 
            // lblRefreshTime
            // 
            this.lblRefreshTime.AutoSize = true;
            this.lblRefreshTime.Location = new System.Drawing.Point(28, 43);
            this.lblRefreshTime.Name = "lblRefreshTime";
            this.lblRefreshTime.Size = new System.Drawing.Size(125, 12);
            this.lblRefreshTime.TabIndex = 3;
            this.lblRefreshTime.Text = "Refresh Interval (s)";
            // 
            // tbxRefreshInterval
            // 
            this.tbxRefreshInterval.Location = new System.Drawing.Point(179, 40);
            this.tbxRefreshInterval.Name = "tbxRefreshInterval";
            this.tbxRefreshInterval.Size = new System.Drawing.Size(51, 21);
            this.tbxRefreshInterval.TabIndex = 4;
            this.tbxRefreshInterval.Text = "1";
            this.tbxRefreshInterval.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // btnHolographicsConfirm
            // 
            this.btnHolographicsConfirm.Location = new System.Drawing.Point(4, 363);
            this.btnHolographicsConfirm.Name = "btnHolographicsConfirm";
            this.btnHolographicsConfirm.Size = new System.Drawing.Size(283, 23);
            this.btnHolographicsConfirm.TabIndex = 7;
            this.btnHolographicsConfirm.Text = "Confirm";
            this.btnHolographicsConfirm.UseVisualStyleBackColor = true;
            this.btnHolographicsConfirm.Click += new System.EventHandler(this.btnHolographicsConfirm_Click);
            // 
            // cbAlgorithms
            // 
            this.cbAlgorithms.FormattingEnabled = true;
            this.cbAlgorithms.Location = new System.Drawing.Point(87, 15);
            this.cbAlgorithms.Name = "cbAlgorithms";
            this.cbAlgorithms.Size = new System.Drawing.Size(146, 20);
            this.cbAlgorithms.TabIndex = 6;
            this.cbAlgorithms.SelectedIndexChanged += new System.EventHandler(this.cbAlgorithms_SelectedIndexChanged);
            // 
            // lblAlgorithms
            // 
            this.lblAlgorithms.AutoSize = true;
            this.lblAlgorithms.Location = new System.Drawing.Point(9, 18);
            this.lblAlgorithms.Name = "lblAlgorithms";
            this.lblAlgorithms.Size = new System.Drawing.Size(65, 12);
            this.lblAlgorithms.TabIndex = 5;
            this.lblAlgorithms.Text = "Algorithms";
            // 
            // tcHolographics
            // 
            this.tcHolographics.Controls.Add(this.tpOnline);
            this.tcHolographics.Controls.Add(this.tpOffline);
            this.tcHolographics.Controls.Add(this.tpSimulation);
            this.tcHolographics.Location = new System.Drawing.Point(3, 392);
            this.tcHolographics.Name = "tcHolographics";
            this.tcHolographics.SelectedIndex = 0;
            this.tcHolographics.Size = new System.Drawing.Size(288, 262);
            this.tcHolographics.TabIndex = 2;
            // 
            // tpOnline
            // 
            this.tpOnline.Location = new System.Drawing.Point(4, 22);
            this.tpOnline.Name = "tpOnline";
            this.tpOnline.Padding = new System.Windows.Forms.Padding(3);
            this.tpOnline.Size = new System.Drawing.Size(280, 236);
            this.tpOnline.TabIndex = 0;
            this.tpOnline.Text = "Online";
            this.tpOnline.UseVisualStyleBackColor = true;
            // 
            // tpOffline
            // 
            this.tpOffline.Location = new System.Drawing.Point(4, 22);
            this.tpOffline.Name = "tpOffline";
            this.tpOffline.Padding = new System.Windows.Forms.Padding(3);
            this.tpOffline.Size = new System.Drawing.Size(280, 236);
            this.tpOffline.TabIndex = 1;
            this.tpOffline.Text = "Offline";
            this.tpOffline.UseVisualStyleBackColor = true;
            // 
            // tpSimulation
            // 
            this.tpSimulation.Controls.Add(this.btnSimulationStop);
            this.tpSimulation.Controls.Add(this.btnSimulationStart);
            this.tpSimulation.Controls.Add(this.gbSimulationTagPosition);
            this.tpSimulation.Controls.Add(this.gbSimulationFrequncy);
            this.tpSimulation.Location = new System.Drawing.Point(4, 22);
            this.tpSimulation.Name = "tpSimulation";
            this.tpSimulation.Padding = new System.Windows.Forms.Padding(3);
            this.tpSimulation.Size = new System.Drawing.Size(280, 236);
            this.tpSimulation.TabIndex = 2;
            this.tpSimulation.Text = "Simulation";
            this.tpSimulation.UseVisualStyleBackColor = true;
            // 
            // btnSimulationStop
            // 
            this.btnSimulationStop.Location = new System.Drawing.Point(164, 209);
            this.btnSimulationStop.Name = "btnSimulationStop";
            this.btnSimulationStop.Size = new System.Drawing.Size(91, 23);
            this.btnSimulationStop.TabIndex = 6;
            this.btnSimulationStop.Text = "Stop";
            this.btnSimulationStop.UseVisualStyleBackColor = true;
            this.btnSimulationStop.Click += new System.EventHandler(this.btnSimulationStop_Click);
            // 
            // btnSimulationStart
            // 
            this.btnSimulationStart.Location = new System.Drawing.Point(26, 209);
            this.btnSimulationStart.Name = "btnSimulationStart";
            this.btnSimulationStart.Size = new System.Drawing.Size(91, 23);
            this.btnSimulationStart.TabIndex = 5;
            this.btnSimulationStart.Text = "Start";
            this.btnSimulationStart.UseVisualStyleBackColor = true;
            this.btnSimulationStart.Click += new System.EventHandler(this.btnSimulationStart_Click);
            // 
            // gbSimulationTagPosition
            // 
            this.gbSimulationTagPosition.Controls.Add(this.dgvSimulationTagPosition);
            this.gbSimulationTagPosition.Location = new System.Drawing.Point(11, 6);
            this.gbSimulationTagPosition.Name = "gbSimulationTagPosition";
            this.gbSimulationTagPosition.Size = new System.Drawing.Size(266, 111);
            this.gbSimulationTagPosition.TabIndex = 3;
            this.gbSimulationTagPosition.TabStop = false;
            this.gbSimulationTagPosition.Text = "Tag Position";
            // 
            // dgvSimulationTagPosition
            // 
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dgvSimulationTagPosition.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle8;
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle9.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle9.Font = new System.Drawing.Font("SimSun", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle9.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvSimulationTagPosition.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle9;
            this.dgvSimulationTagPosition.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSimulationTagPosition.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colSimulationEPC,
            this.colSimulationTagX,
            this.colSimulationTagY,
            this.colSimulationTagZ});
            this.dgvSimulationTagPosition.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvSimulationTagPosition.Location = new System.Drawing.Point(3, 17);
            this.dgvSimulationTagPosition.Name = "dgvSimulationTagPosition";
            dataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle14.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle14.Font = new System.Drawing.Font("SimSun", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle14.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle14.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle14.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle14.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvSimulationTagPosition.RowHeadersDefaultCellStyle = dataGridViewCellStyle14;
            this.dgvSimulationTagPosition.RowTemplate.Height = 23;
            this.dgvSimulationTagPosition.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dgvSimulationTagPosition.Size = new System.Drawing.Size(260, 91);
            this.dgvSimulationTagPosition.TabIndex = 0;
            this.dgvSimulationTagPosition.RowStateChanged += new System.Windows.Forms.DataGridViewRowStateChangedEventHandler(this.dgvSimulationTagPosition_RowStateChanged);
            // 
            // colSimulationEPC
            // 
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.colSimulationEPC.DefaultCellStyle = dataGridViewCellStyle10;
            this.colSimulationEPC.HeaderText = "EPC";
            this.colSimulationEPC.Name = "colSimulationEPC";
            this.colSimulationEPC.Width = 40;
            // 
            // colSimulationTagX
            // 
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.colSimulationTagX.DefaultCellStyle = dataGridViewCellStyle11;
            this.colSimulationTagX.HeaderText = "X (m)";
            this.colSimulationTagX.Name = "colSimulationTagX";
            this.colSimulationTagX.Width = 59;
            // 
            // colSimulationTagY
            // 
            dataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.colSimulationTagY.DefaultCellStyle = dataGridViewCellStyle12;
            this.colSimulationTagY.HeaderText = "Y (m)";
            this.colSimulationTagY.Name = "colSimulationTagY";
            this.colSimulationTagY.Width = 59;
            // 
            // colSimulationTagZ
            // 
            dataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.colSimulationTagZ.DefaultCellStyle = dataGridViewCellStyle13;
            this.colSimulationTagZ.HeaderText = "Z (m)";
            this.colSimulationTagZ.Name = "colSimulationTagZ";
            this.colSimulationTagZ.Width = 59;
            // 
            // gbSimulationFrequncy
            // 
            this.gbSimulationFrequncy.Controls.Add(this.tbxSimulationHoppingNumber);
            this.gbSimulationFrequncy.Controls.Add(this.lblSimulationHoppingFrequencyNumber);
            this.gbSimulationFrequncy.Controls.Add(this.tbxSimulationInitialFrequency);
            this.gbSimulationFrequncy.Controls.Add(this.lblSimulationInitialFrequency);
            this.gbSimulationFrequncy.Location = new System.Drawing.Point(11, 123);
            this.gbSimulationFrequncy.Name = "gbSimulationFrequncy";
            this.gbSimulationFrequncy.Size = new System.Drawing.Size(266, 80);
            this.gbSimulationFrequncy.TabIndex = 2;
            this.gbSimulationFrequncy.TabStop = false;
            this.gbSimulationFrequncy.Text = "Frequency";
            // 
            // tbxSimulationHoppingNumber
            // 
            this.tbxSimulationHoppingNumber.Location = new System.Drawing.Point(168, 50);
            this.tbxSimulationHoppingNumber.Name = "tbxSimulationHoppingNumber";
            this.tbxSimulationHoppingNumber.Size = new System.Drawing.Size(71, 21);
            this.tbxSimulationHoppingNumber.TabIndex = 34;
            this.tbxSimulationHoppingNumber.Text = "1";
            this.tbxSimulationHoppingNumber.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lblSimulationHoppingFrequencyNumber
            // 
            this.lblSimulationHoppingFrequencyNumber.AutoSize = true;
            this.lblSimulationHoppingFrequencyNumber.Location = new System.Drawing.Point(13, 53);
            this.lblSimulationHoppingFrequencyNumber.Name = "lblSimulationHoppingFrequencyNumber";
            this.lblSimulationHoppingFrequencyNumber.Size = new System.Drawing.Size(149, 12);
            this.lblSimulationHoppingFrequencyNumber.TabIndex = 35;
            this.lblSimulationHoppingFrequencyNumber.Text = "Hopping Frequency Number";
            // 
            // tbxSimulationInitialFrequency
            // 
            this.tbxSimulationInitialFrequency.Location = new System.Drawing.Point(168, 20);
            this.tbxSimulationInitialFrequency.Name = "tbxSimulationInitialFrequency";
            this.tbxSimulationInitialFrequency.Size = new System.Drawing.Size(71, 21);
            this.tbxSimulationInitialFrequency.TabIndex = 32;
            this.tbxSimulationInitialFrequency.Text = "920.625";
            this.tbxSimulationInitialFrequency.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lblSimulationInitialFrequency
            // 
            this.lblSimulationInitialFrequency.AutoSize = true;
            this.lblSimulationInitialFrequency.Location = new System.Drawing.Point(13, 24);
            this.lblSimulationInitialFrequency.Name = "lblSimulationInitialFrequency";
            this.lblSimulationInitialFrequency.Size = new System.Drawing.Size(143, 12);
            this.lblSimulationInitialFrequency.TabIndex = 33;
            this.lblSimulationInitialFrequency.Text = "Initial Frequency (MHz)";
            // 
            // gbSearchRegion
            // 
            this.gbSearchRegion.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbSearchRegion.Controls.Add(this.tbxSRZStart);
            this.gbSearchRegion.Controls.Add(this.tbxSRYEnd);
            this.gbSearchRegion.Controls.Add(this.tbxSRXEnd);
            this.gbSearchRegion.Controls.Add(this.tbxSRZInterval);
            this.gbSearchRegion.Controls.Add(this.tbxSRYInterval);
            this.gbSearchRegion.Controls.Add(this.tbxSRXInterval);
            this.gbSearchRegion.Controls.Add(this.lblSREndPoint);
            this.gbSearchRegion.Controls.Add(this.lblSRZ);
            this.gbSearchRegion.Controls.Add(this.lblSRInterval);
            this.gbSearchRegion.Controls.Add(this.labelSRStartPoint);
            this.gbSearchRegion.Controls.Add(this.tbxSRYStart);
            this.gbSearchRegion.Controls.Add(this.tbxSRZEnd);
            this.gbSearchRegion.Controls.Add(this.lblSRY);
            this.gbSearchRegion.Controls.Add(this.lblSRX);
            this.gbSearchRegion.Controls.Add(this.tbxSRXStart);
            this.gbSearchRegion.Location = new System.Drawing.Point(3, 135);
            this.gbSearchRegion.Name = "gbSearchRegion";
            this.gbSearchRegion.Size = new System.Drawing.Size(284, 113);
            this.gbSearchRegion.TabIndex = 1;
            this.gbSearchRegion.TabStop = false;
            this.gbSearchRegion.Text = "Search Region";
            // 
            // tbxSRZStart
            // 
            this.tbxSRZStart.Location = new System.Drawing.Point(216, 35);
            this.tbxSRZStart.Name = "tbxSRZStart";
            this.tbxSRZStart.Size = new System.Drawing.Size(53, 21);
            this.tbxSRZStart.TabIndex = 11;
            this.tbxSRZStart.Text = "0";
            this.tbxSRZStart.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // tbxSRYEnd
            // 
            this.tbxSRYEnd.Location = new System.Drawing.Point(156, 85);
            this.tbxSRYEnd.Name = "tbxSRYEnd";
            this.tbxSRYEnd.Size = new System.Drawing.Size(53, 21);
            this.tbxSRYEnd.TabIndex = 5;
            this.tbxSRYEnd.Text = "-2";
            this.tbxSRYEnd.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // tbxSRXEnd
            // 
            this.tbxSRXEnd.Location = new System.Drawing.Point(93, 85);
            this.tbxSRXEnd.Name = "tbxSRXEnd";
            this.tbxSRXEnd.Size = new System.Drawing.Size(53, 21);
            this.tbxSRXEnd.TabIndex = 2;
            this.tbxSRXEnd.Text = "2";
            this.tbxSRXEnd.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // tbxSRZInterval
            // 
            this.tbxSRZInterval.Location = new System.Drawing.Point(216, 60);
            this.tbxSRZInterval.Name = "tbxSRZInterval";
            this.tbxSRZInterval.Size = new System.Drawing.Size(53, 21);
            this.tbxSRZInterval.TabIndex = 12;
            this.tbxSRZInterval.Text = "0";
            this.tbxSRZInterval.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // tbxSRYInterval
            // 
            this.tbxSRYInterval.Location = new System.Drawing.Point(156, 60);
            this.tbxSRYInterval.Name = "tbxSRYInterval";
            this.tbxSRYInterval.Size = new System.Drawing.Size(53, 21);
            this.tbxSRYInterval.TabIndex = 4;
            this.tbxSRYInterval.Text = "-0.1";
            this.tbxSRYInterval.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // tbxSRXInterval
            // 
            this.tbxSRXInterval.Location = new System.Drawing.Point(93, 60);
            this.tbxSRXInterval.Name = "tbxSRXInterval";
            this.tbxSRXInterval.Size = new System.Drawing.Size(53, 21);
            this.tbxSRXInterval.TabIndex = 1;
            this.tbxSRXInterval.Text = "0.1";
            this.tbxSRXInterval.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lblSREndPoint
            // 
            this.lblSREndPoint.AutoSize = true;
            this.lblSREndPoint.Location = new System.Drawing.Point(15, 89);
            this.lblSREndPoint.Name = "lblSREndPoint";
            this.lblSREndPoint.Size = new System.Drawing.Size(59, 12);
            this.lblSREndPoint.TabIndex = 9;
            this.lblSREndPoint.Text = "End Point";
            // 
            // lblSRZ
            // 
            this.lblSRZ.AutoSize = true;
            this.lblSRZ.Location = new System.Drawing.Point(230, 19);
            this.lblSRZ.Name = "lblSRZ";
            this.lblSRZ.Size = new System.Drawing.Size(35, 12);
            this.lblSRZ.TabIndex = 14;
            this.lblSRZ.Text = "Z (m)";
            // 
            // lblSRInterval
            // 
            this.lblSRInterval.AutoSize = true;
            this.lblSRInterval.Location = new System.Drawing.Point(15, 65);
            this.lblSRInterval.Name = "lblSRInterval";
            this.lblSRInterval.Size = new System.Drawing.Size(53, 12);
            this.lblSRInterval.TabIndex = 10;
            this.lblSRInterval.Text = "Interval";
            // 
            // labelSRStartPoint
            // 
            this.labelSRStartPoint.AutoSize = true;
            this.labelSRStartPoint.Location = new System.Drawing.Point(15, 41);
            this.labelSRStartPoint.Name = "labelSRStartPoint";
            this.labelSRStartPoint.Size = new System.Drawing.Size(71, 12);
            this.labelSRStartPoint.TabIndex = 8;
            this.labelSRStartPoint.Text = "Start Point";
            // 
            // tbxSRYStart
            // 
            this.tbxSRYStart.Location = new System.Drawing.Point(156, 35);
            this.tbxSRYStart.Name = "tbxSRYStart";
            this.tbxSRYStart.Size = new System.Drawing.Size(53, 21);
            this.tbxSRYStart.TabIndex = 3;
            this.tbxSRYStart.Text = "2";
            this.tbxSRYStart.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // tbxSRZEnd
            // 
            this.tbxSRZEnd.Location = new System.Drawing.Point(216, 85);
            this.tbxSRZEnd.Name = "tbxSRZEnd";
            this.tbxSRZEnd.Size = new System.Drawing.Size(53, 21);
            this.tbxSRZEnd.TabIndex = 13;
            this.tbxSRZEnd.Text = "0";
            this.tbxSRZEnd.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lblSRY
            // 
            this.lblSRY.AutoSize = true;
            this.lblSRY.Location = new System.Drawing.Point(168, 19);
            this.lblSRY.Name = "lblSRY";
            this.lblSRY.Size = new System.Drawing.Size(35, 12);
            this.lblSRY.TabIndex = 7;
            this.lblSRY.Tag = " ";
            this.lblSRY.Text = "Y (m)";
            // 
            // lblSRX
            // 
            this.lblSRX.AutoSize = true;
            this.lblSRX.Location = new System.Drawing.Point(105, 19);
            this.lblSRX.Name = "lblSRX";
            this.lblSRX.Size = new System.Drawing.Size(35, 12);
            this.lblSRX.TabIndex = 6;
            this.lblSRX.Text = "X (m)";
            // 
            // tbxSRXStart
            // 
            this.tbxSRXStart.Location = new System.Drawing.Point(93, 36);
            this.tbxSRXStart.Name = "tbxSRXStart";
            this.tbxSRXStart.Size = new System.Drawing.Size(53, 21);
            this.tbxSRXStart.TabIndex = 0;
            this.tbxSRXStart.Text = "-2";
            this.tbxSRXStart.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // gbAntennaTrack
            // 
            this.gbAntennaTrack.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbAntennaTrack.Controls.Add(this.tbxSimulationSamplingTime);
            this.gbAntennaTrack.Controls.Add(this.lblSamplingInterval);
            this.gbAntennaTrack.Controls.Add(this.tbxSamplingAntennaSpeed);
            this.gbAntennaTrack.Controls.Add(this.lblAntennaSpeed);
            this.gbAntennaTrack.Controls.Add(this.tbxAntZStart);
            this.gbAntennaTrack.Controls.Add(this.lblAntennaZ);
            this.gbAntennaTrack.Controls.Add(this.tbxAntXStart);
            this.gbAntennaTrack.Controls.Add(this.tbxAntYStart);
            this.gbAntennaTrack.Controls.Add(this.lblAntennaX);
            this.gbAntennaTrack.Controls.Add(this.lblAntStartPoint);
            this.gbAntennaTrack.Controls.Add(this.lblAntennaY);
            this.gbAntennaTrack.Location = new System.Drawing.Point(4, 249);
            this.gbAntennaTrack.Name = "gbAntennaTrack";
            this.gbAntennaTrack.Size = new System.Drawing.Size(284, 111);
            this.gbAntennaTrack.TabIndex = 1;
            this.gbAntennaTrack.TabStop = false;
            this.gbAntennaTrack.Text = "Antenna Track";
            // 
            // tbxSimulationSamplingTime
            // 
            this.tbxSimulationSamplingTime.Location = new System.Drawing.Point(156, 83);
            this.tbxSimulationSamplingTime.Name = "tbxSimulationSamplingTime";
            this.tbxSimulationSamplingTime.Size = new System.Drawing.Size(68, 21);
            this.tbxSimulationSamplingTime.TabIndex = 32;
            this.tbxSimulationSamplingTime.Text = "0.02";
            this.tbxSimulationSamplingTime.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lblSamplingInterval
            // 
            this.lblSamplingInterval.AutoSize = true;
            this.lblSamplingInterval.Location = new System.Drawing.Point(15, 86);
            this.lblSamplingInterval.Name = "lblSamplingInterval";
            this.lblSamplingInterval.Size = new System.Drawing.Size(131, 12);
            this.lblSamplingInterval.TabIndex = 33;
            this.lblSamplingInterval.Text = "Sampling Interval (s)";
            // 
            // tbxSamplingAntennaSpeed
            // 
            this.tbxSamplingAntennaSpeed.Location = new System.Drawing.Point(156, 56);
            this.tbxSamplingAntennaSpeed.Name = "tbxSamplingAntennaSpeed";
            this.tbxSamplingAntennaSpeed.Size = new System.Drawing.Size(68, 21);
            this.tbxSamplingAntennaSpeed.TabIndex = 30;
            this.tbxSamplingAntennaSpeed.Text = "0.05";
            this.tbxSamplingAntennaSpeed.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lblAntennaSpeed
            // 
            this.lblAntennaSpeed.AutoSize = true;
            this.lblAntennaSpeed.Location = new System.Drawing.Point(15, 61);
            this.lblAntennaSpeed.Name = "lblAntennaSpeed";
            this.lblAntennaSpeed.Size = new System.Drawing.Size(119, 12);
            this.lblAntennaSpeed.TabIndex = 31;
            this.lblAntennaSpeed.Text = "Antenna Speed (m/s)";
            // 
            // tbxAntZStart
            // 
            this.tbxAntZStart.Location = new System.Drawing.Point(216, 28);
            this.tbxAntZStart.Name = "tbxAntZStart";
            this.tbxAntZStart.Size = new System.Drawing.Size(53, 21);
            this.tbxAntZStart.TabIndex = 26;
            this.tbxAntZStart.Text = "0";
            this.tbxAntZStart.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lblAntennaZ
            // 
            this.lblAntennaZ.AutoSize = true;
            this.lblAntennaZ.Location = new System.Drawing.Point(230, 14);
            this.lblAntennaZ.Name = "lblAntennaZ";
            this.lblAntennaZ.Size = new System.Drawing.Size(35, 12);
            this.lblAntennaZ.TabIndex = 29;
            this.lblAntennaZ.Text = "Z (m)";
            // 
            // tbxAntXStart
            // 
            this.tbxAntXStart.Location = new System.Drawing.Point(93, 28);
            this.tbxAntXStart.Name = "tbxAntXStart";
            this.tbxAntXStart.Size = new System.Drawing.Size(53, 21);
            this.tbxAntXStart.TabIndex = 15;
            this.tbxAntXStart.Text = "-2";
            this.tbxAntXStart.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // tbxAntYStart
            // 
            this.tbxAntYStart.Location = new System.Drawing.Point(156, 28);
            this.tbxAntYStart.Name = "tbxAntYStart";
            this.tbxAntYStart.Size = new System.Drawing.Size(53, 21);
            this.tbxAntYStart.TabIndex = 18;
            this.tbxAntYStart.Text = "-3";
            this.tbxAntYStart.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lblAntennaX
            // 
            this.lblAntennaX.AutoSize = true;
            this.lblAntennaX.Location = new System.Drawing.Point(105, 14);
            this.lblAntennaX.Name = "lblAntennaX";
            this.lblAntennaX.Size = new System.Drawing.Size(35, 12);
            this.lblAntennaX.TabIndex = 21;
            this.lblAntennaX.Text = "X (m)";
            // 
            // lblAntStartPoint
            // 
            this.lblAntStartPoint.AutoSize = true;
            this.lblAntStartPoint.Location = new System.Drawing.Point(15, 31);
            this.lblAntStartPoint.Name = "lblAntStartPoint";
            this.lblAntStartPoint.Size = new System.Drawing.Size(71, 12);
            this.lblAntStartPoint.TabIndex = 23;
            this.lblAntStartPoint.Text = "Start Point";
            // 
            // lblAntennaY
            // 
            this.lblAntennaY.AutoSize = true;
            this.lblAntennaY.Location = new System.Drawing.Point(168, 14);
            this.lblAntennaY.Name = "lblAntennaY";
            this.lblAntennaY.Size = new System.Drawing.Size(35, 12);
            this.lblAntennaY.TabIndex = 22;
            this.lblAntennaY.Text = "Y (m)";
            // 
            // tlpHeatMap
            // 
            this.tlpHeatMap.ColumnCount = 1;
            this.tlpHeatMap.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpHeatMap.Controls.Add(this.pbHeatMap, 0, 0);
            this.tlpHeatMap.Controls.Add(this.lblLocalizationResult, 0, 1);
            this.tlpHeatMap.Controls.Add(this.tbxLocalizationResult, 0, 2);
            this.tlpHeatMap.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpHeatMap.Location = new System.Drawing.Point(0, 0);
            this.tlpHeatMap.Name = "tlpHeatMap";
            this.tlpHeatMap.RowCount = 3;
            this.tlpHeatMap.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 80.1604F));
            this.tlpHeatMap.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26F));
            this.tlpHeatMap.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 163F));
            this.tlpHeatMap.Size = new System.Drawing.Size(662, 665);
            this.tlpHeatMap.TabIndex = 2;
            // 
            // pbHeatMap
            // 
            this.pbHeatMap.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pbHeatMap.Location = new System.Drawing.Point(126, 33);
            this.pbHeatMap.Name = "pbHeatMap";
            this.pbHeatMap.Size = new System.Drawing.Size(410, 410);
            this.pbHeatMap.TabIndex = 1;
            this.pbHeatMap.TabStop = false;
            // 
            // lblLocalizationResult
            // 
            this.lblLocalizationResult.AutoSize = true;
            this.lblLocalizationResult.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblLocalizationResult.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblLocalizationResult.Font = new System.Drawing.Font("SimSun", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblLocalizationResult.Location = new System.Drawing.Point(3, 476);
            this.lblLocalizationResult.Name = "lblLocalizationResult";
            this.lblLocalizationResult.Size = new System.Drawing.Size(656, 26);
            this.lblLocalizationResult.TabIndex = 4;
            this.lblLocalizationResult.Text = "Localization Result";
            this.lblLocalizationResult.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tbxLocalizationResult
            // 
            this.tbxLocalizationResult.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbxLocalizationResult.Location = new System.Drawing.Point(3, 505);
            this.tbxLocalizationResult.Multiline = true;
            this.tbxLocalizationResult.Name = "tbxLocalizationResult";
            this.tbxLocalizationResult.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbxLocalizationResult.Size = new System.Drawing.Size(656, 157);
            this.tbxLocalizationResult.TabIndex = 3;
            // 
            // gbBasicSettings
            // 
            this.gbBasicSettings.Controls.Add(this.cbResetToFactoryDefault);
            this.gbBasicSettings.Controls.Add(this.gbTagFilter);
            this.gbBasicSettings.Controls.Add(this.gbFrequencyInfo);
            this.gbBasicSettings.Controls.Add(this.gbReadMode);
            this.gbBasicSettings.Controls.Add(this.gbAddress);
            this.gbBasicSettings.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbBasicSettings.Location = new System.Drawing.Point(6, 6);
            this.gbBasicSettings.Name = "gbBasicSettings";
            this.gbBasicSettings.Size = new System.Drawing.Size(264, 864);
            this.gbBasicSettings.TabIndex = 3;
            this.gbBasicSettings.TabStop = false;
            this.gbBasicSettings.Text = "Basic Settings";
            // 
            // cbResetToFactoryDefault
            // 
            this.cbResetToFactoryDefault.AutoSize = true;
            this.cbResetToFactoryDefault.Checked = true;
            this.cbResetToFactoryDefault.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbResetToFactoryDefault.Location = new System.Drawing.Point(11, 24);
            this.cbResetToFactoryDefault.Name = "cbResetToFactoryDefault";
            this.cbResetToFactoryDefault.Size = new System.Drawing.Size(168, 16);
            this.cbResetToFactoryDefault.TabIndex = 6;
            this.cbResetToFactoryDefault.Text = "Reset To Factory Default";
            this.cbResetToFactoryDefault.UseVisualStyleBackColor = true;
            // 
            // gbTagFilter
            // 
            this.gbTagFilter.Controls.Add(this.cbExtraMask);
            this.gbTagFilter.Controls.Add(this.cbMask);
            this.gbTagFilter.Controls.Add(this.lblExtraMask);
            this.gbTagFilter.Controls.Add(this.lblMask);
            this.gbTagFilter.Location = new System.Drawing.Point(6, 531);
            this.gbTagFilter.Name = "gbTagFilter";
            this.gbTagFilter.Size = new System.Drawing.Size(252, 70);
            this.gbTagFilter.TabIndex = 5;
            this.gbTagFilter.TabStop = false;
            this.gbTagFilter.Text = "Tag Filter";
            // 
            // cbExtraMask
            // 
            this.cbExtraMask.FormattingEnabled = true;
            this.cbExtraMask.Location = new System.Drawing.Point(68, 44);
            this.cbExtraMask.Name = "cbExtraMask";
            this.cbExtraMask.Size = new System.Drawing.Size(178, 20);
            this.cbExtraMask.TabIndex = 5;
            this.cbExtraMask.SelectedIndexChanged += new System.EventHandler(this.cbExtraMask_SelectedIndexChanged);
            // 
            // cbMask
            // 
            this.cbMask.FormattingEnabled = true;
            this.cbMask.Location = new System.Drawing.Point(68, 18);
            this.cbMask.Name = "cbMask";
            this.cbMask.Size = new System.Drawing.Size(178, 20);
            this.cbMask.TabIndex = 4;
            this.cbMask.SelectedIndexChanged += new System.EventHandler(this.cbMask_SelectedIndexChanged);
            // 
            // lblExtraMask
            // 
            this.lblExtraMask.AutoSize = true;
            this.lblExtraMask.Location = new System.Drawing.Point(3, 47);
            this.lblExtraMask.Name = "lblExtraMask";
            this.lblExtraMask.Size = new System.Drawing.Size(65, 12);
            this.lblExtraMask.TabIndex = 1;
            this.lblExtraMask.Text = "Extra Mask";
            // 
            // lblMask
            // 
            this.lblMask.AutoSize = true;
            this.lblMask.Location = new System.Drawing.Point(3, 21);
            this.lblMask.Name = "lblMask";
            this.lblMask.Size = new System.Drawing.Size(29, 12);
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
            this.gbFrequencyInfo.Location = new System.Drawing.Point(6, 290);
            this.gbFrequencyInfo.Name = "gbFrequencyInfo";
            this.gbFrequencyInfo.Size = new System.Drawing.Size(252, 235);
            this.gbFrequencyInfo.TabIndex = 4;
            this.gbFrequencyInfo.TabStop = false;
            this.gbFrequencyInfo.Text = "Frequency Information";
            // 
            // nudHop
            // 
            this.nudHop.Location = new System.Drawing.Point(68, 207);
            this.nudHop.Name = "nudHop";
            this.nudHop.Size = new System.Drawing.Size(178, 21);
            this.nudHop.TabIndex = 7;
            this.nudHop.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // clbFreqSet
            // 
            this.clbFreqSet.FormattingEnabled = true;
            this.clbFreqSet.Location = new System.Drawing.Point(68, 60);
            this.clbFreqSet.Name = "clbFreqSet";
            this.clbFreqSet.Size = new System.Drawing.Size(178, 132);
            this.clbFreqSet.TabIndex = 5;
            // 
            // lblHop
            // 
            this.lblHop.AutoSize = true;
            this.lblHop.Location = new System.Drawing.Point(3, 209);
            this.lblHop.Name = "lblHop";
            this.lblHop.Size = new System.Drawing.Size(53, 12);
            this.lblHop.TabIndex = 4;
            this.lblHop.Text = "Hop Step";
            // 
            // lblFreqSet
            // 
            this.lblFreqSet.AutoSize = true;
            this.lblFreqSet.Location = new System.Drawing.Point(3, 60);
            this.lblFreqSet.Name = "lblFreqSet";
            this.lblFreqSet.Size = new System.Drawing.Size(53, 12);
            this.lblFreqSet.TabIndex = 2;
            this.lblFreqSet.Text = "Freq Set";
            // 
            // cbFreqMode
            // 
            this.cbFreqMode.FormattingEnabled = true;
            this.cbFreqMode.Location = new System.Drawing.Point(68, 26);
            this.cbFreqMode.Name = "cbFreqMode";
            this.cbFreqMode.Size = new System.Drawing.Size(178, 20);
            this.cbFreqMode.TabIndex = 1;
            this.cbFreqMode.SelectedIndexChanged += new System.EventHandler(this.cbFreqMode_SelectedIndexChanged);
            // 
            // lblFreqMode
            // 
            this.lblFreqMode.AutoSize = true;
            this.lblFreqMode.Location = new System.Drawing.Point(3, 29);
            this.lblFreqMode.Name = "lblFreqMode";
            this.lblFreqMode.Size = new System.Drawing.Size(59, 12);
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
            this.gbReadMode.Location = new System.Drawing.Point(6, 173);
            this.gbReadMode.Name = "gbReadMode";
            this.gbReadMode.Size = new System.Drawing.Size(252, 111);
            this.gbReadMode.TabIndex = 2;
            this.gbReadMode.TabStop = false;
            this.gbReadMode.Text = "Read Mode";
            // 
            // lblMs
            // 
            this.lblMs.AutoSize = true;
            this.lblMs.Location = new System.Drawing.Point(164, 78);
            this.lblMs.Name = "lblMs";
            this.lblMs.Size = new System.Drawing.Size(17, 12);
            this.lblMs.TabIndex = 4;
            this.lblMs.Text = "ms";
            // 
            // tbxDuration
            // 
            this.tbxDuration.Location = new System.Drawing.Point(88, 75);
            this.tbxDuration.Name = "tbxDuration";
            this.tbxDuration.Size = new System.Drawing.Size(69, 21);
            this.tbxDuration.TabIndex = 3;
            this.tbxDuration.Text = "30000";
            // 
            // lblDuration
            // 
            this.lblDuration.AutoSize = true;
            this.lblDuration.Location = new System.Drawing.Point(23, 78);
            this.lblDuration.Name = "lblDuration";
            this.lblDuration.Size = new System.Drawing.Size(53, 12);
            this.lblDuration.TabIndex = 2;
            this.lblDuration.Text = "Duration";
            // 
            // rbtnTimerReadMode
            // 
            this.rbtnTimerReadMode.AutoSize = true;
            this.rbtnTimerReadMode.Location = new System.Drawing.Point(6, 50);
            this.rbtnTimerReadMode.Name = "rbtnTimerReadMode";
            this.rbtnTimerReadMode.Size = new System.Drawing.Size(113, 16);
            this.rbtnTimerReadMode.TabIndex = 1;
            this.rbtnTimerReadMode.Text = "Timer Read Mode";
            this.rbtnTimerReadMode.UseVisualStyleBackColor = true;
            this.rbtnTimerReadMode.CheckedChanged += new System.EventHandler(this.rbtnTimerReadMode_CheckedChanged);
            // 
            // rbtnManualReadMode
            // 
            this.rbtnManualReadMode.AutoSize = true;
            this.rbtnManualReadMode.Checked = true;
            this.rbtnManualReadMode.Location = new System.Drawing.Point(6, 24);
            this.rbtnManualReadMode.Name = "rbtnManualReadMode";
            this.rbtnManualReadMode.Size = new System.Drawing.Size(119, 16);
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
            this.gbAddress.Location = new System.Drawing.Point(6, 52);
            this.gbAddress.Name = "gbAddress";
            this.gbAddress.Size = new System.Drawing.Size(252, 115);
            this.gbAddress.TabIndex = 1;
            this.gbAddress.TabStop = false;
            this.gbAddress.Text = "Address";
            // 
            // btnSearchIP
            // 
            this.btnSearchIP.Location = new System.Drawing.Point(158, 26);
            this.btnSearchIP.Name = "btnSearchIP";
            this.btnSearchIP.Size = new System.Drawing.Size(75, 23);
            this.btnSearchIP.TabIndex = 17;
            this.btnSearchIP.Text = "Search";
            this.btnSearchIP.UseVisualStyleBackColor = true;
            this.btnSearchIP.Click += new System.EventHandler(this.btnSearchIP_Click);
            // 
            // lblMAC3
            // 
            this.lblMAC3.AutoSize = true;
            this.lblMAC3.Location = new System.Drawing.Point(146, 90);
            this.lblMAC3.Name = "lblMAC3";
            this.lblMAC3.Size = new System.Drawing.Size(11, 12);
            this.lblMAC3.TabIndex = 16;
            this.lblMAC3.Text = "-";
            // 
            // tbxMAC3
            // 
            this.tbxMAC3.Location = new System.Drawing.Point(159, 85);
            this.tbxMAC3.MaxLength = 2;
            this.tbxMAC3.Name = "tbxMAC3";
            this.tbxMAC3.Size = new System.Drawing.Size(21, 21);
            this.tbxMAC3.TabIndex = 13;
            // 
            // lblMAC2
            // 
            this.lblMAC2.AutoSize = true;
            this.lblMAC2.Location = new System.Drawing.Point(109, 89);
            this.lblMAC2.Name = "lblMAC2";
            this.lblMAC2.Size = new System.Drawing.Size(11, 12);
            this.lblMAC2.TabIndex = 15;
            this.lblMAC2.Text = "-";
            // 
            // lblMAC4
            // 
            this.lblMAC4.AutoSize = true;
            this.lblMAC4.Location = new System.Drawing.Point(184, 90);
            this.lblMAC4.Name = "lblMAC4";
            this.lblMAC4.Size = new System.Drawing.Size(41, 12);
            this.lblMAC4.TabIndex = 14;
            this.lblMAC4.Text = ".local";
            // 
            // tbxMAC2
            // 
            this.tbxMAC2.Location = new System.Drawing.Point(122, 85);
            this.tbxMAC2.MaxLength = 2;
            this.tbxMAC2.Name = "tbxMAC2";
            this.tbxMAC2.Size = new System.Drawing.Size(22, 21);
            this.tbxMAC2.TabIndex = 12;
            // 
            // tbxMAC1
            // 
            this.tbxMAC1.Location = new System.Drawing.Point(86, 85);
            this.tbxMAC1.MaxLength = 2;
            this.tbxMAC1.Name = "tbxMAC1";
            this.tbxMAC1.Size = new System.Drawing.Size(21, 21);
            this.tbxMAC1.TabIndex = 11;
            // 
            // lblMAC1
            // 
            this.lblMAC1.AutoSize = true;
            this.lblMAC1.Location = new System.Drawing.Point(20, 89);
            this.lblMAC1.Name = "lblMAC1";
            this.lblMAC1.Size = new System.Drawing.Size(65, 12);
            this.lblMAC1.TabIndex = 10;
            this.lblMAC1.Text = "SpeedwayR-";
            // 
            // rbtnHostname
            // 
            this.rbtnHostname.AutoSize = true;
            this.rbtnHostname.Location = new System.Drawing.Point(6, 61);
            this.rbtnHostname.Name = "rbtnHostname";
            this.rbtnHostname.Size = new System.Drawing.Size(71, 16);
            this.rbtnHostname.TabIndex = 3;
            this.rbtnHostname.Text = "Hostname";
            this.rbtnHostname.UseVisualStyleBackColor = true;
            this.rbtnHostname.CheckedChanged += new System.EventHandler(this.rbtnHostname_CheckedChanged);
            // 
            // rbtnIP
            // 
            this.rbtnIP.AutoSize = true;
            this.rbtnIP.Checked = true;
            this.rbtnIP.Location = new System.Drawing.Point(6, 29);
            this.rbtnIP.Name = "rbtnIP";
            this.rbtnIP.Size = new System.Drawing.Size(35, 16);
            this.rbtnIP.TabIndex = 2;
            this.rbtnIP.TabStop = true;
            this.rbtnIP.Text = "IP";
            this.rbtnIP.UseVisualStyleBackColor = true;
            this.rbtnIP.CheckedChanged += new System.EventHandler(this.rbtnIP_CheckedChanged);
            // 
            // tbxIP
            // 
            this.tbxIP.Location = new System.Drawing.Point(49, 27);
            this.tbxIP.Name = "tbxIP";
            this.tbxIP.Size = new System.Drawing.Size(100, 21);
            this.tbxIP.TabIndex = 1;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1276, 927);
            this.Controls.Add(this.tlpAll);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.toolStrip1);
            this.Name = "MainForm";
            this.Text = " ";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainForm_FormClosed);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.tlpAll.ResumeLayout(false);
            this.tlpResultDisplay.ResumeLayout(false);
            this.tabControlChart.ResumeLayout(false);
            this.tpRSSI.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chartRSSI)).EndInit();
            this.tabPhase.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chartPhase)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.scHolographics.Panel1.ResumeLayout(false);
            this.scHolographics.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.scHolographics)).EndInit();
            this.scHolographics.ResumeLayout(false);
            this.gbHoloSettings.ResumeLayout(false);
            this.gbHoloSettings.PerformLayout();
            this.gbHologram.ResumeLayout(false);
            this.gbHologram.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudTagIndexForHologram)).EndInit();
            this.tcHolographics.ResumeLayout(false);
            this.tpSimulation.ResumeLayout(false);
            this.gbSimulationTagPosition.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvSimulationTagPosition)).EndInit();
            this.gbSimulationFrequncy.ResumeLayout(false);
            this.gbSimulationFrequncy.PerformLayout();
            this.gbSearchRegion.ResumeLayout(false);
            this.gbSearchRegion.PerformLayout();
            this.gbAntennaTrack.ResumeLayout(false);
            this.gbAntennaTrack.PerformLayout();
            this.tlpHeatMap.ResumeLayout(false);
            this.tlpHeatMap.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbHeatMap)).EndInit();
            this.gbBasicSettings.ResumeLayout(false);
            this.gbBasicSettings.PerformLayout();
            this.gbTagFilter.ResumeLayout(false);
            this.gbTagFilter.PerformLayout();
            this.gbFrequencyInfo.ResumeLayout(false);
            this.gbFrequencyInfo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudHop)).EndInit();
            this.gbReadMode.ResumeLayout(false);
            this.gbReadMode.PerformLayout();
            this.gbAddress.ResumeLayout(false);
            this.gbAddress.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton tsbtnConnect;
        private System.Windows.Forms.ToolStripButton tsbtnStart;
        private System.Windows.Forms.ToolStripButton tsbtnStop;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton tsbtnClear;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ListView lvBasicInfo;
        private System.Windows.Forms.ColumnHeader colHeaderIndex;
        public System.Windows.Forms.ColumnHeader colHeaderEPC;
        public System.Windows.Forms.ColumnHeader colHeaderAntenna;
        private System.Windows.Forms.ColumnHeader colHeaderChannel;
        public System.Windows.Forms.ColumnHeader colHeaderRSSI;
        public System.Windows.Forms.ColumnHeader colHeaderPhase;
        public System.Windows.Forms.ColumnHeader colHeaderDoppler;
        public System.Windows.Forms.ColumnHeader colHeaderVelocity;
        public System.Windows.Forms.ColumnHeader colHeaderCount;
        private System.Windows.Forms.TableLayoutPanel tlpAll;
        private System.Windows.Forms.TableLayoutPanel tlpResultDisplay;
        private System.Windows.Forms.TabControl tabControlChart;
        private System.Windows.Forms.TabPage tpRSSI;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.GroupBox gbBasicSettings;
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
        private System.Windows.Forms.GroupBox gbReadMode;
        private System.Windows.Forms.TextBox tbxDuration;
        private System.Windows.Forms.Label lblDuration;
        private System.Windows.Forms.RadioButton rbtnTimerReadMode;
        private System.Windows.Forms.RadioButton rbtnManualReadMode;
        private System.Windows.Forms.GroupBox gbFrequencyInfo;
        private System.Windows.Forms.ComboBox cbFreqMode;
        private System.Windows.Forms.Label lblFreqMode;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripButton tsbtnMoreSettings;
        private System.Windows.Forms.CheckedListBox clbFreqSet;
        private System.Windows.Forms.Label lblHop;
        private System.Windows.Forms.Label lblFreqSet;
        private System.Windows.Forms.Label lblMs;
        private System.Windows.Forms.GroupBox gbTagFilter;
        private System.Windows.Forms.Label lblExtraMask;
        private System.Windows.Forms.Label lblMask;
        private System.Windows.Forms.CheckBox cbResetToFactoryDefault;
        private System.Windows.Forms.ComboBox cbExtraMask;
        private System.Windows.Forms.ComboBox cbMask;
        private System.Windows.Forms.ToolStripSplitButton tssbtnSave;
        private System.Windows.Forms.ToolStripMenuItem SaveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem SaveAsToolStripMenuItem;
        private System.Windows.Forms.NumericUpDown nudHop;
        private System.Windows.Forms.ToolStripStatusLabel tsslRunTime;
        private System.Windows.Forms.ToolStripStatusLabel tsslblCounter;
        private System.Windows.Forms.ToolStripStatusLabel tsslblStatus;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartRSSI;
        private System.Windows.Forms.TabPage tabPhase;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartPhase;
        private System.Windows.Forms.SplitContainer scHolographics;
        private System.Windows.Forms.GroupBox gbHoloSettings;
        private System.Windows.Forms.GroupBox gbSearchRegion;
        private System.Windows.Forms.Label lblSRInterval;
        private System.Windows.Forms.TextBox tbxSRYStart;
        private System.Windows.Forms.Label lblSREndPoint;
        private System.Windows.Forms.Label labelSRStartPoint;
        private System.Windows.Forms.Label lblSRY;
        private System.Windows.Forms.Label lblSRX;
        private System.Windows.Forms.TextBox tbxSRYEnd;
        private System.Windows.Forms.TextBox tbxSRYInterval;
        private System.Windows.Forms.TextBox tbxSRXEnd;
        private System.Windows.Forms.TextBox tbxSRXInterval;
        private System.Windows.Forms.TextBox tbxSRXStart;
        private System.Windows.Forms.TextBox tbxSRZStart;
        private System.Windows.Forms.Label lblSRZ;
        private System.Windows.Forms.TextBox tbxSRZEnd;
        private System.Windows.Forms.TextBox tbxSRZInterval;
        private System.Windows.Forms.TabControl tcHolographics;
        private System.Windows.Forms.TabPage tpOnline;
        private System.Windows.Forms.TabPage tpOffline;
        private System.Windows.Forms.TabPage tpSimulation;
        private System.Windows.Forms.GroupBox gbSimulationFrequncy;
        private System.Windows.Forms.TextBox tbxSimulationInitialFrequency;
        private System.Windows.Forms.Label lblSimulationInitialFrequency;
        private System.Windows.Forms.TextBox tbxSimulationHoppingNumber;
        private System.Windows.Forms.Label lblSimulationHoppingFrequencyNumber;
        private System.Windows.Forms.GroupBox gbSimulationTagPosition;
        private System.Windows.Forms.Button btnSimulationStop;
        private System.Windows.Forms.Button btnSimulationStart;
        private System.Windows.Forms.TextBox tbxRefreshInterval;
        private System.Windows.Forms.Label lblRefreshTime;
        private System.Windows.Forms.GroupBox gbAntennaTrack;
        private System.Windows.Forms.TextBox tbxSimulationSamplingTime;
        private System.Windows.Forms.Label lblSamplingInterval;
        private System.Windows.Forms.TextBox tbxSamplingAntennaSpeed;
        private System.Windows.Forms.Label lblAntennaSpeed;
        private System.Windows.Forms.TextBox tbxAntZStart;
        private System.Windows.Forms.Label lblAntennaZ;
        private System.Windows.Forms.TextBox tbxAntXStart;
        private System.Windows.Forms.TextBox tbxAntYStart;
        private System.Windows.Forms.Label lblAntennaX;
        private System.Windows.Forms.Label lblAntStartPoint;
        private System.Windows.Forms.Label lblAntennaY;
        private System.Windows.Forms.ComboBox cbAlgorithms;
        private System.Windows.Forms.Label lblAlgorithms;
        private System.Windows.Forms.DataGridView dgvSimulationTagPosition;
        private System.Windows.Forms.Button btnHolographicsConfirm;
        private System.Windows.Forms.TableLayoutPanel tlpHeatMap;
        private System.Windows.Forms.PictureBox pbHeatMap;
        private System.Windows.Forms.TextBox tbxLocalizationResult;
        private System.Windows.Forms.Label lblLocalizationResult;
        private System.Windows.Forms.GroupBox gbHologram;
        private System.Windows.Forms.NumericUpDown nudTagIndexForHologram;
        private System.Windows.Forms.Label lblTagIndexForHologram;
        private System.Windows.Forms.CheckBox cbDisplayHologram;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSimulationEPC;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSimulationTagX;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSimulationTagY;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSimulationTagZ;
    }
}