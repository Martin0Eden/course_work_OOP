using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Курсовая_пятнашки
{
    internal abstract class sql
    {
        public database db = new database();
        public SqlDataAdapter adapter = new SqlDataAdapter();
        public DataTable dt = new DataTable();
        public string table;

        public sql (string table)
        {
            this.table = table;
        }

        public int count()
        {
            string zap = $"select * from {this.table}";
            SqlCommand cmd = new SqlCommand(zap, this.db.getConnection());
            adapter.SelectCommand = cmd;
            adapter.Fill(this.dt);
            return this.dt.Rows.Count;
        }

        public abstract DataTable fill();


    }
}
