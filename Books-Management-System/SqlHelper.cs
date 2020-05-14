using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace Books_Management_System
{
    public class SqlHelper
    {
        //windouws身份验证
        private static readonly string connectionString = "server=.;database=BooksManagementSystem;Integrated Security=true";
        public static object ExecuteScalar(string sql,params SqlParameter[] parameters)
        {
            object o = null;
            
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                //创建command对象
                SqlCommand command = new SqlCommand(sql, connection);
                //command.CommandType = CommandType.StoredProcedure;存储过程
                command.Parameters.Clear();
                command.Parameters.AddRange(parameters);

                //打开连接
                connection.Open();

                //执行命令
                o = command.ExecuteScalar();//执行查询，返回结果集第一行第一列的值，忽略其他行或列

                //关闭连接
                //connection.Close();
            }


                return o;
        }
    }
}
