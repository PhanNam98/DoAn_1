using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
 
namespace DAO
{
    public class LoaiTaiKhoanDAO
    {
        public  List<LoaiTaiKhoan> GetAllLoaiTK()
        {
            using (GalaxyMobileEntities db = new GalaxyMobileEntities())
            {
                return db.LoaiTaiKhoans.ToList();
            }
        }
    }
}
