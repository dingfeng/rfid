namespace RFIDIntegratedApplication.HolographicsForms
{
    partial class SearchRegionForm
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
            this.tbxSRXInterval = new System.Windows.Forms.TextBox();
            this.tbxSRXEnd = new System.Windows.Forms.TextBox();
            this.labelSRStartPoint = new System.Windows.Forms.Label();
            this.lblSRX = new System.Windows.Forms.Label();
            this.tbxSRYStart = new System.Windows.Forms.TextBox();
            this.lblSRY = new System.Windows.Forms.Label();
            this.tbxSRZEnd = new System.Windows.Forms.TextBox();
            this.tbxSRYInterval = new System.Windows.Forms.TextBox();
            this.lblSRZ = new System.Windows.Forms.Label();
            this.tbxSRZInterval = new System.Windows.Forms.TextBox();
            this.tbxSRXStart = new System.Windows.Forms.TextBox();
            this.tbxSRZStart = new System.Windows.Forms.TextBox();
            this.tbxSRYEnd = new System.Windows.Forms.TextBox();
            this.lblSRInterval = new System.Windows.Forms.Label();
            this.lblSREndPoint = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // tbxSRXInterval
            // 
            this.tbxSRXInterval.Location = new System.Drawing.Point(119, 69);
            this.tbxSRXInterval.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tbxSRXInterval.Name = "tbxSRXInterval";
            this.tbxSRXInterval.Size = new System.Drawing.Size(80, 21);
            this.tbxSRXInterval.TabIndex = 1;
            this.tbxSRXInterval.Text = "0.1";
            this.tbxSRXInterval.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tbxSRXInterval.TextChanged += new System.EventHandler(this.tbxSRXInterval_TextChanged);
            // 
            // tbxSRXEnd
            // 
            this.tbxSRXEnd.Location = new System.Drawing.Point(119, 102);
            this.tbxSRXEnd.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tbxSRXEnd.Name = "tbxSRXEnd";
            this.tbxSRXEnd.Size = new System.Drawing.Size(80, 21);
            this.tbxSRXEnd.TabIndex = 2;
            this.tbxSRXEnd.Text = "2";
            this.tbxSRXEnd.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tbxSRXEnd.TextChanged += new System.EventHandler(this.tbxSRXEnd_TextChanged);
            // 
            // labelSRStartPoint
            // 
            this.labelSRStartPoint.AutoSize = true;
            this.labelSRStartPoint.Location = new System.Drawing.Point(13, 39);
            this.labelSRStartPoint.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelSRStartPoint.Name = "labelSRStartPoint";
            this.labelSRStartPoint.Size = new System.Drawing.Size(71, 12);
            this.labelSRStartPoint.TabIndex = 8;
            this.labelSRStartPoint.Text = "Start Point";
            this.labelSRStartPoint.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblSRX
            // 
            this.lblSRX.AutoSize = true;
            this.lblSRX.Location = new System.Drawing.Point(132, 11);
            this.lblSRX.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblSRX.Name = "lblSRX";
            this.lblSRX.Size = new System.Drawing.Size(35, 12);
            this.lblSRX.TabIndex = 6;
            this.lblSRX.Text = "X (m)";
            this.lblSRX.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tbxSRYStart
            // 
            this.tbxSRYStart.Location = new System.Drawing.Point(208, 35);
            this.tbxSRYStart.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tbxSRYStart.Name = "tbxSRYStart";
            this.tbxSRYStart.Size = new System.Drawing.Size(76, 21);
            this.tbxSRYStart.TabIndex = 3;
            this.tbxSRYStart.Text = "0";
            this.tbxSRYStart.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lblSRY
            // 
            this.lblSRY.AutoSize = true;
            this.lblSRY.Location = new System.Drawing.Point(221, 11);
            this.lblSRY.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblSRY.Name = "lblSRY";
            this.lblSRY.Size = new System.Drawing.Size(35, 12);
            this.lblSRY.TabIndex = 7;
            this.lblSRY.Tag = " ";
            this.lblSRY.Text = "Y (m)";
            this.lblSRY.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tbxSRZEnd
            // 
            this.tbxSRZEnd.Location = new System.Drawing.Point(293, 102);
            this.tbxSRZEnd.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tbxSRZEnd.Name = "tbxSRZEnd";
            this.tbxSRZEnd.Size = new System.Drawing.Size(77, 21);
            this.tbxSRZEnd.TabIndex = 13;
            this.tbxSRZEnd.Text = "2";
            this.tbxSRZEnd.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tbxSRZEnd.TextChanged += new System.EventHandler(this.tbxSRZEnd_TextChanged);
            // 
            // tbxSRYInterval
            // 
            this.tbxSRYInterval.Location = new System.Drawing.Point(208, 69);
            this.tbxSRYInterval.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tbxSRYInterval.Name = "tbxSRYInterval";
            this.tbxSRYInterval.Size = new System.Drawing.Size(76, 21);
            this.tbxSRYInterval.TabIndex = 4;
            this.tbxSRYInterval.Text = "0.1";
            this.tbxSRYInterval.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tbxSRYInterval.TextChanged += new System.EventHandler(this.tbxSRYInterval_TextChanged);
            // 
            // lblSRZ
            // 
            this.lblSRZ.AutoSize = true;
            this.lblSRZ.Location = new System.Drawing.Point(307, 11);
            this.lblSRZ.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblSRZ.Name = "lblSRZ";
            this.lblSRZ.Size = new System.Drawing.Size(35, 12);
            this.lblSRZ.TabIndex = 14;
            this.lblSRZ.Text = "Z (m)";
            this.lblSRZ.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tbxSRZInterval
            // 
            this.tbxSRZInterval.Location = new System.Drawing.Point(293, 69);
            this.tbxSRZInterval.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tbxSRZInterval.Name = "tbxSRZInterval";
            this.tbxSRZInterval.Size = new System.Drawing.Size(77, 21);
            this.tbxSRZInterval.TabIndex = 12;
            this.tbxSRZInterval.Text = "0.1";
            this.tbxSRZInterval.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tbxSRZInterval.TextChanged += new System.EventHandler(this.tbxSRZInterval_TextChanged);
            // 
            // tbxSRXStart
            // 
            this.tbxSRXStart.Location = new System.Drawing.Point(119, 35);
            this.tbxSRXStart.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tbxSRXStart.Name = "tbxSRXStart";
            this.tbxSRXStart.Size = new System.Drawing.Size(80, 21);
            this.tbxSRXStart.TabIndex = 0;
            this.tbxSRXStart.Text = "0";
            this.tbxSRXStart.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tbxSRXStart.TextChanged += new System.EventHandler(this.tbxSRXStart_TextChanged);
            // 
            // tbxSRZStart
            // 
            this.tbxSRZStart.Location = new System.Drawing.Point(293, 35);
            this.tbxSRZStart.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tbxSRZStart.Name = "tbxSRZStart";
            this.tbxSRZStart.Size = new System.Drawing.Size(77, 21);
            this.tbxSRZStart.TabIndex = 11;
            this.tbxSRZStart.Text = "0";
            this.tbxSRZStart.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tbxSRZStart.TextChanged += new System.EventHandler(this.tbxSRZStart_TextChanged);
            // 
            // tbxSRYEnd
            // 
            this.tbxSRYEnd.Location = new System.Drawing.Point(208, 102);
            this.tbxSRYEnd.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tbxSRYEnd.Name = "tbxSRYEnd";
            this.tbxSRYEnd.Size = new System.Drawing.Size(76, 21);
            this.tbxSRYEnd.TabIndex = 5;
            this.tbxSRYEnd.Text = "2";
            this.tbxSRYEnd.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lblSRInterval
            // 
            this.lblSRInterval.AutoSize = true;
            this.lblSRInterval.Location = new System.Drawing.Point(25, 72);
            this.lblSRInterval.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblSRInterval.Name = "lblSRInterval";
            this.lblSRInterval.Size = new System.Drawing.Size(53, 12);
            this.lblSRInterval.TabIndex = 10;
            this.lblSRInterval.Text = "Interval";
            this.lblSRInterval.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblSREndPoint
            // 
            this.lblSREndPoint.AutoSize = true;
            this.lblSREndPoint.Location = new System.Drawing.Point(13, 106);
            this.lblSREndPoint.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblSREndPoint.Name = "lblSREndPoint";
            this.lblSREndPoint.Size = new System.Drawing.Size(59, 12);
            this.lblSREndPoint.TabIndex = 9;
            this.lblSREndPoint.Text = "End Point";
            this.lblSREndPoint.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // SearchRegionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(398, 157);
            this.Controls.Add(this.lblSREndPoint);
            this.Controls.Add(this.lblSRInterval);
            this.Controls.Add(this.tbxSRYEnd);
            this.Controls.Add(this.tbxSRXInterval);
            this.Controls.Add(this.tbxSRZStart);
            this.Controls.Add(this.tbxSRXEnd);
            this.Controls.Add(this.tbxSRXStart);
            this.Controls.Add(this.labelSRStartPoint);
            this.Controls.Add(this.tbxSRZInterval);
            this.Controls.Add(this.lblSRX);
            this.Controls.Add(this.lblSRZ);
            this.Controls.Add(this.tbxSRYStart);
            this.Controls.Add(this.tbxSRYInterval);
            this.Controls.Add(this.lblSRY);
            this.Controls.Add(this.tbxSRZEnd);
            this.DockAreas = ((WeifenLuo.WinFormsUI.Docking.DockAreas)(((((WeifenLuo.WinFormsUI.Docking.DockAreas.Float | WeifenLuo.WinFormsUI.Docking.DockAreas.DockLeft) 
            | WeifenLuo.WinFormsUI.Docking.DockAreas.DockRight) 
            | WeifenLuo.WinFormsUI.Docking.DockAreas.DockTop) 
            | WeifenLuo.WinFormsUI.Docking.DockAreas.DockBottom)));
            this.Font = new System.Drawing.Font("SimSun", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.HideOnClose = true;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "SearchRegionForm";
            this.ShowIcon = false;
            this.Text = "SearchRegion";
            this.DockStateChanged += new System.EventHandler(this.SearchRegionForm_DockStateChanged);
            this.Load += new System.EventHandler(this.SearchRegionForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbxSRXInterval;
        private System.Windows.Forms.TextBox tbxSRXEnd;
        private System.Windows.Forms.Label labelSRStartPoint;
        private System.Windows.Forms.Label lblSRX;
        private System.Windows.Forms.TextBox tbxSRYStart;
        private System.Windows.Forms.Label lblSRY;
        private System.Windows.Forms.TextBox tbxSRZEnd;
        private System.Windows.Forms.TextBox tbxSRYInterval;
        private System.Windows.Forms.Label lblSRZ;
        private System.Windows.Forms.TextBox tbxSRZInterval;
        private System.Windows.Forms.TextBox tbxSRXStart;
        private System.Windows.Forms.TextBox tbxSRZStart;
        private System.Windows.Forms.TextBox tbxSRYEnd;
        private System.Windows.Forms.Label lblSRInterval;
        private System.Windows.Forms.Label lblSREndPoint;
    }
}