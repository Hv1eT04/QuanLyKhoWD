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
            // 1. Validate dữ liệu
            if (cboHangHoa.SelectedIndex == -1) { MessageBox.Show("Vui lòng chọn hàng hóa!"); return; }
            if (!int.TryParse(txtSoLuong.Text, out int sl) || sl <= 0) { MessageBox.Show("Số lượng không hợp lệ!"); return; }
            if (!decimal.TryParse(txtGiaNhap.Text.Replace(",", ""), out decimal gia) || gia <= 0) { MessageBox.Show("Giá nhập không hợp lệ!"); return; }

            DataRowView row = (DataRowView)cboHangHoa.SelectedItem;
            int maHangMoi = Convert.ToInt32(row["mahang"]);
            string tenHang = row["tenhang"].ToString();
            decimal giaNhapMoi = Convert.ToDecimal(txtGiaNhap.Text.Replace(",", ""));


            // CHỈ gộp nếu trùng khít cả MÃ HÀNG và GIÁ NHẬP
            var itemDaCo = danhSachChiTiet.FirstOrDefault(x =>
                Convert.ToInt32(x.MaHang) == maHangMoi &&
                decimal.Equals(x.GiaNhap, giaNhapMoi)
            );

            if (itemDaCo != null)
            {
                // Nếu trùng cả giá -> Cộng dồn số lượng vào dòng đó
                itemDaCo.SoLuong += Convert.ToInt32(txtSoLuong.Text);
            }
            else
            {
                // Nếu GIÁ KHÁC hoặc MÃ KHÁC -> Luôn thêm dòng mới vào danh sách
                danhSachChiTiet.Add(new CTPhieuNhapDTO
                {
                    MaHang = maHangMoi.ToString(),
                    TenHang = cboHangHoa.Text,
                    SoLuong = Convert.ToInt32(txtSoLuong.Text),
                    GiaNhap = giaNhapMoi
                });
            }
            RefreshGrid();

            // Clear và focus để nhập tiếp
            txtSoLuong.Clear();
            txtGiaNhap.Clear();
            cboHangHoa.SelectedIndex = -1;
            cboHangHoa.Focus();
        }

        private void RefreshGrid()
        {
            dataGridView1.DataSource = null;
            // .ToList() giúp tạo ra một vùng nhớ mới, tránh việc Grid tự gộp dữ liệu cũ
            dataGridView1.DataSource = danhSachChiTiet.ToList();

            if (dataGridView1.Columns["cGia"] != null)
                dataGridView1.Columns["cGia"].DefaultCellStyle.Format = "N0";

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
        private void btnLuuPhieu_Click(object sender, EventArgs e)
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