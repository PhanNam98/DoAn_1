﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAO;
using Model;
namespace BUS
{
    public class TaiKhoanBUS
    {
        static TaiKhoanDAO db;
        static TaiKhoanBUS()
        {
            db = new TaiKhoanDAO();
        }
        public static TaiKhoan kttk(string name, string pass)
        {
            return db.kttk(name, pass);
        }
    }
}
