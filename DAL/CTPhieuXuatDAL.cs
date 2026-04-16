using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using DTO;

namespace DAL
{
    public class CTPhieuXuatDAL
    {
        DatabaseHelper db = new DatabaseHelper();

        public bool Insert(CTPhieuXuatDTO dto, int maPX)
        {
            // 1. Chèn chi tiết phiếu xuất
            string sqlInsert = @"INSERT INTO ChiTietPhieuXuat (Maphieuxuat, mahang, soluong, dongiaxuat) 
                               VALUES (@Maphieuxuat, @mahang, @soluong, @dongiaxuat)";

            MySqlParameter[] sqlParams = {
                new MySqlParameter("@Maphieuxuat", maPX),
                new MySqlParameter("@mahang", dto.MaHang),
                new MySqlParameter("@soluong", dto.SoLuong),
                new MySqlParameter("@dongiaxuat", dto.GiaXuat)
            };

            int result = db.ExecuteNonQuery(sqlInsert, sqlParams);

            // 2. Trừ kho: tonkhohientai = tonkhohientai - số lượng xuất
            if (result > 0)
            {
                string sqlUpdateKho = "UPDATE HangHoa SET tonkhohientai = tonkhohientai - @sl WHERE mahang = @mh";
                db.ExecuteNonQuery(sqlUpdateKho,
                    new MySqlParameter("@sl", dto.SoLuong),
                    new MySqlParameter("@mh", dto.MaHang));
                return true;
            }
            return false;
        }

        public void UpdateWithStock(int maCT, int maHang, int slMoi, decimal dg)
        {
            // 1. Lấy số lượng cũ để tính toán chênh lệch
            string sqlOld = "SELECT soluong FROM chitietphieuxuat WHERE machitiet = @ma";
            object oldVal = db.ExecuteScalar(sqlOld, new MySqlParameter("@ma", maCT));
            int slCu = (oldVal != null) ? Convert.ToInt32(oldVal) : 0;

            // 2. Cập nhật bảng chi tiết
            string sqlUpdate = @"UPDATE chitietphieuxuat  
                                SET mahang=@mh, soluong=@sl, dongiaxuat=@dg  
                                WHERE machitiet=@ma";

            db.ExecuteNonQuery(sqlUpdate,
                new MySqlParameter("@mh", maHang),
                new MySqlParameter("@sl", slMoi),
                new MySqlParameter("@dg", dg),
                new MySqlParameter("@ma", maCT));

            // 3. Cập nhật kho: tonkhohientai = tonkhohientai + (Số cũ - Số mới)
            int chênhLech = slCu - slMoi;
            string sqlStock = "UPDATE HangHoa SET tonkhohientai = tonkhohientai + @diff WHERE mahang = @mh";
            db.ExecuteNonQuery(sqlStock,
                new MySqlParameter("@diff", chênhLech),
                new MySqlParameter("@mh", maHang));
        }

        public void DeleteAndRestoreStock(int maPX)
        {
            // 1. Lấy danh sách để hoàn kho
            string sqlSelect = "SELECT mahang, soluong FROM chitietphieuxuat WHERE maphieuxuat = @ma";
            DataTable dt = db.ExecuteQuery(sqlSelect, new MySqlParameter("@ma", maPX));

            foreach (DataRow row in dt.Rows)
            {
                string maH = row["mahang"].ToString();
                int sl = Convert.ToInt32(row["soluong"]);

                // Cộng lại vào tonkhohientai
                string sqlRestore = "UPDATE HangHoa SET tonkhohientai = tonkhohientai + @sl WHERE mahang = @mh";
                db.ExecuteNonQuery(sqlRestore,
                    new MySqlParameter("@sl", sl),
                    new MySqlParameter("@mh", maH));
            }

            // 2. Xóa chi tiết
            string sqlDelete = "DELETE FROM chitietphieuxuat WHERE maphieuxuat = @ma";
            db.ExecuteNonQuery(sqlDelete, new MySqlParameter("@ma", maPX));
        }

        // --- Các hàm truy vấn dữ liệu ---

        public DataTable GetByMaPhieuXuat(int maPX)
        {
            string sql = "SELECT * FROM chitietphieuxuat WHERE maphieuxuat=@ma";
            return db.ExecuteQuery(sql, new MySqlParameter("@ma", maPX));
        }

        public DataTable GetListByMaPX(int maPX)
        {
            string sql = @"SELECT ct.*, h.tenhang 
                           FROM chitietphieuxuat ct 
                           INNER JOIN HangHoa h ON ct.mahang = h.mahang 
                           WHERE ct.maphieuxuat = @ma";
            return db.ExecuteQuery(sql, new MySqlParameter("@ma", maPX));
        }

        public double TinhTongTien(int maPX)
        {
            string sql = @"SELECT IFNULL(SUM(soluong * dongiaxuat),0)
                           FROM chitietphieuxuat
                           WHERE maphieuxuat=@ma";
            DataTable dt = db.ExecuteQuery(sql, new MySqlParameter("@ma", maPX));
            return Convert.ToDouble(dt.Rows[0][0]);
        }
    }
}