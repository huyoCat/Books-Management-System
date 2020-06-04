namespace Books_Management_System
{
    partial class AD_FormAddBooks
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.btAdd_close = new System.Windows.Forms.Button();
            this.btAdd_book = new System.Windows.Forms.Button();
            this.cbAdd_Bsort = new System.Windows.Forms.ComboBox();
            this.tbAdd_Bpublisher = new System.Windows.Forms.TextBox();
            this.tbAdd_Bwriter = new System.Windows.Forms.TextBox();
            this.tbAdd_Bname = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.AutoScroll = true;
            this.panel1.Controls.Add(this.btAdd_close);
            this.panel1.Controls.Add(this.btAdd_book);
            this.panel1.Controls.Add(this.cbAdd_Bsort);
            this.panel1.Controls.Add(this.tbAdd_Bpublisher);
            this.panel1.Controls.Add(this.tbAdd_Bwriter);
            this.panel1.Controls.Add(this.tbAdd_Bname);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(292, 291);
            this.panel1.TabIndex = 0;
            // 
            // btAdd_close
            // 
            this.btAdd_close.Location = new System.Drawing.Point(180, 251);
            this.btAdd_close.Name = "btAdd_close";
            this.btAdd_close.Size = new System.Drawing.Size(75, 23);
            this.btAdd_close.TabIndex = 13;
            this.btAdd_close.Text = "关闭";
            this.btAdd_close.UseVisualStyleBackColor = true;
            this.btAdd_close.Click += new System.EventHandler(this.btAdd_close_Click);
            // 
            // btAdd_book
            // 
            this.btAdd_book.Location = new System.Drawing.Point(39, 251);
            this.btAdd_book.Name = "btAdd_book";
            this.btAdd_book.Size = new System.Drawing.Size(75, 23);
            this.btAdd_book.TabIndex = 12;
            this.btAdd_book.Text = "添加";
            this.btAdd_book.UseVisualStyleBackColor = true;
            this.btAdd_book.Click += new System.EventHandler(this.btAdd_book_Click);
            // 
            // cbAdd_Bsort
            // 
            this.cbAdd_Bsort.FormattingEnabled = true;
            this.cbAdd_Bsort.Location = new System.Drawing.Point(86, 189);
            this.cbAdd_Bsort.Name = "cbAdd_Bsort";
            this.cbAdd_Bsort.Size = new System.Drawing.Size(169, 20);
            this.cbAdd_Bsort.TabIndex = 11;
            // 
            // tbAdd_Bpublisher
            // 
            this.tbAdd_Bpublisher.Location = new System.Drawing.Point(86, 131);
            this.tbAdd_Bpublisher.Multiline = true;
            this.tbAdd_Bpublisher.Name = "tbAdd_Bpublisher";
            this.tbAdd_Bpublisher.Size = new System.Drawing.Size(169, 21);
            this.tbAdd_Bpublisher.TabIndex = 9;
            // 
            // tbAdd_Bwriter
            // 
            this.tbAdd_Bwriter.Location = new System.Drawing.Point(86, 73);
            this.tbAdd_Bwriter.Multiline = true;
            this.tbAdd_Bwriter.Name = "tbAdd_Bwriter";
            this.tbAdd_Bwriter.Size = new System.Drawing.Size(169, 21);
            this.tbAdd_Bwriter.TabIndex = 8;
            // 
            // tbAdd_Bname
            // 
            this.tbAdd_Bname.Location = new System.Drawing.Point(86, 23);
            this.tbAdd_Bname.Multiline = true;
            this.tbAdd_Bname.Name = "tbAdd_Bname";
            this.tbAdd_Bname.Size = new System.Drawing.Size(169, 21);
            this.tbAdd_Bname.TabIndex = 7;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(3, 192);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(29, 12);
            this.label5.TabIndex = 4;
            this.label5.Text = "类别";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 134);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 12);
            this.label4.TabIndex = 3;
            this.label4.Text = "出版社";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 76);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 12);
            this.label3.TabIndex = 2;
            this.label3.Text = "作者";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 26);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "书名";
            // 
            // AD_FormAddBooks
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(316, 315);
            this.Controls.Add(this.panel1);
            this.Name = "AD_FormAddBooks";
            this.Text = "添加书籍";
            this.Load += new System.EventHandler(this.FormAddBooks_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btAdd_close;
        private System.Windows.Forms.Button btAdd_book;
        private System.Windows.Forms.ComboBox cbAdd_Bsort;
        private System.Windows.Forms.TextBox tbAdd_Bpublisher;
        private System.Windows.Forms.TextBox tbAdd_Bwriter;
        private System.Windows.Forms.TextBox tbAdd_Bname;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
    }
}