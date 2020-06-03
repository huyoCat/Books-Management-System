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
            int Bid = int.Parse(tbAdd_Bid.Text);
            string Bname = tbAdd_Bname.Text.Trim();
            string Bwriter = tbAdd_Bwriter.Text.Trim();
            string Bpublisher = tbAdd_Bpublisher.Text.Trim();
            int BookSort = (int)cbAdd_Bsort.SelectedValue;
            string Bsum = tbAdd_Bsum.Text.Trim();
            string Bremainder = Bsum;

            //判断是否为空
            {
                if (Bid == 0)
                {
                    MessageBox.Show("请输入书号！", "添加书号提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (string.IsNullOrEmpty(Bname))
                {
                    MessageBox.Show("请输入书名！", "添加书名提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (string.IsNullOrEmpty(Bwriter))
                {
                    MessageBox.Show("请输入作者！", "添加作者提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (string.IsNullOrEmpty(Bpublisher))
                {
                    MessageBox.Show("请输入出版社！", "添加出版社提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (string.IsNullOrEmpty(Bsum))
                {
                    MessageBox.Show("请输入书目馆藏数量！", "添加书目馆藏数量提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            //判断是否已存在
            {
                string sqlExists = "select count(1) from BookInfo where Bid=@Bid";
                SqlParameter[] parameters =
                {
                    new SqlParameter("@Bid",Bid)
                };
                object oCount = SqlHelper.ExecuteScalar(sqlExists, parameters);
                if (oCount == null || oCount == DBNull.Value || ((int)oCount) == 0)
                {
                    string Bsort = getSort(BookSort); 
                    //执行添加
                    string sqlAdd = "SET IDENTITY_INSERT BookInfo ON insert into BookInfo " +
                        "(Bid,Bname,Bwriter,Bpublisher,Bsort,Bsum,Bremainder) values" +
                        "(@Bid,@Bname,@Bwriter,@Bpublisher,@Bsort,@Bsum,@Bremainder) SET IDENTITY_INSERT BookInfo OFF";
                    SqlParameter[] parametersAdd =
                    {
                        new SqlParameter("@Bid",Bid),
                        new SqlParameter("@Bname",Bname),
                        new SqlParameter("@Bwriter",Bwriter),
                        new SqlParameter("@Bpublisher",Bpublisher),
                        new SqlParameter("@Bsort",Bsort),
                        new SqlParameter("@Bsum",Bsum),
                        new SqlParameter("@Bremainder",Bremainder)
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
                        MessageBox.Show("书籍添加失败！", "添加书籍提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
                else
                {
                    MessageBox.Show("书籍已存在！", "添加书籍提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
        }
        /// <summary>
        /// 待优化
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
