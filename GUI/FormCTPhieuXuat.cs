using BLL;
using DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace GUI
{
    public partial class FormCTPhieuXuat : Form
    {
        CTPhieuXuatBLL bll = new CTPhieuXuatBLL();

        List<HangChonDTO> dsHang;
        DataTable dtChiTiet;
        public FormCTPhieuXuat(List<HangChonDTO> ds)
        {
            InitializeComponent();
            dsHang = ds;
        }

        public FormCTPhieuXuat(DataTable dt)
        {
            InitializeComponent();
            dtChiTiet = dt;
        }

        private void FormCTPhieuXuat_Load(object sender, EventArgs e)
        {
            if (dsHang != null)
            {
                dgvChiTiet.DataSource = dsHang;
            }
            else if (dtChiTiet != null)
            {
                dgvChiTiet.DataSource = dtChiTiet;
            }

            dgvChiTiet.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvChiTiet.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvChiTiet.AllowUserToAddRows = false;
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            int maCT = Convert.ToInt32(txtMaCT.Text);
            int mahang = Convert.ToInt32(txtMaHang.Text);
            int sl = Convert.ToInt32(txtSoLuong.Text);
            decimal dg = Convert.ToDecimal(txtDonGia.Text);

            bll.UpdateCT(maCT, mahang, sl, dg);

            MessageBox.Show("Sửa thành công!");

        }

        

        private void dgvChiTiet_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            var row = dgvChiTiet.Rows[e.RowIndex];

            txtMaCT.Text = row.Cells["machitiet"].Value.ToString();
            txtSoLuong.Text = row.Cells["soluong"].Value.ToString();
            txtDonGia.Text = row.Cells["dongiaxuat"].Value.ToString();
            txtMaHang.Text = row.Cells["mahang"].Value.ToString();
            txtMaPX.Text = row.Cells["maphieuxuat"].Value.ToString();
        }
    }
}