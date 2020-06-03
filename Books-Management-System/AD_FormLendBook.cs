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
    public partial class AD_FormLendBook : Form
    {
        public AD_FormLendBook()
        {
            InitializeComponent();
        }

        private void AD_FormLendBook_Load(object sender, EventArgs e)
        {
            InitSelectLendBook();//加载筛选列表
            InitAllLendBook();//加载所有借出书
        }

        private void InitSelectLendBook()
        {
            string sql = "select SID,Sname from SelectList";
            DataTable dataTableSelectList = SqlHelper.GetDataTable(sql);
            DataRow dataRowSelectList = dataTableSelectList.NewRow();
            dataRowSelectList["SID"] = 0;
            dataRowSelectList["Sname"] = "请选择";
            dataTableSelectList.Rows.InsertAt(dataRowSelectList, 0);
            //dataTableBookList.Rows.Add(dataRowBookList);添加至最后一个

            CBLendBookList.DataSource = dataTableSelectList;
            CBLendBookList.DisplayMember = "Sname";
            CBLendBookList.ValueMember = "SID";
        }

        private void InitAllLendBook()
        {
            string sql = "select Bid,Bname,Bwriter,Bpublisher,Bsort,Bsum,Bremainder,Bout,Bback,Rid " +
                "from LendBookInfo";
            DataTable dataTableBookList = SqlHelper.GetDataTable(sql);
            DGVLendBookList.DataSource = dataTableBookList;
        }

        //单例
        private static AD_FormLendBook formLendBooksList = null;
        private int count;

        internal static AD_FormLendBook CreateInstance()
        {
            if (formLendBooksList == null || formLendBooksList.IsDisposed)
            {
                formLendBooksList = new AD_FormLendBook();
            }
            return formLendBooksList;
        }


        private void BT_searchLendBook_Click(object sender, EventArgs e)
        {
            //获取查询条件
            int SearchSID = (int)CBLendBookList.SelectedValue;
            string keyWord = textBox_SearchLendBook.Text.Trim();

            string sql = "select Bid,Bname,Bwriter,Bpublisher,Bsort,Bsum,Bremainder,Bout,Bback,Rid " +
                "from LendBookInfo";
            sql += " where 1=1";
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
                if (SearchSID == 6)
                {
                    if (string.IsNullOrEmpty(keyWord))
                    {
                        MessageBox.Show("请输入关键字！");
                    }
                    else
                    {
                        sql += "and Rid like @Rid";
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
                new SqlParameter("@Bout","%"+keyWord+"%"),
                new SqlParameter("@Bback","%"+keyWord+"%"),
                new SqlParameter("@Rid","%"+keyWord+"%"),
            };
            DataTable dataTableLendBookList = SqlHelper.GetDataTable(sql, parameters);
            DGVLendBookList.DataSource = dataTableLendBookList;
        }

        /// <summary>
        /// 修改或删除的实现
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DGVLendBookList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                //获取当前单元格
                DataGridViewCell dataGridViewCell = DGVLendBookList.Rows[e.RowIndex].Cells[e.ColumnIndex];
                if (dataGridViewCell is DataGridViewLinkCell &&
                    dataGridViewCell.FormattedValue.ToString() == "修改")
                {
                    //修改操作
                }
                else if (dataGridViewCell is DataGridViewLinkCell &&
                    dataGridViewCell.FormattedValue.ToString() == "删除")
                {
                    //删除操作
                    if (MessageBox.Show("您确定要删除该借阅信息吗？", "删除借阅信息提示",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        DataRow dataRow = (DGVLendBookList.Rows[e.RowIndex].DataBoundItem as DataRowView).Row;
                        int Bid = int.Parse(dataRow["Bid"].ToString());
                        //假删除,程序不显示，但数据库数据仍存在
                        string sqlDel0 = "update LendBookInfo set IsDeleted=1 where Bid=@Bid";
                        SqlParameter parameter = new SqlParameter("@Bid", Bid);
                        int count = SqlHelper.ExecuteNonQuery(sqlDel0, parameter);
                        if (count > 0)
                        {
                            MessageBox.Show("该借阅信息删除成功！", "删除借阅信息提示",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
                            //手动刷新信息
                            DataTable dataTableBookList = (DataTable)DGVLendBookList.DataSource;
                            //DGVBookList.DataSource = null;
                            dataTableBookList.Rows.Remove(dataRow);
                            DGVLendBookList.DataSource = dataTableBookList;
                        }
                        else
                        {
                            MessageBox.Show("该借阅信息删除失败！", "删除借阅信息提示",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                    }
                }
            }
        }

        /// <summary>
        /// 批量删除
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bt_DelAll_Click(object sender, EventArgs e)
        {
            //选择
            //获取所选数据
            List<int> listId = new List<int>();
            for (int i = 0; i < DGVLendBookList.Rows.Count; i++)
            {
                DataGridViewCheckBoxCell cell = DGVLendBookList.Rows[i].Cells["ColCheck"]
                    as DataGridViewCheckBoxCell;
                bool check = Convert.ToBoolean(cell.Value);
                if (check)
                {
                    DataRow dataRow = (DGVLendBookList.Rows[i].DataBoundItem as DataRowView).Row;
                    int Bid = (int)dataRow["Bid"];
                    listId.Add(Bid);
                }
            }

            //判断所选数据个数，需>0
            if (listId.Count == 0)
            {
                MessageBox.Show("请选择要删除的借阅信息！", "删除借阅信息提示",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Error);
                return;
            }
            else
            {
                if (MessageBox.Show("您确定要删除所选借阅信息吗？", "删除借阅信息提示",
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
                                command.CommandText = "update LendBookInfo set IsDeleted=1 where Bid=@Bid";
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
                            MessageBox.Show("删除借阅信息出现异常！", "删除借阅信息提示",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                    }
                    if (count == listId.Count)
                    {
                        MessageBox.Show("借阅信息删除成功！", "删除借阅信息提示",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    //手动刷新
                    string sql = "select Bid,Bname,Bwriter,Bpublisher,Bsort,Bsum,Bremainder,Bout,Bback,Rid " +
                        "from LendBookInfo where IsDeleted=0";
                    DataTable dataTableBookList = SqlHelper.GetDataTable(sql);
                    DGVLendBookList.DataSource = dataTableBookList;
                }
            }
        }
    }
}
