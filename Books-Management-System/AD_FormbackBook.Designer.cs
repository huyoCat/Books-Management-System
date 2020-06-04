﻿namespace Books_Management_System
{
    partial class AD_FormbackBook
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.groupBox_searchCondition = new System.Windows.Forms.GroupBox();
            this.button_search = new System.Windows.Forms.Button();
            this.label_keyWord = new System.Windows.Forms.Label();
            this.textBox_keyWord = new System.Windows.Forms.TextBox();
            this.comboBox_searchWay = new System.Windows.Forms.ComboBox();
            this.label_Sway = new System.Windows.Forms.Label();
            this.DGVBookList = new System.Windows.Forms.DataGridView();
            this.Bid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Bname = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Bwriter = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Bpublisher = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Bsort = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Bsum = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Bremainder = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Bout = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Bback = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Rid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.outBook = new System.Windows.Forms.DataGridViewLinkColumn();
            this.groupBox_searchCondition.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGVBookList)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox_searchCondition
            // 
            this.groupBox_searchCondition.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox_searchCondition.Controls.Add(this.button_search);
            this.groupBox_searchCondition.Controls.Add(this.label_keyWord);
            this.groupBox_searchCondition.Controls.Add(this.textBox_keyWord);
            this.groupBox_searchCondition.Controls.Add(this.comboBox_searchWay);
            this.groupBox_searchCondition.Controls.Add(this.label_Sway);
            this.groupBox_searchCondition.Location = new System.Drawing.Point(12, 7);
            this.groupBox_searchCondition.Name = "groupBox_searchCondition";
            this.groupBox_searchCondition.Size = new System.Drawing.Size(743, 72);
            this.groupBox_searchCondition.TabIndex = 2;
            this.groupBox_searchCondition.TabStop = false;
            this.groupBox_searchCondition.Text = "查询条件";
            // 
            // button_search
            // 
            this.button_search.Location = new System.Drawing.Point(660, 33);
            this.button_search.Name = "button_search";
            this.button_search.Size = new System.Drawing.Size(75, 23);
            this.button_search.TabIndex = 4;
            this.button_search.Text = "查询";
            this.button_search.UseVisualStyleBackColor = true;
            this.button_search.Click += new System.EventHandler(this.button_search_Click);
            // 
            // label_keyWord
            // 
            this.label_keyWord.AutoSize = true;
            this.label_keyWord.Location = new System.Drawing.Point(261, 33);
            this.label_keyWord.Name = "label_keyWord";
            this.label_keyWord.Size = new System.Drawing.Size(77, 12);
            this.label_keyWord.TabIndex = 3;
            this.label_keyWord.Text = "请输入关键字";
            // 
            // textBox_keyWord
            // 
            this.textBox_keyWord.Location = new System.Drawing.Point(362, 33);
            this.textBox_keyWord.Name = "textBox_keyWord";
            this.textBox_keyWord.Size = new System.Drawing.Size(263, 21);
            this.textBox_keyWord.TabIndex = 2;
            // 
            // comboBox_searchWay
            // 
            this.comboBox_searchWay.FormattingEnabled = true;
            this.comboBox_searchWay.Location = new System.Drawing.Point(90, 33);
            this.comboBox_searchWay.Name = "comboBox_searchWay";
            this.comboBox_searchWay.Size = new System.Drawing.Size(121, 20);
            this.comboBox_searchWay.TabIndex = 1;
            // 
            // label_Sway
            // 
            this.label_Sway.AutoSize = true;
            this.label_Sway.Location = new System.Drawing.Point(17, 36);
            this.label_Sway.Name = "label_Sway";
            this.label_Sway.Size = new System.Drawing.Size(53, 12);
            this.label_Sway.TabIndex = 0;
            this.label_Sway.Text = "查询方式";
            // 
            // DGVBookList
            // 
            this.DGVBookList.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DGVBookList.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.DGVBookList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGVBookList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Bid,
            this.Bname,
            this.Bwriter,
            this.Bpublisher,
            this.Bsort,
            this.Bsum,
            this.Bremainder,
            this.Bout,
            this.Bback,
            this.Rid,
            this.outBook});
            this.DGVBookList.Location = new System.Drawing.Point(1, 85);
            this.DGVBookList.Name = "DGVBookList";
            this.DGVBookList.RowTemplate.Height = 23;
            this.DGVBookList.Size = new System.Drawing.Size(766, 274);
            this.DGVBookList.TabIndex = 3;
            this.DGVBookList.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DGVBookList_CellContentClick);
            // 
            // Bid
            // 
            this.Bid.DataPropertyName = "Bid";
            this.Bid.HeaderText = "书号";
            this.Bid.Name = "Bid";
            this.Bid.ReadOnly = true;
            this.Bid.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Bid.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
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
            // Bsum
            // 
            this.Bsum.DataPropertyName = "Bsum";
            this.Bsum.HeaderText = "总数";
            this.Bsum.Name = "Bsum";
            this.Bsum.ReadOnly = true;
            // 
            // Bremainder
            // 
            this.Bremainder.DataPropertyName = "Bremainder";
            this.Bremainder.HeaderText = "在馆数量";
            this.Bremainder.Name = "Bremainder";
            this.Bremainder.ReadOnly = true;
            // 
            // Bout
            // 
            this.Bout.DataPropertyName = "Bout";
            this.Bout.HeaderText = "借出日期";
            this.Bout.Name = "Bout";
            this.Bout.ReadOnly = true;
            // 
            // Bback
            // 
            this.Bback.DataPropertyName = "Bback";
            this.Bback.HeaderText = "归还日期";
            this.Bback.Name = "Bback";
            this.Bback.ReadOnly = true;
            // 
            // Rid
            // 
            this.Rid.DataPropertyName = "Rid";
            this.Rid.HeaderText = "借阅读者";
            this.Rid.Name = "Rid";
            this.Rid.ReadOnly = true;
            // 
            // outBook
            // 
            dataGridViewCellStyle2.NullValue = "办理归还";
            this.outBook.DefaultCellStyle = dataGridViewCellStyle2;
            this.outBook.HeaderText = "办理归还";
            this.outBook.Name = "outBook";
            // 
            // AD_FormbackBook
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(767, 360);
            this.Controls.Add(this.DGVBookList);
            this.Controls.Add(this.groupBox_searchCondition);
            this.Name = "AD_FormbackBook";
            this.Text = "还书";
            this.Load += new System.EventHandler(this.AD_FormbackBook_Load);
            this.groupBox_searchCondition.ResumeLayout(false);
            this.groupBox_searchCondition.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGVBookList)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox_searchCondition;
        private System.Windows.Forms.Button button_search;
        private System.Windows.Forms.Label label_keyWord;
        private System.Windows.Forms.TextBox textBox_keyWord;
        private System.Windows.Forms.ComboBox comboBox_searchWay;
        private System.Windows.Forms.Label label_Sway;
        private System.Windows.Forms.DataGridView DGVBookList;
        private System.Windows.Forms.DataGridViewTextBoxColumn Bid;
        private System.Windows.Forms.DataGridViewTextBoxColumn Bname;
        private System.Windows.Forms.DataGridViewTextBoxColumn Bwriter;
        private System.Windows.Forms.DataGridViewTextBoxColumn Bpublisher;
        private System.Windows.Forms.DataGridViewTextBoxColumn Bsort;
        private System.Windows.Forms.DataGridViewTextBoxColumn Bsum;
        private System.Windows.Forms.DataGridViewTextBoxColumn Bremainder;
        private System.Windows.Forms.DataGridViewTextBoxColumn Bout;
        private System.Windows.Forms.DataGridViewTextBoxColumn Bback;
        private System.Windows.Forms.DataGridViewTextBoxColumn Rid;
        private System.Windows.Forms.DataGridViewLinkColumn outBook;
    }
}