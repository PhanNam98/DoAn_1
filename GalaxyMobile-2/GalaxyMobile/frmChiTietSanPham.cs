using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GalaxyMobile
{
    public partial class frmChiTietSanPham : Form
    {
        public frmChiTietSanPham(string id,string idmod )
        {
            InitializeComponent();
            ID = id;
            IDMod = idmod; ;
        }
        private string ID;
        private string IDMod;
        void LoadSP()
        {   

        }

    }
}
