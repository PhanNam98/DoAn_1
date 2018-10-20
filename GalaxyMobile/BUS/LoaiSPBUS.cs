using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using DAO;
namespace BUS
{
    public class LoaiSPBUS
    {
        static LoaiSPDAO db;
        static LoaiSPBUS()
        {
            db = new LoaiSPDAO();
        }
        public static List<LoaiSP> GetAllLoaiSP()
        {
            return db.GetLoaiSP();
        }
        public static void ThemLSP( LoaiSP obj)
        {
            db.ThemLSP(obj);
        }
        public static void XoaLSP(LoaiSP obj)
        {
            db.XoaLSP(obj);
        }
        public static void SuaLSP(LoaiSP obj)
        {
            db.ChinhSuaLSP(obj);
        }
    }
}
