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
    }
}
