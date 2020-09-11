using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BLL;
using BLL.BLL_Class;

namespace DLL
{
    public partial class usChiTietSanPham : UserControl
    {
        #region properties
        public int soLuong;
        public float tongTien, donGia;
        #endregion

        public usChiTietSanPham()
        {
            InitializeComponent();
            tongTien = 0;
            soLuong = 1;
            
        }

        public void setValue(string masp)
        {
            SanPham_BLL qlsp = new SanPham_BLL();
            SanPham sp = qlsp.laySanPhamTheoMa(masp);
            lbTenSanPham.Text = sp.TenSanPham;
            soLuong = (int)btnTangGiam.Value;
            donGia = (float)sp.Gia;
            tongTien =  donGia * soLuong;
            lbTongTien.Text = tongTien.ToString();
        }

        public void capnhapTongTien(int sl)
        {
            tongTien = donGia * sl;
            this.lbTongTien.Text = ConvertValue.convertValueMoney(tongTien); ;
        }

        

    }
}
