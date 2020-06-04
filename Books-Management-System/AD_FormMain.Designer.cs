namespace Books_Management_System
{
    partial class AD_FormMain
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
            this.components = new System.ComponentModel.Container();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.BooksManage = new System.Windows.Forms.ToolStripMenuItem();
            this.AddBooks = new System.Windows.Forms.ToolStripMenuItem();
            this.BooksList = new System.Windows.Forms.ToolStripMenuItem();
            this.LendBooksList = new System.Windows.Forms.ToolStripMenuItem();
            this.ReadersManage = new System.Windows.Forms.ToolStripMenuItem();
            this.AddReader = new System.Windows.Forms.ToolStripMenuItem();
            this.ReaderList = new System.Windows.Forms.ToolStripMenuItem();
            this.outAback = new System.Windows.Forms.ToolStripMenuItem();
            this.outBook = new System.Windows.Forms.ToolStripMenuItem();
            this.backBook = new System.Windows.Forms.ToolStripMenuItem();
            this.exitSystem = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.Administrator = new System.Windows.Forms.ToolStripMenuItem();
            this.AddAD = new System.Windows.Forms.ToolStripMenuItem();
            this.ADList = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.BooksManage,
            this.ReadersManage,
            this.outAback,
            this.Administrator,
            this.exitSystem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(569, 25);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // BooksManage
            // 
            this.BooksManage.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.AddBooks,
            this.BooksList,
            this.LendBooksList});
            this.BooksManage.Name = "BooksManage";
            this.BooksManage.Size = new System.Drawing.Size(68, 21);
            this.BooksManage.Text = "书籍管理";
            // 
            // AddBooks
            // 
            this.AddBooks.Name = "AddBooks";
            this.AddBooks.Size = new System.Drawing.Size(180, 22);
            this.AddBooks.Text = "添加书籍";
            this.AddBooks.Click += new System.EventHandler(this.AddBooks_Click);
            // 
            // BooksList
            // 
            this.BooksList.Name = "BooksList";
            this.BooksList.Size = new System.Drawing.Size(180, 22);
            this.BooksList.Text = "书籍列表";
            this.BooksList.Click += new System.EventHandler(this.BooksList_Click);
            // 
            // LendBooksList
            // 
            this.LendBooksList.Name = "LendBooksList";
            this.LendBooksList.Size = new System.Drawing.Size(180, 22);
            this.LendBooksList.Text = "借出书籍列表";
            this.LendBooksList.Click += new System.EventHandler(this.LendBooksList_Click);
            // 
            // ReadersManage
            // 
            this.ReadersManage.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.AddReader,
            this.ReaderList});
            this.ReadersManage.Name = "ReadersManage";
            this.ReadersManage.Size = new System.Drawing.Size(68, 21);
            this.ReadersManage.Text = "读者管理";
            // 
            // AddReader
            // 
            this.AddReader.Name = "AddReader";
            this.AddReader.Size = new System.Drawing.Size(180, 22);
            this.AddReader.Text = "添加读者";
            this.AddReader.Click += new System.EventHandler(this.AddReader_Click);
            // 
            // ReaderList
            // 
            this.ReaderList.Name = "ReaderList";
            this.ReaderList.Size = new System.Drawing.Size(180, 22);
            this.ReaderList.Text = "读者列表";
            this.ReaderList.Click += new System.EventHandler(this.ReaderList_Click);
            // 
            // outAback
            // 
            this.outAback.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.outBook,
            this.backBook});
            this.outAback.Name = "outAback";
            this.outAback.Size = new System.Drawing.Size(80, 21);
            this.outAback.Text = "办理借还书";
            // 
            // outBook
            // 
            this.outBook.Name = "outBook";
            this.outBook.Size = new System.Drawing.Size(180, 22);
            this.outBook.Text = "借书";
            this.outBook.Click += new System.EventHandler(this.outBook_Click);
            // 
            // backBook
            // 
            this.backBook.Name = "backBook";
            this.backBook.Size = new System.Drawing.Size(180, 22);
            this.backBook.Text = "还书";
            this.backBook.Click += new System.EventHandler(this.backBook_Click);
            // 
            // exitSystem
            // 
            this.exitSystem.Name = "exitSystem";
            this.exitSystem.Size = new System.Drawing.Size(68, 21);
            this.exitSystem.Text = "退出系统";
            this.exitSystem.Click += new System.EventHandler(this.exitSystem_Click);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // Administrator
            // 
            this.Administrator.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.AddAD,
            this.ADList});
            this.Administrator.Name = "Administrator";
            this.Administrator.Size = new System.Drawing.Size(56, 21);
            this.Administrator.Text = "管理员";
            // 
            // AddAD
            // 
            this.AddAD.Name = "AddAD";
            this.AddAD.Size = new System.Drawing.Size(180, 22);
            this.AddAD.Text = "添加管理员";
            this.AddAD.Click += new System.EventHandler(this.AddAD_Click);
            // 
            // ADList
            // 
            this.ADList.Name = "ADList";
            this.ADList.Size = new System.Drawing.Size(180, 22);
            this.ADList.Text = "管理员列表";
            this.ADList.Click += new System.EventHandler(this.ADList_Click);
            // 
            // AD_FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(569, 356);
            this.Controls.Add(this.menuStrip1);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "AD_FormMain";
            this.Text = "图书管理系统";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormMain_FormClosing);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem BooksManage;
        private System.Windows.Forms.ToolStripMenuItem ReadersManage;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem AddBooks;
        private System.Windows.Forms.ToolStripMenuItem BooksList;
        private System.Windows.Forms.ToolStripMenuItem AddReader;
        private System.Windows.Forms.ToolStripMenuItem ReaderList;
        private System.Windows.Forms.ToolStripMenuItem exitSystem;
        private System.Windows.Forms.ToolStripMenuItem LendBooksList;
        private System.Windows.Forms.ToolStripMenuItem outAback;
        private System.Windows.Forms.ToolStripMenuItem outBook;
        private System.Windows.Forms.ToolStripMenuItem backBook;
        private System.Windows.Forms.ToolStripMenuItem Administrator;
        private System.Windows.Forms.ToolStripMenuItem AddAD;
        private System.Windows.Forms.ToolStripMenuItem ADList;
    }
}