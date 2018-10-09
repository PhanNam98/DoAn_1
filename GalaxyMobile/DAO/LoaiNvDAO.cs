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
                dbs.spInsertLNV(ma, ten);
            }
        }
        public void SuaLNV(string ma, string ten)
        {
            using (GalaxyMobileEntities dbs = new GalaxyMobileEntities())
            {
                dbs.spUpdateLNV(ma, ten);
            }
        }
        public void XoaLNV(string ma)
        {
            using (GalaxyMobileEntities dbs = new GalaxyMobileEntities())
            {
                dbs.spDelLNV(ma);
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
