using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BLL;
using BLL.BLL_Class;

namespace GUI
{
    public partial class frmSanPham : Form
    {
        NhomSanPham_BLL nhomsp_bll;
        SanPham_BLL sp_bll;

        int chucnang = 0;

        public frmSanPham()
        {
            InitializeComponent();

            nhomsp_bll = new NhomSanPham_BLL();
            sp_bll = new SanPham_BLL();

            LockAllControl();

            //load image từ máy lên project
            //image.Image = new Bitmap(Application.StartupPath + "\\Asset\\SanPham\\Capheden.png");
            //guna2ImageButton2.Image = new Bitmap(Application.StartupPath + "\\Asset\\SanPham\\Capheden.png");

            load_ComboBoxLoaiSanPham();
            load_dataGridViewSanPham();

            this.btnThem.Click += btnThem_Click;
            this.btnSua.Click += btnSua_Click;
            this.btnTatCa.Click += btnTatCa_Click;
            this.btnXoa.Click += btnXoa_Click;
            this.dataGridViewSanPham.CellContentClick += dataGridViewSanPham_CellContentClick;
            this.btnDanhKinhDoanh.Click += btnDanhKinhDoanh_Click;
            this.btnNgungKinhDoanh.Click += btnNgungKinhDoanh_Click;
        }

        void btnNgungKinhDoanh_Click(object sender, EventArgs e)
        {
            dataGridViewSanPham.DataSource = sp_bll.layDanhSachSanPham_TheoTinhTrang(false);
        }

        void btnDanhKinhDoanh_Click(object sender, EventArgs e)
        {
            dataGridViewSanPham.DataSource = sp_bll.layDanhSachSanPham_TheoTinhTrang(true);
        }

        void dataGridViewSanPham_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                DataGridViewRow i = dataGridViewSanPham.Rows[e.RowIndex];

                string tenHinh = Application.StartupPath + "\\Asset\\SanPham\\" + i.Cells["HinhAnh"].Value.ToString();
                btnImage.Image = new Bitmap(tenHinh);
                txtMaSanPham.Text = i.Cells[1].Value.ToString();
                txtTenSanPham.Text = i.Cells[2].Value.ToString();
                txtGiaThucTe.Text = i.Cells[3].Value.ToString();

                txtMoTa.Text = i.Cells[5].Value.ToString();
                chkTrangThai.Checked = (Boolean)i.Cells[6].Value;
                cboNhom.SelectedValue = i.Cells[7].Value.ToString();
            }
            catch { }
        }

        void btnTatCa_Click(object sender, EventArgs e)
        {
            load_dataGridViewSanPham();
        }

        void btnXoa_Click(object sender, EventArgs e)
        {
            if (txtMaSanPham.Text.Trim().Length != 0)
            {
                if (MessageBox.Show("Bạn có muốn xóa sản phẩm " + txtTenSanPham.Text + " với mã sản phẩm " + txtMaSanPham.Text + " ra khỏi danh sách không?",
                    "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                    sp_bll.delete_SanPham(txtMaSanPham.Text);
                load_dataGridViewSanPham();
            }
            else
            {
                if (MessageBox.Show("Bạn có muốn xóa các sản phẩm đang được chọn trong bảng sản phẩm hay không?", "Thông báo",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                    while (dataGridViewSanPham.SelectedRows != null)
                        sp_bll.delete_SanPham(dataGridViewSanPham.SelectedRows[0].Cells[0].Value.ToString());
                load_dataGridViewSanPham();
            }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            try
            {
                SanPham sp = new SanPham();

                sp.HinhAnh = txtPath.Text;
                sp.MaSanPham = txtMaSanPham.Text;
                sp.TenSanPham = txtTenSanPham.Text;
                sp.Gia = double.Parse(txtGiaThucTe.Text);

                sp.MoTa = txtMoTa.Text;
                sp.TinhTrang = chkTrangThai.Checked;
                sp.Nhom = cboNhom.SelectedValue.ToString();

                if (chucnang == 1)
                {
                    if (sp_bll.insert_SanPham(sp) == 1)
                    {
                        MessageBox.Show("Lưu sản phẩm mới thành công");

                        load_dataGridViewSanPham();

                        LockAllControl();

                        chucnang = 0;

                        saveImage();
                    }
                    else
                        MessageBox.Show("Lưu sản phẩm thất bại");
                }
                if (chucnang == 2)
                {
                    sp_bll.update_SanPham(sp);

                    MessageBox.Show("Lưu thay đổi thành công");

                    LockAllControl();

                    chucnang = 0;

                    saveImage();
                }
            }
            catch { }
        }

        void btnSua_Click(object sender, EventArgs e)
        {
            UnLockAllControl();

            chucnang = 2;
        }

        void btnThem_Click(object sender, EventArgs e)
        {
            chucnang = 1;

            UnLockAllControl();
            ClearAllControl();

            txtMaSanPham.Text = maSP_TuDong();
        }
        //=======================================================================//
        private void load_ComboBoxLoaiSanPham()
        {
            cboNhom.DataSource = nhomsp_bll.layDanhSachNhomSanPham();

            cboNhom.DisplayMember = "TenNhom";
            cboNhom.ValueMember = "MaNhomSP";
        }

        private void load_dataGridViewSanPham()
        {
            dataGridViewSanPham.DataSource = sp_bll.layDanhSachSanPham();

            dataGridViewSanPham.Columns[0].Visible = false;
            dataGridViewSanPham.Columns[4].Visible = false;
            dataGridViewSanPham.Columns[6].Visible = false;
            dataGridViewSanPham.Columns[7].Visible = false;
            dataGridViewSanPham.Columns[8].Visible = false;
        }

        public void ClearAllControl()
        {
            txtMaSanPham.Clear();
            txtTenSanPham.Clear();
            txtGiaThucTe.Clear();
            cboNhom.SelectedIndex = -1;
            chkTrangThai.Checked = false;
            txtMoTa.Clear();
        }

        public void LockAllControl()
        {
            txtMaSanPham.ReadOnly = true;
            txtTenSanPham.ReadOnly = true;
            txtGiaThucTe.ReadOnly = true;
            cboNhom.Enabled = false;
            chkTrangThai.Enabled = false;
            txtMoTa.ReadOnly = true;
        }

        public void UnLockAllControl()
        {
            txtMaSanPham.ReadOnly = false;
            txtTenSanPham.ReadOnly = false;
            txtGiaThucTe.ReadOnly = false;

            cboNhom.Enabled = true;
            chkTrangThai.Enabled = true;
            txtMoTa.ReadOnly = false;
        }

        private string maSP_TuDong()
        {
            return DateTime.Now.ToString("yyyy") + DateTime.Now.ToString("MM")
                        + DateTime.Now.ToString("dd") + "SP" + DateTime.Now.ToString("HH") + DateTime.Now.ToString("ss");
        }

        private void saveImage()
        {
            try
            {
                btnImage.Image.Save(Application.StartupPath + "\\Asset\\SanPham\\" + txtPath.Text);
                MessageBox.Show("Thành công");
            }
            catch
            {
                MessageBox.Show("Lỗi");
            }
        }

        //=======================================================================//
        private void txtMaSanPham_MouseClick(object sender, MouseEventArgs e)
        {
            lbMaSanPham.Visible = true;
            txtMaSanPham.PlaceholderText = "";
            pnMaSanPham.CustomBorderColor = Color.FromArgb(255, 128, 0);
            lbMaSanPham.ForeColor = Color.FromArgb(255, 128, 0);
        }

        private void txtTenSanPham_MouseClick(object sender, MouseEventArgs e)
        {
            lbTenSanPham.Visible = true;
            txtTenSanPham.PlaceholderText = "";
            pnTenSanPham.CustomBorderColor = Color.FromArgb(255, 128, 0);
            lbTenSanPham.ForeColor = Color.FromArgb(255, 128, 0);
        }

        private void txtMoTa_MouseClick(object sender, MouseEventArgs e)
        {
            lbMoTa.Visible = true;
            txtMoTa.PlaceholderText = "";
            pnMoTa.CustomBorderColor = Color.FromArgb(255, 128, 0);
            lbMoTa.ForeColor = Color.FromArgb(255, 128, 0);
        }

        private void txtGiaThucTe_MouseClick(object sender, MouseEventArgs e)
        {
            lbGiaThucTe.Visible = true;
            txtGiaThucTe.PlaceholderText = "";
            pnGiaThucTe.CustomBorderColor = Color.FromArgb(255, 128, 0);
            lbGiaThucTe.ForeColor = Color.FromArgb(255, 128, 0);
        }

        private void pnTrangThai_MouseClick(object sender, MouseEventArgs e)
        {
            lbTrangThai.ForeColor = Color.FromArgb(255, 128, 0);

        }

        private void cboNhom_MouseClick(object sender, MouseEventArgs e)
        {
            lbNhom.ForeColor = Color.FromArgb(255, 128, 0);

        }

        private void chkTrangThai_MouseClick(object sender, MouseEventArgs e)
        {
            lbTrangThai.ForeColor = Color.FromArgb(255, 128, 0);
        }

        private void pnNhom_MouseClick(object sender, MouseEventArgs e)
        {
            lbNhom.ForeColor = Color.FromArgb(255, 128, 0);
        }

        private void pnMaSanPham_Leave(object sender, EventArgs e)
        {
            if (txtMaSanPham.Text.Length == 0)
            {
                lbMaSanPham.Visible = false;
                txtMaSanPham.PlaceholderText = "Mã sản phẩm";
            }

            pnMaSanPham.CustomBorderColor = Color.FromArgb(224, 224, 224);
            lbMaSanPham.ForeColor = Color.FromArgb(255, 255, 255);
        }

        private void pnTenSanPham_Leave(object sender, EventArgs e)
        {
            if (txtTenSanPham.Text.Length == 0)
            {
                lbTenSanPham.Visible = false;
                txtTenSanPham.PlaceholderText = "Tên sản phẩm";

            }
            pnTenSanPham.CustomBorderColor = Color.FromArgb(224, 224, 224);
            lbTenSanPham.ForeColor = Color.FromArgb(255, 255, 255);
        }

        private void pnMoTa_Leave(object sender, EventArgs e)
        {
            if (txtMoTa.Text.Length == 0)
            {
                lbMoTa.Visible = false;
                txtMoTa.PlaceholderText = "Mô tả";

            }
            pnMoTa.CustomBorderColor = Color.FromArgb(224, 224, 224);
            lbMoTa.ForeColor = Color.FromArgb(255, 255, 255);
        }

        private void pnGiaThucTe_Leave(object sender, EventArgs e)
        {
            if (txtGiaThucTe.Text.Length == 0)
            {
                lbGiaThucTe.Visible = false;
                txtGiaThucTe.PlaceholderText = "Giá thực tế";

            }
            pnGiaThucTe.CustomBorderColor = Color.FromArgb(224, 224, 224);
            lbGiaThucTe.ForeColor = Color.FromArgb(255, 255, 255);
        }

        private void pnTrangThai_Leave(object sender, EventArgs e)
        {
            lbTrangThai.ForeColor = Color.FromArgb(255, 255, 255);
        }

        private void pnNhom_Leave(object sender, EventArgs e)
        {
            lbNhom.ForeColor = Color.FromArgb(255, 255, 255);
        }

        private void btnImage_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            // image filters  
            open.Filter = "Image Files(*.jpg; *.jpeg; *.gif; *.bmp;*.png)|*.jpg; *.jpeg; *.gif; *.bmp;*.png";
            if (open.ShowDialog() == DialogResult.OK)
            {
                // display image in picture box  
                btnImage.Image = new Bitmap(open.FileName);
                //image file path
                txtPath.Text = Path.GetFileName(open.FileName);

                //File.Copy(open.FileName,Path.GetDirectoryName(Application.ExecutablePath)+@"..\Asset\SanPham\"+txtPath.Text);

            }
            open.Dispose();
        }


    }

}
