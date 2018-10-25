using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace DAO
{
    public class HSXDAO
    {
        public List<HSX> GetAllHSX()
        {
            using (GalaxyMobileEntities dbs = new GalaxyMobileEntities())
            {
                return dbs.HSXes.ToList();
            }
        }
        public List<HSX> TimKiemHSX(string id)
        {
            using (GalaxyMobileEntities db = new GalaxyMobileEntities())
            {
                return db.HSXes.Where(p => p.MaHSX.Contains(id) || p.TenHSX.Contains(id)).ToList();
            }
        }
        public void ThemHSX(HSX hsx)
        {
            using (GalaxyMobileEntities dbs = new GalaxyMobileEntities())
            {
                 dbs.HSXes.Add(hsx);
                dbs.SaveChanges();
            }
        }
        public void XoaHSX(HSX hsx)
        {
            using (GalaxyMobileEntities dbs = new GalaxyMobileEntities())
            {
                dbs.HSXes.Attach(hsx);
                dbs.HSXes.Remove(hsx);
                dbs.SaveChanges();
            }
        }
        public void ChinhSua(HSX hsx)
        {
            using (GalaxyMobileEntities dbs = new GalaxyMobileEntities())
            {
                dbs.HSXes.Attach(hsx);
                dbs.SaveChanges();
                dbs.Entry(hsx).State = System.Data.Entity.EntityState.Modified;
                dbs.SaveChanges();
            }
        }

    }
}
