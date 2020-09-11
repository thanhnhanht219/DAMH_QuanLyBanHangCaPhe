using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BLL;
using BLL.BLL_Class;

namespace GUI
{
    public partial class frmLogin : Form
    {
        NhanVien_BLL nv = new NhanVien_BLL();
        public frmLogin()
        {
            InitializeComponent();
            CenterToScreen();
        }

        #region validation
        public bool checInputkUser()
        {
            if (string.IsNullOrEmpty(txtUser.Text))
            {
                MessageBox.Show("Tên đăng nhập không được bỏ trống");
                txtUser.Focus();
                return false;
            }
            else
            {
                return true;
            }

        }

        public bool checkInputPassword()
        {
            if (string.IsNullOrEmpty(txtPassword.Text))
            {
                MessageBox.Show("Mật khẩu không được bỏ trống");
                txtPassword.Focus();
                return false;
            }
            else
            {
                return true;
            }

        }

        public bool checkExist()
        {
            if(nv.check_NhanVienTonTai(txtUser.Text,txtPassword.Text) == 0)
            {
                MessageBox.Show("Tên đăng nhập hoặc mật khẩu không chính xác");
                txtUser.Focus();
                return false;
            }
            else
            {
                return true;
            }    
        }
        #endregion

        #region method
        public void phanQuyen()
        {
            NhanVien nhanVien = nv.setTenNhanVienTheoMa(txtUser.Text);
            string hoten = nhanVien.TenNhanVien;
            string ma = nhanVien.MaNhanVien;
            string loaiNV = nhanVien.LoaiNhanVien;
            

            if (nhanVien.LoaiNhanVien.Equals("0"))
            {
                return;
            }
            else if(nhanVien.LoaiNhanVien.Equals("1"))
            {
               
                frmMain frm = new frmMain(nhanVien);
                frm.WindowState = FormWindowState.Maximized;
                frm.Show();
                this.Visible = false;
            }
            else
            {
                frmPOS frm = new frmPOS(nhanVien);
                frm.WindowState = FormWindowState.Maximized;
                frm.Show();
                this.Visible = false;
            }    
        }
        #endregion

        private void Login_Load(object sender, EventArgs e)
        {
            guna2ShadowForm1.SetShadowForm(this);
            txtPassword.PasswordChar = '\u2022';
        }


        private void btnThoat_Click(object sender, EventArgs e)
        {
              this.Close();
        }

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            if(!checInputkUser() || !checkInputPassword())
            {
                return;
            }
            else if(!checkExist())
            {
                return;
            }
            else
            {
                phanQuyen();
            }

                
            
        }

        private void frmLogin_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.ExitThread();
            Application.Exit();
        }
    }
}
