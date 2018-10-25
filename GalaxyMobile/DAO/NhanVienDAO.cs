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
        public List<NhanVien> TimKiemNV(string id)
        {
            using (GalaxyMobileEntities db = new GalaxyMobileEntities())
            {
                return db.NhanViens.Where(p => p.MaNV.Contains(id) || p.TenNV.Contains(id) ||p.SDT.Contains(id)||p.DiaChi.Contains(id)).ToList();
            }
        }
        public List<NhanVien> GetallNVWithoutAdmin()
        {
            using (GalaxyMobileEntities dbs = new GalaxyMobileEntities())
            {
                return dbs.NhanViens.Where(p => p.MaLoaiNV != "admin").ToList();
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
        public List<NhanVien> GetNVShiper()
        {
            using (GalaxyMobileEntities dbs = new GalaxyMobileEntities())
            {
                return dbs.NhanViens.Where(p => p.MaLoaiNV =="shiper").ToList();
 
            }
        }
        public NhanVien Get1NV(string id)
        {
            using (GalaxyMobileEntities dbs = new GalaxyMobileEntities())
            {
                return dbs.NhanViens.Where(p => p.MaNV == id ).SingleOrDefault();

            }
        }
    }
}
