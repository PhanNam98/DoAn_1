using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using DAO;
namespace BUS
{
    public static class LoaiNvBUS
    {
        static public LoaiNvDAO db;
        static LoaiNvBUS()
        {
            db = new LoaiNvDAO();
        }
        public static List<LoaiNV> GetLNV()
        {
            return db.GetallLNV();
        }
    }
}
