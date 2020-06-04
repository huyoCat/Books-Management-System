using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Books_Management_System
{
    public partial class AD_FormAdministratorInfoList : Form
    {
        public AD_FormAdministratorInfoList()
        {
            InitializeComponent();
        }

        private void btReaderSearch_Click(object sender, EventArgs e)
        {
            //获取关键字
            string keyWord = textBReaderSearch.Text.Trim();
            string sql = "select Aid,Apassword from AdministratorInfo";
            sql += " where 1=1";
            sql += "and Aid like @Aid";

            SqlParameter[] parameters =
            {
                new SqlParameter("@Aid","%"+keyWord+"%")
            };
            DataTable dataTableReaderList = SqlHelper.GetDataTable(sql, parameters);
            DGVReaderList.DataSource = dataTableReaderList;
        }

        /// <summary>
        /// 加载所有信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AD_FormAdministratorInfoList_Load(object sender, EventArgs e)
        {
            string sql = "select Aid,Apassword from AdministratorInfo";
            DataTable dataTableReaderList = SqlHelper.GetDataTable(sql);
            DGVReaderList.DataSource = dataTableReaderList;
        }
    }
}
