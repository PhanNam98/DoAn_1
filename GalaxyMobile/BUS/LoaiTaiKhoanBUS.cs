using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using DAO;
namespace BUS
{
    public static class LoaiTaiKhoanBUS
    {
        static public LoaiTaiKhoanDAO db;
        static LoaiTaiKhoanBUS()
        {
            db = new LoaiTaiKhoanDAO();
        }
        public static List<LoaiTaiKhoan> GetAllLoaiTaiKhoan()
        {
            return db.GetAllLoaiTK();
        } 
       
    }
}
