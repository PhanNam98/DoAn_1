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
       
        static NSXDAO dbs;
        static HSXBUS()
        {
            dbs = new NSXDAO();
        }
        public static List<HSX> GetAllHSX()
        {
            return dbs.GetAllHSX();
        }
        public static HSX GetHSXByID(string id)
        {
            return dbs.getHSXbyID(id);
        }
        public static void ThemHSX( HSX obj)
        {
            dbs.ThemHSX(obj);

        }
        public static void XoaHSX(HSX obj)
        {
            dbs.XoaHSX(obj);
        }
        public static void ChinhSuaHXS(HSX obj)
        {
            dbs.ChinhSuaHSX(obj);
        }
    }
}
