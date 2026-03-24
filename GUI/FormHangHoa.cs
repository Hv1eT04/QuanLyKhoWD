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
            MessageBox.Show("FormHangHoa chạy");
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
            LoadHangHoa();
            LoadDanhMuc();
            LoadTrangThai();
        }
        void LoadHangHoa()
        {
            DataTable dt;
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
                int tt = Convert.ToInt32(dr["TrangThai"]);
                dr["TenTrangThai"] = (tt == 1) ? "Còn bán" : "Ngừng bán";
            }
            //Tô màu xám nếu ngừng kinh doanh (trạng thái = 0)
            DGVHangHoa.DataSource = dt;
            int last = DGVHangHoa.Columns.Count;

            DGVHangHoa.Columns["btnSua"].DisplayIndex = last - 3;
            DGVHangHoa.Columns["btnXoa"].DisplayIndex = last - 2;
            DGVHangHoa.Columns["btnKhoiPhuc"].DisplayIndex = last - 1;
            foreach (DataGridViewRow row in DGVHangHoa.Rows)
            {
                if (row.Cells["trangthai"].Value != null)
                {
                    int tt = Convert.ToInt32(row.Cells["trangthai"].Value);

                    if (tt == 0)
                    {
                        row.DefaultCellStyle.BackColor = Color.LightGray;
                        row.DefaultCellStyle.ForeColor = Color.Black;
                    }
                }
            }
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
            cbbTrangThai.SelectedIndex = 1;
        }
        private void btnThem_Click(object sender, EventArgs e)
        {
            HangHoaDTO hh = new HangHoaDTO();

            hh.MaCode = txtMaCode.Text;
            hh.TenHang = txtTenHang.Text;
            hh.DonViTinh = txtDonVi.Text;
            hh.DonGiaBan = double.Parse(txtDonGia.Text);
            hh.MaDanhMuc = Convert.ToInt32(CbbDanhMuc.SelectedValue);
            hh.TrangThai = Convert.ToInt32(cbbTrangThai.SelectedValue);
            hh.TonKhoHienTai = int.Parse(txtSoLuong.Text);
            hh.MucCanhBao = 0;
            bus.ThemHangHoa(hh);
            LoadHangHoa();
            MessageBox.Show("Thêm hàng hóa thành công!");
            if(hh.TonKhoHienTai <= hh.MucCanhBao)
            {
                MessageBox.Show("Cảnh báo: Hàng sắp hết!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnMoi_Click(object sender, EventArgs e)
        {
            ResetForm();
        }

        private void chkHienNgung_CheckedChanged(object sender, EventArgs e)
        {
            LoadHangHoa();
        }
    }
}
