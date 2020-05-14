using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button_Login_Click(object sender, EventArgs e)
        {
            //获取用户输入信息
            string Rno = textBox_Num.Text.Trim();
            string Rpassword = textBox_password.Text.Trim();

            //判断是否为空
            if (string.IsNullOrEmpty(Rno))
            {
                MessageBox.Show("请输入账号","登录提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBox_Num.Focus();
                return;
            }

            if (string.IsNullOrEmpty(Rpassword))
            {
                MessageBox.Show("请输入密码", "登录提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBox_password.Focus();
                return;
            }

            //与数据库通信，检查输入与数据库记录是否一致
            {
                //建立与数据库的连接


                //查询语句
                //这种方法容易被SQL注入
                //string sql = "select count(1) from ReaderInfo where Rno='"+readerNo+"'and Rpassword='"+readerPassword+"'";
                string sql = "select count(1) from ReaderInfo where Rno=@Rno and Rpassword=@Rpassword";

                //添加参数
               // SqlParameter parameterRno = new SqlParameter("@Rno", readerNo);
               // SqlParameter parameterRpassword = new SqlParameter("@Rpassword", readerPassword);
                //或者使用数组添加参数
                SqlParameter[] parameters =
                {
                    new SqlParameter("@Rno", Rno),
                    new SqlParameter("@Rpassword", Rpassword)
                };


                //创建command对象
                //SqlCommand command = new SqlCommand(sql, connection);
                //command.CommandType = CommandType.StoredProcedure;存储过程
                //command.Parameters.Clear();
                //command.Parameters.Add(parameterRno);
                //command.Parameters.Add(parameterRpassword);
                //command.Parameters.AddRange(parameters);

                //打开连接
                //connection.Open();

                //执行命令
                //object o = command.ExecuteScalar();//执行查询，返回结果集第一行第一列的值，忽略其他行或列

                //关闭连接
                //connection.Close();

                object o = SqlHelper.ExecuteScalar(sql, parameters);

                //处理结果
                if (o == null || o == DBNull.Value || ((int)o == 0))
                {
                    MessageBox.Show("账号或密码有误！", "登录提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else
                {
                    int count = (int)o;
                    MessageBox.Show("登录成功！", "登录提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //转到主页面
                }
            }

            //根据返回结果显示不同提示
        }

        private void button_Exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
