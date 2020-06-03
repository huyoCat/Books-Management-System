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
    public partial class AD_FormEditBookInfo : Form
    {
        public AD_FormEditBookInfo()
        {
            InitializeComponent();
        }

        private int Bid = 0;
        private Action reLaod = null;
        //public int pubBid = 0;//公有变量
        //public AD_FormEditBookInfo(int _Bid)
        //{
        //    InitializeComponent();
        //    Bid = _Bid;
        //}

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
            //DataRow dataRowSelectList = dataTableSelectList.NewRow();
            cbEdit_Bsort.DataSource = dataTableSelectList;
            cbEdit_Bsort.DisplayMember = "BSortName";
            cbEdit_Bsort.ValueMember = "BSortId";
            //dataRowSelectList["SID"] = 0;
            //dataRowSelectList["Sname"] = "请选择";
            //dataTableSelectList.Rows.InsertAt(dataRowSelectList, 0);
            //dataTableBookList.Rows.Add(dataRowBookList);添加至最后一个

            //comboBox_searchWay.DataSource = dataTableSelectList;
            //comboBox_searchWay.DisplayMember = "Sname";
            //comboBox_searchWay.ValueMember = "SID";
        }

        private void InitBookInfo()
        {
            //if (this.Tag != null&&this.Tag.ToString()!="")
            if(this.Tag!=null)
            {
                //int.TryParse(this.Tag.ToString(), out Bid);
                TagObject tagObject = (TagObject)this.Tag;
                Bid = tagObject.Bid;
                reLaod = tagObject.ReLoad;//赋值
            }
            //查询
            string sql = "select Bid,Bname,Bwriter,Bpublisher,Bsort,Bsum from BookInfo where Bid=@Bid";
            SqlParameter paraID = new SqlParameter("@Bid", Bid);
            SqlDataReader dataReader = SqlHelper.ExecuteReader(sql, paraID);
            //读取数据
            if (dataReader.Read())
            {
                tbEdit_Bid.Text = dataReader["Bid"].ToString();
                tbEdit_Bname.Text = dataReader["Bname"].ToString();
                tbEdit_Bwriter.Text = dataReader["Bwriter"].ToString();
                tbEdit_Bpublisher.Text = dataReader["Bpublisher"].ToString();
                cbEdit_Bsort.SelectedItem = dataReader["Bsort"].ToString();
                tbEdit_Bsum.Text = dataReader["Bsum"].ToString();
            }
            dataReader.Close();
        }

        private void btEdit_book_Click(object sender, EventArgs e)
        {
            //获取页面信息
            int Bid = int.Parse(tbEdit_Bid.Text);
            string Bname = tbEdit_Bname.Text.Trim();
            string Bwriter = tbEdit_Bwriter.Text.Trim();
            string Bpublisher = tbEdit_Bpublisher.Text.Trim();
            int BookSort = (int)cbEdit_Bsort.SelectedValue;
            string Bsum = tbEdit_Bsum.Text.Trim();
            //这里要做一个借出然后减掉
            string Bremainder = Bsum;

            //判空处理
            {
                if (Bid == 0)
                {
                    MessageBox.Show("请输入书号！", "修改书号提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (string.IsNullOrEmpty(Bname))
                {
                    MessageBox.Show("请输入书名！", "修改书名提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (string.IsNullOrEmpty(Bwriter))
                {
                    MessageBox.Show("请输入作者！", "修改作者提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (string.IsNullOrEmpty(Bpublisher))
                {
                    MessageBox.Show("请输入出版社！", "修改出版社提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (string.IsNullOrEmpty(Bsum))
                {
                    MessageBox.Show("请输入书目馆藏数量！", "修改书目馆藏数量提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            //判断是否存在
            {
                string sqlExists = "select count(1) from BookInfo where Bid=@Bid and Bid<>@Bid";
                SqlParameter[] parameters =
                {
                    new SqlParameter("@Bid",Bid),
                    new SqlParameter("@Bname",Bname),
                    new SqlParameter("@Bwriter",Bwriter),
                    new SqlParameter("@Bpublisher",Bpublisher),
                    new SqlParameter("@Bsort",BookSort),
                    new SqlParameter("@Bsum",Bsum),
                    new SqlParameter("@Bremainder",Bremainder)
                };
                object oCount = SqlHelper.ExecuteScalar(sqlExists, parameters);
                if (oCount == null || oCount == DBNull.Value || ((int)oCount) == 0)
                {
                    string Bsort = getSort(BookSort);
                    //执行添加
                    string sqlEdit = " update BookInfo set " +
                        "Bname=@Bname,Bwriter=@Bwriter,Bpublisher=@Bpublisher,Bsort=@Bsort," +
                        "Bsum=@Bsum where Bid=@Bid ";
                    SqlParameter[] parametersEdit =
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
                        MessageBox.Show("修改书籍信息失败！", "修改书籍信息提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
                else
                {
                    MessageBox.Show("书籍已存在！", "修改书籍信息提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void btAdd_close_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
