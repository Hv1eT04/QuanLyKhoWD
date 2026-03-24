using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using DTO;
namespace BLL
{
    public class NhaCCBLL
    {
        NhaCCDAL dal = new NhaCCDAL();
        public List<NhaCCDTO> GetALL() => dal.GetALL();

        public bool Insert(string ten, string diachi, string sdt)
        => dal.Insert(ten, diachi, sdt) > 0;
        public bool Update(int ma, string ten, string diachi, string sdt)
        => dal.Update(ma, ten, diachi, sdt) > 0;
        public bool Delete(int ma)
        => dal.Delete(ma) > 0;
    }
}
