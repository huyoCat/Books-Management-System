﻿namespace Books_Management_System
{
    partial class AD_FormReaderList
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
            this.DGVReaderList = new System.Windows.Forms.DataGridView();
            this.Rid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Rpassword = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btReaderSearch = new System.Windows.Forms.Button();
            this.textBReaderSearch = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.DGVReaderList)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // DGVReaderList
            // 
            this.DGVReaderList.AllowUserToAddRows = false;
            this.DGVReaderList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DGVReaderList.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.DGVReaderList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGVReaderList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Rid,
            this.Rpassword});
            this.DGVReaderList.Location = new System.Drawing.Point(0, 81);
            this.DGVReaderList.Name = "DGVReaderList";
            this.DGVReaderList.RowTemplate.Height = 23;
            this.DGVReaderList.Size = new System.Drawing.Size(418, 334);
            this.DGVReaderList.TabIndex = 0;
            // 
            // Rid
            // 
            this.Rid.DataPropertyName = "Rid";
            this.Rid.HeaderText = "读者号";
            this.Rid.Name = "Rid";
            this.Rid.ReadOnly = true;
            // 
            // Rpassword
            // 
            this.Rpassword.DataPropertyName = "Rpassword";
            this.Rpassword.HeaderText = "密码";
            this.Rpassword.Name = "Rpassword";
            this.Rpassword.ReadOnly = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.AutoSize = true;
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.btReaderSearch);
            this.groupBox1.Controls.Add(this.textBReaderSearch);
            this.groupBox1.Location = new System.Drawing.Point(0, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(418, 63);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(29, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 12);
            this.label1.TabIndex = 4;
            this.label1.Text = "请输入读者号：";
            // 
            // btReaderSearch
            // 
            this.btReaderSearch.Location = new System.Drawing.Point(306, 16);
            this.btReaderSearch.Name = "btReaderSearch";
            this.btReaderSearch.Size = new System.Drawing.Size(65, 23);
            this.btReaderSearch.TabIndex = 3;
            this.btReaderSearch.Text = "查询";
            this.btReaderSearch.UseVisualStyleBackColor = true;
            this.btReaderSearch.Click += new System.EventHandler(this.btReaderSearch_Click);
            // 
            // textBReaderSearch
            // 
            this.textBReaderSearch.Location = new System.Drawing.Point(143, 18);
            this.textBReaderSearch.Name = "textBReaderSearch";
            this.textBReaderSearch.Size = new System.Drawing.Size(123, 21);
            this.textBReaderSearch.TabIndex = 2;
            // 
            // AD_FormReaderList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(418, 415);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.DGVReaderList);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MinimizeBox = false;
            this.Name = "AD_FormReaderList";
            this.Text = "读者列表";
            this.Load += new System.EventHandler(this.FormReaderList_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DGVReaderList)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView DGVReaderList;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btReaderSearch;
        private System.Windows.Forms.TextBox textBReaderSearch;
        private System.Windows.Forms.DataGridViewTextBoxColumn Rid;
        private System.Windows.Forms.DataGridViewTextBoxColumn Rpassword;
        private System.Windows.Forms.Label label1;
    }
}