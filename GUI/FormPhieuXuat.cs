using BLL;
using DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Security.Cryptography;
using System.Windows.Forms;


namespace GUI
{
    public partial class FormPhieuXuat : Form
    {
        PhieuXuatBLL bll = new PhieuXuatBLL();

        public FormPhieuXuat()
        {
            InitializeComponent();
        }

        private void FormPhieuXuat_Load(object sender, EventArgs e)
        {
            LoadPhieuXuat();
            TinhTongTien();
        }

        void LoadPhieuXuat()
        {
            dgvPhieuXuat.DataSource = bll.GetAllPhieuXuat();
        }

        void TinhTongTien()
        {
            CTPhieuXuatBLL bllCT = new CTPhieuXuatBLL();

            decimal tong = bll.GetTongTien();

            txtTongTien.Text = tong.ToString("N0") + " VND";
        }

        private void btntaophieu_Click(object sender, EventArgs e)
        {
            FormTao f = new FormTao(FormMode.Tao);
            f.ShowDialog();

            LoadPhieuXuat();
        }

        private void dgvPhieuXuat_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            DataGridViewRow row = dgvPhieuXuat.Rows[e.RowIndex];

            txtmaPX.Text = row.Cells["maphieuxuat"].Value.ToString();
            txtsophieu.Text = row.Cells["sophieu"].Value.ToString();
            txtuser.Text = row.Cells["nguoilap"].Value.ToString();
            txtnote.Text = row.Cells["ghichu"].Value.ToString();
            int trangThai = Convert.ToInt32(row.Cells["trangthai"].Value);

            if (trangThai == 1)
                txttt.Text = "Lỗi";
            else if (trangThai == 2)
                txttt.Text = "Hoàn thành";
            else
                txttt.Text = "";
        }

        private void btnxoa_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(txtmaPX.Text, out int maPX))
            {
                MessageBox.Show("Chọn phiếu hợp lệ!");
                return;
            }

            if (MessageBox.Show("Xóa phiếu?", "Xác nhận", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                bll.Delete(maPX);
                MessageBox.Show("Đã xóa!");
                LoadPhieuXuat();
            }
        }

        private void btnreload_Click(object sender, EventArgs e)
        {
            LoadPhieuXuat();
        }

        private void dgvPhieuXuat_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            int colIndex = dgvPhieuXuat.Columns["btnxem"].Index;

            if (e.ColumnIndex != colIndex) return;

            int maPX = Convert.ToInt32(dgvPhieuXuat.Rows[e.RowIndex].Cells["maphieuxuat"].Value);

            CTPhieuXuatBLL bllCT = new CTPhieuXuatBLL();

            DataTable dt = bllCT.GetChiTietByMaPX(maPX);

            FormCTPhieuXuat f = new FormCTPhieuXuat(dt);
            f.ShowDialog();
        }
    }
}