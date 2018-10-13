using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAO;
using Model;
namespace BUS
{
    public class ChiTietSPBUS
    {
        static ChiTietSPDAO db;
        static ChiTietSPBUS()
        {
            db = new ChiTietSPDAO();
        }
        public static List<MauSP> GetAllMauSP()
        {
            return db.GetAllMauSP();
        }
        public static List<ChiTietSP> GetChiTietSPByIDSP(string id)
        {
            return db.GetChiTietSPByIDSP(id);
        }
    }
}
