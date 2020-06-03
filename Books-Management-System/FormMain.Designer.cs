﻿namespace Books_Management_System
{
    partial class FormMain
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
            this.ReadersManage = new System.Windows.Forms.ToolStripMenuItem();
            this.AddReader = new System.Windows.Forms.ToolStripMenuItem();
            this.ReaderList = new System.Windows.Forms.ToolStripMenuItem();
            this.exitSystem = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.LendBooksList = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.BooksManage,
            this.ReadersManage,
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
            this.BooksManage.Click += new System.EventHandler(this.BooksManage_Click);
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
            // LendBooksList
            // 
            this.LendBooksList.Name = "LendBooksList";
            this.LendBooksList.Size = new System.Drawing.Size(180, 22);
            this.LendBooksList.Text = "借出书籍列表";
            this.LendBooksList.Click += new System.EventHandler(this.LendBooksList_Click);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(569, 356);
            this.Controls.Add(this.menuStrip1);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "FormMain";
            this.Text = "图书管理系统";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormMain_FormClosing);
            this.Load += new System.EventHandler(this.FormMain_Load);
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
    }
}