using DTO;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
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
            string sql = @"INSERT INTO PhieuNhap
                   (SoPhieu, NguoiLap, MaNCC, TrangThai, NgayTao, GhiChu)
                   VALUES
                   (@sp, @nl, @ncc, @tt, @ngay, @gc)";

            return db.ExecuteNonQuery(sql,
                new MySqlParameter("@sp", dto.SoPhieu),
                new MySqlParameter("@nl", dto.NguoiLap),
                new MySqlParameter("@ncc", dto.MaNCC),
                new MySqlParameter("@tt", dto.TrangThai),
                new MySqlParameter("@ngay", DateTime.Now),
                new MySqlParameter("@gc", dto.GhiChu)
            );
        }

        public int Delete(int maPN)
        {
            string sql1 = "DELETE FROM chitietphieunhap WHERE maphieunhap=@ma";
            db.ExecuteNonQuery(sql1,
                new MySqlParameter("@ma", maPN)
            );

            string sql2 = "DELETE FROM PhieuNhap WHERE MaPhieuNhap=@ma";
            return db.ExecuteNonQuery(sql2,
                new MySqlParameter("@ma", maPN)
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
        public PhieuNhapDTO GetById(int maPN)
        {
            string sql = "SELECT * FROM PhieuNhap WHERE MaPhieuNhap = @ma";

            DataTable dt = db.ExecuteQuery(sql,
                new MySqlParameter("@ma", maPN)
            );

            if (dt.Rows.Count == 0)
                return null;

            DataRow row = dt.Rows[0];

            return new PhieuNhapDTO
            {
                MaPhieuNhap = Convert.ToInt32(row["MaPhieuNhap"]),
                SoPhieu = row["SoPhieu"].ToString(),
                NguoiLap = Convert.ToInt32(row["NguoiLap"]),
                MaNCC = Convert.ToInt32(row["MaNCC"]),
                TrangThai = Convert.ToInt32(row["TrangThai"]),
                NgayTao = Convert.ToDateTime(row["NgayTao"]),
                GhiChu = row["GhiChu"].ToString()
            };
        }
        public int InsertAndGetId(PhieuNhapDTO pn)
        {
            string sql = @"
        INSERT INTO PhieuNhap(SoPhieu, GhiChu, MaNCC, TrangThai, NgayTao, NguoiLap)
        VALUES (@sp, @gc, @ncc, @tt, @ngay, @nl);
        SELECT LAST_INSERT_ID();";

            DataTable dt = db.ExecuteQuery(sql,
                new MySqlParameter("@sp", pn.SoPhieu),
                new MySqlParameter("@gc", pn.GhiChu),
                new MySqlParameter("@ncc", pn.MaNCC),
                new MySqlParameter("@tt", pn.TrangThai),
                new MySqlParameter("@ngay", DateTime.Now),
                new MySqlParameter("@nl", pn.NguoiLap)
            );

            return Convert.ToInt32(dt.Rows[0][0]);
        }
        public string GetMaxSoPhieu()
        {
            string sql = "SELECT MAX(SoPhieu) FROM PhieuNhap";
            return db.ExecuteScalar(sql)?.ToString();
        }
    }
}
