using System;
using System.Data;
using System.Collections.Generic;
using MySql.Data.MySqlClient;

namespace DAL
{
    public class BaoCaoDAL
    {
        DatabaseHelper db = new DatabaseHelper();

        public DataTable GetBaoCaoNhapXuat(DateTime tuNgay, DateTime denNgay)
        {
            string sql = @"
            -- Lấy dữ liệu từ Phiếu Nhập
            SELECT 'Nhập' AS LoaiPhieu, pn.sophieu, pn.ngaytao, hh.tenhang, 
                   ctn.soluong, ctn.dongianhap AS dongia, (ctn.soluong * ctn.dongianhap) AS thanhtien
            FROM phieunhap pn
            JOIN chitietphieunhap ctn ON pn.maphieunhap = ctn.maphieunhap
            JOIN hanghoa hh ON ctn.mahang = hh.mahang
            WHERE pn.ngaytao BETWEEN @tu AND @den

            UNION ALL

            -- Lấy dữ liệu từ Phiếu Xuất
            SELECT 'Xuất' AS LoaiPhieu, px.sophieu, px.ngaytao, hh.tenhang, 
                   ctx.soluong, ctx.dongiaxuat AS dongia, (ctx.soluong * ctx.dongiaxuat) AS thanhtien
            FROM phieuxuat px
            JOIN chitietphieuxuat ctx ON px.maphieuxuat = ctx.maphieuxuat
            JOIN hanghoa hh ON ctx.mahang = hh.mahang
            WHERE px.ngaytao BETWEEN @tu AND @den
            ORDER BY ngaytao DESC";

            MySqlParameter[] pars = {
            new MySqlParameter("@tu", tuNgay.ToString("yyyy-MM-dd 00:00:00")),
            new MySqlParameter("@den", denNgay.ToString("yyyy-MM-dd 23:59:59"))
        };

            return db.ExecuteQuery(sql, pars);
        }
    }
}