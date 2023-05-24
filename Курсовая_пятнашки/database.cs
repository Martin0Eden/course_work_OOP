using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Курсовая_пятнашки
{
    internal class database
    {
        /*SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\GameAt15.mdf;Integrated Security=True");*/

        SqlConnection conn = new SqlConnection(@"Data Source=WIN-AG9158AOA4O;Initial Catalog=GameAt15;Integrated Security=True");

        public void open()
        {
            if (conn.State == System.Data.ConnectionState.Closed)
            {
                conn.Open();
            }
        }
        public void close()
        {
            if (conn.State == System.Data.ConnectionState.Open)
            {
                conn.Close();
            }
        }
        public SqlConnection getConnection()
        {
            return conn;
        }

    }
}
