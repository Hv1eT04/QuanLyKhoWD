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

        // 1. Lấy tất cả danh sách phiếu nhập
        public DataTable GetAll()
        {
            string sql = @"SELECT * FROM PhieuNhap";
            return db.ExecuteQuery(sql);
        }

        // 2. Xóa phiếu nhập (Xóa chi tiết trước, xóa phiếu sau)
        public bool Delete(int maPN)
        {
            try
            {
                // 1. Gọi CTPhieuNhapDAL để trừ lại số lượng trong kho
                CTPhieuNhapDAL ctDal = new CTPhieuNhapDAL();
                ctDal.DeleteAndReduceStock(maPN);

                // 2. Xóa phiếu chính
                string sqlMaster = "DELETE FROM phieunhap WHERE maphieunhap = @MaPN";
                return db.ExecuteNonQuery(sqlMaster, new MySqlParameter("@MaPN", maPN)) > 0;
            }
            catch { return false; }
        }

        // 3. Lấy ID người dùng từ tên (Dùng để map NguoiLap)
        public int GetUserIdByName(string hoTen)
        {
            string sql = "SELECT manguoidung FROM NguoiDung WHERE hoten = @hovaten LIMIT 1";
            MySqlParameter[] sqlParams = { new MySqlParameter("@hovaten", hoTen) };
            object result = db.ExecuteScalar(sql, sqlParams);
            return result != null ? Convert.ToInt32(result) : -1;
        }

        // 4. Thêm phiếu nhập và lấy ID vừa tạo (Có thêm MaNCC)
        public int InsertAndGetId(PhieuNhapDTO dto)
        {
            string sql = @"INSERT INTO PhieuNhap (SoPhieu, nguoilap, mancc, ngaytao, ghichu, trangthai) 
                           VALUES (@SoPhieu, @nguoilap, @mancc, @ngaytao, @ghichu, @trangthai);
                           SELECT LAST_INSERT_ID();";

            MySqlParameter[] sqlParams = {
                new MySqlParameter("@SoPhieu", dto.SoPhieu),
                new MySqlParameter("@nguoilap", dto.NguoiLap),
                new MySqlParameter("@mancc", dto.MaNCC),
                new MySqlParameter("@ngaytao", DateTime.Now),
                new MySqlParameter("@ghichu", dto.GhiChu),
                new MySqlParameter("@trangthai", dto.TrangThai)
            };

            object result = db.ExecuteScalar(sql, sqlParams);
            return result != null ? Convert.ToInt32(result) : -1;
        }

        // 5. Lấy mã ID lớn nhất hiện tại
        public int GetMaxMaPhieuNhap()
        {
            string sql = "SELECT IFNULL(MAX(MaPhieuNhap),0) FROM PhieuNhap";
            DataTable dt = db.ExecuteQuery(sql);
            return Convert.ToInt32(dt.Rows[0][0]);
        }

        // 6. Tính tổng tiền nhập hàng
        public object GetTongTien()
        {
            string sql = "SELECT SUM(soluong * dongianhap) FROM chitietphieunhap";
            return db.ExecuteScalar(sql);
        }

        // 7. Lấy thông tin phiếu nhập theo ID
        public DataTable GetById(int maPN)
        {
            string sql = "SELECT * FROM PhieuNhap WHERE MaPhieuNhap = @MaPN";
            return db.ExecuteQuery(sql, new MySqlParameter("@MaPN", maPN));
        }

        // 8. Cập nhật ghi chú và nhà cung cấp cho phiếu nhập
        public bool Update(PhieuNhapDTO dto)
        {
            string sql = @"UPDATE PhieuNhap SET ghichu = @ghichu, mancc = @mancc, trangthai = @trangthai 
                           WHERE MaPhieuNhap = @MaPN";
            MySqlParameter[] sqlParams = {
                new MySqlParameter("@ghichu", dto.GhiChu),
                new MySqlParameter("@mancc", dto.MaNCC),
                new MySqlParameter("@trangthai", dto.TrangThai),
                new MySqlParameter("@MaPN", dto.MaPhieuNhap)
            };
            return db.ExecuteNonQuery(sql, sqlParams) > 0;
        }

        // 9. Lấy số phiếu lớn nhất (để tự sinh số phiếu tiếp theo)
        public string GetMaxSoPhieu()
        {
            string sql = "SELECT MAX(SoPhieu) FROM PhieuNhap";
            object result = db.ExecuteScalar(sql);
            return result?.ToString();
        }
        public decimal GetGiaHienTai(string maHang)
        {
            // Lấy đơn giá nhập của lần nhập gần nhất dựa vào ID phiếu nhập lớn nhất
            string sql = @"SELECT dongianhap FROM chitietphieunhap 
                   WHERE mahang = @mahang 
                   ORDER BY MaPhieuNhap DESC LIMIT 1";

            object result = db.ExecuteScalar(sql, new MySqlParameter("@mahang", maHang));

            return result != null ? Convert.ToDecimal(result) : 0;
        }
    }
}