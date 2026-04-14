using DTO;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class CTPhieuNhapDAL
    {
        DatabaseHelper db = new DatabaseHelper();

        public DataTable GetByMaPN(int maPN)
        {
            string sql = @"SELECT ct.machitiet, ct.maphieunhap, h.MaCode, h.TenHang, ct.soluong, ct.dongianhap
                            FROM chitietphieunhap ct
                            JOIN hanghoa h ON ct.mahang = h.MaHang
                            WHERE ct.maphieunhap = @ma";

            return db.ExecuteQuery(sql,
                new MySqlParameter("@ma", maPN));
        }

        public void Update(int maCT, int maHang, int sl, double dg)
        {
            string sql = @"SELECT ct.machitiet, ct.maphieunhap, ct.mahang,
                      h.TenHang, ct.soluong, ct.dongianhap
               FROM chitietphieunhap ct
               JOIN hanghoa h ON ct.mahang = h.MaCode
               WHERE ct.maphieunhap=@ma";

            db.ExecuteNonQuery(sql,
                new MySqlParameter("@mh", maHang),
                new MySqlParameter("@sl", sl),
                new MySqlParameter("@dg", dg),
                new MySqlParameter("@ma", maCT)
            );
        }
        public void Insert(CTPhieuNhapDTO ct)
        {
            string sql = @"INSERT INTO chitietphieunhap
                            (maphieunhap, mahang, soluong, dongianhap)
                            VALUES (@mapn, @mh, @sl, @dg)";

            db.ExecuteNonQuery(sql,
                new MySqlParameter("@mapn", ct.maphieunhap),
                new MySqlParameter("@mh", ct.mahang),
                new MySqlParameter("@sl", ct.soluong),
                new MySqlParameter("@dg", ct.dongianhap)
            );
        }
        public void Delete(int maCT)
        {
            string sql = "DELETE FROM chitietphieunhap WHERE machitiet=@ma";

            db.ExecuteNonQuery(sql,
                new MySqlParameter("@ma", maCT)
            );
        }
    }
}
