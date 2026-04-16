using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using BLL;
using DTO;

namespace GUI
{
    public partial class FormNhapCommon : Form
    {
        private PhieuNhapBLL bll = new PhieuNhapBLL();
        private CTPhieuNhapBLL bllCT = new CTPhieuNhapBLL();
        private NhaCCBLL bllNCC = new NhaCCBLL();
        private List<CTPhieuNhapDTO> danhSachChiTiet = new List<CTPhieuNhapDTO>();

        public NguoiDungDTO UserResult { get; set; }
        private int currentMaPN = -1;
        private string currentMode = "ADD";

        public FormNhapCommon(NguoiDungDTO user)
        {
            InitializeComponent();
            this.UserResult = user;
            this.currentMode = "ADD";
            InitForm();
        }

        public FormNhapCommon(NguoiDungDTO user, int maPN, string mode)
        {
            InitializeComponent();
            this.UserResult = user;
            this.currentMaPN = maPN;
            this.currentMode = mode.ToUpper();
            InitForm();
            LoadDataFromDatabase(maPN);
        }

        private void InitForm()
        {
            SetupGrid();
            LoadCombo();

            if (currentMode == "ADD")
            {
                this.Text = "Lập Phiếu Nhập Kho Mới";
                txtSoPhieu.Text = bll.GetNextMaPhieuNhap();
            }
            else if (currentMode == "VIEW")
            {
                this.Text = "Chi Tiết Phiếu Nhập (Chỉ Xem)";
                LockControls();
            }
            else if (currentMode == "EDIT")
            {
                this.Text = "Chỉnh Sửa Phiếu Nhập";
                txtSoPhieu.ReadOnly = true;
                cboNhaCungCap.Enabled = false;
            }
        }

        private void SetupGrid()
        {
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.Columns.Clear();
            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "MaHang", HeaderText = "Mã Hàng", Name = "cMa", ReadOnly = true, Width = 80 });
            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "TenHang", HeaderText = "Tên hàng hóa", Name = "cTen", ReadOnly = true, Width = 200 });
            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "SoLuong", HeaderText = "SL Nhập", Name = "cSL", ReadOnly = false, Width = 80 });
            DataGridViewTextBoxColumn colGia = new DataGridViewTextBoxColumn { DataPropertyName = "GiaNhap", HeaderText = "Giá Nhập", Name = "cGia", ReadOnly = false, Width = 120 };
            colGia.DefaultCellStyle.Format = "N0";
            dataGridView1.Columns.Add(colGia);
            DataGridViewTextBoxColumn colTT = new DataGridViewTextBoxColumn { DataPropertyName = "ThanhTien", HeaderText = "Thành tiền", Name = "cTT", ReadOnly = true, AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill };
            colTT.DefaultCellStyle.Format = "N0";
            dataGridView1.Columns.Add(colTT);

            DataGridViewButtonColumn btnDel = new DataGridViewButtonColumn { Text = "Xóa", Name = "btnDelete", UseColumnTextForButtonValue = true, HeaderText = "Tùy chọn", Width = 60 };
            dataGridView1.Columns.Add(btnDel);

            dataGridView1.CellValueChanged += DataGridView1_CellValueChanged;
            dataGridView1.CellContentClick += dataGridView1_CellContentClick;
        }

        private void LoadCombo()
        {
            cboHangHoa.DataSource = bll.GetAllHangHoaCommon();
            cboHangHoa.DisplayMember = "tenhang";
            cboHangHoa.ValueMember = "mahang";
            cboHangHoa.SelectedIndex = -1;

            cboNhaCungCap.DataSource = bllNCC.GetALL();
            cboNhaCungCap.DisplayMember = "TenNCC";
            cboNhaCungCap.ValueMember = "MaNCC";
            cboNhaCungCap.SelectedIndex = -1;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (cboHangHoa.SelectedIndex == -1) return;
            if (!int.TryParse(txtSoLuong.Text, out int sl) || sl <= 0) return;
            if (!decimal.TryParse(txtGiaNhap.Text, out decimal gia) || gia < 0) return;

            DataRowView row = (DataRowView)cboHangHoa.SelectedItem;
            string maHangMoi = row["mahang"].ToString();

            var itemTonTai = danhSachChiTiet.FirstOrDefault(x => x.MaHang == maHangMoi);
            if (itemTonTai != null) { itemTonTai.SoLuong += sl; itemTonTai.GiaNhap = gia; }
            else { danhSachChiTiet.Add(new CTPhieuNhapDTO { MaHang = maHangMoi, TenHang = row["tenhang"].ToString(), SoLuong = sl, GiaNhap = gia }); }

            RefreshGrid();
            txtSoLuong.Clear(); txtGiaNhap.Clear();
            cboHangHoa.SelectedIndex = -1; cboHangHoa.Focus();
        }

        private void RefreshGrid()
        {
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = danhSachChiTiet;
            lblTongTien.Text = $"Thành tiền: {danhSachChiTiet.Sum(x => x.ThanhTien):N0} VND";
        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && dataGridView1.Columns[e.ColumnIndex].Name == "btnDelete" && currentMode != "VIEW")
            {
                danhSachChiTiet.RemoveAt(e.RowIndex);
                RefreshGrid();
            }
        }

        private void DataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && currentMode != "VIEW") RefreshGrid();
        }

        private void LockControls()
        {
            btnLuuPhieu.Visible = false; btnThem.Enabled = false;
            txtGhiChu.ReadOnly = true; cboHangHoa.Enabled = false;
            cboNhaCungCap.Enabled = false; txtSoLuong.ReadOnly = true;
            txtGiaNhap.ReadOnly = true; dataGridView1.ReadOnly = true;
        }

        private void LoadDataFromDatabase(int maPN)
        {
            DataTable dtPhieu = bll.GetPhieuNhapByMaID(maPN);
            if (dtPhieu.Rows.Count > 0)
            {
                txtSoPhieu.Text = dtPhieu.Rows[0]["sophieu"].ToString();
                txtGhiChu.Text = dtPhieu.Rows[0]["ghichu"].ToString();
                cboNhaCungCap.SelectedValue = dtPhieu.Rows[0]["MaNCC"];
            }
            DataTable dtDetails = bllCT.GetChiTietByMaPN(maPN);
            danhSachChiTiet.Clear();
            foreach (DataRow row in dtDetails.Rows)
            {
                danhSachChiTiet.Add(new CTPhieuNhapDTO { MaHang = row["mahang"].ToString(), TenHang = row["tenhang"].ToString(), SoLuong = Convert.ToInt32(row["soluong"]), GiaNhap = Convert.ToDecimal(row["dongianhap"]) });
            }
            RefreshGrid();
        }

        private void btnHuy_Click(object sender, EventArgs e) => this.Close();

        private void btnLuuPhieu_Click_1(object sender, EventArgs e)
        {
            if (cboNhaCungCap.SelectedValue == null) { MessageBox.Show("Vui lòng chọn Nhà Cung Cấp!"); return; }
            if (danhSachChiTiet.Count == 0) { MessageBox.Show("Phiếu nhập phải có ít nhất một mặt hàng!"); return; }

            PhieuNhapDTO pn = new PhieuNhapDTO
            {
                SoPhieu = txtSoPhieu.Text,
                GhiChu = txtGhiChu.Text,
                MaNCC = Convert.ToInt32(cboNhaCungCap.SelectedValue),
                NguoiLap = UserResult?.manguoidung ?? 1,
                NgayTao = DateTime.Now,
                TrangThai = 1
            };

            bool success = false;
            if (currentMode == "ADD")
                success = bll.LuuPhieuHoanChinh(pn, danhSachChiTiet);
            else if (currentMode == "EDIT")
                // FIX: Truyền đủ 4 tham số khớp với BLL
                success = bll.CapNhatPhieu(currentMaPN, pn.GhiChu, pn.MaNCC, danhSachChiTiet);

            if (success) { MessageBox.Show("Lưu thành công!"); this.DialogResult = DialogResult.OK; this.Close(); }
            else MessageBox.Show("Lưu thất bại!");
        }
    }
}