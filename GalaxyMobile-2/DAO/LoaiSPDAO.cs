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
    }
}
