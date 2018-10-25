using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace DAO
{
    public class MauDAO
    {
        public void ThemMau(MauSP obj)
        {
            using (GalaxyMobileEntities db = new GalaxyMobileEntities())
            {
                db.MauSPs.Add(obj);
                db.SaveChanges();
            }
        }
        public void XaoMau(MauSP obj)
        {
            using (GalaxyMobileEntities db = new GalaxyMobileEntities())
            {
                db.MauSPs.Attach(obj);
                db.MauSPs.Remove(obj);
                db.SaveChanges();
            }
        }
    }
}
