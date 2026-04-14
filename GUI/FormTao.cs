using BLL;
using DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI
{
    public partial class FormTao : Form
    {
        private FormMode mode;
        private int maPN = 0;

        public FormTao(FormMode mode)
        {
            InitializeComponent();
            this.mode = mode;
            this.maPN = 0;
        }

        public FormTao(FormMode mode, int maPN)
        {
            InitializeComponent();
            this.mode = mode;
            this.maPN = maPN;
        }

        private void FormTao_Load(object sender, EventArgs e)
        {
            LoadMaHang();
            LoadNCC();

            txtuser.Text = FormDangNhap.currentUser.hoten;

            if (mode == FormMode.Tao)
            {
                txtSoPhieu.Text = new PhieuNhapBLL().TaoSoPhieu();
                pnlBlock2.Enabled = false;
            }

            if (mode == FormMode.Sua)
            {
                LoadPhieu();
                LoadChiTiet();
                pnlBlock2.Enabled = true;
            }
        }

        // ================= LOAD PHIẾU =================
        void LoadPhieu()
        {
            var bll = new PhieuNhapBLL();
            var data = bll.GetById(maPN);

            if (data == null) return;

            txtMaPN.Text = data.MaPhieuNhap.ToString();
            txtSoPhieu.Text = data.SoPhieu;
            txtnote.Text = data.GhiChu;

            cbbncc.SelectedValue = data.MaNCC;
        }

        // ================= LOAD HÀNG =================
        void LoadMaHang()
        {
            HangHoaBLL bll = new HangHoaBLL();

            cbbmahang.DataSource = bll.GetAllHangHoaDangBan();
            cbbmahang.DisplayMember = "tenhang";
            cbbmahang.ValueMember = "mahang";
        }

        // ================= LOAD NCC =================
        void LoadNCC()
        {
            NhaCCBLL bll = new NhaCCBLL();

            var list = bll.GetALL();

            cbbncc.DataSource = list;
            cbbncc.DisplayMember = "TenNCC";
            cbbncc.ValueMember = "MaNCC";
        }

        // ================= LOAD CHI TIẾT =================
        void LoadChiTiet()
        {
            if (maPN <= 0) return;

            CTPhieuNhapBLL bll = new CTPhieuNhapBLL();
            dgvChiTiet.DataSource = bll.GetByMaPN(maPN);
        }

        // ================= LƯU PHIẾU =================
        private void btnluu_Click(object sender, EventArgs e)
        {
            PhieuNhapDTO pn = new PhieuNhapDTO
            {
                SoPhieu = txtSoPhieu.Text,
                GhiChu = txtnote.Text,
                MaNCC = Convert.ToInt32(cbbncc.SelectedValue),
                NguoiLap = FormDangNhap.currentUser.manguoidung,
                TrangThai = 0
            };

            PhieuNhapBLL bll = new PhieuNhapBLL();

            maPN = bll.InsertAndGetId(pn); // 🔥 lấy ID từ DB

            txtMaPN.Text = maPN.ToString();
            txtMaPNCT.Text = maPN.ToString();

            MessageBox.Show("Lưu phiếu thành công!");

            pnlBlock1.Enabled = false;
            pnlBlock2.Enabled = true;

            LoadChiTiet(); // 🔥 realtime
        }

        // ================= THÊM CHI TIẾT =================
        private void txtluuct_Click(object sender, EventArgs e)
        {
            if (maPN <= 0)
            {
                MessageBox.Show("Vui lòng lưu phiếu trước!");
                return;
            }

            if (!int.TryParse(txtsoluong.Text, out int sl))
            {
                MessageBox.Show("Số lượng không hợp lệ!");
                return;
            }

            if (!double.TryParse(txtdongianhap.Text, out double dg))
            {
                MessageBox.Show("Đơn giá không hợp lệ!");
                return;
            }

            CTPhieuNhapDTO ct = new CTPhieuNhapDTO
            {
                maphieunhap = maPN,
                mahang = Convert.ToInt32(cbbmahang.SelectedValue),
                soluong = sl,
                dongianhap = dg
            };

            new CTPhieuNhapBLL().Insert(ct);
            new HangHoaBLL().CongTonKho(ct.mahang, ct.soluong);

            LoadChiTiet(); // 🔥 realtime update

            txtsoluong.Clear();
            txtdongianhap.Clear();
        }

        // ================= XÓA CHI TIẾT =================
        private void dgvChiTiet_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            if (dgvChiTiet.Columns[e.ColumnIndex].Name == "btnxoa")
            {
                var row = dgvChiTiet.Rows[e.RowIndex];

                int maCT = Convert.ToInt32(row.Cells["machitiet"].Value);
                int maHang = Convert.ToInt32(row.Cells["mahang"].Value);
                int sl = Convert.ToInt32(row.Cells["soluong"].Value);

                new CTPhieuNhapBLL().Delete(maCT);
                new HangHoaBLL().TruTonKho(maHang, sl);

                LoadChiTiet(); // 🔥 realtime
            }
        }

        private void btncancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
