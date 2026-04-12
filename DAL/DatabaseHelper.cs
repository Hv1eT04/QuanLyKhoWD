using System;
using System.Data;
using MySql.Data.MySqlClient;

namespace DAL
{
    public class DatabaseHelper
    {
        // Fixed: Use only one connection string variable. 
        // Note: Ensure your password and database name are correct here.
        private readonly string connectionString = "Server=localhost;Port=3306;Database=quanlykhohangdb;Uid=root;Pwd=123456;Charset=utf8;";

        /// <summary>
        /// Used for SELECT statements. 
        /// Works for both no-parameter and parameterized queries thanks to 'params'.
        /// </summary>
        public DataTable ExecuteQuery(string sql, params MySqlParameter[] parameters)
        {
            DataTable dt = new DataTable();
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                {
                    if (parameters != null)
                    {
                        cmd.Parameters.AddRange(parameters);
                    }

                    using (MySqlDataAdapter da = new MySqlDataAdapter(cmd))
                    {
                        da.Fill(dt);
                    }
                }
            }
            return dt;
        }

        /// <summary>
        /// Used for INSERT, UPDATE, DELETE.
        /// Returns the number of rows affected.
        /// </summary>
        public int ExecuteNonQuery(string sql, params MySqlParameter[] parameters)
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                {
                    conn.Open();
                    if (parameters != null)
                    {
                        cmd.Parameters.AddRange(parameters);
                    }
                    return cmd.ExecuteNonQuery();
                }
            }
        }

        /// <summary>
        /// Used for aggregate functions like COUNT(*), MAX(), or fetching a single ID.
        /// </summary>
        public object ExecuteScalar(string sql, params MySqlParameter[] parameters)
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                {
                    conn.Open();
                    if (parameters != null)
                    {
                        cmd.Parameters.AddRange(parameters);
                    }
                    return cmd.ExecuteScalar();
                }
            }
        }
    }
}