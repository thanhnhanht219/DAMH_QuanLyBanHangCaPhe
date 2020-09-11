using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using BLL.BLL_Class;
using DLL;
using Guna.UI.WinForms;
using Guna.UI2.WinForms;


namespace GUI
{
    public partial class frmPOS : Form
    {
        #region properties
        SanPham_BLL sp_bll = new SanPham_BLL();
        KhachHang_BLL kh_bll = new KhachHang_BLL();
        List<ChiTietHoaDon> lstChiTiet;
        HoaDon_BLL hd_bll = new HoaDon_BLL();
        NhanVien nv_bll = new NhanVien();
        int tongtienHd;
        NhanVien nv;
        KhachHang kh_hientai;
        string maHD;
        NhanVien NV_hienTai;
        #endregion
        public frmPOS()
        {
            InitializeComponent();
            WindowState = FormWindowState.Maximized;
        }

        public frmPOS(NhanVien nv)
        {
            InitializeComponent();
            lbTenNhanVien.Text = nv.TenNhanVien;
            NV_hienTai = nv;
            WindowState = FormWindowState.Maximized;
        }

        public frmPOS(NhanVien nv,bool b)
        {
            InitializeComponent();
            lbTenNhanVien.Text = nv.TenNhanVien;
            picBack.Enabled = b;
            NV_hienTai = nv;
            WindowState = FormWindowState.Maximized;
        }


        #region method

        public void loadNhomSanPham()
        {
            List<NhomSanPham> lstLoai = sp_bll.layDanhSachMaNhom();
            int top = 10;

            for (int i = 0; i < lstLoai.Count; i++)
            {
                Guna2Button btnNhomSanPham = new Guna2Button()
                {
                    BackColor = Color.Transparent,
                    Dock = DockStyle.Left,
                    FillColor = Color.Transparent,
                    Font = new Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0))),
                    ForeColor = Color.White,
                    Location = new System.Drawing.Point(0, 0),
                    Margin = new System.Windows.Forms.Padding(2),
                    PressedColor = Color.Transparent,
                    Size = new System.Drawing.Size(150, 39),
                    TabIndex = 0,
                    Animated = true,
                    Tag = lstLoai[i].MaNhomSP,
                    Text = lstLoai[i].TenNhom
                };
                btnNhomSanPham.Click += BtnNhom_Click;
                pnNhomSanPham.Controls.Add(btnNhomSanPham);
            }
        }

        private void loadSPTheoNhomSP(string maLoaiNL)
        {
            List<SanPham> lstSP = sp_bll.layDanhSachSanPhamTheoNhom(maLoaiNL);
            loadSanPham(lstSP);
        }
        private void loadSanPham(List<SanPham> lstSP)
        {
            pnContainer.Controls.Clear();
            foreach (SanPham item in lstSP)
            {
                string path;
                usSanPham itemsp = new usSanPham();

                //itemsp.btnchon.Visible = false;

                if (item.HinhAnh == null || item.HinhAnh == string.Empty)
                {
                    path = Application.StartupPath + "\\Asset\\More\\ic_image.png";
                }
                else
                {
                    path = Application.StartupPath + "\\Asset\\SanPham\\" + item.HinhAnh;
                }

                itemsp.setValue((float)item.Gia, path, item.TenSanPham);
                //itemsp.setSuKien();
                itemsp.pic.Tag = item.MaSanPham + "," + (float)item.Gia;
                itemsp.pic.Click += itemsp_Click;
                pnContainer.Controls.Add(itemsp);
                itemsp.BringToFront();
            }
        }

        private void itemsp_Click(object sender, EventArgs e)
        {
           
            PictureBox  pc = (PictureBox)sender;
            if (lstChiTiet == null)
            {
                MessageBox.Show("Vui lòng ấn tạo hóa đơn trước khi thêm món!");
                return;
            }
            string[] mavagia = pc.Tag.ToString().Split(',');

            ChiTietHoaDon cthd = new ChiTietHoaDon();
            cthd.MaHoaDon = " ";

            cthd.MaSanPham = mavagia[0];
            cthd.SoLuong = 1;
            cthd.ThanhTien = Convert.ToInt32(mavagia[1]);
           
            if (!checkHD(mavagia[0]))
            {
                MessageBox.Show("Sản phẩm đã có trong chi tiết hóa đơn");
                return;

            }
            lstChiTiet.Add(cthd);
            usChiTietSanPham usChiTiet = new usChiTietSanPham();
            usChiTiet.setValue(mavagia[0]);
            usChiTiet.Tag = mavagia[0];
            usChiTiet.btnTangGiam.Tag = mavagia[0];
            usChiTiet.btnXoa.Tag = mavagia[0];

            pnChiTietHoaDon.Controls.Add(usChiTiet);
            usChiTiet.Dock = DockStyle.Top;

            usChiTiet.btnTangGiam.Click += BtnTangGiam_Click; ;
            usChiTiet.btnXoa.Click += BtnXoa_Click; ;
            capnhapTongTien();
        }

        private void capnhapTongTien()
        {

            if (lstChiTiet.Count == 0 || lstChiTiet == null)
            {
                return;
            }
            float tong = 0;
            foreach (usChiTietSanPham item in pnChiTietHoaDon.Controls)
            {
                tong += item.tongTien;
                
            }
            lbTongCong.Text = tong + " ";
            lbThanhToan.Text = tong + " ";

            if (kh_hientai == null)
            {
                return;
            }
            lbThanhToan.Text = tong + " ";

        }

        private void catnhapSoLuongSanPhamChiTiet(string p1, int p2)
        {
            foreach (ChiTietHoaDon item in lstChiTiet)
            {
                if (item.MaSanPham == p1)
                {
                    item.SoLuong = p2;
                    break;
                }
            }
        }

        private bool checkHD(string maSP)
        {
            if (lstChiTiet.Count == 0)
            {
                return true;
            }
            foreach (Control control in pnChiTietHoaDon.Controls)
            {

                if (control.Tag.ToString() == maSP)
                {
                    return false;
                }
            }
            return true;
        }

        public void resetThanhToan()
        {
            lbDiemTL.Text = "0";
            lbTongCong.Text = "0";
            lbTienDu.Text = "0";
            lbThanhToan.Text = "0";
            txtTienDua.Text = "0";
            txtKhachHang.Enabled = false;
        }

        public void capnhaptiendu()
        {
            try
            {
                if (txtTienDua.Text == string.Empty)
                {
                    lbTienDu.Text = "0";
                    return;
                }
                if (Convert.ToInt32(txtTienDua.Text) >= dsHangSo.SOTIENLONNHAT)
                {
                    MessageBox.Show("Vượt quá giới hạn thanh toán!");
                    return;
                }

                int val = Convert.ToInt32(txtTienDua.Text);
                updateTienThua_TienThieu(val, Convert.ToInt32(lbThanhToan.Text));
            }
            catch
            {
                MessageBox.Show("Vượt giới hạn của kiểu dữ liệu");
            }
        }

        public void updateTienThua_TienThieu(int val, int tong)
        {

            if (val > tong)
            {

                lbTienDu.Text = (val - tong).ToString();
                lbTienDu.ForeColor = Color.FromArgb(255, 255, 192);
            }
            else if (val < tong)
            {


                lbTienDu.Text = (tong - val).ToString();
                lbTienDu.ForeColor = Color.FromArgb(255, 128, 128);
            }
            else
            {
                lbTienDu.Text = "0";
            }
        }

        private void veTrangThaiBD()
        {
            loadSanPham(sp_bll.layDanhSachSanPhamList());
            resetThanhToan();
            txtKhachHang.Clear();
            txtKhachHang.PlaceholderText = "Nhập vào khách hàng ... ";
            tongtienHd = 0;
            lstChiTiet = null;
            pnChiTietHoaDon.Controls.Clear();
             maHD = "";
            btnTaoHoaDon.Enabled = true;

        }


        public bool checkTienDua()
        {
            if (txtTienDua.Text == string.Empty)
            {
                return false;
            }
            int tiendua = Convert.ToInt32(txtTienDua.Text);
            int tongtien = Convert.ToInt32(lbThanhToan.Text);
            return tiendua >= tongtien ? true : false;
        }
        #endregion



        private void frmPOS_Load(object sender, EventArgs e)
        {
            Guna.UI.Lib.ScrollBar.PanelScrollHelper flowpanel =
              new Guna.UI.Lib.ScrollBar.PanelScrollHelper(pnContainer, gunaVScrollBar1, true);

            Guna.UI.Lib.ScrollBar.PanelScrollHelper pn =
             new Guna.UI.Lib.ScrollBar.PanelScrollHelper(pnChiTietHoaDon, gunaVScrollBar2, true);

            loadSanPham(sp_bll.layDanhSachSanPhamList());
            resetThanhToan();
            loadNhomSanPham();
            tongtienHd = 0;
        }

        private void BtnXoa_Click(object sender, EventArgs e)
        {
            PictureBox nb = (PictureBox)sender;
            for (int i = 0; i < pnChiTietHoaDon.Controls.Count; i++)
            {
                if (pnChiTietHoaDon.Controls[i].Tag != null && pnChiTietHoaDon.Controls[i].Tag.ToString() == nb.Tag.ToString())
                {
                    pnChiTietHoaDon.Controls.Remove(pnChiTietHoaDon.Controls[i]);
                    lstChiTiet.RemoveAt(i);
                    capnhapTongTien();
                }
                else
                {
                    continue;
                }
            }

        }

        private void BtnTangGiam_Click(object sender, EventArgs e)
        {
            GunaNumeric nb = (GunaNumeric)sender;
            if (nb.Value > 10)
            {
                MessageBox.Show("Đã vượt giới hạn cho phép. 10!");
                nb.Value = 10;
                return;
            }
            foreach (Control item in pnChiTietHoaDon.Controls)
            {
                if (item.Tag != null && item.Tag.ToString() == nb.Tag.ToString())
                {                    
                    usChiTietSanPham usChiTiet = (usChiTietSanPham)item;
                    usChiTiet.capnhapTongTien((int)nb.Value);
                    // Cap nhap so luong moi don hang                    
                    catnhapSoLuongSanPhamChiTiet(nb.Tag.ToString(), (int) nb.Value);
                }
                else
                {
                    continue;
                }
            }
            capnhapTongTien();
        }

        private void BtnNhomNguyenLieu_Click(object sender, EventArgs e)
        {
            GunaAdvenceTileButton btn = (GunaAdvenceTileButton)sender;
            loadSPTheoNhomSP(btn.Tag.ToString());
        }

        private void BtnNhom_Click(object sender, EventArgs e)
        {
            Guna2Button btn = (Guna2Button)sender;
            loadSPTheoNhomSP(btn.Tag.ToString());
        }

        private void btnTatCa_Click(object sender, EventArgs e)
        {
            List<SanPham> lst = sp_bll.layDanhSachSanPhamList();
            loadSanPham(lst);
        }

        private void btnTaoHoaDon_Click(object sender, EventArgs e)
        {
            txtKhachHang.Enabled = true;
            if (btnTaoHoaDon.Enabled == true)
            {
                lstChiTiet = new List<ChiTietHoaDon>();
                btnTaoHoaDon.Enabled = false;
                
            }
            else
            {
                resetThanhToan();
                pnChiTietHoaDon.Controls.Clear();
                lstChiTiet = null;
                btnTaoHoaDon.Enabled = true;
            }
        }

        private void txtTienDua_TextChanged(object sender, EventArgs e)
        {
            capnhaptiendu();
            
        }

        private void btnSeachKH_Click(object sender, EventArgs e)
        {
            if (txtKhachHang.Enabled == false)
            {
                txtKhachHang.Text = "";
                txtKhachHang.Enabled = true;
                lbDiemTL.Text = "0";
                return;
            }
            if (txtKhachHang.Text == string.Empty)
            {
                MessageBox.Show("Chưa nhập mã số khách hàng");
                return;
            }
            else
            {
                string makh = txtKhachHang.Text;
                KhachHang kh = kh_bll.loadGridViewTimKiemPOSKhachHang(makh);
                kh_hientai = kh;
                if (kh == null)
                {
                    MessageBox.Show("Khách hàng chưa đăng kí. Vui lòng Ấn thêm khách hàng!");
                    return;
                }
                txtKhachHang.Enabled = false;
                lbDiemTL.Text = (int.Parse(lbTongCong.Text) / 10000).ToString();
                txtKhachHang.Text = kh.TenKhachHang;
            }
        }

        private void txtTienDua_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void btnSeachSP_Click(object sender, EventArgs e)
        {
            if (txtSearchSP.Text == string.Empty)
            {
                MessageBox.Show("Chưa nhập sản phẩm");
                return;
            }
            List<SanPham> lstSP = sp_bll.layDanhSachSanPhamTimKiemTheoTen(txtSearchSP.Text);
            if (lstSP.Count == 0)
            {
                MessageBox.Show("Không tìm thấy sản phẩm");
                return;
            }

            loadSanPham(lstSP);
        }

        private void btnThanhToan_Click(object sender, EventArgs e)
        {
            if (lstChiTiet == null || lstChiTiet.Count == 0)
            {
                MessageBox.Show("Hóa đơn đang tạo bị rỗng, vui lòng thêm món!");
                return;
            }
            if (!checkTienDua())
            {
                MessageBox.Show("Số tiền khách đưa không hợp lệ.");
                return;
            }
            else
            {
                string makh = "";
                if(txtKhachHang.Text.Length == 0)
                {
                    makh = null;
                }
                else
                {
                    makh = txtKhachHang.Text;
                }    
                maHD = hd_bll.setMaHD();
                hd_bll.insert_HoaDon(lstChiTiet, maHD, NV_hienTai.MaNhanVien, "NULL", double.Parse(lbThanhToan.Text));

                MessageBox.Show("Thanh toán thành công!");
                    //xuatFileExcel();
                    if (kh_hientai == null)
                    {
                        veTrangThaiBD();
                        return;
                    }
                    veTrangThaiBD();
            }
        }

        private void picBack_Click(object sender, EventArgs e)
        {
            frmMain frm = new frmMain();
            frm.Show();
            this.Close();
        }
    }
}
