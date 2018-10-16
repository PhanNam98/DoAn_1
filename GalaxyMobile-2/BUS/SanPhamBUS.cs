using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using DAO;
namespace BUS
{
    public static class SanPhamBUS
    {
        static SanPhamDAO db;
        static SanPhamBUS()
        {
            db = new SanPhamDAO();
        }
        public static List<SanPham> GetAllSanPham()
        {
            return db.GetAllSanPham();
        }
        public static SanPham GetSanPhamByID(string id)
        {
            return db.GetSanPhamByID(id);
        }
        public static List<SanPham> GetSanPhamByMaDSP(string id)
        {
            return db.GetSPByMaDSP(id);
        }
        public static void ThemSP(SanPham obj)
        {
            db.ThemSP(obj);
        }
        public static void XoaSP(SanPham obj)
        {
            db.XoaSP(obj);
        }
        public static void ChinhSuaSP(SanPham obj)
        {
            db.ChinhSuaSP(obj);
        }
    }
}
