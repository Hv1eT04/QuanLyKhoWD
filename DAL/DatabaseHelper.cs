using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Data;
namespace DAL
{
    public class DatabaseHelper
    {
        string connectionString = "server=localhost; database= quanlykhodb ;user=root; password=12345; charset=utf8";
        public DataTable ExecuteQuery(string sql)
        {
            MySqlConnection conn = new MySqlConnection(connectionString);
            MySqlDataAdapter da = new MySqlDataAdapter(sql, conn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
        public int ExecuteNonQuery(string sql, MySqlParameter[] parameters)
        {
           MySqlConnection conn = new MySqlConnection(connectionString);
           conn.Open();
           MySqlCommand cmd = new MySqlCommand(sql, conn);
           if (parameters != null)
           {
               cmd.Parameters.AddRange(parameters);
           }
            int result = cmd.ExecuteNonQuery();
           return result;
        }
    }
}
