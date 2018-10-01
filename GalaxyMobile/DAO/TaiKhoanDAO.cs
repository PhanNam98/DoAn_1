using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
namespace DAO
{
    public class TaiKhoanDAO
    {
        public TaiKhoan kttk(string name, string pass)
        {
            TaiKhoan a = new TaiKhoan();
            using (GalaxyMobileEntities dbs = new GalaxyMobileEntities())
            {
                return dbs.TaiKhoans.SingleOrDefault(p => p.UserName == name && p.Password == pass);
                //a = (from i in dbs.TaiKhoans
                //     where i.UserName == name && i.Password == pass
                //     select new TaiKhoan(i.UserName,i.Password))
            }
            //return a;
        }
    }
}
