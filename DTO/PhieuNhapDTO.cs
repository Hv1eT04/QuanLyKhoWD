using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class TrangThai
    {
        public int Value { get; set; }
        public string Text { get; set; }
    }
    public class PhieuNhapDTO
    {
        public int MaPhieuNhap { get; set; }
        public string SoPhieu { get; set; }
        public string NguoiLap { get; set; }
        public int MaNCC { get; set; }
        public int TrangThai { get; set; }
        public DateTime NgayTao { get; set; }
        public string GhiChu { get; set; }
    }
}
