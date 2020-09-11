using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.BLL_Class
{
    public class HoaDon_BLL
    {
        QLCuaHangDataContext db;

        public HoaDon_BLL()
        {
            db = new QLCuaHangDataContext();
        }
        public int demSoLuongHD()
        {
            return db.HoaDons.Select(t => t).Count();
        }

        public bool ktKhoaChinhHD(string maHD)
        {
            return db.HoaDons.SingleOrDefault(t => t.MaHoaDon == maHD) == null ? true : false;

        }


        public string setMaHD()
        {
            string maHD;

            string year = DateTime.Now.Year.ToString();
            string month = DateTime.Now.Month.ToString();
            string day = DateTime.Now.Day.ToString();

            string random = new Random().Next(1, 1000).ToString();

            maHD = year + month + day  +"HD"+  random;
            while (!ktKhoaChinhHD(maHD))
            {
                maHD = setMaHD();
            }
            return maHD;
        }

        public void insert_HoaDon(List<ChiTietHoaDon> lstCT, string maHD, string maNV, string maKH, double TongCong)
        {
                string date = DateTime.Now.ToShortDateString();
                HoaDon newHD = new HoaDon();
                newHD.MaHoaDon = maHD;
                newHD.MaNhanVien = maNV;
                newHD.MaKhachHang = maKH;
                newHD.NgayBan = Convert.ToDateTime(date);
                newHD.TongTien = (decimal?)TongCong;
                db.HoaDons.InsertOnSubmit(newHD);
                db.SubmitChanges();
                foreach (ChiTietHoaDon item in lstCT)
                {
                    item.MaHoaDon = maHD;
                    db .ChiTietHoaDons.InsertOnSubmit(item);
                }
                db.SubmitChanges();
        }

        public IQueryable getAllHoaDon()
        {
            return db.HoaDons.Select(t => t);
        }

        public IQueryable getTimKiemHoaDon(string txt)
        {
            return db.HoaDons.Where(t=> t.MaHoaDon.Contains(txt)).Select(t=>t);
        }

        public IQueryable getAllHoaDonTrongNgay()
        {
            string date = DateTime.Now.ToShortDateString();
            return db.HoaDons.Where(t => t.NgayBan == Convert.ToDateTime(date)).Select(t => t);
        }

        public IQueryable getAllHoaDonTrong7Ngay()
        {
            string date = DateTime.Now.ToShortDateString();
            string date7 = DateTime.Now.AddDays(-7).ToShortDateString();
            return db.HoaDons.Where(t => t.NgayBan <= Convert.ToDateTime(date) || t.NgayBan >= Convert.ToDateTime(date7)).Select(t => t);
        }


        public IQueryable getAllHoaDonTrong30Ngay()
        {
            string date = DateTime.Now.ToShortDateString();
            string date30 = DateTime.Now.AddDays(-30).ToShortDateString();
            return db.HoaDons.Where(t => t.NgayBan <= Convert.ToDateTime(date) || t.NgayBan >= Convert.ToDateTime(date30)).Select(t => t);
        }

        public IQueryable getChiTietHoaDonTheoMa(string ma)
        {
            return db.ChiTietHoaDons.Where(t=>t.MaHoaDon == ma).Select(t => t);
        }
    }
}
