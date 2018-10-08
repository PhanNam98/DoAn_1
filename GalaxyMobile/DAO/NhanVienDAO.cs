using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
namespace DAO
{
    public class NhanVienDAO
    {
        public List<NhanVien> GetallNV()
        {
            using (GalaxyMobileEntities dbs = new GalaxyMobileEntities())
            {
                return dbs.NhanViens.ToList();
            }
        }
        public void DelNV(string ma)
        {
            using (GalaxyMobileEntities dbs = new GalaxyMobileEntities())
                dbs.delNV(ma);
        }
        public void ThemNV(string manv, string mach, string maloai, string tennv, string sex, string diachi, string sdt, decimal luong)
        {
            using (GalaxyMobileEntities dbs = new GalaxyMobileEntities())
                dbs.spThemNV(manv, mach, maloai, tennv, sex, diachi, sdt, luong);
        }
        public void SuaNV(string manv, string mach, string maloai, string tennv, string sex, string diachi, string sdt, decimal luong)
        {
            using (GalaxyMobileEntities dbs = new GalaxyMobileEntities())
                dbs.updateNV(manv, mach, maloai, tennv, sex, diachi, sdt, luong);
        }
        public int KtNV(string manv)
        {
            using (GalaxyMobileEntities dbs = new GalaxyMobileEntities())
            {
                var nv = dbs.NhanViens.Where(p => p.MaNV == manv).Count();
                return nv;
            }
        }
    }
}
