namespace GUI
{
    partial class FormTao
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.dgvChiTiet = new System.Windows.Forms.DataGridView();
            this.btnxoa = new System.Windows.Forms.DataGridViewButtonColumn();
            this.pnlBlock1 = new System.Windows.Forms.Panel();
            this.txtuser = new System.Windows.Forms.TextBox();
            this.cbbncc = new System.Windows.Forms.ComboBox();
            this.lbncc = new System.Windows.Forms.Label();
            this.txtnote = new System.Windows.Forms.TextBox();
            this.lbnote = new System.Windows.Forms.Label();
            this.lbuser = new System.Windows.Forms.Label();
            this.txtSoPhieu = new System.Windows.Forms.TextBox();
            this.lbsophieu = new System.Windows.Forms.Label();
            this.txtMaPN = new System.Windows.Forms.TextBox();
            this.lbmapn = new System.Windows.Forms.Label();
            this.btncancel = new System.Windows.Forms.Button();
            this.btnluu = new System.Windows.Forms.Button();
            this.pnlBlock2 = new System.Windows.Forms.Panel();
            this.cbbmahang = new System.Windows.Forms.ComboBox();
            this.txtdongianhap = new System.Windows.Forms.TextBox();
            this.lbmahang = new System.Windows.Forms.Label();
            this.lbsoluong = new System.Windows.Forms.Label();
            this.txtmact = new System.Windows.Forms.TextBox();
            this.txtsoluong = new System.Windows.Forms.TextBox();
            this.lbmact = new System.Windows.Forms.Label();
            this.txtluuct = new System.Windows.Forms.Button();
            this.lbmaphieunhap = new System.Windows.Forms.Label();
            this.lbdongianhap = new System.Windows.Forms.Label();
            this.txtMaPNCT = new System.Windows.Forms.TextBox();
            this.pnlBlock3 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.dgvChiTiet)).BeginInit();
            this.pnlBlock1.SuspendLayout();
            this.pnlBlock2.SuspendLayout();
            this.pnlBlock3.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvChiTiet
            // 
            this.dgvChiTiet.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvChiTiet.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.btnxoa});
            this.dgvChiTiet.Location = new System.Drawing.Point(3, 3);
            this.dgvChiTiet.Name = "dgvChiTiet";
            this.dgvChiTiet.RowHeadersWidth = 51;
            this.dgvChiTiet.RowTemplate.Height = 24;
            this.dgvChiTiet.Size = new System.Drawing.Size(1170, 219);
            this.dgvChiTiet.TabIndex = 30;
            this.dgvChiTiet.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvChiTiet_CellClick);
            // 
            // btnxoa
            // 
            this.btnxoa.HeaderText = "Xóa";
            this.btnxoa.MinimumWidth = 6;
            this.btnxoa.Name = "btnxoa";
            this.btnxoa.Text = "❌";
            this.btnxoa.UseColumnTextForButtonValue = true;
            this.btnxoa.Width = 125;
            // 
            // pnlBlock1
            // 
            this.pnlBlock1.Controls.Add(this.txtuser);
            this.pnlBlock1.Controls.Add(this.cbbncc);
            this.pnlBlock1.Controls.Add(this.lbncc);
            this.pnlBlock1.Controls.Add(this.txtnote);
            this.pnlBlock1.Controls.Add(this.lbnote);
            this.pnlBlock1.Controls.Add(this.lbuser);
            this.pnlBlock1.Controls.Add(this.txtSoPhieu);
            this.pnlBlock1.Controls.Add(this.lbsophieu);
            this.pnlBlock1.Controls.Add(this.txtMaPN);
            this.pnlBlock1.Controls.Add(this.lbmapn);
            this.pnlBlock1.Controls.Add(this.btncancel);
            this.pnlBlock1.Controls.Add(this.btnluu);
            this.pnlBlock1.Location = new System.Drawing.Point(1, 0);
            this.pnlBlock1.Name = "pnlBlock1";
            this.pnlBlock1.Size = new System.Drawing.Size(1176, 235);
            this.pnlBlock1.TabIndex = 45;
            // 
            // txtuser
            // 
            this.txtuser.Location = new System.Drawing.Point(186, 124);
            this.txtuser.Name = "txtuser";
            this.txtuser.ReadOnly = true;
            this.txtuser.Size = new System.Drawing.Size(121, 22);
            this.txtuser.TabIndex = 55;
            // 
            // cbbncc
            // 
            this.cbbncc.FormattingEnabled = true;
            this.cbbncc.Location = new System.Drawing.Point(186, 175);
            this.cbbncc.Name = "cbbncc";
            this.cbbncc.Size = new System.Drawing.Size(121, 24);
            this.cbbncc.TabIndex = 54;
            // 
            // lbncc
            // 
            this.lbncc.AutoSize = true;
            this.lbncc.Location = new System.Drawing.Point(63, 178);
            this.lbncc.Name = "lbncc";
            this.lbncc.Size = new System.Drawing.Size(93, 16);
            this.lbncc.TabIndex = 53;
            this.lbncc.Text = "Nhà cung cấp:";
            // 
            // txtnote
            // 
            this.txtnote.Location = new System.Drawing.Point(544, 26);
            this.txtnote.Multiline = true;
            this.txtnote.Name = "txtnote";
            this.txtnote.Size = new System.Drawing.Size(270, 185);
            this.txtnote.TabIndex = 52;
            // 
            // lbnote
            // 
            this.lbnote.AutoSize = true;
            this.lbnote.Location = new System.Drawing.Point(473, 40);
            this.lbnote.Name = "lbnote";
            this.lbnote.Size = new System.Drawing.Size(54, 16);
            this.lbnote.TabIndex = 51;
            this.lbnote.Text = "Ghi chú:";
            // 
            // lbuser
            // 
            this.lbuser.AutoSize = true;
            this.lbuser.Location = new System.Drawing.Point(63, 127);
            this.lbuser.Name = "lbuser";
            this.lbuser.Size = new System.Drawing.Size(68, 16);
            this.lbuser.TabIndex = 50;
            this.lbuser.Text = "Người lập:";
            // 
            // txtSoPhieu
            // 
            this.txtSoPhieu.Location = new System.Drawing.Point(186, 78);
            this.txtSoPhieu.Name = "txtSoPhieu";
            this.txtSoPhieu.ReadOnly = true;
            this.txtSoPhieu.Size = new System.Drawing.Size(121, 22);
            this.txtSoPhieu.TabIndex = 49;
            // 
            // lbsophieu
            // 
            this.lbsophieu.AutoSize = true;
            this.lbsophieu.Location = new System.Drawing.Point(63, 81);
            this.lbsophieu.Name = "lbsophieu";
            this.lbsophieu.Size = new System.Drawing.Size(63, 16);
            this.lbsophieu.TabIndex = 48;
            this.lbsophieu.Text = "Số phiếu:";
            // 
            // txtMaPN
            // 
            this.txtMaPN.Location = new System.Drawing.Point(186, 31);
            this.txtMaPN.Name = "txtMaPN";
            this.txtMaPN.ReadOnly = true;
            this.txtMaPN.Size = new System.Drawing.Size(121, 22);
            this.txtMaPN.TabIndex = 47;
            // 
            // lbmapn
            // 
            this.lbmapn.AutoSize = true;
            this.lbmapn.Location = new System.Drawing.Point(63, 34);
            this.lbmapn.Name = "lbmapn";
            this.lbmapn.Size = new System.Drawing.Size(98, 16);
            this.lbmapn.TabIndex = 46;
            this.lbmapn.Text = "Mã phiếu nhập:";
            // 
            // btncancel
            // 
            this.btncancel.Location = new System.Drawing.Point(929, 127);
            this.btncancel.Name = "btncancel";
            this.btncancel.Size = new System.Drawing.Size(145, 60);
            this.btncancel.TabIndex = 45;
            this.btncancel.Text = "Hủy bỏ";
            this.btncancel.UseVisualStyleBackColor = true;
            this.btncancel.Click += new System.EventHandler(this.btncancel_Click);
            // 
            // btnluu
            // 
            this.btnluu.Location = new System.Drawing.Point(929, 40);
            this.btnluu.Name = "btnluu";
            this.btnluu.Size = new System.Drawing.Size(145, 60);
            this.btnluu.TabIndex = 44;
            this.btnluu.Text = "Lưu";
            this.btnluu.UseVisualStyleBackColor = true;
            this.btnluu.Click += new System.EventHandler(this.btnluu_Click);
            // 
            // pnlBlock2
            // 
            this.pnlBlock2.Controls.Add(this.cbbmahang);
            this.pnlBlock2.Controls.Add(this.txtdongianhap);
            this.pnlBlock2.Controls.Add(this.lbmahang);
            this.pnlBlock2.Controls.Add(this.lbsoluong);
            this.pnlBlock2.Controls.Add(this.txtmact);
            this.pnlBlock2.Controls.Add(this.txtsoluong);
            this.pnlBlock2.Controls.Add(this.lbmact);
            this.pnlBlock2.Controls.Add(this.txtluuct);
            this.pnlBlock2.Controls.Add(this.lbmaphieunhap);
            this.pnlBlock2.Controls.Add(this.lbdongianhap);
            this.pnlBlock2.Controls.Add(this.txtMaPNCT);
            this.pnlBlock2.Location = new System.Drawing.Point(1, 253);
            this.pnlBlock2.Name = "pnlBlock2";
            this.pnlBlock2.Size = new System.Drawing.Size(1176, 178);
            this.pnlBlock2.TabIndex = 46;
            // 
            // cbbmahang
            // 
            this.cbbmahang.FormattingEnabled = true;
            this.cbbmahang.Location = new System.Drawing.Point(187, 123);
            this.cbbmahang.Name = "cbbmahang";
            this.cbbmahang.Size = new System.Drawing.Size(121, 24);
            this.cbbmahang.TabIndex = 57;
            // 
            // txtdongianhap
            // 
            this.txtdongianhap.Location = new System.Drawing.Point(679, 72);
            this.txtdongianhap.Name = "txtdongianhap";
            this.txtdongianhap.Size = new System.Drawing.Size(121, 22);
            this.txtdongianhap.TabIndex = 53;
            // 
            // lbmahang
            // 
            this.lbmahang.AutoSize = true;
            this.lbmahang.Location = new System.Drawing.Point(64, 123);
            this.lbmahang.Name = "lbmahang";
            this.lbmahang.Size = new System.Drawing.Size(62, 16);
            this.lbmahang.TabIndex = 56;
            this.lbmahang.Text = "Mã hàng:";
            // 
            // lbsoluong
            // 
            this.lbsoluong.AutoSize = true;
            this.lbsoluong.Location = new System.Drawing.Point(551, 28);
            this.lbsoluong.Name = "lbsoluong";
            this.lbsoluong.Size = new System.Drawing.Size(63, 16);
            this.lbsoluong.TabIndex = 47;
            this.lbsoluong.Text = "Số lượng:";
            // 
            // txtmact
            // 
            this.txtmact.Location = new System.Drawing.Point(187, 25);
            this.txtmact.Name = "txtmact";
            this.txtmact.ReadOnly = true;
            this.txtmact.Size = new System.Drawing.Size(121, 22);
            this.txtmact.TabIndex = 55;
            // 
            // txtsoluong
            // 
            this.txtsoluong.Location = new System.Drawing.Point(679, 25);
            this.txtsoluong.Name = "txtsoluong";
            this.txtsoluong.Size = new System.Drawing.Size(121, 22);
            this.txtsoluong.TabIndex = 48;
            // 
            // lbmact
            // 
            this.lbmact.AutoSize = true;
            this.lbmact.Location = new System.Drawing.Point(64, 28);
            this.lbmact.Name = "lbmact";
            this.lbmact.Size = new System.Drawing.Size(69, 16);
            this.lbmact.TabIndex = 54;
            this.lbmact.Text = "Mã chi tiết:";
            // 
            // txtluuct
            // 
            this.txtluuct.Location = new System.Drawing.Point(930, 53);
            this.txtluuct.Name = "txtluuct";
            this.txtluuct.Size = new System.Drawing.Size(145, 60);
            this.txtluuct.TabIndex = 49;
            this.txtluuct.Text = "Lưu";
            this.txtluuct.UseVisualStyleBackColor = true;
            this.txtluuct.Click += new System.EventHandler(this.txtluuct_Click);
            // 
            // lbmaphieunhap
            // 
            this.lbmaphieunhap.AutoSize = true;
            this.lbmaphieunhap.Location = new System.Drawing.Point(64, 75);
            this.lbmaphieunhap.Name = "lbmaphieunhap";
            this.lbmaphieunhap.Size = new System.Drawing.Size(98, 16);
            this.lbmaphieunhap.TabIndex = 50;
            this.lbmaphieunhap.Text = "Mã phiếu nhập:";
            // 
            // lbdongianhap
            // 
            this.lbdongianhap.AutoSize = true;
            this.lbdongianhap.Location = new System.Drawing.Point(551, 75);
            this.lbdongianhap.Name = "lbdongianhap";
            this.lbdongianhap.Size = new System.Drawing.Size(89, 16);
            this.lbdongianhap.TabIndex = 52;
            this.lbdongianhap.Text = "Đơn giá nhập:";
            // 
            // txtMaPNCT
            // 
            this.txtMaPNCT.Location = new System.Drawing.Point(187, 72);
            this.txtMaPNCT.Name = "txtMaPNCT";
            this.txtMaPNCT.ReadOnly = true;
            this.txtMaPNCT.Size = new System.Drawing.Size(121, 22);
            this.txtMaPNCT.TabIndex = 51;
            // 
            // pnlBlock3
            // 
            this.pnlBlock3.Controls.Add(this.dgvChiTiet);
            this.pnlBlock3.Location = new System.Drawing.Point(1, 446);
            this.pnlBlock3.Name = "pnlBlock3";
            this.pnlBlock3.Size = new System.Drawing.Size(1176, 233);
            this.pnlBlock3.TabIndex = 47;
            // 
            // FormTao
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1178, 682);
            this.Controls.Add(this.pnlBlock3);
            this.Controls.Add(this.pnlBlock2);
            this.Controls.Add(this.pnlBlock1);
            this.Name = "FormTao";
            this.Text = "Form Tạo Phiếu";
            this.Load += new System.EventHandler(this.FormTao_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvChiTiet)).EndInit();
            this.pnlBlock1.ResumeLayout(false);
            this.pnlBlock1.PerformLayout();
            this.pnlBlock2.ResumeLayout(false);
            this.pnlBlock2.PerformLayout();
            this.pnlBlock3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.DataGridView dgvChiTiet;
        private System.Windows.Forms.DataGridViewButtonColumn btnxoa;
        private System.Windows.Forms.Panel pnlBlock1;
        private System.Windows.Forms.TextBox txtuser;
        private System.Windows.Forms.ComboBox cbbncc;
        private System.Windows.Forms.Label lbncc;
        private System.Windows.Forms.TextBox txtnote;
        private System.Windows.Forms.Label lbnote;
        private System.Windows.Forms.Label lbuser;
        private System.Windows.Forms.TextBox txtSoPhieu;
        private System.Windows.Forms.Label lbsophieu;
        private System.Windows.Forms.TextBox txtMaPN;
        private System.Windows.Forms.Label lbmapn;
        private System.Windows.Forms.Button btncancel;
        private System.Windows.Forms.Button btnluu;
        private System.Windows.Forms.Panel pnlBlock2;
        private System.Windows.Forms.ComboBox cbbmahang;
        private System.Windows.Forms.TextBox txtdongianhap;
        private System.Windows.Forms.Label lbmahang;
        private System.Windows.Forms.Label lbsoluong;
        private System.Windows.Forms.TextBox txtmact;
        private System.Windows.Forms.TextBox txtsoluong;
        private System.Windows.Forms.Label lbmact;
        private System.Windows.Forms.Button txtluuct;
        private System.Windows.Forms.Label lbmaphieunhap;
        private System.Windows.Forms.Label lbdongianhap;
        private System.Windows.Forms.TextBox txtMaPNCT;
        private System.Windows.Forms.Panel pnlBlock3;
    }
}