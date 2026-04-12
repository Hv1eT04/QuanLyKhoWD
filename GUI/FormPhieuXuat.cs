using BLL;
using DTO;
using System;
using System.Data;
using System.Windows.Forms;

namespace GUI
{
    public partial class FormPhieuXuat : Form
    {
        PhieuXuatBLL bll = new PhieuXuatBLL();
        private NguoiDungDTO loginUser;

        public FormPhieuXuat(NguoiDungDTO user)
        {
            InitializeComponent();
            this.loginUser = user;

            SetupGrid();
            LoadPhieuXuat();
            TinhTongTien();
        }

        private void SetupGrid()
        {
            dgvPhieuXuat.AutoGenerateColumns = false;
            dgvPhieuXuat.Columns.Clear();

            dgvPhieuXuat.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "maphieuxuat", HeaderText = "ID", Name = "maphieuxuat", Visible = false });

            dgvPhieuXuat.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "sophieu", HeaderText = "Số Phiếu", Name = "sophieu", Width = 120 });
            dgvPhieuXuat.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "nguoilap", HeaderText = "Người Lập", Name = "nguoilap", Width = 150 });
            dgvPhieuXuat.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "ngaytao", HeaderText = "Ngày Tạo", Name = "ngaytao", Width = 130 });
            dgvPhieuXuat.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "ghichu", HeaderText = "Ghi Chú", Name = "ghichu", Width = 200 });
            dgvPhieuXuat.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "trangthai", HeaderText = "Trạng Thái", Name = "trangthai", Width = 100 });

            DataGridViewButtonColumn btnXem = new DataGridViewButtonColumn
            {
                HeaderText = "Xem",
                Text = "Xem",
                Name = "btnxem",
                UseColumnTextForButtonValue = true,
                Width = 70
            };
            dgvPhieuXuat.Columns.Add(btnXem);

            DataGridViewButtonColumn btnSua = new DataGridViewButtonColumn
            {
                HeaderText = "Sửa",
                Text = "Sửa",
                Name = "btnsua",
                UseColumnTextForButtonValue = true,
                Width = 70
            };
            dgvPhieuXuat.Columns.Add(btnSua);
        }

        private void LoadPhieuXuat()
        {
            try
            {
                dgvPhieuXuat.DataSource = bll.GetAllPhieuXuat();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải danh sách: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void TinhTongTien()
        {
            decimal tong = bll.GetTongTien();
            txtTongTien.Text = tong.ToString("N0") + " VND";
        }

        private void dgvPhieuXuat_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            int maID = Convert.ToInt32(dgvPhieuXuat.Rows[e.RowIndex].Cells["maphieuxuat"].Value);

            if (dgvPhieuXuat.Columns[e.ColumnIndex].Name == "btnxem")
            {
                FormXuatCommon f = new FormXuatCommon(this.loginUser, maID, "VIEW");
                f.ShowDialog();
                LoadPhieuXuat();
                TinhTongTien();
            }
            else if (dgvPhieuXuat.Columns[e.ColumnIndex].Name == "btnsua")
            {
                FormXuatCommon f = new FormXuatCommon(this.loginUser, maID, "EDIT");

                f.ShowDialog();

                LoadPhieuXuat();
                TinhTongTien();
            }
        }

        private void btntaophieu_Click(object sender, EventArgs e)
        {
            FormXuatCommon f = new FormXuatCommon(this.loginUser);
            f.ShowDialog();
            LoadPhieuXuat();
            TinhTongTien();
        }

        private void btnreload_Click(object sender, EventArgs e)
        {
            LoadPhieuXuat();
            TinhTongTien();
        }

        private void dgvPhieuXuat_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvPhieuXuat.Rows[e.RowIndex];
                if (txtmaPX != null) txtmaPX.Text = row.Cells["maphieuxuat"].Value.ToString();
                if (txtsophieu != null) txtsophieu.Text = row.Cells["sophieu"].Value.ToString();
                if (txtuser != null) txtuser.Text = row.Cells["nguoilap"].Value.ToString();
            }
        }

        private void btnxoa_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtmaPX.Text))
            {
                MessageBox.Show("Vui lòng chọn một phiếu xuất để xóa!");
                return;
            }

            if (MessageBox.Show("Xóa phiếu này sẽ xóa toàn bộ chi tiết liên quan. Bạn chắc chắn chứ?", "Cảnh báo",
                MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                int maID = int.Parse(txtmaPX.Text);
                bll.Delete(maID);
                LoadPhieuXuat();
                TinhTongTien();
                MessageBox.Show("Đã xóa phiếu xuất thành công!");
                txtmaPX.Clear();
                txtsophieu.Clear();
                txtuser.Clear();
            }
        }
    }
}