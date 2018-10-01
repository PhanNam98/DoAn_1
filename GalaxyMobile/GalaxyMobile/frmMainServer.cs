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
    public partial class frmMainServer : Form
    {
        public frmMainServer(string username,string matruycap)
        {
            InitializeComponent();
        }
        public frmMainServer()
        {
            InitializeComponent();
        }

        private TaiKhoan User;
        private int MaTruyCap;
        private void frmMainServer_Load(object sender, EventArgs e)
        {
            LoadKhoHang();

        }
        #region Kho Hang
        public void LoadKhoHang()
        {

            khoHangBindingSource.DataSource = KhoHangBUS.GetAllKHoHang();
            cmBoxKhoHang.DataSource = CuaHangBUS.GetAllCuaHang();
            cmBoxKhoHang.DisplayMember = "TenCuaHang";
            cmBoxKhoHang.ValueMember = "MaCuaHang";

        }

        private void dgvKhoHang_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int r = dgvKhoHang.CurrentCell.RowIndex;
                string id = dgvKhoHang.Rows[r].Cells[0].Value.ToString();
                txtboxMaKieuSP.Text = id;
                txtSoLuongTonKho.Text = dgvKhoHang.Rows[r].Cells[2].Value.ToString();
                cmBoxKhoHang.SelectedValue = dgvKhoHang.Rows[r].Cells[1].Value.ToString();
            }
            catch { }
        }

        private void cmBoxKhoHang_SelectedIndexChanged(object sender, EventArgs e)
        {
            try {
                string id = cmBoxKhoHang.SelectedValue.ToString(); 
                KhoHang kh = CuaHangBUS.GetMaKieuByMaCH(id,txtboxMaKieuSP.Text);
                txtSoLuongTonKho.Text = kh.SoLuong.ToString();
                txtboxMaKieuSP.Text = kh.MaKieu.ToString();
            }
            catch { }
        }
        private void linklbChiTietSP_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }
        private void dgvKhoHang_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int r = dgvKhoHang.CurrentCell.RowIndex;
                string id = dgvKhoHang.Rows[r].Cells[0].Value.ToString();
                
                MessageBox.Show(id);
            }
            catch { }
        }
        #endregion




        #region San Pham
        private void btnLoadSP_Click(object sender, EventArgs e)
        {
            LoadSp();
        }
        void LoadSp()
        {
            sanPhamBindingSource.DataSource = SanPhamBUS.GetAllSanPham();
        }
        private void btnChiTietSP_Click(object sender, EventArgs e)
        {
            try
            {
                int r = dgvSP.CurrentCell.RowIndex;
                string id = dgvSP.Rows[r].Cells[0].Value.ToString();
                frmChiTietSanPham ctsp = new frmChiTietSanPham(id,null);
                ctsp.ShowDialog();
            }
            catch { }
        }
        private void dgvSP_CellClick(object sender, DataGridViewCellEventArgs e)
        {
           
        }
        private void dgvSP_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        #endregion




        #region Dong San Pham
        private void btnLoadDSP_Click(object sender, EventArgs e)
        {
            LoadDongSP();
        }

        public void LoadDongSP()
        {
            dongSanPhamBindingSource.DataSource = DongSanPhamBUS.GetAllDongSP();
        }









        #endregion

        private void pnlMainServer_Paint(object sender, PaintEventArgs e)
        {

        }

       
    }
}
