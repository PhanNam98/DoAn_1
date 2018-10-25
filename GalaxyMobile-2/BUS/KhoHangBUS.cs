using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAO;
using Model;
namespace BUS
{
    public static class KhoHangBUS
    {
        static KhoHangDAO db;
        static KhoHangBUS()
        {
            db = new KhoHangDAO();
        }
        public static List<KhoHang> GetAllKHoHang()
        {
            return db.GetAllKhoHang();
        }
        public static List<KhoHang> GetAllKhoHangByMaKieu(string id)
        {
            return db.GetAllKhoHangByMaKieu(id);
        }
        public static void KiemTraKho_CuaHang_MaKieu(string idma, string idch)
        {
            db.KiemTraKho_CuaHang_MaKieu(idma, idch);
        }
        public static void ThemSL_SP_Kho_ByCuaHangBy_MaKieu(string idhdnhap, string idch)
        {
            db.ThemSL_SP_Kho_ByCuaHangBy_MaKieu(idhdnhap, idch);
        }
    }
}
