using System;
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
    public partial class RE_FormMain : Form
    {
        public RE_FormMain()
        {
            InitializeComponent();
        }

        private void exitSystem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void RE_FormMain_Load(object sender, EventArgs e)
        {

        }

        private void REBookList_Click(object sender, EventArgs e)
        {
            bool bl = CheckForm(typeof(RE_FormBookList).Name);
            if (!bl)
            {
                RE_FormBookList formBooksList = RE_FormBookList.CreateInstance();
                formBooksList.MdiParent = this;
                formBooksList.Show();
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

        private void RE_FormMain_FormClosing(object sender, FormClosingEventArgs e)
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
    }
}
