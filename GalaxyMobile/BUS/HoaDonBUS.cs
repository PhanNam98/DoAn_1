using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using DAO;
namespace BUS
{
    public class HoaDonBUS
    {
        static HoaDonDAO db;
        static HoaDonBUS()
        {
            db = new HoaDonDAO();
        }
        public static List<HoaDon> GetAllHoaDon()
        {
            return db.GetAllHoaDon();
        }
        public static List<HoaDon> GetAllHoaDonByMaCH(string maCH)
        {
            return db.GetAllHoaDonByMaCH(maCH);
        }
        public static void ThemHoaDon(HoaDon hd)
        {
            db.ThemHoaDon(hd);
        }
        public static void XoaHoaDon(HoaDon hd)
        {
            db.XoaHoaDon(hd);
        }
        public static void ThanhToanHoaDon(string idhd, string idch)
        {
            db.ThanhToanHoaDon(idhd, idch);
        }
        public static void LayHangHoaDon(string idhd, string idch)
        {
            db.LayHangHoaDon(idhd, idch);

        }
        public static void TraHangHoaDon(string idhd, string idch)
        {
            db.TraHangHoaDon(idhd, idch);

        }
        public static void DaThanhToan(string idhd, string idch)
        {
            db.DaThanhToan(idhd, idch);
        }
        public static List<HoaDon> TimKiemHD(string id)
        {
            return db.TimKiemHD(id);
        }
        public static List<HoaDon> GetAllHoaDonByMaCH_Tg_DaThanhToan(string maCH, DateTime a, DateTime b)
        {
            return db.GetAllHoaDonByMaCH_Tg_DaThanhToan(maCH, a, b);
        }
        public static List<HoaDon> GetAllHoaDonByMaCH_DaThanhToan(string maCH)
        {
            return db.GetAllHoaDonByMaCH_DaThanhToan(maCH);
        }
        public static List<HoaDon> GetAllHoaDonByTg_DaThanhToan(string maCH, DateTime a, DateTime b)
        {
            return db.GetAllHoaDonByTg_DaThanhToan(maCH, a, b);
        }


        //Chua Thanh Toan Theo TG
        public static List<HoaDon> GetAllHoaDonByMaCH_Tg_ChuaThanhToan(string maCH, DateTime a, DateTime b)
        {
            return db.GetAllHoaDonByMaCH_Tg_ChuaThanhToan(maCH, a, b);
        }
        public static List<HoaDon> GetAllHoaDonByMaCH_ChuaThanhToan(string maCH)
        {
            return db.GetAllHoaDonByMaCH_ChuaThanhToan(maCH);
        }
        public static List<HoaDon> GetAllHoaDonByTg_ChuaThanhToan(string maCH, DateTime a, DateTime b)
        {
            return db.GetAllHoaDonByTg_ChuaThanhToan(maCH, a, b);
        }

        //Dang Giao Hang Theo TG
        public static List<HoaDon> GetAllHoaDonByMaCH_Tg_DangGiaoHang(string maCH, DateTime a, DateTime b)
        {
            return db.GetAllHoaDonByMaCH_Tg_DangGiaoHang(maCH, a, b);
        }
        public static List<HoaDon> GetAllHoaDonByMaCH_DangGiaoHang(string maCH)
        {
            return db.GetAllHoaDonByMaCH_DangGiaoHang(maCH);
        }
        public static List<HoaDon> GetAllHoaDonByTg_DangGiaoHang(string maCH, DateTime a, DateTime b)
        {
            return db.GetAllHoaDonByTg_DangGiaoHang(maCH, a, b);
        }

        //Toan Bo Theo TG
        public static  List<HoaDon> GetAllHoaDonByMaCH_Tg(string maCH, DateTime a, DateTime b)
        {
            return db.GetAllHoaDonByMaCH_Tg(maCH, a, b);
        }
        public static List<HoaDon> GetAllHoaDonByTg(DateTime a, DateTime b)
        {
            return db.GetAllHoaDonByTg(a,b);
        }
        public static List<InHoaDon_Result> InHD(string idhd, string idch)
        {
            return db.InHD(idhd, idch);
        }
        public static HoaDon Get1HD(string mahd, string mach)
        {
            return db.Get1HD(mahd, mach);
        }
    }
}
