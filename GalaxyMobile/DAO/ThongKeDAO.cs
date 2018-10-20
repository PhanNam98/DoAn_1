using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
namespace DAO
{
    public class ThongKeDAO
    {
        public List<spSPBanDuoc_Result> GetAll(string cuahang)
        {
            using (GalaxyMobileEntities dbs = new GalaxyMobileEntities())
            {
                return dbs.spSPBanDuoc(cuahang).ToList();
            }
        }
    }
}
