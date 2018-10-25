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
        public static ChiTietSP Get1ChiTietSPByIDMaKieu(string id)
        {
            return db.Get1ChiTietSPByIDKieuSP(id);
        }
        public static SanPham GetMaSPByIDKieuSP(string id)
        {
            return db.GetMaSPByIDKieuSP(id);
        }
        public static USP_GETAllInfoSPNew_Result GetMaSPByMaKieuSP(string id)
        {
            return db.GetMaSPByMaKieuSP(id);
        }
        public static void XoaKieuSp(string id)
        {
            db.XoaKieuSp(id);
        }
        public static List<ChiTietSP> GetChiTietSPOderByMaCHByIDSP(string idch, string id)
        {
            return db.GetChiTietSPOderByMaCHByIDSP(idch, id);
        }
        public static ChiTietSP GetChiTietSPOderByMaCHByIDKieuSP(string idch, string id)
        {
            return db.GetChiTietSPOderByMaCHByIDKieuSP(idch, id);
        }
        public static void ThayDoiGiaChiTietSO(string id, decimal gia)
        {
            db.ThayDoiGiaSP(id, gia);
        }
        public  static byte[] LayAnhKieuSP(string id, string idsp)
        {
            return db.LayAnhKieuSP(id, idsp);
        }
        public static void PhanChiSP(string idMa, string idNhap, string idPP, int SL)
        {
            db.PhanChiSP(idMa,idNhap,idPP,SL);
        }
        public static void Them_CTSPMoi_Into_KhoHang_(string idMa)
        {
            db.Them_CTSPMoi_Into_KhoHang_(idMa);
        }
        public void Them_SLCTSP_Into_KhoHang_(string idMa, string ch, int sl)
        {
            db.Them_SLCTSP_Into_KhoHang_(idMa, ch, sl);
        }
    }
}
