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
        public bool Insert(CTPhieuXuatDTO dto, int maPX)
        {
            string sql = @"INSERT INTO ChiTietPhieuXuat (Maphieuxuat, mahang, soluong, dongiaxuat) 
                   VALUES (@Maphieuxuat, @mahang, @soluong, @dongiaxuat)";

            MySqlParameter[] sqlParams = {
                new MySqlParameter("@Maphieuxuat", maPX),
                new MySqlParameter("@mahang", dto.MaHang),
                new MySqlParameter("@soluong", dto.SoLuong),
                new MySqlParameter("@dongiaxuat", dto.GiaXuat)
            };

            return db.ExecuteNonQuery(sql, sqlParams) > 0;
        }
        public void DeleteByMaPX(int maPX)
        {
            string sql = "DELETE FROM chitietphieuxuat WHERE maphieuxuat = @ma";
            db.ExecuteNonQuery(sql, new MySqlParameter("@ma", maPX));
        }

        public DataTable GetListByMaPX(int maPX)
        {
            string sql = @"SELECT ct.*, h.tenhang 
                   FROM chitietphieuxuat ct 
                   INNER JOIN HangHoa h ON ct.mahang = h.mahang 
                   WHERE ct.maphieuxuat = @ma";

            return db.ExecuteQuery(sql, new MySqlParameter("@ma", maPX));
        }
    }
}
