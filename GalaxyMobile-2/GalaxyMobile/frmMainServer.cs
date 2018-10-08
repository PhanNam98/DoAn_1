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
using DAO;
namespace GalaxyMobile
{
    public partial class frmMainServer : Form
    {
        public frmMainServer(TaiKhoan username,int matruycap)
        {
            InitializeComponent();
            User = username;
            MaTruyCap = matruycap;
        }
        //public frmMainServer()
        //{
        //    InitializeComponent();
        //}

        private TaiKhoan User;
        private int MaTruyCap;
        private CuaHang CH;
        private void frmMainServer_Load(object sender, EventArgs e)
        {
            LoadKhoHang();
            PhanQuyen();
            CH = CuaHangBUS.GetThongTinCuaHang(User.MaCuaHang);
            this.Text = CH.TenCuaHang;
        }
        #region method
        public void PhanQuyen()
        {
            if (MaTruyCap == 1)
            {
                tabControlMainServer.Controls.Remove(tabNhanVien);
                tabControlMainServer.Controls.Remove(tabTaiKhoan);
            }
            if (MaTruyCap == 2)
            {
                tabControlMainServer.Controls.Remove(tabKhoHang);
                tabControlMainServer.Controls.Remove(tabDongSanPham);
                tabControlMainServer.Controls.Remove(tabSanPham);
                tabControlMainServer.Controls.Remove(tabNSX);
            }
            label12.Text = User.UserName;
            loadCmboxDongSanPham();
        }
        public void loadCmboxDongSanPham()
        {
            cmBoxLoaiSP.DataSource = LoaiSPBUS.GetAllLoaiSP();
            cmBoxLoaiSP.DisplayMember = "TenLSP";
            cmBoxLoaiSP.ValueMember = "MaLSP";

            cmBoxHSX.DataSource = HSXBUS.GetAllHSX();
            cmBoxHSX.DisplayMember = "TenHSX";
            cmBoxHSX.ValueMember = "MaHSX";
        }
        #endregion

        #region Event
        private void btnChiTietTaiKhoan_Click(object sender, EventArgs e)
        {
            frmChiTietTaiKhoan frm = new frmChiTietTaiKhoan(User);
            frm.ShowDialog();
        }
      
        #endregion

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

        #region NhanVien

        public void LoadNV()
        {
            nhanVienBindingSource.DataSource = NhanVienBUS.GetNV();
        }
        private void btnReload_Click(object sender, EventArgs e)
        {
            LoadNV();
        }
        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                // Lấy thứ tự record hiện hành 
                int r = dgvNhanVien.CurrentCell.RowIndex;
                // Lấy MaKH của record hiện hành 
                string strMANV =
                dgvNhanVien.Rows[r].Cells[0].Value.ToString();
                NhanVienBUS.DelNhanVien(strMANV);
                LoadNV();
                //dgvNV_CellClick(null, null);
                MessageBox.Show("Đã xóa xong!");
            }
            catch
            {
                MessageBox.Show("Không được phép xóa nhân viên này");
            }
        }
        private void btnSua_Click(object sender, EventArgs e)
        {

        }
        private void btnThem_Click(object sender, EventArgs e)
        {

        }
        private void btnLuu_Click(object sender, EventArgs e)
        {
            decimal tien = Convert.ToDecimal(txtLuong.Text);
            NhanVienBUS.InsertNV(txtMaNV.Text, txtCH.Text, txtLoai.Text, txtTenNV.Text, txtSex.Text, txtDiaChi.Text, txtSDT.Text, tien);
            LoadNV();
        }
        private void btnHuy_Click(object sender, EventArgs e)
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
        private void dgvDongSP_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int r = dgvDongSP.CurrentCell.RowIndex;
                string id = dgvDongSP.Rows[r].Cells[0].Value.ToString();
                txtboxMaDongSP.Text = id;
                txtboxTenDongSP.Text = dgvDongSP.Rows[r].Cells[1].Value.ToString();
                cmBoxHSX.SelectedValue = dgvDongSP.Rows[r].Cells[2].Value.ToString();
                cmBoxLoaiSP.SelectedValue = dgvDongSP.Rows[r].Cells[3].Value.ToString();
            }
            catch { }
        }


        #endregion

        private void pnlMainServer_Paint(object sender, PaintEventArgs e)
        {

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void pnlKho_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label15_Click(object sender, EventArgs e)
        {

        }

       
    }
}
