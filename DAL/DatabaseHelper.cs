using System;
using System.Data;
using MySql.Data.MySqlClient;

namespace DAL
{
    public class DatabaseHelper
    {
        private string connectionString = "Server=localhost;Port=3306;Database=quanlykhodb;Uid=root;Pwd=12345;Charset=utf8;";

        // HÀM 1: Dùng cho các câu lệnh SELECT không có tham số (ví dụ: Load toàn bộ bảng)
        public DataTable ExecuteQuery(string sql)
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                MySqlDataAdapter da = new MySqlDataAdapter(sql, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }

        // HÀM 2: Dùng cho SELECT có tham số (QUAN TRỌNG - Để sửa lỗi 'takes 2 arguments' khi Đăng nhập)
        public DataTable ExecuteQuery(string sql, MySqlParameter[] parameters)
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
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                if (parameters != null)
                {
                    cmd.Parameters.AddRange(parameters);
                }
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }

        // HÀM 3: Dùng cho INSERT, UPDATE, DELETE
        public int ExecuteNonQuery(string sql, MySqlParameter[] parameters = null)
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                if (parameters != null)
                {
                    cmd.Parameters.AddRange(parameters);
                }
                return cmd.ExecuteNonQuery();
            }
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