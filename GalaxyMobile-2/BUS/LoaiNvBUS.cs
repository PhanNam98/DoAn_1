using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using DAO;
namespace BUS
{
    public static class LoaiNvBUS
    {
        static public LoaiNvDAO db;
        static LoaiNvBUS()
        {
            db = new LoaiNvDAO();
        }
        public static List<LoaiNV> GetLNV()
        {
            return db.GetallLNV();
        }
        public static void ThemLNV(string ma, string ten)
        {
            db.ThemLNV(ma, ten);
        }
        public static void SuaLNV(string ma, string ten)
        {
            db.SuaLNV(ma, ten);
        }
        public static void XoaLNV(string ma)
        {
            db.XoaLNV(ma);
        }
        public static int KtMaLNV(string ma)
        {
            return db.ktLNV(ma);
        }
    }
}
