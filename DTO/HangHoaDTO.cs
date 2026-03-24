using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class HangHoaDTO
    {
        public string MaCode { get; set; }
        public string TenHang { get; set; }
        public int MaDanhMuc { get; set; }
        public string DonViTinh { get; set; }
        public double DonGiaBan { get; set; }
        public int TonKhoHienTai { get; set; }
        public int MucCanhBao { get; set; }
        public int TrangThai { get; set; }
    }
}
