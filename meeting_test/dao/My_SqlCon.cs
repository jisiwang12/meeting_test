using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace meeting_test.dao
{
    /**
     * 数据库服务
     */
    class My_SqlCon
    {
        private String sqlStringCon = "server=10.86.36.28;uid=sa;pwd=123;database=Meeting";

        public SqlConnection GetConnection()
        {
            var sqlConnection = new SqlConnection(sqlStringCon);
            return sqlConnection;
        }
        /**
         * 验证用户
         * @mysql 传入数据库参数 
         */
        public SqlDataReader getSqlDr_Login(String mysql,SqlConnection sqlConnection)
        {
            SqlCommand cmd = new SqlCommand(mysql, sqlConnection);
            sqlConnection.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            return dr;
        }

        /**
         * 获取sqlcommand
         * @mysql 数据库语句
         */
        public SqlCommand getCmd(String mysql,SqlConnection connection)
        {
         
            SqlCommand cmd = new SqlCommand(mysql, connection);
            connection.Open();
            return cmd;
        }
        /**
         * 获取SqlDateSet
         * @mysql 传入的字符串参数
         */
        public DataSet getSqlds(String mysql,SqlConnection connection)
        {
            DataSet dataSet = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter(mysql, connection);
            connection.Open();
            da.Fill(dataSet);
            return dataSet;
        }
    }
}
