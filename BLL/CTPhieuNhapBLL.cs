using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Data;

namespace BLL
{
    public class CTPhieuNhapBLL
    {
        CTPhieuNhapDAL dal = new CTPhieuNhapDAL();

        public DataTable GetChiTietByMaPN(int maPN)
        {
            return dal.GetListByMaPN(maPN);
        }

        public bool Insert(CTPhieuNhapDTO ct, int maPN)
        {
            if (ct.SoLuong <= 0) return false;
            return dal.Insert(ct, maPN);
        }

        public void DeleteByMaPN(int maPN)
        {
            dal.DeleteByMaPN(maPN);
        }

        public double TinhTongTien(int maPN)
        {
            return dal.TinhTongTien(maPN);
        }

        public void Update(int maCT, int mahang, int sl, double dg)
        {
            if (sl > 0 && dg >= 0)
            {
                dal.Update(maCT, mahang, sl, dg);
            }
        }
    }
}