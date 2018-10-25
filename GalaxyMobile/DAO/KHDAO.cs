using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
namespace DAO
{
    public class KHDAO
    {
        public List<KhachHang> GetAllKH()
        {
            using (GalaxyMobileEntities dbs = new GalaxyMobileEntities())
            {
                return dbs.spGetKH().ToList();
            }
        }
        public void DelKH(string ma)
        {
            using (GalaxyMobileEntities dbs = new GalaxyMobileEntities())
                dbs.spDelKH(ma);
        }
        public void AddKH(string ma,string tenkh, string diachi, string sdt)
        {
            using (GalaxyMobileEntities dbs = new GalaxyMobileEntities())
            {
                dbs.spInsertKH(ma, tenkh, diachi, sdt);
            }
        }
        public void UpdateKH(string ma, string tenkh, string diachi, string sdt)
        {
            using (GalaxyMobileEntities dbs = new GalaxyMobileEntities())
            {
                dbs.spUpdateKH(ma, tenkh, diachi, sdt);
            }
        }
        public int KtKH(string makh)
        {
            using (GalaxyMobileEntities dbs = new GalaxyMobileEntities())
            {
                var nv = dbs.KhachHangs.Where(p => p.MaKH == makh).Count();
                return nv;
            }
        }
        public KhachHang GetKHByMAKH(string makh)
        {
            using (GalaxyMobileEntities dbs = new GalaxyMobileEntities())
            {
               return dbs.KhachHangs.Where(p => p.MaKH == makh).SingleOrDefault();
              
            }
        }
        public List<KhachHang> TimKiemKhachHang(string id)
        {
            using (GalaxyMobileEntities db = new GalaxyMobileEntities())
            {
                return db.KhachHangs.Where(p => p.MaKH.Contains(id) || p.TenKH.Contains(id) || p.DiaChi.Contains(id)).ToList();
            }
        }

    }
}
