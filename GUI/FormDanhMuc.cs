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
        void StyleTextBox(TextBox txt)
        {
            txt.Font = new Font("Segoe UI", 10);
            txt.BorderStyle = BorderStyle.FixedSingle;
            txt.BackColor = Color.White;
        }
        void StyleButton(Button btn, Color color)
        {
            btn.BackColor = color;
            btn.ForeColor = Color.White;
            btn.FlatStyle = FlatStyle.Flat;
            btn.FlatAppearance.BorderSize = 0;
            btn.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            btn.Cursor = Cursors.Hand;
        }
        private void FormDanhMuc_Load(object sender, EventArgs e)
        {
            StyleTextBox(txtMaDanhMuc);
            StyleTextBox(txtTenDanhMuc);
            StyleTextBox(txtMoTa);

            //Style cho các nút
            StyleButton(btnThem, Color.FromArgb(40, 167, 69));   // xanh lá
            StyleButton(btnSua, Color.FromArgb(0, 123, 255));    // xanh dương
            StyleButton(btnXoa, Color.FromArgb(220, 53, 69));    // đỏ
            StyleButton(btnLuu, Color.FromArgb(255, 193, 7));    // vàng

            btnLuu.ForeColor = Color.Black; 

            LoadDanhMuc();
            dgvDanhMuc.Columns[0].HeaderText = "Mã danh mục";
            dgvDanhMuc.Columns[1].HeaderText = "Tên danh mục";
            dgvDanhMuc.Columns[2].HeaderText = "Mô tả";
            StyleGrid();
            this.BackColor = Color.White;
            this.Font = new Font("Segoe UI", 10);
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
        //Style cho datagridview
        void StyleGrid()
        {
            dgvDanhMuc.BorderStyle = BorderStyle.None;
            dgvDanhMuc.BackgroundColor = Color.White;

            dgvDanhMuc.EnableHeadersVisualStyles = false;
            dgvDanhMuc.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;

            dgvDanhMuc.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(0, 120, 215);
            dgvDanhMuc.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvDanhMuc.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);

            dgvDanhMuc.DefaultCellStyle.Font = new Font("Segoe UI", 10);
            dgvDanhMuc.DefaultCellStyle.SelectionBackColor = Color.FromArgb(0, 120, 215);
            dgvDanhMuc.DefaultCellStyle.SelectionForeColor = Color.White;

            dgvDanhMuc.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(245, 245, 245);

            dgvDanhMuc.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvDanhMuc.RowTemplate.Height = 35;
        }
    }
}
