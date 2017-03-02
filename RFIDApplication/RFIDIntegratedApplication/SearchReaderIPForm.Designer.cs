namespace RFIDIntegratedApplication
{
    partial class SearchReaderIPForm
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
            this.tlpSearchReaerIp = new System.Windows.Forms.TableLayoutPanel();
            this.tlpSearchReaderIPButton = new System.Windows.Forms.TableLayoutPanel();
            this.btnSearch = new System.Windows.Forms.Button();
            this.btnConfirm = new System.Windows.Forms.Button();
            this.listBoxHostAddress = new System.Windows.Forms.ListBox();
            this.tlpSearchReaerIp.SuspendLayout();
            this.tlpSearchReaderIPButton.SuspendLayout();
            this.SuspendLayout();
            // 
            // tlpSearchReaerIp
            // 
            this.tlpSearchReaerIp.ColumnCount = 1;
            this.tlpSearchReaerIp.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpSearchReaerIp.Controls.Add(this.listBoxHostAddress, 0, 0);
            this.tlpSearchReaerIp.Controls.Add(this.tlpSearchReaderIPButton, 0, 1);
            this.tlpSearchReaerIp.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpSearchReaerIp.Location = new System.Drawing.Point(0, 0);
            this.tlpSearchReaerIp.Name = "tlpSearchReaerIp";
            this.tlpSearchReaerIp.RowCount = 2;
            this.tlpSearchReaerIp.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 86.23482F));
            this.tlpSearchReaerIp.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 13.76518F));
            this.tlpSearchReaerIp.Size = new System.Drawing.Size(546, 247);
            this.tlpSearchReaerIp.TabIndex = 0;
            // 
            // tlpSearchReaderIPButton
            // 
            this.tlpSearchReaderIPButton.ColumnCount = 2;
            this.tlpSearchReaderIPButton.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpSearchReaderIPButton.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpSearchReaderIPButton.Controls.Add(this.btnSearch, 0, 0);
            this.tlpSearchReaderIPButton.Controls.Add(this.btnConfirm, 1, 0);
            this.tlpSearchReaderIPButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpSearchReaderIPButton.Location = new System.Drawing.Point(3, 215);
            this.tlpSearchReaderIPButton.Name = "tlpSearchReaderIPButton";
            this.tlpSearchReaderIPButton.RowCount = 1;
            this.tlpSearchReaderIPButton.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpSearchReaderIPButton.Size = new System.Drawing.Size(540, 29);
            this.tlpSearchReaderIPButton.TabIndex = 0;
            // 
            // btnSearch
            // 
            this.btnSearch.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnSearch.Location = new System.Drawing.Point(3, 3);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(264, 23);
            this.btnSearch.TabIndex = 0;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            // 
            // btnConfirm
            // 
            this.btnConfirm.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnConfirm.Location = new System.Drawing.Point(273, 3);
            this.btnConfirm.Name = "btnConfirm";
            this.btnConfirm.Size = new System.Drawing.Size(264, 23);
            this.btnConfirm.TabIndex = 1;
            this.btnConfirm.Text = "Confirm";
            this.btnConfirm.UseVisualStyleBackColor = true;
            // 
            // listBoxHostAddress
            // 
            this.listBoxHostAddress.DisplayMember = "HostAddress.Infomation";
            this.listBoxHostAddress.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listBoxHostAddress.FormattingEnabled = true;
            this.listBoxHostAddress.ItemHeight = 12;
            this.listBoxHostAddress.Location = new System.Drawing.Point(3, 3);
            this.listBoxHostAddress.Name = "listBoxHostAddress";
            this.listBoxHostAddress.ScrollAlwaysVisible = true;
            this.listBoxHostAddress.Size = new System.Drawing.Size(540, 206);
            this.listBoxHostAddress.TabIndex = 2;
            this.listBoxHostAddress.ValueMember = "TableHostAddress.IP";
            // 
            // SearchReaderIPForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(546, 247);
            this.Controls.Add(this.tlpSearchReaerIp);
            this.Name = "SearchReaderIPForm";
            this.ShowIcon = false;
            this.Text = "Search Reader IP";
            this.tlpSearchReaerIp.ResumeLayout(false);
            this.tlpSearchReaderIPButton.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tlpSearchReaerIp;
        private System.Windows.Forms.TableLayoutPanel tlpSearchReaderIPButton;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Button btnConfirm;
        private System.Windows.Forms.ListBox listBoxHostAddress;
    }
}