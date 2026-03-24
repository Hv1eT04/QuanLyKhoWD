using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Data;
using DTO;
namespace DAL
{
    public class HangHoaDAL
    {
        DatabaseHelper db = new DatabaseHelper();
        public DataTable GetAllHangHoa()
        {
            string sql = "SELECT * FROM HangHoa";
            return db.ExecuteQuery(sql);
        }
        public int ThemHangHoa(DTO.HangHoaDTO hh)
        {
            string sql = @"INSERT INTO HangHoa (MaCode, TenHang, MaDanhMuc, DonViTinh, DonGiaBan, TonKhoHienTai, MucCanhBao, TrangThai) 
                           VALUES (@MaCode, @TenHang, @MaDanhMuc, @DonViTinh, @DonGiaBan, @TonKhoHienTai, @MucCanhBao, @TrangThai)";
            MySqlParameter[] param =
            {
                new MySqlParameter("@MaCode", hh.MaCode),
                new MySqlParameter("@TenHang", hh.TenHang),
                new MySqlParameter("@MaDanhMuc", hh.MaDanhMuc),
                new MySqlParameter("@DonViTinh", hh.DonViTinh),
                new MySqlParameter("@DonGiaBan", hh.DonGiaBan),
                new MySqlParameter("@TonKhoHienTai", hh.TonKhoHienTai),
                new MySqlParameter("@MucCanhBao", hh.MucCanhBao),
                new MySqlParameter("@TrangThai", hh.TrangThai)
            };
            return db.ExecuteNonQuery(sql, param);
        }
        public int SuaHangHoa(DTO.HangHoaDTO hh)
        {
            string sql = "UPDATE hanghoa SET TenHang=@ten, DonViTinh=@dvt, MaDanhMuc=@MaDanhMuc, DonGiaBan=@DonGiaBan, TonKhoHienTai=@TonkhoHienTai, MucCanhBao=@MucCanhBao, TrangThai=@TrangThai WHERE MaCode=@ma";

            MySqlParameter[] param = {
            new MySqlParameter("@ten", hh.TenHang),
            new MySqlParameter("@dvt", hh.DonViTinh),
            new MySqlParameter("@MaDanhMuc", hh.MaDanhMuc),
            new MySqlParameter("@DonGiaBan", hh.DonGiaBan),
            new MySqlParameter("@TonkhoHienTai", hh.TonKhoHienTai),
            new MySqlParameter("@MucCanhBao", hh.MucCanhBao),
            new MySqlParameter("@TrangThai", hh.TrangThai),
            new MySqlParameter("@ma", hh.MaCode)
};

            return db.ExecuteNonQuery(sql, param);
        }
        //Xử lý xóa mềm thay vì xóa cứng
        public int Ngungkinhdoanh(string macode)
        {
            string sql = "UPDATE HangHoa SET TrangThai = 0 WHERE MaCode = @MaCode";
            MySqlParameter[] param =
            {
                new MySqlParameter("@MaCode", macode)
            };
            return db.ExecuteNonQuery(sql, param);
        }
        //Xử lý để vẫn thấy hàng đã ngừng sẽ phân biệt hàng hóa
        public DataTable GetAllHangHoaDangBan()
        {
            string sql = "SELECT * FROM HangHoa WHERE TrangThai = 1";
            return db.ExecuteQuery(sql);
        }
        public int KhoiPhucHangHoa(string macode)
        {
            string sql = "UPDATE HangHoa SET TrangThai = 1 WHERE MaCode = @MaCode";
            MySqlParameter[] param =
            {
                new MySqlParameter("@MaCode", macode)
            };
            return db.ExecuteNonQuery(sql, param);
        }
    }
}
