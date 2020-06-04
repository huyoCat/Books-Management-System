using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Books_Management_System
{
    public partial class AD_FormBooksList : Form
    {
        public AD_FormBooksList()
        {
            InitializeComponent();
        }

        //委托
        private Action reLoad = null;

        //单例实现
        private static AD_FormBooksList formBooksList = null;
        private int count;

        public static AD_FormBooksList CreateInstance()
        {
            if (formBooksList == null || formBooksList.IsDisposed)
            {
                formBooksList = new AD_FormBooksList();
            }
            return formBooksList;
        }

        private void FormBooksList_Load(object sender, EventArgs e)
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

            comboBox_searchWay.DataSource = dataTableSelectList;
            comboBox_searchWay.DisplayMember = "Sname";
            comboBox_searchWay.ValueMember = "SID";
        }

        private void InitAllBook()
        {
            string sql = "select Bid,Bname,Bwriter,Bpublisher,Bsort " +
                "from BookInfo where IsDeleted=0";
            DataTable dataTableBookList = SqlHelper.GetDataTable(sql);
            DGVBookList.DataSource = dataTableBookList;
        }

        private void button_search_Click(object sender, EventArgs e)
        {
            //获取查询条件
            int SearchSID = (int)comboBox_searchWay.SelectedValue;
            string keyWord = textBox_keyWord.Text.Trim();

            string sql = "select Bid,Bname,Bwriter,Bpublisher,Bsort " +
                "from BookInfo where IsDeleted=0";
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

        /// <summary>
        /// 修改或删除的实现
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DGVBookList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //获取行数据
            DataRow dataRow = (DGVBookList.Rows[e.RowIndex].DataBoundItem as DataRowView).Row;
            if (e.RowIndex != -1)
            {
                //获取当前单元格
                DataGridViewCell dataGridViewCell = DGVBookList.Rows[e.RowIndex].Cells[e.ColumnIndex];
                if (dataGridViewCell is DataGridViewLinkCell &&
                    dataGridViewCell.FormattedValue.ToString() == "修改")
                {
                    //修改操作
                    reLoad = LoadAllBookList;
                    int Bid = (int)dataRow["Bid"];
                    AD_FormEditBookInfo editBookInfo = new AD_FormEditBookInfo();
                    //传值
                    //editBookInfo.Tag = Bid;
                    editBookInfo.Tag = new TagObject()
                    {
                        Bid = Bid,
                        ReLoad = reLoad
                    };
                    editBookInfo.MdiParent = this.MdiParent;//指定修改页面的父容器
                    editBookInfo.Show();
                }

                else if (dataGridViewCell is DataGridViewLinkCell &&
                    dataGridViewCell.FormattedValue.ToString() == "删除")
                {
                    //删除操作
                    if (MessageBox.Show("您确定要删除该书籍信息吗？", "删除书籍提示",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        
                        int Bid = int.Parse(dataRow["Bid"].ToString());
                        //假删除,程序不显示，但数据库数据仍存在
                        string sqlDel0 = "update BookInfo set IsDeleted=1 where Bid=@Bid";
                        SqlParameter parameter = new SqlParameter("@Bid", Bid);
                        int count = SqlHelper.ExecuteNonQuery(sqlDel0, parameter);
                        if (count > 0)
                        {
                            MessageBox.Show("该书籍信息删除成功！", "删除书籍提示",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
                            //手动刷新信息
                            DataTable dataTableBookList = (DataTable)DGVBookList.DataSource;
                            //DGVBookList.DataSource = null;
                            dataTableBookList.Rows.Remove(dataRow);
                            DGVBookList.DataSource = dataTableBookList;
                        }
                        else
                        {
                            MessageBox.Show("该书籍信息删除失败！", "删除书籍提示",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                    }
                }
            }
        }

        private void LoadAllBookList()
        {
            string sql = "select Bid,Bname,Bwriter,Bpublisher,Bsort " +
                        "from BookInfo where IsDeleted=0";
            DataTable dataTableBookList = SqlHelper.GetDataTable(sql);
            DGVBookList.DataSource = dataTableBookList;
        }
        /// <summary>
        /// 批量删除
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btDelAll_Click(object sender, EventArgs e)
        {
            //选择
            //获取所选数据
            List<int> listId = new List<int>();
            for (int i = 0; i < DGVBookList.Rows.Count; i++)
            {
                DataGridViewCheckBoxCell cell = DGVBookList.Rows[i].Cells["ColCheck"]
                    as DataGridViewCheckBoxCell;
                bool check = Convert.ToBoolean(cell.Value);
                if (check)
                {
                    DataRow dataRow = (DGVBookList.Rows[i].DataBoundItem as DataRowView).Row;
                    int Bid = (int)dataRow["Bid"];
                    listId.Add(Bid);
                }
            }

            //判断所选数据个数，需>0
            if (listId.Count == 0)
            {
                MessageBox.Show("请选择要删除的书籍信息！", "删除书籍提示",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Error);
                return;
            }
            else
            {
                if (MessageBox.Show("您确定要删除所选书籍信息吗？", "删除书籍提示",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    //启动事务，删除
                    using (SqlConnection connection = new SqlConnection(SqlHelper.connectionString))
                    {
                        connection.Open();
                        SqlTransaction transaction = connection.BeginTransaction();
                        SqlCommand command = new SqlCommand();
                        command.Connection = connection;
                        command.Transaction = transaction;
                        try
                        {
                            foreach (int Bid in listId)
                            {
                                command.CommandText = "update BookInfo set IsDeleted=1 where Bid=@Bid";
                                SqlParameter parameter = new SqlParameter("@Bid", Bid);
                                command.Parameters.Clear();
                                command.Parameters.Add(parameter);
                                count += command.ExecuteNonQuery();
                            }
                            transaction.Commit();
                        }
                        catch (SqlException ex)
                        {
                            transaction.Rollback();
                            MessageBox.Show("删除书籍出现异常！", "删除书籍提示",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                    }
                    if (count == listId.Count)
                    {
                        MessageBox.Show("书籍信息删除成功！", "删除书籍提示",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }

                    //刷新数据列表
                    string sql = "select Bid,Bname,Bwriter,Bpublisher,Bsort " +
                        "from BookInfo where IsDeleted=0";
                    DataTable dataTableBookList = SqlHelper.GetDataTable(sql);
                    DGVBookList.DataSource = dataTableBookList;
                }
            }
        }
    }
}
