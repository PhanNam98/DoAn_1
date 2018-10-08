using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
namespace DAO
{
    public class HoaDonDAO
    {
        public List<HoaDon> GetAllHoaDon()
        {
            using (GalaxyMobileEntities dbs = new GalaxyMobileEntities())
            {
                return dbs.HoaDons.ToList();
            }
        }
        public List<HoaDon> GetAllHoaDonByMaCH(string maCH)
        {
            using (GalaxyMobileEntities dbs = new GalaxyMobileEntities())
            {
                return dbs.HoaDons.Where(p=>p.MaCuaHang==maCH).ToList();
            }
        }
        
    }
}
