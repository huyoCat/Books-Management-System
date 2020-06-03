using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Books_Management_System
{
    public partial class AD_FormReaderList : Form
    {
        public AD_FormReaderList()
        {
            InitializeComponent();
        }

        //加载所有读者信息，查询读者
        private void FormReaderList_Load(object sender, EventArgs e)
        {
            string sql = "select Rno,Rname,Rscore from ReaderInfo";
            DataTable dataTableReaderList = SqlHelper.GetDataTable(sql);
            DGVReaderList.DataSource = dataTableReaderList;
        }
    }
}
