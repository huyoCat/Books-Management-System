using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Books_Management_System
{
    public partial class RE_FormBookList : Form
    {
        public RE_FormBookList()
        {
            InitializeComponent();
        }

        //单例实现
        private static RE_FormBookList formBooksList = null;
        private int count;

        public static RE_FormBookList CreateInstance()
        {
            if (formBooksList == null || formBooksList.IsDisposed)
            {
                formBooksList = new RE_FormBookList();
            }
            return formBooksList;
        }

        private void RE_FormBookList_Load(object sender, EventArgs e)
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

        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_search_Click_1(object sender, EventArgs e)
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
    }
}
