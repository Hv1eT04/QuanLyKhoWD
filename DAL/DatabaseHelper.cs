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
        string connectionString = "server=localhost; database= quanlykhodb ;user=root; password=12346; charset=utf8";
        public DataTable ExecuteQuery(string sql, params MySqlParameter[] parameters)
        {
            DataTable dt = new DataTable();

            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();

                using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                {
                    if (parameters != null)
                        cmd.Parameters.AddRange(parameters);

                    using (MySqlDataAdapter da = new MySqlDataAdapter(cmd))
                    {
                        da.Fill(dt);
                    }
                }
            }

            return dt;
        }
        public int ExecuteNonQuery(string sql, params MySqlParameter[] parameters)
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
        public object ExecuteScalar(string sql, params MySqlParameter[] parameters)
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();

                using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                {
                    if (parameters != null)
                        cmd.Parameters.AddRange(parameters);

                    return cmd.ExecuteScalar();
                }
            }
        }
    }
}
