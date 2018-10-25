using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
namespace DAO
{
    public class ChiTietHoaDonNhapDAO
    {
        public List<ChiTietHDNhapHang> GetChiTietHDNH(string id)
        {
            using (GalaxyMobileEntities dbs = new GalaxyMobileEntities())
            {
                return dbs.ChiTietHDNhapHangs.Where(p => p.MaHoaDonNH == id).ToList();
            }
        }
        public void ThemSPintoCTNH(ChiTietHDNhapHang obj)
        {
            using (GalaxyMobileEntities dbs = new GalaxyMobileEntities())
            {
                dbs.ChiTietHDNhapHangs.Add(obj);
                dbs.SaveChanges();
            }
        }
        public void XoaSPfromCTNH(string idhd,string idsp)
        {
            using (GalaxyMobileEntities dbs = new GalaxyMobileEntities())
            {
                var ct = dbs.ChiTietHDNhapHangs.Where(p => p.MaHoaDonNH == idhd && p.MaKieu == idsp).SingleOrDefault();
                dbs.ChiTietHDNhapHangs.Attach(ct);
                dbs.ChiTietHDNhapHangs.Remove(ct);
                dbs.SaveChanges();
            }
        }
        public ChiTietHDNhapHang  KiemTRaTonTaiSPinCTNH(string  id, string idsp)
        {
            using (GalaxyMobileEntities dbs = new GalaxyMobileEntities())
            {
                return dbs.ChiTietHDNhapHangs.Where(p => p.MaHoaDonNH == id && p.MaKieu == idsp).SingleOrDefault();
            }
        }
        public void ThayDoiSLNhap(ChiTietHDNhapHang obj)
        {
            using (GalaxyMobileEntities dbs = new GalaxyMobileEntities())
            {
                dbs.ChiTietHDNhapHangs.Attach(obj);
                dbs.Entry(obj).State = System.Data.Entity.EntityState.Modified;
                dbs.SaveChanges();
            }
        }
        public void LuuHoaDonNhap(string id)
        {
            using (GalaxyMobileEntities dbs = new GalaxyMobileEntities())
            {
                var p = (from u in dbs.ChiTietHDNhapHangs
                         where u.MaHoaDonNH == id
                         select u).ToList();
                foreach (var t in p)
                    dbs.USP_ThayDoiSoLuongChiTietSP(t.MaKieu, t.SoLuongNhap);

            }
        }
        public void XoaAll(string mahd)
        {
            using (GalaxyMobileEntities dbs = new GalaxyMobileEntities())
            {
                var p = (from u in dbs.ChiTietHDNhapHangs
                         where u.MaHoaDonNH == mahd
                         select u).ToList();
                foreach (var t in p)
                    XoaSPfromCTNH(mahd, t.MaKieu);
            }
        }
        public decimal TinhTien_ByMaHD(string mahd)
        {
            using (GalaxyMobileEntities dbs = new GalaxyMobileEntities())
            {
                decimal s = 0;
                var hd = dbs.ChiTietHDNhapHangs.Where(p => p.MaHoaDonNH == mahd).ToList();
                foreach (ChiTietHDNhapHang ct in hd)
                {
                    s += ct.SoLuongNhap * ct.GiaNSX;
                }
                return s;

            }
        }
    }
}
