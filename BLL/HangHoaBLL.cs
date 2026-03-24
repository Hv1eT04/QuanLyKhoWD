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
        public string TaoMaCode()
        {
            DataTable dt = dal.GetAllHangHoa();
            int stt = dt.Rows.Count + 1;
            return "HH" + stt.ToString("000");
        }
        public int ThemHangHoa(HangHoaDTO hh)
        {
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
        public string KiemTraCanhBao(int tonKHo, int mucCanhBao)
        {
            if (tonKHo <= mucCanhBao)
            {
                return "Cảnh báo: Hàng sắp hết!";
            }
            return "Còn Hàng";
        }
    }
}
