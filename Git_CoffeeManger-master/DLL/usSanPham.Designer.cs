namespace DLL
{
    partial class usSanPham
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.pic = new System.Windows.Forms.PictureBox();
            this.guna2Panel5 = new Guna.UI2.WinForms.Guna2Panel();
            this.lbGia = new System.Windows.Forms.Label();
            this.lbTenSanPham = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pic)).BeginInit();
            this.guna2Panel5.SuspendLayout();
            this.SuspendLayout();
            // 
            // pic
            // 
            this.pic.Location = new System.Drawing.Point(10, 3);
            this.pic.Name = "pic";
            this.pic.Size = new System.Drawing.Size(190, 183);
            this.pic.TabIndex = 15;
            this.pic.TabStop = false;
            // 
            // guna2Panel5
            // 
            this.guna2Panel5.Controls.Add(this.lbGia);
            this.guna2Panel5.Controls.Add(this.lbTenSanPham);
            this.guna2Panel5.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.guna2Panel5.Location = new System.Drawing.Point(10, 186);
            this.guna2Panel5.Margin = new System.Windows.Forms.Padding(0);
            this.guna2Panel5.Name = "guna2Panel5";
            this.guna2Panel5.ShadowDecoration.Parent = this.guna2Panel5;
            this.guna2Panel5.Size = new System.Drawing.Size(190, 45);
            this.guna2Panel5.TabIndex = 16;
            // 
            // lbGia
            // 
            this.lbGia.AutoSize = true;
            this.lbGia.BackColor = System.Drawing.Color.Transparent;
            this.lbGia.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbGia.ForeColor = System.Drawing.Color.White;
            this.lbGia.Location = new System.Drawing.Point(120, 13);
            this.lbGia.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbGia.Name = "lbGia";
            this.lbGia.Size = new System.Drawing.Size(58, 18);
            this.lbGia.TabIndex = 5;
            this.lbGia.Text = "25.000";
            // 
            // lbTenSanPham
            // 
            this.lbTenSanPham.AutoSize = true;
            this.lbTenSanPham.BackColor = System.Drawing.Color.Transparent;
            this.lbTenSanPham.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTenSanPham.ForeColor = System.Drawing.Color.White;
            this.lbTenSanPham.Location = new System.Drawing.Point(2, 13);
            this.lbTenSanPham.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbTenSanPham.Name = "lbTenSanPham";
            this.lbTenSanPham.Size = new System.Drawing.Size(87, 15);
            this.lbTenSanPham.TabIndex = 4;
            this.lbTenSanPham.Text = "Cà phê đen đá";
            // 
            // usSanPham
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(53)))), ((int)(((byte)(57)))), ((int)(((byte)(82)))));
            this.Controls.Add(this.guna2Panel5);
            this.Controls.Add(this.pic);
            this.Margin = new System.Windows.Forms.Padding(15, 10, 10, 10);
            this.Name = "usSanPham";
            this.Size = new System.Drawing.Size(214, 246);
            this.Load += new System.EventHandler(this.usSanPham_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pic)).EndInit();
            this.guna2Panel5.ResumeLayout(false);
            this.guna2Panel5.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.PictureBox pic;
        public Guna.UI2.WinForms.Guna2Panel guna2Panel5;
        public System.Windows.Forms.Label lbGia;
        public System.Windows.Forms.Label lbTenSanPham;
    }
}
