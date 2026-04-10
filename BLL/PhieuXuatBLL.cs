using System;
using System.Data;
using DAL;
using DTO;

namespace BLL
{
    public class PhieuXuatBLL
    {
        PhieuXuatDAL dal = new PhieuXuatDAL();

        public DataTable GetAllPhieuXuat()
        {
            return dal.GetAll();
        }
        public void Delete(int maPX)
        {
            dal.Delete(maPX);
        }
        public void Insert(PhieuXuatDTO dto)
        {
            dal.Insert(dto);
        }
        public int GetNextMaPhieuXuat()
        {
            return dal.GetMaxMaPhieuXuat() + 1;
        }
        public decimal GetTongTien()
        {
            object result = dal.GetTongTien();

            if (result == null || result == DBNull.Value)
                return 0;

            return Convert.ToDecimal(result);
        }
    }
}