using BLL;
using DTO;
using System;
using System.Windows.Forms;

namespace GUI
{
    public partial class FormDangNhap : Form
    {
        NguoiDungBLL bll = new NguoiDungBLL();

        public FormDangNhap()
        {
            InitializeComponent();
        }

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            try
            {
                string user = txtTenDangNhap.Text;
                string pass = txtMatKhau.Text;

                NguoiDungDTO result = bll.DangNhap(user, pass);

                if (result != null)
                {
                    MessageBox.Show("Đăng nhập thành công! Chào " + result.hovaten);

                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Sai tên đăng nhập hoặc mật khẩu!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}