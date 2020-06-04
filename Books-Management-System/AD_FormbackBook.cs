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
    public partial class AD_FormbackBook : Form
    {
        public AD_FormbackBook()
        {
            InitializeComponent();
        }

        //委托
        private Action reLoad = null;

        /// <summary>
        /// 单例实现
        /// </summary>
        private static AD_FormbackBook formBooksList = null;


        public static AD_FormbackBook CreateInstance()
        {
            if (formBooksList == null || formBooksList.IsDisposed)
            {
                formBooksList = new AD_FormbackBook();
            }
            return formBooksList;
        }

        private void AD_FormbackBook_Load(object sender, EventArgs e)
        {
            InitSelect();//加载筛选列表
            InitAllBook();//加载所有书
        }

        private void InitSelect()
        {
            string sql = "select SID,Sname from SelectList where SID<6";
            DataTable dataTableSelectList = SqlHelper.GetDataTable(sql);
            DataRow dataRowSelectList = dataTableSelectList.NewRow();
            dataRowSelectList["SID"] = 0;
            dataRowSelectList["Sname"] = "请选择";
            dataTableSelectList.Rows.InsertAt(dataRowSelectList, 0);
            //dataTableBookList.Rows.Add(dataRowBookList);添加至最后一个

            comboBox_searchWay.DataSource = dataTableSelectList;
            comboBox_searchWay.DisplayMember = "Sname";
            comboBox_searchWay.ValueMember = "SID";
        }

        private void InitAllBook()
        {
            string sql = "select Bid,Bname,Bwriter,Bpublisher,Bsort,Bsum,Bremainder,Bout,Bback,Rid " +
                "from LendBookInfo where IsDeleted=0";
            DataTable dataTableBookList = SqlHelper.GetDataTable(sql);
            DGVBookList.DataSource = dataTableBookList;
        }


        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_search_Click(object sender, EventArgs e)
        {
            //获取查询条件
            int SearchSID = (int)comboBox_searchWay.SelectedValue;
            string keyWord = textBox_keyWord.Text.Trim();

            string sql = "select Bid,Bname,Bwriter,Bpublisher,Bsort,Bsum,Bremainder,Bout,Bback,Rid " +
                "from LendBookInfo where IsDeleted=0";
            //sql += " where 1=1";
            if (SearchSID > 0)
            {
                if (SearchSID == 1)
                {
                    if (string.IsNullOrEmpty(keyWord))
                    {
                        MessageBox.Show("请输入关键字！");
                    }
                    else
                    {
                        sql += "and Bid like @Bid";
                    }

                }
                if (SearchSID == 2)
                {
                    if (string.IsNullOrEmpty(keyWord))
                    {
                        MessageBox.Show("请输入关键字！");
                    }
                    else
                    {
                        sql += "and Bname like @Bname";
                    }
                }
                if (SearchSID == 3)
                {
                    if (string.IsNullOrEmpty(keyWord))
                    {
                        MessageBox.Show("请输入关键字！");
                    }
                    else
                    {
                        sql += "and Bwriter like @Bwriter";
                    }
                }
                if (SearchSID == 4)
                {
                    if (string.IsNullOrEmpty(keyWord))
                    {
                        MessageBox.Show("请输入关键字！");
                    }
                    else
                    {
                        sql += "and Bpublisher like @Bpublisher";
                    }
                }
                if (SearchSID == 5)
                {
                    if (string.IsNullOrEmpty(keyWord))
                    {
                        MessageBox.Show("请输入关键字！");
                    }
                    else
                    {
                        sql += "and Bsort like @Bsort";
                    }
                }
            }

            SqlParameter[] parameters =
            {
                new SqlParameter("@Bid","%"+keyWord+"%"),
                new SqlParameter("@Bname","%"+keyWord+"%"),
                new SqlParameter("@Bwriter","%"+keyWord+"%"),
                new SqlParameter("@Bpublisher","%"+keyWord+"%"),
                new SqlParameter("@Bsort","%"+keyWord+"%"),
            };
            DataTable dataTableBookList = SqlHelper.GetDataTable(sql, parameters);
            DGVBookList.DataSource = dataTableBookList;
        }

        //private int Bid = 0;
        private Action reLaod = null;

        /// <summary>
        /// 在出借列表删除，在书籍列表+1
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DGVBookList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //获取行数据
            DataRow dataRow = (DGVBookList.Rows[e.RowIndex].DataBoundItem as DataRowView).Row;
            if (e.RowIndex != -1)
            {
                DataGridViewCell dataGridViewCell = DGVBookList.Rows[e.RowIndex].Cells[e.ColumnIndex];
                if (dataGridViewCell is DataGridViewLinkCell &&
                    dataGridViewCell.FormattedValue.ToString() == "办理归还")
                {
                    DialogResult result = MessageBox.Show("是否确定归还书籍？", "归还书籍提示",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (result == DialogResult.Yes)
                    {
                        int Bid = (int)dataRow["Bid"];
                        int Rid = (int)dataRow["Rid"];
                        string Bremainder = (string)dataRow["Bremainder"];
                        //string sql = "select Bid,Bname,Bwriter,Bpublisher,Bsort,Bsum,Bremainder+1 " +
                        //    "from BookInfo where Bid=@Bid";
                        //SqlParameter paraID = new SqlParameter("@Bid", Bid);
                        //SqlDataReader dataReader = SqlHelper.ExecuteReader(sql, paraID);
                        ////读取数据
                        //if (dataReader.Read())
                        //{
                        //    int BookId = int.Parse(dataReader["Bid"].ToString());
                        //    //string Bname = dataReader["Bname"].ToString();
                        //    //string Bwriter = dataReader["Bwriter"].ToString();
                        //    //string Bpublisher = dataReader["Bpublisher"].ToString();
                        //    //string Bsort = dataReader["Bsort"].ToString();
                        //    //string Bsum = dataReader["Bsum"].ToString();
                        //    //string Bremainder = dataReader["Bremainder"].ToString();
                        //}
                        //dataReader.Close();

                        //在馆数量+1
                        string sqlBookList = " update BookInfo set Bremainder=@Bremainder+1 where Bid=@Bid";
                        SqlParameter[] parameters1 =
                        {
                            new SqlParameter("@Bid",Bid),
                            //new SqlParameter("@Bname",Bname),
                            //new SqlParameter("@Bwriter",Bwriter),
                            //new SqlParameter("@Bpublisher",Bpublisher),
                            //new SqlParameter("@Bsort",Bsort),
                            //new SqlParameter("@Bsum",Bsum),
                            new SqlParameter("@Bremainder",Bremainder)
                            //new SqlParameter("@Bout",Bout),
                            //new SqlParameter("@Bback",Bback),
                            //new SqlParameter("@Rid",Rid)
                        };
                        int count1 = SqlHelper.ExecuteNonQuery(sqlBookList, parameters1);

                        //删除出借列表信息
                        string sqlLendBookList = " delete LendBookInfo where Bid=@Bid and Rid=@Rid";
                        SqlParameter[] parameters2 =
                        {
                            new SqlParameter("@Bid",Bid),
                            //new SqlParameter("@Bname",Bname),
                            //new SqlParameter("@Bwriter",Bwriter),
                            //new SqlParameter("@Bpublisher",Bpublisher),
                            //new SqlParameter("@Bsort",Bsort),
                            //new SqlParameter("@Bsum",Bsum),
                            //new SqlParameter("@Bremainder",Bremainder),
                            //new SqlParameter("@Bout",Bout),
                            //new SqlParameter("@Bback",Bback),
                            new SqlParameter("@Rid",Rid)
                        };
                        int count2 = SqlHelper.ExecuteNonQuery(sqlLendBookList, parameters2);

                        //后台修改数据库书籍信息
                        if (count1 <= 0 || count2 <= 0)
                        {
                            MessageBox.Show("数据库信息修改失败！");
                        }

                        string sql = "select Bid,Bname,Bwriter,Bpublisher,Bsort,Bsum,Bremainder,Bout,Bback,Rid " +
                        "from LendBookInfo where IsDeleted=0";
                        DataTable dataTableBookList = SqlHelper.GetDataTable(sql);
                        DGVBookList.DataSource = dataTableBookList;

                        ////利用委托跨页面刷新
                        //reLoad = LoadAllBookList;
                        //reLaod.Invoke();
                    }
                }
            }
        }

        //private void LoadAllBookList()
        //{
        //    string sql = "select Bid,Bname,Bwriter,Bpublisher,Bsort,Bsum,Bremainder,Bout,Bback,Rid " +
        //                "from LendBookInfo where IsDeleted=0";
        //    DataTable dataTableBookList = SqlHelper.GetDataTable(sql);
        //    DGVBookList.DataSource = dataTableBookList;
        //}
    }
}
