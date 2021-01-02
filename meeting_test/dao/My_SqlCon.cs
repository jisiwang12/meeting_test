using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace meeting_test.dao
{
    class My_SqlCon
    {
        private String sqlStringCon = "server=localhost;uid=gsq;pwd=123;database=My_Test";
        
        public SqlDataReader getSqlDr_Login(String mysql)
        {
            SqlConnection connection = new SqlConnection(sqlStringCon);
            
            SqlCommand cmd = new SqlCommand(mysql, connection);
            connection.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            return dr;
        }

        public SqlCommand getCmd(String mysql)
        {
            SqlConnection connection = new SqlConnection(sqlStringCon);
            SqlCommand cmd = new SqlCommand(mysql, connection);
            connection.Open();
            return cmd;
        }

        public DataSet getSqlds(String mysql)
        {
            SqlConnection connection = new SqlConnection(sqlStringCon);
            DataSet dataSet = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter(mysql, connection);
            connection.Open();
            da.Fill(dataSet);
            return dataSet;
        }
    }
}
