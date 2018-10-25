using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using DAO;
namespace BUS
{
    public class ChiTietHoaDonBUS
    {
        static ChiTietHoaDonDAO db;
        static ChiTietHoaDonBUS()
        {
            db = new ChiTietHoaDonDAO();
        }
        public static List<ChiTietHoaDon> GetChieTietHD_ByMaHD(string mahd, string mach)
        {
            return db.GetChieTietHD_ByMaHD(mahd, mach);
        }
        public static decimal TinhTien_ByMaHD(string mahd, string mach)
        {
            return db.TinhTien_ByMaHD(mahd, mach);
        }
        public static void ThemChiTietHoaDon(ChiTietHoaDon ct)
        {
            db.ThemChiTietHoaDon(ct);
        }
        public static bool KiemTraTonTaiChiTietHoaDon(ChiTietHoaDon ct)
        {
          return  db.KiemTraTonTaiChiTietHoaDon(ct);
        }
        public static void thayDoiSLChiTietHoaDon(string idhd, string idch, string id, int sl)
        {
            db.ThayDoiSLChiTietHoaDon(idhd, idch, id, sl);
        }
        public static void XoaChiTietHoaDon(string idhd, string idch, string id)
        {
            db.XoaChiTietHoaDon(idhd, idch, id);
        }
    }
}
