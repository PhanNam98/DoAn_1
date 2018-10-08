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

    }
}
