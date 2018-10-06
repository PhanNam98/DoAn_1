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
    }
}
