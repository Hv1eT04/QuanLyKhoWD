using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using BLL;

namespace GUI
{
    public partial class FormBaoCao : Form
    {
        private BaoCaoBLL reportBLL = new BaoCaoBLL();

        // Biến toàn cục lưu trữ dữ liệu sau khi nhấn "Xem"
        private DataTable dtBaoCao;

        public FormBaoCao()
        {
            InitializeComponent();
            // Mặc định xem từ đầu tháng hiện tại
            dtpTuNgay.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            dtpDenNgay.Value = DateTime.Now;
        }

        private void btnXemBaoCao_Click(object sender, EventArgs e)
        {
            try
            {
                DateTime tu = dtpTuNgay.Value;
                DateTime den = dtpDenNgay.Value;

                // 1. Lấy dữ liệu từ tầng BLL
                dtBaoCao = reportBLL.LayBaoCao(tu, den);

                // 2. Hiển thị lên lưới DataGridView
                dgvKetQua.DataSource = dtBaoCao;

                // 3. Định dạng cột và tô màu
                FormatGrid();
                ColorRows();

                // 4. Tính toán tổng hợp
                decimal tongNhap = reportBLL.TinhTongNhap(dtBaoCao);
                decimal tongXuat = reportBLL.TinhTongXuat(dtBaoCao);
                decimal chenhLech = tongXuat - tongNhap;

                lblThongKe.Text = string.Format("Tổng Nhập: {0:N0} | Tổng Xuất: {1:N0} | Chênh lệch: {2:N0} VNĐ",
                                                tongNhap, tongXuat, chenhLech);

                if (dtBaoCao.Rows.Count == 0)
                {
                    MessageBox.Show("Không có dữ liệu trong khoảng thời gian này!", "Thông báo",
                                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải dữ liệu: " + ex.Message, "Lỗi",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnInBaoCao_Click(object sender, EventArgs e)
        {
            // Kiểm tra xem người dùng đã nhấn "Xem" để có dữ liệu chưa
            if (dtBaoCao == null || dtBaoCao.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu để in! Vui lòng nhấn nút 'Xem' trước.",
                                "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                // Mở Form hiển thị báo cáo và truyền DataTable vào constructor
                FormInBaoCao frmIn = new FormInBaoCao(dtBaoCao);
                frmIn.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi khởi tạo báo cáo: " + ex.Message, "Lỗi",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FormatGrid()
        {
            if (dgvKetQua.Columns.Count > 0)
            {
                dgvKetQua.Columns["LoaiPhieu"].HeaderText = "Loại";
                dgvKetQua.Columns["sophieu"].HeaderText = "Số Phiếu";
                dgvKetQua.Columns["ngaytao"].HeaderText = "Ngày Giao Dịch";
                dgvKetQua.Columns["tenhang"].HeaderText = "Tên Hàng";
                dgvKetQua.Columns["soluong"].HeaderText = "Số Lượng";
                dgvKetQua.Columns["dongia"].HeaderText = "Đơn Giá";
                dgvKetQua.Columns["thanhtien"].HeaderText = "Thành Tiền";

                // Định dạng hiển thị số tiền có dấu phân cách hàng nghìn
                dgvKetQua.Columns["dongia"].DefaultCellStyle.Format = "N0";
                dgvKetQua.Columns["thanhtien"].DefaultCellStyle.Format = "N0";
                dgvKetQua.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }
        }

        private void ColorRows()
        {
            foreach (DataGridViewRow row in dgvKetQua.Rows)
            {
                if (row.Cells["LoaiPhieu"].Value != null)
                {
                    string type = row.Cells["LoaiPhieu"].Value.ToString();
                    if (type == "Xuất")
                        row.DefaultCellStyle.BackColor = Color.FromArgb(230, 255, 230); // Xanh nhạt
                    else
                        row.DefaultCellStyle.BackColor = Color.FromArgb(255, 240, 240); // Hồng nhạt
                }
            }
        }
    }
}