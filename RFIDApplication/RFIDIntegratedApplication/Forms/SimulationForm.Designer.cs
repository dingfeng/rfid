namespace RFIDIntegratedApplication.HolographicsForms
{
    partial class SimulationForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SimulationForm));
            this.gbSimulationTag = new System.Windows.Forms.GroupBox();
            this.tlpSimulationTag = new System.Windows.Forms.TableLayoutPanel();
            this.lblTagIllustration = new System.Windows.Forms.Label();
            this.dgvSimulationTagPosition = new System.Windows.Forms.DataGridView();
            this.colSimulationEPC = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSimulationTagX = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSimulationTagY = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSimulationTagZ = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colReflectiveCoefficient = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTagOrientation = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tlpTagButton = new System.Windows.Forms.TableLayoutPanel();
            this.btnAddTag = new System.Windows.Forms.Button();
            this.btnDeleteTag = new System.Windows.Forms.Button();
            this.gbSimulationFrequncy = new System.Windows.Forms.GroupBox();
            this.nudSimulationHopStep = new System.Windows.Forms.NumericUpDown();
            this.lblSimulationHopStep = new System.Windows.Forms.Label();
            this.tbxSimulationInitialFrequency = new System.Windows.Forms.TextBox();
            this.lblSimulationInitialFrequency = new System.Windows.Forms.Label();
            this.gbReader = new System.Windows.Forms.GroupBox();
            this.tbxSamplingInterval = new System.Windows.Forms.TextBox();
            this.lblSamplingInterval = new System.Windows.Forms.Label();
            this.gbAntenna = new System.Windows.Forms.GroupBox();
            this.gbCable = new System.Windows.Forms.GroupBox();
            this.tbxLength = new System.Windows.Forms.TextBox();
            this.lblLength = new System.Windows.Forms.Label();
            this.gbGaussiannoise = new System.Windows.Forms.GroupBox();
            this.tbxSigma = new System.Windows.Forms.TextBox();
            this.tbxMu = new System.Windows.Forms.TextBox();
            this.lblSigma = new System.Windows.Forms.Label();
            this.lblMu = new System.Windows.Forms.Label();
            this.gbMultipath = new System.Windows.Forms.GroupBox();
            this.cbPhaseAmbiguity = new System.Windows.Forms.CheckBox();
            this.tsSimulation = new System.Windows.Forms.ToolStrip();
            this.tsbtnSimulationStart = new System.Windows.Forms.ToolStripButton();
            this.tsbtnSimulationStop = new System.Windows.Forms.ToolStripButton();
            this.gbSimulationTag.SuspendLayout();
            this.tlpSimulationTag.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSimulationTagPosition)).BeginInit();
            this.tlpTagButton.SuspendLayout();
            this.gbSimulationFrequncy.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudSimulationHopStep)).BeginInit();
            this.gbReader.SuspendLayout();
            this.gbCable.SuspendLayout();
            this.gbGaussiannoise.SuspendLayout();
            this.tsSimulation.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbSimulationTag
            // 
            this.gbSimulationTag.Controls.Add(this.tlpSimulationTag);
            this.gbSimulationTag.Location = new System.Drawing.Point(16, 56);
            this.gbSimulationTag.Margin = new System.Windows.Forms.Padding(4);
            this.gbSimulationTag.Name = "gbSimulationTag";
            this.gbSimulationTag.Padding = new System.Windows.Forms.Padding(4);
            this.gbSimulationTag.Size = new System.Drawing.Size(537, 318);
            this.gbSimulationTag.TabIndex = 4;
            this.gbSimulationTag.TabStop = false;
            this.gbSimulationTag.Text = "Tag";
            // 
            // tlpSimulationTag
            // 
            this.tlpSimulationTag.ColumnCount = 1;
            this.tlpSimulationTag.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpSimulationTag.Controls.Add(this.lblTagIllustration, 0, 2);
            this.tlpSimulationTag.Controls.Add(this.dgvSimulationTagPosition, 0, 0);
            this.tlpSimulationTag.Controls.Add(this.tlpTagButton, 0, 1);
            this.tlpSimulationTag.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpSimulationTag.Location = new System.Drawing.Point(4, 22);
            this.tlpSimulationTag.Margin = new System.Windows.Forms.Padding(4);
            this.tlpSimulationTag.Name = "tlpSimulationTag";
            this.tlpSimulationTag.RowCount = 3;
            this.tlpSimulationTag.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 79.06977F));
            this.tlpSimulationTag.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20.93023F));
            this.tlpSimulationTag.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 76F));
            this.tlpSimulationTag.Size = new System.Drawing.Size(529, 292);
            this.tlpSimulationTag.TabIndex = 1;
            // 
            // lblTagIllustration
            // 
            this.lblTagIllustration.AutoSize = true;
            this.lblTagIllustration.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTagIllustration.Location = new System.Drawing.Point(4, 215);
            this.lblTagIllustration.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTagIllustration.Name = "lblTagIllustration";
            this.lblTagIllustration.Size = new System.Drawing.Size(521, 77);
            this.lblTagIllustration.TabIndex = 2;
            this.lblTagIllustration.Text = "PS:\r\n(1) RC (Reflective Coefficient) - Format: [amplitude, phase]\r\nIndicates ampl" +
    "itude and phase changes of the signal.\r\n(2) Orientation\r\nIndicates the angle bet" +
    "ween the tag and the antenna.";
            // 
            // dgvSimulationTagPosition
            // 
            this.dgvSimulationTagPosition.AllowUserToAddRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dgvSimulationTagPosition.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("SimSun", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvSimulationTagPosition.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvSimulationTagPosition.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSimulationTagPosition.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colSimulationEPC,
            this.colSimulationTagX,
            this.colSimulationTagY,
            this.colSimulationTagZ,
            this.colReflectiveCoefficient,
            this.colTagOrientation});
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle9.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle9.Font = new System.Drawing.Font("SimSun", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle9.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvSimulationTagPosition.DefaultCellStyle = dataGridViewCellStyle9;
            this.dgvSimulationTagPosition.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvSimulationTagPosition.Location = new System.Drawing.Point(4, 4);
            this.dgvSimulationTagPosition.Margin = new System.Windows.Forms.Padding(4);
            this.dgvSimulationTagPosition.Name = "dgvSimulationTagPosition";
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle10.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle10.Font = new System.Drawing.Font("SimSun", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle10.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle10.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle10.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvSimulationTagPosition.RowHeadersDefaultCellStyle = dataGridViewCellStyle10;
            this.dgvSimulationTagPosition.RowTemplate.Height = 23;
            this.dgvSimulationTagPosition.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dgvSimulationTagPosition.Size = new System.Drawing.Size(521, 162);
            this.dgvSimulationTagPosition.TabIndex = 0;
            this.dgvSimulationTagPosition.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvSimulationTagPosition_CellContentClick);
            this.dgvSimulationTagPosition.RowStateChanged += new System.Windows.Forms.DataGridViewRowStateChangedEventHandler(this.dgvSimulationTagPosition_RowStateChanged);
            // 
            // colSimulationEPC
            // 
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.colSimulationEPC.DefaultCellStyle = dataGridViewCellStyle3;
            this.colSimulationEPC.HeaderText = "EPC";
            this.colSimulationEPC.Name = "colSimulationEPC";
            this.colSimulationEPC.Width = 30;
            // 
            // colSimulationTagX
            // 
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.colSimulationTagX.DefaultCellStyle = dataGridViewCellStyle4;
            this.colSimulationTagX.HeaderText = "X (m)";
            this.colSimulationTagX.Name = "colSimulationTagX";
            this.colSimulationTagX.Width = 59;
            // 
            // colSimulationTagY
            // 
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.colSimulationTagY.DefaultCellStyle = dataGridViewCellStyle5;
            this.colSimulationTagY.HeaderText = "Y (m)";
            this.colSimulationTagY.Name = "colSimulationTagY";
            this.colSimulationTagY.Width = 59;
            // 
            // colSimulationTagZ
            // 
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.colSimulationTagZ.DefaultCellStyle = dataGridViewCellStyle6;
            this.colSimulationTagZ.HeaderText = "Z (m)";
            this.colSimulationTagZ.Name = "colSimulationTagZ";
            this.colSimulationTagZ.Width = 59;
            // 
            // colReflectiveCoefficient
            // 
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.colReflectiveCoefficient.DefaultCellStyle = dataGridViewCellStyle7;
            this.colReflectiveCoefficient.HeaderText = " RC";
            this.colReflectiveCoefficient.Name = "colReflectiveCoefficient";
            this.colReflectiveCoefficient.Width = 60;
            // 
            // colTagOrientation
            // 
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.colTagOrientation.DefaultCellStyle = dataGridViewCellStyle8;
            this.colTagOrientation.HeaderText = "Orientation";
            this.colTagOrientation.Name = "colTagOrientation";
            this.colTagOrientation.Width = 80;
            // 
            // tlpTagButton
            // 
            this.tlpTagButton.ColumnCount = 2;
            this.tlpTagButton.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpTagButton.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpTagButton.Controls.Add(this.btnAddTag, 0, 0);
            this.tlpTagButton.Controls.Add(this.btnDeleteTag, 1, 0);
            this.tlpTagButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpTagButton.Location = new System.Drawing.Point(4, 174);
            this.tlpTagButton.Margin = new System.Windows.Forms.Padding(4);
            this.tlpTagButton.Name = "tlpTagButton";
            this.tlpTagButton.RowCount = 1;
            this.tlpTagButton.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpTagButton.Size = new System.Drawing.Size(521, 37);
            this.tlpTagButton.TabIndex = 3;
            // 
            // btnAddTag
            // 
            this.btnAddTag.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnAddTag.Location = new System.Drawing.Point(4, 4);
            this.btnAddTag.Margin = new System.Windows.Forms.Padding(4);
            this.btnAddTag.Name = "btnAddTag";
            this.btnAddTag.Size = new System.Drawing.Size(252, 29);
            this.btnAddTag.TabIndex = 0;
            this.btnAddTag.Text = "Add Tag";
            this.btnAddTag.UseVisualStyleBackColor = true;
            this.btnAddTag.Click += new System.EventHandler(this.btnAddTag_Click);
            // 
            // btnDeleteTag
            // 
            this.btnDeleteTag.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnDeleteTag.Location = new System.Drawing.Point(264, 4);
            this.btnDeleteTag.Margin = new System.Windows.Forms.Padding(4);
            this.btnDeleteTag.Name = "btnDeleteTag";
            this.btnDeleteTag.Size = new System.Drawing.Size(253, 29);
            this.btnDeleteTag.TabIndex = 1;
            this.btnDeleteTag.Text = "Delete Tag";
            this.btnDeleteTag.UseVisualStyleBackColor = true;
            this.btnDeleteTag.Click += new System.EventHandler(this.btnDeleteTag_Click);
            // 
            // gbSimulationFrequncy
            // 
            this.gbSimulationFrequncy.Controls.Add(this.nudSimulationHopStep);
            this.gbSimulationFrequncy.Controls.Add(this.lblSimulationHopStep);
            this.gbSimulationFrequncy.Controls.Add(this.tbxSimulationInitialFrequency);
            this.gbSimulationFrequncy.Controls.Add(this.lblSimulationInitialFrequency);
            this.gbSimulationFrequncy.Location = new System.Drawing.Point(8, 49);
            this.gbSimulationFrequncy.Margin = new System.Windows.Forms.Padding(4);
            this.gbSimulationFrequncy.Name = "gbSimulationFrequncy";
            this.gbSimulationFrequncy.Padding = new System.Windows.Forms.Padding(4);
            this.gbSimulationFrequncy.Size = new System.Drawing.Size(520, 58);
            this.gbSimulationFrequncy.TabIndex = 5;
            this.gbSimulationFrequncy.TabStop = false;
            this.gbSimulationFrequncy.Text = "Frequency";
            // 
            // nudSimulationHopStep
            // 
            this.nudSimulationHopStep.Location = new System.Drawing.Point(419, 22);
            this.nudSimulationHopStep.Margin = new System.Windows.Forms.Padding(4);
            this.nudSimulationHopStep.Name = "nudSimulationHopStep";
            this.nudSimulationHopStep.Size = new System.Drawing.Size(95, 25);
            this.nudSimulationHopStep.TabIndex = 36;
            this.nudSimulationHopStep.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.nudSimulationHopStep.ValueChanged += new System.EventHandler(this.nudSimulationHopStep_ValueChanged);
            // 
            // lblSimulationHopStep
            // 
            this.lblSimulationHopStep.AutoSize = true;
            this.lblSimulationHopStep.Location = new System.Drawing.Point(344, 26);
            this.lblSimulationHopStep.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblSimulationHopStep.Name = "lblSimulationHopStep";
            this.lblSimulationHopStep.Size = new System.Drawing.Size(71, 15);
            this.lblSimulationHopStep.TabIndex = 35;
            this.lblSimulationHopStep.Text = "Hop Step";
            // 
            // tbxSimulationInitialFrequency
            // 
            this.tbxSimulationInitialFrequency.Location = new System.Drawing.Point(209, 21);
            this.tbxSimulationInitialFrequency.Margin = new System.Windows.Forms.Padding(4);
            this.tbxSimulationInitialFrequency.Name = "tbxSimulationInitialFrequency";
            this.tbxSimulationInitialFrequency.Size = new System.Drawing.Size(93, 25);
            this.tbxSimulationInitialFrequency.TabIndex = 32;
            this.tbxSimulationInitialFrequency.Text = "920.625";
            this.tbxSimulationInitialFrequency.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lblSimulationInitialFrequency
            // 
            this.lblSimulationInitialFrequency.AutoSize = true;
            this.lblSimulationInitialFrequency.Location = new System.Drawing.Point(17, 26);
            this.lblSimulationInitialFrequency.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblSimulationInitialFrequency.Name = "lblSimulationInitialFrequency";
            this.lblSimulationInitialFrequency.Size = new System.Drawing.Size(191, 15);
            this.lblSimulationInitialFrequency.TabIndex = 33;
            this.lblSimulationInitialFrequency.Text = "Initial Frequency (MHz)";
            // 
            // gbReader
            // 
            this.gbReader.Controls.Add(this.tbxSamplingInterval);
            this.gbReader.Controls.Add(this.lblSamplingInterval);
            this.gbReader.Controls.Add(this.gbAntenna);
            this.gbReader.Controls.Add(this.gbCable);
            this.gbReader.Controls.Add(this.gbGaussiannoise);
            this.gbReader.Controls.Add(this.gbSimulationFrequncy);
            this.gbReader.Location = new System.Drawing.Point(16, 381);
            this.gbReader.Margin = new System.Windows.Forms.Padding(4);
            this.gbReader.Name = "gbReader";
            this.gbReader.Padding = new System.Windows.Forms.Padding(4);
            this.gbReader.Size = new System.Drawing.Size(533, 308);
            this.gbReader.TabIndex = 6;
            this.gbReader.TabStop = false;
            this.gbReader.Text = "Reader";
            // 
            // tbxSamplingInterval
            // 
            this.tbxSamplingInterval.Location = new System.Drawing.Point(203, 19);
            this.tbxSamplingInterval.Margin = new System.Windows.Forms.Padding(4);
            this.tbxSamplingInterval.Name = "tbxSamplingInterval";
            this.tbxSamplingInterval.Size = new System.Drawing.Size(89, 25);
            this.tbxSamplingInterval.TabIndex = 34;
            this.tbxSamplingInterval.Text = "1";
            this.tbxSamplingInterval.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lblSamplingInterval
            // 
            this.lblSamplingInterval.AutoSize = true;
            this.lblSamplingInterval.Location = new System.Drawing.Point(15, 22);
            this.lblSamplingInterval.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblSamplingInterval.Name = "lblSamplingInterval";
            this.lblSamplingInterval.Size = new System.Drawing.Size(175, 15);
            this.lblSamplingInterval.TabIndex = 35;
            this.lblSamplingInterval.Text = "Sampling Interval (s)";
            // 
            // gbAntenna
            // 
            this.gbAntenna.Location = new System.Drawing.Point(7, 224);
            this.gbAntenna.Margin = new System.Windows.Forms.Padding(4);
            this.gbAntenna.Name = "gbAntenna";
            this.gbAntenna.Padding = new System.Windows.Forms.Padding(4);
            this.gbAntenna.Size = new System.Drawing.Size(521, 71);
            this.gbAntenna.TabIndex = 8;
            this.gbAntenna.TabStop = false;
            this.gbAntenna.Text = "Antenna";
            // 
            // gbCable
            // 
            this.gbCable.Controls.Add(this.tbxLength);
            this.gbCable.Controls.Add(this.lblLength);
            this.gbCable.Location = new System.Drawing.Point(8, 164);
            this.gbCable.Margin = new System.Windows.Forms.Padding(4);
            this.gbCable.Name = "gbCable";
            this.gbCable.Padding = new System.Windows.Forms.Padding(4);
            this.gbCable.Size = new System.Drawing.Size(517, 52);
            this.gbCable.TabIndex = 7;
            this.gbCable.TabStop = false;
            this.gbCable.Text = "Cable";
            // 
            // tbxLength
            // 
            this.tbxLength.Location = new System.Drawing.Point(112, 20);
            this.tbxLength.Margin = new System.Windows.Forms.Padding(4);
            this.tbxLength.Name = "tbxLength";
            this.tbxLength.Size = new System.Drawing.Size(132, 25);
            this.tbxLength.TabIndex = 1;
            this.tbxLength.Text = "1";
            this.tbxLength.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lblLength
            // 
            this.lblLength.AutoSize = true;
            this.lblLength.Location = new System.Drawing.Point(17, 25);
            this.lblLength.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblLength.Name = "lblLength";
            this.lblLength.Size = new System.Drawing.Size(87, 15);
            this.lblLength.TabIndex = 0;
            this.lblLength.Text = "Length (m)";
            // 
            // gbGaussiannoise
            // 
            this.gbGaussiannoise.Controls.Add(this.tbxSigma);
            this.gbGaussiannoise.Controls.Add(this.tbxMu);
            this.gbGaussiannoise.Controls.Add(this.lblSigma);
            this.gbGaussiannoise.Controls.Add(this.lblMu);
            this.gbGaussiannoise.Location = new System.Drawing.Point(8, 109);
            this.gbGaussiannoise.Margin = new System.Windows.Forms.Padding(4);
            this.gbGaussiannoise.Name = "gbGaussiannoise";
            this.gbGaussiannoise.Padding = new System.Windows.Forms.Padding(4);
            this.gbGaussiannoise.Size = new System.Drawing.Size(517, 52);
            this.gbGaussiannoise.TabIndex = 6;
            this.gbGaussiannoise.TabStop = false;
            this.gbGaussiannoise.Text = " Gaussian noise";
            // 
            // tbxSigma
            // 
            this.tbxSigma.Location = new System.Drawing.Point(299, 20);
            this.tbxSigma.Margin = new System.Windows.Forms.Padding(4);
            this.tbxSigma.Name = "tbxSigma";
            this.tbxSigma.Size = new System.Drawing.Size(132, 25);
            this.tbxSigma.TabIndex = 3;
            this.tbxSigma.Text = "0.1";
            this.tbxSigma.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // tbxMu
            // 
            this.tbxMu.Location = new System.Drawing.Point(48, 20);
            this.tbxMu.Margin = new System.Windows.Forms.Padding(4);
            this.tbxMu.Name = "tbxMu";
            this.tbxMu.Size = new System.Drawing.Size(132, 25);
            this.tbxMu.TabIndex = 2;
            this.tbxMu.Text = "0";
            this.tbxMu.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lblSigma
            // 
            this.lblSigma.AutoSize = true;
            this.lblSigma.Location = new System.Drawing.Point(244, 24);
            this.lblSigma.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblSigma.Name = "lblSigma";
            this.lblSigma.Size = new System.Drawing.Size(47, 15);
            this.lblSigma.TabIndex = 1;
            this.lblSigma.Text = "Sigma";
            // 
            // lblMu
            // 
            this.lblMu.AutoSize = true;
            this.lblMu.Location = new System.Drawing.Point(17, 24);
            this.lblMu.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblMu.Name = "lblMu";
            this.lblMu.Size = new System.Drawing.Size(23, 15);
            this.lblMu.TabIndex = 0;
            this.lblMu.Text = "Mu";
            // 
            // gbMultipath
            // 
            this.gbMultipath.Location = new System.Drawing.Point(16, 710);
            this.gbMultipath.Margin = new System.Windows.Forms.Padding(4);
            this.gbMultipath.Name = "gbMultipath";
            this.gbMultipath.Padding = new System.Windows.Forms.Padding(4);
            this.gbMultipath.Size = new System.Drawing.Size(533, 126);
            this.gbMultipath.TabIndex = 7;
            this.gbMultipath.TabStop = false;
            this.gbMultipath.Text = "Multipath";
            // 
            // cbPhaseAmbiguity
            // 
            this.cbPhaseAmbiguity.AutoSize = true;
            this.cbPhaseAmbiguity.Location = new System.Drawing.Point(20, 35);
            this.cbPhaseAmbiguity.Margin = new System.Windows.Forms.Padding(4);
            this.cbPhaseAmbiguity.Name = "cbPhaseAmbiguity";
            this.cbPhaseAmbiguity.Size = new System.Drawing.Size(197, 19);
            this.cbPhaseAmbiguity.TabIndex = 8;
            this.cbPhaseAmbiguity.Text = "pi ambiguity of phase";
            this.cbPhaseAmbiguity.UseVisualStyleBackColor = true;
            // 
            // tsSimulation
            // 
            this.tsSimulation.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.tsSimulation.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbtnSimulationStart,
            this.tsbtnSimulationStop});
            this.tsSimulation.Location = new System.Drawing.Point(0, 0);
            this.tsSimulation.Name = "tsSimulation";
            this.tsSimulation.Size = new System.Drawing.Size(564, 27);
            this.tsSimulation.TabIndex = 9;
            this.tsSimulation.Text = "toolStrip1";
            // 
            // tsbtnSimulationStart
            // 
            this.tsbtnSimulationStart.Image = ((System.Drawing.Image)(resources.GetObject("tsbtnSimulationStart.Image")));
            this.tsbtnSimulationStart.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnSimulationStart.Name = "tsbtnSimulationStart";
            this.tsbtnSimulationStart.Size = new System.Drawing.Size(149, 24);
            this.tsbtnSimulationStart.Text = "Simulation Start";
            this.tsbtnSimulationStart.Click += new System.EventHandler(this.tsbtnSimulationStart_Click);
            // 
            // tsbtnSimulationStop
            // 
            this.tsbtnSimulationStop.Image = ((System.Drawing.Image)(resources.GetObject("tsbtnSimulationStop.Image")));
            this.tsbtnSimulationStop.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnSimulationStop.Name = "tsbtnSimulationStop";
            this.tsbtnSimulationStop.Size = new System.Drawing.Size(149, 24);
            this.tsbtnSimulationStop.Text = "Simulation Stop";
            this.tsbtnSimulationStop.Click += new System.EventHandler(this.tsbtnSimulationStop_Click);
            // 
            // SimulationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(564, 851);
            this.Controls.Add(this.tsSimulation);
            this.Controls.Add(this.cbPhaseAmbiguity);
            this.Controls.Add(this.gbMultipath);
            this.Controls.Add(this.gbSimulationTag);
            this.Controls.Add(this.gbReader);
            this.Font = new System.Drawing.Font("SimSun", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.HideOnClose = true;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "SimulationForm";
            this.ShowIcon = false;
            this.Text = "Simulation";
            this.Load += new System.EventHandler(this.SimulationForm_Load);
            this.gbSimulationTag.ResumeLayout(false);
            this.tlpSimulationTag.ResumeLayout(false);
            this.tlpSimulationTag.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSimulationTagPosition)).EndInit();
            this.tlpTagButton.ResumeLayout(false);
            this.gbSimulationFrequncy.ResumeLayout(false);
            this.gbSimulationFrequncy.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudSimulationHopStep)).EndInit();
            this.gbReader.ResumeLayout(false);
            this.gbReader.PerformLayout();
            this.gbCable.ResumeLayout(false);
            this.gbCable.PerformLayout();
            this.gbGaussiannoise.ResumeLayout(false);
            this.gbGaussiannoise.PerformLayout();
            this.tsSimulation.ResumeLayout(false);
            this.tsSimulation.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox gbSimulationTag;
        private System.Windows.Forms.DataGridView dgvSimulationTagPosition;
        private System.Windows.Forms.GroupBox gbSimulationFrequncy;
        private System.Windows.Forms.Label lblSimulationHopStep;
        private System.Windows.Forms.TextBox tbxSimulationInitialFrequency;
        private System.Windows.Forms.Label lblSimulationInitialFrequency;
        private System.Windows.Forms.NumericUpDown nudSimulationHopStep;
        private System.Windows.Forms.TableLayoutPanel tlpSimulationTag;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSimulationEPC;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSimulationTagX;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSimulationTagY;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSimulationTagZ;
        private System.Windows.Forms.DataGridViewTextBoxColumn colReflectiveCoefficient;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTagOrientation;
        private System.Windows.Forms.GroupBox gbReader;
        private System.Windows.Forms.GroupBox gbAntenna;
        private System.Windows.Forms.GroupBox gbCable;
        private System.Windows.Forms.TextBox tbxLength;
        private System.Windows.Forms.Label lblLength;
        private System.Windows.Forms.GroupBox gbGaussiannoise;
        private System.Windows.Forms.TextBox tbxSigma;
        private System.Windows.Forms.TextBox tbxMu;
        private System.Windows.Forms.Label lblSigma;
        private System.Windows.Forms.Label lblMu;
        private System.Windows.Forms.GroupBox gbMultipath;
        private System.Windows.Forms.CheckBox cbPhaseAmbiguity;
        private System.Windows.Forms.TextBox tbxSamplingInterval;
        private System.Windows.Forms.Label lblSamplingInterval;
        private System.Windows.Forms.ToolStrip tsSimulation;
        private System.Windows.Forms.ToolStripButton tsbtnSimulationStart;
        private System.Windows.Forms.ToolStripButton tsbtnSimulationStop;
        private System.Windows.Forms.Label lblTagIllustration;
        private System.Windows.Forms.TableLayoutPanel tlpTagButton;
        private System.Windows.Forms.Button btnAddTag;
        private System.Windows.Forms.Button btnDeleteTag;
    }
}