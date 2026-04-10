using System;
using System.Data;
using System.Windows.Forms;

namespace GUI
{
    public partial class FormInBaoCao : Form
    {
        // 1. Khai báo biến cục bộ để hứng dữ liệu
        private DataTable _dtSource;

        // 2. Sửa Constructor để nó nhận DataTable từ Form chính
        public FormInBaoCao(DataTable dt)
        {
            InitializeComponent();
            this._dtSource = dt; // Lưu dữ liệu vào biến cục bộ
        }

        private void crvHienThi_Load(object sender, EventArgs e)
        {
            try
            {

                // 3. Khởi tạo đối tượng báo cáo rptBaoCaoKho
                rptBaoCaoKho rpt = new rptBaoCaoKho();

                // 4. Đổ DataTable của bạn vào báo cáo
                // Nếu thiếu dòng này, Crystal Reports sẽ không có dữ liệu để hiện
                rpt.SetDataSource(_dtSource);

                // 5. Gán báo cáo đã có dữ liệu vào Viewer
                // (Giả sử bạn đặt tên Viewer là crvHienThi)
                crvHienThi.ReportSource = rpt;

                // 6. Làm mới Viewer
                crvHienThi.Refresh();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi hiển thị báo cáo: " + ex.Message, "Lỗi",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}