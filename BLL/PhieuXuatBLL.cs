using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Data;

namespace BLL
{
    public class PhieuXuatBLL
    {
        PhieuXuatDAL dal = new PhieuXuatDAL();
        HangHoaBLL hangHoaBLL = new HangHoaBLL();
        public DataTable GetAllPhieuXuat()
        {
            return dal.GetAll();
        }
        public void Delete(int maPX)
        {
            dal.Delete(maPX);
        }
        public bool LuuPhieuHoanChinh(string soPhieu, string ghiChu, string hoTenUser, List<CTPhieuXuatDTO> dsChiTiet)
        {
            // 1. Lưu phiếu chính và lấy ID vừa sinh ra
            PhieuXuatDTO phieu = new PhieuXuatDTO
            {
                SoPhieu = soPhieu,
                GhiChu = ghiChu,
                TenNguoiXuat = hoTenUser
            };

            // Lấy Maphieuxuat từ Database sau khi chèn thành công
            int maPXVuatTao = dal.InsertAndGetId(phieu);

            // 2. Nếu có ID hợp lệ, mới lưu các dòng chi tiết
            if (maPXVuatTao > 0)
            {
                CTPhieuXuatDAL ctDal = new CTPhieuXuatDAL();
                foreach (var item in dsChiTiet)
                {
                    ctDal.Insert(item, maPXVuatTao);
                }
                return true;
            }
            return false;
        }
        public string GetNextMaPhieuXuat()
        {
            Random res = new Random();

            string str = "abcdefghijklmnopqrstuvwxyz0123456789";
            int size = 5;
            string randomString = "";

            for (int i = 0; i < size; i++)
            {
                int x = res.Next(str.Length);
                randomString += str[x];
            }
            return "PX" + randomString.ToUpper();
        }
        public decimal GetTongTien()
        {
            object result = dal.GetTongTien();

            if (result == null || result == DBNull.Value)
                return 0;

            return Convert.ToDecimal(result);
        }
        public DataTable GetAllHangHoaCommon()
        {
            return hangHoaBLL.GetHangHoaCommon();
        }
        public DataTable GetPhieuXuatByMaID(int maPX)
        {
            return dal.GetById(maPX);
        }

        public bool CapNhatPhieu(int maPX, string ghiChu, List<CTPhieuXuatDTO> dsChiTiet)
        {
            bool updateMaster = dal.Update(maPX, ghiChu);

            if (updateMaster)
            {
                CTPhieuXuatDAL ctDal = new CTPhieuXuatDAL();
                ctDal.DeleteByMaPX(maPX);

                foreach (var item in dsChiTiet)
                {
                    ctDal.Insert(item, maPX);
                }
                return true;
            }
            return false;
        }
    }
}