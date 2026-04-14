using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using BLL;
using DTO;

namespace GUI
{
    public partial class FormXuatCommon : Form
    {
        // Khởi tạo các lớp nghiệp vụ
        private PhieuXuatBLL bll = new PhieuXuatBLL();
        private CTPhieuXuatBLL bllCT = new CTPhieuXuatBLL();

        // Danh sách tạm lưu chi tiết phiếu
        private List<CTPhieuXuatDTO> danhSachChiTiet = new List<CTPhieuXuatDTO>();

        public NguoiDungDTO UserResult { get; set; }
        private int currentMaPX = -1;
        private string currentMode = "ADD";

        // Constructor: THÊM MỚI
        public FormXuatCommon(NguoiDungDTO user)
        {
            InitializeComponent();
            this.UserResult = user;
            this.currentMode = "ADD";
            InitForm();
        }

        // Constructor: XEM hoặc SỬA
        public FormXuatCommon(NguoiDungDTO user, int maPX, string mode)
        {
            InitializeComponent();
            this.UserResult = user;
            this.currentMaPX = maPX;
            this.currentMode = mode.ToUpper();
            InitForm();
            LoadDataFromDatabase(maPX);
        }

        private void InitForm()
        {
            SetupGrid();
            LoadCombo();

            if (currentMode == "ADD")
            {
                this.Text = "Lập Phiếu Xuất Mới";
                txtSoPhieu.Text = bll.GetNextMaPhieuXuat();
            }
            else if (currentMode == "VIEW")
            {
                this.Text = "Chi Tiết Phiếu Xuất (Chỉ Xem)";
                LockControls();
            }
            else if (currentMode == "EDIT")
            {
                this.Text = "Chỉnh Sửa Phiếu Xuất";
                txtSoPhieu.ReadOnly = true;
            }
        }

        private void LockControls()
        {
            btnLuuPhieu.Visible = false;
            btnThem.Enabled = false;
            txtGhiChu.ReadOnly = true;
            cboHangHoa.Enabled = false;
            txtSoLuong.ReadOnly = true;
            txtGiaXuat.ReadOnly = true;
            dataGridView1.ReadOnly = true; // Khóa toàn bộ grid khi xem
            if (dataGridView1.Columns["btnDelete"] != null)
                dataGridView1.Columns["btnDelete"].Visible = false;
        }

        private void SetupGrid()
        {
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.Columns.Clear();

            // Các cột mã và tên hàng để ReadOnly = true
            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "MaHang", HeaderText = "Mã", Name = "cMa", ReadOnly = true, Width = 80 });
            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "TenHang", HeaderText = "Tên hàng hóa", Name = "cTen", ReadOnly = true, Width = 200 });

            // Cột SL và Giá cho phép sửa (ReadOnly = false)
            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "SoLuong", HeaderText = "SL", Name = "cSL", ReadOnly = false, Width = 70 });

            DataGridViewTextBoxColumn colGia = new DataGridViewTextBoxColumn { DataPropertyName = "GiaXuat", HeaderText = "Giá xuất", Name = "cGia", ReadOnly = false, Width = 120 };
            colGia.DefaultCellStyle.Format = "N0";
            dataGridView1.Columns.Add(colGia);

            DataGridViewTextBoxColumn colTT = new DataGridViewTextBoxColumn { DataPropertyName = "ThanhTien", HeaderText = "Thành tiền", Name = "cTT", ReadOnly = true, AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill };
            colTT.DefaultCellStyle.Format = "N0";
            dataGridView1.Columns.Add(colTT);

            DataGridViewButtonColumn btnDel = new DataGridViewButtonColumn { Text = "Xóa", Name = "btnDelete", UseColumnTextForButtonValue = true, HeaderText = "Xóa", Width = 60 };
            dataGridView1.Columns.Add(btnDel);

            // Gán sự kiện sửa trực tiếp trên Grid
            dataGridView1.CellValueChanged += DataGridView1_CellValueChanged;
        }

        private void LoadCombo()
        {
            cboHangHoa.DataSource = bll.GetAllHangHoaCommon();
            cboHangHoa.DisplayMember = "tenhang";
            cboHangHoa.ValueMember = "mahang";
            cboHangHoa.SelectedIndex = -1;
        }

        private void LoadDataFromDatabase(int maPX)
        {
            DataTable dtPhieu = bll.GetPhieuXuatByMaID(maPX);
            if (dtPhieu.Rows.Count > 0)
            {
                txtSoPhieu.Text = dtPhieu.Rows[0]["sophieu"].ToString();
                txtGhiChu.Text = dtPhieu.Rows[0]["ghichu"].ToString();
            }

            DataTable dtDetails = bllCT.GetChiTietByMaPX(maPX);
            danhSachChiTiet.Clear();
            foreach (DataRow row in dtDetails.Rows)
            {
                danhSachChiTiet.Add(new CTPhieuXuatDTO
                {
                    MaHang = row["mahang"].ToString(),
                    TenHang = row["tenhang"] != DBNull.Value ? row["tenhang"].ToString() : "N/A",
                    SoLuong = Convert.ToInt32(row["soluong"]),
                    GiaXuat = Convert.ToDecimal(row["dongiaxuat"])
                });
            }
            RefreshGrid();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (cboHangHoa.SelectedIndex == -1) return;
            if (!int.TryParse(txtSoLuong.Text, out int sl) || sl <= 0) return;
            if (!decimal.TryParse(txtGiaXuat.Text, out decimal gia)) return;

            DataRowView row = (DataRowView)cboHangHoa.SelectedItem;
            string maHangMoi = row["mahang"].ToString();

            // Xử lý CỘNG DỒN nếu trùng sản phẩm
            var itemTonTai = danhSachChiTiet.FirstOrDefault(x => x.MaHang == maHangMoi);
            if (itemTonTai != null)
            {
                itemTonTai.SoLuong += sl;
                itemTonTai.GiaXuat = gia; // Cập nhật theo giá mới nhất nhập vào
            }
            else
            {
                danhSachChiTiet.Add(new CTPhieuXuatDTO
                {
                    MaHang = maHangMoi,
                    TenHang = row["tenhang"].ToString(),
                    SoLuong = sl,
                    GiaXuat = gia
                });
            }

            RefreshGrid();
            txtSoLuong.Clear();
            txtGiaXuat.Clear();
            cboHangHoa.SelectedIndex = -1;
        }

        // Xử lý SỬA TRỰC TIẾP TRÊN GRID
        private void DataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || currentMode == "VIEW") return;

            var item = danhSachChiTiet[e.RowIndex];
            try
            {
                if (dataGridView1.Columns[e.ColumnIndex].Name == "cSL")
                    item.SoLuong = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["cSL"].Value);

                if (dataGridView1.Columns[e.ColumnIndex].Name == "cGia")
                    item.GiaXuat = Convert.ToDecimal(dataGridView1.Rows[e.RowIndex].Cells["cGia"].Value);

                RefreshGrid();
            }
            catch { MessageBox.Show("Dữ liệu nhập không hợp lệ!"); RefreshGrid(); }
        }

        private void RefreshGrid()
        {
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = danhSachChiTiet;
            lblTongTien.Text = $"Tổng cộng: {danhSachChiTiet.Sum(x => x.ThanhTien):N0} VND";
        }

        private void btnLuuPhieu_Click(object sender, EventArgs e)
        {
            if (danhSachChiTiet.Count == 0) return;

            string hoTen = (UserResult != null) ? UserResult.hovaten : "Admin";
            bool success = false;

            if (currentMode == "ADD")
                success = bll.LuuPhieuHoanChinh(txtSoPhieu.Text, txtGhiChu.Text, hoTen, danhSachChiTiet);
            else if (currentMode == "EDIT")
                success = bll.CapNhatPhieu(currentMaPX, txtGhiChu.Text, danhSachChiTiet);

            if (success)
            {
                MessageBox.Show("Đã lưu dữ liệu thành công!");
                this.DialogResult = DialogResult.OK; // Giúp Form cha reload grid
                this.Close();
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.Columns[e.ColumnIndex].Name == "btnDelete" && e.RowIndex >= 0)
            {
                danhSachChiTiet.RemoveAt(e.RowIndex);
                RefreshGrid();
            }
        }

        private void btnHuy_Click(object sender, EventArgs e) => this.Close();
    }
}