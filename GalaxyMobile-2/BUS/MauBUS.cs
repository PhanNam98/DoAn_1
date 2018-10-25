using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using DAO;
namespace BUS
{
    public class MauBUS
    {
        static MauDAO db;
        static MauBUS()
        {
            db = new MauDAO();
        }
        public static void ThemMauSP(MauSP obj)
        {
            db.ThemMau(obj);
        }
        public static void XoaMauSP(MauSP obj)
        {
            db.XaoMau(obj);
        }
    }
}
