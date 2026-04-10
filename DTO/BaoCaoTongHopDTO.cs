using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class BaoCaoTongHopDTO
    {
        public string LoaiPhieu { get; set; }
        public string SoPhieu { get; set; }
        public DateTime NgayTao { get; set; }
        public string TenHang { get; set; }
        public int SoLuong { get; set; }
        public decimal DonGia { get; set; }
        public decimal ThanhTien { get; set; }
    }
}