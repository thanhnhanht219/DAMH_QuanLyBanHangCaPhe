using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.BLL_Class
{
    public class LoaiKhachHang_BLL
    {
        QLCuaHangDataContext db;

        public LoaiKhachHang_BLL()
        {
            db = new QLCuaHangDataContext();
        }

        public IQueryable layDanhSachLoaiKhachHang()
        {
            return db.LoaiKhachHangs.Select(t => t);
        }

        public LoaiKhachHang layLoaiKhachHang_TheoMaLoai(string maLoai)
        {
            return db.LoaiKhachHangs.FirstOrDefault(t => t.MaLoai == maLoai);
        }

        public LoaiKhachHang timLoaiKhachHang_TheoTenLoai(string tenLoai)
        {
            return db.LoaiKhachHangs.FirstOrDefault(t => t.TenLoai == tenLoai);
        }

        public LoaiKhachHang timLoaiKhachHang_TheoDiemTichLuy(int diemTichLuy)
        {
            return db.LoaiKhachHangs.FirstOrDefault(t => t.DiemTichLuy == diemTichLuy || t.DiemTichLuy < diemTichLuy);
        }
    }
}
