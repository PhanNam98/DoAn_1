using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using DAO;
namespace BUS
{
    public class HoaDonNhapHangBUS
    {
        static HoaDonNhapDAO db;
        static HoaDonNhapHangBUS()
        {
            db = new HoaDonNhapDAO();
        }
        public static HoaDonNhapHang GetGetHoaDonNhapByID(string id)
        {
            return db.GetHoaDonNhap(id);
        }
        public static List<HoaDonNhapHang> GetAllHoaDonNhap()
        {
            return db.GetAllHoaDonNhap();
        }
        public static void ThemHDNhap(HoaDonNhapHang obj)
        {
            db.ThemHDNhap(obj);
        }
        public static void XoaHDNhap(HoaDonNhapHang obj)
        {
            db.XoaHDNhap(obj);
        }
    }
}
