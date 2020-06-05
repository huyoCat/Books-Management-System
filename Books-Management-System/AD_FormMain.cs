using System;
using System.Windows.Forms;

namespace Books_Management_System
{
    public partial class AD_FormMain : Form
    {
        public AD_FormMain()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 添加书籍
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AddBooks_Click(object sender, EventArgs e)
        {
            AD_FormAddBooks formAddBooks = new AD_FormAddBooks();
            formAddBooks.MdiParent = this;
            formAddBooks.Show();
        }

        /// <summary>
        /// 书籍列表
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BooksList_Click(object sender, EventArgs e)
        {
            bool bl = CheckForm(typeof(AD_FormBooksList).Name);
            if (!bl)
            {
                AD_FormBooksList formBooksList = AD_FormBooksList.CreateInstance();
                formBooksList.MdiParent = this;
                formBooksList.Show();
            }
        }

        /// <summary>
        /// 借出书籍列表
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
            AD_FormAddReader formAddReader = new AD_FormAddReader();
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

        /// <summary>
        /// 办理借书
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void outBook_Click(object sender, EventArgs e)
        {
            bool bl = CheckForm(typeof(AD_FormoutBook).Name);
            if (!bl)
            {
                AD_FormoutBook aD_FormoutBook = AD_FormoutBook.CreateInstance();
                aD_FormoutBook.MdiParent = this;
                aD_FormoutBook.Show();
            }
        }
        /// <summary>
        /// 还书
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void backBook_Click(object sender, EventArgs e)
        {
            bool bl = CheckForm(typeof(AD_FormbackBook).Name);
            if (!bl)
            {
                AD_FormbackBook aD_FormbackBook = AD_FormbackBook.CreateInstance();
                aD_FormbackBook.MdiParent = this;
                aD_FormbackBook.Show();
            }
        }

        private void AddAD_Click(object sender, EventArgs e)
        {
            AD_FormAddAD formAddReader = new AD_FormAddAD();
            formAddReader.MdiParent = this;
            formAddReader.Show();
        }

        private void ADList_Click(object sender, EventArgs e)
        {
            bool bl = CheckForm(typeof(AD_FormAdministratorInfoList).Name);
            if (!bl)
            {
                AD_FormAdministratorInfoList formReaderList = new AD_FormAdministratorInfoList();
                formReaderList.MdiParent = this;
                formReaderList.Show();
            }
        }
    }
}
