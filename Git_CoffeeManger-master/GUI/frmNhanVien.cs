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
    public partial class frmNhanVien : Form
    {

        NhanVien_BLL nv_bll;
        LoaiNhanVien_BLL loainv;

        int chucnang = 0;

        public frmNhanVien()
        {
            InitializeComponent();

            nv_bll = new NhanVien_BLL();
            loainv = new LoaiNhanVien_BLL();

            LockAllControl();

            load_ComboBoxNhomNguoiDung();
            load_dataGridViewNhanVien();

            cboNguoiDung.SelectedIndex = 0;

            this.btnThem.Click += btnThem_Click;
            this.btnSua.Click += btnSua_Click;
            this.btnLuu.Click += btnLuu_Click;
            this.btnXoa.Click += btnXoa_Click;
            this.btnTatCa.Click += btnTatCa_Click;
            this.btnDangHoatDong.Click += btnDangHoatDong_Click;
            this.btnDaNghi.Click += btnDaNghi_Click;
            this.cboNguoiDung.SelectedValueChanged += cboNguoiDung_SelectedValueChanged;
            this.dataGridViewNhanVien.CellContentClick += dataGridViewNhanVien_CellContentClick;
            
           
        }

        void btnDaNghi_Click(object sender, EventArgs e)
        {
            dataGridViewNhanVien.DataSource = nv_bll.layDanhSachNhanVien_TheoTrangThai(false);
        }

        void btnDangHoatDong_Click(object sender, EventArgs e)
        {
            dataGridViewNhanVien.DataSource = nv_bll.layDanhSachNhanVien_TheoTrangThai(true);
        }

        void dataGridViewNhanVien_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                DataGridViewRow i = dataGridViewNhanVien.Rows[e.RowIndex];

                txtMaNhanVien.Text = i.Cells[0].Value.ToString();
                txtHoTenKhachHang.Text = i.Cells[1].Value.ToString();
                txtSoDienThoai.Text = i.Cells[2].Value.ToString();
                if ((Boolean)i.Cells[3].Value)
                    rdNam.Checked = true;
                else
                    rdNữ.Checked = true;
                dateTimePickerNgaySinh.Value = Convert.ToDateTime(i.Cells["NgaySinh"].Value.ToString());
                txtEmail.Text = i.Cells[5].Value.ToString();
                txtCMND.Text = i.Cells[6].Value.ToString();
                txtDiaChi.Text = i.Cells[7].Value.ToString();
                dateTimePickerNgayVaoLam.Value = Convert.ToDateTime(i.Cells["NgayVaoLam"].Value.ToString());
                txtMatKhau.Text = i.Cells[9].Value.ToString();
                chkTrangThai.Checked = (Boolean)i.Cells[10].Value;
                txtTongGioLam.Text = i.Cells[11].Value.ToString();
                txtLuongThucTe.Text = i.Cells[12].Value.ToString();
                cboNguoiDung.SelectedValue = i.Cells[13].Value.ToString();
            }
            catch { }

        }

        public void cboNguoiDung_SelectedValueChanged(object sender, EventArgs e)
        {
            try
            {
                LoaiNhanVien loai = loainv.layLoaiNhanVien_TheoMaLoai(cboNguoiDung.SelectedValue.ToString());
                txtLuongCoBan.Text = loai.LuongCoBan.ToString();
                txtLuongThucTe.Text = (int.Parse(txtTongGioLam.Text) * loai.LuongCoBan).ToString();
            }
            catch { }
        }

        void btnTatCa_Click(object sender, EventArgs e)
        {
            load_dataGridViewNhanVien();
        }

        void btnXoa_Click(object sender, EventArgs e)
        {
            if (txtMaNhanVien.Text.Trim().Length != 0)
            {
                if (MessageBox.Show("Bạn có muốn xóa nhân viên " + txtHoTenKhachHang.Text + " với mã nhân viên " + txtMaNhanVien.Text + " ra khỏi danh sách không?",
                    "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                    nv_bll.delete_NhanVien(txtMaNhanVien.Text);
                load_dataGridViewNhanVien();
            }
            else
            {
                if (MessageBox.Show("Bạn có muốn xóa các nhân viên đang được chọn trong bảng nhân viên hay không?", "Thông báo",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                    while (dataGridViewNhanVien.SelectedRows != null)
                        nv_bll.delete_NhanVien(dataGridViewNhanVien.SelectedRows[0].Cells[0].Value.ToString());
                load_dataGridViewNhanVien();
            }
        }

        void btnLuu_Click(object sender, EventArgs e)
        {
            TimeSpan getDateDifference(DateTime date1, DateTime date2)
            {
                TimeSpan ts = date1 - date2;
                int differenceInDays = ts.Days;
                string differenceAsString = differenceInDays.ToString();
                return ts;

            }
            try
            {
                if (txtMaNhanVien.Text.Trim().Length == 0)
                {
                    MessageBox.Show("Không có thông tin về họ tên nhân viên");
                    return;
                }

                if (txtSoDienThoai.Text.Trim().Length == 0)
                {
                    MessageBox.Show("Không có thông tin về số điện thoại nhân viên");
                    return;
                }

                if (txtCMND.Text.Trim().Length == 0)
                {
                    MessageBox.Show("Không có thông tin về số chứng mình nhân viên");
                    return;
                }


                    TimeSpan difference = getDateDifference(DateTime.Now, dateTimePickerNgaySinh.Value);
                    int differenceinDay = difference.Days;
                    if(differenceinDay >= 18)
                    {
                        NhanVien nv = new NhanVien();

                        nv.MaNhanVien = txtMaNhanVien.Text;
                        nv.TenNhanVien = txtHoTenKhachHang.Text;
                        nv.SDT = txtSoDienThoai.Text;
                        nv.GioiTinh = rdNam.Checked;
                        nv.NgaySinh = dateTimePickerNgaySinh.Value;
                        nv.Email = txtEmail.Text;
                        nv.CMND = txtCMND.Text;
                        nv.DiaChi = txtDiaChi.Text;
                        nv.NgaySinh = dateTimePickerNgayVaoLam.Value;
                        nv.MatKhau = txtMatKhau.Text;
                        nv.TinhTrang = chkTrangThai.Checked;
                        nv.TongGioLam = int.Parse(txtTongGioLam.Text);
                        nv.Luong = double.Parse(txtLuongThucTe.Text);
                        nv.LoaiNhanVien = cboNguoiDung.SelectedValue.ToString();

                        if (chucnang == 1)
                        {
                            if (nv_bll.insert_NhanVien(nv) == 1)
                            {
                                MessageBox.Show("Thêm nhân viên thành công");

                                load_dataGridViewNhanVien();

                                LockAllControl();
                            }
                            chucnang = 0;
                        }
                        if (chucnang == 2)
                        {
                            nv_bll.update_NhanVien(nv);

                            load_dataGridViewNhanVien();

                            LockAllControl();

                            chucnang = 0;
                        }
                }
                else
                {
                    MessageBox.Show("Nhân viên này hiện không đủ 18t hoặc ngày sinh nhập sai, hãy kiểm tra lại");
                    return;
                }
            }
            catch { }

        }

        void btnSua_Click(object sender, EventArgs e)
        {
            chucnang = 2;

            UnLockAllControl();

            txtHoTenKhachHang.Focus();
        }

        void btnThem_Click(object sender, EventArgs e)
        {
            chucnang = 1;

            UnLockAllControl();

            ClearAllControl();

            txtMaNhanVien.Text = maNV_TuDong();

            txtLuongCoBan.Text = "0";
            txtLuongThucTe.ReadOnly = true;
            txtLuongThucTe.Text = "0";
            txtLuongThucTe.ReadOnly = true;
            txtTongGioLam.Text = "0";
            txtTongGioLam.ReadOnly = true;

            dateTimePickerNgayVaoLam.Value = DateTime.Now;
        }

        //=========================================================//
        private void load_dataGridViewNhanVien()
        {
            dataGridViewNhanVien.DataSource = nv_bll.layDanhSachNhanVien();

            dataGridViewNhanVien.Columns[0].Visible = false;
            dataGridViewNhanVien.Columns[3].Visible = false;
            dataGridViewNhanVien.Columns[7].Visible = false;
            dataGridViewNhanVien.Columns[9].Visible = false;
            dataGridViewNhanVien.Columns[10].Visible = false;
            dataGridViewNhanVien.Columns[11].Visible = false;
            dataGridViewNhanVien.Columns[12].Visible = false;
            dataGridViewNhanVien.Columns[13].Visible = false;
            dataGridViewNhanVien.Columns[14].Visible = false;

        }

        private void load_ComboBoxNhomNguoiDung()
        {
            cboNguoiDung.DataSource = loainv.layDanhSachLoaiNhanVien();

            cboNguoiDung.DisplayMember = "TenLoai";
            cboNguoiDung.ValueMember = "MaLoaiNV";
        }

        public void ClearAllControl()
        {
            txtHoTenKhachHang.Clear();
            txtEmail.Clear();
            txtMaNhanVien.Clear();
            txtSoDienThoai.Clear();
            txtCMND.Clear();
            txtMatKhau.Clear();
            rdNam.Checked = true;
            txtDiaChi.Clear();
            cboNguoiDung.SelectedIndex = 0;
            dateTimePickerNgaySinh.Value = Convert.ToDateTime("12/31/1900");
            dateTimePickerNgayVaoLam.Value = Convert.ToDateTime("12/31/1900");
            chkTrangThai.Checked = false;
            txtLuongCoBan.Clear();
            txtTongGioLam.Clear();
            txtLuongThucTe.Clear();
        }

        public void LockAllControl()
        {
            txtHoTenKhachHang.ReadOnly = true;
            txtEmail.ReadOnly = true;
            txtMaNhanVien.ReadOnly = true;
            txtSoDienThoai.ReadOnly = true;
            txtCMND.ReadOnly = true;
            txtMatKhau.ReadOnly = true;
            rdNam.Enabled = false;
            rdNữ.Enabled = false;
            txtDiaChi.ReadOnly = true;
            cboNguoiDung.Enabled = false;
            dateTimePickerNgaySinh.Enabled = false;
            dateTimePickerNgayVaoLam.Enabled = false;
            chkTrangThai.Enabled = false;
            txtLuongCoBan.ReadOnly = true;
            txtTongGioLam.ReadOnly = true;
            txtLuongThucTe.ReadOnly = true;
        }

        public void UnLockAllControl()
        {
            txtHoTenKhachHang.ReadOnly = false;
            txtEmail.ReadOnly = false;
            txtMaNhanVien.ReadOnly = false;
            txtSoDienThoai.ReadOnly = false;
            txtCMND.ReadOnly = false;
            txtMatKhau.ReadOnly = false;
            rdNam.Enabled = true;
            rdNữ.Enabled = true;
            txtDiaChi.ReadOnly = false;
            cboNguoiDung.Enabled = true;
            dateTimePickerNgaySinh.Enabled = true;
            dateTimePickerNgayVaoLam.Enabled = true;
            chkTrangThai.Enabled = true;
            txtLuongCoBan.ReadOnly = false;
            txtTongGioLam.ReadOnly = false;
            txtLuongThucTe.ReadOnly = false;
        }

        private string maNV_TuDong()
        {
            return DateTime.Now.ToString("yyyy") + DateTime.Now.ToString("MM")
                        + DateTime.Now.ToString("dd") + "NV" + DateTime.Now.ToString("HH") + DateTime.Now.ToString("ss");
        }
        //=========================================================//
    }
}
