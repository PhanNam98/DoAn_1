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
        public SanPham GetSanPhamByID(string id)
        {
            using (GalaxyMobileEntities db = new GalaxyMobileEntities())
            {
                return db.SanPhams.Where(p=>p.MaSP==id).Single();
            }
        }
        public List<SanPham> GetSPByMaDSP(string id)
        {
            using (GalaxyMobileEntities db = new GalaxyMobileEntities())
            {
                return db.SanPhams.Where(p => p.MaDSP == id).ToList();
            }
        }
        public void ThemSP(SanPham obj)
        {
            using (GalaxyMobileEntities db = new GalaxyMobileEntities())
            {
                db.SanPhams.Add(obj);
                db.SaveChanges();
            }
        }
        public void XoaSP(SanPham obj)
        {
            using (GalaxyMobileEntities db = new GalaxyMobileEntities())
            {
                db.SanPhams.Attach(obj);
                db.SanPhams.Remove(obj);
                db.SaveChanges();
            }
        }
        public void ChinhSuaSP(SanPham obj)
        {
            using (GalaxyMobileEntities db = new GalaxyMobileEntities())
            {
                db.SanPhams.Attach(obj);
                db.Entry(obj).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
            }
        }
       
        
    }
}
