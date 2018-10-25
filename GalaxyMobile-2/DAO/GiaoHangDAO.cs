using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
namespace DAO
{
    public class GiaoHangDAO
    {
        public void ThemGiaoHang(GiaoHang gh)
        {
            using (GalaxyMobileEntities dbs = new GalaxyMobileEntities())
            {
                dbs.GiaoHangs.Add(gh);
                dbs.SaveChanges();
            }
        }
        public void DaGiaoHangGiaoHang(GiaoHang gh)
        {
            using (GalaxyMobileEntities dbs = new GalaxyMobileEntities())
            {
                dbs.GiaoHangs.Attach(gh);
                dbs.Entry(gh).State = System.Data.Entity.EntityState.Modified;
                dbs.SaveChanges();
            }
        }
        public GiaoHang GetGiaoHangByMaHD_MaCH(string mahd,string mach)
        {
            using (GalaxyMobileEntities dbs = new GalaxyMobileEntities())
            {
                return dbs.GiaoHangs.Where(p => p.MaCuaHang == mach && p.MaHoaDon == mahd).SingleOrDefault();
            }
        }
        public bool KiemTraGiaoHang(string mahd,string mach)
        {
            using (GalaxyMobileEntities dbs = new GalaxyMobileEntities())
            {
                return dbs.GiaoHangs.Where(p => p.MaCuaHang == mach && p.MaHoaDon == mahd).Count() > 0 ? true : false; 
            }
        }
        public void HuyGiaoHang(string mahd,string mach)
        {
            using (GalaxyMobileEntities dbs = new GalaxyMobileEntities())
            {
                var gh = dbs.GiaoHangs.Where(p => p.MaCuaHang == mach && p.MaHoaDon == mahd).SingleOrDefault();
                dbs.GiaoHangs.Attach(gh);
                dbs.GiaoHangs.Remove(gh);
                dbs.SaveChanges();
            }
        }
    }
}
