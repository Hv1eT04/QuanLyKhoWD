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
        public bool Delete(int maPN)
        {
            return dal.Delete(maPN) > 0;
        }
        public bool InsertFull(PhieuNhapDTO dto)
        {
            return dal.Insert(dto) > 0;
        }

        public bool UpdateFull(PhieuNhapDTO dto)
        {
            return dal.Update(dto) > 0;
        }

        public PhieuNhapDTO GetById(int maPN)
        {
            return dal.GetById(maPN);
        }
        public int InsertAndGetId(PhieuNhapDTO dto)
        {
            return dal.InsertAndGetId(dto);
        }
        public string TaoSoPhieu()
        {
            PhieuNhapDAL dal = new PhieuNhapDAL();

            string max = dal.GetMaxSoPhieu();

            if (string.IsNullOrEmpty(max))
                return "PN001";

            int num = int.Parse(max.Replace("PN", ""));
            num++;

            return "PN" + num.ToString("000");
        }
    }
}
