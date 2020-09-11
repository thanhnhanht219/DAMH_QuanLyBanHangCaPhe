using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.BLL_Class
{
    public class LoaiNhanVien_BLL
    {
        QLCuaHangDataContext db;

        public LoaiNhanVien_BLL()
        {
            db = new QLCuaHangDataContext();
        }

        public IQueryable layDanhSachLoaiNhanVien()
        {
            return db.LoaiNhanViens.Select(t => t);
        }

        public LoaiNhanVien layLoaiNhanVien_TheoMaLoai(string maloai)
        {
            return db.LoaiNhanViens.FirstOrDefault(t => t.MaLoaiNV == maloai);
        }
    }
}
