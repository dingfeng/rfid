namespace RFIDIntegratedApplication.Forms
{
    partial class SystemInfoForm
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
            this.readerTime = new System.Windows.Forms.Label();
            this.readerTimeValue = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // readerTime
            // 
            this.readerTime.AutoSize = true;
            this.readerTime.Location = new System.Drawing.Point(28, 29);
            this.readerTime.Name = "readerTime";
            this.readerTime.Size = new System.Drawing.Size(71, 12);
            this.readerTime.TabIndex = 0;
            this.readerTime.Text = "reader time";
            // 
            // readerTimeValue
            // 
            this.readerTimeValue.AutoSize = true;
            this.readerTimeValue.Location = new System.Drawing.Point(217, 29);
            this.readerTimeValue.Name = "readerTimeValue";
            this.readerTimeValue.Size = new System.Drawing.Size(0, 12);
            this.readerTimeValue.TabIndex = 1;
            this.readerTimeValue.Click += new System.EventHandler(this.label1_Click);
            // 
            // SystemInfoForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(428, 252);
            this.Controls.Add(this.readerTimeValue);
            this.Controls.Add(this.readerTime);
            this.Font = new System.Drawing.Font("SimSun", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Name = "SystemInfoForm";
            this.Text = "SystemInfoForm";
            this.Load += new System.EventHandler(this.SystemInfoForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label readerTime;
        private System.Windows.Forms.Label readerTimeValue;
    }
}