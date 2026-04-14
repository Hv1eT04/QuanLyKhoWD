namespace GUI
{
    partial class FormPhieuNhap
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.dgvPhieuNhap = new System.Windows.Forms.DataGridView();
            this.btnxem = new System.Windows.Forms.DataGridViewButtonColumn();
            this.btnsua = new System.Windows.Forms.DataGridViewButtonColumn();
            this.btntaophieu = new System.Windows.Forms.Button();
            this.btnxoa = new System.Windows.Forms.Button();
            this.lbPN = new System.Windows.Forms.Label();
            this.txtmaPN = new System.Windows.Forms.TextBox();
            this.lbSoPhieu = new System.Windows.Forms.Label();
            this.txtsophieu = new System.Windows.Forms.TextBox();
            this.lbuser = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtnote = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.boxtt = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cbbncc = new System.Windows.Forms.ComboBox();
            this.txtuser = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPhieuNhap)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvPhieuNhap
            // 
            this.dgvPhieuNhap.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPhieuNhap.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.btnxem,
            this.btnsua});
            this.dgvPhieuNhap.Location = new System.Drawing.Point(1, 232);
            this.dgvPhieuNhap.Name = "dgvPhieuNhap";
            this.dgvPhieuNhap.RowHeadersWidth = 51;
            this.dgvPhieuNhap.RowTemplate.Height = 24;
            this.dgvPhieuNhap.Size = new System.Drawing.Size(1175, 279);
            this.dgvPhieuNhap.TabIndex = 0;
            this.dgvPhieuNhap.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvPhieuNhap_CellClick);
            // 
            // btnxem
            // 
            this.btnxem.HeaderText = "Chi tiết";
            this.btnxem.MinimumWidth = 6;
            this.btnxem.Name = "btnxem";
            this.btnxem.ReadOnly = true;
            this.btnxem.Text = "Xem";
            this.btnxem.UseColumnTextForButtonValue = true;
            this.btnxem.Width = 125;
            // 
            // btnsua
            // 
            this.btnsua.HeaderText = "Sửa";
            this.btnsua.MinimumWidth = 6;
            this.btnsua.Name = "btnsua";
            this.btnsua.ReadOnly = true;
            this.btnsua.Text = "Sửa";
            this.btnsua.UseColumnTextForButtonValue = true;
            this.btnsua.Width = 125;
            // 
            // btntaophieu
            // 
            this.btntaophieu.Location = new System.Drawing.Point(936, 33);
            this.btntaophieu.Name = "btntaophieu";
            this.btntaophieu.Size = new System.Drawing.Size(108, 40);
            this.btntaophieu.TabIndex = 10;
            this.btntaophieu.Text = "Tạo Phiếu";
            this.btntaophieu.UseVisualStyleBackColor = true;
            this.btntaophieu.Click += new System.EventHandler(this.btntaophieu_Click);
            // 
            // btnxoa
            // 
            this.btnxoa.Location = new System.Drawing.Point(936, 96);
            this.btnxoa.Name = "btnxoa";
            this.btnxoa.Size = new System.Drawing.Size(108, 40);
            this.btnxoa.TabIndex = 11;
            this.btnxoa.Text = "Xóa";
            this.btnxoa.UseVisualStyleBackColor = true;
            this.btnxoa.Click += new System.EventHandler(this.btnxoa_Click);
            // 
            // lbPN
            // 
            this.lbPN.AutoSize = true;
            this.lbPN.Location = new System.Drawing.Point(50, 27);
            this.lbPN.Name = "lbPN";
            this.lbPN.Size = new System.Drawing.Size(98, 16);
            this.lbPN.TabIndex = 1;
            this.lbPN.Text = "Mã phiếu nhập:";
            // 
            // txtmaPN
            // 
            this.txtmaPN.Location = new System.Drawing.Point(173, 27);
            this.txtmaPN.Name = "txtmaPN";
            this.txtmaPN.ReadOnly = true;
            this.txtmaPN.Size = new System.Drawing.Size(121, 22);
            this.txtmaPN.TabIndex = 2;
            // 
            // lbSoPhieu
            // 
            this.lbSoPhieu.AutoSize = true;
            this.lbSoPhieu.Location = new System.Drawing.Point(50, 69);
            this.lbSoPhieu.Name = "lbSoPhieu";
            this.lbSoPhieu.Size = new System.Drawing.Size(63, 16);
            this.lbSoPhieu.TabIndex = 3;
            this.lbSoPhieu.Text = "Số phiếu:";
            // 
            // txtsophieu
            // 
            this.txtsophieu.Location = new System.Drawing.Point(173, 69);
            this.txtsophieu.Name = "txtsophieu";
            this.txtsophieu.ReadOnly = true;
            this.txtsophieu.Size = new System.Drawing.Size(121, 22);
            this.txtsophieu.TabIndex = 4;
            // 
            // lbuser
            // 
            this.lbuser.AutoSize = true;
            this.lbuser.Location = new System.Drawing.Point(50, 120);
            this.lbuser.Name = "lbuser";
            this.lbuser.Size = new System.Drawing.Size(68, 16);
            this.lbuser.TabIndex = 6;
            this.lbuser.Text = "Người lập:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(453, 33);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 16);
            this.label2.TabIndex = 8;
            this.label2.Text = "ghi chú:";
            // 
            // txtnote
            // 
            this.txtnote.Location = new System.Drawing.Point(546, 33);
            this.txtnote.Multiline = true;
            this.txtnote.Name = "txtnote";
            this.txtnote.Size = new System.Drawing.Size(270, 191);
            this.txtnote.TabIndex = 9;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(50, 159);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 16);
            this.label1.TabIndex = 12;
            this.label1.Text = "Trạng thái:";
            // 
            // boxtt
            // 
            this.boxtt.FormattingEnabled = true;
            this.boxtt.Location = new System.Drawing.Point(173, 156);
            this.boxtt.Name = "boxtt";
            this.boxtt.Size = new System.Drawing.Size(121, 24);
            this.boxtt.TabIndex = 13;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(50, 203);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(93, 16);
            this.label3.TabIndex = 15;
            this.label3.Text = "Nhà cung cấp:";
            // 
            // cbbncc
            // 
            this.cbbncc.FormattingEnabled = true;
            this.cbbncc.Location = new System.Drawing.Point(173, 200);
            this.cbbncc.Name = "cbbncc";
            this.cbbncc.Size = new System.Drawing.Size(121, 24);
            this.cbbncc.TabIndex = 16;
            // 
            // txtuser
            // 
            this.txtuser.Location = new System.Drawing.Point(173, 117);
            this.txtuser.Name = "txtuser";
            this.txtuser.Size = new System.Drawing.Size(121, 22);
            this.txtuser.TabIndex = 17;
            // 
            // FormPhieuNhap
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1177, 514);
            this.Controls.Add(this.txtuser);
            this.Controls.Add(this.cbbncc);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.boxtt);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnxoa);
            this.Controls.Add(this.btntaophieu);
            this.Controls.Add(this.txtnote);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lbuser);
            this.Controls.Add(this.txtsophieu);
            this.Controls.Add(this.lbSoPhieu);
            this.Controls.Add(this.txtmaPN);
            this.Controls.Add(this.lbPN);
            this.Controls.Add(this.dgvPhieuNhap);
            this.Name = "FormPhieuNhap";
            this.Text = "Quản Lý Phiếu Nhập";
            this.Load += new System.EventHandler(this.FormPhieuNhap_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPhieuNhap)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvPhieuNhap;
        private System.Windows.Forms.Button btntaophieu;
        private System.Windows.Forms.Button btnxoa;
        private System.Windows.Forms.DataGridViewButtonColumn btnxem;
        private System.Windows.Forms.DataGridViewButtonColumn btnsua;
        private System.Windows.Forms.Label lbPN;
        private System.Windows.Forms.TextBox txtmaPN;
        private System.Windows.Forms.Label lbSoPhieu;
        private System.Windows.Forms.TextBox txtsophieu;
        private System.Windows.Forms.Label lbuser;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtnote;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox boxtt;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cbbncc;
        private System.Windows.Forms.TextBox txtuser;
    }
}