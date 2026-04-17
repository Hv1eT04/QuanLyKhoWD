using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Data;

namespace BLL
{
    public class PhieuNhapBLL
    {
        private PhieuNhapDAL dal = new PhieuNhapDAL();
        private CTPhieuNhapDAL dalCT = new CTPhieuNhapDAL();
        private HangHoaDAL dalHang = new HangHoaDAL();

        // Lấy danh sách phiếu nhập cho DataGridView chính
        public DataTable GetAllPhieuNhap() => dal.GetAll();

        // Lấy danh sách hàng hóa cho ComboBox trong Form Nhập
        public DataTable GetAllHangHoaCommon() => dalHang.GetAllHangHoaCommon();

        // Lấy thông tin một phiếu nhập cụ thể để đổ ngược lên Form khi Sửa/Xem
        public DataTable GetPhieuNhapByMaID(int maPN) => dal.GetById(maPN);

        /// <summary>
        /// Tạo số phiếu tự động (VD: PN001, PN002...)
        /// </summary>
        public string GetNextMaPhieuNhap() => TaoSoPhieu();

        /// <summary>
        /// LƯU MỚI: Nhận đối tượng DTO và Danh sách chi tiết.
        /// Giải quyết lỗi thiếu tham số maNguoiLap.
        /// </summary>
        public bool LuuPhieuHoanChinh(PhieuNhapDTO pn, List<CTPhieuNhapDTO> dsChiTiet)
        {
            try
            {
                // 1. Chèn phiếu master và lấy ID tự tăng vừa tạo trong DB
                int maPNVuaTao = dal.InsertAndGetId(pn);

                if (maPNVuaTao > 0)
                {
                    // 2. Duyệt danh sách để chèn chi tiết phiếu nhập
                    foreach (var ct in dsChiTiet)
                    {
                        dalCT.Insert(ct, maPNVuaTao);
                    }
                    return true;
                }
                return false;
            }
            catch (Exception )
            {
                // Ghi log lỗi nếu cần thiết
                return false;
            }
        }

        /// <summary>
        /// CẬP NHẬT: Nhận đủ 4 tham số khớp hoàn toàn với lời gọi từ GUI.
        /// </summary>
        public bool CapNhatPhieu(int maPN, string ghiChu, int maNCC, List<CTPhieuNhapDTO> dsChiTiet)
        {
            try
            {
                // 1. Cập nhật thông tin phần đầu phiếu (Master)
                PhieuNhapDTO phieu = new PhieuNhapDTO
                {
                    MaPhieuNhap = maPN,
                    GhiChu = ghiChu,
                    MaNCC = maNCC,
                    TrangThai = 1
                };

                bool updateMaster = dal.Update(phieu);

                if (updateMaster)
                {
                    // 2. Xóa các chi tiết cũ của phiếu này để tránh trùng lặp hoặc rác dữ liệu
                    dalCT.DeleteAndReduceStock(maPN);

                    // 3. Chèn lại danh sách chi tiết mới sau khi chỉnh sửa
                    foreach (var ct in dsChiTiet)
                    {
                        dalCT.Insert(ct, maPN);
                    }
                    return true;
                }
                return false;
            }
            catch (Exception)
            {
                return false;
            }
        }

        /// <summary>
        /// XÓA PHIẾU: Đã sửa từ void thành bool để khớp với logic xử lý kết quả.
        /// </summary>
        public bool Delete(int maPN)
        {
            try
            {
                // Xóa chi tiết trước để tránh vi phạm ràng buộc khóa ngoại (Foreign Key)
                dalCT.DeleteAndReduceStock(maPN);

                // Sau đó mới xóa phiếu chính
                return dal.Delete(maPN);
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// Logic sinh mã phiếu tự động
        /// </summary>
        public string TaoSoPhieu()
        {
            string max = dal.GetMaxSoPhieu();
            if (string.IsNullOrEmpty(max))
                return "PN001";

            try
            {
                // Tách phần số từ chuỗi PNxxx
                string partNum = max.Replace("PN", "");
                int num = int.Parse(partNum);
                return "PN" + (num + 1).ToString("D3");
            }
            catch
            {
                // Trường hợp mã cũ không theo quy chuẩn, sinh mã theo ngày
                return "PN" + DateTime.Now.ToString("yyyyMMdd") + "01";
            }
        }

        /// <summary>
        /// Lấy tổng tiền toàn bộ các phiếu nhập (nếu cần hiển thị thống kê)
        /// </summary>
        public decimal GetTongTien()
        {
            object result = dal.GetTongTien();
            if (result == null || result == DBNull.Value)
                return 0;

            return Convert.ToDecimal(result);
        }
        public decimal GetGiaHienTai(string maHang)
        {
            return dal.GetGiaHienTai(maHang);
        }
    }
}