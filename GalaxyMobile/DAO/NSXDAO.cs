using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
namespace DAO
{
    public class NSXDAO
    {
        public List<HSX> GetAllHSX()
        {
            using (GalaxyMobileEntities db = new GalaxyMobileEntities())
            {
                return db.HSXes.ToList();
            }
        }
        public HSX getHSXbyID(string id)
        {
            using (GalaxyMobileEntities db = new GalaxyMobileEntities())
            {
                return db.HSXes.Where(h => h.MaHSX == id).SingleOrDefault();
            }
        }
        public void ThemHSX(HSX obj)
        {
            using (GalaxyMobileEntities db = new GalaxyMobileEntities())
            {
                db.HSXes.Add(obj);
                db.SaveChanges();
               
            }
        }
        public void XoaHSX(HSX obj)
        {
            using (GalaxyMobileEntities db = new GalaxyMobileEntities())
            {
                db.HSXes.Attach(obj);
                db.HSXes.Remove(obj);
                db.SaveChanges();
               
            }
        }
        public void ChinhSuaHSX(HSX obj)
        {
            using (GalaxyMobileEntities db = new GalaxyMobileEntities())
            {
                db.HSXes.Attach(obj);
                db.Entry(obj).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
            }
        }
    }
}
