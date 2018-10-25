using System;
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
        public static int MaTruyCap(string name, string pass)
        {
            return db.matruycap(name, pass);
        }
        public static void ThayDoiMK(TaiKhoan User)
        {
            db.ThayDoiMK(User);
        }
        public static List<TaiKhoan> GetAllTK()
        {
            return db.GetAllTK();
        }
        public static void ThemTK(TaiKhoan obj)
        {
            db.ThemTK(obj);
        }
        public static void XoaTK(string User)
        {
            db.XoaTK(User);
        }
        public static TaiKhoan Get1TK(string name)
        {
           return db.Get1TK(name);
        }
        public static void EditTk(TaiKhoan obj)
        {
            db.EditTk(obj);
        }
    }
}
