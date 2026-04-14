using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using DTO;
using System.Data;

namespace BLL
{
    public class HangHoaBLL
    {
       HangHoaDAL dal = new HangHoaDAL();
        public DataTable GetAllHangHoa()
        {
            return dal.GetAllHangHoa();
        }
        public DataTable TimKiemHangHoa(string keyword)
        {
            return dal.TimKiemHangHoa(keyword);
        }
        public string TaoMaCode()
        {
            DataTable dt = dal.GetAllHangHoa();
            int stt = dt.Rows.Count + 1;
            return "HH" + stt.ToString("000");
        }
        public int ThemHangHoa(HangHoaDTO hh)
        {
            string loi = KiemTraDuLieu(hh);
            if (loi != "")
                throw new Exception(loi);

            CapNhatTrangThai(hh); // 🔥 tự động trạng thái

            return dal.ThemHangHoa(hh);
        }
        public int SuaHangHoa(HangHoaDTO hh)
        {
            return dal.SuaHangHoa(hh);
        }
        public int Ngungkinhdoanh(string maCode)
        {
            return dal.Ngungkinhdoanh(maCode);
        }
        public int KhoiPhucHangHoa(string maCode)
        {
            return dal.KhoiPhucHangHoa(maCode);
        }
        public DataTable GetAllHangHoaDangBan()
        {
            return dal.GetAllHangHoaDangBan();
        }
        public bool KiemTraCanhBao(HangHoaDTO hh)
        {
            return hh.TonKhoHienTai <= hh.MucCanhBao;
        }
        public void CongTonKho(int maHang, int soLuong)
        {
            HangHoaDAL dal = new HangHoaDAL();
            dal.CongTonKho(maHang, soLuong);
        }

        public void TruTonKho(int maHang, int soLuong)
        {
            HangHoaDAL dal = new HangHoaDAL();
            dal.TruTonKho(maHang, soLuong);
        }
       public DataTable GetHangHoaCommon()
        {
            return dal.GetAllHangHoaCommon();
        }
        public string KiemTraDuLieu(HangHoaDTO hh)
        {
            if (string.IsNullOrWhiteSpace(hh.TenHang))
                return "Tên hàng không được để trống";

            if (hh.DonGiaBan <= 0)
                return "Đơn giá phải lớn hơn 0";

            if (hh.TonKhoHienTai < 0)
                return "Số lượng không hợp lệ";

            return ""; // hợp lệ
        }
        public void CapNhatTrangThai(HangHoaDTO hh)
        {
            if (hh.TonKhoHienTai == 0)
                hh.TrangThai = 0; // hết hàng
            else
                hh.TrangThai = 1; // còn hàng
        }

    }
}
