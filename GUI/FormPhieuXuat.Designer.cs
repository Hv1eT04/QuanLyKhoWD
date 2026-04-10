namespace GUI
{
    partial class FormPhieuXuat
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dgvPhieuXuat = new System.Windows.Forms.DataGridView();
            this.btnxem = new System.Windows.Forms.DataGridViewButtonColumn();
            this.btnreload = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.btnxoa = new System.Windows.Forms.Button();
            this.btntaophieu = new System.Windows.Forms.Button();
            this.txtnote = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.lbuser = new System.Windows.Forms.Label();
            this.txtuser = new System.Windows.Forms.TextBox();
            this.txtsophieu = new System.Windows.Forms.TextBox();
            this.lbSoPhieu = new System.Windows.Forms.Label();
            this.txtmaPX = new System.Windows.Forms.TextBox();
            this.lbPX = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtTongTien = new System.Windows.Forms.TextBox();
            this.txttt = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPhieuXuat)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvPhieuXuat
            // 
            this.dgvPhieuXuat.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPhieuXuat.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.btnxem});
            this.dgvPhieuXuat.Location = new System.Drawing.Point(0, 201);
            this.dgvPhieuXuat.Name = "dgvPhieuXuat";
            this.dgvPhieuXuat.RowHeadersWidth = 51;
            this.dgvPhieuXuat.RowTemplate.Height = 24;
            this.dgvPhieuXuat.Size = new System.Drawing.Size(1176, 333);
            this.dgvPhieuXuat.TabIndex = 0;
            this.dgvPhieuXuat.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvPhieuXuat_CellClick);
            this.dgvPhieuXuat.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvPhieuXuat_CellContentClick);
            // 
            // btnxem
            // 
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopCenter;
            this.btnxem.DefaultCellStyle = dataGridViewCellStyle1;
            this.btnxem.HeaderText = "Chi tiết";
            this.btnxem.MinimumWidth = 6;
            this.btnxem.Name = "btnxem";
            this.btnxem.Text = "Xem";
            this.btnxem.UseColumnTextForButtonValue = true;
            this.btnxem.Width = 125;
            // 
            // btnreload
            // 
            this.btnreload.Location = new System.Drawing.Point(959, 142);
            this.btnreload.Name = "btnreload";
            this.btnreload.Size = new System.Drawing.Size(108, 40);
            this.btnreload.TabIndex = 27;
            this.btnreload.Text = "Làm mới";
            this.btnreload.UseVisualStyleBackColor = true;
            this.btnreload.Click += new System.EventHandler(this.btnreload_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(73, 154);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 16);
            this.label1.TabIndex = 25;
            this.label1.Text = "Trạng thái:";
            // 
            // btnxoa
            // 
            this.btnxoa.Location = new System.Drawing.Point(959, 91);
            this.btnxoa.Name = "btnxoa";
            this.btnxoa.Size = new System.Drawing.Size(108, 40);
            this.btnxoa.TabIndex = 24;
            this.btnxoa.Text = "Xóa";
            this.btnxoa.UseVisualStyleBackColor = true;
            this.btnxoa.Click += new System.EventHandler(this.btnxoa_Click);
            // 
            // btntaophieu
            // 
            this.btntaophieu.Location = new System.Drawing.Point(959, 28);
            this.btntaophieu.Name = "btntaophieu";
            this.btntaophieu.Size = new System.Drawing.Size(108, 40);
            this.btntaophieu.TabIndex = 23;
            this.btntaophieu.Text = "Tạo phiếu";
            this.btntaophieu.UseVisualStyleBackColor = true;
            this.btntaophieu.Click += new System.EventHandler(this.btntaophieu_Click);
            // 
            // txtnote
            // 
            this.txtnote.Location = new System.Drawing.Point(569, 28);
            this.txtnote.Multiline = true;
            this.txtnote.Name = "txtnote";
            this.txtnote.Size = new System.Drawing.Size(270, 151);
            this.txtnote.TabIndex = 22;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(476, 28);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 16);
            this.label2.TabIndex = 21;
            this.label2.Text = "ghi chú:";
            // 
            // lbuser
            // 
            this.lbuser.AutoSize = true;
            this.lbuser.Location = new System.Drawing.Point(73, 115);
            this.lbuser.Name = "lbuser";
            this.lbuser.Size = new System.Drawing.Size(68, 16);
            this.lbuser.TabIndex = 20;
            this.lbuser.Text = "Người lập:";
            // 
            // txtuser
            // 
            this.txtuser.Location = new System.Drawing.Point(196, 112);
            this.txtuser.Name = "txtuser";
            this.txtuser.Size = new System.Drawing.Size(121, 22);
            this.txtuser.TabIndex = 19;
            // 
            // txtsophieu
            // 
            this.txtsophieu.Location = new System.Drawing.Point(196, 64);
            this.txtsophieu.Name = "txtsophieu";
            this.txtsophieu.ReadOnly = true;
            this.txtsophieu.Size = new System.Drawing.Size(121, 22);
            this.txtsophieu.TabIndex = 18;
            // 
            // lbSoPhieu
            // 
            this.lbSoPhieu.AutoSize = true;
            this.lbSoPhieu.Location = new System.Drawing.Point(73, 64);
            this.lbSoPhieu.Name = "lbSoPhieu";
            this.lbSoPhieu.Size = new System.Drawing.Size(63, 16);
            this.lbSoPhieu.TabIndex = 17;
            this.lbSoPhieu.Text = "Số phiếu:";
            // 
            // txtmaPX
            // 
            this.txtmaPX.Location = new System.Drawing.Point(196, 22);
            this.txtmaPX.Name = "txtmaPX";
            this.txtmaPX.ReadOnly = true;
            this.txtmaPX.Size = new System.Drawing.Size(121, 22);
            this.txtmaPX.TabIndex = 16;
            // 
            // lbPX
            // 
            this.lbPX.AutoSize = true;
            this.lbPX.Location = new System.Drawing.Point(73, 22);
            this.lbPX.Name = "lbPX";
            this.lbPX.Size = new System.Drawing.Size(92, 16);
            this.lbPX.TabIndex = 15;
            this.lbPX.Text = "Mã phiếu xuất:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(741, 596);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(66, 16);
            this.label3.TabIndex = 28;
            this.label3.Text = "Tổng tiền:";
            // 
            // txtTongTien
            // 
            this.txtTongTien.Location = new System.Drawing.Point(837, 579);
            this.txtTongTien.Multiline = true;
            this.txtTongTien.Name = "txtTongTien";
            this.txtTongTien.ReadOnly = true;
            this.txtTongTien.Size = new System.Drawing.Size(162, 43);
            this.txtTongTien.TabIndex = 29;
            // 
            // txttt
            // 
            this.txttt.Location = new System.Drawing.Point(196, 151);
            this.txttt.Name = "txttt";
            this.txttt.Size = new System.Drawing.Size(121, 22);
            this.txttt.TabIndex = 30;
            // 
            // FormPhieuXuat
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1189, 669);
            this.Controls.Add(this.txttt);
            this.Controls.Add(this.txtTongTien);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnreload);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnxoa);
            this.Controls.Add(this.btntaophieu);
            this.Controls.Add(this.txtnote);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lbuser);
            this.Controls.Add(this.txtuser);
            this.Controls.Add(this.txtsophieu);
            this.Controls.Add(this.lbSoPhieu);
            this.Controls.Add(this.txtmaPX);
            this.Controls.Add(this.lbPX);
            this.Controls.Add(this.dgvPhieuXuat);
            this.Name = "FormPhieuXuat";
            this.Text = "FormPhieuXuat";
            this.Load += new System.EventHandler(this.FormPhieuXuat_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPhieuXuat)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvPhieuXuat;
        private System.Windows.Forms.Button btnreload;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnxoa;
        private System.Windows.Forms.Button btntaophieu;
        private System.Windows.Forms.TextBox txtnote;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lbuser;
        private System.Windows.Forms.TextBox txtuser;
        private System.Windows.Forms.TextBox txtsophieu;
        private System.Windows.Forms.Label lbSoPhieu;
        private System.Windows.Forms.TextBox txtmaPX;
        private System.Windows.Forms.Label lbPX;
        private System.Windows.Forms.DataGridViewButtonColumn btnxem;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtTongTien;
        private System.Windows.Forms.TextBox txttt;
    }
}