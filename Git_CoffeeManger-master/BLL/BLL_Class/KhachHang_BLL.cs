using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.BLL_Class
{
    public class KhachHang_BLL
    {
        QLCuaHangDataContext db;

        public KhachHang_BLL()
        {
            db = new QLCuaHangDataContext();
        }

        public KhachHang loadGridViewTimKiemPOSKhachHang(string txtTimKiem)
        {
            var khachhang = (from kh in db.KhachHangs
                             where kh.MaKhachHang.Contains(txtTimKiem) ||
                             kh.TenKhachHang.Contains(txtTimKiem) ||
                             kh.SDT.Contains(txtTimKiem) ||
                             kh.CMND.Contains(txtTimKiem) ||
                             kh.Email.Contains(txtTimKiem)
                             select kh).FirstOrDefault();
            return khachhang;

 
        }
        public IQueryable layDanhSachKhachHang()
        {
            return db.KhachHangs.Select(t => t);
        }

        public List<KhachHang> layDanhSachKhachHang_TheoMaLoai(string maloai)
        {
            return db.KhachHangs.Where(t => t.LoaiKhachHang == maloai).ToList();
        }

        public KhachHang layKhachHang_TheoMaKhachHang(string maKhachHang)
        {
            return db.KhachHangs.FirstOrDefault(t => t.MaKhachHang == maKhachHang);
        }

        public int insert_KhachHang(KhachHang k)
        {
            KhachHang kh = db.KhachHangs.FirstOrDefault(t => t.MaKhachHang == k.MaKhachHang);

            if (kh != null)
                return -1;

            db.KhachHangs.InsertOnSubmit(k);

            db.SubmitChanges();

            return 1;
        }

        public void update_KhachHang(KhachHang k)
        {
            KhachHang kh = db.KhachHangs.FirstOrDefault(t => t.MaKhachHang == k.MaKhachHang);
            kh.TenKhachHang = k.TenKhachHang;
            kh.SDT = k.SDT;
            kh.GioiTinh = k.GioiTinh;
            kh.Email = k.Email;
            kh.CMND = k.CMND;
            kh.DiaChi = k.DiaChi;
            kh.LoaiKhachHang = k.LoaiKhachHang;
            kh.Diem = k.Diem;
            db.SubmitChanges();
        }

        public void delete_KhachHang(string maKH)
        {
            KhachHang kh = db.KhachHangs.FirstOrDefault(t => t.MaKhachHang == maKH);

            db.KhachHangs.DeleteOnSubmit(kh);

            db.SubmitChanges();
        }
    }
}
