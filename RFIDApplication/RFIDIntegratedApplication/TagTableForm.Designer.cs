namespace RFIDIntegratedApplication
{
    partial class TagTableForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dgvTagTable = new System.Windows.Forms.DataGridView();
            this.colEPC = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAntenna = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colChannel = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colRSSI = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPhase = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDopplerShift = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTagDireciton = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTagCount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTagTable)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvTagTable
            // 
            this.dgvTagTable.AllowUserToAddRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.ActiveBorder;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("SimSun", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvTagTable.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvTagTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTagTable.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colEPC,
            this.colAntenna,
            this.colChannel,
            this.colRSSI,
            this.colPhase,
            this.colDopplerShift,
            this.colTagDireciton,
            this.colTagCount});
            this.dgvTagTable.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvTagTable.Location = new System.Drawing.Point(0, 0);
            this.dgvTagTable.Name = "dgvTagTable";
            this.dgvTagTable.RowTemplate.Height = 23;
            this.dgvTagTable.Size = new System.Drawing.Size(787, 189);
            this.dgvTagTable.TabIndex = 0;
            this.dgvTagTable.RowStateChanged += new System.Windows.Forms.DataGridViewRowStateChangedEventHandler(this.dgvTagTable_RowStateChanged);
            // 
            // colEPC
            // 
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.colEPC.DefaultCellStyle = dataGridViewCellStyle2;
            this.colEPC.HeaderText = "EPC";
            this.colEPC.Name = "colEPC";
            this.colEPC.ToolTipText = "EPC";
            this.colEPC.Width = 170;
            // 
            // colAntenna
            // 
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.colAntenna.DefaultCellStyle = dataGridViewCellStyle3;
            this.colAntenna.HeaderText = "Antenna";
            this.colAntenna.Name = "colAntenna";
            this.colAntenna.Width = 60;
            // 
            // colChannel
            // 
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.colChannel.DefaultCellStyle = dataGridViewCellStyle4;
            this.colChannel.HeaderText = "Channel";
            this.colChannel.Name = "colChannel";
            this.colChannel.Width = 60;
            // 
            // colRSSI
            // 
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.colRSSI.DefaultCellStyle = dataGridViewCellStyle5;
            this.colRSSI.HeaderText = "RSSI/dBm";
            this.colRSSI.Name = "colRSSI";
            this.colRSSI.Width = 70;
            // 
            // colPhase
            // 
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.colPhase.DefaultCellStyle = dataGridViewCellStyle6;
            this.colPhase.HeaderText = "Phase/rad";
            this.colPhase.Name = "colPhase";
            this.colPhase.Width = 70;
            // 
            // colDopplerShift
            // 
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.colDopplerShift.DefaultCellStyle = dataGridViewCellStyle7;
            this.colDopplerShift.HeaderText = "Doppler Shift/Hz";
            this.colDopplerShift.Name = "colDopplerShift";
            this.colDopplerShift.Width = 125;
            // 
            // colTagDireciton
            // 
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.colTagDireciton.DefaultCellStyle = dataGridViewCellStyle8;
            this.colTagDireciton.HeaderText = "Tag Direction";
            this.colTagDireciton.Name = "colTagDireciton";
            this.colTagDireciton.Width = 106;
            // 
            // colTagCount
            // 
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.colTagCount.DefaultCellStyle = dataGridViewCellStyle9;
            this.colTagCount.HeaderText = "Tag Count";
            this.colTagCount.Name = "colTagCount";
            this.colTagCount.Width = 82;
            // 
            // TagTableForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(787, 189);
            this.Controls.Add(this.dgvTagTable);
            this.DockAreas = ((WeifenLuo.WinFormsUI.Docking.DockAreas)((((WeifenLuo.WinFormsUI.Docking.DockAreas.Float | WeifenLuo.WinFormsUI.Docking.DockAreas.DockTop) 
            | WeifenLuo.WinFormsUI.Docking.DockAreas.DockBottom) 
            | WeifenLuo.WinFormsUI.Docking.DockAreas.Document)));
            this.Font = new System.Drawing.Font("SimSun", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.HideOnClose = true;
            this.Name = "TagTableForm";
            this.ShowIcon = false;
            this.Text = "Tag Table";
            this.DockStateChanged += new System.EventHandler(this.TagTableForm_DockStateChanged);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTagTable)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvTagTable;
        private System.Windows.Forms.DataGridViewTextBoxColumn colEPC;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAntenna;
        private System.Windows.Forms.DataGridViewTextBoxColumn colChannel;
        private System.Windows.Forms.DataGridViewTextBoxColumn colRSSI;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPhase;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDopplerShift;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTagDireciton;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTagCount;
    }
}