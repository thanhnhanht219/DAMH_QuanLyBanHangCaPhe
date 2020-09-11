using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Tracing;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Runtime.CompilerServices;
using BLL;
using BLL.BLL_Class;

namespace GUI
{
    public partial class frmMain : Form
    {
        NhanVien nv_hientai;
        public frmMain()
        {
            InitializeComponent();
            customizeSubMenu();
            this.FormBorderStyle = FormBorderStyle.None;
            DoubleBuffered = true;
            this.SetStyle(ControlStyles.ResizeRedraw, true);
        }


        public frmMain(NhanVien nv)
        {
            InitializeComponent();
            customizeSubMenu();
            this.FormBorderStyle = FormBorderStyle.None;
            DoubleBuffered = true;
            this.SetStyle(ControlStyles.ResizeRedraw, true);
            lbTenNhanVien.Text = nv.TenNhanVien;
            nv_hientai = nv;
        }


        private void btnClose_Click(object sender, EventArgs e)
        {
            DialogResult result;
            result = MessageBox.Show("Bạn có muốn thoát?", "Thông báo", 
                MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
            if (result == DialogResult.Yes)
            {
                this.Close();
            }
            else
                return;
        }

        /*---Hiển thị sub menu---*/
        public void customizeSubMenu()
        {
            pnSubmenuQuanLy.Visible = false;
            pnSubmenuQuy.Visible = false;
            pnSubMenuBaoCao.Visible = false;
        }

        public void hideSubMenu()
        {
            pnSubmenuQuanLy.Visible = false;
            pnSubmenuQuy.Visible = false;
            pnSubMenuBaoCao.Visible = false;
        }

        public void showSubMenu(Panel submenu)
        {
            if (submenu.Visible == false)
            {
                hideSubMenu();
                submenu.Visible = true;
            }
            else
                submenu.Visible = false;


        }
        private void btnQuanLy_Click(object sender, EventArgs e)
        {
            showSubMenu(pnSubmenuQuanLy);
        }

        private void btnQuy_Click(object sender, EventArgs e)
        {
            showSubMenu(pnSubmenuQuy);
        }

        private void btnBaoCao_Click(object sender, EventArgs e)
        {
            showSubMenu(pnSubMenuBaoCao);
        }
        /*---End hiển thị sub menu---*/
        //Di chuyển form
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);
        private void pnTop_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);

        }
        //Chỉnh size form
        private const int cGrip = 16;
        private const int cCaption = 32;

        protected override void OnPaint(PaintEventArgs e)
        {
            Rectangle rc = new Rectangle(ClientSize.Width - cGrip, ClientSize.Height - cGrip, cGrip, cGrip);
            ControlPaint.DrawSizeGrip(e.Graphics, BackColor, rc);
        }
        protected override void WndProc(ref Message m)
        {
            if (m.Msg == 0x84)
            {
                Point pos = new Point(m.LParam.ToInt32());
                pos = this.PointToScreen(pos);
                if (pos.Y < cCaption)
                {
                    m.Result = (IntPtr)2;
                    return;
                }
                if (pos.X >= this.ClientSize.Width - cGrip &&
                    pos.Y >= this.ClientSize.Height - cGrip)
                {
                    m.Result = (IntPtr)17;
                    return;
                }
            }
            base.WndProc(ref m);
        }


        //Hiển thị form con
        private Form activieForm = null;
        private void addFormInPanel(Form form)
        {
            if(activieForm != null)
            {
                activieForm.Close();
            }
            activieForm = form;
            form.TopLevel = false;
            form.Dock = DockStyle.Fill;
            this.pnContainer.Controls.Add(form);
            this.pnContainer.Tag = form;
            form.BringToFront();
            form.Show();
        }

        private void btnLogo_Click(object sender, EventArgs e)
        {
            Intro frm = new Intro();
          
            addFormInPanel(frm);
        }

        private void btnSanPham_Click(object sender, EventArgs e)
        {
            addFormInPanel(new frmSanPham());
        }

        private void btnKhachHang_Click(object sender, EventArgs e)
        {
            addFormInPanel(new frmKhachHang());
        }
        private void btnNhaCungCap_Click(object sender, EventArgs e)
        {
            addFormInPanel(new frmNhaCungCap());
        }

        private void btnNhanVien_Click(object sender, EventArgs e)
        {
            addFormInPanel(new frmNhanVien());
        }

        private void btnPOS_Click(object sender, EventArgs e)
        {

            frmPOS frm = new frmPOS(nv_hientai,true);
            frm.Show();
            this.Visible = false;
        }

        private void Main_Load(object sender, EventArgs e)
        {
            btnLogo_Click(null, e);
            addFormInPanel(new frmDashboard());
        }

        private void btnKho_Click(object sender, EventArgs e)
        {
            addFormInPanel(new frmKho());
        }

        private void frmMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.ExitThread();
            Application.Exit();
        }

        private void btnLogOut_Click(object sender, EventArgs e)
        {
            frmLogin frm = new frmLogin();
            frm.Show();
            this.Visible = false;
        }

        private void btnBanHang_Click(object sender, EventArgs e)
        {
            addFormInPanel(new frmHoaDonBanHang());
        }
    }
}
