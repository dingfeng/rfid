namespace BasicApplication
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
            this.listBoxHostAddress = new System.Windows.Forms.ListBox();
            this.dataSet = new System.Data.DataSet();
            this.TableHostAddress = new System.Data.DataTable();
            this.dcIP = new System.Data.DataColumn();
            this.dcInfotmation = new System.Data.DataColumn();
            this.btnConfirm = new System.Windows.Forms.Button();
            this.btnSearch = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TableHostAddress)).BeginInit();
            this.SuspendLayout();
            // 
            // listBoxHostAddress
            // 
            this.listBoxHostAddress.DataSource = this.dataSet;
            this.listBoxHostAddress.DisplayMember = "HostAddress.Infomation";
            this.listBoxHostAddress.FormattingEnabled = true;
            this.listBoxHostAddress.ItemHeight = 12;
            this.listBoxHostAddress.Location = new System.Drawing.Point(12, 12);
            this.listBoxHostAddress.Name = "listBoxHostAddress";
            this.listBoxHostAddress.ScrollAlwaysVisible = true;
            this.listBoxHostAddress.Size = new System.Drawing.Size(472, 160);
            this.listBoxHostAddress.TabIndex = 1;
            this.listBoxHostAddress.ValueMember = "TableHostAddress.IP";
            // 
            // dataSet
            // 
            this.dataSet.DataSetName = "Dataset";
            this.dataSet.Tables.AddRange(new System.Data.DataTable[] {
            this.TableHostAddress});
            // 
            // TableHostAddress
            // 
            this.TableHostAddress.CaseSensitive = true;
            this.TableHostAddress.Columns.AddRange(new System.Data.DataColumn[] {
            this.dcIP,
            this.dcInfotmation});
            this.TableHostAddress.Constraints.AddRange(new System.Data.Constraint[] {
            new System.Data.UniqueConstraint("Constraint1", new string[] {
                        "IP"}, true)});
            this.TableHostAddress.PrimaryKey = new System.Data.DataColumn[] {
        this.dcIP};
            this.TableHostAddress.TableName = "HostAddress";
            // 
            // dcIP
            // 
            this.dcIP.AllowDBNull = false;
            this.dcIP.ColumnName = "IP";
            this.dcIP.DefaultValue = "";
            this.dcIP.ReadOnly = true;
            // 
            // dcInfotmation
            // 
            this.dcInfotmation.AllowDBNull = false;
            this.dcInfotmation.ColumnName = "Infomation";
            this.dcInfotmation.DefaultValue = "";
            this.dcInfotmation.ReadOnly = true;
            // 
            // btnConfirm
            // 
            this.btnConfirm.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnConfirm.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnConfirm.Location = new System.Drawing.Point(251, 184);
            this.btnConfirm.Name = "btnConfirm";
            this.btnConfirm.Size = new System.Drawing.Size(230, 21);
            this.btnConfirm.TabIndex = 4;
            this.btnConfirm.Text = "Confirm";
            this.btnConfirm.UseVisualStyleBackColor = true;
            this.btnConfirm.Click += new System.EventHandler(this.btnConfirm_Click);
            // 
            // btnSearch
            // 
            this.btnSearch.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSearch.Location = new System.Drawing.Point(12, 184);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(225, 21);
            this.btnSearch.TabIndex = 3;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // SearchReaderIPForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(493, 217);
            this.Controls.Add(this.btnConfirm);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.listBoxHostAddress);
            this.Name = "SearchReaderIPForm";
            this.Text = "SearchReaderIPForm";
            this.Load += new System.EventHandler(this.SearchReaderIPForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TableHostAddress)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox listBoxHostAddress;
        private System.Windows.Forms.Button btnConfirm;
        private System.Windows.Forms.Button btnSearch;
        private System.Data.DataSet dataSet;
        private System.Data.DataTable TableHostAddress;
        private System.Data.DataColumn dcIP;
        private System.Data.DataColumn dcInfotmation;
    }
}