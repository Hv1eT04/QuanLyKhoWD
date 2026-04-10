using DTO;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
namespace DAL
{
    public class PhieuNhapDAL
    {
        DatabaseHelper db = new DatabaseHelper();

        public DataTable GetAll()
        {
            string sql = "SELECT * FROM PhieuNhap";
            return db.ExecuteQuery(sql);
        }
        public int Insert(PhieuNhapDTO dto)
        {
            string sql = @"INSERT INTO PhieuNhap (MaPhieuNhap, SoPhieu, NguoiLap, MaNCC, TrangThai, NgayTao, GhiChu) 
                   VALUES (@MaPhieuNhap, @SoPhieu, @NguoiLap, @MaNCC, @TrangThai, @NgayTao, @GhiChu)";
            return db.ExecuteNonQuery(sql,
                new MySqlParameter("@MaPhieuNhap", dto.MaPhieuNhap),
                new MySqlParameter("@SoPhieu", dto.SoPhieu),
                new MySqlParameter("@NguoiLap", dto.NguoiLap),
                new MySqlParameter("@MaNCC", dto.MaNCC),
                new MySqlParameter("@TrangThai", dto.TrangThai),
                new MySqlParameter("@NgayTao", dto.NgayTao),
                new MySqlParameter("@GhiChu", dto.GhiChu)
            );
        }
        public void Delete(string maPN)
        {
            string sql = "DELETE FROM PhieuNhap WHERE MaPhieuNhap = @MaPN";

            db.ExecuteNonQuery(sql,
                new MySqlParameter("@MaPN", maPN)
            );
        }
        public int GetMaxMaPhieuNhap()
        {
            string sql = "SELECT IFNULL(MAX(MaPhieuNhap),0) FROM PhieuNhap";
            DataTable dt = db.ExecuteQuery(sql);
            return Convert.ToInt32(dt.Rows[0][0]);
        }
        public int Update(PhieuNhapDTO dto)
        {
            string sql = @"UPDATE PhieuNhap 
                   SET sophieu = @sophieu,
                       ghichu = @ghichu,
                       trangthai = @trangthai,
                        mancc = @mancc
                   WHERE maphieunhap = @mapn";

                return db.ExecuteNonQuery(sql,
                new MySqlParameter("@sophieu", dto.SoPhieu),
                new MySqlParameter("@ghichu", dto.GhiChu),
                new MySqlParameter("@trangthai", dto.TrangThai),
                new MySqlParameter("@mancc", dto.MaNCC),
                new MySqlParameter("@mapn", dto.MaPhieuNhap)
            );
        }
    }
}
