using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
namespace DAO
{
    public class LoaiSPDAO
    {
        
        public List<LoaiSP>  GetLoaiSP()
        {
            using (GalaxyMobileEntities dbs = new GalaxyMobileEntities())
            {
                return dbs.LoaiSPs.ToList();
            }
        }
        public void ThemLSP(LoaiSP obj)
        {
            using (GalaxyMobileEntities dbs = new GalaxyMobileEntities())
            {
                dbs.LoaiSPs.Add(obj);
                dbs.SaveChanges();
            }

        }
        public void XoaLSP( LoaiSP obj)
        {
            using (GalaxyMobileEntities dbs = new GalaxyMobileEntities())
            {
                dbs.LoaiSPs.Attach(obj);
                dbs.LoaiSPs.Remove(obj);
                dbs.SaveChanges();
            }
        }
        public void ChinhSuaLSP(LoaiSP obj)
        {
            using (GalaxyMobileEntities dbs = new GalaxyMobileEntities())
            {
                dbs.LoaiSPs.Attach(obj);
                dbs.Entry(obj).State = System.Data.Entity.EntityState.Modified;
                dbs.SaveChanges();
            }
        }
    }
}
