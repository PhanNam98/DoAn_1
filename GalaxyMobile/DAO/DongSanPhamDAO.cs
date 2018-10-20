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
        public List<DongSanPham> GetAllDongSPByMaHSX(string id)
        {
            using (GalaxyMobileEntities db = new GalaxyMobileEntities())
            {
                return db.DongSanPhams.Where(p=>p.MaHSX==id).ToList();
            }
        }
        public List<DongSanPham> GetAllDongSPByMaHSXAndMaLoai(string id,string idloai)
        {
            using (GalaxyMobileEntities db = new GalaxyMobileEntities())
            {
                return db.DongSanPhams.Where(p => p.MaHSX == id && p.MaLSP==idloai).ToList();
            }
        }
        public DongSanPham Get1DongSPByMaSP(string id)
        {
            using (GalaxyMobileEntities db = new GalaxyMobileEntities())
            {
                return db.DongSanPhams.Where(p => p.MaDSP == id).SingleOrDefault();
            }
        }
        public void XoaDSP(DongSanPham obj)
        {
            using (GalaxyMobileEntities db = new GalaxyMobileEntities())
            {

                db.DongSanPhams.Attach(obj);
                db.DongSanPhams.Remove(obj);
                db.SaveChanges();
            }
        }
        public void ThemDSP(DongSanPham obj)
        {
            using (GalaxyMobileEntities db = new GalaxyMobileEntities())
            {

                db.DongSanPhams.Add(obj);
                db.SaveChanges();
            }
        }
        public void ChinhSuaDSP(DongSanPham obj)
        {
            using (GalaxyMobileEntities db = new GalaxyMobileEntities())
            {

                db.DongSanPhams.Attach(obj);
                db.Entry(obj).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
            }
        }
    }
}
