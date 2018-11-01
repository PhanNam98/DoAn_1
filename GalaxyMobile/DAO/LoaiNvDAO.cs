using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
namespace DAO
{
    public class LoaiNvDAO
    {
        public List<LoaiNV> GetallLNV()
        {
            using (GalaxyMobileEntities dbs = new GalaxyMobileEntities())
            {
                return dbs.GetLNV().ToList();
            }
        }
        public void ThemLNV(string ma, string ten)
        {
            using (GalaxyMobileEntities dbs = new GalaxyMobileEntities())
            {
                //dbs.spInsertLNV(ma, ten);
                LoaiNV l = new LoaiNV();
                l.MaLoaiNV = ma;
                l.TenLoaiNV = ten;
                dbs.LoaiNVs.Add(l);
                dbs.SaveChanges();
            }
        }
        public void SuaLNV(string ma, string ten)
        {
            using (GalaxyMobileEntities dbs = new GalaxyMobileEntities())
            {
                //dbs.spUpdateLNV(ma, ten);
                LoaiNV l = new LoaiNV();
                l.MaLoaiNV = ma;
                l.TenLoaiNV = ten;
                dbs.LoaiNVs.Attach(l);
                dbs.Entry(l).State = System.Data.Entity.EntityState.Modified;
                dbs.SaveChanges();
            }
        }
        public void XoaLNV(string ma)
        {
            using (GalaxyMobileEntities dbs = new GalaxyMobileEntities())
            {
                var l = dbs.LoaiNVs.Where(p => p.MaLoaiNV == ma).SingleOrDefault();
                dbs.LoaiNVs.Attach(l);
                dbs.LoaiNVs.Remove(l);
                dbs.SaveChanges();
                // dbs.spDelLNV(ma);
            }
        }
        public int ktLNV(string ma)
        {
            using (GalaxyMobileEntities dbs = new GalaxyMobileEntities())
            {
                var nv = dbs.LoaiNVs.Where(p => p.MaLoaiNV == ma).Count();
                return nv;
            }
        }
    }
}
