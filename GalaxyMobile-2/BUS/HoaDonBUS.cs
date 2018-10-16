using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using DAO;
namespace BUS
{
    public class HoaDonBUS
    {
        static HoaDonDAO db;
        static HoaDonBUS()
        {
            db = new HoaDonDAO();
        }
        public static List<HoaDon> GetAllHoaDon()
        {
            return db.GetAllHoaDon();
        }
        public static List<HoaDon> GetAllHoaDonByMaCH(string maCH)
        {
            return db.GetAllHoaDonByMaCH(maCH);
        }
    }
}
