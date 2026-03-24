using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using System.Data;
using DTO;
namespace BLL
{
    public class DanhMucBLL
    {
        DanhMucDAL dal = new DanhMucDAL();
        public List<DanhMucDTO> GetAllDanhMuc()
        {
            return dal.GetAllDanhMuc();
        }
        public bool InsertDanhMuc(string ten, string mota)
        {
            return dal.InsertDanhMuc(ten, mota) > 0;
        }
        public bool UpdateDanhMuc(int ma, string ten, string mota)
        {
            return dal.UpdateDanhMuc(ma, ten, mota) > 0;
        }
        public bool DeleteDanhMuc(int ma)
        {
            return dal.DeleteDanhMuc(ma) > 0;
        }
    }
}
