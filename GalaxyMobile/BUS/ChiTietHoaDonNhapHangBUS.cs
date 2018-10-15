using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using DAO;
namespace BUS
{
    public class ChiTietHoaDonNhapHangBUS
    {
        static ChiTietHoaDonNhapDAO db;
        static ChiTietHoaDonNhapHangBUS()
        {
            db = new ChiTietHoaDonNhapDAO();
        }
        public static List<ChiTietHDNhapHang> GetAllSanPham(string id)
        {
            return db.GetChiTietHDNH(id);
        }
    }
}
