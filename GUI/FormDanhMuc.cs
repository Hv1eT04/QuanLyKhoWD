using BLL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DTO;
using DAL;
namespace GUI
{
    public partial class FormDanhMuc : Form
    {
        DanhMucBLL bll = new DanhMucBLL();
        public FormDanhMuc()
        {
            InitializeComponent();
        }

        private void FormDanhMuc_Load(object sender, EventArgs e)
        {
            LoadDanhMuc();
        }
        private void LoadDanhMuc()
        {
            dgvDanhMuc.DataSource = bll.GetAllDanhMuc();
        }

        private void dgvDanhMuc_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvDanhMuc.Rows[e.RowIndex];

                txtMaDanhMuc.Text = row.Cells[0].Value.ToString();
                txtTenDanhMuc.Text = row.Cells[1].Value.ToString();
                txtMoTa.Text = row.Cells[2].Value.ToString();
                btnLuu.Enabled = false; //Đang sửa không cho phép lưu thêm mới
            }    
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            txtMaDanhMuc.Clear();
            txtTenDanhMuc.Clear();
            txtMoTa.Clear();
            txtTenDanhMuc.Focus();
            btnLuu.Enabled = true; //Cho phép lưu khi đang thêm mới
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtMaDanhMuc.Text))
            {
                MessageBox.Show("Vui lòng chọn danh mục cần sửa!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            int ma = int.Parse(txtMaDanhMuc.Text);
            string ten = txtTenDanhMuc.Text;
            string mota = txtMoTa.Text;
            if (string.IsNullOrEmpty(ten))
            {
                MessageBox.Show("Tên danh mục không được để trống!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            bool result = bll.UpdateDanhMuc(ma, ten, mota);
            if (result)
            {
                MessageBox.Show("Cập nhật thành công");
                LoadDanhMuc();
            }
            else
            {
                MessageBox.Show("Sửa thất bại");
            }    
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            string ten = txtTenDanhMuc.Text;
            string mota = txtMoTa.Text;
            if (string.IsNullOrEmpty(ten))
            {
                MessageBox.Show("Tên danh mục không được để trống!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            bool result = bll.InsertDanhMuc(ten,mota);
            if (result)
            {
                MessageBox.Show("Thêm thành công");
                LoadDanhMuc();
            }
            else
            {
                MessageBox.Show("Thêm thất bại");
            }
            btnLuu.Enabled = false; //Sau khi lưu xong thì không cho phép lưu tiếp nếu chưa bấm thêm mới
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtMaDanhMuc.Text)) return;
            int ma = int.Parse(txtMaDanhMuc.Text);
            DialogResult result = MessageBox.Show("Bạn có chắc muốn xóa danh mục này?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                bll.DeleteDanhMuc(ma);
                LoadDanhMuc();
            }
        }
    }
}
