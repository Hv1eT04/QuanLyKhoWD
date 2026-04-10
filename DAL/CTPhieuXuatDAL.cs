using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace DAL
{
    public class CTPhieuXuatDAL
    {
        DatabaseHelper db = new DatabaseHelper();

        public DataTable GetByMaPhieuXuat(int maPX)
        {
            string sql = "SELECT * FROM chitietphieuxuat WHERE maphieuxuat=@ma";

            return db.ExecuteQuery(sql,
                new MySqlParameter("@ma", maPX));
        }
        public void Update(int maCT, int mahang, int sl, double dg)
        {
            string sql = @"UPDATE chitietphieuxuat  
            SET mahang=@mh, soluong=@sl, dongiaxuat=@dg  
            WHERE machitiet=@ma";

            db.ExecuteNonQuery(sql,
                new MySqlParameter("@mh", mahang),
                new MySqlParameter("@sl", sl),
                new MySqlParameter("@dg", dg),
                new MySqlParameter("@ma", maCT));
        }

        public double TinhTongTien(int maPX)
        {
            string sql = @"SELECT IFNULL(SUM(soluong * dongiaxuat),0)
                           FROM chitietphieuxuat
                           WHERE maphieuxuat=@ma";

            DataTable dt = db.ExecuteQuery(sql,
                new MySqlParameter("@ma", maPX));

            return Convert.ToDouble(dt.Rows[0][0]);
        }
        public DataTable GetByMaPX(int maPX)
        {
            string sql = "SELECT * FROM chitietphieuxuat WHERE maphieuxuat=@ma";

            return db.ExecuteQuery(sql,
                new MySqlParameter("@ma", maPX));
        }
        public void Insert(int maPX, int mahang, int sl, double dg)
        {
            string sql = @"INSERT INTO chitietphieuxuat
                   (maphieuxuat, mahang, soluong, dongiaxuat)
                   VALUES (@px, @mh, @sl, @dg)";

            db.ExecuteNonQuery(sql,
                new MySqlParameter("@px", maPX),
                new MySqlParameter("@mh", mahang),
                new MySqlParameter("@sl", sl),
                new MySqlParameter("@dg", dg)
            );
        }
    }
}
