using DTO;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;

namespace DAL
{
    public class PhieuXuatDAL
    {
        DatabaseHelper db = new DatabaseHelper();

        public DataTable GetAll()
        {
            string sql = @"SELECT * FROM PhieuXuat";

            return db.ExecuteQuery(sql);
        }
        public void Delete(int maPX)
        {
            string sql = "DELETE FROM PhieuXuat WHERE MaPhieuXuat = @MaPX";

            db.ExecuteNonQuery(sql,
                new MySqlParameter("@MaPX", maPX)
            );
        }
        public void Insert(PhieuXuatDTO dto)
        {
            string sql = @"INSERT INTO PhieuXuat
    (MaPhieuXuat, SoPhieu, NguoiLap, NgayTao, GhiChu, TrangThai)
    VALUES (@MaPX, @SoPhieu, @NguoiLap, @NgayTao, @GhiChu, @TrangThai)";

            db.ExecuteNonQuery(sql,
                new MySqlParameter("@MaPX", dto.MaPhieuXuat),
                new MySqlParameter("@SoPhieu", dto.SoPhieu),
                new MySqlParameter("@NguoiLap", dto.NguoiLap),
                new MySqlParameter("@NgayTao", dto.NgayTao),
                new MySqlParameter("@GhiChu", dto.GhiChu),
                new MySqlParameter("@TrangThai", dto.TrangThai)
            );
        }
        public int GetMaxMaPhieuXuat()
        {
            string sql = "SELECT IFNULL(MAX(MaPhieuXuat),0) FROM PhieuXuat";
            DataTable dt = db.ExecuteQuery(sql);
            return Convert.ToInt32(dt.Rows[0][0]);
        }
        public object GetTongTien()
        {
            string sql = "SELECT SUM(soluong * dongiaxuat) FROM chitietphieuxuat";
            return db.ExecuteScalar(sql);
        }
    }
}