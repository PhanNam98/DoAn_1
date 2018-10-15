using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
namespace DAO
{
    public class ChiTietHoaDonNhapDAO
    {
        public List<ChiTietHDNhapHang> GetChiTietHDNH(string id)
        {
            using (GalaxyMobileEntities dbs = new GalaxyMobileEntities())
            {
                return dbs.ChiTietHDNhapHangs.Where(p => p.MaHoaDonNH == id).ToList();
            }
        }
    }
}
