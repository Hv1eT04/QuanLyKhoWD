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
    public class PhieuNhapBLL
    {
        PhieuNhapDAL dal = new PhieuNhapDAL();

        public DataTable GetAllPhieuNhap()
        {
            DataTable dt = dal.GetAll();
            return dt;
        }
        public void Insert(PhieuNhapDTO dto)
        {
            dal.Insert(dto);
        }
        public int GetNextMaPhieuNhap()
        {
            return dal.GetMaxMaPhieuNhap() + 1;
        }
        public void Delete(string maPN)
        {
            dal.Delete(maPN);
        }
        public void Update(PhieuNhapDTO dto)
        {
            dal.Update(dto);
        }
    }
}
