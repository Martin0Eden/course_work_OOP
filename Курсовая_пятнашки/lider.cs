using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Курсовая_пятнашки
{
    internal class lider: sql
    {
        public string name;
        public string complexity;
        public TimeSpan time;

        public lider(string table, string name,string complexity, TimeSpan time) : base(table) 
        { 
            this.name = name;
            this.complexity = complexity;
            this.time = time;
        }

        public lider(string table) : base(table)
        { }

        public void ExecuteInsertQuery()
        {
            try
            {
                using (SqlConnection connection = db.getConnection())
                {
                    connection.Open();
                    string query = "INSERT INTO player ([name], [complexity], [time]) VALUES (@name, @complexity, @time)";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@name", name);
                        command.Parameters.AddWithValue("@complexity", complexity);
                        command.Parameters.AddWithValue("@time", time);
                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ошибка при выполнении SQL-запроса на добавление: " + ex.Message);
            }
        }

        public override DataTable fill()
        {
            string zap = $"select * from " + table;
            SqlCommand cmd = new SqlCommand(zap, db.getConnection());
            adapter.SelectCommand = cmd;
            adapter.Fill(dt);
            return dt;

        }
    }
}
