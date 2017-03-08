namespace RFIDIntegratedApplication.HolographicsForms
{
    partial class LinearGuideForm
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
            this.gbControlPanel = new System.Windows.Forms.GroupBox();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.btnEmergencyStop = new System.Windows.Forms.Button();
            this.btnResetRotatingPos = new System.Windows.Forms.Button();
            this.btnResetHorizontalPos = new System.Windows.Forms.Button();
            this.btnOriginPoint = new System.Windows.Forms.Button();
            this.gbRotatingAxis = new System.Windows.Forms.GroupBox();
            this.cbRotatingDirection = new System.Windows.Forms.ComboBox();
            this.lblRotatingDirection = new System.Windows.Forms.Label();
            this.btnRotatingRun = new System.Windows.Forms.Button();
            this.tbxSetRotatingSpeed = new System.Windows.Forms.TextBox();
            this.lblSetRotatingSpeed = new System.Windows.Forms.Label();
            this.tbxSetRotatingPos = new System.Windows.Forms.TextBox();
            this.lblSetRotatingPos = new System.Windows.Forms.Label();
            this.gbHorizontalAxis = new System.Windows.Forms.GroupBox();
            this.cbHorizontalDirection = new System.Windows.Forms.ComboBox();
            this.lblHorizontalDirection = new System.Windows.Forms.Label();
            this.btnHorizontalRun = new System.Windows.Forms.Button();
            this.lblHorizontalSpeed = new System.Windows.Forms.Label();
            this.tbxHorizontalSpeed = new System.Windows.Forms.TextBox();
            this.tbxSetHorizontalPos = new System.Windows.Forms.TextBox();
            this.lblSetHorizontalPos = new System.Windows.Forms.Label();
            this.tbxPort = new System.Windows.Forms.TextBox();
            this.lblPort = new System.Windows.Forms.Label();
            this.gbTrajectory = new System.Windows.Forms.GroupBox();
            this.tbxZStart = new System.Windows.Forms.TextBox();
            this.lblAntennaZ = new System.Windows.Forms.Label();
            this.tbxXStart = new System.Windows.Forms.TextBox();
            this.tbxYStart = new System.Windows.Forms.TextBox();
            this.lblAntennaX = new System.Windows.Forms.Label();
            this.lblAntStartPoint = new System.Windows.Forms.Label();
            this.lblAntennaY = new System.Windows.Forms.Label();
            this.rbtnCalculatedByApplication = new System.Windows.Forms.RadioButton();
            this.rbtnProvidedByDevice = new System.Windows.Forms.RadioButton();
            this.tlpDisplay = new System.Windows.Forms.TableLayoutPanel();
            this.lblDisplayHorizontalPos = new System.Windows.Forms.Label();
            this.lblDisplayHorizontalPosition = new System.Windows.Forms.Label();
            this.lblDisplayRotatingPos = new System.Windows.Forms.Label();
            this.lblDisplayRotatingPosition = new System.Windows.Forms.Label();
            this.gbControlPanel.SuspendLayout();
            this.gbRotatingAxis.SuspendLayout();
            this.gbHorizontalAxis.SuspendLayout();
            this.gbTrajectory.SuspendLayout();
            this.tlpDisplay.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbControlPanel
            // 
            this.gbControlPanel.Controls.Add(this.button2);
            this.gbControlPanel.Controls.Add(this.button1);
            this.gbControlPanel.Controls.Add(this.btnEmergencyStop);
            this.gbControlPanel.Controls.Add(this.btnResetRotatingPos);
            this.gbControlPanel.Controls.Add(this.btnResetHorizontalPos);
            this.gbControlPanel.Controls.Add(this.btnOriginPoint);
            this.gbControlPanel.Controls.Add(this.gbRotatingAxis);
            this.gbControlPanel.Controls.Add(this.gbHorizontalAxis);
            this.gbControlPanel.Controls.Add(this.tbxPort);
            this.gbControlPanel.Controls.Add(this.lblPort);
            this.gbControlPanel.Location = new System.Drawing.Point(11, 181);
            this.gbControlPanel.Margin = new System.Windows.Forms.Padding(5);
            this.gbControlPanel.Name = "gbControlPanel";
            this.gbControlPanel.Padding = new System.Windows.Forms.Padding(5);
            this.gbControlPanel.Size = new System.Drawing.Size(569, 592);
            this.gbControlPanel.TabIndex = 0;
            this.gbControlPanel.TabStop = false;
            this.gbControlPanel.Text = "Control Panel";
            this.gbControlPanel.Enter += new System.EventHandler(this.lblDisplayHorizontalPosition_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(406, 28);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(126, 36);
            this.button2.TabIndex = 9;
            this.button2.Text = "disconnect";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(233, 26);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(126, 36);
            this.button1.TabIndex = 8;
            this.button1.Text = "connect";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnEmergencyStop
            // 
            this.btnEmergencyStop.Location = new System.Drawing.Point(15, 451);
            this.btnEmergencyStop.Margin = new System.Windows.Forms.Padding(5);
            this.btnEmergencyStop.Name = "btnEmergencyStop";
            this.btnEmergencyStop.Size = new System.Drawing.Size(544, 36);
            this.btnEmergencyStop.TabIndex = 7;
            this.btnEmergencyStop.Text = "Emergency Stop";
            this.btnEmergencyStop.UseVisualStyleBackColor = true;
            this.btnEmergencyStop.Click += new System.EventHandler(this.btnEmergencyStop_Click);
            // 
            // btnResetRotatingPos
            // 
            this.btnResetRotatingPos.Location = new System.Drawing.Point(12, 540);
            this.btnResetRotatingPos.Margin = new System.Windows.Forms.Padding(5);
            this.btnResetRotatingPos.Name = "btnResetRotatingPos";
            this.btnResetRotatingPos.Size = new System.Drawing.Size(545, 36);
            this.btnResetRotatingPos.TabIndex = 6;
            this.btnResetRotatingPos.Text = "Reset Rotating Position";
            this.btnResetRotatingPos.UseVisualStyleBackColor = true;
            this.btnResetRotatingPos.Click += new System.EventHandler(this.btnResetRotatingPos_Click);
            // 
            // btnResetHorizontalPos
            // 
            this.btnResetHorizontalPos.Location = new System.Drawing.Point(12, 498);
            this.btnResetHorizontalPos.Margin = new System.Windows.Forms.Padding(5);
            this.btnResetHorizontalPos.Name = "btnResetHorizontalPos";
            this.btnResetHorizontalPos.Size = new System.Drawing.Size(545, 36);
            this.btnResetHorizontalPos.TabIndex = 5;
            this.btnResetHorizontalPos.Text = "Reset Horizontal Position";
            this.btnResetHorizontalPos.UseVisualStyleBackColor = true;
            this.btnResetHorizontalPos.Click += new System.EventHandler(this.btnResetHorizontalPos_Click);
            // 
            // btnOriginPoint
            // 
            this.btnOriginPoint.Location = new System.Drawing.Point(15, 410);
            this.btnOriginPoint.Margin = new System.Windows.Forms.Padding(5);
            this.btnOriginPoint.Name = "btnOriginPoint";
            this.btnOriginPoint.Size = new System.Drawing.Size(544, 36);
            this.btnOriginPoint.TabIndex = 4;
            this.btnOriginPoint.Text = "Back to Origin Point";
            this.btnOriginPoint.UseVisualStyleBackColor = true;
            this.btnOriginPoint.Click += new System.EventHandler(this.btnOriginPoint_Click);
            // 
            // gbRotatingAxis
            // 
            this.gbRotatingAxis.Controls.Add(this.cbRotatingDirection);
            this.gbRotatingAxis.Controls.Add(this.lblRotatingDirection);
            this.gbRotatingAxis.Controls.Add(this.btnRotatingRun);
            this.gbRotatingAxis.Controls.Add(this.tbxSetRotatingSpeed);
            this.gbRotatingAxis.Controls.Add(this.lblSetRotatingSpeed);
            this.gbRotatingAxis.Controls.Add(this.tbxSetRotatingPos);
            this.gbRotatingAxis.Controls.Add(this.lblSetRotatingPos);
            this.gbRotatingAxis.Location = new System.Drawing.Point(15, 232);
            this.gbRotatingAxis.Margin = new System.Windows.Forms.Padding(5);
            this.gbRotatingAxis.Name = "gbRotatingAxis";
            this.gbRotatingAxis.Padding = new System.Windows.Forms.Padding(5);
            this.gbRotatingAxis.Size = new System.Drawing.Size(544, 172);
            this.gbRotatingAxis.TabIndex = 3;
            this.gbRotatingAxis.TabStop = false;
            this.gbRotatingAxis.Text = "Rotating Axis";
            // 
            // cbRotatingDirection
            // 
            this.cbRotatingDirection.FormattingEnabled = true;
            this.cbRotatingDirection.Items.AddRange(new object[] {
            "Clockwise",
            "Counterclockwise"});
            this.cbRotatingDirection.Location = new System.Drawing.Point(132, 28);
            this.cbRotatingDirection.Margin = new System.Windows.Forms.Padding(5);
            this.cbRotatingDirection.Name = "cbRotatingDirection";
            this.cbRotatingDirection.Size = new System.Drawing.Size(212, 23);
            this.cbRotatingDirection.TabIndex = 8;
            this.cbRotatingDirection.Text = "Clockwise";
            // 
            // lblRotatingDirection
            // 
            this.lblRotatingDirection.AutoSize = true;
            this.lblRotatingDirection.Location = new System.Drawing.Point(16, 32);
            this.lblRotatingDirection.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblRotatingDirection.Name = "lblRotatingDirection";
            this.lblRotatingDirection.Size = new System.Drawing.Size(79, 15);
            this.lblRotatingDirection.TabIndex = 7;
            this.lblRotatingDirection.Text = "Direction";
            // 
            // btnRotatingRun
            // 
            this.btnRotatingRun.Location = new System.Drawing.Point(12, 120);
            this.btnRotatingRun.Margin = new System.Windows.Forms.Padding(5);
            this.btnRotatingRun.Name = "btnRotatingRun";
            this.btnRotatingRun.Size = new System.Drawing.Size(519, 36);
            this.btnRotatingRun.TabIndex = 6;
            this.btnRotatingRun.Text = "Run";
            this.btnRotatingRun.UseVisualStyleBackColor = true;
            this.btnRotatingRun.Click += new System.EventHandler(this.btnRotatingRun_Click);
            // 
            // tbxSetRotatingSpeed
            // 
            this.tbxSetRotatingSpeed.Location = new System.Drawing.Point(459, 76);
            this.tbxSetRotatingSpeed.Margin = new System.Windows.Forms.Padding(5);
            this.tbxSetRotatingSpeed.Name = "tbxSetRotatingSpeed";
            this.tbxSetRotatingSpeed.Size = new System.Drawing.Size(69, 25);
            this.tbxSetRotatingSpeed.TabIndex = 4;
            this.tbxSetRotatingSpeed.Text = "60";
            this.tbxSetRotatingSpeed.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lblSetRotatingSpeed
            // 
            this.lblSetRotatingSpeed.AutoSize = true;
            this.lblSetRotatingSpeed.Location = new System.Drawing.Point(316, 81);
            this.lblSetRotatingSpeed.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblSetRotatingSpeed.Name = "lblSetRotatingSpeed";
            this.lblSetRotatingSpeed.Size = new System.Drawing.Size(111, 15);
            this.lblSetRotatingSpeed.TabIndex = 4;
            this.lblSetRotatingSpeed.Text = "Speed (deg/s)";
            // 
            // tbxSetRotatingPos
            // 
            this.tbxSetRotatingPos.Location = new System.Drawing.Point(233, 74);
            this.tbxSetRotatingPos.Margin = new System.Windows.Forms.Padding(5);
            this.tbxSetRotatingPos.Name = "tbxSetRotatingPos";
            this.tbxSetRotatingPos.Size = new System.Drawing.Size(68, 25);
            this.tbxSetRotatingPos.TabIndex = 4;
            this.tbxSetRotatingPos.Text = "0";
            this.tbxSetRotatingPos.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lblSetRotatingPos
            // 
            this.lblSetRotatingPos.AutoSize = true;
            this.lblSetRotatingPos.Location = new System.Drawing.Point(9, 81);
            this.lblSetRotatingPos.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblSetRotatingPos.Name = "lblSetRotatingPos";
            this.lblSetRotatingPos.Size = new System.Drawing.Size(167, 15);
            this.lblSetRotatingPos.TabIndex = 4;
            this.lblSetRotatingPos.Text = "Final Position (deg)";
            // 
            // gbHorizontalAxis
            // 
            this.gbHorizontalAxis.Controls.Add(this.cbHorizontalDirection);
            this.gbHorizontalAxis.Controls.Add(this.lblHorizontalDirection);
            this.gbHorizontalAxis.Controls.Add(this.btnHorizontalRun);
            this.gbHorizontalAxis.Controls.Add(this.lblHorizontalSpeed);
            this.gbHorizontalAxis.Controls.Add(this.tbxHorizontalSpeed);
            this.gbHorizontalAxis.Controls.Add(this.tbxSetHorizontalPos);
            this.gbHorizontalAxis.Controls.Add(this.lblSetHorizontalPos);
            this.gbHorizontalAxis.Location = new System.Drawing.Point(15, 72);
            this.gbHorizontalAxis.Margin = new System.Windows.Forms.Padding(5);
            this.gbHorizontalAxis.Name = "gbHorizontalAxis";
            this.gbHorizontalAxis.Padding = new System.Windows.Forms.Padding(5);
            this.gbHorizontalAxis.Size = new System.Drawing.Size(544, 151);
            this.gbHorizontalAxis.TabIndex = 2;
            this.gbHorizontalAxis.TabStop = false;
            this.gbHorizontalAxis.Text = "Horizontal Axis";
            // 
            // cbHorizontalDirection
            // 
            this.cbHorizontalDirection.FormattingEnabled = true;
            this.cbHorizontalDirection.Items.AddRange(new object[] {
            "+X",
            "-X",
            "+Y",
            "-Y",
            "+Z",
            "-Z"});
            this.cbHorizontalDirection.Location = new System.Drawing.Point(128, 28);
            this.cbHorizontalDirection.Margin = new System.Windows.Forms.Padding(5);
            this.cbHorizontalDirection.Name = "cbHorizontalDirection";
            this.cbHorizontalDirection.Size = new System.Drawing.Size(88, 23);
            this.cbHorizontalDirection.TabIndex = 7;
            this.cbHorizontalDirection.Text = "+X";
            // 
            // lblHorizontalDirection
            // 
            this.lblHorizontalDirection.AutoSize = true;
            this.lblHorizontalDirection.Location = new System.Drawing.Point(12, 32);
            this.lblHorizontalDirection.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblHorizontalDirection.Name = "lblHorizontalDirection";
            this.lblHorizontalDirection.Size = new System.Drawing.Size(79, 15);
            this.lblHorizontalDirection.TabIndex = 6;
            this.lblHorizontalDirection.Text = "Direction";
            // 
            // btnHorizontalRun
            // 
            this.btnHorizontalRun.Location = new System.Drawing.Point(15, 108);
            this.btnHorizontalRun.Margin = new System.Windows.Forms.Padding(5);
            this.btnHorizontalRun.Name = "btnHorizontalRun";
            this.btnHorizontalRun.Size = new System.Drawing.Size(517, 36);
            this.btnHorizontalRun.TabIndex = 5;
            this.btnHorizontalRun.Text = "Run";
            this.btnHorizontalRun.UseVisualStyleBackColor = true;
            this.btnHorizontalRun.Click += new System.EventHandler(this.btnHorizontalRun_Click);
            // 
            // lblHorizontalSpeed
            // 
            this.lblHorizontalSpeed.AutoSize = true;
            this.lblHorizontalSpeed.Location = new System.Drawing.Point(321, 74);
            this.lblHorizontalSpeed.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblHorizontalSpeed.Name = "lblHorizontalSpeed";
            this.lblHorizontalSpeed.Size = new System.Drawing.Size(95, 15);
            this.lblHorizontalSpeed.TabIndex = 3;
            this.lblHorizontalSpeed.Text = "Speed (m/s)";
            // 
            // tbxHorizontalSpeed
            // 
            this.tbxHorizontalSpeed.Location = new System.Drawing.Point(459, 68);
            this.tbxHorizontalSpeed.Margin = new System.Windows.Forms.Padding(5);
            this.tbxHorizontalSpeed.Name = "tbxHorizontalSpeed";
            this.tbxHorizontalSpeed.Size = new System.Drawing.Size(69, 25);
            this.tbxHorizontalSpeed.TabIndex = 2;
            this.tbxHorizontalSpeed.Text = "0.1";
            this.tbxHorizontalSpeed.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tbxHorizontalSpeed.TextChanged += new System.EventHandler(this.tbxHorizontalSpeed_TextChanged);
            // 
            // tbxSetHorizontalPos
            // 
            this.tbxSetHorizontalPos.Location = new System.Drawing.Point(176, 68);
            this.tbxSetHorizontalPos.Margin = new System.Windows.Forms.Padding(5);
            this.tbxSetHorizontalPos.Name = "tbxSetHorizontalPos";
            this.tbxSetHorizontalPos.Size = new System.Drawing.Size(68, 25);
            this.tbxSetHorizontalPos.TabIndex = 1;
            this.tbxSetHorizontalPos.Text = "1";
            this.tbxSetHorizontalPos.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tbxSetHorizontalPos.TextChanged += new System.EventHandler(this.tbxSetHorizontalPos_TextChanged);
            // 
            // lblSetHorizontalPos
            // 
            this.lblSetHorizontalPos.AutoSize = true;
            this.lblSetHorizontalPos.Location = new System.Drawing.Point(11, 74);
            this.lblSetHorizontalPos.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblSetHorizontalPos.Name = "lblSetHorizontalPos";
            this.lblSetHorizontalPos.Size = new System.Drawing.Size(151, 15);
            this.lblSetHorizontalPos.TabIndex = 0;
            this.lblSetHorizontalPos.Text = "Final Position (m)";
            // 
            // tbxPort
            // 
            this.tbxPort.Location = new System.Drawing.Point(87, 28);
            this.tbxPort.Margin = new System.Windows.Forms.Padding(5);
            this.tbxPort.Name = "tbxPort";
            this.tbxPort.Size = new System.Drawing.Size(107, 25);
            this.tbxPort.TabIndex = 1;
            this.tbxPort.Text = "9000";
            this.tbxPort.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lblPort
            // 
            this.lblPort.AutoSize = true;
            this.lblPort.Location = new System.Drawing.Point(25, 32);
            this.lblPort.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblPort.Name = "lblPort";
            this.lblPort.Size = new System.Drawing.Size(39, 15);
            this.lblPort.TabIndex = 0;
            this.lblPort.Text = "Port";
            this.lblPort.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // gbTrajectory
            // 
            this.gbTrajectory.Controls.Add(this.tbxZStart);
            this.gbTrajectory.Controls.Add(this.lblAntennaZ);
            this.gbTrajectory.Controls.Add(this.tbxXStart);
            this.gbTrajectory.Controls.Add(this.tbxYStart);
            this.gbTrajectory.Controls.Add(this.lblAntennaX);
            this.gbTrajectory.Controls.Add(this.lblAntStartPoint);
            this.gbTrajectory.Controls.Add(this.lblAntennaY);
            this.gbTrajectory.Controls.Add(this.rbtnCalculatedByApplication);
            this.gbTrajectory.Controls.Add(this.rbtnProvidedByDevice);
            this.gbTrajectory.Location = new System.Drawing.Point(11, 19);
            this.gbTrajectory.Margin = new System.Windows.Forms.Padding(5);
            this.gbTrajectory.Name = "gbTrajectory";
            this.gbTrajectory.Padding = new System.Windows.Forms.Padding(5);
            this.gbTrajectory.Size = new System.Drawing.Size(569, 152);
            this.gbTrajectory.TabIndex = 9;
            this.gbTrajectory.TabStop = false;
            this.gbTrajectory.Text = "Trajectory";
            this.gbTrajectory.Enter += new System.EventHandler(this.gbTrajectory_Enter);
            // 
            // tbxZStart
            // 
            this.tbxZStart.Location = new System.Drawing.Point(395, 42);
            this.tbxZStart.Margin = new System.Windows.Forms.Padding(5);
            this.tbxZStart.Name = "tbxZStart";
            this.tbxZStart.Size = new System.Drawing.Size(91, 25);
            this.tbxZStart.TabIndex = 41;
            this.tbxZStart.Text = "0";
            this.tbxZStart.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tbxZStart.TextChanged += new System.EventHandler(this.tbxZStart_TextChanged);
            // 
            // lblAntennaZ
            // 
            this.lblAntennaZ.AutoSize = true;
            this.lblAntennaZ.Location = new System.Drawing.Point(420, 20);
            this.lblAntennaZ.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblAntennaZ.Name = "lblAntennaZ";
            this.lblAntennaZ.Size = new System.Drawing.Size(47, 15);
            this.lblAntennaZ.TabIndex = 42;
            this.lblAntennaZ.Text = "Z (m)";
            // 
            // tbxXStart
            // 
            this.tbxXStart.Location = new System.Drawing.Point(176, 42);
            this.tbxXStart.Margin = new System.Windows.Forms.Padding(5);
            this.tbxXStart.Name = "tbxXStart";
            this.tbxXStart.Size = new System.Drawing.Size(91, 25);
            this.tbxXStart.TabIndex = 36;
            this.tbxXStart.Text = "0";
            this.tbxXStart.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tbxXStart.TextChanged += new System.EventHandler(this.tbxXStart_TextChanged);
            // 
            // tbxYStart
            // 
            this.tbxYStart.Location = new System.Drawing.Point(288, 42);
            this.tbxYStart.Margin = new System.Windows.Forms.Padding(5);
            this.tbxYStart.Name = "tbxYStart";
            this.tbxYStart.Size = new System.Drawing.Size(91, 25);
            this.tbxYStart.TabIndex = 37;
            this.tbxYStart.Text = "0";
            this.tbxYStart.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lblAntennaX
            // 
            this.lblAntennaX.AutoSize = true;
            this.lblAntennaX.Location = new System.Drawing.Point(197, 20);
            this.lblAntennaX.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblAntennaX.Name = "lblAntennaX";
            this.lblAntennaX.Size = new System.Drawing.Size(47, 15);
            this.lblAntennaX.TabIndex = 38;
            this.lblAntennaX.Text = "X (m)";
            // 
            // lblAntStartPoint
            // 
            this.lblAntStartPoint.AutoSize = true;
            this.lblAntStartPoint.Location = new System.Drawing.Point(25, 48);
            this.lblAntStartPoint.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblAntStartPoint.Name = "lblAntStartPoint";
            this.lblAntStartPoint.Size = new System.Drawing.Size(95, 15);
            this.lblAntStartPoint.TabIndex = 40;
            this.lblAntStartPoint.Text = "Start Point";
            // 
            // lblAntennaY
            // 
            this.lblAntennaY.AutoSize = true;
            this.lblAntennaY.Location = new System.Drawing.Point(309, 20);
            this.lblAntennaY.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblAntennaY.Name = "lblAntennaY";
            this.lblAntennaY.Size = new System.Drawing.Size(47, 15);
            this.lblAntennaY.TabIndex = 39;
            this.lblAntennaY.Text = "Y (m)";
            // 
            // rbtnCalculatedByApplication
            // 
            this.rbtnCalculatedByApplication.AutoSize = true;
            this.rbtnCalculatedByApplication.Checked = true;
            this.rbtnCalculatedByApplication.Location = new System.Drawing.Point(27, 114);
            this.rbtnCalculatedByApplication.Margin = new System.Windows.Forms.Padding(5);
            this.rbtnCalculatedByApplication.Name = "rbtnCalculatedByApplication";
            this.rbtnCalculatedByApplication.Size = new System.Drawing.Size(228, 19);
            this.rbtnCalculatedByApplication.TabIndex = 35;
            this.rbtnCalculatedByApplication.TabStop = true;
            this.rbtnCalculatedByApplication.Text = "Calculated by application";
            this.rbtnCalculatedByApplication.UseVisualStyleBackColor = true;
            // 
            // rbtnProvidedByDevice
            // 
            this.rbtnProvidedByDevice.AutoSize = true;
            this.rbtnProvidedByDevice.Location = new System.Drawing.Point(27, 80);
            this.rbtnProvidedByDevice.Margin = new System.Windows.Forms.Padding(5);
            this.rbtnProvidedByDevice.Name = "rbtnProvidedByDevice";
            this.rbtnProvidedByDevice.Size = new System.Drawing.Size(172, 19);
            this.rbtnProvidedByDevice.TabIndex = 34;
            this.rbtnProvidedByDevice.Text = "Provided by device";
            this.rbtnProvidedByDevice.UseVisualStyleBackColor = true;
            // 
            // tlpDisplay
            // 
            this.tlpDisplay.ColumnCount = 2;
            this.tlpDisplay.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 44.87632F));
            this.tlpDisplay.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 55.12368F));
            this.tlpDisplay.Controls.Add(this.lblDisplayHorizontalPos, 0, 0);
            this.tlpDisplay.Controls.Add(this.lblDisplayHorizontalPosition, 1, 0);
            this.tlpDisplay.Controls.Add(this.lblDisplayRotatingPos, 0, 1);
            this.tlpDisplay.Controls.Add(this.lblDisplayRotatingPosition, 1, 1);
            this.tlpDisplay.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tlpDisplay.Location = new System.Drawing.Point(0, 783);
            this.tlpDisplay.Margin = new System.Windows.Forms.Padding(5);
            this.tlpDisplay.Name = "tlpDisplay";
            this.tlpDisplay.RowCount = 2;
            this.tlpDisplay.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpDisplay.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 31F));
            this.tlpDisplay.Size = new System.Drawing.Size(601, 62);
            this.tlpDisplay.TabIndex = 10;
            // 
            // lblDisplayHorizontalPos
            // 
            this.lblDisplayHorizontalPos.AutoSize = true;
            this.lblDisplayHorizontalPos.BackColor = System.Drawing.Color.WhiteSmoke;
            this.lblDisplayHorizontalPos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblDisplayHorizontalPos.Location = new System.Drawing.Point(5, 0);
            this.lblDisplayHorizontalPos.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblDisplayHorizontalPos.Name = "lblDisplayHorizontalPos";
            this.lblDisplayHorizontalPos.Size = new System.Drawing.Size(259, 31);
            this.lblDisplayHorizontalPos.TabIndex = 0;
            this.lblDisplayHorizontalPos.Text = "Horizontal Position";
            this.lblDisplayHorizontalPos.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblDisplayHorizontalPosition
            // 
            this.lblDisplayHorizontalPosition.AutoSize = true;
            this.lblDisplayHorizontalPosition.BackColor = System.Drawing.Color.WhiteSmoke;
            this.lblDisplayHorizontalPosition.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblDisplayHorizontalPosition.Location = new System.Drawing.Point(274, 0);
            this.lblDisplayHorizontalPosition.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblDisplayHorizontalPosition.Name = "lblDisplayHorizontalPosition";
            this.lblDisplayHorizontalPosition.Size = new System.Drawing.Size(322, 31);
            this.lblDisplayHorizontalPosition.TabIndex = 1;
            this.lblDisplayHorizontalPosition.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblDisplayHorizontalPosition.Click += new System.EventHandler(this.lblDisplayHorizontalPosition_Click);
            // 
            // lblDisplayRotatingPos
            // 
            this.lblDisplayRotatingPos.AutoSize = true;
            this.lblDisplayRotatingPos.BackColor = System.Drawing.Color.WhiteSmoke;
            this.lblDisplayRotatingPos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblDisplayRotatingPos.Location = new System.Drawing.Point(5, 31);
            this.lblDisplayRotatingPos.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblDisplayRotatingPos.Name = "lblDisplayRotatingPos";
            this.lblDisplayRotatingPos.Size = new System.Drawing.Size(259, 31);
            this.lblDisplayRotatingPos.TabIndex = 2;
            this.lblDisplayRotatingPos.Text = "Rotating Position";
            this.lblDisplayRotatingPos.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblDisplayRotatingPosition
            // 
            this.lblDisplayRotatingPosition.AutoSize = true;
            this.lblDisplayRotatingPosition.BackColor = System.Drawing.Color.WhiteSmoke;
            this.lblDisplayRotatingPosition.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblDisplayRotatingPosition.Location = new System.Drawing.Point(274, 31);
            this.lblDisplayRotatingPosition.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblDisplayRotatingPosition.Name = "lblDisplayRotatingPosition";
            this.lblDisplayRotatingPosition.Size = new System.Drawing.Size(322, 31);
            this.lblDisplayRotatingPosition.TabIndex = 3;
            this.lblDisplayRotatingPosition.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // LinearGuideForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(601, 845);
            this.Controls.Add(this.gbTrajectory);
            this.Controls.Add(this.gbControlPanel);
            this.Controls.Add(this.tlpDisplay);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("SimSun", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.HideOnClose = true;
            this.Margin = new System.Windows.Forms.Padding(5);
            this.Name = "LinearGuideForm";
            this.ShowIcon = false;
            this.Text = "Linear Guide";
            this.DockStateChanged += new System.EventHandler(this.LinearGuideForm_DockStateChanged);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.LinearGuideForm_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.LinearGuideForm_FormClosed);
            this.Load += new System.EventHandler(this.LinearGuideForm_Load);
            this.Shown += new System.EventHandler(this.LinearGuideForm_Shown);
            this.Leave += new System.EventHandler(this.LinearGuideForm_Leave);
            this.gbControlPanel.ResumeLayout(false);
            this.gbControlPanel.PerformLayout();
            this.gbRotatingAxis.ResumeLayout(false);
            this.gbRotatingAxis.PerformLayout();
            this.gbHorizontalAxis.ResumeLayout(false);
            this.gbHorizontalAxis.PerformLayout();
            this.gbTrajectory.ResumeLayout(false);
            this.gbTrajectory.PerformLayout();
            this.tlpDisplay.ResumeLayout(false);
            this.tlpDisplay.PerformLayout();
            this.ResumeLayout(false);

    }

        #endregion

        private System.Windows.Forms.GroupBox gbControlPanel;
        private System.Windows.Forms.GroupBox gbTrajectory;
        private System.Windows.Forms.RadioButton rbtnCalculatedByApplication;
        private System.Windows.Forms.RadioButton rbtnProvidedByDevice;
        private System.Windows.Forms.TextBox tbxZStart;
        private System.Windows.Forms.Label lblAntennaZ;
        private System.Windows.Forms.TextBox tbxXStart;
        private System.Windows.Forms.TextBox tbxYStart;
        private System.Windows.Forms.Label lblAntennaX;
        private System.Windows.Forms.Label lblAntStartPoint;
        private System.Windows.Forms.Label lblAntennaY;
        private System.Windows.Forms.TableLayoutPanel tlpDisplay;
        private System.Windows.Forms.Label lblDisplayHorizontalPos;
        private System.Windows.Forms.Label lblDisplayHorizontalPosition;
        private System.Windows.Forms.Label lblDisplayRotatingPos;
        private System.Windows.Forms.Label lblDisplayRotatingPosition;
        private System.Windows.Forms.Label lblPort;
        private System.Windows.Forms.TextBox tbxPort;
        private System.Windows.Forms.GroupBox gbHorizontalAxis;
        private System.Windows.Forms.Label lblSetHorizontalPos;
        private System.Windows.Forms.Label lblHorizontalSpeed;
        private System.Windows.Forms.TextBox tbxHorizontalSpeed;
        private System.Windows.Forms.TextBox tbxSetHorizontalPos;
        private System.Windows.Forms.GroupBox gbRotatingAxis;
        private System.Windows.Forms.Label lblSetRotatingPos;
        private System.Windows.Forms.TextBox tbxSetRotatingSpeed;
        private System.Windows.Forms.Label lblSetRotatingSpeed;
        private System.Windows.Forms.TextBox tbxSetRotatingPos;
        private System.Windows.Forms.Button btnOriginPoint;
        private System.Windows.Forms.Button btnHorizontalRun;
        private System.Windows.Forms.Button btnResetHorizontalPos;
        private System.Windows.Forms.Button btnRotatingRun;
        private System.Windows.Forms.Button btnResetRotatingPos;
        private System.Windows.Forms.Button btnEmergencyStop;
        private System.Windows.Forms.ComboBox cbHorizontalDirection;
        private System.Windows.Forms.Label lblHorizontalDirection;
        private System.Windows.Forms.Label lblRotatingDirection;
        private System.Windows.Forms.ComboBox cbRotatingDirection;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
    }
}