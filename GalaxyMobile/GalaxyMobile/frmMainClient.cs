using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Model;
using BUS;
namespace GalaxyMobile
{
    public partial class frmMainClient : Form
    {
        public frmMainClient(TaiKhoan username, int matruycap)
        {
            InitializeComponent();
            User = username;
            MaTruyCap = matruycap;
        }
        private TaiKhoan User;
        private int MaTruyCap;
    }
}
