using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
namespace DAO
{
    public class HoaDonDAO
    {
        public List<HoaDon> GetAllHoaDon()
        {
            using (GalaxyMobileEntities dbs = new GalaxyMobileEntities())
            {
                return dbs.HoaDons.ToList();
            }
        }
        public List<HoaDon> GetAllHoaDonByMaCH(string maCH)
        {
            using (GalaxyMobileEntities dbs = new GalaxyMobileEntities())
            {
                return dbs.HoaDons.Where(p=>p.MaCuaHang==maCH).ToList();
            }
        }
        public void ThemHD( HoaDon obj)
        {
            using (GalaxyMobileEntities db = new GalaxyMobileEntities())
            {
                db.HoaDons.Add(obj);
                db.SaveChanges();
            }
        }
        public void XoaHD(HoaDon obj)
        {
            using (GalaxyMobileEntities db = new GalaxyMobileEntities())
            {
                db.HoaDons.Attach(obj);
                db.HoaDons.Remove(obj);
                db.SaveChanges();
            }
        }
        public void ChinhSuaHD( HoaDon obj)
        {
            using (GalaxyMobileEntities db = new GalaxyMobileEntities())
            {
                db.HoaDons.Attach(obj);
                db.Entry(obj).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
            }
        }
        public List<USP_GetHDTheoThang_Result> GetHoaDonbyMonth(int month)
        {
            using (GalaxyMobileEntities db = new GalaxyMobileEntities())
            {
                return db.USP_GetHDTheoThang(month).ToList();
            }
        }
        
    }
}
