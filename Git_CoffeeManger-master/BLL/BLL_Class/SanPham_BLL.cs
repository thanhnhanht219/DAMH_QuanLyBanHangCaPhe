using Microsoft.SqlServer.Server;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.BLL_Class
{
    public class SanPham_BLL
    {
        QLCuaHangDataContext db;

        public SanPham_BLL()
        {
            db = new QLCuaHangDataContext();
        }

        public IQueryable layDanhSachSanPham()
        {
            return db.SanPhams.Select(t => t);
        }

        public List<SanPham> layDanhSachSanPhamList()
        {
            return db.SanPhams.Select(t => t).ToList();
        }

        public List<SanPham> layDanhSachSanPhamTheoNhom(string manhom)
        {
            return db.SanPhams.Where(t => t.Nhom == manhom).Select(t => t).ToList();
        }


        public List<SanPham> layDanhSachSanPham_TheoMaSanPham(string maSP)
        {
            return db.SanPhams.Where(t => t.MaSanPham == maSP).ToList();
        }

        public SanPham laySanPhamTheoMa(string maSP)
        {
            return db.SanPhams.SingleOrDefault(t => t.MaSanPham == maSP);
        }

        public List<SanPham> layDanhSachSanPhamTimKiemTheoTen(string tenSP)
        {
            return db.SanPhams.Where(t => t.TenSanPham.Contains(tenSP)).ToList();
        }


        public List<SanPham> layDanhSachSanPham_TheoTinhTrang(bool tinhTrang)
        {
            return db.SanPhams.Where(t => t.TinhTrang == tinhTrang).ToList();
        }

        public List<NhomSanPham> layDanhSachMaNhom()
        {
            return db.NhomSanPhams.Select(t => t).ToList();
        }

        public int insert_SanPham(SanPham sp)
        {
            if (sp != null)
            {
                db.SanPhams.InsertOnSubmit(sp);

                db.SubmitChanges();

                return 1;
            }

            return -1;

        }

        public void update_SanPham(SanPham sp)
        {
            SanPham s = db.SanPhams.FirstOrDefault(t => t.MaSanPham == sp.MaSanPham);

            s.TenSanPham = sp.TenSanPham;
            s.Gia = sp.Gia;
            s.Nhom = sp.Nhom;
            s.TinhTrang = sp.TinhTrang;
            s.MoTa = sp.MoTa;
            s.HinhAnh = sp.HinhAnh;

            db.SubmitChanges();
        }

        public void delete_SanPham(string maSP)
        {
            SanPham s = db.SanPhams.FirstOrDefault(t => t.MaSanPham == maSP);

            db.SanPhams.DeleteOnSubmit(s);

            db.SubmitChanges();
        }
    }
}
