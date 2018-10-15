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
                tabControlMainServer.Controls.Remove(tabNhapHang);
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
                frmChiTietSanPham ctsp = new frmChiTietSanPham(id,MaTruyCap,null,false);
                ctsp.ShowDialog();
            }
            catch { }
        }
        private void btnChinhSuaSP_Click(object sender, EventArgs e)
        {
            try
            {
                int r = dgvSP.CurrentCell.RowIndex;
                string id = dgvSP.Rows[r].Cells[0].Value.ToString();
                frmChiTietSanPham ctsp = new frmChiTietSanPham(id,MaTruyCap,null,true);
                ctsp.ShowDialog();
            }
            catch { }
            LoadSp();
        }
        private void btnThemSP_Click(object sender, EventArgs e)
        {
           
                frmChiTietSanPham ctsp = new frmChiTietSanPham(null,MaTruyCap, null,false);
                ctsp.ShowDialog();
                LoadSp();
           
        }
        private void btXoaSP_Click(object sender, EventArgs e)
        {
            if (sanPhamBindingSource.Current == null)
                return;
            if (MessageBox.Show("Bạn có chắc muốn xóa dòng này không?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {

                try
                {
                    SanPhamBUS.XoaSP(sanPhamBindingSource.Current as SanPham);
                    MessageBox.Show("Xóa thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch { MessageBox.Show("Lỗi! Không thể thực hiện thao tác", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            }

            LoadSp();
        }
        private void dgvSP_CellClick(object sender, DataGridViewCellEventArgs e)
        {
           
        }
        private void dgvSP_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int r = dgvSP.CurrentCell.RowIndex;
                string id = dgvSP.Rows[r].Cells[0].Value.ToString();
                frmChiTietSanPham ctsp = new frmChiTietSanPham(id,MaTruyCap,null,false);
                ctsp.ShowDialog();
            }
            catch { }
        }
        #endregion

        #region NhanVien
        bool Them = false;
        public void LoadNV()
        {
            nhanVienBindingSource.DataSource = NhanVienBUS.GetNV();
            dgvNhanVien_CellClick(null, null);
            // Xóa trống các đối tượng trong Panel 
            txtMaNV.ResetText();
            txtTenNV.ResetText();
            txtSDT.ResetText();
            cboLoaiNV.ResetText();
            cboSex.ResetText();
            txtDiaChi.ResetText();
            txtLuong.ResetText();
            cboCH.ResetText();
            // Không cho thao tác trên các nút Lưu / Hủy 
            btnLuu.Enabled = false;
            btnHuy.Enabled = false;
            panel.Enabled = false;
            btnLNV.Enabled = true;
            // Cho thao tác trên các nút Thêm / Sửa / Xóa / Thoát 
            btnThem.Enabled = true;
            btnSua.Enabled = true;
            btnXoa.Enabled = true;
        }
        private void btnReload_Click(object sender, EventArgs e)
        {
            LoadNV();
            dgvNhanVien_CellClick(null, null);
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
            // Kích hoạt biến Sửa
            Them = false;
            dgvNhanVien_CellClick(null, null);
            //dgvKH_CellClick(null, null);
            // Cho phép thao tác trên Panel 
            panel.Enabled = true;
            // Cho thao tác trên các nút Lưu / Hủy / Panel 
            btnLuu.Enabled = true;
            btnHuy.Enabled = true;
            // Không cho thao tác trên các nút Thêm / Xóa / Thoát 
            btnThem.Enabled = false;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            // Đưa con trỏ đến TextField txtTenNV         
            txtMaNV.Enabled = false;
            txtTenNV.Focus();
        }
        private void btnThem_Click(object sender, EventArgs e)
        {
            Them = true;
            txtMaNV.Enabled = true;
            // Xóa trống các đối tượng trong Panel 
            txtMaNV.ResetText();
            txtTenNV.ResetText();
            txtSDT.ResetText();
            cboLoaiNV.ResetText();
            cboSex.ResetText();
            txtDiaChi.ResetText();
            txtLuong.ResetText();
            cboCH.ResetText();
            // Cho thao tác trên các nút Lưu / Hủy / Panel 
            btnLuu.Enabled = true;
            btnHuy.Enabled = true;
            panel.Enabled = true;
            // Không cho thao tác trên các nút Thêm / Xóa / Thoát 
            btnThem.Enabled = false;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            txtMaNV.Focus();
        }
        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (Them)
            {
                if (NhanVienBUS.KtMaNV(txtMaNV.Text) > 0)
                {
                    MessageBox.Show("Mã nhân viên tồn tai. Nhập Mã nhân viên khác !");
                    txtMaNV.ResetText();
                    txtTenNV.ResetText();
                    txtSDT.ResetText();
                    cboLoaiNV.ResetText();
                    cboSex.ResetText();
                    txtDiaChi.ResetText();
                    txtLuong.ResetText();
                    cboCH.ResetText();
                    txtMaNV.Focus();
                }
                else
                {
                    decimal tien = Convert.ToDecimal(txtLuong.Text);
                    NhanVienBUS.InsertNV(txtMaNV.Text, cboCH.SelectedValue.ToString(), cboLoaiNV.SelectedValue.ToString(), txtTenNV.Text, cboSex.Text, txtDiaChi.Text, txtSDT.Text, tien);
                    LoadNV();
                    // Thông báo 
                    MessageBox.Show("Đã thêm xong!");
                }
            }
            else
            {
                int r = dgvNhanVien.CurrentCell.RowIndex;
                // MaNV hiện hành 
                decimal tien = Convert.ToDecimal(txtLuong.Text);
                string strMaNV = dgvNhanVien.Rows[r].Cells[0].Value.ToString();
                NhanVienBUS.UpdateNV(strMaNV, cboCH.SelectedValue.ToString(), cboLoaiNV.SelectedValue.ToString(), txtTenNV.Text, cboSex.Text, txtDiaChi.Text, txtSDT.Text, tien);
                LoadNV();
                // Thông báo 
                MessageBox.Show("Đã sửa xong!");
            }

        }
        private void btnHuy_Click(object sender, EventArgs e)
        {

            // Xóa trống các đối tượng trong Panel 
            txtMaNV.ResetText();
            txtTenNV.ResetText();
            txtSDT.ResetText();
            cboLoaiNV.ResetText();
            cboSex.ResetText();
            txtDiaChi.ResetText();
            txtLuong.ResetText();
            cboCH.ResetText();
            // Cho thao tác trên các nút Thêm / Sửa / Xóa / Thoát 
            btnThem.Enabled = true;
            btnSua.Enabled = true;
            btnXoa.Enabled = true;
            // Không cho thao tác trên các nút Lưu / Hủy / Panel 
            btnLuu.Enabled = false;
            btnHuy.Enabled = false;
            panel.Enabled = false;
        }

        private void dgvNhanVien_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            cboCH.DataSource = CuaHangBUS.GetAllCuaHang();
            cboCH.DisplayMember = "TenCuaHang";
            cboCH.ValueMember = "MaCuaHang";
            cboLoaiNV.DataSource = LoaiNvBUS.GetLNV();
            cboLoaiNV.DisplayMember = "TenLoaiNV";
            cboLoaiNV.ValueMember = "MaLoaiNV";

            // Lấy thứ tự record hiện hành 
            int r = dgvNhanVien.CurrentCell.RowIndex;
            txtMaNV.Text = dgvNhanVien.Rows[r].Cells[0].Value.ToString();
            cboCH.SelectedValue = dgvNhanVien.Rows[r].Cells[1].Value.ToString();
            cboLoaiNV.SelectedValue = dgvNhanVien.Rows[r].Cells[2].Value.ToString();
            txtTenNV.Text = dgvNhanVien.Rows[r].Cells[3].Value.ToString();
            cboSex.Text = dgvNhanVien.Rows[r].Cells[4].Value.ToString();
            try
            {
                txtDiaChi.Text = dgvNhanVien.Rows[r].Cells[5].Value.ToString();
            }
            catch { txtDiaChi.Text = " "; }
               
                try
                {
                    txtSDT.Text = dgvNhanVien.Rows[r].Cells[6].Value.ToString();
                }
                catch
                {
                   
                    txtSDT.Text = " ";
                }
            try
            {
                txtLuong.Text = dgvNhanVien.Rows[r].Cells[7].Value.ToString();
            }
            catch
            {

                txtLuong.Text = " ";
            }


        }
        #endregion


        #region LoaiNhanVIen
        private void btnLNV_Click(object sender, EventArgs e)
        {
            Form frm = new LNhanVIen();
            frm.ShowDialog();
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
        private void btnThemDSP_Click(object sender, EventArgs e)
        {
            btnThemDSP.Visible = false;
            btnXoaDSP.Visible = false;
            btnChinhSuaDSP.Visible = false;
            btnLuuChangeDSP.Visible = true;
            btnHuyChangeDSP.Visible = true;
            lbTitle.Visible = true;
            lbTitle.Text = "Thêm Dòng Sản Phẩm";
            txtboxMaDongSP.Text = "";
            txtboxTenDongSP.Text = "";
            //cmBoxHSX.DataSource =HSXBUS.GetAllHSX();
            //cmBoxHSX.DisplayMember = "TenHSX";
            //cmBoxHSX.ValueMember = "MaHSX";
            //cmBoxLoaiSP.DataSource =LoaiSPBUS.GetAllLoaiSP();
            //cmBoxLoaiSP.DisplayMember = "TenLSP";
            //cmBoxLoaiSP.ValueMember = "MaLSP";
        }
        private void btnChinhSuaDSP_Click(object sender, EventArgs e)
        {
            btnThemDSP.Visible = false;
            btnXoaDSP.Visible = false;
            btnChinhSuaDSP.Visible = false;
            btnLuuChangeDSP.Visible = true;
            btnHuyChangeDSP.Visible = true;
            txtboxMaDongSP.ReadOnly = true;
            lbTitle.Visible = true;
            lbTitle.Text = "Chỉnh Sửa Dòng Sản Phẩm";
           
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
        private void btnXoaDSP_Click(object sender, EventArgs e)
        {
            if (dongSanPhamBindingSource.Current == null)
                return;
            if (MessageBox.Show("Bạn có chắc muốn xóa dòng này không?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {

                try
                {
                    DongSanPhamBUS.XoaDongSP(dongSanPhamBindingSource.Current as DongSanPham);
                    MessageBox.Show("Xóa thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch { MessageBox.Show("Lỗi! Không thể thực hiện thao tác", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            }
            LoadDongSP();
        }
        private void btnLuuChangeDSP_Click(object sender, EventArgs e)
        {
            if (txtboxMaDongSP.Text == "" || txtboxTenDongSP.Text == "")
            {
                MessageBox.Show("Lỗi! Xin Nhập Đầy Đủ thông Tin", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (lbTitle.Text == "Thêm Dòng Sản Phẩm")
            {
                try
                {
                    DongSanPham dsp = new DongSanPham();
                    dsp.MaDSP = txtboxMaDongSP.Text;
                    dsp.MaHSX = cmBoxHSX.SelectedValue.ToString();
                    dsp.TenDong = txtboxTenDongSP.Text;
                    dsp.MaLSP = cmBoxLoaiSP.SelectedValue.ToString();
                    //kiểm tra hợp lệ
                    DongSanPhamBUS.ThemDongSP(dsp);
                    MessageBox.Show("Thêm Thành Công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch { MessageBox.Show("Lỗi! Không thể thực hiện thao tác", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            }
            else
            {
                try
                {
                    DongSanPham dsp = new DongSanPham();
                    dsp.MaDSP = txtboxMaDongSP.Text;
                    dsp.MaHSX = cmBoxHSX.SelectedValue.ToString();
                    dsp.TenDong = txtboxTenDongSP.Text;
                    dsp.MaLSP = cmBoxLoaiSP.SelectedValue.ToString();
                    DongSanPhamBUS.ChinhSuaDongSP(dsp);
                    MessageBox.Show("Chỉnh Sửa Thành Công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch { MessageBox.Show("Lỗi! Không thể thực hiện thao tác", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            }
            btnThemDSP.Visible = true;
            btnXoaDSP.Visible = true;
            btnChinhSuaDSP.Visible = true;
            btnLuuChangeDSP.Visible = false;
            btnHuyChangeDSP.Visible = false;
            txtboxMaDongSP.ReadOnly = false;
            LoadDongSP();
        }
        private void btnHuyChangeDSP_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn Có Chắc Muốn Hủy Thao Tác Này Không?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                MessageBox.Show("Đã Hủy Thay Đổi!","Thông Báo");
                btnThemDSP.Visible = true;
                btnXoaDSP.Visible = true;
                btnChinhSuaDSP.Visible = true;
                btnLuuChangeDSP.Visible = false;
                btnHuyChangeDSP.Visible = false;
            }
           
        }
        #endregion



        #region Hhap Hang






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

       

        private void panel_Paint(object sender, PaintEventArgs e)
        {

        }


        private void cboCH_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cboSex_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void frmMainServer_Load_1(object sender, EventArgs e)
        {

        }
    }
}
