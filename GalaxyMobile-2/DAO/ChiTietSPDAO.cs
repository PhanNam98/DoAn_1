using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
namespace DAO
{
    public class ChiTietSPDAO
    {
        public List<MauSP> GetAllMauSP()
        {
            using (GalaxyMobileEntities db = new GalaxyMobileEntities())
            {
                return db.MauSPs.ToList();
            }
        }
        public List<ChiTietSP> GetChiTietSPByIDSP(string id)
        {
            using (GalaxyMobileEntities db = new GalaxyMobileEntities())
            {
                return db.ChiTietSPs.Where(p => p.MaSP == id).ToList();
            }
        }
        public List<ChiTietSP> GetChiTietSPOderByMaCHByIDSP(string idch, string id)
        {
            using (GalaxyMobileEntities db = new GalaxyMobileEntities())
            {
                return db.USP_GetCTSPOderByMaCHByMaSP(idch, id).ToList();
            }
        }
        public ChiTietSP Get1ChiTietSPByIDKieuSP(string id)
        {
            using (GalaxyMobileEntities db = new GalaxyMobileEntities())
            {

                return db.ChiTietSPs.Where(p => p.MaKieu == id).SingleOrDefault();
            }
        }
        public ChiTietSP GetChiTietSPOderByMaCHByIDKieuSP(string idch, string id)
        {
            using (GalaxyMobileEntities db = new GalaxyMobileEntities())
            {
                return db.USP_GetCTSPOderByMaCHByMaKieu(idch, id).SingleOrDefault();
            }
        }
        public SanPham GetMaSPByIDKieuSP(string id)
        {
            using (GalaxyMobileEntities db = new GalaxyMobileEntities())
            {
                string idsp = db.ChiTietSPs.Where(p => p.MaKieu == id).Select(o => o.MaSP).Single();
                return db.SanPhams.Where(p => p.MaSP == idsp).Single();

            }
        }
        public USP_GETAllInfoSPNew_Result GetMaSPByMaKieuSP(string id)
        {
            using (GalaxyMobileEntities db = new GalaxyMobileEntities())
            {
                return db.USP_GETAllInfoSPNew(id).Single();
            }
        }
        public void ThemKieuSp(ChiTietSP obj)
        {
            using (GalaxyMobileEntities db = new GalaxyMobileEntities())
            {
                db.ChiTietSPs.Add(obj);
                db.SaveChangesAsync();
            }
        }
        public void XoaKieuSp(string id)
        {
            using (GalaxyMobileEntities db = new GalaxyMobileEntities())
            {
                db.USP_DeleteCTSP(id);
            }
        }
        public void ThayDoiGiaSP(string id, decimal gia)
        {
            using (GalaxyMobileEntities db = new GalaxyMobileEntities())
            {
                db.USP_ThayDoiGiaChiTietSP(id, gia);
            }
        }
        public byte[] LayAnhKieuSP(string id, string idsp)
        {
            using (GalaxyMobileEntities db = new GalaxyMobileEntities())
            {
                try {
                    return db.ChiTietSPs.Where(p => p.MaKieu == idsp && p.MaSP == id).SingleOrDefault().Anh;
                }
                catch { return null; }
            }
        }
        public void PhanChiSP(string idMa, string idNhap, string idPP, int SL)
        {
            using (GalaxyMobileEntities db = new GalaxyMobileEntities())
            {
                db.USP_PhanChiaSP(idMa, idNhap, idPP, SL);
            }
        }
        public void Them_CTSPMoi_Into_KhoHang_(string idMa)
        {
            using (GalaxyMobileEntities db = new GalaxyMobileEntities())
            {
                List<CuaHang> ch = db.CuaHangs.ToList();
                foreach (CuaHang p in ch)
                {
                    KhoHang kh = new KhoHang();
                    kh.MaCuaHang = p.MaCuaHang;
                    kh.MaKieu = idMa;
                    kh.SoLuong = 0;
                    db.KhoHangs.Add(kh);
                    db.SaveChanges();
                }
               
            }
        }
        public void Them_SLCTSP_Into_KhoHang_(string idMa,string ch,int sl)
        {
            using (GalaxyMobileEntities db = new GalaxyMobileEntities())
            {
                    db.USP_ThemSL_KhoHangByMaKieuByMaCH(idMa, ch,sl);
            }
        }

    }

}
