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
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            LoadHomeImage();
            lblHome.ForeColor = Color.FromArgb(51, 51, 51);
            lblHome.MouseEnter += (s, ev) =>
            {
                lblHome.ForeColor = Color.Blue;
            };

            lblHome.MouseLeave += (s, ev) =>
            {
                lblHome.ForeColor = Color.FromArgb(51, 51, 51);
            };
        }
        //Hàm mở Form con trong panelNoiDung
        private Form currentFormChild;
        private void OpenChildForm(Form childForm)
        { 
            if (currentFormChild != null)
                currentFormChild.Close();
            currentFormChild = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;

            panelNoiDung.Controls.Clear();//Xóa ảnh hoặc form cũ
            panelNoiDung.Controls.Add(childForm);

            childForm.BringToFront();
            childForm.Show();
        }

        private void btnHangHoa_Click(object sender, EventArgs e)
        {
            OpenChildForm(new FormHangHoa());
        }
        //Xử lý nút Home
        private void picHome_Click(object sender, EventArgs e)
        {
            ShowHome();
        }

        private void lblHome_Click(object sender, EventArgs e)
        {
            ShowHome();
        }
        private void ShowHome()
        {
            if (currentFormChild != null)
            {
                currentFormChild.Close();
                currentFormChild = null;
            }
            LoadHomeImage();
                
        }
        private void LoadHomeImage()
        {
            panelNoiDung.Controls.Clear();
            panelNoiDung.Controls.Add(picBia);
            picBia.Dock = DockStyle.Fill;
            picBia.BringToFront();
        }

        private void btnDanhMuc_Click(object sender, EventArgs e)
        {
            OpenChildForm(new FormDanhMuc());
        }

        private void btnNCC_Click(object sender, EventArgs e)
        {
            OpenChildForm(new FormNCC());
        }
    }
}
