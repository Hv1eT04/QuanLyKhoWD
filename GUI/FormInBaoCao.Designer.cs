namespace GUI
{
    partial class FormInBaoCao
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
            this.crvHienThi = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.SuspendLayout();
            // 
            // crvHienThi
            // 
            this.crvHienThi.ActiveViewIndex = -1;
            this.crvHienThi.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crvHienThi.Cursor = System.Windows.Forms.Cursors.Default;
            this.crvHienThi.Dock = System.Windows.Forms.DockStyle.Fill;
            this.crvHienThi.Location = new System.Drawing.Point(0, 0);
            this.crvHienThi.Name = "crvHienThi";
            this.crvHienThi.Size = new System.Drawing.Size(800, 450);
            this.crvHienThi.TabIndex = 0;
            this.crvHienThi.Load += new System.EventHandler(this.crvHienThi_Load);
            // 
            // FormInBaoCao
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.crvHienThi);
            this.Name = "FormInBaoCao";
            this.Text = "FormInBaoCao";
            this.ResumeLayout(false);

        }

        #endregion

        private CrystalDecisions.Windows.Forms.CrystalReportViewer crvHienThi;
    }
}