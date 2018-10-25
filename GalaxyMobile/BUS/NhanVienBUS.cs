using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAO;
using Model;
namespace BUS
{
    public static class NhanVienBUS
    {
        static NhanVienDAO db;
        static NhanVienBUS()
        {
            db = new NhanVienDAO();
        }
        public static List<NhanVien> TimKiemNV(string id)
        {
            return db.TimKiemNV(id);
        }
        public static List<NhanVien> GetNV()
        {
            return db.GetallNV();
        }
        public static void DelNhanVien(string ma)
        {
             db.DelNV(ma);
        }
        public static void InsertNV(string manv, string mach, string maloai, string tennv, string sex, string diachi, string sdt, decimal luong)
        {
            db.ThemNV(manv, mach, maloai, tennv, sex, diachi, sdt, luong);
        }
        public static void UpdateNV(string manv, string mach, string maloai, string tennv, string sex, string diachi, string sdt, decimal luong)
        {
            db.SuaNV(manv, mach, maloai, tennv, sex, diachi, sdt, luong);
        }
        public static int KtMaNV( string manv)
        {
            return db.KtNV(manv);
        }
        public static List<NhanVien> GetNVShiper()
        {
            return db.GetNVShiper();
        }
         public static NhanVien Get1NV(string id)
        {

            return db.Get1NV(id);
        }
        public static List<NhanVien> GetallNVWithoutAdmin()
        {
            return db.GetallNVWithoutAdmin();
        }
    }
}
