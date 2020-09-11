using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.BLL_Class
{
    public class NhaCungCap_BLL
    {
        QLCuaHangDataContext db;
        public NhaCungCap_BLL()
        {
            db = new QLCuaHangDataContext();
        }

        public IQueryable layDanhSachNhaCungCap()
        {
            return db.NhaCungCaps.Select(t => t);
        }

        public NhaCungCap layNhaCungCap_TheoMaNhaCungCap(string maNCC)
        {
            return db.NhaCungCaps.FirstOrDefault(t => t.MaNhaCungCap == maNCC);
        }

        public int insert_NhaCungCap(NhaCungCap ncc)
        {
            NhaCungCap cc = db.NhaCungCaps.FirstOrDefault(t => t.MaNhaCungCap == ncc.MaNhaCungCap);

            if (cc != null)
                return -1;

            db.NhaCungCaps.InsertOnSubmit(ncc);

            db.SubmitChanges();

            return 1;
        }

        public int update_NhaCungCap(NhaCungCap ncc)
        {
            NhaCungCap cc = db.NhaCungCaps.FirstOrDefault(t => t.MaNhaCungCap == ncc.MaNhaCungCap);

            if (cc == null)
                return -1;

            cc.TenNhaCungCap = ncc.TenNhaCungCap;
            cc.SDT = ncc.SDT;
            cc.Email = ncc.Email;
            cc.DiaChi = ncc.DiaChi;
            cc.GhiChu = ncc.GhiChu;

            db.SubmitChanges();

            return 1;
        }

        public int delete_NhaCungCap(string maNCC)
        {
            NhaCungCap cc = db.NhaCungCaps.FirstOrDefault(t => t.MaNhaCungCap == maNCC);
            if (cc == null)
                return -1;

            db.NhaCungCaps.DeleteOnSubmit(cc);

            db.SubmitChanges();

            return 1;
        }
    }
}
