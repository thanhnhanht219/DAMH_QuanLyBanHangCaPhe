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
    
    public partial class frmHoaDonBanHang : Form
    {
        HoaDon_BLL hd = new HoaDon_BLL();
        public frmHoaDonBanHang()
        {
            InitializeComponent();
        }

        #region method
        public void setHeader()
        {
            dataGridViewHoaDon.Columns["KhachHang"].Visible = false;
            dataGridViewHoaDon.Columns["MaKhachHang"].Visible = false;
            dataGridViewHoaDon.Columns["NhanVien"].Visible = false;
           
        }
        #endregion

        private void frmHoaDonBanHang_Load(object sender, EventArgs e)
        {
            cboLoc.SelectedIndex = 0;
            dataGridViewHoaDon.DataSource = hd.getAllHoaDon();
            setHeader();
            string mahd = dataGridViewHoaDon.Rows[0].Cells["MaHoaDon"].FormattedValue.ToString();
            dataGridViewChiTietHoaDon.DataSource = hd.getChiTietHoaDonTheoMa(mahd);
            dataGridViewChiTietHoaDon.Columns["HoaDon"].Visible = false;
            dataGridViewChiTietHoaDon.Columns["SanPham"].Visible = false;
        }

        private void cboLoc_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cboLoc.SelectedIndex == 0)
            {
                dataGridViewHoaDon.DataSource = hd.getAllHoaDon();
                setHeader();
            }
            else if(cboLoc.SelectedIndex == 1)
            {
                dataGridViewHoaDon.DataSource = hd.getAllHoaDonTrongNgay();
                setHeader();
            }
            else if(cboLoc.SelectedIndex == 2)
            {
                dataGridViewHoaDon.DataSource = hd.getAllHoaDonTrong7Ngay();
                setHeader();
            }
            else
            {
                dataGridViewHoaDon.DataSource = hd.getAllHoaDonTrong30Ngay();
                setHeader();
            }
        }

        private void dataGridViewHoaDon_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridViewHoaDon_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dataGridViewHoaDon.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
                {
                    dataGridViewHoaDon.CurrentRow.Selected = true;
                    string mahd = dataGridViewHoaDon.Rows[e.RowIndex].Cells["MaHoaDon"].FormattedValue.ToString();
                    dataGridViewChiTietHoaDon.DataSource = hd.getChiTietHoaDonTheoMa(mahd);
                    dataGridViewChiTietHoaDon.Columns["HoaDon"].Visible = false;
                    dataGridViewChiTietHoaDon.Columns["SanPham"].Visible = false;
                }
            }
            catch
            {
                return;
            }
        }

        private void txtTimKiem_TextChanged(object sender, EventArgs e)
        {
            if (txtTimKiem.Text.Length == 0)
            {
                dataGridViewHoaDon.DataSource = hd.getAllHoaDon();
            }
            else
            {
                dataGridViewHoaDon.DataSource = hd.getTimKiemHoaDon(txtTimKiem.Text);
            }
        }
    }
}
