using BLL;
using DTO;
using System;
using System.Data;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace GUI
{
    public partial class FormPhieuNhap : Form
    {
        PhieuNhapBLL bll = new PhieuNhapBLL();
        private NguoiDungDTO loginUser;

        // WinAPI để xử lý Placeholder cho .NET Framework
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        private static extern Int32 SendMessage(IntPtr hWnd, int msg, int wParam, [MarshalAs(UnmanagedType.LPWStr)] string lParam);
        private const int EM_SETCUEBANNER = 0x1501;

        public FormPhieuNhap(NguoiDungDTO user)
        {
            InitializeComponent();
            this.loginUser = user ?? new NguoiDungDTO();

            // Đảm bảo chạy sau khi form đã dựng xong
            this.Load += (s, e) => {
                SetPlaceholders();
                SetupGrid();
                RefreshData();
            };
        }

        private void SetPlaceholders()
        {
            SendMessage(txtsophieu.Handle, EM_SETCUEBANNER, 0, "Số phiếu...");
            SendMessage(txtuser.Handle, EM_SETCUEBANNER, 0, "Người lập...");
            SendMessage(txtNCC.Handle, EM_SETCUEBANNER, 0, "Nhà cung cấp...");
        }

        private void SetupGrid()
        {
            if (dgvPhieuNhap == null) return;
            dgvPhieuNhap.AutoGenerateColumns = false;
            dgvPhieuNhap.Columns.Clear();

            dgvPhieuNhap.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "maphieunhap", HeaderText = "ID", Name = "maphieunhap", Visible = false });
            dgvPhieuNhap.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "sophieu", HeaderText = "Số Phiếu", Name = "sophieu", Width = 100 });
            dgvPhieuNhap.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "tenncc", HeaderText = "Nhà Cung Cấp", Name = "tenncc", Width = 150 });
            dgvPhieuNhap.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "nguoilap", HeaderText = "Người Nhập", Name = "nguoilap", Width = 120 });
            dgvPhieuNhap.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "ngaytao", HeaderText = "Ngày Tạo", Name = "ngaytao", Width = 120 });

            // Nút chức năng
            DataGridViewButtonColumn btnXem = new DataGridViewButtonColumn { HeaderText = "Xem", Text = "Xem", Name = "btnxem", UseColumnTextForButtonValue = true, Width = 60 };
            dgvPhieuNhap.Columns.Add(btnXem);

            DataGridViewButtonColumn btnSua = new DataGridViewButtonColumn { HeaderText = "Sửa", Text = "Sửa", Name = "btnsua", UseColumnTextForButtonValue = true, Width = 60 };
            dgvPhieuNhap.Columns.Add(btnSua);
        }

        private void RefreshData()
        {
            try
            {
                DataTable dt = bll.GetAllPhieuNhap();
                dgvPhieuNhap.DataSource = dt;

                decimal tong = bll.GetTongTien();
                txtTongTien.Text = tong.ToString("N0") + " VND";
            }
            catch { }
        }

        private void dgvPhieuNhap_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvPhieuNhap.Rows[e.RowIndex];
                txtmaPN.Text = row.Cells["maphieunhap"].Value?.ToString();
                txtsophieu.Text = row.Cells["sophieu"].Value?.ToString();
                txtuser.Text = row.Cells["nguoilap"].Value?.ToString();
                txtNCC.Text = row.Cells["tenncc"].Value?.ToString();
            }
        }

        private void dgvPhieuNhap_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            string colName = dgvPhieuNhap.Columns[e.ColumnIndex].Name;
            int maID = Convert.ToInt32(dgvPhieuNhap.Rows[e.RowIndex].Cells["maphieunhap"].Value);

            if (colName == "btnxem")
            {
                FormNhapCommon f = new FormNhapCommon(this.loginUser, maID, "VIEW");
                f.ShowDialog();
                RefreshData();
            }
            else if (colName == "btnsua")
            {
                FormNhapCommon f = new FormNhapCommon(this.loginUser, maID, "EDIT");
                f.ShowDialog();
                RefreshData();
            }
        }

        private void btntaophieu_Click(object sender, EventArgs e)
        {
            FormNhapCommon f = new FormNhapCommon(this.loginUser);
            f.ShowDialog();
            RefreshData();
        }

        private void btnxoa_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtmaPN.Text)) return;
            if (MessageBox.Show("Xóa phiếu này?", "Xác nhận", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                bll.Delete(int.Parse(txtmaPN.Text));
                RefreshData();
                txtmaPN.Clear(); txtsophieu.Clear(); txtuser.Clear(); txtNCC.Clear();
            }
        }

        private void btnreload_Click(object sender, EventArgs e) => RefreshData();
    }
}