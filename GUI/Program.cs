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

            FormDangNhap login = new FormDangNhap();

            if (login.ShowDialog() == DialogResult.OK)
            {
                Application.Run(new FormMain(login.UserResult));
            }
            else
            {
                Application.Exit();
            }
        }
    }
}