using System;
using System.Windows.Forms;

namespace GUI
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // 1. Khởi tạo Form đăng nhập
            FormDangNhap login = new FormDangNhap();

            // 2. Hiện Form đăng nhập dưới dạng Dialog (chờ xử lý xong mới chạy tiếp)
            if (login.ShowDialog() == DialogResult.OK)
            {
                // 3. Nếu Login trả về OK (do ta gán ở bước trên), thì mới chạy FormMain
                Application.Run(new FormMain());
            }
            else
            {
                // Nếu đóng form login hoặc login fail thì thoát ứng dụng
                Application.Exit();
            }
        }
    }
}