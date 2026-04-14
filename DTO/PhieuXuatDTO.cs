using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class PhieuXuatDTO
    {
        public int MaPhieuXuat { get; set; }
        public string SoPhieu { get; set; }
        public string NguoiLap { get; set; }
        public DateTime NgayTao { get; set; }
        public string GhiChu { get; set; }
        public int TrangThai { get; set; }
        public string TenNguoiXuat { get; set; }
    }
}
