using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using DTO;
using System.Data;
namespace DAL
{
    public class NhaCCDAL
    {
        DatabaseHelper db = new DatabaseHelper();
        public List<NhaCCDTO> GetALL()
        {
            List<NhaCCDTO> list = new List<NhaCCDTO>();
            string sql = "SELECT * FROM nhacungcap";
            DataTable dt = db.ExecuteQuery(sql);
            foreach (DataRow row in dt.Rows)
            {
                list.Add(new NhaCCDTO()
                {
                    MaNCC = Convert.ToInt32(row["MaNCC"]),
                    TenNCC = row["TenNCC"].ToString(),
                    DiaChi = row["DiaChi"].ToString(),
                    SDT = row["SDT"].ToString()
                });
            }
            return list;
        }
        public int Insert(string ten, string diachi, string sdt)
        {
            string sql = "INSERT INTO nhacungcap(TenNCC, DiaChi, SDT) VALUES(@ten, @diachi, @sdt)";
            MySqlParameter[] parameters = new MySqlParameter[]
            {
                new MySqlParameter("@ten", ten),
                new MySqlParameter("@diachi", diachi),
                new MySqlParameter("@sdt", sdt)
            };
            return db.ExecuteNonQuery(sql, parameters);
        }
        public int Update(int ma, string ten, string diachi, string sdt)
        {
            string sql = "UPDATE nhacungcap SET TenNCC = @ten, DiaChi = @diachi, SDT = @sdt WHERE MaNCC = @ma";
            MySqlParameter[] p =
            {
                new MySqlParameter("@ten", ten),
                new MySqlParameter("@diachi", diachi),
                new MySqlParameter("@sdt", sdt),
                new MySqlParameter("@ma", ma)
            };
            return db.ExecuteNonQuery(sql, p);
        }
        public int Delete(int ma)
        {
            string sql = "DELETE FROM nhacungcap WHERE MaNCC = @ma";
            MySqlParameter[] p =
            {
                new MySqlParameter("@ma", ma)
            };
            return db.ExecuteNonQuery(sql, p);
        }
    }
}
