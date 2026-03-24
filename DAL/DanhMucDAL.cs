using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using DTO;
using MySql.Data.MySqlClient;
namespace DAL

{
    public class DanhMucDAL
    {
        DatabaseHelper dbHelper = new DatabaseHelper();
        public List<DanhMucDTO> GetAllDanhMuc()
        {
            List<DanhMucDTO> list = new List<DanhMucDTO>();
            string sql = "SELECT * FROM DanhMuc";
            DataTable dt = dbHelper.ExecuteQuery(sql);
            foreach (DataRow row in dt.Rows)
            {
                DanhMucDTO dm = new DanhMucDTO()
                {
                    MaDanhMuc = (int)row["MaDanhMuc"],
                    TenDanhMuc = row["TenDanhMuc"].ToString(),
                    MoTa = row["MoTa"].ToString()
                };
                list.Add(dm);
            }
            return list;
        }
        public int InsertDanhMuc(string ten, string mota)
        {
            string sql = "INSERT INTO DanhMuc(TenDanhMuc, MoTa) VALUES(@ten, @mota)";
            MySqlParameter[] parameters = new MySqlParameter[]
            {
                new MySqlParameter("@ten", ten),
                new MySqlParameter("@mota", mota)
            };
            return dbHelper.ExecuteNonQuery(sql, parameters);
        }
        public int UpdateDanhMuc(int ma, string ten, string mota)
        {
            string sql = "Update DanhMuc set TenDanhMuc = @ten, MoTa = @mota where MaDanhMuc = @ma";
            MySqlParameter[] parameters = new MySqlParameter[]
            {
                new MySqlParameter("@ten", ten),
                new MySqlParameter("@mota", mota),
                new MySqlParameter("@ma", ma)
            };
            return dbHelper.ExecuteNonQuery(sql, parameters);
        }
        public int DeleteDanhMuc(int ma)
        {
            string sql = "Delete from DanhMuc where MaDanhMuc = @ma";
            MySqlParameter[] parameters = new MySqlParameter[]
            {
                new MySqlParameter("@ma", ma)
            };
            return dbHelper.ExecuteNonQuery(sql, parameters);
        }
    }
}
