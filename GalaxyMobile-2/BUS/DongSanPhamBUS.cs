﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using DAO;
namespace BUS
{
    public static class DongSanPhamBUS
    {
        static DongSanPhamDAO db;
        static DongSanPhamBUS()
        {
            db = new DongSanPhamDAO();
        }
        public static List<DongSanPham> GetAllDongSP()
        {
            return db.GetAllDongSP();
        }
    }
}
