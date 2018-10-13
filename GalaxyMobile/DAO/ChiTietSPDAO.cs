using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
namespace DAO
{
    public class ChiTietSPDAO
    {
        public List<MauSP> GetAllMauSP()
        {
            using (GalaxyMobileEntities db = new GalaxyMobileEntities())
            {
                return db.MauSPs.ToList();
            }
        }
        public List<ChiTietSP> GetChiTietSPByIDSP(string id)
        {
            using (GalaxyMobileEntities db = new GalaxyMobileEntities())
            {
                return db.ChiTietSPs.Where(p=>p.MaSP==id).ToList();
            }
        }


    }

}
