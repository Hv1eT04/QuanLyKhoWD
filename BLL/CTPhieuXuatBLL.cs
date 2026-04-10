using DAL;
using System;
using System.Collections.Generic;
using System.Data;
using MySql.Data.MySqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class CTPhieuXuatBLL
    {
        CTPhieuXuatDAL dal = new CTPhieuXuatDAL();

        public DataTable GetChiTietByMaPX(int maPX)
        {
            return dal.GetByMaPX(maPX);
        }

        public void UpdateCT(int maCT, int mahang, int sl, double dg)
        {
            dal.Update(maCT, mahang, sl, dg);
        }

        public double GetTongTien(int maPX)
        {
            return dal.TinhTongTien(maPX);
        }
        public void Insert(int maPX, int mahang, int sl, double dg)
        {
            dal.Insert(maPX, mahang, sl, dg);
        }
    }
}
