using BLL;
using DTO;
using System;
using System.Collections.Generic;
using System.Windows.Forms;


namespace GUI
{
    public partial class FormPhieuNhap : Form
    {
        int maPN_DangChon = 0;
        public FormPhieuNhap()
        {
            InitializeComponent();
        }

        private void FormPhieuNhap_Load(object sender, EventArgs e)
        {
            LoadTrangThai();
            LoadNCC();
            LoadPhieuNhap();
            SetAutoMaPhieu();

            PhieuNhapBLL bll = new PhieuNhapBLL();
            int nextId = bll.GetNextMaPhieuNhap();

            txtmaPN.Text = nextId.ToString();
            txtsophieu.Text = "PN" + nextId.ToString("D3");

        }

        void LoadPhieuNhap()
        {
            PhieuNhapBLL bll = new PhieuNhapBLL();
            dgvPhieuNhap.DataSource = bll.GetAllPhieuNhap();
        }

        void LoadTrangThai()
        {
            var list = new List<TrangThai>
            {
                new TrangThai { Value = 0, Text = "Hoàn thành" },
                new TrangThai { Value = 1, Text = "Lỗi" }
            };

            boxtt.DataSource = list;
            boxtt.DisplayMember = "Text";
            boxtt.ValueMember = "Value";

            boxtt.SelectedIndex = 0;
        }
        void CapNhatPhieuNhap()
        {
            if (maPN_DangChon == 0)
            {
                MessageBox.Show("Chọn phiếu cần sửa!");
                return;
            }

            PhieuNhapDTO dto = new PhieuNhapDTO
            {
                MaPhieuNhap = maPN_DangChon,
                SoPhieu = txtsophieu.Text,
                NguoiLap = txtuser.Text,
                GhiChu = txtnote.Text,
                TrangThai = Convert.ToInt32(boxtt.SelectedValue),
                MaNCC = Convert.ToInt32(cbbncc.SelectedValue),
                NgayTao = DateTime.Now
            };

            PhieuNhapBLL bll = new PhieuNhapBLL();
            bll.Update(dto);

            MessageBox.Show("Cập nhật thành công!");

            LoadPhieuNhap();
        }

        void SetAutoMaPhieu()
        {
            PhieuNhapBLL bll = new PhieuNhapBLL();
            int nextId = bll.GetNextMaPhieuNhap();

            txtmaPN.Text = nextId.ToString();
            txtsophieu.Text = "PN" + nextId.ToString("D3");
            txtnote.Clear();
            boxtt.SelectedIndex = 0;
        }

        void LoadNCC()
        {
            NhaCCBLL bllNCC = new NhaCCBLL();

            cbbncc.DataSource = bllNCC.GetALL();
            cbbncc.DisplayMember = "TenNCC";
            cbbncc.ValueMember = "MaNCC";

            cbbncc.SelectedIndex = -1;
        }
        private void btnthem_Click(object sender, EventArgs e)
        {
            PhieuNhapDTO dto = new PhieuNhapDTO
            {
                MaPhieuNhap = Convert.ToInt32(txtmaPN.Text),
                SoPhieu = txtsophieu.Text,
                NguoiLap = txtuser.Text,
                GhiChu = txtnote.Text,
                TrangThai = Convert.ToInt32(boxtt.SelectedValue),
                MaNCC = Convert.ToInt32(cbbncc.SelectedValue),
                NgayTao = DateTime.Now
            };

            PhieuNhapBLL bll = new PhieuNhapBLL();
            bll.Insert(dto);
            MessageBox.Show("Thêm thành công!");
            LoadPhieuNhap();
        }

        private void btnxoa_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtmaPN.Text))
            {
                MessageBox.Show("Chọn phiếu cần xóa!");
                return;
            }

            DialogResult result = MessageBox.Show(
                "Bạn có chắc muốn xóa?",
                "Xác nhận",
                MessageBoxButtons.YesNo);

            if (result == DialogResult.Yes)
            {
                PhieuNhapBLL bll = new PhieuNhapBLL();
                bll.Delete(txtmaPN.Text);

                MessageBox.Show("Xóa thành công!");
                LoadPhieuNhap();
            }
        }

        private void btnreload_Click(object sender, EventArgs e)
        {
            LoadPhieuNhap();
            SetAutoMaPhieu();
        }

        private void dgvPhieuNhap_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            string colName = dgvPhieuNhap.Columns[e.ColumnIndex].Name;
            DataGridViewRow row = dgvPhieuNhap.Rows[e.RowIndex];

            maPN_DangChon = Convert.ToInt32(row.Cells["maphieunhap"].Value);

            if (colName == "btnxem")
            {
                FormCTPhieuNhap f = new FormCTPhieuNhap(maPN_DangChon);
                f.ShowDialog();
            }

            if (colName == "btnsua")
            {
                CapNhatPhieuNhap();
                return;
            }

            txtmaPN.Text = maPN_DangChon.ToString();
            txtsophieu.Text = row.Cells["sophieu"].Value?.ToString();
            txtnote.Text = row.Cells["ghichu"].Value?.ToString();
            txtuser.Text = row.Cells["nguoilap"].Value?.ToString();

            if (row.Cells["mancc"].Value != null)
                cbbncc.SelectedValue = row.Cells["mancc"].Value;

            if (row.Cells["trangthai"].Value != null)
                boxtt.SelectedValue = row.Cells["trangthai"].Value;
        }
    }
}
