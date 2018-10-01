using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
namespace DAO
{
    public class SanPhamDAO
    {
        public List<SanPham> GetAllSanPham()
        {
            using (GalaxyMobileEntities db = new GalaxyMobileEntities())
            {
                return db.SanPhams.ToList();
            }
        }
    }
}
