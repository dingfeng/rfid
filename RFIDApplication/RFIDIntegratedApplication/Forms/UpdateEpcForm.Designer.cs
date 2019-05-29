namespace RFIDIntegratedApplication.Forms
{
    partial class UpdateEpcForm
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
            this.CurrentEpcTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.newEpcTextBox = new System.Windows.Forms.TextBox();
            this.saveButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // CurrentEpcTextBox
            // 
            this.CurrentEpcTextBox.Location = new System.Drawing.Point(177, 24);
            this.CurrentEpcTextBox.Name = "CurrentEpcTextBox";
            this.CurrentEpcTextBox.Size = new System.Drawing.Size(243, 21);
            this.CurrentEpcTextBox.TabIndex = 0;
            this.CurrentEpcTextBox.TextChanged += new System.EventHandler(this.CurrentEpcTextBox_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("SimSun", 9F);
            this.label1.Location = new System.Drawing.Point(72, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "current epc";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("SimSun", 9F);
            this.label2.Location = new System.Drawing.Point(96, 92);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "new epc";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // newEpcTextBox
            // 
            this.newEpcTextBox.Location = new System.Drawing.Point(177, 89);
            this.newEpcTextBox.Name = "newEpcTextBox";
            this.newEpcTextBox.Size = new System.Drawing.Size(243, 21);
            this.newEpcTextBox.TabIndex = 3;
            this.newEpcTextBox.TextChanged += new System.EventHandler(this.newEpcTextBox_TextChanged);
            // 
            // saveButton
            // 
            this.saveButton.Location = new System.Drawing.Point(177, 167);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(90, 25);
            this.saveButton.TabIndex = 4;
            this.saveButton.Text = "save";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // cancelButton
            // 
            this.cancelButton.Location = new System.Drawing.Point(330, 167);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(90, 25);
            this.cancelButton.TabIndex = 5;
            this.cancelButton.Text = "cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click_1);
            // 
            // UpdateEpcForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(588, 232);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.newEpcTextBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.CurrentEpcTextBox);
            this.Font = new System.Drawing.Font("SimSun", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Name = "UpdateEpcForm";
            this.Text = "UpdateEpcForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox CurrentEpcTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox newEpcTextBox;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.Button cancelButton;
    }
}