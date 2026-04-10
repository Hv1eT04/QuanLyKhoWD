namespace GUI
{
    partial class FormHangHoa
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
            this.chkHienNgung = new System.Windows.Forms.CheckBox();
            this.txtTimKiem = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnThem = new System.Windows.Forms.Button();
            this.btnMoi = new System.Windows.Forms.Button();
            this.cbbTrangThai = new System.Windows.Forms.ComboBox();
            this.CbbDanhMuc = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtSoLuong = new System.Windows.Forms.TextBox();
            this.txtDonVi = new System.Windows.Forms.TextBox();
            this.txtDonGia = new System.Windows.Forms.TextBox();
            this.txtTenHang = new System.Windows.Forms.TextBox();
            this.txtMaCode = new System.Windows.Forms.TextBox();
            this.panelMain = new System.Windows.Forms.Panel();
            this.DGVHangHoa = new System.Windows.Forms.DataGridView();
            this.btnSua = new System.Windows.Forms.DataGridViewButtonColumn();
            this.btnXoa = new System.Windows.Forms.DataGridViewButtonColumn();
            this.btnKhoiPhuc = new System.Windows.Forms.DataGridViewButtonColumn();
            this.panel1.SuspendLayout();
            this.panelMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGVHangHoa)).BeginInit();
            this.SuspendLayout();
            // 
            // chkHienNgung
            // 
            this.chkHienNgung.AutoSize = true;
            this.chkHienNgung.Location = new System.Drawing.Point(172, 227);
            this.chkHienNgung.Name = "chkHienNgung";
            this.chkHienNgung.Size = new System.Drawing.Size(130, 20);
            this.chkHienNgung.TabIndex = 19;
            this.chkHienNgung.Text = "Hàng hiện ngưng";
            this.chkHienNgung.UseVisualStyleBackColor = true;
            this.chkHienNgung.CheckedChanged += new System.EventHandler(this.chkHienNgung_CheckedChanged);
            // 
            // txtTimKiem
            // 
            this.txtTimKiem.Location = new System.Drawing.Point(827, 228);
            this.txtTimKiem.Name = "txtTimKiem";
            this.txtTimKiem.Size = new System.Drawing.Size(240, 22);
            this.txtTimKiem.TabIndex = 20;
            this.txtTimKiem.Text = "Tìm kiếm ....";
            this.txtTimKiem.TextChanged += new System.EventHandler(this.txtTimKiem_TextChanged);
            this.txtTimKiem.Enter += new System.EventHandler(this.txtTimKiem_Enter);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnThem);
            this.panel1.Controls.Add(this.txtTimKiem);
            this.panel1.Controls.Add(this.btnMoi);
            this.panel1.Controls.Add(this.chkHienNgung);
            this.panel1.Controls.Add(this.cbbTrangThai);
            this.panel1.Controls.Add(this.CbbDanhMuc);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.txtSoLuong);
            this.panel1.Controls.Add(this.txtDonVi);
            this.panel1.Controls.Add(this.txtDonGia);
            this.panel1.Controls.Add(this.txtTenHang);
            this.panel1.Controls.Add(this.txtMaCode);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1203, 257);
            this.panel1.TabIndex = 21;
            // 
            // btnThem
            // 
            this.btnThem.BackColor = System.Drawing.Color.SteelBlue;
            this.btnThem.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThem.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnThem.Location = new System.Drawing.Point(925, 44);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(99, 45);
            this.btnThem.TabIndex = 34;
            this.btnThem.Text = "+ Thêm";
            this.btnThem.UseVisualStyleBackColor = false;
            // 
            // btnMoi
            // 
            this.btnMoi.Location = new System.Drawing.Point(935, 119);
            this.btnMoi.Name = "btnMoi";
            this.btnMoi.Size = new System.Drawing.Size(80, 40);
            this.btnMoi.TabIndex = 33;
            this.btnMoi.Text = "Làm mới";
            this.btnMoi.UseVisualStyleBackColor = true;
            // 
            // cbbTrangThai
            // 
            this.cbbTrangThai.FormattingEnabled = true;
            this.cbbTrangThai.Location = new System.Drawing.Point(614, 143);
            this.cbbTrangThai.Name = "cbbTrangThai";
            this.cbbTrangThai.Size = new System.Drawing.Size(250, 24);
            this.cbbTrangThai.TabIndex = 32;
            // 
            // CbbDanhMuc
            // 
            this.CbbDanhMuc.FormattingEnabled = true;
            this.CbbDanhMuc.Location = new System.Drawing.Point(240, 115);
            this.CbbDanhMuc.Name = "CbbDanhMuc";
            this.CbbDanhMuc.Size = new System.Drawing.Size(237, 24);
            this.CbbDanhMuc.TabIndex = 31;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(519, 143);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(67, 16);
            this.label7.TabIndex = 30;
            this.label7.Text = "Trạng thái";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(533, 99);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(44, 16);
            this.label6.TabIndex = 29;
            this.label6.Text = "Đơn vị";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(533, 38);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 16);
            this.label5.TabIndex = 28;
            this.label5.Text = "Đơn giá";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(169, 169);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(60, 16);
            this.label4.TabIndex = 27;
            this.label4.Text = "Số lượng";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(166, 114);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(67, 16);
            this.label3.TabIndex = 26;
            this.label3.Text = "Danh mục";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(166, 72);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 16);
            this.label2.TabIndex = 25;
            this.label2.Text = "Tên Hàng";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(163, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 16);
            this.label1.TabIndex = 24;
            this.label1.Text = "Mã Code";
            // 
            // txtSoLuong
            // 
            this.txtSoLuong.Location = new System.Drawing.Point(242, 169);
            this.txtSoLuong.Name = "txtSoLuong";
            this.txtSoLuong.Size = new System.Drawing.Size(235, 22);
            this.txtSoLuong.TabIndex = 23;
            // 
            // txtDonVi
            // 
            this.txtDonVi.Location = new System.Drawing.Point(614, 93);
            this.txtDonVi.Name = "txtDonVi";
            this.txtDonVi.Size = new System.Drawing.Size(250, 22);
            this.txtDonVi.TabIndex = 22;
            // 
            // txtDonGia
            // 
            this.txtDonGia.Location = new System.Drawing.Point(614, 38);
            this.txtDonGia.Name = "txtDonGia";
            this.txtDonGia.Size = new System.Drawing.Size(250, 22);
            this.txtDonGia.TabIndex = 21;
            // 
            // txtTenHang
            // 
            this.txtTenHang.Location = new System.Drawing.Point(242, 67);
            this.txtTenHang.Name = "txtTenHang";
            this.txtTenHang.Size = new System.Drawing.Size(235, 22);
            this.txtTenHang.TabIndex = 20;
            // 
            // txtMaCode
            // 
            this.txtMaCode.Location = new System.Drawing.Point(242, 23);
            this.txtMaCode.Name = "txtMaCode";
            this.txtMaCode.ReadOnly = true;
            this.txtMaCode.Size = new System.Drawing.Size(235, 22);
            this.txtMaCode.TabIndex = 19;
            // 
            // panelMain
            // 
            this.panelMain.BackColor = System.Drawing.Color.White;
            this.panelMain.Controls.Add(this.DGVHangHoa);
            this.panelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMain.Location = new System.Drawing.Point(0, 257);
            this.panelMain.Name = "panelMain";
            this.panelMain.Size = new System.Drawing.Size(1203, 357);
            this.panelMain.TabIndex = 35;
            // 
            // DGVHangHoa
            // 
            this.DGVHangHoa.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGVHangHoa.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.btnSua,
            this.btnXoa,
            this.btnKhoiPhuc});
            this.DGVHangHoa.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DGVHangHoa.Location = new System.Drawing.Point(0, 0);
            this.DGVHangHoa.Name = "DGVHangHoa";
            this.DGVHangHoa.RowHeadersWidth = 51;
            this.DGVHangHoa.RowTemplate.Height = 24;
            this.DGVHangHoa.Size = new System.Drawing.Size(1203, 357);
            this.DGVHangHoa.TabIndex = 2;
            // 
            // btnSua
            // 
            this.btnSua.HeaderText = "Sửa";
            this.btnSua.MinimumWidth = 6;
            this.btnSua.Name = "btnSua";
            this.btnSua.Text = "✏️";
            this.btnSua.UseColumnTextForButtonValue = true;
            this.btnSua.Width = 125;
            // 
            // btnXoa
            // 
            this.btnXoa.HeaderText = "Xóa";
            this.btnXoa.MinimumWidth = 6;
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Text = "❌";
            this.btnXoa.UseColumnTextForButtonValue = true;
            this.btnXoa.Width = 125;
            // 
            // btnKhoiPhuc
            // 
            this.btnKhoiPhuc.HeaderText = "Khôi phục";
            this.btnKhoiPhuc.MinimumWidth = 6;
            this.btnKhoiPhuc.Name = "btnKhoiPhuc";
            this.btnKhoiPhuc.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.btnKhoiPhuc.Text = "Khôi phục";
            this.btnKhoiPhuc.UseColumnTextForButtonValue = true;
            this.btnKhoiPhuc.Width = 125;
            // 
            // FormHangHoa
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1203, 614);
            this.Controls.Add(this.panelMain);
            this.Controls.Add(this.panel1);
            this.Name = "FormHangHoa";
            this.Text = "FormHangHoa";
            this.Load += new System.EventHandler(this.FormHangHoa_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panelMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DGVHangHoa)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.CheckBox chkHienNgung;
        private System.Windows.Forms.TextBox txtTimKiem;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.Button btnMoi;
        private System.Windows.Forms.ComboBox cbbTrangThai;
        private System.Windows.Forms.ComboBox CbbDanhMuc;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtSoLuong;
        private System.Windows.Forms.TextBox txtDonVi;
        private System.Windows.Forms.TextBox txtDonGia;
        private System.Windows.Forms.TextBox txtTenHang;
        private System.Windows.Forms.TextBox txtMaCode;
        private System.Windows.Forms.Panel panelMain;
        private System.Windows.Forms.DataGridView DGVHangHoa;
        private System.Windows.Forms.DataGridViewButtonColumn btnSua;
        private System.Windows.Forms.DataGridViewButtonColumn btnXoa;
        private System.Windows.Forms.DataGridViewButtonColumn btnKhoiPhuc;
    }
}