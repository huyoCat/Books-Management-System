﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Books_Management_System
{
    public partial class FormMain : Form
    {
        

        public FormMain()
        {
            InitializeComponent();
        }
        private void BooksManage_Click(object sender, EventArgs e)
        {
            
        }

        //添加书籍
        private void AddBooks_Click(object sender, EventArgs e)
        {
            AD_FormAddBooks formAddBooks = new AD_FormAddBooks();
            formAddBooks.MdiParent = this;
            formAddBooks.Show();
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            
        }

        //书籍列表
        private void BooksList_Click(object sender, EventArgs e)
        {
            bool bl = CheckForm(typeof(BO_FormBooksList).Name);
            if (!bl)
            {
                BO_FormBooksList formBooksList = BO_FormBooksList.CreateInstance();
                formBooksList.MdiParent = this;
                formBooksList.Show();
            }
        }

        //借出书籍列表
        private void LendBooksList_Click(object sender, EventArgs e)
        {
            bool bl = CheckForm(typeof(AD_FormLendBook).Name);
            if (!bl)
            {
                AD_FormLendBook aD_FormLendBook = AD_FormLendBook.CreateInstance();
                aD_FormLendBook.MdiParent = this;
                aD_FormLendBook.Show();
            }
        }

        //检查窗体是否已经打开
        private bool CheckForm(string formName)
        {
            bool bl = false;
            foreach (Form f in Application.OpenForms)
            {
                if (f.Name == formName)
                {
                    bl = true;
                    f.Activate();
                    break;
                }
            }
            return bl;
        }

        //添加读者
        private void AddReader_Click(object sender, EventArgs e)
        {
            BO_FormAddReader formAddReader = new BO_FormAddReader();
            formAddReader.MdiParent = this;
            formAddReader.Show();
        }


        //读者列表
        private void ReaderList_Click(object sender, EventArgs e)
        {
            bool bl = CheckForm(typeof(AD_FormReaderList).Name);
            if (!bl)
            {
                AD_FormReaderList formReaderList = new AD_FormReaderList();
                formReaderList.MdiParent = this;
                formReaderList.Show();
            }
        }

        //退出程序
        

        private void FormMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult result = MessageBox.Show("您确定要退出系统吗？", "退出提示",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                Application.ExitThread();
            }
            else
            {
                e.Cancel = true;
            }
        }
        private void exitSystem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        
    }
}
