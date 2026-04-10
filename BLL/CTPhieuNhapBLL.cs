using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class CTPhieuNhapBLL
    {
        CTPhieuNhapDAL dal = new CTPhieuNhapDAL();

        public DataTable GetChiTiet(int maPN)
        {
            return dal.GetByMaPN(maPN);
        }
    }
}
