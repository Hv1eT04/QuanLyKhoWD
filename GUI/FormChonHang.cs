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
    public partial class FormChonHang : Form
    {
        public List<HangChonDTO> dsHangChon = new List<HangChonDTO>();
        public FormChonHang()
        {
            InitializeComponent();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            dsHangChon.Clear();

            foreach (DataGridViewRow row in dgvHang.Rows)
            {
                if (row.Cells["soluong"].Value != null &&
                    int.TryParse(row.Cells["soluong"].Value.ToString(), out int sl) &&
                    sl > 0)
                {
                    dsHangChon.Add(new HangChonDTO
                    {
                        MaHang = Convert.ToInt32(row.Cells["mahang"].Value),
                        SoLuong = sl,
                        DonGia = Convert.ToDouble(row.Cells["dongia"].Value)
                    });
                }
            }

            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
