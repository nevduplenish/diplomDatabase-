using System.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ArEx_DataBase
{
    class DataBase
    {

        SqlConnection sqlConnection = new SqlConnection(@"Data Source = DESKTOP-5HFGC8L\SQLEXPRESS;Initial Catalog=ArExDB;Integrated Security=True");
        
        public void openConnection()
        {
                if (sqlConnection.State == System.Data.ConnectionState.Closed)
                {
                        sqlConnection.Open();
                }
        }
        public void closeConnection()
        {
            if (sqlConnection.State == System.Data.ConnectionState.Open)
            {
                sqlConnection.Close();
            }
        }

        public SqlConnection getConnection()
        {
            return sqlConnection;
        }

    }
}
