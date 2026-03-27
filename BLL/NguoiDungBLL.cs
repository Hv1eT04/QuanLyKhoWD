using DAL;
using DTO;
using System;

namespace BLL
{
    public class NguoiDungBLL
    {
        NguoiDungDAL dal = new NguoiDungDAL();

        public NguoiDungDTO DangNhap(string user, string pass)
        {
            if (string.IsNullOrEmpty(user) || string.IsNullOrEmpty(pass))
            {
                throw new Exception("Tên đăng nhập và mật khẩu không được để trống!");
            }

            return dal.KiemTraDangNhap(user, pass);
        }
    }
}