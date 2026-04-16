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
    public class CTPhieuNhapDAL
    {
        DatabaseHelper db = new DatabaseHelper();

        // 1. Lấy chi tiết theo mã phiếu nhập
        public DataTable GetByMaPhieuNhap(int maPN)
        {
            string sql = "SELECT * FROM chitietphieunhap WHERE maphieunhap=@ma";

            return db.ExecuteQuery(sql,
                new MySqlParameter("@ma", maPN));
        }

        // 2. Cập nhật chi tiết phiếu nhập
        public void Update(int maCT, int mahang, int sl, double dg)
        {
            string sql = @"UPDATE chitietphieunhap  
                           SET mahang=@mh, soluong=@sl, dongianhap=@dg  
                           WHERE machitiet=@ma";

            db.ExecuteNonQuery(sql,
                new MySqlParameter("@mh", mahang),
                new MySqlParameter("@sl", sl),
                new MySqlParameter("@dg", dg),
                new MySqlParameter("@ma", maCT));
        }

        // 3. Tính tổng tiền của phiếu nhập dựa trên mã phiếu
        public double TinhTongTien(int maPN)
        {
            string sql = @"SELECT IFNULL(SUM(soluong * dongianhap),0)
                           FROM chitietphieunhap
                           WHERE maphieunhap=@ma";

            DataTable dt = db.ExecuteQuery(sql,
                new MySqlParameter("@ma", maPN));

            return Convert.ToDouble(dt.Rows[0][0]);
        }

        // 4. Thêm mới một chi tiết phiếu nhập
        public bool Insert(CTPhieuNhapDTO dto, int maPN)
        {
            string sql = @"INSERT INTO chitietphieunhap (maphieunhap, mahang, soluong, dongianhap) 
                           VALUES (@maphieunhap, @mahang, @soluong, @dongianhap)";

            MySqlParameter[] sqlParams = {
                new MySqlParameter("@maphieunhap", maPN),
                new MySqlParameter("@mahang", dto.MaHang),
                new MySqlParameter("@soluong", dto.SoLuong),
                new MySqlParameter("@dongianhap", dto.GiaNhap)
            };

            return db.ExecuteNonQuery(sql, sqlParams) > 0;
        }

        // 5. Xóa tất cả chi tiết thuộc về một mã phiếu nhập
        public void DeleteByMaPN(int maPN)
        {
            string sql = "DELETE FROM chitietphieunhap WHERE maphieunhap = @ma";
            db.ExecuteNonQuery(sql, new MySqlParameter("@ma", maPN));
        }

        // 6. Lấy danh sách chi tiết kèm tên hàng hóa (Dùng cho hiển thị GridView)
        public DataTable GetListByMaPN(int maPN)
        {
            string sql = @"SELECT ct.*, h.tenhang 
                           FROM chitietphieunhap ct 
                           INNER JOIN HangHoa h ON ct.mahang = h.mahang 
                           WHERE ct.maphieunhap = @ma";

            return db.ExecuteQuery(sql, new MySqlParameter("@ma", maPN));
        }
    }
}