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

        

        public void UpdateCT(int maCT, int mahang, int sl, decimal dg)
        {
            dal.UpdateWithStock(maCT, mahang, sl, dg);
        }

        public double GetTongTien(int maPX)
        {
            return dal.TinhTongTien(maPX);
        }
        public DataTable GetChiTietByMaPX(int maPX)
        {
            return dal.GetListByMaPX(maPX);
        }
    }
}
