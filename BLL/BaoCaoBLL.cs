using DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace BLL
{
    public class BaoCaoBLL
    {
        BaoCaoDAL dal = new BaoCaoDAL();

        public DataTable LayBaoCao(DateTime tu, DateTime den) => dal.GetBaoCaoNhapXuat(tu, den);

        public decimal TinhTongNhap(DataTable dt)
        {
            return dt.AsEnumerable()
                     .Where(row => row.Field<string>("LoaiPhieu") == "Nhập")
                     .Sum(row => row.Field<decimal>("thanhtien"));
        }

        public decimal TinhTongXuat(DataTable dt)
        {
            return dt.AsEnumerable()
                     .Where(row => row.Field<string>("LoaiPhieu") == "Xuất")
                     .Sum(row => row.Field<decimal>("thanhtien"));
        }
    }
}