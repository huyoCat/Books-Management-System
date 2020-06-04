using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Books_Management_System
{
    public partial class BO_FormAddReader : Form
    {
        public BO_FormAddReader()
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
            int Rid = int.Parse(tbRid.Text);
            string Password = tbPassword.Text.Trim();

            //判断是否为空
            {
                if (Rid == 0)
                {
                    MessageBox.Show("请输入读者号！", "添加读者提示",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (string.IsNullOrEmpty(Password))
                {
                    MessageBox.Show("请输入密码！", "添加读者提示",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            //判断是否已存在
            {
                string sqlAdd = "select count(1) from ReaderInfo where Rid=@Rid";
                SqlParameter[] parameters =
                {
                    new SqlParameter("@Rid",Rid)
                };
                object oCount = SqlHelper.ExecuteScalar(sqlAdd, parameters);
                if (oCount == null || oCount == DBNull.Value || ((int)oCount) == 0)
                {
                    //string Bsort = getSort(BookSort);
                    //执行添加
                    string sqlAddReader = "SET IDENTITY_INSERT ReaderInfo ON insert into ReaderInfo " +
                        "(Rid,Rpassword) values" +
                        "(@Rid,@Rpassword) SET IDENTITY_INSERT ReaderInfo OFF";
                    SqlParameter[] parametersAdd =
                    {
                        new SqlParameter("@Rid",Rid),
                        new SqlParameter("@Rpassword",Password)
                    };

                    //执行并返回
                    int count = SqlHelper.ExecuteNonQuery(sqlAddReader, parametersAdd);
                    if (count > 0)
                    {
                        MessageBox.Show($"读者: {Rid} 添加成功", "添加读者提示",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("读者添加失败！", "添加读者提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
                else
                {
                    MessageBox.Show("读者已存在！", "添加读者提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
        }
    }
}
