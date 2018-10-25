using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAO;
using Model;
namespace BUS
{
    public static class ThongKeBUS
    {
        static ThongKeDAO db;
        static ThongKeBUS()
        {
            db = new ThongKeDAO();
        }
        public static List<spSPBanDuoc_Result> getProductSale(string cuahang)
        {
            return db.GetAll(cuahang);
        }
    }
}
