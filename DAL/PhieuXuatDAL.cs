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
            string sqlDetail = "DELETE FROM chitietphieuxuat WHERE maphieuxuat = @MaPX";
            db.ExecuteNonQuery(sqlDetail, new MySqlParameter("@MaPX", maPX));

            string sqlMaster = "DELETE FROM phieuxuat WHERE maphieuxuat = @MaPX";
            db.ExecuteNonQuery(sqlMaster, new MySqlParameter("@MaPX", maPX));
        }
        public int GetUserIdByName(string hoTen)
        {
            string sql = "SELECT manguoidung FROM NguoiDung WHERE hoten = @hovaten LIMIT 1";
            MySqlParameter[] sqlParams = { new MySqlParameter("@hovaten", hoTen) };
            object result = db.ExecuteScalar(sql, sqlParams);
            return result != null ? Convert.ToInt32(result) : -1;
        }

        public int InsertAndGetId(PhieuXuatDTO dto)
        {
            int idNguoiLap = GetUserIdByName(dto.TenNguoiXuat);
            if (idNguoiLap == -1) return -1;

            string sql = @"INSERT INTO PhieuXuat (SoPhieu, nguoilap, ngaytao, ghichu, trangthai) 
                   VALUES (@SoPhieu, @nguoilap, @ngaytao, @ghichu, @trangthai);
                   SELECT LAST_INSERT_ID();";

            MySqlParameter[] sqlParams = {
                new MySqlParameter("@sophieu", dto.SoPhieu),
                new MySqlParameter("@nguoilap", idNguoiLap),
                new MySqlParameter("@ngaytao", DateTime.Now),
                new MySqlParameter("@ghichu", dto.GhiChu),
                new MySqlParameter("@trangthai", "hoanthanh")
            };

            object result = db.ExecuteScalar(sql, sqlParams);
            return result != null ? Convert.ToInt32(result) : -1;
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
        public DataTable GetById(int maPX)
        {
            string sql = "SELECT * FROM PhieuXuat WHERE MaPhieuXuat = @MaPX";
            return db.ExecuteQuery(sql, new MySqlParameter("@MaPX", maPX));
        }

        public bool Update(int maPX, string ghiChu)
        {
            string sql = "UPDATE PhieuXuat SET ghichu = @ghichu WHERE MaPhieuXuat = @MaPX";
            MySqlParameter[] sqlParams = {
        new MySqlParameter("@ghichu", ghiChu),
        new MySqlParameter("@MaPX", maPX)
    };
            return db.ExecuteNonQuery(sql, sqlParams) > 0;
        }
    }
}