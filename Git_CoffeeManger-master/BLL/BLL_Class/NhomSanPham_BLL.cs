using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.BLL_Class
{
    public class NhomSanPham_BLL
    {
        QLCuaHangDataContext db;

        public NhomSanPham_BLL()
        {
            db = new QLCuaHangDataContext();
        }

        public IQueryable layDanhSachNhomSanPham()
        {
            return db.NhomSanPhams.Select(t => t);
        }

        public NhomSanPham layNhomSanPham_TheoMaNhomSanPham(string maNhomSP)
        {
            return db.NhomSanPhams.FirstOrDefault(t => t.MaNhomSP == maNhomSP);
        }
    }
}
