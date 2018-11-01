using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
namespace DAO
{
    public class ThongKe
    {
        public List<spSPBanDuoc_Result> GetAll(string cuahang)
        {
            using (GalaxyMobileEntities dbs = new GalaxyMobileEntities())
            {
                return dbs.spSPBanDuoc(cuahang).ToList();
            }
        }
        public List<spSPBanDuocTrongNgay_Result> SPBanTrongNgay(string cuahang,DateTime date)
        {
            using (GalaxyMobileEntities dbs = new GalaxyMobileEntities())
            {
                return dbs.spSPBanDuocTrongNgay(cuahang,date).ToList();
            }
        }
        public List<spSPBanDuocTheoThoiGian_Result> SPBanTheoTG(string cuahang, DateTime date, DateTime date2)
        {
            using (GalaxyMobileEntities dbs = new GalaxyMobileEntities())
            {
                return dbs.spSPBanDuocTheoThoiGian(cuahang, date,date2).ToList();
            }
        }
    }
}