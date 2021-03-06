﻿using System;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Books_Management_System
{
    public partial class loginForm : Form
    {
        public loginForm()
        {
            InitializeComponent();
        }

        private void loginForm_Load(object sender, EventArgs e)
        {
            rbtReader.Checked = true;
        }

        private void button_Login_Click(object sender, EventArgs e)
        {
            //获取用户输入信息
            string id = textBox_Num.Text.Trim();
            string password = textBox_password.Text.Trim();
            string iden = rbtReader.Checked ? rbtReader.Text : rbtAD.Text;

            //判断是否为空
            if (string.IsNullOrEmpty(id))
            {
                MessageBox.Show("请输入账号","登录提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBox_Num.Focus();
                return;
            }

            if (string.IsNullOrEmpty(password))
            {
                MessageBox.Show("请输入密码", "登录提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBox_password.Focus();
                return;
            }

            //与数据库通信，检查输入与数据库记录是否一致
            {
                //建立与数据库的连接,根据返回结果显示不同提示

                //管理员登录
                if (iden == "管理员")
                {
                    string sqlAD = "select count(1) from AdministratorInfo " +
                        "where Aid=@Aid and Apassword=@Apassword";

                    SqlParameter[] parametersAD =
                    {
                        new SqlParameter("@Aid", id),
                        new SqlParameter("@Apassword", password)
                    };

                    object o = SqlHelper.ExecuteScalar(sqlAD, parametersAD);

                    //处理结果
                    if (o == null || o == DBNull.Value || ((int)o == 0))
                    {
                        MessageBox.Show("账号或密码有误！", "登录提示",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    else
                    {
                        int count = (int)o;
                        MessageBox.Show("登录成功！", "登录提示", 
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                        //转到主页面
                        AD_FormMain formMain = new AD_FormMain();
                        formMain.Show();
                        this.Hide();
                    }
                }

                //读者登录
                else
                {
                    string sql = "select count(1) from ReaderInfo where Rid=@Rid and Rpassword=@Rpassword";

                    //添加参数
                    SqlParameter[] parameters =
                    {
                        new SqlParameter("@Rid", id),
                        new SqlParameter("@Rpassword", password)
                    };

                    object o = SqlHelper.ExecuteScalar(sql, parameters);

                    //处理结果
                    if (o == null || o == DBNull.Value || ((int)o == 0))
                    {
                        MessageBox.Show("账号或密码有误！", "登录提示", 
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    else
                    {
                        int count = (int)o;
                        MessageBox.Show("登录成功！", "登录提示", 
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                        //转到主页面
                        RE_FormMain formMain = new RE_FormMain();
                        formMain.Show();
                        this.Hide();
                    }
                }
            }
        }

        private void button_Exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
