using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class CTPhieuNhapDAL
    {
        DatabaseHelper db = new DatabaseHelper();

        public DataTable GetByMaPN(int maPN)
        {
            string sql = "SELECT * FROM chitietphieunhap WHERE maphieunhap=@ma";

            return db.ExecuteQuery(sql,
                new MySqlParameter("@ma", maPN));
        }

        public void Update(int maCT, int maHang, int sl, double dg)
        {
            string sql = @"UPDATE chitietphieunhap
                           SET mahang=@mh, soluong=@sl, dongianhap=@dg
                           WHERE mactpn=@ma";

            db.ExecuteNonQuery(sql,
                new MySqlParameter("@mh", maHang),
                new MySqlParameter("@sl", sl),
                new MySqlParameter("@dg", dg),
                new MySqlParameter("@ma", maCT)
            );
        }
    }
}
