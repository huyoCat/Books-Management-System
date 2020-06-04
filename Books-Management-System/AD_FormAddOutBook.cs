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
    public partial class AD_FormAddOutBook : Form
    {
        public AD_FormAddOutBook()
        {
            InitializeComponent();
        }

        private int Bid = 0;
        private Action reLaod = null;

        private void AD_FormAddOutBook_Load(object sender, EventArgs e)
        {
            //InitSelect();//加载类别列表
            //加载书籍信息
            InitBookInfo();
        }

        //private void InitSelect()
        //{
        //    string sql = "select BSortId,BSortName from BookSortList";
        //    DataTable dataTableSelectList = SqlHelper.GetDataTable(sql);
        //    cbEdit_Bsort.DataSource = dataTableSelectList;
        //    cbEdit_Bsort.DisplayMember = "BSortName";
        //    cbEdit_Bsort.ValueMember = "BSortId";
        //}

        private void InitBookInfo()
        {
            //if (this.Tag != null&&this.Tag.ToString()!="")
            if (this.Tag != null)
            {
                //int.TryParse(this.Tag.ToString(), out Bid);
                TagObject tagObject = (TagObject)this.Tag;
                Bid = tagObject.Bid;
                reLaod = tagObject.ReLoad;//赋值
            }
            //查询
            string sql = "select Bid,Bname,Bwriter,Bpublisher,Bsort,Bsum,Bremainder" +
                " from BookInfo where Bid=@Bid";
            SqlParameter paraID = new SqlParameter("@Bid", Bid);
            SqlDataReader dataReader = SqlHelper.ExecuteReader(sql, paraID);
            //读取数据
            if (dataReader.Read())
            {
                lbBid.Text = dataReader["Bid"].ToString();
                lbBname.Text = dataReader["Bname"].ToString();
                lbBwriter.Text = dataReader["Bwriter"].ToString();
                lbBpublisher.Text = dataReader["Bpublisher"].ToString();
                lbBsort.Text = dataReader["Bsort"].ToString();
                lbBsum.Text = dataReader["Bsum"].ToString();
                lbBremainder.Text = dataReader["Bremainder"].ToString();
                tbOutDate.Text = DateTime.Now.ToString("yyyy.MM.dd");
                tbBackDate.Text = DateTime.Now.AddDays(30).ToString("yyyy.MM.dd");
            }
            dataReader.Close();
        }

        private void btEdit_book_Click(object sender, EventArgs e)
        {
            //获取页面信息
            int Bid = int.Parse(lbBid.Text);
            string Bname = lbBname.Text.Trim();
            string Bwriter = lbBwriter.Text.Trim();
            string Bpublisher = lbBpublisher.Text.Trim();
            string Bsort = lbBsort.Text.Trim();
            string Bsum = lbBsum.Text.Trim();
            //这里要做一个借出然后减掉
            string Bremainder = lbBremainder.Text.Trim();
            string Bout = tbOutDate.Text.Trim();
            string Bback = tbBackDate.Text.Trim();
            int Rid = int.Parse(tbRid.Text);

            //判空处理
            {
                if (string.IsNullOrEmpty(Bout))
                {
                    MessageBox.Show("请输入借出日期！", "办理借阅提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (string.IsNullOrEmpty(Bback))
                {
                    MessageBox.Show("请输入归还日期！", "办理借阅提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (Rid==0)
                {
                    MessageBox.Show("请输入借阅读者号！", "办理借阅提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            //判断是否存在
            {
                string sqlExists = "select count(1) from LendBookInfo where Bid=@Bid";
                SqlParameter[] parameters =
                {
                    new SqlParameter("@Bid",Bid),
                    new SqlParameter("@Bname",Bname),
                    new SqlParameter("@Bwriter",Bwriter),
                    new SqlParameter("@Bpublisher",Bpublisher),
                    new SqlParameter("@Bsort",Bsort),
                    new SqlParameter("@Bsum",Bsum),
                    new SqlParameter("@Bremainder",Bremainder)
                };
                object oCount = SqlHelper.ExecuteScalar(sqlExists, parameters);
                if (oCount == null || oCount == DBNull.Value || ((int)oCount) == 0)
                {
                    //string Bsort = getSort(BookSort);
                    //执行添加
                    string sqlEdit = "SET IDENTITY_INSERT LendBookInfo ON insert into LendBookInfo " +
                        "(Bid,Bname,Bwriter,Bpublisher,Bsort,Bsum,Bremainder,Bout,Bback,Rid) values" +
                        "(@Bid,@Bname,@Bwriter,@Bpublisher,@Bsort,@Bsum,@Bremainder,@Bout,@Bback,@Rid) " +
                        "SET IDENTITY_INSERT LendBookInfo OFF";
                    SqlParameter[] parametersEdit =
                    {
                        new SqlParameter("@Bid",Bid),
                        new SqlParameter("@Bname",Bname),
                        new SqlParameter("@Bwriter",Bwriter),
                        new SqlParameter("@Bpublisher",Bpublisher),
                        new SqlParameter("@Bsort",Bsort),
                        new SqlParameter("@Bsum",Bsum),
                        new SqlParameter("@Bremainder",Bremainder),
                        new SqlParameter("@Bout",Bout),
                        new SqlParameter("@Bback",Bback),
                        new SqlParameter("@Rid",Rid)
                    };

                    //执行并返回
                    int count = SqlHelper.ExecuteNonQuery(sqlEdit, parametersEdit);
                    if (count > 0)
                    {
                        MessageBox.Show($"书籍: {Bname} 办理借阅成功", "办理借阅信息提示",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);

                        //在馆数量-1
                        string sqlBookList= " update BookInfo set Bremainder=@Bremainder-1 where Bid=@Bid";
                        SqlParameter[] parameters1 =
                    {
                        new SqlParameter("@Bid",Bid),
                        new SqlParameter("@Bname",Bname),
                        new SqlParameter("@Bwriter",Bwriter),
                        new SqlParameter("@Bpublisher",Bpublisher),
                        new SqlParameter("@Bsort",Bsort),
                        new SqlParameter("@Bsum",Bsum),
                        new SqlParameter("@Bremainder",Bremainder),
                        new SqlParameter("@Bout",Bout),
                        new SqlParameter("@Bback",Bback),
                        new SqlParameter("@Rid",Rid)
                    };
                        int count1 = SqlHelper.ExecuteNonQuery(sqlBookList, parameters1);
                        string sqlLendBookList = " update LendBookInfo set Bremainder=@Bremainder-1 " +
                            "where Bid=@Bid";
                        SqlParameter[] parameters2 =
                    {
                        new SqlParameter("@Bid",Bid),
                        new SqlParameter("@Bname",Bname),
                        new SqlParameter("@Bwriter",Bwriter),
                        new SqlParameter("@Bpublisher",Bpublisher),
                        new SqlParameter("@Bsort",Bsort),
                        new SqlParameter("@Bsum",Bsum),
                        new SqlParameter("@Bremainder",Bremainder),
                        new SqlParameter("@Bout",Bout),
                        new SqlParameter("@Bback",Bback),
                        new SqlParameter("@Rid",Rid)
                    };
                        int count2 = SqlHelper.ExecuteNonQuery(sqlLendBookList, parameters2);

                        if (count1 <= 0 || count2 <= 0)
                        {
                            MessageBox.Show("数据库信息修改失败！");
                        }

                        //利用委托跨页面刷新
                        reLaod.Invoke();
                    }
                    else
                    {
                        MessageBox.Show("办理借阅失败！", "办理借阅信息提示", 
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
                else
                {
                    MessageBox.Show("借阅信息已存在！", "办理借阅信息提示", 
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
        }

        private void btAdd_close_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
