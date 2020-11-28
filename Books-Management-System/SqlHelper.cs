using System;
using System.Data.SqlClient;
using System.Data;

namespace Books_Management_System
{
    public class SqlHelper
    {
        //windouws身份验证
        //private static readonly string connectionString = "server=.;database=BooksManagementSystem;Integrated Security=true";
        //SQL server验证
        public static readonly string connectionString = 
            "server=.;database=BooksManagementSystem;uid=sa;pwd=1064534251";
        public static object ExecuteScalar(string sql,params SqlParameter[] parameters)
        {
            object o = null;
            
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                //创建command对象
                SqlCommand command = new SqlCommand(sql, connection);
                command.Parameters.Clear();
                command.Parameters.AddRange(parameters);

                //打开连接
                connection.Open();

                //执行命令
                o = command.ExecuteScalar();//执行查询，返回结果集第一行第一列的值，忽略其他行或列
            }
                return o;
        }

        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public static DataTable GetDataTable(string sql,params SqlParameter[] parameters)
        {
            DataTable dataTable = new DataTable();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                //创建command对象
                SqlCommand command = new SqlCommand(sql, connection);
                if (parameters != null)
                {
                    command.Parameters.Clear();
                    command.Parameters.AddRange(parameters);
                }

                //执行命令
                SqlDataAdapter dataAdapter = new SqlDataAdapter();
                dataAdapter.SelectCommand = command;

                //打开连接，数据填充
                dataAdapter.Fill(dataTable);
            }
            return dataTable;
        }


        /// <summary>
        /// 返回受影响的行数
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public static int ExecuteNonQuery(string sql,params SqlParameter[] parameters)
        {
            int count = 0;
            using(SqlConnection connection=new SqlConnection(connectionString))
            {
                //创建command对象
                SqlCommand command = new SqlCommand(sql, connection);
                //command.CommandType = CommandType.StoredProcedure;存储过程
                command.Parameters.Clear();
                command.Parameters.AddRange(parameters);

                //打开连接
                connection.Open();

                //执行命令
                count = command.ExecuteNonQuery();//执行查询，返回受影响的行数
            }
            return count;
        }

        /// <summary>
        /// 执行查询，返回数据流
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public static SqlDataReader ExecuteReader(string sql,params SqlParameter[] parameters)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            
            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand(sql, connection);
                command.Parameters.Clear();
                command.Parameters.AddRange(parameters);
                SqlDataReader dataReader = command.ExecuteReader(CommandBehavior.CloseConnection);
                return dataReader;
            }
            catch(SqlException ex)
            {
                connection.Close();
                throw new Exception("执行出现异常", ex);
            }
        }
    }
}
