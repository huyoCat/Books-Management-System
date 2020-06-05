namespace Books_Management_System
{
    partial class AD_FormLendBook
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.bt_DelAll = new System.Windows.Forms.Button();
            this.BT_searchLendBook = new System.Windows.Forms.Button();
            this.textBox_SearchLendBook = new System.Windows.Forms.TextBox();
            this.CBLendBookList = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.DGVLendBookList = new System.Windows.Forms.DataGridView();
            this.Bid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Bname = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Bwriter = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Bpublisher = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Bsort = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Bout = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Bback = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Rid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColDel = new System.Windows.Forms.DataGridViewLinkColumn();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGVLendBookList)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.bt_DelAll);
            this.groupBox1.Controls.Add(this.BT_searchLendBook);
            this.groupBox1.Controls.Add(this.textBox_SearchLendBook);
            this.groupBox1.Controls.Add(this.CBLendBookList);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(843, 56);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // bt_DelAll
            // 
            this.bt_DelAll.Location = new System.Drawing.Point(726, 14);
            this.bt_DelAll.Name = "bt_DelAll";
            this.bt_DelAll.Size = new System.Drawing.Size(75, 23);
            this.bt_DelAll.TabIndex = 4;
            this.bt_DelAll.Text = "批量删除";
            this.bt_DelAll.UseVisualStyleBackColor = true;
            this.bt_DelAll.Click += new System.EventHandler(this.bt_DelAll_Click);
            // 
            // BT_searchLendBook
            // 
            this.BT_searchLendBook.Location = new System.Drawing.Point(601, 14);
            this.BT_searchLendBook.Name = "BT_searchLendBook";
            this.BT_searchLendBook.Size = new System.Drawing.Size(75, 23);
            this.BT_searchLendBook.TabIndex = 3;
            this.BT_searchLendBook.Text = "查询";
            this.BT_searchLendBook.UseVisualStyleBackColor = true;
            this.BT_searchLendBook.Click += new System.EventHandler(this.BT_searchLendBook_Click);
            // 
            // textBox_SearchLendBook
            // 
            this.textBox_SearchLendBook.Location = new System.Drawing.Point(328, 14);
            this.textBox_SearchLendBook.Name = "textBox_SearchLendBook";
            this.textBox_SearchLendBook.Size = new System.Drawing.Size(230, 21);
            this.textBox_SearchLendBook.TabIndex = 2;
            // 
            // CBLendBookList
            // 
            this.CBLendBookList.FormattingEnabled = true;
            this.CBLendBookList.Location = new System.Drawing.Point(95, 14);
            this.CBLendBookList.Name = "CBLendBookList";
            this.CBLendBookList.Size = new System.Drawing.Size(177, 20);
            this.CBLendBookList.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(23, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "查询方式";
            // 
            // DGVLendBookList
            // 
            this.DGVLendBookList.AllowUserToAddRows = false;
            this.DGVLendBookList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DGVLendBookList.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.DGVLendBookList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGVLendBookList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Bid,
            this.Bname,
            this.Bwriter,
            this.Bpublisher,
            this.Bsort,
            this.Bout,
            this.Bback,
            this.Rid,
            this.ColDel});
            this.DGVLendBookList.Location = new System.Drawing.Point(12, 74);
            this.DGVLendBookList.Name = "DGVLendBookList";
            this.DGVLendBookList.RowTemplate.Height = 23;
            this.DGVLendBookList.Size = new System.Drawing.Size(843, 327);
            this.DGVLendBookList.TabIndex = 2;
            this.DGVLendBookList.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DGVLendBookList_CellContentClick);
            // 
            // Bid
            // 
            this.Bid.DataPropertyName = "Bid";
            this.Bid.HeaderText = "书号";
            this.Bid.Name = "Bid";
            this.Bid.ReadOnly = true;
            // 
            // Bname
            // 
            this.Bname.DataPropertyName = "Bname";
            this.Bname.HeaderText = "书名";
            this.Bname.Name = "Bname";
            this.Bname.ReadOnly = true;
            // 
            // Bwriter
            // 
            this.Bwriter.DataPropertyName = "Bwriter";
            this.Bwriter.HeaderText = "作者";
            this.Bwriter.Name = "Bwriter";
            this.Bwriter.ReadOnly = true;
            // 
            // Bpublisher
            // 
            this.Bpublisher.DataPropertyName = "Bpublisher";
            this.Bpublisher.HeaderText = "出版社";
            this.Bpublisher.Name = "Bpublisher";
            this.Bpublisher.ReadOnly = true;
            // 
            // Bsort
            // 
            this.Bsort.DataPropertyName = "Bsort";
            this.Bsort.HeaderText = "种类";
            this.Bsort.Name = "Bsort";
            this.Bsort.ReadOnly = true;
            // 
            // Bout
            // 
            this.Bout.DataPropertyName = "Bout";
            this.Bout.HeaderText = "借出时间";
            this.Bout.Name = "Bout";
            this.Bout.ReadOnly = true;
            // 
            // Bback
            // 
            this.Bback.DataPropertyName = "Bback";
            this.Bback.HeaderText = "归还时间";
            this.Bback.Name = "Bback";
            this.Bback.ReadOnly = true;
            // 
            // Rid
            // 
            this.Rid.DataPropertyName = "Rid";
            this.Rid.HeaderText = "读者号";
            this.Rid.Name = "Rid";
            this.Rid.ReadOnly = true;
            // 
            // ColDel
            // 
            dataGridViewCellStyle1.NullValue = "删除";
            this.ColDel.DefaultCellStyle = dataGridViewCellStyle1;
            this.ColDel.HeaderText = "删除";
            this.ColDel.Name = "ColDel";
            // 
            // AD_FormLendBook
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(867, 413);
            this.Controls.Add(this.DGVLendBookList);
            this.Controls.Add(this.groupBox1);
            this.Name = "AD_FormLendBook";
            this.Text = "外借图书列表";
            this.Load += new System.EventHandler(this.AD_FormLendBook_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGVLendBookList)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button BT_searchLendBook;
        private System.Windows.Forms.TextBox textBox_SearchLendBook;
        private System.Windows.Forms.ComboBox CBLendBookList;
        private System.Windows.Forms.Label label1;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.DataGridView DGVLendBookList;
        private System.Windows.Forms.Button bt_DelAll;
        private System.Windows.Forms.DataGridViewTextBoxColumn Bid;
        private System.Windows.Forms.DataGridViewTextBoxColumn Bname;
        private System.Windows.Forms.DataGridViewTextBoxColumn Bwriter;
        private System.Windows.Forms.DataGridViewTextBoxColumn Bpublisher;
        private System.Windows.Forms.DataGridViewTextBoxColumn Bsort;
        private System.Windows.Forms.DataGridViewTextBoxColumn Bout;
        private System.Windows.Forms.DataGridViewTextBoxColumn Bback;
        private System.Windows.Forms.DataGridViewTextBoxColumn Rid;
        private System.Windows.Forms.DataGridViewLinkColumn ColDel;
    }
}