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
        private void FormNCC_Load(object sender, EventArgs e)
        {
            //Style cho các TextBox
            StyleTextBox(txtTenNCC);
            StyleTextBox(txtDiaChi);
            StyleTextBox(txtSDT);
            //Style cho các nút
            StyleButton(btnThem, Color.FromArgb(40, 167, 69)); // xanh lá
            this.BackColor = Color.White;
            this.Font = new Font("Segoe UI", 10);
            LoadNCC();
            StyleGrid();
        }
        void LoadNCC()
        {
            dgvNCC.DataSource = bll.GetALL();
            dgvNCC.Columns["MaNCC"].HeaderText = "Mã NCC";
            dgvNCC.Columns["TenNCC"].HeaderText = "Tên nhà cung cấp";
            dgvNCC.Columns["DiaChi"].HeaderText = "Địa chỉ";
            dgvNCC.Columns["SDT"].HeaderText = "Số điện thoại";
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

                // reset form
                txtTenNCC.Clear();
                txtDiaChi.Clear();
                txtSDT.Clear();
            }
            else
            {
                MessageBox.Show("Thêm thất bại!");
            }
        }
        //Style cho DataGridView
        void StyleGrid()
        {
            dgvNCC.BorderStyle = BorderStyle.None;
            dgvNCC.BackgroundColor = Color.White;

            dgvNCC.EnableHeadersVisualStyles = false;
            dgvNCC.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;

            dgvNCC.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(0, 120, 215);
            dgvNCC.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvNCC.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);

            dgvNCC.DefaultCellStyle.Font = new Font("Segoe UI", 10);
            dgvNCC.DefaultCellStyle.SelectionBackColor = Color.FromArgb(0, 120, 215);
            dgvNCC.DefaultCellStyle.SelectionForeColor = Color.White;

            dgvNCC.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(245, 245, 245);

            dgvNCC.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvNCC.RowTemplate.Height = 35;
        }
    }
}
