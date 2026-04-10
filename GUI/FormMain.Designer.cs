namespace GUI
{
    partial class FormMain
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
            this.panelMenu = new System.Windows.Forms.Panel();
            this.btnNCC = new System.Windows.Forms.Button();
            this.lblHome = new System.Windows.Forms.Label();
            this.picHome = new System.Windows.Forms.PictureBox();
            this.btnDanhMuc = new System.Windows.Forms.Button();
            this.btnHangHoa = new System.Windows.Forms.Button();
            this.panelNoiDung = new System.Windows.Forms.Panel();
            this.picBia = new System.Windows.Forms.PictureBox();
            this.btnBaocao = new System.Windows.Forms.Button();
            this.panelMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picHome)).BeginInit();
            this.panelNoiDung.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picBia)).BeginInit();
            this.SuspendLayout();
            // 
            // panelMenu
            // 
            this.panelMenu.Controls.Add(this.btnBaocao);
            this.panelMenu.Controls.Add(this.btnNCC);
            this.panelMenu.Controls.Add(this.lblHome);
            this.panelMenu.Controls.Add(this.picHome);
            this.panelMenu.Controls.Add(this.btnDanhMuc);
            this.panelMenu.Controls.Add(this.btnHangHoa);
            this.panelMenu.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelMenu.Location = new System.Drawing.Point(0, 0);
            this.panelMenu.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panelMenu.Name = "panelMenu";
            this.panelMenu.Size = new System.Drawing.Size(242, 654);
            this.panelMenu.TabIndex = 0;
            // 
            // btnNCC
            // 
            this.btnNCC.Location = new System.Drawing.Point(0, 241);
            this.btnNCC.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnNCC.Name = "btnNCC";
            this.btnNCC.Size = new System.Drawing.Size(244, 64);
            this.btnNCC.TabIndex = 4;
            this.btnNCC.Text = "Nhà cung cấp";
            this.btnNCC.UseVisualStyleBackColor = true;
            this.btnNCC.Click += new System.EventHandler(this.btnNCC_Click);
            // 
            // lblHome
            // 
            this.lblHome.AutoSize = true;
            this.lblHome.Font = new System.Drawing.Font("Segoe Script", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHome.Location = new System.Drawing.Point(57, 30);
            this.lblHome.Name = "lblHome";
            this.lblHome.Size = new System.Drawing.Size(182, 34);
            this.lblHome.TabIndex = 3;
            this.lblHome.Text = " Kho Hàng Hóa";
            this.lblHome.Click += new System.EventHandler(this.lblHome_Click);
            // 
            // picHome
            // 
            this.picHome.Image = global::GUI.Properties.Resources.icon_Home;
            this.picHome.Location = new System.Drawing.Point(3, 15);
            this.picHome.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.picHome.Name = "picHome";
            this.picHome.Size = new System.Drawing.Size(56, 62);
            this.picHome.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picHome.TabIndex = 2;
            this.picHome.TabStop = false;
            this.picHome.Click += new System.EventHandler(this.picHome_Click);
            // 
            // btnDanhMuc
            // 
            this.btnDanhMuc.Location = new System.Drawing.Point(-2, 170);
            this.btnDanhMuc.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnDanhMuc.Name = "btnDanhMuc";
            this.btnDanhMuc.Size = new System.Drawing.Size(244, 64);
            this.btnDanhMuc.TabIndex = 1;
            this.btnDanhMuc.Text = "Quản lý danh mục ";
            this.btnDanhMuc.UseVisualStyleBackColor = true;
            this.btnDanhMuc.Click += new System.EventHandler(this.btnDanhMuc_Click);
            // 
            // btnHangHoa
            // 
            this.btnHangHoa.Location = new System.Drawing.Point(-2, 99);
            this.btnHangHoa.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnHangHoa.Name = "btnHangHoa";
            this.btnHangHoa.Size = new System.Drawing.Size(244, 64);
            this.btnHangHoa.TabIndex = 0;
            this.btnHangHoa.Text = "Quản lý hàng hóa";
            this.btnHangHoa.UseVisualStyleBackColor = true;
            this.btnHangHoa.Click += new System.EventHandler(this.btnHangHoa_Click);
            // 
            // panelNoiDung
            // 
            this.panelNoiDung.Controls.Add(this.picBia);
            this.panelNoiDung.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelNoiDung.Location = new System.Drawing.Point(242, 0);
            this.panelNoiDung.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panelNoiDung.Name = "panelNoiDung";
            this.panelNoiDung.Size = new System.Drawing.Size(854, 654);
            this.panelNoiDung.TabIndex = 1;
            // 
            // picBia
            // 
            this.picBia.Dock = System.Windows.Forms.DockStyle.Fill;
            this.picBia.Image = global::GUI.Properties.Resources.Ảnh_bìa;
            this.picBia.Location = new System.Drawing.Point(0, 0);
            this.picBia.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.picBia.Name = "picBia";
            this.picBia.Size = new System.Drawing.Size(854, 654);
            this.picBia.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picBia.TabIndex = 0;
            this.picBia.TabStop = false;
            // 
            // btnBaocao
            // 
            this.btnBaocao.Location = new System.Drawing.Point(0, 313);
            this.btnBaocao.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnBaocao.Name = "btnBaocao";
            this.btnBaocao.Size = new System.Drawing.Size(244, 64);
            this.btnBaocao.TabIndex = 5;
            this.btnBaocao.Text = "Báo cáo";
            this.btnBaocao.UseVisualStyleBackColor = true;
            this.btnBaocao.Click += new System.EventHandler(this.btnBaocao_Click);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1096, 654);
            this.Controls.Add(this.panelNoiDung);
            this.Controls.Add(this.panelMenu);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "FormMain";
            this.Text = "FormMain";
            this.Load += new System.EventHandler(this.FormMain_Load);
            this.panelMenu.ResumeLayout(false);
            this.panelMenu.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picHome)).EndInit();
            this.panelNoiDung.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picBia)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelMenu;
        private System.Windows.Forms.Panel panelNoiDung;
        private System.Windows.Forms.PictureBox picBia;
        private System.Windows.Forms.Button btnDanhMuc;
        private System.Windows.Forms.Button btnHangHoa;
        private System.Windows.Forms.Label lblHome;
        private System.Windows.Forms.PictureBox picHome;
        private System.Windows.Forms.Button btnNCC;
        private System.Windows.Forms.Button btnBaocao;
    }
}