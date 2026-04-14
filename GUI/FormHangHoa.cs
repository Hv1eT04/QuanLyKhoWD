using BLL;
using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace GUI
{
    public partial class FormHangHoa : Form
    {
        HangHoaBLL bus = new HangHoaBLL();
        DanhMucBLL danhmucBUS = new DanhMucBLL();
        public FormHangHoa()
        {
            InitializeComponent();
        }

        void StyleButton(Button btn, Color backColor)
        {
            btn.BackColor = backColor;
            btn.ForeColor = Color.White;
            btn.FlatStyle = FlatStyle.Flat;
            btn.FlatAppearance.BorderSize = 0;
            btn.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            btn.Cursor = Cursors.Hand;
        }
        void StyleTextBox(TextBox txt)
        {
            txt.BorderStyle = BorderStyle.FixedSingle;
            txt.Font = new Font("Segoe UI", 10);
            txt.BackColor = Color.White;
            txt.ForeColor = Color.Black;

            txt.Height = 30;
        }
        private void DGVHangHoa_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            string maCode = DGVHangHoa.Rows[e.RowIndex].Cells["macode"].Value.ToString();

            //NÚT SỬA
            if (DGVHangHoa.Columns[e.ColumnIndex].Name == "btnSua")
            {
                HangHoaDTO hh = new HangHoaDTO();

                hh.MaCode = maCode;
                hh.TenHang = DGVHangHoa.Rows[e.RowIndex].Cells["tenhang"].Value.ToString();
                hh.DonViTinh = DGVHangHoa.Rows[e.RowIndex].Cells["donvitinh"].Value.ToString();
                hh.DonGiaBan = double.Parse(DGVHangHoa.Rows[e.RowIndex].Cells["dongiaban"].Value.ToString());
                hh.MaDanhMuc = Convert.ToInt32(DGVHangHoa.Rows[e.RowIndex].Cells["madanhmuc"].Value);
                hh.TrangThai = Convert.ToInt32(DGVHangHoa.Rows[e.RowIndex].Cells["trangthai"].Value);
                hh.TonKhoHienTai = int.Parse(DGVHangHoa.Rows[e.RowIndex].Cells["tonkhohientai"].Value.ToString());
                hh.MucCanhBao = 0;

                bus.SuaHangHoa(hh);
                LoadHangHoa();
                MessageBox.Show("Sửa thành công!");
                return; // ❗ dừng tại đây
            }

            // NÚT XÓA 
            if (DGVHangHoa.Columns[e.ColumnIndex].Name == "btnXoa")
            {
                DialogResult r = MessageBox.Show("Ngừng kinh doanh hàng này?", "Xác nhận", MessageBoxButtons.YesNo);

                if (r == DialogResult.Yes)
                {
                    bus.Ngungkinhdoanh(maCode);
                    LoadHangHoa();
                    MessageBox.Show("Đã ngừng kinh doanh!");
                }
                return;
            }
            if (DGVHangHoa.Columns[e.ColumnIndex].Name == "btnKhoiPhuc")
            {
                DialogResult r = MessageBox.Show("Khôi phục hàng này?", "Xác nhận", MessageBoxButtons.YesNo);
                if (r == DialogResult.Yes)
                {
                    bus.KhoiPhucHangHoa(maCode);
                    LoadHangHoa();
                    MessageBox.Show("Đã khôi phục hàng hóa!");
                }
            }

            // CLICK DÒNG (không phải nút) → mới đổ dữ liệu
            txtMaCode.Text = maCode;
            txtTenHang.Text = DGVHangHoa.Rows[e.RowIndex].Cells["tenhang"].Value.ToString();
            txtSoLuong.Text = DGVHangHoa.Rows[e.RowIndex].Cells["tonkhohientai"].Value.ToString();
            txtDonGia.Text = DGVHangHoa.Rows[e.RowIndex].Cells["dongiaban"].Value.ToString();
            txtDonVi.Text = DGVHangHoa.Rows[e.RowIndex].Cells["donvitinh"].Value.ToString();
            CbbDanhMuc.SelectedValue = DGVHangHoa.Rows[e.RowIndex].Cells["madanhmuc"].Value;
            cbbTrangThai.SelectedValue = DGVHangHoa.Rows[e.RowIndex].Cells["trangthai"].Value;
        }

        private void FormHangHoa_Load(object sender, EventArgs e)
        {
            StyleButton(btnThem, Color.FromArgb(40, 167, 69));
            StyleButton(btnMoi, Color.FromArgb(0, 123, 255));

            //Style TextBox
            StyleTextBox(txtMaCode);
            StyleTextBox(txtTenHang);
            StyleTextBox(txtSoLuong);
            StyleTextBox(txtDonGia);
            StyleTextBox(txtDonVi);
            StyleTextBox(txtTimKiem);

            LoadHangHoa();
            LoadDanhMuc();
            LoadTrangThai();
            StyleDataGridView();
            ResetForm();
        }
        void LoadHangHoa()
        {
            DataTable dt = bus.GetAllHangHoaDangBan();
            if (chkHienNgung.Checked)
                dt = bus.GetAllHangHoa(); // tất cả
            else
                dt = bus.GetAllHangHoaDangBan(); // chỉ trạng thái = 1

            txtMaCode.Text = bus.TaoMaCode();

            // 👉 Thêm cột trạng thái chữ
            if (!dt.Columns.Contains("TenTrangThai"))
                dt.Columns.Add("TenTrangThai", typeof(string));

            foreach (DataRow dr in dt.Rows)
            {
                if (dr["TrangThai"] == DBNull.Value) continue;
                int tt = Convert.ToInt32(dr["TrangThai"]);
                dr["TenTrangThai"] = (tt == 1) ? "Còn bán" : "Ngừng bán";
            }
            //Tô màu xám nếu ngừng kinh doanh (trạng thái = 0)
            DGVHangHoa.DataSource = dt;
            //Ẩn cột
            DGVHangHoa.Columns["trangthai"].Visible = false;
            DGVHangHoa.Columns["muccanhbao"].Visible = false;
            DGVHangHoa.Columns["btnKhoiPhuc"].Visible = chkHienNgung.Checked;
            int last = DGVHangHoa.Columns.Count;

            DGVHangHoa.Columns["btnSua"].DisplayIndex = last - 3;
            DGVHangHoa.Columns["btnXoa"].DisplayIndex = last - 2;
            DGVHangHoa.Columns["btnKhoiPhuc"].DisplayIndex = last - 1;
            foreach (DataGridViewRow row in DGVHangHoa.Rows)
            {
                var value = row.Cells["trangthai"].Value;

                if (value == null || value == DBNull.Value) continue;

                int tt = Convert.ToInt32(value);

                if (tt == 0)
                {
                    row.DefaultCellStyle.BackColor = Color.LightGray;
                    row.DefaultCellStyle.ForeColor = Color.Black;
                }

            }
            foreach (DataGridViewRow row in DGVHangHoa.Rows)
            {
                if (row.Cells["tonkhohientai"].Value == null) continue;
                int tonkho = Convert.ToInt32(row.Cells["tonkhohientai"].Value);
                int mucCanhBao = 5;
                if (tonkho <= mucCanhBao)
                {
                    row.DefaultCellStyle.BackColor = Color.LightPink;
                    row.DefaultCellStyle.ForeColor = Color.Black;
                }
            }
            DGVHangHoa.Columns["mahang"].HeaderText = "Mã hàng";
            DGVHangHoa.Columns["macode"].HeaderText = "Mã code";
            DGVHangHoa.Columns["tenhang"].HeaderText = "Tên hàng";
            DGVHangHoa.Columns["madanhmuc"].HeaderText = "Danh mục";
            DGVHangHoa.Columns["donvitinh"].HeaderText = "Đơn vị";
            DGVHangHoa.Columns["dongiaban"].HeaderText = "Đơn giá";
            DGVHangHoa.Columns["tonkhohientai"].HeaderText = "Tồn kho";
            DGVHangHoa.Columns["TenTrangThai"].HeaderText = "Trạng thái";
        }

        void LoadDanhMuc()
        {
            CbbDanhMuc.DataSource = danhmucBUS.GetAllDanhMuc();
            CbbDanhMuc.DisplayMember = "TenDanhMuc";
            CbbDanhMuc.ValueMember = "MaDanhMuc";
        }
        void ResetForm()
            {
                txtMaCode.Text = bus.TaoMaCode();
                txtTenHang.Text = "";
                txtSoLuong.Text = "";
                txtDonGia.Text = "";
                txtDonVi.Text = "";
        }
        void LoadTrangThai()
        {
            var list = new List<object>
            {
                new { Value = 1, Text = "Còn hàng" },
                new { Value = 0, Text = "Hết hàng" }
            };
            cbbTrangThai.DataSource = list;
            cbbTrangThai.DisplayMember = "Text";
            cbbTrangThai.ValueMember = "Value";
            cbbTrangThai.SelectedIndex = 0;
        }
        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                HangHoaDTO hh = new HangHoaDTO();

                hh.MaCode = txtMaCode.Text;
                hh.TenHang = txtTenHang.Text;
                hh.DonViTinh = txtDonVi.Text;
                hh.DonGiaBan = double.Parse(txtDonGia.Text);
                hh.MaDanhMuc = Convert.ToInt32(CbbDanhMuc.SelectedValue);
                hh.TrangThai = Convert.ToInt32(cbbTrangThai.SelectedValue);
                hh.TonKhoHienTai = int.Parse(txtSoLuong.Text);
                hh.MucCanhBao = 5; 

                //GỌI BLL (validate + thêm)
                bus.ThemHangHoa(hh);

                //CẢNH BÁO
                if (bus.KiemTraCanhBao(hh))
                {
                    MessageBox.Show("Cảnh báo: Hàng sắp hết!",
                        "Thông báo",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                }

                LoadHangHoa();
                ResetForm();

                MessageBox.Show("Thêm hàng hóa thành công!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnMoi_Click(object sender, EventArgs e)
        {
            LoadHangHoa();
            LoadDanhMuc();
            LoadTrangThai();
            ResetForm();
        }

        private void chkHienNgung_CheckedChanged(object sender, EventArgs e)
        {
            LoadHangHoa();
        }

        private void txtTimKiem_TextChanged(object sender, EventArgs e)
        {
            string keyword = txtTimKiem.Text.Trim();

            if (string.IsNullOrEmpty(keyword))
            {
                LoadHangHoa(); // load lại danh sách đang bán
            }
            else
            {
                DGVHangHoa.DataSource = bus.TimKiemHangHoa(keyword);
            }
        }

        private void txtTimKiem_Enter(object sender, EventArgs e)
        {
            txtTimKiem.Text = "";
            txtTimKiem.ForeColor = Color.Black;
        }
        //Style DGV 
        void StyleDataGridView()
        {
            DGVHangHoa.BorderStyle = BorderStyle.None;
            DGVHangHoa.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(245, 245, 245);

            DGVHangHoa.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            DGVHangHoa.DefaultCellStyle.SelectionBackColor = Color.FromArgb(0, 120, 215);
            DGVHangHoa.DefaultCellStyle.SelectionForeColor = Color.White;

            DGVHangHoa.BackgroundColor = Color.White;
            DGVHangHoa.EnableHeadersVisualStyles = false;

            // Header
            DGVHangHoa.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            DGVHangHoa.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(30, 144, 255);
            DGVHangHoa.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            DGVHangHoa.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);

            // Font
            DGVHangHoa.DefaultCellStyle.Font = new Font("Segoe UI", 10);

            // Auto size
            DGVHangHoa.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            DGVHangHoa.RowTemplate.Height = 35;
        }
        
    }
}
