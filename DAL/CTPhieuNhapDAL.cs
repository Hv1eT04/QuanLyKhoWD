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
        public void UpdateWithStock(int maCT, int maHang, int slMoi, double dg)
        {
            // Lấy số lượng cũ để tính toán
            string sqlOld = "SELECT soluong FROM chitietphieunhap WHERE machitiet = @ma";
            object oldVal = db.ExecuteScalar(sqlOld, new MySqlParameter("@ma", maCT));
            int slCu = (oldVal != null) ? Convert.ToInt32(oldVal) : 0;

            // Cập nhật bảng chi tiết
            string sqlUpdate = @"UPDATE chitietphieunhap SET mahang=@mh, soluong=@sl, dongianhap=@dg WHERE machitiet=@ma";
            db.ExecuteNonQuery(sqlUpdate,
                new MySqlParameter("@mh", maHang),
                new MySqlParameter("@sl", slMoi),
                new MySqlParameter("@dg", dg),
                new MySqlParameter("@ma", maCT));

            // Cập nhật kho: Kho_Moi = Kho_HT - SL_Cu + SL_Moi
            int chênhLech = slMoi - slCu;
            string sqlStock = "UPDATE HangHoa SET tonkhohientai = tonkhohientai + @diff WHERE mahang = @mh";
            db.ExecuteNonQuery(sqlStock, new MySqlParameter("@diff", chênhLech), new MySqlParameter("@mh", maHang));
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
            // 1. Lấy thông tin bản gốc - maHangThucTe khai báo là string để khớp với dto.MaHang
            string maHangThucTe = dto.MaHang.ToString();

            string sqlGetGoc = "SELECT * FROM HangHoa WHERE mahang = @mh";
            DataTable dt = db.ExecuteQuery(sqlGetGoc, new MySqlParameter("@mh", maHangThucTe));

            if (dt != null && dt.Rows.Count > 0)
            {
                decimal giaHienTai = Convert.ToDecimal(dt.Rows[0]["dongiaban"]);

                // Nếu giá nhập khác giá hiện tại trong kho
                if (giaHienTai != dto.GiaNhap)
                {
                    // Tăng macode và đổi tên hàng
                    string newMaCode = GenerateRandomMaCode(dt.Rows[0]["macode"].ToString());
                    string newTenHang = GenerateNextTenHang(dt.Rows[0]["tenhang"].ToString());

                    string sqlInsertNewHang = @"INSERT INTO HangHoa (macode, tenhang, madanhmuc, donvitinh, dongiaban, tonkhohientai, muccanhbao, trangthai) 
                                       VALUES (@macode, @tenhang, @madanhmuc, @donvitinh, @dongiaban, 0, @muccanhbao, @trangthai);
                                       SELECT LAST_INSERT_ID();";

                    MySqlParameter[] paramsNewHang = {
                new MySqlParameter("@macode", newMaCode),
                new MySqlParameter("@tenhang", newTenHang),
                new MySqlParameter("@madanhmuc", dt.Rows[0]["madanhmuc"]),
                new MySqlParameter("@donvitinh", dt.Rows[0]["donvitinh"]),
                new MySqlParameter("@dongiaban", dto.GiaNhap),
                new MySqlParameter("@muccanhbao", dt.Rows[0]["muccanhbao"]),
                new MySqlParameter("@trangthai", dt.Rows[0]["trangthai"])
            };

                    object newId = db.ExecuteScalar(sqlInsertNewHang, paramsNewHang);
                    if (newId != null)
                    {
                        // SỬA LỖI TẠI ĐÂY: Chuyển ID mới về string
                        maHangThucTe = newId.ToString();
                    }
                }
            }

            // 2. Thêm vào bảng Chi Tiết Phiếu Nhập
            string sqlInsertCT = @"INSERT INTO chitietphieunhap (maphieunhap, mahang, soluong, dongianhap) 
                           VALUES (@maphieunhap, @mahang, @soluong, @dongianhap)";

            MySqlParameter[] sqlParams = {
        new MySqlParameter("@maphieunhap", maPN),
        new MySqlParameter("@mahang", maHangThucTe),
        new MySqlParameter("@soluong", dto.SoLuong),
        new MySqlParameter("@dongianhap", dto.GiaNhap)
    };

            int result = db.ExecuteNonQuery(sqlInsertCT, sqlParams);

            // 3. Cập nhật tồn kho
            if (result > 0)
            {
                string sqlUpdateKho = "UPDATE HangHoa SET tonkhohientai = tonkhohientai + @sl WHERE mahang = @mh";
                db.ExecuteNonQuery(sqlUpdateKho,
                    new MySqlParameter("@sl", dto.SoLuong),
                    new MySqlParameter("@mh", maHangThucTe));
                return true;
            }
            return false;
        }

        private string GenerateRandomMaCode(string currentCode)
        {
            string prefix = new string(currentCode.TakeWhile(c => !char.IsDigit(c)).ToArray());
            if (string.IsNullOrEmpty(prefix)) prefix = "HH";

            Random rd = new Random();
            int randomNumber = rd.Next(100000, 999999);

            return prefix + randomNumber.ToString();
        }

        private string GenerateNextTenHang(string currentName)
        {
            string tenGoc = currentName;
            if (currentName.Contains(" - "))
            {
                tenGoc = currentName.Split(new[] { " - " }, StringSplitOptions.None)[0];
            }

            string randomSuffix = Guid.NewGuid().ToString().Substring(0, 4).ToUpper();

            return $"{tenGoc} - {randomSuffix}";
        }

        // 5. Xóa tất cả chi tiết thuộc về một mã phiếu nhập
        public void DeleteAndReduceStock(int maPN)
        {
            // Lấy danh sách hàng đã nhập để TRỪ lại kho
            string sqlSelect = "SELECT mahang, soluong FROM chitietphieunhap WHERE maphieunhap = @ma";
            DataTable dt = db.ExecuteQuery(sqlSelect, new MySqlParameter("@ma", maPN));

            foreach (DataRow row in dt.Rows)
            {
                string sqlReduce = "UPDATE HangHoa SET tonkhohientai = tonkhohientai - @sl WHERE mahang = @mh";
                db.ExecuteNonQuery(sqlReduce,
                    new MySqlParameter("@sl", row["soluong"]),
                    new MySqlParameter("@mh", row["mahang"]));
            }

            // Xóa các dòng chi tiết
            string sqlDelete = "DELETE FROM chitietphieunhap WHERE maphieunhap = @ma";
            db.ExecuteNonQuery(sqlDelete, new MySqlParameter("@ma", maPN));
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