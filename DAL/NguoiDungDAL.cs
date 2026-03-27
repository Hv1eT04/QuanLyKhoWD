using System;
using System.Data;
using MySql.Data.MySqlClient;
using DTO;

namespace DAL
{
    public class NguoiDungDAL
    {
        DatabaseHelper dbHelper = new DatabaseHelper();

        public NguoiDungDTO KiemTraDangNhap(string user, string pass)
        {
            string query = "SELECT * FROM nguoidung WHERE tendangnhap = @user AND matkhau = @pass";

            MySqlParameter[] parameters = new MySqlParameter[]
            {
                new MySqlParameter("@user", user),
                new MySqlParameter("@pass", pass)
            };

            DataTable dt = dbHelper.ExecuteQuery(query, parameters);

            if (dt != null && dt.Rows.Count > 0)
            {
                DataRow row = dt.Rows[0];
                return new NguoiDungDTO
                {
                    tendangnhap = row["tendangnhap"].ToString(),
                    hovaten = row["hoten"].ToString(),
                    Vaitro = row["Vaitro"].ToString()
                };
            }

            return null;
        }
    }
}