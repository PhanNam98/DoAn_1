using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
namespace DAO
{
    public class CuaHangDAO
    {
        public List<CuaHang> GetAllCuaHang()
        {
            using (GalaxyMobileEntities db = new GalaxyMobileEntities())
            {
                return db.USP_GetAllCuaHang().ToList();
            }
        }
        public KhoHang GetMaKieuByMaCH(string id,string makieu)
        {
            using (GalaxyMobileEntities db = new GalaxyMobileEntities())
            {
                return db.KhoHangs.Where(p => p.MaCuaHang == id && p.MaKieu==makieu ).SingleOrDefault();
            }
        }
        public CuaHang GetThongTinCuaHang(string mach)
        {
            using (GalaxyMobileEntities db = new GalaxyMobileEntities())
            {
                return db.CuaHangs.Where(p => p.MaCuaHang == mach).SingleOrDefault();
            }
        }
    }
}
