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
    public partial class AD_FormoutBook : Form
    {
        public AD_FormoutBook()
        {
            InitializeComponent();
        }

        //委托
        private Action reLoad = null;

        /// <summary>
        /// 单例实现
        /// </summary>
        private static AD_FormoutBook formBooksList = null;
        private int count;

        public static AD_FormoutBook CreateInstance()
        {
            if (formBooksList == null || formBooksList.IsDisposed)
            {
                formBooksList = new AD_FormoutBook();
            }
            return formBooksList;
        }

        private void comboBox_searchWay_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void AD_FormoutBook_Load(object sender, EventArgs e)
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
            string sql = "select Bid,Bname,Bwriter,Bpublisher,Bsort,Bsum,Bremainder " +
                "from BookInfo where IsDeleted=0";
            DataTable dataTableBookList = SqlHelper.GetDataTable(sql);
            DGVBookList.DataSource = dataTableBookList;
        }

        /// <summary>
        /// 查询  待优化
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_search_Click(object sender, EventArgs e)
        {

            //获取查询条件
            int SearchSID = (int)comboBox_searchWay.SelectedValue;
            string keyWord = textBox_keyWord.Text.Trim();

            string sql = "select Bid,Bname,Bwriter,Bpublisher,Bsort,Bsum,Bremainder " +
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

        

        private void DGVBookList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //获取行数据
            DataRow dataRow = (DGVBookList.Rows[e.RowIndex].DataBoundItem as DataRowView).Row;
            if (e.RowIndex != -1)
            {
                DataGridViewCell dataGridViewCell = DGVBookList.Rows[e.RowIndex].Cells[e.ColumnIndex];
                if (dataGridViewCell is DataGridViewLinkCell &&
                    dataGridViewCell.FormattedValue.ToString() == "办理借阅")
                {
                    reLoad = LoadAllBookList;
                    int Bid = (int)dataRow["Bid"];
                    AD_FormAddOutBook outBook = new AD_FormAddOutBook();
                    //传值
                    // outBook.Tag = Bid;
                    outBook.Tag = new TagObject()
                    {
                        Bid = Bid,
                        ReLoad = reLoad
                    };
                    outBook.MdiParent = this.MdiParent;//指定修改页面的父容器
                    outBook.Show();
                }
            }
        }

        private void LoadAllBookList()
        {
            string sql = "select Bid,Bname,Bwriter,Bpublisher,Bsort,Bsum,Bremainder " +
                        "from BookInfo where IsDeleted=0";
            DataTable dataTableBookList = SqlHelper.GetDataTable(sql);
            DGVBookList.DataSource = dataTableBookList;
        }
    }
}
