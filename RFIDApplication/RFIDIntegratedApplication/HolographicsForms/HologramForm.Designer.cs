namespace RFIDIntegratedApplication.HolographicsForms
{
    partial class HologramForm
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
            this.tsHologram = new System.Windows.Forms.ToolStrip();
            this.tslblRefreshInterval = new System.Windows.Forms.ToolStripLabel();
            this.tstbxRefreshInterval = new System.Windows.Forms.ToolStripTextBox();
            this.tslblTagEPCForHologram = new System.Windows.Forms.ToolStripLabel();
            this.tscbTagEPCForHologram = new System.Windows.Forms.ToolStripComboBox();
            this.tlpHologram = new System.Windows.Forms.TableLayoutPanel();
            this.pbHeatMap = new System.Windows.Forms.PictureBox();
            this.tsHologram.SuspendLayout();
            this.tlpHologram.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbHeatMap)).BeginInit();
            this.SuspendLayout();
            // 
            // tsHologram
            // 
            this.tsHologram.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.tsHologram.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tslblRefreshInterval,
            this.tstbxRefreshInterval,
            this.tslblTagEPCForHologram,
            this.tscbTagEPCForHologram});
            this.tsHologram.Location = new System.Drawing.Point(0, 0);
            this.tsHologram.Name = "tsHologram";
            this.tsHologram.Size = new System.Drawing.Size(1092, 28);
            this.tsHologram.TabIndex = 0;
            this.tsHologram.Text = "Hologram";
            // 
            // tslblRefreshInterval
            // 
            this.tslblRefreshInterval.Name = "tslblRefreshInterval";
            this.tslblRefreshInterval.Size = new System.Drawing.Size(143, 25);
            this.tslblRefreshInterval.Text = "Refresh Interval (s)";
            this.tslblRefreshInterval.Click += new System.EventHandler(this.tslblRefreshInterval_Click);
            // 
            // tstbxRefreshInterval
            // 
            this.tstbxRefreshInterval.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tstbxRefreshInterval.Name = "tstbxRefreshInterval";
            this.tstbxRefreshInterval.Size = new System.Drawing.Size(66, 28);
            this.tstbxRefreshInterval.Text = "1";
            this.tstbxRefreshInterval.TextBoxTextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // tslblTagEPCForHologram
            // 
            this.tslblTagEPCForHologram.Name = "tslblTagEPCForHologram";
            this.tslblTagEPCForHologram.Size = new System.Drawing.Size(173, 25);
            this.tslblTagEPCForHologram.Text = "Tag EPC For Hologram";
            this.tslblTagEPCForHologram.Click += new System.EventHandler(this.tslblTagEPCForHologram_Click);
            // 
            // tscbTagEPCForHologram
            // 
            this.tscbTagEPCForHologram.FlatStyle = System.Windows.Forms.FlatStyle.Standard;
            this.tscbTagEPCForHologram.Name = "tscbTagEPCForHologram";
            this.tscbTagEPCForHologram.Size = new System.Drawing.Size(212, 28);
            // 
            // tlpHologram
            // 
            this.tlpHologram.ColumnCount = 1;
            this.tlpHologram.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpHologram.Controls.Add(this.pbHeatMap, 0, 0);
            this.tlpHologram.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpHologram.Location = new System.Drawing.Point(0, 28);
            this.tlpHologram.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tlpHologram.Name = "tlpHologram";
            this.tlpHologram.RowCount = 1;
            this.tlpHologram.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpHologram.Size = new System.Drawing.Size(1092, 1021);
            this.tlpHologram.TabIndex = 1;
            // 
            // pbHeatMap
            // 
            this.pbHeatMap.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pbHeatMap.Location = new System.Drawing.Point(6, 5);
            this.pbHeatMap.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pbHeatMap.Name = "pbHeatMap";
            this.pbHeatMap.Size = new System.Drawing.Size(1080, 1010);
            this.pbHeatMap.TabIndex = 2;
            this.pbHeatMap.TabStop = false;
            // 
            // HologramForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1092, 1049);
            this.Controls.Add(this.tlpHologram);
            this.Controls.Add(this.tsHologram);
            this.DockAreas = ((WeifenLuo.WinFormsUI.Docking.DockAreas)((((WeifenLuo.WinFormsUI.Docking.DockAreas.Float | WeifenLuo.WinFormsUI.Docking.DockAreas.DockTop) 
            | WeifenLuo.WinFormsUI.Docking.DockAreas.DockBottom) 
            | WeifenLuo.WinFormsUI.Docking.DockAreas.Document)));
            this.Font = new System.Drawing.Font("SimSun", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.HideOnClose = true;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "HologramForm";
            this.ShowIcon = false;
            this.Text = "HologramForm";
            this.DockStateChanged += new System.EventHandler(this.HologramForm_DockStateChanged);
            this.tsHologram.ResumeLayout(false);
            this.tsHologram.PerformLayout();
            this.tlpHologram.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbHeatMap)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip tsHologram;
        private System.Windows.Forms.ToolStripLabel tslblRefreshInterval;
        private System.Windows.Forms.ToolStripTextBox tstbxRefreshInterval;
        private System.Windows.Forms.ToolStripLabel tslblTagEPCForHologram;
        private System.Windows.Forms.ToolStripComboBox tscbTagEPCForHologram;
        private System.Windows.Forms.TableLayoutPanel tlpHologram;
        private System.Windows.Forms.PictureBox pbHeatMap;
    }
}