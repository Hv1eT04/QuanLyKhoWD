using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BLL;
using DTO;
using DAL;

namespace GUI
{
    public partial class FormCTPhieuNhap : Form
    {
        int maPhieuNhap;
        CTPhieuNhapBLL bll = new CTPhieuNhapBLL();
        public FormCTPhieuNhap(int maPN)
        {
            InitializeComponent();
            this.maPhieuNhap = maPN;
        }
        void LoadChiTiet()
        {
            dgvCTPN.DataSource = bll.GetByMaPN(maPhieuNhap);
        }
        private void FormCTPhieuNhap_Load_1(object sender, EventArgs e)
        {
            LoadChiTiet();
        }
    }
}
