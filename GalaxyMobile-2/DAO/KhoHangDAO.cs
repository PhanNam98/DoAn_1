using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
namespace DAO
{
    public class KhoHangDAO
    {
        public List<KhoHang> GetAllKhoHang()
        {
            using (GalaxyMobileEntities db = new GalaxyMobileEntities())
            {
                return db.USP_GetAllKhoHang().ToList();
            }
        }
    }
}
