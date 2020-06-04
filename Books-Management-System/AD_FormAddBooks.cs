using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Books_Management_System
{
    public partial class AD_FormAddBooks : Form
    {
        public AD_FormAddBooks()
        {
            InitializeComponent();
        }

        private void FormAddBooks_Load(object sender, EventArgs e)
        {
            InitBookSortList();//加载书籍类别列表
        }

        private void InitBookSortList()
        {
            string sql = "select BSortId,BSortName from BookSortList";
            DataTable dataTableSelectSort = SqlHelper.GetDataTable(sql);

            cbAdd_Bsort.DataSource = dataTableSelectSort;
            cbAdd_Bsort.DisplayMember = "BSortName";
            cbAdd_Bsort.ValueMember = "BSortId";
            cbAdd_Bsort.SelectedIndex = 0;
        }

        private void btAdd_book_Click(object sender, EventArgs e)
        {

            //信息获取
            string Bname = tbAdd_Bname.Text.Trim();
            string Bwriter = tbAdd_Bwriter.Text.Trim();
            string Bpublisher = tbAdd_Bpublisher.Text.Trim();
            int BookSort = (int)cbAdd_Bsort.SelectedValue;

            //判断是否为空
            {
                if (string.IsNullOrEmpty(Bname))
                {
                    MessageBox.Show("请输入书名！", "添加书名提示", 
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (string.IsNullOrEmpty(Bwriter))
                {
                    MessageBox.Show("请输入作者！", "添加作者提示", 
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (string.IsNullOrEmpty(Bpublisher))
                {
                    MessageBox.Show("请输入出版社！", "添加出版社提示", 
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            //判断是否已存在
            {
                string sqlExists = "select count(1) from BookInfo " +
                    "where Bname=@Bname and Bwriter=@Bwriter";
                SqlParameter[] parameters =
                {
                    new SqlParameter("@Bname",Bname),
                    new SqlParameter("@Bwriter",Bwriter)
                };
                object oCount = SqlHelper.ExecuteScalar(sqlExists, parameters);
                if (oCount == null || oCount == DBNull.Value || ((int)oCount) == 0)
                {
                    string Bsort = getSort(BookSort); 
                    //执行添加
                    string sqlAdd = "insert into BookInfo " +
                        "(Bname,Bwriter,Bpublisher,Bsort) values" +
                        "(@Bname,@Bwriter,@Bpublisher,@Bsort)";
                    SqlParameter[] parametersAdd =
                    {
                        new SqlParameter("@Bname",Bname),
                        new SqlParameter("@Bwriter",Bwriter),
                        new SqlParameter("@Bpublisher",Bpublisher),
                        new SqlParameter("@Bsort",Bsort)
                    };

                    //执行并返回
                    int count = SqlHelper.ExecuteNonQuery(sqlAdd, parametersAdd);
                    if (count > 0)
                    {
                        MessageBox.Show($"书籍: {Bname} 添加成功", "添加书籍提示",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("书籍添加失败！", "添加书籍提示", 
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
                else
                {
                    MessageBox.Show("书籍已存在！", "添加书籍提示", 
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
        }
        /// <summary>
        /// 获取书籍类型
        /// </summary>
        /// <param name="BookSort"></param>
        /// <returns></returns>
        private string getSort(int BookSort)
        {
            string Bsort="";
            switch (BookSort)
            {
                case 0:
                    Bsort = "艺术";
                    break;
                case 1:
                    Bsort = "计算机技术、自动化技术";
                    break;
                case 2:
                    Bsort = "医药、卫生";
                    break;
                case 3:
                    Bsort = "哲学、宗教";
                    break;
                case 4:
                    Bsort = "政治、法律";
                    break;
            }
            return Bsort;
        }
        private void btAdd_close_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
