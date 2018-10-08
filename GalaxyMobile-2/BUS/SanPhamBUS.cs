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
    }
}
