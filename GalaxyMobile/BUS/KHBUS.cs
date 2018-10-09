using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAO;
using Model;
namespace BUS
{
    public static class KHBUS
    {
        static KHDAO db;
        static KHBUS()
        {
            db = new KHDAO();
        }
        public static List<KhachHang> GetKH()
        {
            return db.GetAllKH();
        }
        public static void DelKH(string ma)
        {
            db.DelKH(ma);
        }
        public static void ThemKH(string ma, string tenkh, string diachi, string sdt)
        {
            db.AddKH(ma, tenkh, diachi, sdt);
        }
        public static void SuaKH(string ma, string tenkh, string diachi, string sdt)
        {
            db.UpdateKH(ma, tenkh, diachi, sdt);
        }
        public static int ktMaKH(string ma)
        {
            return db.KtKH(ma);
        }
    }
}
