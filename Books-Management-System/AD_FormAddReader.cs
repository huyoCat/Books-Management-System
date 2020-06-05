using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Books_Management_System
{
    public partial class AD_FormAddReader : Form
    {
        public AD_FormAddReader()
        {
            InitializeComponent();
        }

        private void btClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        /// <summary>
        /// 添加读者
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btAdd_Click(object sender, EventArgs e)
        {
            //信息获取
            string Password = tbPassword.Text.Trim();

            //判断是否为空
            {
                if (string.IsNullOrEmpty(Password))
                {
                    MessageBox.Show("请设置密码！", "添加读者提示",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            {
                //执行添加
                string sqlAddReader = "insert into ReaderInfo " +
                    "(Rpassword) values" +
                    "(@Rpassword)";
                SqlParameter[] parametersAdd =
                {
                        new SqlParameter("@Rpassword",Password)
                    };

                //执行并返回
                int count = SqlHelper.ExecuteNonQuery(sqlAddReader, parametersAdd);
                if (count > 0)
                {
                    string sql = "select top 1 Rid from ReaderInfo order by Rid desc";
                    int Rid = 0;
                    //添加参数
                    SqlParameter[] parameters =
                    {
                        new SqlParameter("@Rid", Rid)
                    };

                    object o = SqlHelper.ExecuteScalar(sql, parameters);
                    MessageBox.Show($"读者: {o} 添加成功", "添加读者提示",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("读者添加失败！", "添加读者提示", 
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
        }
    }
}
