using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
namespace DAO
{
    public class DongSanPhamDAO
    {
        public List<DongSanPham> GetAllDongSP()
        {
            using (GalaxyMobileEntities db = new GalaxyMobileEntities())
            {
                return db.DongSanPhams.ToList();
            }
        }
    }
}
