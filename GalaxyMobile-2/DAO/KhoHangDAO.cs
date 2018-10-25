using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
namespace DAO
{
    public class KhoHangDAO
    {
        public List<KhoHang> GetAllKhoHang()
        {
            using (GalaxyMobileEntities db = new GalaxyMobileEntities())
            {
                return db.USP_GetAllKhoHang().ToList();
            }
        }
        public List<KhoHang> GetAllKhoHangByMaKieu(string id)
        {
            using (GalaxyMobileEntities db = new GalaxyMobileEntities())
            {
                return db.KhoHangs.Where(p => p.MaKieu == id).ToList();
            }
        }
        public void KiemTraKho_CuaHang_MaKieu(string idma,string idch)
        {
            using (GalaxyMobileEntities db = new GalaxyMobileEntities())
            {
                if(db.KhoHangs.Where(p=>p.MaCuaHang==idch && p.MaKieu==idma).Count()==0)
                {
                    KhoHang kh = new KhoHang();
                    kh.MaCuaHang = idch;
                    kh.MaKieu = idma;
                    kh.SoLuong = 0;
                    db.KhoHangs.Add(kh);
                    db.SaveChanges();
                }
            }
        }
        public void ThemSL_SP_Kho_ByCuaHangBy_MaKieu(string idhdnhap, string idch)
        {
            using (GalaxyMobileEntities db = new GalaxyMobileEntities())
            {
                List<ChiTietHDNhapHang> hdn = db.ChiTietHDNhapHangs.Where(p => p.MaHoaDonNH == idhdnhap).ToList();
               foreach(ChiTietHDNhapHang ct in hdn)
                {
                    db.USP_ThemSL_KhoHangByMaKieuByMaCH(ct.MaKieu, idch, ct.SoLuongNhap);
                }
            }
        }
    }
}
