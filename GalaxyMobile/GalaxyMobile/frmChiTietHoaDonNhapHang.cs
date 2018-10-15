using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BUS;
using Model;
namespace GalaxyMobile
{
    public partial class frmChiTietHoaDonNhapHang : Form
    {
        public frmChiTietHoaDonNhapHang(string idHd)
        {
            InitializeComponent();
            IDHDNH = idHd;
        }
        private string IDHDNH;
        
        private void frmChiTietHoaDonNhapHang_Load(object sender, EventArgs e)
        {
            LoadCTHDNH();
        }
        #region methods
        void LoadCTHDNH()
        {
            chiTietHDNhapHangBindingSource.DataSource = ChiTietHoaDonNhapHangBUS.GetAllSanPham(IDHDNH);
        }
        #endregion
        #region events

        #endregion
    }
}
