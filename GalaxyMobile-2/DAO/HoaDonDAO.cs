using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
namespace DAO
{
    public class HoaDonDAO
    {
        public List<HoaDon> GetAllHoaDon()
        {
            using (GalaxyMobileEntities dbs = new GalaxyMobileEntities())
            {
                return dbs.HoaDons.ToList();
            }
        }


        //Da Thanh Toan Theo TG
        public List<HoaDon> GetAllHoaDonByMaCH_Tg_DaThanhToan(string maCH, DateTime a, DateTime b)
        {
            using (GalaxyMobileEntities dbs = new GalaxyMobileEntities())
            {
                return dbs.HoaDons.Where(p => p.MaCuaHang == maCH && p.NgayLapHD <= b && p.NgayLapHD >= a && p.TinhTrang==1).ToList();
            }
        }
        public List<HoaDon> GetAllHoaDonByMaCH_DaThanhToan(string maCH)
        {
            using (GalaxyMobileEntities dbs = new GalaxyMobileEntities())
            {
                return dbs.HoaDons.Where(p => p.MaCuaHang == maCH && p.TinhTrang == 1).ToList();
            }
        }
        public List<HoaDon> GetAllHoaDonByTg_DaThanhToan(string maCH, DateTime a, DateTime b)
        {
            using (GalaxyMobileEntities dbs = new GalaxyMobileEntities())
            {
                return dbs.HoaDons.Where(p => p.NgayLapHD <= b && p.NgayLapHD >= a && p.TinhTrang == 1).ToList();
            }
        }


        //Chua Thanh Toan Theo TG
        public List<HoaDon> GetAllHoaDonByMaCH_Tg_ChuaThanhToan(string maCH, DateTime a, DateTime b)
        {
            using (GalaxyMobileEntities dbs = new GalaxyMobileEntities())
            {
                return dbs.HoaDons.Where(p => p.MaCuaHang == maCH && p.NgayLapHD <= b && p.NgayLapHD >= a && p.TinhTrang == 0).ToList();
            }
        }
        public List<HoaDon> GetAllHoaDonByMaCH_ChuaThanhToan(string maCH)
        {
            using (GalaxyMobileEntities dbs = new GalaxyMobileEntities())
            {
                return dbs.HoaDons.Where(p => p.MaCuaHang == maCH &&  p.TinhTrang == 0).ToList();
            }
        }
        public List<HoaDon> GetAllHoaDonByTg_ChuaThanhToan(string maCH, DateTime a, DateTime b)
        {
            using (GalaxyMobileEntities dbs = new GalaxyMobileEntities())
            {
                return dbs.HoaDons.Where(p=> p.NgayLapHD <= b && p.NgayLapHD >= a && p.TinhTrang == 0).ToList();
            }
        }

        //Dang Giao Hang Theo TG
        public List<HoaDon> GetAllHoaDonByMaCH_Tg_DangGiaoHang(string maCH, DateTime a, DateTime b)
        {
            using (GalaxyMobileEntities dbs = new GalaxyMobileEntities())
            {
                return dbs.HoaDons.Where(p => p.MaCuaHang == maCH && p.NgayLapHD <= b && p.NgayLapHD >= a && p.HTGiaoHang.ToLower() == "Giao Hàng".ToLower() && p.TinhTrang == 0).ToList();
            }
        }
        public List<HoaDon> GetAllHoaDonByMaCH_DangGiaoHang(string maCH)
        {
            using (GalaxyMobileEntities dbs = new GalaxyMobileEntities())
            {
                return dbs.HoaDons.Where(p => p.MaCuaHang == maCH &&  p.HTGiaoHang.ToLower() == "Giao Hàng".ToLower() && p.TinhTrang == 0).ToList();
            }
        }
        public List<HoaDon> GetAllHoaDonByTg_DangGiaoHang(string maCH, DateTime a, DateTime b)
        {
            using (GalaxyMobileEntities dbs = new GalaxyMobileEntities())
            {
                return dbs.HoaDons.Where(p => p.NgayLapHD <= b && p.NgayLapHD >= a && p.HTGiaoHang.ToLower()=="Giao Hàng".ToLower() && p.TinhTrang==0).ToList();
            }
        }

        //Toan Bo Theo TG
        public List<HoaDon> GetAllHoaDonByMaCH_Tg(string maCH, DateTime a, DateTime b)
        {
            using (GalaxyMobileEntities dbs = new GalaxyMobileEntities())
            {
                return dbs.HoaDons.Where(p => p.MaCuaHang == maCH && p.NgayLapHD <= b && p.NgayLapHD >= a).ToList();
            }
        }
        public List<HoaDon> GetAllHoaDonByTg(DateTime a, DateTime b)
        {
            using (GalaxyMobileEntities dbs = new GalaxyMobileEntities())
            {
                return dbs.HoaDons.Where(p =>p.NgayLapHD <= b && p.NgayLapHD >= a).ToList();
            }
        }


        public List<HoaDon> GetAllHoaDonByMaCH(string maCH)
        {
            using (GalaxyMobileEntities dbs = new GalaxyMobileEntities())
            {
                return dbs.HoaDons.Where(p=>p.MaCuaHang==maCH).ToList();
            }
        }
        public void ThemHoaDon(HoaDon hd)
        {
            using (GalaxyMobileEntities dbs = new GalaxyMobileEntities())
            {
                dbs.HoaDons.Add(hd);
                dbs.SaveChanges();
            }
        }
        public void XoaHoaDon(HoaDon hd)
        {
            using (GalaxyMobileEntities dbs = new GalaxyMobileEntities())
            {
                dbs.HoaDons.Attach(hd);
                dbs.HoaDons.Remove(hd);
                dbs.SaveChanges();
            }
        }
        public void ThanhToanHoaDon(string idhd, string idch)
        {
            using (GalaxyMobileEntities dbs = new GalaxyMobileEntities())
            {
                var ct = dbs.ChiTietHoaDons.Where(p => p.MaHoaDon == idhd && p.MaCuaHang == idch).ToList();
                foreach(ChiTietHoaDon c in ct)
                {
                    dbs.USP_ThayDoiSoLuongChiTietSP(c.MaKieu, -c.SoluongSP);
                    dbs.USP_ThemSL_KhoHangByMaKieuByMaCH(c.MaKieu, idch, -c.SoluongSP);
                }
                var hd = dbs.HoaDons.Where(p => p.MaHoaDon == idhd && p.MaCuaHang == idch).SingleOrDefault();
                dbs.HoaDons.Attach(hd);
                hd.TinhTrang = 1;
                dbs.Entry(hd).State = System.Data.Entity.EntityState.Modified;
                dbs.SaveChanges();
            }
        }
        public void LayHangHoaDon(string idhd, string idch)
        {
            using (GalaxyMobileEntities dbs = new GalaxyMobileEntities())
            {
                var ct = dbs.ChiTietHoaDons.Where(p => p.MaHoaDon == idhd && p.MaCuaHang == idch).ToList();
                foreach (ChiTietHoaDon c in ct)
                {
                    dbs.USP_ThayDoiSoLuongChiTietSP(c.MaKieu, -c.SoluongSP);
                    dbs.USP_ThemSL_KhoHangByMaKieuByMaCH(c.MaKieu, idch, -c.SoluongSP);
                }
               
            }
        }
        public void TraHangHoaDon(string idhd, string idch)
        {
            using (GalaxyMobileEntities dbs = new GalaxyMobileEntities())
            {
                var ct = dbs.ChiTietHoaDons.Where(p => p.MaHoaDon == idhd && p.MaCuaHang == idch).ToList();
                foreach (ChiTietHoaDon c in ct)
                {
                    dbs.USP_ThayDoiSoLuongChiTietSP(c.MaKieu, c.SoluongSP);
                    dbs.USP_ThemSL_KhoHangByMaKieuByMaCH(c.MaKieu, idch, c.SoluongSP);
                }

            }
        }
        public void DaThanhToan(string idhd, string idch)
        {
            using (GalaxyMobileEntities dbs = new GalaxyMobileEntities())
            {
                
                var hd = dbs.HoaDons.Where(p => p.MaHoaDon == idhd && p.MaCuaHang == idch).SingleOrDefault();
                dbs.HoaDons.Attach(hd);
                hd.TinhTrang = 1;
                dbs.Entry(hd).State = System.Data.Entity.EntityState.Modified;
                dbs.SaveChanges();
            }
        }
        public List<HoaDon> TimKiemHD(string id)
        {
            using (GalaxyMobileEntities db = new GalaxyMobileEntities())
            {
                return db.HoaDons.Where(p => p.MaHoaDon.Contains(id) || p.MaKH.Contains(id)||p.MaNV.Contains(id)).ToList();
            }
        }
    }
}
