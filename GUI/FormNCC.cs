using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BLL;

namespace GUI
{
    public partial class FormNCC : Form
    {
        NhaCCBLL bll = new NhaCCBLL();
        public FormNCC()
        {
            InitializeComponent();
        }

        private void FormNCC_Load(object sender, EventArgs e)
        {
            LoadNCC();
        }
        void LoadNCC()
        {
            dgvNCC.DataSource = bll.GetALL();
        }

        private void dgvNCC_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return; //Bỏ qua nếu click vào header hoặc ngoài vùng dữ liệu
            var row = dgvNCC.Rows[e.RowIndex];
            int ma = Convert.ToInt32(row.Cells["MaNCC"].Value);
            if (dgvNCC.Columns[e.ColumnIndex].Name == "btnSua")
            {
                int maNCC = Convert.ToInt32(row.Cells["MaNCC"].Value);
                string ten = row.Cells["TenNCC"].Value.ToString();
                string diachi = row.Cells["DiaChi"].Value.ToString();
                string sdt = row.Cells["SDT"].Value.ToString();
                if (string.IsNullOrEmpty(ten))
                {
                    MessageBox.Show("Không được để trống tên");
                    return;
                }
                if (bll.Update(maNCC, ten, diachi, sdt))
                {
                    MessageBox.Show("Cập nhật thành công!");
                    LoadNCC();
                }
                else
                {
                    MessageBox.Show("Sửa thất bại!");
                }
            }
            //Nếu click nút xóa
            if (dgvNCC.Columns[e.ColumnIndex].Name == "btnXoa")
            {
                var confirm = MessageBox.Show("Bạn có chắc muốn xóa nhà cung cấp này?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (confirm == DialogResult.Yes)
                {
                    if (bll.Delete(ma))
                    {
                        MessageBox.Show("Xóa thành công!");
                        LoadNCC();
                    }
                    else
                    {
                        MessageBox.Show("Xóa thất bại!");
                    }
                }
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            txtMaNCC.Clear();
            txtTenNCC.Clear();
            txtDiaChi.Clear();
            txtSDT.Clear();
            txtTenNCC.Focus();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            string ten = txtTenNCC.Text;
            string dc = txtDiaChi.Text;
            string sdt = txtSDT.Text;
            if (string.IsNullOrEmpty(ten))
            {
                MessageBox.Show("Không được để trống tên");
                return;
            }
            if (bll.Insert(ten, dc, sdt))
            {
                MessageBox.Show("Thêm thành công!");
                LoadNCC();
            }
            else
            {
                MessageBox.Show("Thêm thất bại!");
            }
        }
    }
}
