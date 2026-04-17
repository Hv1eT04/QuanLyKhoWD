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
            // Bước 1: Lấy tên gốc của mặt hàng được chọn để tìm các phiên bản cùng tên
            string sqlGetTen = "SELECT tenhang FROM HangHoa WHERE mahang = @mh";
            object tenObj = db.ExecuteScalar(sqlGetTen, new MySqlParameter("@mh", dto.MaHang));
            if (tenObj == null) return false;

            // Lấy phần tên chính (loại bỏ phần " - 1", " - 2" nếu có để tìm chính xác các phiên bản)
            string tenGoc = tenObj.ToString();
            if (tenGoc.Contains(" - "))
            {
                tenGoc = tenGoc.Split(new[] { " - " }, StringSplitOptions.None)[0];
            }

            // Bước 2: Tìm tất cả phiên bản có giá bán <= giá xuất và còn hàng, sắp xếp theo mã hàng cũ trước
            string sqlGetPhienBan = @"SELECT mahang, tonkhohientai FROM HangHoa 
                              WHERE tenhang LIKE @ten AND dongiaban <= @giaXuat AND tonkhohientai > 0
                              ORDER BY mahang ASC";

            DataTable dtPhienBan = db.ExecuteQuery(sqlGetPhienBan,
                new MySqlParameter("@ten", tenGoc + "%"),
                new MySqlParameter("@giaXuat", dto.GiaXuat));

            // Bước 3: Kiểm tra tổng số lượng có đủ xuất không
            long tongTonKho = 0;
            foreach (DataRow row in dtPhienBan.Rows)
            {
                tongTonKho += Convert.ToInt64(row["tonkhohientai"]);
            }

            if (tongTonKho < dto.SoLuong)
            {
                // Bạn có thể ném ra một Exception hoặc trả về false để báo lỗi không đủ hàng
                throw new Exception($"Không đủ hàng trong kho. Tổng tồn các phiên bản chỉ còn: {tongTonKho}");
            }

            // Bước 4: Chèn chi tiết phiếu xuất (Lưu mã hàng chính mà người dùng chọn)
            string sqlInsert = @"INSERT INTO ChiTietPhieuXuat (Maphieuxuat, mahang, soluong, dongiaxuat) 
                         VALUES (@Maphieuxuat, @mahang, @soluong, @dongiaxuat)";

            MySqlParameter[] sqlParams = {
        new MySqlParameter("@Maphieuxuat", maPX),
        new MySqlParameter("@mahang", dto.MaHang),
        new MySqlParameter("@soluong", dto.SoLuong),
        new MySqlParameter("@dongiaxuat", dto.GiaXuat)
    };
            db.ExecuteNonQuery(sqlInsert, sqlParams);

            // Bước 5: Thực hiện trừ kho dần dần trên các phiên bản
            int soLuongCanTru = dto.SoLuong;
            foreach (DataRow row in dtPhienBan.Rows)
            {
                if (soLuongCanTru <= 0) break;

                string maH = row["mahang"].ToString();
                int tonHienTai = Convert.ToInt32(row["tonkhohientai"]);
                int soLuongTru = Math.Min(tonHienTai, soLuongCanTru);

                string sqlUpdateKho = "UPDATE HangHoa SET tonkhohientai = tonkhohientai - @sl WHERE mahang = @mh";
                db.ExecuteNonQuery(sqlUpdateKho,
                    new MySqlParameter("@sl", soLuongTru),
                    new MySqlParameter("@mh", maH));

                soLuongCanTru -= soLuongTru;
            }

            return true;
        }

        public void UpdateWithStock(int maCT, int maHang, int slMoi, decimal dg)
        {
            // --- BƯỚC 1: HOÀN KHO (Restore) ---
            // Lấy thông tin cũ trước khi update
            string sqlOldData = "SELECT mahang, soluong, dongiaxuat FROM chitietphieuxuat WHERE machitiet = @ma";
            DataTable dtOld = db.ExecuteQuery(sqlOldData, new MySqlParameter("@ma", maCT));

            if (dtOld == null || dtOld.Rows.Count == 0) return;

            string maHangCu = dtOld.Rows[0]["mahang"].ToString();
            int slCu = Convert.ToInt32(dtOld.Rows[0]["soluong"]);
            decimal giaXuatCu = Convert.ToDecimal(dtOld.Rows[0]["dongiaxuat"]);

            // Hoàn lại số lượng cũ vào kho (Tìm lại các phiên bản đã trừ)
            // Lưu ý: Vì không có bảng lịch sử trừ mã nào, ta hoàn lại dựa trên tên của mã hàng cũ
            string tenGocCu = GetTenGoc(maHangCu);
            RestoreStock(tenGocCu, slCu, giaXuatCu);

            // --- BƯỚC 2: KIỂM TRA TỒN KHO MỚI ---
            string tenGocMoi = GetTenGoc(maHang.ToString());
            string sqlCheckMoi = @"SELECT mahang, tonkhohientai FROM HangHoa 
                           WHERE tenhang LIKE @ten AND dongiaban <= @dg AND tonkhohientai > 0
                           ORDER BY mahang ASC";
            DataTable dtPhienBanMoi = db.ExecuteQuery(sqlCheckMoi,
                new MySqlParameter("@ten", tenGocMoi + "%"),
                new MySqlParameter("@dg", dg));

            long tongTonHienTai = 0;
            foreach (DataRow r in dtPhienBanMoi.Rows) tongTonHienTai += Convert.ToInt64(r["tonkhohientai"]);

            if (tongTonHienTai < slMoi)
            {
                // Nếu không đủ, ta phải hoàn lại số lượng cũ đã lấy ra ở Bước 1 và báo lỗi
                // (Hoặc đơn giản là throw exception để UI xử lý)
                throw new Exception($"Cập nhật thất bại. Tổng kho phiên bản mới không đủ (Chỉ còn: {tongTonHienTai})");
            }

            // --- BƯỚC 3: CẬP NHẬT BẢNG CHI TIẾT ---
            string sqlUpdateCT = @"UPDATE chitietphieuxuat SET mahang=@mh, soluong=@sl, dongiaxuat=@dg WHERE machitiet=@ma";
            db.ExecuteNonQuery(sqlUpdateCT,
                new MySqlParameter("@mh", maHang),
                new MySqlParameter("@sl", slMoi),
                new MySqlParameter("@dg", dg),
                new MySqlParameter("@ma", maCT));

            // --- BƯỚC 4: TRỪ KHO MỚI (FIFO) ---
            int soLuongCanTru = slMoi;
            foreach (DataRow row in dtPhienBanMoi.Rows)
            {
                if (soLuongCanTru <= 0) break;
                string maH = row["mahang"].ToString();
                int tonHienTai = Convert.ToInt32(row["tonkhohientai"]);
                int soLuongTru = Math.Min(tonHienTai, soLuongCanTru);

                db.ExecuteNonQuery("UPDATE HangHoa SET tonkhohientai = tonkhohientai - @sl WHERE mahang = @mh",
                    new MySqlParameter("@sl", soLuongTru),
                    new MySqlParameter("@mh", maH));
                soLuongCanTru -= soLuongTru;
            }
        }

        // Hàm hỗ trợ lấy tên gốc (Bút bi - 1 -> Bút bi)
        private string GetTenGoc(string maHang)
        {
            object res = db.ExecuteScalar("SELECT tenhang FROM HangHoa WHERE mahang = @mh", new MySqlParameter("@mh", maHang));
            if (res == null) return "";
            string ten = res.ToString();
            return ten.Contains(" - ") ? ten.Split(new[] { " - " }, StringSplitOptions.None)[0] : ten;
        }

        // Hàm hoàn kho cho các phiên bản (Cộng ngược lại theo thứ tự ID mới nhất trước để ưu tiên trả hàng mới)
        private void RestoreStock(string tenGoc, int soLuongHoan, decimal giaXuat)
        {
            string sql = @"SELECT mahang FROM HangHoa WHERE tenhang LIKE @ten AND dongiaban <= @gia ORDER BY mahang DESC";
            DataTable dt = db.ExecuteQuery(sql, new MySqlParameter("@ten", tenGoc + "%"), new MySqlParameter("@gia", giaXuat));

            int conLai = soLuongHoan;
            foreach (DataRow r in dt.Rows)
            {
                if (conLai <= 0) break;
                // Vì ta không lưu lịch sử từng mã đã trừ bao nhiêu, nên tạm thời cộng hết vào mã đầu tiên tìm thấy 
                // hoặc chia đều. Ở đây ta cộng vào mã hàng chính tìm được để đảm bảo tổng tồn kho khớp.
                db.ExecuteNonQuery("UPDATE HangHoa SET tonkhohientai = tonkhohientai + @sl WHERE mahang = @mh",
                    new MySqlParameter("@sl", conLai),
                    new MySqlParameter("@mh", r["mahang"]));
                break; // Cộng dồn vào mã hợp lệ đầu tiên để đơn giản hóa
            }
        }

        public void DeleteAndRestoreStock(int maPX)
        {
            // 1. Lấy danh sách các chi tiết phiếu xuất cần xóa để hoàn kho
            // Lấy thêm dongiaxuat để biết nhóm phiên bản nào cần được cộng trả
            string sqlSelect = "SELECT mahang, soluong, dongiaxuat FROM chitietphieuxuat WHERE maphieuxuat = @ma";
            DataTable dt = db.ExecuteQuery(sqlSelect, new MySqlParameter("@ma", maPX));

            if (dt != null && dt.Rows.Count > 0)
            {
                foreach (DataRow row in dt.Rows)
                {
                    string maH = row["mahang"].ToString();
                    int slHoan = Convert.ToInt32(row["soluong"]);
                    decimal giaXuat = Convert.ToDecimal(row["dongiaxuat"]);

                    // 2. Lấy tên gốc của mặt hàng (VD: "Bút bi - 1" -> "Bút bi")
                    string tenGoc = GetTenGoc(maH);

                    // 3. Tìm các phiên bản cùng tên để hoàn kho
                    // Ưu tiên hoàn vào các mã có ID lớn nhất trước (hàng mới về sau thường được ưu tiên hoàn lại)
                    string sqlFindVersions = @"SELECT mahang FROM HangHoa 
                                       WHERE tenhang LIKE @ten AND dongiaban <= @gia 
                                       ORDER BY mahang DESC";

                    DataTable dtVersions = db.ExecuteQuery(sqlFindVersions,
                        new MySqlParameter("@ten", tenGoc + "%"),
                        new MySqlParameter("@gia", giaXuat));

                    if (dtVersions.Rows.Count > 0)
                    {
                        // Cộng toàn bộ số lượng hoàn vào mã hợp lệ đầu tiên tìm thấy 
                        // Điều này đảm bảo Tổng Tồn Kho của loại hàng đó chính xác.
                        string maHToRestore = dtVersions.Rows[0]["mahang"].ToString();

                        string sqlRestore = "UPDATE HangHoa SET tonkhohientai = tonkhohientai + @sl WHERE mahang = @mh";
                        db.ExecuteNonQuery(sqlRestore,
                            new MySqlParameter("@sl", slHoan),
                            new MySqlParameter("@mh", maHToRestore));
                    }
                    else
                    {
                        // Trường hợp không tìm thấy phiên bản nào khớp (hiếm khi xảy ra), cộng vào chính nó
                        string sqlRestoreFallback = "UPDATE HangHoa SET tonkhohientai = tonkhohientai + @sl WHERE mahang = @mh";
                        db.ExecuteNonQuery(sqlRestoreFallback,
                            new MySqlParameter("@sl", slHoan),
                            new MySqlParameter("@mh", maH));
                    }
                }
            }

            // 4. Sau khi hoàn kho xong mới xóa chi tiết phiếu xuất
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