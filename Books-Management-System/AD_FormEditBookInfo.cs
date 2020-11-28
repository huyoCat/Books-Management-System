using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Books_Management_System
{
    public partial class AD_FormEditBookInfo : Form
    {
        public AD_FormEditBookInfo()
        {
            InitializeComponent();
        }

        private int Bid = 0;
        private string BSortName = null;
        private Action reLaod = null;

        private void AD_FormEditBookInfo_Load(object sender, EventArgs e)
        {
            InitSelect();//加载类别列表
            //加载书籍信息
            InitBookInfo();
        }

        private void InitSelect()
        {
            string sql = "select BSortId,BSortName from BookSortList";
            DataTable dataTableSelectList = SqlHelper.GetDataTable(sql);
            cbEdit_Bsort.DataSource = dataTableSelectList;
            cbEdit_Bsort.DisplayMember = "BSortName";
            cbEdit_Bsort.ValueMember = "BSortId";
        }

        private void InitBookInfo()
        {
            //if (this.Tag != null&&this.Tag.ToString()!="")
            if(this.Tag!=null)
            {
                //int.TryParse(this.Tag.ToString(), out Bid);
                TagObject tagObject = (TagObject)this.Tag;
                Bid = tagObject.Bid;
                BSortName = tagObject.BSortName;
                reLaod = tagObject.ReLoad;//赋值
            }
            //查询
            string sql = "select Bid,Bname,Bwriter,Bpublisher,Bsort from BookInfo where Bid=@Bid";
            SqlParameter paraID = new SqlParameter("@Bid", Bid);
            SqlDataReader dataReader = SqlHelper.ExecuteReader(sql, paraID);
            int BSortId = getBSortId(BSortName);

            string sql1 = "select BSortId,BSortName from BookSortList";
            DataTable dataTableSelectSort = SqlHelper.GetDataTable(sql1);

            cbEdit_Bsort.DataSource = dataTableSelectSort;
            cbEdit_Bsort.DisplayMember = "BSortName";
            cbEdit_Bsort.ValueMember = "BSortId";
            cbEdit_Bsort.SelectedIndex = BSortId;

            //读取数据
            if (dataReader.Read())
            {
                tbEdit_Bname.Text = dataReader["Bname"].ToString();
                tbEdit_Bwriter.Text = dataReader["Bwriter"].ToString();
                tbEdit_Bpublisher.Text = dataReader["Bpublisher"].ToString();
            }
            dataReader.Close();
        }

        private void btEdit_book_Click(object sender, EventArgs e)
        {
            //获取页面信息
            string Bname = tbEdit_Bname.Text.Trim();
            string Bwriter = tbEdit_Bwriter.Text.Trim();
            string Bpublisher = tbEdit_Bpublisher.Text.Trim();
            int BookSort = (int)cbEdit_Bsort.SelectedValue;

            //判空处理
            {
                if (string.IsNullOrEmpty(Bname))
                {
                    MessageBox.Show("请输入书名！", "修改书名提示", 
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (string.IsNullOrEmpty(Bwriter))
                {
                    MessageBox.Show("请输入作者！", "修改作者提示", 
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (string.IsNullOrEmpty(Bpublisher))
                {
                    MessageBox.Show("请输入出版社！", "修改出版社提示", 
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            //判断是否存在
            {
                string sqlExists = "select count(1) from BookInfo where Bname=@Bname and Bwriter=@Bwriter";
                SqlParameter[] parameters =
                {
                    new SqlParameter("@Bid",Bid),
                    new SqlParameter("@Bname",Bname),
                    new SqlParameter("@Bwriter",Bwriter),
                    new SqlParameter("@Bpublisher",Bpublisher),
                    new SqlParameter("@Bsort",BookSort)
                };
                object oCount = SqlHelper.ExecuteScalar(sqlExists, parameters);
                if (oCount == null || oCount == DBNull.Value || ((int)oCount) == 0)
                {
                    string Bsort = getSort(BookSort);
                    //执行修改
                    string sqlEdit = " update BookInfo set " +
                        "Bname=@Bname,Bwriter=@Bwriter,Bpublisher=@Bpublisher,Bsort=@Bsort" +
                        " where Bid=@Bid ";
                    SqlParameter[] parametersEdit =
                    {
                        new SqlParameter("@Bid",Bid),
                        new SqlParameter("@Bname",Bname),
                        new SqlParameter("@Bwriter",Bwriter),
                        new SqlParameter("@Bpublisher",Bpublisher),
                        new SqlParameter("@Bsort",Bsort)
                    };

                    //执行并返回
                    int count = SqlHelper.ExecuteNonQuery(sqlEdit, parametersEdit);
                    if (count > 0)
                    {
                        MessageBox.Show($"书籍: {Bname} 修改成功", "修改书籍信息提示",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);

                        //利用委托跨页面刷新
                        reLaod.Invoke();
                    }
                    else
                    {
                        MessageBox.Show("修改书籍信息失败！", "修改书籍信息提示", 
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
                else
                {
                    MessageBox.Show("书籍已存在！", "修改书籍信息提示", 
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
        }

        /// <summary>
        /// 书籍类型
        /// </summary>
        /// <param name="BookSort"></param>
        /// <returns></returns>
        private string getSort(int BookSort)
        {
            string Bsort = "";
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

        private int getBSortId(string BSortNmae)
        {
            int id = 0;
            switch (BSortNmae)
            {
                case "艺术":
                    id = 1;
                    break;
                case "计算机技术、自动化技术":
                    id = 1;
                    break;
                case "医药、卫生":
                    id = 2;
                    break;
                case "哲学、宗教":
                    id = 3;
                    break;
                case "政治、法律":
                    id = 4;
                    break;
            }
            return id;
        }

        private void btAdd_close_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
