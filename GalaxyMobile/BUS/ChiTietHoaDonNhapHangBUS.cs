﻿using System;
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
        public static void ThemSPintoCTNH(ChiTietHDNhapHang obj)
        {
            db.ThemSPintoCTNH(obj);
        }
        public static ChiTietHDNhapHang KiemTRaTonTaiSPinCTNH(string id, string idsp)
        {
            return db.KiemTRaTonTaiSPinCTNH(id, idsp);
        }
        public static void ThayDoiSLNhap(ChiTietHDNhapHang obj)
        {
            db.ThayDoiSLNhap(obj);
        }
        public static void LuuHoaDonNhap(string id)
        {
            db.LuuHoaDonNhap(id);
        }
    }
}
