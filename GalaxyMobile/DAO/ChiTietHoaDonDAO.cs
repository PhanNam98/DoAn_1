using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
namespace DAO
{
    public class ChiTietHoaDonDAO
    {
        public List<ChiTietHoaDon> GetChieTietHD_ByMaHD(string mahd,string mach)
        {
            using (GalaxyMobileEntities dbs = new GalaxyMobileEntities())
            {
                return dbs.ChiTietHoaDons.Where(p => p.MaHoaDon == mahd && p.MaCuaHang == mach).ToList();


            }
        }
        public decimal TinhTien_ByMaHD(string mahd, string mach)
        {
            using (GalaxyMobileEntities dbs = new GalaxyMobileEntities())
            {
                decimal s = 0;
                var hd= dbs.ChiTietHoaDons.Where(p => p.MaHoaDon == mahd && p.MaCuaHang == mach).ToList();
                foreach(ChiTietHoaDon ct in hd)
                {
                    s += ct.SoluongSP * ct.GiaSP;
                }
                return s;

            }
        }
        public void ThemChiTietHoaDon(ChiTietHoaDon ct)
        {
            using (GalaxyMobileEntities dbs = new GalaxyMobileEntities())
            {
                dbs.ChiTietHoaDons.Add(ct);
                dbs.SaveChanges();

            }
        }
        public bool KiemTraTonTaiChiTietHoaDon(ChiTietHoaDon ct)
        {
            using (GalaxyMobileEntities dbs = new GalaxyMobileEntities())
            {
               return dbs.ChiTietHoaDons.Where(p => p.MaCuaHang == ct.MaCuaHang && p.MaHoaDon == ct.MaHoaDon && p.MaKieu == ct.MaKieu).Count() >0? false : true ;
                

            }
        }
        public void ThayDoiSLChiTietHoaDon(string idhd,string idch,string id,int sl)
        {
            using (GalaxyMobileEntities dbs = new GalaxyMobileEntities())
            {
                dbs.USP_ThayDoiSLChiTietHoaDon(idhd, idch, id, sl);

            }
        }
        public void XoaChiTietHoaDon(string idhd,string idch,string id)
        {
            using (GalaxyMobileEntities dbs = new GalaxyMobileEntities())
            {
                var ct = dbs.ChiTietHoaDons.Where(p => p.MaCuaHang == idch && p.MaHoaDon == idhd && p.MaKieu == id).SingleOrDefault();
                dbs.ChiTietHoaDons.Attach(ct);
                dbs.ChiTietHoaDons.Remove(ct);
                dbs.SaveChanges();
                    

            }
        }
    }
}
