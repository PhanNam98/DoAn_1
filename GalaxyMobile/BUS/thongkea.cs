using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using DAO;
using Model;
namespace BUS
{
    public static class thongkea
    {
        static ThongKe db;
        static thongkea()
        {
            db = new ThongKe();
        }
        public static List<spSPBanDuoc_Result> getProductSale(string cuahang)
        {
            return db.GetAll(cuahang);
        }
        public static List<spSPBanDuocTrongNgay_Result> SPBanTrongNgay(string cuahang, DateTime date)
        {
            return db.SPBanTrongNgay(cuahang, date);
        }
        public static List<spSPBanDuocTheoThoiGian_Result> SPBanTheoTG(string cuahang, DateTime date, DateTime date2)
        {
            return db.SPBanTheoTG(cuahang, date, date2);
        }
    }
}