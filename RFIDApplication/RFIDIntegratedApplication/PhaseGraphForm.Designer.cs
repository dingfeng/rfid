namespace RFIDIntegratedApplication
{
    partial class PhaseGraphForm
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            this.chartPhase = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.tsPhaseSettings = new System.Windows.Forms.ToolStrip();
            this.tslblLineType = new System.Windows.Forms.ToolStripLabel();
            this.tscbLineType = new System.Windows.Forms.ToolStripComboBox();
            this.tslblLineWidth = new System.Windows.Forms.ToolStripLabel();
            this.tscbLineWidth = new System.Windows.Forms.ToolStripComboBox();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tslblPointFreq = new System.Windows.Forms.ToolStripLabel();
            this.tscbPointFrequency = new System.Windows.Forms.ToolStripComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.chartPhase)).BeginInit();
            this.tsPhaseSettings.SuspendLayout();
            this.SuspendLayout();
            // 
            // chartPhase
            // 
            this.chartPhase.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.chartPhase.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            chartArea1.AxisX.IntervalAutoMode = System.Windows.Forms.DataVisualization.Charting.IntervalAutoMode.VariableCount;
            chartArea1.AxisX.IsLabelAutoFit = false;
            chartArea1.AxisX.LabelStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            chartArea1.AxisX.LabelStyle.Interval = 0D;
            chartArea1.AxisX.LineWidth = 2;
            chartArea1.AxisX.MajorGrid.LineColor = System.Drawing.Color.Gainsboro;
            chartArea1.AxisX.MajorGrid.LineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Dash;
            chartArea1.AxisX.MajorTickMark.Interval = 0D;
            chartArea1.AxisX.MajorTickMark.IntervalOffset = 0D;
            chartArea1.AxisX.MajorTickMark.IntervalOffsetType = System.Windows.Forms.DataVisualization.Charting.DateTimeIntervalType.Milliseconds;
            chartArea1.AxisX.MajorTickMark.IntervalType = System.Windows.Forms.DataVisualization.Charting.DateTimeIntervalType.Milliseconds;
            chartArea1.AxisX.Minimum = 0D;
            chartArea1.AxisX.Title = "Time/ms";
            chartArea1.AxisX.TitleFont = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            chartArea1.AxisY.IntervalAutoMode = System.Windows.Forms.DataVisualization.Charting.IntervalAutoMode.VariableCount;
            chartArea1.AxisY.IsLabelAutoFit = false;
            chartArea1.AxisY.LabelStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            chartArea1.AxisY.LabelStyle.Interval = 0D;
            chartArea1.AxisY.LineWidth = 2;
            chartArea1.AxisY.MajorGrid.LineColor = System.Drawing.Color.Gainsboro;
            chartArea1.AxisY.MajorGrid.LineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Dash;
            chartArea1.AxisY.MajorTickMark.Interval = 0D;
            chartArea1.AxisY.Maximum = 6.5D;
            chartArea1.AxisY.Minimum = -0.5D;
            chartArea1.AxisY.Title = "Phase  Value/rad";
            chartArea1.AxisY.TitleFont = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            chartArea1.CursorX.IsUserEnabled = true;
            chartArea1.CursorX.IsUserSelectionEnabled = true;
            chartArea1.CursorX.SelectionColor = System.Drawing.Color.DeepSkyBlue;
            chartArea1.CursorY.IsUserEnabled = true;
            chartArea1.CursorY.IsUserSelectionEnabled = true;
            chartArea1.CursorY.SelectionColor = System.Drawing.Color.DeepSkyBlue;
            chartArea1.Name = "Phase";
            chartArea1.Position.Auto = false;
            chartArea1.Position.Height = 70F;
            chartArea1.Position.Width = 95F;
            chartArea1.Position.X = 2F;
            chartArea1.Position.Y = 10F;
            this.chartPhase.ChartAreas.Add(chartArea1);
            this.chartPhase.Location = new System.Drawing.Point(0, 25);
            this.chartPhase.Name = "chartPhase";
            this.chartPhase.Size = new System.Drawing.Size(584, 436);
            this.chartPhase.TabIndex = 0;
            this.chartPhase.Text = "Phase";
            this.chartPhase.Click += new System.EventHandler(this.chartPhase_Click);
            // 
            // tsPhaseSettings
            // 
            this.tsPhaseSettings.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.tsPhaseSettings.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tslblLineType,
            this.tscbLineType,
            this.tslblLineWidth,
            this.tscbLineWidth,
            this.toolStripSeparator1,
            this.tslblPointFreq,
            this.tscbPointFrequency});
            this.tsPhaseSettings.Location = new System.Drawing.Point(0, 0);
            this.tsPhaseSettings.Name = "tsPhaseSettings";
            this.tsPhaseSettings.Size = new System.Drawing.Size(584, 25);
            this.tsPhaseSettings.TabIndex = 1;
            this.tsPhaseSettings.Text = "tsPhaseSettings";
            // 
            // tslblLineType
            // 
            this.tslblLineType.Name = "tslblLineType";
            this.tslblLineType.Size = new System.Drawing.Size(63, 22);
            this.tslblLineType.Text = "Line Type";
            // 
            // tscbLineType
            // 
            this.tscbLineType.FlatStyle = System.Windows.Forms.FlatStyle.Standard;
            this.tscbLineType.Name = "tscbLineType";
            this.tscbLineType.Size = new System.Drawing.Size(90, 25);
            this.tscbLineType.Click += new System.EventHandler(this.tscbLineType_Click);
            // 
            // tslblLineWidth
            // 
            this.tslblLineWidth.Name = "tslblLineWidth";
            this.tslblLineWidth.Size = new System.Drawing.Size(69, 22);
            this.tslblLineWidth.Text = "Line Width";
            // 
            // tscbLineWidth
            // 
            this.tscbLineWidth.FlatStyle = System.Windows.Forms.FlatStyle.Standard;
            this.tscbLineWidth.Name = "tscbLineWidth";
            this.tscbLineWidth.Size = new System.Drawing.Size(75, 25);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // tslblPointFreq
            // 
            this.tslblPointFreq.Name = "tslblPointFreq";
            this.tslblPointFreq.Size = new System.Drawing.Size(100, 22);
            this.tslblPointFreq.Text = "Point Frequency";
            // 
            // tscbPointFrequency
            // 
            this.tscbPointFrequency.FlatStyle = System.Windows.Forms.FlatStyle.Standard;
            this.tscbPointFrequency.Name = "tscbPointFrequency";
            this.tscbPointFrequency.Size = new System.Drawing.Size(75, 25);
            // 
            // PhaseGraphForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 461);
            this.Controls.Add(this.chartPhase);
            this.Controls.Add(this.tsPhaseSettings);
            this.DockAreas = ((WeifenLuo.WinFormsUI.Docking.DockAreas)((((WeifenLuo.WinFormsUI.Docking.DockAreas.Float | WeifenLuo.WinFormsUI.Docking.DockAreas.DockTop) 
            | WeifenLuo.WinFormsUI.Docking.DockAreas.DockBottom) 
            | WeifenLuo.WinFormsUI.Docking.DockAreas.Document)));
            this.Font = new System.Drawing.Font("SimSun", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.HideOnClose = true;
            this.Name = "PhaseGraphForm";
            this.ShowIcon = false;
            this.Text = "Phase Graph";
            this.DockStateChanged += new System.EventHandler(this.PhaseGraphForm_DockStateChanged);
            this.Load += new System.EventHandler(this.PhaseGraphForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.chartPhase)).EndInit();
            this.tsPhaseSettings.ResumeLayout(false);
            this.tsPhaseSettings.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart chartPhase;
        private System.Windows.Forms.ToolStrip tsPhaseSettings;
        private System.Windows.Forms.ToolStripLabel tslblLineType;
        private System.Windows.Forms.ToolStripComboBox tscbLineType;
        private System.Windows.Forms.ToolStripLabel tslblLineWidth;
        private System.Windows.Forms.ToolStripComboBox tscbLineWidth;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripLabel tslblPointFreq;
        private System.Windows.Forms.ToolStripComboBox tscbPointFrequency;
    }
}