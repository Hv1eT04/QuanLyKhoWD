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
            this.DGVHangHoa = new System.Windows.Forms.DataGridView();
            this.btnSua = new System.Windows.Forms.DataGridViewButtonColumn();
            this.btnXoa = new System.Windows.Forms.DataGridViewButtonColumn();
            this.btnKhoiPhuc = new System.Windows.Forms.DataGridViewButtonColumn();
            this.txtMaCode = new System.Windows.Forms.TextBox();
            this.txtTenHang = new System.Windows.Forms.TextBox();
            this.txtDonGia = new System.Windows.Forms.TextBox();
            this.txtDonVi = new System.Windows.Forms.TextBox();
            this.txtSoLuong = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.CbbDanhMuc = new System.Windows.Forms.ComboBox();
            this.cbbTrangThai = new System.Windows.Forms.ComboBox();
            this.btnMoi = new System.Windows.Forms.Button();
            this.btnThem = new System.Windows.Forms.Button();
            this.chkHienNgung = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.DGVHangHoa)).BeginInit();
            this.SuspendLayout();
            // 
            // DGVHangHoa
            // 
            this.DGVHangHoa.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGVHangHoa.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.btnSua,
            this.btnXoa,
            this.btnKhoiPhuc});
            this.DGVHangHoa.Location = new System.Drawing.Point(12, 260);
            this.DGVHangHoa.Name = "DGVHangHoa";
            this.DGVHangHoa.ReadOnly = true;
            this.DGVHangHoa.RowHeadersWidth = 51;
            this.DGVHangHoa.RowTemplate.Height = 24;
            this.DGVHangHoa.Size = new System.Drawing.Size(1179, 342);
            this.DGVHangHoa.TabIndex = 0;
            this.DGVHangHoa.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DGVHangHoa_CellContentClick);
            // 
            // btnSua
            // 
            this.btnSua.HeaderText = "Sửa";
            this.btnSua.MinimumWidth = 6;
            this.btnSua.Name = "btnSua";
            this.btnSua.ReadOnly = true;
            this.btnSua.Text = "✏️";
            this.btnSua.UseColumnTextForButtonValue = true;
            this.btnSua.Width = 125;
            // 
            // btnXoa
            // 
            this.btnXoa.HeaderText = "Xóa";
            this.btnXoa.MinimumWidth = 6;
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.ReadOnly = true;
            this.btnXoa.Text = "❌";
            this.btnXoa.UseColumnTextForButtonValue = true;
            this.btnXoa.Width = 125;
            // 
            // btnKhoiPhuc
            // 
            this.btnKhoiPhuc.HeaderText = "Khôi phục";
            this.btnKhoiPhuc.MinimumWidth = 6;
            this.btnKhoiPhuc.Name = "btnKhoiPhuc";
            this.btnKhoiPhuc.ReadOnly = true;
            this.btnKhoiPhuc.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.btnKhoiPhuc.Text = "Khôi phục";
            this.btnKhoiPhuc.UseColumnTextForButtonValue = true;
            this.btnKhoiPhuc.Width = 125;
            // 
            // txtMaCode
            // 
            this.txtMaCode.Location = new System.Drawing.Point(113, 31);
            this.txtMaCode.Name = "txtMaCode";
            this.txtMaCode.ReadOnly = true;
            this.txtMaCode.Size = new System.Drawing.Size(235, 22);
            this.txtMaCode.TabIndex = 1;
            // 
            // txtTenHang
            // 
            this.txtTenHang.Location = new System.Drawing.Point(113, 75);
            this.txtTenHang.Name = "txtTenHang";
            this.txtTenHang.Size = new System.Drawing.Size(235, 22);
            this.txtTenHang.TabIndex = 2;
            // 
            // txtDonGia
            // 
            this.txtDonGia.Location = new System.Drawing.Point(485, 46);
            this.txtDonGia.Name = "txtDonGia";
            this.txtDonGia.Size = new System.Drawing.Size(250, 22);
            this.txtDonGia.TabIndex = 4;
            // 
            // txtDonVi
            // 
            this.txtDonVi.Location = new System.Drawing.Point(485, 101);
            this.txtDonVi.Name = "txtDonVi";
            this.txtDonVi.Size = new System.Drawing.Size(250, 22);
            this.txtDonVi.TabIndex = 5;
            // 
            // txtSoLuong
            // 
            this.txtSoLuong.Location = new System.Drawing.Point(113, 177);
            this.txtSoLuong.Name = "txtSoLuong";
            this.txtSoLuong.Size = new System.Drawing.Size(235, 22);
            this.txtSoLuong.TabIndex = 7;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(34, 37);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 16);
            this.label1.TabIndex = 8;
            this.label1.Text = "Mã Code";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(37, 80);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 16);
            this.label2.TabIndex = 9;
            this.label2.Text = "Tên Hàng";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(37, 122);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(67, 16);
            this.label3.TabIndex = 10;
            this.label3.Text = "Danh mục";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(40, 177);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(60, 16);
            this.label4.TabIndex = 11;
            this.label4.Text = "Số lượng";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(404, 46);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 16);
            this.label5.TabIndex = 12;
            this.label5.Text = "Đơn giá";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(404, 107);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(44, 16);
            this.label6.TabIndex = 13;
            this.label6.Text = "Đơn vị";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(390, 151);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(67, 16);
            this.label7.TabIndex = 14;
            this.label7.Text = "Trạng thái";
            // 
            // CbbDanhMuc
            // 
            this.CbbDanhMuc.FormattingEnabled = true;
            this.CbbDanhMuc.Location = new System.Drawing.Point(111, 123);
            this.CbbDanhMuc.Name = "CbbDanhMuc";
            this.CbbDanhMuc.Size = new System.Drawing.Size(237, 24);
            this.CbbDanhMuc.TabIndex = 15;
            // 
            // cbbTrangThai
            // 
            this.cbbTrangThai.FormattingEnabled = true;
            this.cbbTrangThai.Location = new System.Drawing.Point(485, 151);
            this.cbbTrangThai.Name = "cbbTrangThai";
            this.cbbTrangThai.Size = new System.Drawing.Size(250, 24);
            this.cbbTrangThai.TabIndex = 16;
            // 
            // btnMoi
            // 
            this.btnMoi.Location = new System.Drawing.Point(806, 127);
            this.btnMoi.Name = "btnMoi";
            this.btnMoi.Size = new System.Drawing.Size(80, 40);
            this.btnMoi.TabIndex = 17;
            this.btnMoi.Text = "Làm mới";
            this.btnMoi.UseVisualStyleBackColor = true;
            this.btnMoi.Click += new System.EventHandler(this.btnMoi_Click);
            // 
            // btnThem
            // 
            this.btnThem.BackColor = System.Drawing.Color.SteelBlue;
            this.btnThem.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThem.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnThem.Location = new System.Drawing.Point(796, 52);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(90, 45);
            this.btnThem.TabIndex = 18;
            this.btnThem.Text = "+ Thêm";
            this.btnThem.UseVisualStyleBackColor = false;
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            // 
            // chkHienNgung
            // 
            this.chkHienNgung.AutoSize = true;
            this.chkHienNgung.Location = new System.Drawing.Point(94, 219);
            this.chkHienNgung.Name = "chkHienNgung";
            this.chkHienNgung.Size = new System.Drawing.Size(130, 20);
            this.chkHienNgung.TabIndex = 19;
            this.chkHienNgung.Text = "Hàng hiện ngưng";
            this.chkHienNgung.UseVisualStyleBackColor = true;
            this.chkHienNgung.CheckedChanged += new System.EventHandler(this.chkHienNgung_CheckedChanged);
            // 
            // FormHangHoa
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1203, 614);
            this.Controls.Add(this.chkHienNgung);
            this.Controls.Add(this.btnThem);
            this.Controls.Add(this.btnMoi);
            this.Controls.Add(this.cbbTrangThai);
            this.Controls.Add(this.CbbDanhMuc);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtSoLuong);
            this.Controls.Add(this.txtDonVi);
            this.Controls.Add(this.txtDonGia);
            this.Controls.Add(this.txtTenHang);
            this.Controls.Add(this.txtMaCode);
            this.Controls.Add(this.DGVHangHoa);
            this.Name = "FormHangHoa";
            this.Text = "FormHangHoa";
            this.Load += new System.EventHandler(this.FormHangHoa_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DGVHangHoa)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView DGVHangHoa;
        private System.Windows.Forms.TextBox txtMaCode;
        private System.Windows.Forms.TextBox txtTenHang;
        private System.Windows.Forms.TextBox txtDonGia;
        private System.Windows.Forms.TextBox txtDonVi;
        private System.Windows.Forms.TextBox txtSoLuong;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox CbbDanhMuc;
        private System.Windows.Forms.ComboBox cbbTrangThai;
        private System.Windows.Forms.Button btnMoi;
        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.CheckBox chkHienNgung;
        private System.Windows.Forms.DataGridViewButtonColumn btnSua;
        private System.Windows.Forms.DataGridViewButtonColumn btnXoa;
        private System.Windows.Forms.DataGridViewButtonColumn btnKhoiPhuc;
    }
}