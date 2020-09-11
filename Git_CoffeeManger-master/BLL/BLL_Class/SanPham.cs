using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL;
namespace BLL.BLL_Class
{
    public partial class SanPham
    {
        private string _TenNhom;

        public string TenNhom
        {
            get { return _TenNhom; }
            set { _TenNhom = value; }
        }

        

        public SanPham(SanPham sp, string tenloai)
        {
            this.MaSanPham = sp.MaSanPham;
            this.TenSanPham= sp.TenSanPham;
            this.TinhTrang = sp.TinhTrang;
            this.TenNhom = tenloai;
            this.HinhAnh = sp.HinhAnh;
            this.Gia = sp.Gia;
            this.Nhom = sp.Nhom;
        }
    }
}
