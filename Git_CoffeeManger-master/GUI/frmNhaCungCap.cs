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
using BLL;
using BLL.BLL_Class;

namespace GUI
{
    public partial class frmNhaCungCap : Form
    {

        NhaCungCap_BLL ncc_bll;

        int chucNang = 0;

        public frmNhaCungCap()
        {
            InitializeComponent();

            ncc_bll = new NhaCungCap_BLL();

            load_dataGridViewNhaCungCap();

            LockAllControl();

            this.btnThem.Click += btnThem_Click;
            this.btnSua.Click += btnSua_Click;
            this.btnLuu.Click += btnLuu_Click;
            this.btnXoa.Click += btnXoa_Click;

            this.dataGridViewNhaCungCap.CellContentClick += dataGridViewNhaCungCap_CellContentClick;
        }

        void btnXoa_Click(object sender, EventArgs e)
        {
            delete_NhaCungCap();
        }

        void dataGridViewNhaCungCap_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = e.RowIndex;
            if (index >= 0 && index < dataGridViewNhaCungCap.RowCount - 1)
            {
                txtMaNhaCungCap.Text = dataGridViewNhaCungCap.Rows[index].Cells[0].Value.ToString();
                txtTenNCC.Text = dataGridViewNhaCungCap.Rows[index].Cells[1].Value.ToString();
                txtSoDienThoai.Text = dataGridViewNhaCungCap.Rows[index].Cells[2].Value.ToString();
                txtEmail.Text = dataGridViewNhaCungCap.Rows[index].Cells[3].Value.ToString();
                txtDiaChi.Text = dataGridViewNhaCungCap.Rows[index].Cells[4].Value.ToString();
                txtGhiChu.Text = dataGridViewNhaCungCap.Rows[index].Cells[5].Value.ToString();
            }
        }

        void btnLuu_Click(object sender, EventArgs e)
        {
            if (chucNang == 0)
                return;
            if (chucNang == 1)
                insert_NhaCungCap();
            else
                update_NhaCungCap();
        }

        void btnSua_Click(object sender, EventArgs e)
        {
            chucNang = 2;
            UnLockAllControl();
        }

        void btnThem_Click(object sender, EventArgs e)
        {
            ClearAllControl();
            UnLockAllControl();
            chucNang = 1;
        }
        //============================================================================//
        public void load_dataGridViewNhaCungCap()
        {
            dataGridViewNhaCungCap.DataSource = ncc_bll.layDanhSachNhaCungCap();
        }

        public void ClearAllControl()
        {
            txtTenNCC.Clear();
            txtSoDienThoai.Clear();
            txtMaNhaCungCap.Clear();
            txtEmail.Clear();
            txtGhiChu.Clear();
            txtDiaChi.Clear();
        }

        public void LockAllControl()
        {
            txtDiaChi.ReadOnly = true;
            txtEmail.ReadOnly = true;
            txtGhiChu.ReadOnly = true;
            txtMaNhaCungCap.ReadOnly = true;
            txtSoDienThoai.ReadOnly = true;
            txtTenNCC.ReadOnly = true;
        }

        public void UnLockAllControl()
        {
            txtDiaChi.ReadOnly = false;
            txtEmail.ReadOnly = false;
            txtGhiChu.ReadOnly = false;
            txtMaNhaCungCap.ReadOnly = false;
            txtSoDienThoai.ReadOnly = false;
            txtTenNCC.ReadOnly = false;
        }

        public void insert_NhaCungCap()
        {
            bool ktraEmptyText = false;
            string strEmpty = "";

            if (txtTenNCC.Text.Trim().Length == 0)
            {
                strEmpty += "Tên nhà cung cấp, ";
                ktraEmptyText = true;
            }
            if (txtDiaChi.Text.Trim().Length == 0)
            {
                strEmpty += "địa chỉ, ";
                ktraEmptyText = true;
            }
            if (txtEmail.Text.Trim().Length == 0)
            {
                strEmpty += "email, ";
                ktraEmptyText = true;
            }
            if (txtSoDienThoai.Text.Trim().Length == 0)
            {
                strEmpty += "số điện thoại, ";
                ktraEmptyText = true;
            }

            if (txtMaNhaCungCap.Text.Trim().Length == 0)
                if (MessageBox.Show("Mã nhà cung cấp rỗng, bạn có muốn tạo ngẫu nhiên 1 mã không?",
                    "Tạo mã ngẫu nhiên", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                    txtMaNhaCungCap.Text = DateTime.Now.ToString("yyyy") + DateTime.Now.ToString("MM")
                        + DateTime.Now.ToString("dd") + "NCC" + DateTime.Now.ToString("HH") + DateTime.Now.ToString("ss");
                else
                {
                    txtMaNhaCungCap.Focus();
                    return;
                }
            else
            {
                if (ktraEmptyText)
                    if (MessageBox.Show(strEmpty + "không có giá trị, bạn có muốn thêm với dữ liệu rỗng không?", "Thông báo",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.No)
                        return;

                NhaCungCap ncc = new NhaCungCap();

                ncc.MaNhaCungCap = txtMaNhaCungCap.Text;
                ncc.TenNhaCungCap = txtTenNCC.Text;
                ncc.SDT = txtSoDienThoai.Text;
                ncc.Email = txtEmail.Text;
                ncc.DiaChi = txtDiaChi.Text;
                ncc.GhiChu = txtGhiChu.Text;

                if (ncc_bll.insert_NhaCungCap(ncc) == -1)
                    if (MessageBox.Show("Nhà cung cấp bạn muốn thêm đã có trong CSDL, bạn có muốn cập nhật nhà cung cấp này với dữ liệu mới không?", "Thông báo",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                        ncc_bll.update_NhaCungCap(ncc);
                    else
                        return;
                else
                    MessageBox.Show("Thêm nhà cung cấp thành công!");

                load_dataGridViewNhaCungCap();

                ClearAllControl();

                LockAllControl();

                chucNang = 0;
            }
        }

        public void update_NhaCungCap()
        {
            NhaCungCap ncc = new NhaCungCap();

            ncc.MaNhaCungCap = txtMaNhaCungCap.Text;
            ncc.TenNhaCungCap = txtTenNCC.Text;
            ncc.SDT = txtSoDienThoai.Text;
            ncc.Email = txtEmail.Text;
            ncc.DiaChi = txtDiaChi.Text;
            ncc.GhiChu = txtGhiChu.Text;

            if (ncc_bll.update_NhaCungCap(ncc) == 1)
                MessageBox.Show("Cập nhật nhà cung cấp thành công!");
            else
                if (MessageBox.Show("Nhà cung cấp bạn muốn sửa không có trong CSDL, bạn có muốn thêm mới nhà cung cấp này không?",
                    "Cập nhật không thành công!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                {
                    ncc.MaNhaCungCap = DateTime.Now.ToString("yyyy") + DateTime.Now.ToString("MM")
                        + DateTime.Now.ToString("dd") + "NCC" + DateTime.Now.ToString("HH") + DateTime.Now.ToString("ss");
                    ncc_bll.insert_NhaCungCap(ncc);
                }
            ClearAllControl();

            load_dataGridViewNhaCungCap();

            LockAllControl();

            chucNang = 0;
        }

        public void delete_NhaCungCap()
        {
            if (txtMaNhaCungCap.Text.Trim().Length != 0)
            {
                string maNCC = txtMaNhaCungCap.Text;

                if (MessageBox.Show("Bạn có muốn xóa nhà cung cấp " + maNCC + " không?", "Thông báo xóa",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.No)
                    return;
                if (ncc_bll.delete_NhaCungCap(maNCC) == -1)
                    MessageBox.Show("Không tìm thấy nhà cung cấp muốn xóa");
                else
                {
                    MessageBox.Show("Xóa nhà cung cấp thành công!");

                    load_dataGridViewNhaCungCap();
                }
            }
            else
            {
                if (dataGridViewNhaCungCap.SelectedRows != null)
                {
                    if (MessageBox.Show("Bạn có muốn xóa những nhà cung cấp đang được chọn không?", "Thông báo xóa",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.No)
                        return;
                    foreach (DataGridViewRow row in dataGridViewNhaCungCap.SelectedRows)
                    {
                        string maNCC = row.Cells[0].Value.ToString();

                        ncc_bll.delete_NhaCungCap(maNCC);
                    }

                    MessageBox.Show("Đã xóa nhà cung cấp thành công!");

                    load_dataGridViewNhaCungCap();
                }
            }
        }

        //============================================================================//
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

        private void txtTenNCC_MouseClick(object sender, MouseEventArgs e)
        {
            mouseclick(lbTenNCC, txtTenNCC, pnTenNCC);
        }

        private void txtMoTa_MouseClick(object sender, MouseEventArgs e)
        {
            mouseclick(lbTenNCC, txtTenNCC, pnTenNCC);
        }

        private void txtMaNhaCungCap_MouseClick(object sender, MouseEventArgs e)
        {
            mouseclick(lbMaNhaCungCap, txtMaNhaCungCap, pnMaNhaCungCap);
        }

        private void txtSoDienThoai_MouseClick(object sender, MouseEventArgs e)
        {
            mouseclick(lbSoDienThoai, txtSoDienThoai, pnSoDienThoai);
        }

        private void txtEmail_MouseClick(object sender, MouseEventArgs e)
        {
            mouseclick(lbEmail, txtEmail, pnEmail);
        }

        private void txtDiaChi_MouseClick(object sender, MouseEventArgs e)
        {
            mouseclick(lbDiaChi, txtDiaChi, pnDiaChi);
        }

        private void pnTenNCC_Leave(object sender, EventArgs e)
        {
            leave(lbTenNCC, txtTenNCC, pnTenNCC);
        }

        private void pnDiaChi_Leave(object sender, EventArgs e)
        {
            leave(lbDiaChi, txtDiaChi, pnDiaChi);
        }

        private void pnMaNhaCungCap_Leave(object sender, EventArgs e)
        {
            leave(lbMaNhaCungCap, txtMaNhaCungCap, pnMaNhaCungCap);
        }

        private void pnSoDienThoai_Leave(object sender, EventArgs e)
        {
            leave(lbSoDienThoai, txtSoDienThoai, pnSoDienThoai);
        }

        private void pnEmail_Leave(object sender, EventArgs e)
        {
            leave(lbEmail, txtEmail, pnEmail);
        }

        private void pnGhiChu_Leave(object sender, EventArgs e)
        {
            lbGhiChu.ForeColor = Color.FromArgb(255, 255, 255);
        }

        private void txtGhiChu_MouseClick(object sender, MouseEventArgs e)
        {
            lbGhiChu.ForeColor = Color.FromArgb(255, 128, 0);
        }

    }
}
