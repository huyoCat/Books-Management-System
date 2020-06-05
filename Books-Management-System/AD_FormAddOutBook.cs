using System;
using System.Data.SqlClient;
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
            InitBookInfo();
        }

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
            string sql = "select Bid,Bname,Bwriter,Bpublisher,Bsort" +
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
            string Bout = tbOutDate.Text.Trim();
            string Bback = tbBackDate.Text.Trim();
            string Rid = tbRid.Text.Trim();

            //判空处理
            {
                if (string.IsNullOrEmpty(Bout))
                {
                    MessageBox.Show("请输入借出日期！", "办理借阅提示",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (string.IsNullOrEmpty(Bback))
                {
                    MessageBox.Show("请输入归还日期！", "办理借阅提示",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                //判断读者是否存在
                {
                    if (Rid=="")
                    {
                        MessageBox.Show("请输入借阅读者号！", "办理借阅提示",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    string sql = "select count(1) from ReaderInfo where Rid=@Rid";

                    //添加参数
                    SqlParameter[] parameters =
                    {
                        new SqlParameter("@Rid", Rid)
                    };

                    object o = SqlHelper.ExecuteScalar(sql, parameters);
                    //处理结果
                    if (o == null || o == DBNull.Value || ((int)o == 0))
                    {
                        MessageBox.Show("请输入正确的读者号！", "办理借阅提示",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    else
                    //判断是否存在
                    {
                        string sqlExists = "select count(1) from LendBookInfo where Bid=@Bid";
                        SqlParameter[] parameters1 =
                        {
                            new SqlParameter("@Bid",Bid),
                            new SqlParameter("@Bname",Bname),
                            new SqlParameter("@Bwriter",Bwriter),
                            new SqlParameter("@Bpublisher",Bpublisher),
                            new SqlParameter("@Bsort",Bsort)
                        };
                        object oCount = SqlHelper.ExecuteScalar(sqlExists, parameters1);
                        if (oCount == null || oCount == DBNull.Value || ((int)oCount) == 0)
                        {
                            //执行添加
                            string sqlEdit = "SET IDENTITY_INSERT LendBookInfo ON insert into LendBookInfo " +
                                "(Bid,Bname,Bwriter,Bpublisher,Bsort,Bout,Bback,Rid) values" +
                                "(@Bid,@Bname,@Bwriter,@Bpublisher,@Bsort,@Bout,@Bback,@Rid) " +
                                "SET IDENTITY_INSERT LendBookInfo OFF";
                            SqlParameter[] parametersEdit =
                            {
                                    new SqlParameter("@Bid",Bid),
                                    new SqlParameter("@Bname",Bname),
                                    new SqlParameter("@Bwriter",Bwriter),
                                    new SqlParameter("@Bpublisher",Bpublisher),
                                    new SqlParameter("@Bsort",Bsort),
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

                                //修改为不可见
                                string sqlBookList = " update BookInfo set IsDeleted=1 where Bid=@Bid";
                                SqlParameter[] parameters2 =
                            {
                                    new SqlParameter("@Bid",Bid)
                                };
                                int count1 = SqlHelper.ExecuteNonQuery(sqlBookList, parameters2);


                                if (count1 <= 0)
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
                            MessageBox.Show("书籍已外借！", "办理借阅信息提示",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                    }
                }
            }
        }

        private void btAdd_close_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
