using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using DAO;
namespace BUS
{
    public  class GiaoHangBUS
    {
        static GiaoHangDAO db;
        static GiaoHangBUS()
        {
            db = new GiaoHangDAO();
        }
        public static void ThemGiaoHang(GiaoHang gh)
        {
            db.ThemGiaoHang(gh);
        }
        public static GiaoHang GetGiaoHangByMaHD_MaCH(string mahd, string mach)
        {
            return db.GetGiaoHangByMaHD_MaCH(mahd, mach);
        }
        public  static void DaGiaoHangGiaoHang(GiaoHang gh)
        {
            db.DaGiaoHangGiaoHang(gh);
        }
        public static bool KiemTraGiaoHang(string mahd,string mach)
        {
          return  db.KiemTraGiaoHang(mahd,mach);
        }
        public static void HuyGiaoHang(string mahd, string mach)
        {
            db.HuyGiaoHang(mahd, mach);
        }
    }
}
