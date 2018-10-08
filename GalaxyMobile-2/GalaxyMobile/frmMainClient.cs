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
        private CuaHang CH;

        private void frmMainClient_Load(object sender, EventArgs e)
        {
            PhanQuyen();
            CH = CuaHangBUS.GetThongTinCuaHang(User.MaCuaHang);
            this.Text = CH.TenCuaHang;
        }

        #region Event
        private void btnChiTietTK_Click(object sender, EventArgs e)
        {
            frmChiTietTaiKhoan frm = new frmChiTietTaiKhoan(User);
            frm.ShowDialog();
        }
        #endregion

        #region methods
        public void PhanQuyen()
        {
            if (MaTruyCap == 3)
            {
              
            }
            if (MaTruyCap == 4)
            {
                 tabControlMainClient.Controls.Remove(tabNhanVien);
                tabControlMainClient.Controls.Remove(tabThongKe);
                tabControlMainClient.Controls.Remove(tabCuaHang);
            }
            lbUser.Text = User.UserName;

        }
        #endregion

        #region HoaDon
        private void btnLoadHD_Click(object sender, EventArgs e)
        {
            LoadHoaDon();
        }
        void LoadHoaDon()
        {
            hoaDonBindingSource.DataSource = HoaDonBUS.GetAllHoaDonByMaCH(CH.MaCuaHang);
        }

        #endregion

        #region Kho Hang
        #endregion

        #region San Pham

        private void btnLoadSP_Click(object sender, EventArgs e)
        {
            LoadSP();
        }
        void LoadSP()
        {
            sanPhamBindingSource.DataSource = SanPhamBUS.GetAllSanPham();
        }
        #endregion

        #region Nha san xuat

        #endregion


    }
}
