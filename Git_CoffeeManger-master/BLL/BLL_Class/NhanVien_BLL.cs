using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.BLL_Class
{
    public class NhanVien_BLL
    {
        QLCuaHangDataContext db;

        public NhanVien_BLL()
        {
            db = new QLCuaHangDataContext();
        }

        public IQueryable layDanhSachNhanVien()
        {
            return db.NhanViens.Select(t => t);
        }

        public List<NhanVien> layDanhSachNhanVien_TheoMaLoai(string maloai)
        {
            return db.NhanViens.Where(t => t.LoaiNhanVien == maloai).ToList();
        }

        public List<NhanVien> layDanhSachNhanVien_TheoTrangThai(bool trangThai)
        {
            return db.NhanViens.Where(t => t.TinhTrang == trangThai).ToList<NhanVien>();
        }

        public NhanVien layNhanVien_TheoMaNhanVien(string maNhanVien)
        {
            return db.NhanViens.FirstOrDefault(t => t.MaNhanVien == maNhanVien);
        }

        public int insert_NhanVien(NhanVien nv)
        {
            NhanVien n = db.NhanViens.FirstOrDefault(t => t.MaNhanVien == nv.MaNhanVien);

            if (n != null)
                return -1;

            db.NhanViens.InsertOnSubmit(nv);

            db.SubmitChanges();

            return 1;
        }

        public void update_NhanVien(NhanVien nv)
        {
            NhanVien n = db.NhanViens.FirstOrDefault(t => t.MaNhanVien == nv.MaNhanVien);
            n.TenNhanVien = nv.TenNhanVien;
            n.SDT = nv.SDT;
            n.GioiTinh = nv.GioiTinh;
            n.NgaySinh = nv.NgaySinh;
            n.Email = nv.Email;
            n.CMND = nv.CMND;
            n.DiaChi = nv.DiaChi;
            n.NgayVaoLam = nv.NgayVaoLam;
            n.MatKhau = nv.MatKhau;
            n.TinhTrang = nv.TinhTrang;
            n.TongGioLam = nv.TongGioLam;
            n.Luong = nv.Luong;
            n.LoaiNhanVien = nv.LoaiNhanVien;
            db.SubmitChanges();
        }

        public void delete_NhanVien(string maNV)
        {
            NhanVien n = db.NhanViens.FirstOrDefault(t => t.MaNhanVien == maNV);

            db.NhanViens.DeleteOnSubmit(n);

            db.SubmitChanges();
        }

        
        public int check_NhanVienTonTai(string user, string pass)
        {
            int count_nhanvien = (from nv in db.NhanViens
                            where nv.MaNhanVien == user
                            && nv.MatKhau == pass
                            select nv).Count();
            return count_nhanvien;
        }

        public NhanVien phanQuyen(string user)
        {
            return db.NhanViens.SingleOrDefault(t => t.MaNhanVien == user);
        }

       

        public NhanVien setTenNhanVienTheoMa(string user)
        {
            var nhanvien = (from nv in db.NhanViens
                            where nv.MaNhanVien == user
                            select nv).SingleOrDefault();
            return nhanvien;
        }
    }
}
