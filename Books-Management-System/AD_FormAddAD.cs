using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Books_Management_System
{
    public partial class AD_FormAddAD : Form
    {
        public AD_FormAddAD()
        {
            InitializeComponent();
        }

        private void btAdd_Click(object sender, EventArgs e)
        {
            //信息获取
            string Password = tbPassword.Text.Trim();

            //判断是否为空
            {
                if (string.IsNullOrEmpty(Password))
                {
                    MessageBox.Show("请设置密码！", "添加管理员提示",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            {
                //执行添加
                string sqlAddReader = "insert into AdministratorInfo " +
                    "(Apassword) values" +
                    "(@Apassword)";
                SqlParameter[] parametersAdd =
                {
                        new SqlParameter("@Apassword",Password)
                    };

                //执行并返回
                int count = SqlHelper.ExecuteNonQuery(sqlAddReader, parametersAdd);
                if (count > 0)
                {
                    string sql = "select top 1 Aid from AdministratorInfo order by Aid desc";
                    int Aid = 0;
                    //添加参数
                    SqlParameter[] parameters =
                    {
                        new SqlParameter("@Aid", Aid)
                    };

                    object o = SqlHelper.ExecuteScalar(sql, parameters);
                    MessageBox.Show($"管理员: {o} 添加成功", "添加管理员提示",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("管理员添加失败！", "添加管理员提示",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
        }

        private void btClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
