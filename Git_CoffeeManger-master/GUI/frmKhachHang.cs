using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BLL.BLL_Class;
using BLL;

namespace GUI
{
    public partial class frmKhachHang : Form
    {

        private KhachHang_BLL kh_bll;
        private LoaiKhachHang_BLL loaikh_bll;
        int chucnang = 0;

        public frmKhachHang()
        {
            InitializeComponent();

            kh_bll = new KhachHang_BLL();
            loaikh_bll = new LoaiKhachHang_BLL();

            LockAllControl();

            load_dataGridViewKhachHang();

            this.btnThem.Click += btnThem_Click;
            this.btnSua.Click += btnSua_Click;
            this.btnLuu.Click += btnLuu_Click;
            this.btnXoa.Click += btnXoa_Click;
            this.dataGridViewKhachHang.CellContentClick += dataGridViewKhachHang_CellContentClick;
        }

        //===================================================================//
        void dataGridViewKhachHang_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                DataGridViewRow i = dataGridViewKhachHang.Rows[e.RowIndex];

                txtMaKhachHang.Text = i.Cells[0].Value.ToString();
                txtHoTenKhachHang.Text = i.Cells[1].Value.ToString();
                txtSoDienThoai.Text = i.Cells[2].Value.ToString();
                if ((Boolean)i.Cells[3].Value == true)
                    rdNam.Checked = true;
                else
                    rdNữ.Checked = true;
                txtEmail.Text = i.Cells[4].Value.ToString();
                txtCMND.Text = i.Cells[5].Value.ToString();
                txtDiaChi.Text = i.Cells[6].Value.ToString();

                LoaiKhachHang loaikh = new LoaiKhachHang_BLL().layLoaiKhachHang_TheoMaLoai(i.Cells[7].Value.ToString());
                txtDiemTichLuy.Text = i.Cells["Diem"].Value.ToString();
                //txtDiemTichLuy.Text = loaikh.DiemTichLuy.Value.ToString();
                txtCapBacKH.Text = loaikh.TenLoai;
            }
            catch { }
        }

        void btnXoa_Click(object sender, EventArgs e)
        {
            if (txtMaKhachHang.Text.Trim().Length != 0)
            {
                if (MessageBox.Show("Bạn có chắc chắn muốn xóa khách hàng " + txtHoTenKhachHang.Text + " có mã " + txtMaKhachHang.Text + " ra khỏi danh sách hay không?", "Thông báo",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                    kh_bll.delete_KhachHang(txtMaKhachHang.Text);
            }
            else
            {
                if (MessageBox.Show("Bạn có chắc chắn muốn xóa khách hàng các khách hàng đang được chọn trong bảng dữ liệu này ra khỏi danh sách hay không?", "Thông báo",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                    while (dataGridViewKhachHang.SelectedRows != null)
                    {
                        string maKH = dataGridViewKhachHang.SelectedRows[0].Cells[0].Value.ToString();
                        kh_bll.delete_KhachHang(maKH);
                    }
            }
            load_dataGridViewKhachHang();
        }

        void btnLuu_Click(object sender, EventArgs e)
        {
            try
            {
                switch (chucnang)
                {
                    case 1:
                        themKhachHang();
                        chucnang = 0;
                        break;
                    case 2:
                        KhachHang kh = new KhachHang_BLL().layKhachHang_TheoMaKhachHang(txtMaKhachHang.Text);
                        if (kh != null)
                        {
                            if (MessageBox.Show("Bạn có chắc muốn thay đổi những thông tin của khách hàng có mã " + txtMaKhachHang.Text + " không?", "Thông báo",
                                MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                            {
                                capNhatKhachHang();

                                load_dataGridViewKhachHang();
                            }
                            MessageBox.Show("Đã lưu các thông tin vừa được chỉnh sửa");
                        }
                        else
                        {
                            if (MessageBox.Show("Không có khách hàng nào có mã " + txtMaKhachHang.Text +
                                "mà bạn muốn thay đổi, bạn có muốn tạo mới một khách hàng có mã như vậy luôn không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                            {
                                themKhachHang();

                                load_dataGridViewKhachHang();
                            }
                        }
                        chucnang = 0;
                        break;
                    default:
                        break;
                }
            }
            catch { }
        }

        void btnSua_Click(object sender, EventArgs e)
        {
            UnLockAllControl();
            txtHoTenKhachHang.Focus();
            chucnang = 2;

            txtMaKhachHang.ReadOnly = true;
        }

        void btnThem_Click(object sender, EventArgs e)
        {
            UnLockAllControl();
            ClearAllControl();
            chucnang = 1;

            maKH_TuDong();

            txtDiemTichLuy.ReadOnly = true;
            txtDiemTichLuy.Text = "0";

            txtCapBacKH.ReadOnly = true;
            txtCapBacKH.Text = "Thành viên mới";
        }

        //===================================================================//
        private void load_dataGridViewKhachHang()
        {
            dataGridViewKhachHang.DataSource = kh_bll.layDanhSachKhachHang();

            dataGridViewKhachHang.Columns[3].Visible = false;
            dataGridViewKhachHang.Columns[5].Visible = false;
            dataGridViewKhachHang.Columns[8].Visible = false;
        }

        public void ClearAllControl()
        {
            txtMaKhachHang.Clear();
            txtHoTenKhachHang.Clear();
            txtSoDienThoai.Clear();
            txtEmail.Clear();
            rdNam.Checked = true;
            txtDiaChi.Clear();
            txtCMND.Clear();
            txtDiemTichLuy.Clear();
            txtCapBacKH.Clear();
        }

        public void LockAllControl()
        {
            txtMaKhachHang.ReadOnly = true;
            txtHoTenKhachHang.ReadOnly = true;
            txtSoDienThoai.ReadOnly = true;
            txtEmail.ReadOnly = true;
            rdNam.Enabled = false;
            rdNữ.Enabled = false;
            txtDiaChi.ReadOnly = true;
            txtCMND.ReadOnly = true;
            txtDiemTichLuy.ReadOnly = true;
            txtCapBacKH.ReadOnly = true;
        }

        public void UnLockAllControl()
        {
            txtMaKhachHang.ReadOnly = false;
            txtHoTenKhachHang.ReadOnly = false;
            txtSoDienThoai.ReadOnly = false;
            txtEmail.ReadOnly = false;
            rdNam.Enabled = true;
            rdNữ.Enabled = true;
            txtDiaChi.ReadOnly = false;
            txtCMND.ReadOnly = false;
            txtDiemTichLuy.ReadOnly = false;
            txtCapBacKH.ReadOnly = false;
        }

        private void maKH_TuDong()
        {
            txtMaKhachHang.Text = DateTime.Now.ToString("yyyy") + DateTime.Now.ToString("MM")
                        + DateTime.Now.ToString("dd") + "KH" + DateTime.Now.ToString("HH") + DateTime.Now.ToString("ss");
        }

        private void themKhachHang()
        {
            KhachHang kh = new KhachHang();
            kh.MaKhachHang = txtMaKhachHang.Text;
            kh.TenKhachHang = txtHoTenKhachHang.Text;
            kh.SDT = txtSoDienThoai.Text;
            kh.GioiTinh = rdNam.Checked;
            kh.Email = txtEmail.Text;
            kh.CMND = txtCMND.Text;
            kh.DiaChi = txtDiaChi.Text;
            kh.Diem = int.Parse(txtDiemTichLuy.Text);

            LoaiKhachHang loaikh = new LoaiKhachHang_BLL().timLoaiKhachHang_TheoTenLoai(txtCapBacKH.Text);
            if (loaikh != null)
                kh.LoaiKhachHang = loaikh.MaLoai;
            else
            {
                loaikh = new LoaiKhachHang_BLL().timLoaiKhachHang_TheoDiemTichLuy(kh.Diem.Value);
                if (loaikh != null)
                    kh.LoaiKhachHang = loaikh.MaLoai;
                else
                    kh.LoaiKhachHang = "CAP1";
            }

            if (new KhachHang_BLL().insert_KhachHang(kh) == 1)
            {
                MessageBox.Show("Lưu khách hàng thành công");

                load_dataGridViewKhachHang();

                LockAllControl();

                ClearAllControl();
            }
            else
            {
                MessageBox.Show("Lưu khách hàng thất bại");

                txtHoTenKhachHang.Focus();
            }
        }

        private void capNhatKhachHang()
        {
            KhachHang kh = new KhachHang();
            kh.MaKhachHang = txtMaKhachHang.Text;
            kh.TenKhachHang = txtHoTenKhachHang.Text;
            kh.SDT = txtSoDienThoai.Text;
            kh.GioiTinh = rdNam.Checked;
            kh.Email = txtEmail.Text;
            kh.CMND = txtCMND.Text;
            kh.DiaChi = txtDiaChi.Text;
            kh.Diem = int.Parse(txtDiemTichLuy.Text);

            LoaiKhachHang loaikh = new LoaiKhachHang_BLL().timLoaiKhachHang_TheoTenLoai(txtCapBacKH.Text);
            if (loaikh != null)
                kh.LoaiKhachHang = loaikh.MaLoai;
            else
            {
                loaikh = new LoaiKhachHang_BLL().timLoaiKhachHang_TheoDiemTichLuy(kh.Diem.Value);
                if (loaikh != null)
                    kh.LoaiKhachHang = loaikh.MaLoai;
                else
                    kh.LoaiKhachHang = "CAP1";
            }

            new KhachHang_BLL().update_KhachHang(kh);

            LockAllControl();
        }
        //===================================================================//
        public void mouseclick(Label lb, Guna2TextBox txt, Guna2Panel pn)
        {
            lb.Visible = true;
            txt.PlaceholderText = "";
            pn.CustomBorderColor = Color.FromArgb(255, 128, 0);
            lb.ForeColor = Color.FromArgb(255, 128, 0);
        }

        public void leave(Label lb, Guna2TextBox txt, Guna2Panel pn)
        {
            if (txt.Text.Length == 0)
            {
                lb.Visible = false;
                txt.PlaceholderText = lb.Text;
            }

            pn.CustomBorderColor = Color.FromArgb(224, 224, 224);
            lb.ForeColor = Color.FromArgb(255, 255, 255);
        }

        private void txtHoTenKhachHang_MouseClick(object sender, MouseEventArgs e)
        {
            mouseclick(lbTenKhachHang, txtHoTenKhachHang, pnHoTenKhachHang);
        }

        private void txtEmail_MouseClick(object sender, MouseEventArgs e)
        {
            mouseclick(lbEmail, txtEmail, pnEmail);
        }

        private void txtMaKhachHang_MouseClick(object sender, MouseEventArgs e)
        {
            mouseclick(lbMaKhachHang, txtMaKhachHang, pnMaKhachHang);
        }

        private void txtSoDienThoai_MouseClick(object sender, MouseEventArgs e)
        {
            mouseclick(lbSoDienThoai, txtSoDienThoai, pnSoDienThoai);
        }

        private void txtCMND_MouseClick(object sender, MouseEventArgs e)
        {
            mouseclick(lbCMND, txtCMND, pnCMND);
        }

        private void txtDiemTichLuy_MouseClick(object sender, MouseEventArgs e)
        {
            mouseclick(lbDiemTichLuy, txtDiemTichLuy, pnDiemTichLuy);
        }

        private void txtCapBacKH_MouseClick(object sender, MouseEventArgs e)
        {
            mouseclick(lbCapBacKH, txtCapBacKH, pnCapBacKH);
        }

        private void txtDiaChi_MouseClick(object sender, MouseEventArgs e)
        {
            mouseclick(lbDiaChi, txtDiaChi, pnDiaChi);
        }

        private void rdNam_MouseClick(object sender, MouseEventArgs e)
        {
            lbGioiTinh.ForeColor = Color.FromArgb(255, 128, 0);
        }

        private void pnHoTenKhachHang_Leave(object sender, EventArgs e)
        {
            leave(lbTenKhachHang, txtHoTenKhachHang, pnHoTenKhachHang);
        }

        private void pnEmail_Leave(object sender, EventArgs e)
        {
            leave(lbEmail, txtEmail, pnEmail);
        }

        private void pnMaKhachHang_Leave(object sender, EventArgs e)
        {
            leave(lbMaKhachHang, txtMaKhachHang, pnMaKhachHang);
        }

        private void pnSoDienThoai_Leave(object sender, EventArgs e)
        {
            leave(lbSoDienThoai, txtSoDienThoai, pnSoDienThoai);
        }

        private void pnCMND_Leave(object sender, EventArgs e)
        {
            leave(lbCMND, txtCMND, pnCMND);
        }

        private void pnDiemTichLuy_Leave(object sender, EventArgs e)
        {
            leave(lbDiemTichLuy, txtDiemTichLuy, pnDiemTichLuy);
        }

        private void pnCapBacKH_Leave(object sender, EventArgs e)
        {
            leave(lbCapBacKH, txtCapBacKH, pnCapBacKH);
        }

        private void pnDiaChi_Leave(object sender, EventArgs e)
        {
            leave(lbDiaChi, txtDiaChi, pnDiaChi);
        }

        private void pnGioiTinh_Leave(object sender, EventArgs e)
        {
            lbGioiTinh.ForeColor = Color.FromArgb(255, 255, 255);
        }
    }
}
