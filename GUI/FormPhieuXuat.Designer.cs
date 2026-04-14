namespace GUI
{
    partial class FormPhieuXuat
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dgvPhieuXuat = new System.Windows.Forms.DataGridView();
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.btnreload = new System.Windows.Forms.Button();
            this.btntaophieu = new System.Windows.Forms.Button();
            this.btnxoa = new System.Windows.Forms.Button();
            this.pnlStatus = new System.Windows.Forms.Panel();
            this.lblSelectedInfo = new System.Windows.Forms.Label();
            this.txtsophieu = new System.Windows.Forms.TextBox();
            this.txtuser = new System.Windows.Forms.TextBox();
            this.txtmaPX = new System.Windows.Forms.TextBox();
            this.txtnote = new System.Windows.Forms.TextBox();
            this.txttt = new System.Windows.Forms.TextBox();
            this.pnlFooter = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.txtTongTien = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPhieuXuat)).BeginInit();
            this.pnlHeader.SuspendLayout();
            this.pnlStatus.SuspendLayout();
            this.pnlFooter.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvPhieuXuat
            // 
            this.dgvPhieuXuat.AllowUserToAddRows = false;
            this.dgvPhieuXuat.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvPhieuXuat.BackgroundColor = System.Drawing.Color.White;
            this.dgvPhieuXuat.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvPhieuXuat.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvPhieuXuat.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvPhieuXuat.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvPhieuXuat.ColumnHeadersHeight = 40;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(240)))), ((int)(((byte)(241)))));
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(62)))), ((int)(((byte)(80)))));
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvPhieuXuat.DefaultCellStyle = dataGridViewCellStyle4;
            this.dgvPhieuXuat.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvPhieuXuat.EnableHeadersVisualStyles = false;
            this.dgvPhieuXuat.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(240)))), ((int)(((byte)(241)))));
            this.dgvPhieuXuat.Location = new System.Drawing.Point(0, 169);
            this.dgvPhieuXuat.Name = "dgvPhieuXuat";
            this.dgvPhieuXuat.RowHeadersVisible = false;
            this.dgvPhieuXuat.RowHeadersWidth = 51;
            this.dgvPhieuXuat.RowTemplate.Height = 35;
            this.dgvPhieuXuat.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvPhieuXuat.Size = new System.Drawing.Size(1012, 431);
            this.dgvPhieuXuat.TabIndex = 0;
            this.dgvPhieuXuat.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvPhieuXuat_CellClick);
            this.dgvPhieuXuat.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvPhieuXuat_CellContentClick);
            // 
            // pnlHeader
            // 
            this.pnlHeader.BackColor = System.Drawing.Color.White;
            this.pnlHeader.Controls.Add(this.lblTitle);
            this.pnlHeader.Controls.Add(this.btnreload);
            this.pnlHeader.Controls.Add(this.btntaophieu);
            this.pnlHeader.Controls.Add(this.btnxoa);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(1012, 100);
            this.pnlHeader.TabIndex = 1;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(62)))), ((int)(((byte)(80)))));
            this.lblTitle.Location = new System.Drawing.Point(16, 25);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(311, 45);
            this.lblTitle.TabIndex = 4;
            this.lblTitle.Text = "Quản Lý Phiếu Xuất";
            // 
            // btnreload
            // 
            this.btnreload.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnreload.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(149)))), ((int)(((byte)(165)))), ((int)(((byte)(166)))));
            this.btnreload.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnreload.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnreload.ForeColor = System.Drawing.Color.White;
            this.btnreload.Location = new System.Drawing.Point(608, 28);
            this.btnreload.Name = "btnreload";
            this.btnreload.Size = new System.Drawing.Size(123, 48);
            this.btnreload.TabIndex = 2;
            this.btnreload.Text = "LÀM MỚI";
            this.btnreload.UseVisualStyleBackColor = false;
            // 
            // btntaophieu
            // 
            this.btntaophieu.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btntaophieu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(204)))), ((int)(((byte)(113)))));
            this.btntaophieu.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btntaophieu.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btntaophieu.ForeColor = System.Drawing.Color.White;
            this.btntaophieu.Location = new System.Drawing.Point(738, 28);
            this.btntaophieu.Name = "btntaophieu";
            this.btntaophieu.Size = new System.Drawing.Size(123, 48);
            this.btntaophieu.TabIndex = 3;
            this.btntaophieu.Text = "+ TẠO PHIẾU";
            this.btntaophieu.UseVisualStyleBackColor = false;
            this.btntaophieu.Click += new System.EventHandler(this.btntaophieu_Click);
            // 
            // btnxoa
            // 
            this.btnxoa.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnxoa.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(76)))), ((int)(((byte)(60)))));
            this.btnxoa.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnxoa.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnxoa.ForeColor = System.Drawing.Color.White;
            this.btnxoa.Location = new System.Drawing.Point(868, 28);
            this.btnxoa.Name = "btnxoa";
            this.btnxoa.Size = new System.Drawing.Size(123, 48);
            this.btnxoa.TabIndex = 4;
            this.btnxoa.Text = "XÓA PHIẾU";
            this.btnxoa.UseVisualStyleBackColor = false;
            this.btnxoa.Click += new System.EventHandler(this.btnxoa_Click);
            // 
            // pnlStatus
            // 
            this.pnlStatus.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(240)))), ((int)(((byte)(241)))));
            this.pnlStatus.Controls.Add(this.lblSelectedInfo);
            this.pnlStatus.Controls.Add(this.txtsophieu);
            this.pnlStatus.Controls.Add(this.txtuser);
            this.pnlStatus.Controls.Add(this.txtmaPX);
            this.pnlStatus.Controls.Add(this.txtnote);
            this.pnlStatus.Controls.Add(this.txttt);
            this.pnlStatus.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlStatus.Location = new System.Drawing.Point(0, 100);
            this.pnlStatus.Name = "pnlStatus";
            this.pnlStatus.Size = new System.Drawing.Size(1012, 69);
            this.pnlStatus.TabIndex = 5;
            // 
            // lblSelectedInfo
            // 
            this.lblSelectedInfo.AutoSize = true;
            this.lblSelectedInfo.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            this.lblSelectedInfo.Location = new System.Drawing.Point(21, 22);
            this.lblSelectedInfo.Name = "lblSelectedInfo";
            this.lblSelectedInfo.Size = new System.Drawing.Size(155, 25);
            this.lblSelectedInfo.TabIndex = 6;
            this.lblSelectedInfo.Text = "Phiếu đang chọn:";
            // 
            // txtsophieu
            // 
            this.txtsophieu.BackColor = System.Drawing.Color.White;
            this.txtsophieu.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtsophieu.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtsophieu.Location = new System.Drawing.Point(174, 17);
            this.txtsophieu.Name = "txtsophieu";
            this.txtsophieu.ReadOnly = true;
            this.txtsophieu.Size = new System.Drawing.Size(158, 31);
            this.txtsophieu.TabIndex = 7;
            this.txtsophieu.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtuser
            // 
            this.txtuser.BackColor = System.Drawing.Color.White;
            this.txtuser.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtuser.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtuser.Location = new System.Drawing.Point(344, 17);
            this.txtuser.Name = "txtuser";
            this.txtuser.ReadOnly = true;
            this.txtuser.Size = new System.Drawing.Size(203, 31);
            this.txtuser.TabIndex = 8;
            this.txtuser.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtmaPX
            // 
            this.txtmaPX.Location = new System.Drawing.Point(585, 17);
            this.txtmaPX.Name = "txtmaPX";
            this.txtmaPX.Size = new System.Drawing.Size(34, 26);
            this.txtmaPX.TabIndex = 9;
            this.txtmaPX.Visible = false;
            // 
            // txtnote
            // 
            this.txtnote.Location = new System.Drawing.Point(626, 17);
            this.txtnote.Name = "txtnote";
            this.txtnote.Size = new System.Drawing.Size(34, 26);
            this.txtnote.TabIndex = 10;
            this.txtnote.Visible = false;
            // 
            // txttt
            // 
            this.txttt.Location = new System.Drawing.Point(666, 17);
            this.txttt.Name = "txttt";
            this.txttt.Size = new System.Drawing.Size(34, 26);
            this.txttt.TabIndex = 11;
            this.txttt.Visible = false;
            // 
            // pnlFooter
            // 
            this.pnlFooter.BackColor = System.Drawing.Color.White;
            this.pnlFooter.Controls.Add(this.label3);
            this.pnlFooter.Controls.Add(this.txtTongTien);
            this.pnlFooter.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlFooter.Location = new System.Drawing.Point(0, 600);
            this.pnlFooter.Name = "pnlFooter";
            this.pnlFooter.Size = new System.Drawing.Size(1012, 88);
            this.pnlFooter.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(62)))), ((int)(((byte)(80)))));
            this.label3.Location = new System.Drawing.Point(597, 29);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(222, 30);
            this.label3.TabIndex = 12;
            this.label3.Text = "TỔNG DOANH THU:";
            // 
            // txtTongTien
            // 
            this.txtTongTien.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTongTien.BackColor = System.Drawing.Color.White;
            this.txtTongTien.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtTongTien.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.txtTongTien.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(57)))), ((int)(((byte)(43)))));
            this.txtTongTien.Location = new System.Drawing.Point(810, 23);
            this.txtTongTien.Name = "txtTongTien";
            this.txtTongTien.ReadOnly = true;
            this.txtTongTien.Size = new System.Drawing.Size(180, 38);
            this.txtTongTien.TabIndex = 13;
            this.txtTongTien.Text = "0 VND";
            this.txtTongTien.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // FormPhieuXuat
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1012, 688);
            this.Controls.Add(this.dgvPhieuXuat);
            this.Controls.Add(this.pnlStatus);
            this.Controls.Add(this.pnlHeader);
            this.Controls.Add(this.pnlFooter);
            this.Name = "FormPhieuXuat";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Hệ thống Quản lý Xuất kho";
            ((System.ComponentModel.ISupportInitialize)(this.dgvPhieuXuat)).EndInit();
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.pnlStatus.ResumeLayout(false);
            this.pnlStatus.PerformLayout();
            this.pnlFooter.ResumeLayout(false);
            this.pnlFooter.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvPhieuXuat;
        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Button btnreload;
        private System.Windows.Forms.Button btntaophieu;
        private System.Windows.Forms.Button btnxoa;
        private System.Windows.Forms.TextBox txtsophieu;
        private System.Windows.Forms.TextBox txtuser;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Panel pnlStatus;
        private System.Windows.Forms.Label lblSelectedInfo;
        private System.Windows.Forms.TextBox txtmaPX;
        private System.Windows.Forms.TextBox txtnote;
        private System.Windows.Forms.TextBox txttt;
        private System.Windows.Forms.Panel pnlFooter;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtTongTien;
    }
}