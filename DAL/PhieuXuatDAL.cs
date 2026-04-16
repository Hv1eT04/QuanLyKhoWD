using DTO;
using MySql.Data.MySqlClient;
using System;
using System.Data;

namespace DAL
{
    public class PhieuXuatDAL
    {
        DatabaseHelper db = new DatabaseHelper();

        public DataTable GetAll()
        {
            string sql = @"SELECT * FROM PhieuXuat ORDER BY ngaytao DESC";
            return db.ExecuteQuery(sql);
        }

        public DataTable GetById(int maPX)
        {
            string sql = "SELECT * FROM PhieuXuat WHERE MaPhieuXuat = @MaPX";
            return db.ExecuteQuery(sql, new MySqlParameter("@MaPX", maPX));
        }

        // THÊM MỚI PHIẾU
        public int InsertAndGetId(PhieuXuatDTO dto)
        {
            int idNguoiLap = GetUserIdByName(dto.TenNguoiXuat);
            if (idNguoiLap == -1) return -1;

            string sql = @"INSERT INTO PhieuXuat (SoPhieu, nguoilap, ngaytao, ghichu, trangthai) 
                           VALUES (@SoPhieu, @nguoilap, @ngaytao, @ghichu, @trangthai);
                           SELECT LAST_INSERT_ID();";

            MySqlParameter[] sqlParams = {
                new MySqlParameter("@SoPhieu", dto.SoPhieu),
                new MySqlParameter("@nguoilap", idNguoiLap),
                new MySqlParameter("@ngaytao", DateTime.Now),
                new MySqlParameter("@ghichu", dto.GhiChu),
                new MySqlParameter("@trangthai", "hoanthanh")
            };

            object result = db.ExecuteScalar(sql, sqlParams);
            return result != null ? Convert.ToInt32(result) : -1;
        }

        // CẬP NHẬT THÔNG TIN CHUNG
        public bool Update(int maPX, string ghiChu)
        {
            string sql = "UPDATE PhieuXuat SET ghichu = @ghichu WHERE MaPhieuXuat = @MaPX";
            MySqlParameter[] sqlParams = {
                new MySqlParameter("@ghichu", ghiChu),
                new MySqlParameter("@MaPX", maPX)
            };
            return db.ExecuteNonQuery(sql, sqlParams) > 0;
        }

        // XÓA PHIẾU: Gọi hoàn kho trước khi xóa phiếu chính
        public void Delete(int maPX)
        {
            // 1. Hoàn trả số lượng hàng vào kho và xóa chi tiết
            CTPhieuXuatDAL ctDal = new CTPhieuXuatDAL();
            ctDal.DeleteAndRestoreStock(maPX);

            // 2. Xóa phiếu chính
            string sqlMaster = "DELETE FROM phieuxuat WHERE maphieuxuat = @MaPX";
            db.ExecuteNonQuery(sqlMaster, new MySqlParameter("@MaPX", maPX));
        }

        public int GetUserIdByName(string hoTen)
        {
            string sql = "SELECT manguoidung FROM NguoiDung WHERE hoten = @hovaten LIMIT 1";
            object result = db.ExecuteScalar(sql, new MySqlParameter("@hovaten", hoTen));
            return result != null ? Convert.ToInt32(result) : -1;
        }

        public object GetTongTien()
        {
            string sql = "SELECT SUM(soluong * dongiaxuat) FROM chitietphieuxuat";
            return db.ExecuteScalar(sql);
        }
    }
}