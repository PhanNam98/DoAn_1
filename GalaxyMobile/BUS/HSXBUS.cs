using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using DAO;
namespace BUS
{
    public class HSXBUS
    {
        static HSXDAO db;
        static HSXBUS()
        {
            db = new HSXDAO();
        }
        public static List<HSX> GetAllHSX()
        {
            return db.GetAllHSX();
        }
        public static void ThemHSX(HSX hsx)
        {
            db.ThemHSX(hsx);
        }
        public static  void XoaHSX(HSX hsx)
        {
            db.XoaHSX(hsx);
        }
        public static void ChinhSua(HSX hsx)
        {
            db.ChinhSua(hsx);
        }
        public static  List<HSX> TimKiemHSX(string id)
        {
            return db.TimKiemHSX(id);
        }
    }
}
