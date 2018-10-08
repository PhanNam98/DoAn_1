using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAO;
using Model;
namespace BUS
{
    public static class KhoHangBUS
    {
        static KhoHangDAO db;
        static KhoHangBUS()
        {
            db = new KhoHangDAO();
        }
        public static List<KhoHang> GetAllKHoHang()
        {
            return db.GetAllKhoHang();
        }
    }
}
