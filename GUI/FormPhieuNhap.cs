using BLL;
using DTO;
using System;
using System.Collections.Generic;
using System.Data;
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

        void LoadNCC()
        {
            NhaCCBLL bllNCC = new NhaCCBLL();

            cbbncc.DataSource = bllNCC.GetALL();
            cbbncc.DisplayMember = "TenNCC";
            cbbncc.ValueMember = "MaNCC";

            cbbncc.SelectedIndex = -1;
        }
        private void btntaophieu_Click(object sender, EventArgs e)
        {
            FormTao f = new FormTao(FormMode.Tao, 0);
            f.ShowDialog();

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

                if (bll.Delete(maPN_DangChon))
                {
                    MessageBox.Show("Xóa thành công!");
                    LoadPhieuNhap();
                }
                else
                {
                    MessageBox.Show("Xóa thất bại!");
                }
            }
        }

        private void dgvPhieuNhap_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            string colName = dgvPhieuNhap.Columns[e.ColumnIndex].Name;
            DataGridViewRow row = dgvPhieuNhap.Rows[e.RowIndex];

            var data = (DataRowView)row.DataBoundItem;
            maPN_DangChon = Convert.ToInt32(data["MaPhieuNhap"]);

            if (colName == "btnxem")
            {
                FormCTPhieuNhap f = new FormCTPhieuNhap(maPN_DangChon);
                f.ShowDialog();
                return;
            }

            if (colName == "btnsua")
            {
                FormTao f = new FormTao(FormMode.Sua, maPN_DangChon);
                f.ShowDialog();

                LoadPhieuNhap();
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
