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
        public frmMainServer(TaiKhoan username, int matruycap)
        {
            InitializeComponent();
            User = username;
            MaTruyCap = matruycap;
        }


        private TaiKhoan User;
        private int MaTruyCap;
        private CuaHang CH;
        private void frmMainServer_Load(object sender, EventArgs e)
        {
            LoadKhoHang();
            LoadSer();
            PhanQuyen();
            CH = CuaHangBUS.GetThongTinCuaHang(User.MaCuaHang);
            this.Text = CH.TenCuaHang;
        }
        #region method
        void LoadSer()
        {
            dateTimePickerTrongNgay.Value = DateTime.Now;
            comboBoxTKSP.DataSource = CuaHangBUS.GetCuaHangChiNhanh();
            comboBoxTKSP.DisplayMember = "TenCuaHang";
            comboBoxTKSP.ValueMember = "MaCuaHang";
        }
        public void PhanQuyen()
        {
            if (MaTruyCap == 1)
            {
                tabControlMainServer.Controls.Remove(tabNhanVien);
                tabControlMainServer.Controls.Remove(tabTaiKhoan);
                tabControlMainServer.Controls.Remove(tabCuaHang);
                tabControlMainServer.Controls.Remove(tabThongKe);

                cmBoxTimKiemTheo.Items.Add("Dòng Sản Phẩm");
                cmBoxTimKiemTheo.Items.Add("Sản Phẩm");
                cmBoxTimKiemTheo.Items.Add("Nhà Sản Xuất");
                cmBoxTimKiemTheo.Items.Add("Hóa Đơn Nhập");

            }
            if (MaTruyCap == 2)
            {
                tabControlMainServer.Controls.Remove(tabKhoHang);
                tabControlMainServer.Controls.Remove(tabDongSanPham);
                tabControlMainServer.Controls.Remove(tabSanPham);
                tabControlMainServer.Controls.Remove(tabNSX);
                tabControlMainServer.Controls.Remove(tabNhapHang);
                tabControlMainServer.Controls.Remove(tabCuaHang);
                tabControlMainServer.Controls.Remove(tabThongKe);
                cmBoxTimKiemTheo.Items.Add("Nhân Viên");

            }
            else if (MaTruyCap == 0)
            {
                cmBoxTimKiemTheo.Items.Add("Nhân Viên");
                cmBoxTimKiemTheo.Items.Add("Dòng Sản Phẩm");
                cmBoxTimKiemTheo.Items.Add("Sản Phẩm");
                cmBoxTimKiemTheo.Items.Add("Nhà Sản Xuất");
                cmBoxTimKiemTheo.Items.Add("Hóa Đơn Nhập");
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
            try
            {
                string id = cmBoxKhoHang.SelectedValue.ToString();
                KhoHang kh = CuaHangBUS.GetMaKieuByMaCH(id, txtboxMaKieuSP.Text);
                txtSoLuongTonKho.Text = kh.SoLuong.ToString();
                txtboxMaKieuSP.Text = kh.MaKieu.ToString();
            }
            catch { }
        }
        private void btnChiaSP_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtboxMaKieuSP.Text.Trim(' ') != "")
                {
                    frmPhanChiaSP pc = new frmPhanChiaSP(txtboxMaKieuSP.Text);
                    pc.Show();
                    LoadKhoHang();
                }
                else
                    MessageBox.Show("Lỗi! Mã Kiểu Sản Phẩm Không Có Giá Trị", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch { MessageBox.Show("Lỗi! Không thể thực hiện thao tác", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void linklbChiTietSP_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (txtboxMaKieuSP.Text == "")
                return;
            frmChiTietSanPham ctsp = new frmChiTietSanPham(ChiTietSPBUS.GetMaSPByIDKieuSP(txtboxMaKieuSP.Text).MaSP, User.MaCuaHang, null, false);
            ctsp.ShowDialog();
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
        private void btnLoadKho_Click(object sender, EventArgs e)
        {
            LoadKhoHang();
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
                frmChiTietSanPham ctsp = new frmChiTietSanPham(id, User.MaCuaHang, null, false);
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
                frmChiTietSanPham ctsp = new frmChiTietSanPham(id, User.MaCuaHang, null, true);
                ctsp.ShowDialog();
            }
            catch { }
            LoadSp();
        }
        private void btnThemSP_Click(object sender, EventArgs e)
        {

            frmChiTietSanPham ctsp = new frmChiTietSanPham(null, User.MaCuaHang, null, false);
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
                frmChiTietSanPham ctsp = new frmChiTietSanPham(id, User.MaCuaHang, null, false);
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
            loadCmboxDongSanPham();
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
                MessageBox.Show("Đã Hủy Thay Đổi!", "Thông Báo");
                btnThemDSP.Visible = true;
                btnXoaDSP.Visible = true;
                btnChinhSuaDSP.Visible = true;
                btnLuuChangeDSP.Visible = false;
                btnHuyChangeDSP.Visible = false;
            }

        }
        #endregion



        #region Hhap Hang
        void LoadNhapHang()
        {
            hoaDonNhapHangBindingSource.DataSource = HoaDonNhapHangBUS.GetAllHoaDonNhap();
        }
        private void btnLoadHDNH_Click(object sender, EventArgs e)
        {
            LoadNhapHang();
        }
        private void btnChiTietHDNH_Click(object sender, EventArgs e)
        {

            int r = dgvNhapHang.CurrentCell.RowIndex;
            string id = dgvNhapHang.Rows[r].Cells[0].Value.ToString();
            frmChiTietHoaDonNhapHang fr = new frmChiTietHoaDonNhapHang(id, User.UserName, false);
            fr.Show();
        }
        private void dgvNhapHang_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int r = dgvNhapHang.CurrentCell.RowIndex;
            string id = dgvNhapHang.Rows[r].Cells[0].Value.ToString();
            frmChiTietHoaDonNhapHang fr = new frmChiTietHoaDonNhapHang(id, User.UserName, false);
            fr.Show();
        }

        private void dgvNhapHang_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int r = dgvNhapHang.CurrentCell.RowIndex;
                txtboxMaHDNH.Text = dgvNhapHang.Rows[r].Cells[0].Value.ToString();
                txtboxMaNVNH.Text = dgvNhapHang.Rows[r].Cells[1].Value.ToString();
                dateTimePickerNgayNH.Value = Convert.ToDateTime((dgvNhapHang.Rows[r].Cells[2].Value.ToString()));
            }
            catch { }
        }
        private void btnThemHDNH_Click(object sender, EventArgs e)
        {
            try
            {
                frmChiTietHoaDonNhapHang frm = new frmChiTietHoaDonNhapHang(null, User.UserName, true);
                frm.Show();
                LoadNhapHang();
            }
            catch { }
            LoadNhapHang();
            LoadKhoHang();
        }
        private void btnXoaHDNH_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc muốn xóa dòng này không?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                HoaDonNhapHang hd = new HoaDonNhapHang();
                hd.MaHoaDonNH = txtboxMaHDNH.Text;
                hd.MaNV = txtboxMaNVNH.Text;
                hd.NgayNhapHang = dateTimePickerNgayNH.Value;
                try
                {
                    HoaDonNhapHangBUS.XoaHDNhap(hd);
                    MessageBox.Show("Xóa Thành Công!", "Thông Báo");
                    txtboxMaHDNH.Text = "";
                    txtboxMaNVNH.Text = "";
                    LoadNhapHang();
                }
                catch { MessageBox.Show("Không Thể Thực Hiện Thao Tác!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            }
        }

        #endregion

        #region NSX
        private void dgvHSX_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int r = dgvHSX.CurrentCell.RowIndex;
                textBoxMaHSX.Text = dgvHSX.Rows[r].Cells[0].Value.ToString();
                textBoxTenHSX.Text = dgvHSX.Rows[r].Cells[1].Value.ToString();
            }
            catch { }


        }

        private void btnLoadHSX_Click(object sender, EventArgs e)
        {
            try
            {
                hSXBindingSource.DataSource = HSXBUS.GetAllHSX();
            }
            catch { }
        }

        private void btnThemHSX_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBoxMaHSX.Text != "" && textBoxTenHSX.Text != "")
                {
                    HSX hsx = new HSX();
                    hsx.MaHSX = textBoxMaHSX.Text;
                    hsx.TenHSX = textBoxTenHSX.Text;
                    HSXBUS.ThemHSX(hsx);
                    MessageBox.Show("Thêm thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    hSXBindingSource.DataSource = HSXBUS.GetAllHSX();
                }
                else
                {
                    MessageBox.Show("Mã HSX hoặc Tên HSX Không Được Điền!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch { MessageBox.Show("Không Thể Thực Hiện Thao Tác!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void btnXoaHSX_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBoxMaHSX.Text != "")
                {
                    HSX hsx = new HSX();
                    hsx.MaHSX = textBoxMaHSX.Text;
                    hsx.TenHSX = textBoxTenHSX.Text;
                    HSXBUS.XoaHSX(hsx);
                    MessageBox.Show("Xóa thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    hSXBindingSource.DataSource = HSXBUS.GetAllHSX();
                }
                else
                {
                    MessageBox.Show("Mã HSX Không Được Điền!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch { MessageBox.Show("Không Thể Thực Hiện Thao Tác!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void btnNewHSX_Click(object sender, EventArgs e)
        {
            textBoxMaHSX.Text = "";
            textBoxTenHSX.Text = "";
        }

        private void btnEditHSX_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBoxMaHSX.Text != "" && textBoxTenHSX.Text != "")
                {
                    HSX hsx = new HSX();
                    hsx.MaHSX = textBoxMaHSX.Text;
                    hsx.TenHSX = textBoxTenHSX.Text;
                    HSXBUS.ChinhSua(hsx);
                    MessageBox.Show("Chỉnh Sửa thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    hSXBindingSource.DataSource = HSXBUS.GetAllHSX();
                }
                else
                {
                    MessageBox.Show("Mã HSX Không Được Điền!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch { MessageBox.Show("Không Thể Thực Hiện Thao Tác!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }
        #endregion

        #region TaiKhoan
        void LoadTK()
        {
            taiKhoanBindingSource.DataSource = TaiKhoanBUS.GetAllTK();
            comboBoxUser.DataSource = TaiKhoanBUS.GetAllTK();
            comboBoxUser.DisplayMember = "UserName";
            comboBoxUser.ValueMember = "UserName";
            comboBoxMaCHUser.DataSource = CuaHangBUS.GetAllCuaHang();
            comboBoxMaCHUser.DisplayMember = "TenCuaHang";
            comboBoxMaCHUser.ValueMember = "MaCuaHang";
            comboBoxLoaiTK.DataSource = LoaiTaiKhoanBUS.GetAllLoaiTaiKhoan();
            comboBoxLoaiTK.DisplayMember = "TenLoaiTK";
            comboBoxLoaiTK.ValueMember = "MaLoaiTK";
        }
        private bool IsNewTK = false;
        private void btnLoadTK_Click(object sender, EventArgs e)
        {
            LoadTK();
        }
        private void dgvTaiKhoan_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int r = dgvTaiKhoan.CurrentCell.RowIndex;
                comboBoxUser.SelectedValue = dgvTaiKhoan.Rows[r].Cells[0].Value.ToString();
                comboBoxMaCHUser.SelectedValue = dgvTaiKhoan.Rows[r].Cells[1].Value.ToString();
                textBoxLoaiTK.Text = dgvTaiKhoan.Rows[r].Cells[2].Value.ToString();
                comboBoxLoaiTK.SelectedValue = textBoxLoaiTK.Text;
            }
            catch { }
        }
        private void comboBoxUser_SelectedIndexChanged(object sender, EventArgs e)
        {

            try
            {
                if (IsNewTK == false)
                {
                    TaiKhoan tk = TaiKhoanBUS.Get1TK(comboBoxLoaiTK.SelectedValue.ToString());

                    comboBoxMaCHUser.SelectedValue = tk.MaCuaHang;
                    textBoxLoaiTK.Text = tk.MaLoaiTK;
                    comboBoxLoaiTK.SelectedValue = textBoxLoaiTK.Text;
                }
                else if (IsNewTK == true)

                {
                    NhanVien nv = NhanVienBUS.Get1NV(comboBoxUser.SelectedValue.ToString());
                    comboBoxMaCHUser.SelectedValue = nv.MaCuaHang;
                    textBoxLoaiTK.Text = nv.MaLoaiNV;
                    comboBoxLoaiTK.SelectedValue = textBoxLoaiTK.Text;
                }
            }
            catch { }
        }
        private void btnNewTK_Click(object sender, EventArgs e)
        {
            comboBoxLoaiTK.Visible = false;
            comboBoxUser.DataSource = NhanVienBUS.GetallNVWithoutAdmin();
            comboBoxUser.DisplayMember = "MaNV";
            comboBoxUser.ValueMember = "MaNV";
            IsNewTK = true;

        }
        private void btnThemTK_Click(object sender, EventArgs e)
        {
            try
            {
                TaiKhoan tk = new TaiKhoan();
                tk.UserName = comboBoxUser.SelectedValue.ToString();
                tk.MaCuaHang = comboBoxMaCHUser.SelectedValue.ToString();
                tk.Password = "123";
                tk.MaLoaiTK = textBoxLoaiTK.Text;
                TaiKhoanBUS.ThemTK(tk);
                MessageBox.Show("Thêm thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch
            {
                MessageBox.Show("Lỗi! Không thể thực hiện thao tác", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            LoadTK();
            comboBoxLoaiTK.Visible = true;
            IsNewTK = false;
        }

        private void btnXoaTK_Click(object sender, EventArgs e)
        {
            try
            {

                if (MessageBox.Show("Bạn Có Chắc Muốn Hủy Thao Tác Này Không?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                {
                    TaiKhoanBUS.XoaTK(comboBoxUser.SelectedValue.ToString());
                    MessageBox.Show("Xóa thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch
            {
                MessageBox.Show("Lỗi! Không thể thực hiện thao tác", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            LoadTK();
            comboBoxLoaiTK.Visible = true;
        }

        private void btnChinhSua_Click(object sender, EventArgs e)
        {
            try
            {
                if (comboBoxMaCHUser.SelectedValue.ToString() == "admin" && User.MaLoaiTK != "admin")
                {
                    MessageBox.Show("Lỗi! Tài Khoản Của Bạn Không Có Quyền Chọn Loại Tài Khoản Admin", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                TaiKhoan tk = TaiKhoanBUS.Get1TK(comboBoxUser.SelectedValue.ToString());
                //tk.UserName = comboBoxUser.SelectedValue.ToString();
                tk.MaCuaHang = comboBoxMaCHUser.SelectedValue.ToString();
                tk.MaLoaiTK = comboBoxMaCHUser.SelectedValue.ToString();
                TaiKhoanBUS.EditTk(tk);
                MessageBox.Show("Chỉnh Sửa Thành Công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch
            {
                MessageBox.Show("Lỗi! Không thể thực hiện thao tác", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            LoadTK();
            comboBoxLoaiTK.Visible = true;
        }
        private void btnDatLaiMK_Click(object sender, EventArgs e)
        {
            try
            {
                TaiKhoan tk = TaiKhoanBUS.Get1TK(comboBoxUser.SelectedValue.ToString());
                //tk.UserName = comboBoxUser.SelectedValue.ToString();
                //tk.MaCuaHang = comboBoxMaCHUser.SelectedValue.ToString();
                //tk.MaLoaiTK = textBoxLoaiTK.Text;
                tk.Password = "123";
                TaiKhoanBUS.EditTk(tk);
                MessageBox.Show("Đặt Lại Mật Khẩu Thành Công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch
            {
                MessageBox.Show("Lỗi! Không thể thực hiện thao tác", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            LoadTK();
            comboBoxLoaiTK.Visible = true;
        }
        #endregion


        #region
        private bool IsNewCH;
        void LoadCuaHang()
        {
            cmBoxMaCH.DataSource = CuaHangBUS.GetAllCuaHang();
            cmBoxMaCH.DisplayMember = "TenCuaHang";
            cmBoxMaCH.ValueMember = "MaCuaHang";
        }
        private void btnLoadCH_Click(object sender, EventArgs e)
        {
            LoadCuaHang();
        }
        private void cmBoxMaCH_SelectedIndexChanged(object sender, EventArgs e)
        {
            var ch = CuaHangBUS.GetThongTinCuaHang(cmBoxMaCH.SelectedValue.ToString());
            if (ch != null)
            {
                txtboxTenCuaHang.Text = ch.TenCuaHang;
                txtboxDiaChiCH.Text = ch.DiaChi;
                txtboxMaCH.Text = ch.MaCuaHang;
            }
        }
        private void btnThemCuaHang_Click(object sender, EventArgs e)
        {
            txtboxTenCuaHang.ReadOnly = false;
            txtboxDiaChiCH.ReadOnly = false;
            btnXoaCH.Visible = false;
            btnChinhSuaCH.Visible = false;
            btnThemCuaHang.Visible = false;
            cmBoxMaCH.Visible = false;

            btnLuuCuaHang.Visible = true;
            btnHuyLuuCuaHang.Visible = true;
            IsNewCH = true;

        }
        private void btnChinhSuaCH_Click(object sender, EventArgs e)
        {
            txtboxTenCuaHang.ReadOnly = false;
            txtboxDiaChiCH.ReadOnly = false;
            btnXoaCH.Visible = false;
            btnChinhSuaCH.Visible = false;
            btnThemCuaHang.Visible = false;

            btnLuuCuaHang.Visible = true;
            btnHuyLuuCuaHang.Visible = true;
            IsNewCH = false;
        }

        private void btnXoaCH_Click(object sender, EventArgs e)
        {
            try
            {

                CuaHang ch = new CuaHang();


                if (txtboxDiaChiCH.Text != "" && txtboxMaCH.Text != "")
                {
                    ch.DiaChi = txtboxDiaChiCH.Text;
                    ch.MaCuaHang = cmBoxMaCH.SelectedValue.ToString();
                    ch.TenCuaHang = txtboxTenCuaHang.Text;
                    CuaHangBUS.XoaCH(ch);
                    MessageBox.Show("Xóa thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Lỗi! Mã CH Hoặc Tên CH Không Được Điền", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
            catch
            {
                MessageBox.Show("Lỗi! Không thể thực hiện thao tác", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnLuuCuaHang_Click(object sender, EventArgs e)
        {
            //try
            //{
            CuaHang ch = new CuaHang();
            if (IsNewCH)
            {

                if (txtboxDiaChiCH.Text != "" && txtboxTenCuaHang.Text != "" && txtboxTenCuaHang.Text != "")
                {
                    ch.DiaChi = txtboxDiaChiCH.Text;
                    ch.MaCuaHang = txtboxMaCH.Text;
                    ch.TenCuaHang = txtboxTenCuaHang.Text;
                    CuaHangBUS.ThemCH(ch);
                    MessageBox.Show("Thêm Thành Công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Lỗi! Mã CH Hoặc Tên CH Không Được Điền", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {

                if (txtboxDiaChiCH.Text != "" && txtboxMaCH.Text != "")
                {
                    ch.DiaChi = txtboxDiaChiCH.Text;
                    ch.MaCuaHang = cmBoxMaCH.SelectedValue.ToString();
                    ch.TenCuaHang = txtboxTenCuaHang.Text;
                    CuaHangBUS.SuaCH(ch);
                    MessageBox.Show("Chỉnh Sửa Thành Công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Lỗi! Mã CH Hoặc Tên CH Không Được Điền", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }


            }
            //}
            //catch
            //{
            //    MessageBox.Show("Lỗi! Không thể thực hiện thao tác", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}
            LoadCuaHang();
            txtboxTenCuaHang.ReadOnly = true;
            txtboxDiaChiCH.ReadOnly = true;
            btnXoaCH.Visible = true;
            btnChinhSuaCH.Visible = true;
            btnThemCuaHang.Visible = true;
            cmBoxMaCH.Visible = true;

            btnLuuCuaHang.Visible = false;
            btnHuyLuuCuaHang.Visible = false;
            IsNewCH = false;
        }

        private void btnHuyLuuCuaHang_Click(object sender, EventArgs e)
        {

            txtboxTenCuaHang.ReadOnly = true;
            txtboxDiaChiCH.ReadOnly = true;
            btnXoaCH.Visible = true;
            btnChinhSuaCH.Visible = true;
            btnThemCuaHang.Visible = true;
            cmBoxMaCH.Visible = true;

            btnLuuCuaHang.Visible = false;
            btnHuyLuuCuaHang.Visible = false;
            IsNewCH = false;
        }
        #endregion
        #region TimKiem

        private void btnDongSearch_Click(object sender, EventArgs e)
        {
            txtboxTimKiem.Text = "";
        }
        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            string i = cmBoxTimKiemTheo.SelectedItem.ToString();

            if (i == "Dòng Sản Phẩm")
            {
                tabControlMainServer.SelectedTab = tabControlMainServer.TabPages[2];
                dongSanPhamBindingSource.DataSource = DongSanPhamBUS.TimKiemDongSP(txtboxTimKiem.Text);
            }
            else
                if (i == "Nhân Viên")
            {
                if (MaTruyCap == 2)
                    tabControlMainServer.SelectedTab = tabControlMainServer.TabPages[0];
                else
                    tabControlMainServer.SelectedTab = tabControlMainServer.TabPages[4];
                nhanVienBindingSource.DataSource = NhanVienBUS.TimKiemNV(txtboxTimKiem.Text);
            }
            else if (i == "Sản Phẩm")
            {
                tabControlMainServer.SelectedTab = tabControlMainServer.TabPages[1];
                sanPhamBindingSource.DataSource = SanPhamBUS.TimKiemSP(txtboxTimKiem.Text);
            }
            else if (i == "Nhà Sản Xuất")
            {
                tabControlMainServer.SelectedTab = tabControlMainServer.TabPages[3];
                hSXBindingSource.DataSource = HSXBUS.TimKiemHSX(txtboxTimKiem.Text);
            }
            else if (i == "Hóa Đơn Nhập")
            {
                if (MaTruyCap == 1)
                    tabControlMainServer.SelectedTab = tabControlMainServer.TabPages[4];
                else
                    tabControlMainServer.SelectedTab = tabControlMainServer.TabPages[8];
                hoaDonNhapHangBindingSource.DataSource = HoaDonNhapHangBUS.TimKiemHDNhap(txtboxTimKiem.Text);
            }
        }

        private void cmBoxTimKiemTheo_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtboxTimKiem.Text = "";
        }
        private void txtboxTimKiem_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string i = cmBoxTimKiemTheo.SelectedItem.ToString();

                if (i == "Dòng Sản Phẩm")
                {
                    tabControlMainServer.SelectedTab = tabControlMainServer.TabPages[2];
                    dongSanPhamBindingSource.DataSource = DongSanPhamBUS.TimKiemDongSP(txtboxTimKiem.Text);
                }
                else
                    if (i == "Nhân Viên")
                {
                    if (MaTruyCap == 2)
                        tabControlMainServer.SelectedTab = tabControlMainServer.TabPages[0];
                    else
                        tabControlMainServer.SelectedTab = tabControlMainServer.TabPages[4];
                    nhanVienBindingSource.DataSource = NhanVienBUS.TimKiemNV(txtboxTimKiem.Text);
                }
                else if (i == "Sản Phẩm")
                {
                    tabControlMainServer.SelectedTab = tabControlMainServer.TabPages[1];
                    sanPhamBindingSource.DataSource = SanPhamBUS.TimKiemSP(txtboxTimKiem.Text);
                }
                else if (i == "Nhà Sản Xuất")
                {
                    tabControlMainServer.SelectedTab = tabControlMainServer.TabPages[3];
                    hSXBindingSource.DataSource = HSXBUS.TimKiemHSX(txtboxTimKiem.Text);
                }
                else if (i == "Hóa Đơn Nhập")
                {
                    if (MaTruyCap == 1)
                        tabControlMainServer.SelectedTab = tabControlMainServer.TabPages[4];
                    else
                        tabControlMainServer.SelectedTab = tabControlMainServer.TabPages[8];
                    hoaDonNhapHangBindingSource.DataSource = HoaDonNhapHangBUS.TimKiemHDNhap(txtboxTimKiem.Text);
                }
            }
            catch { MessageBox.Show("Bạn Chưa Chọn Đối Tượng Tìm Kiếm!"); }
        }
        #endregion
        #region tras
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












        #endregion

        private void btnloadtksp_Click(object sender, EventArgs e)
        {
            string id = comboBoxTKSP.SelectedValue.ToString();
            try
            {
                string i = comboBoxTKTheoThoiGian.SelectedItem.ToString();

                if (i == "Trong ngày")
                {
                   
                    chart1.DataSource = thongkea.SPBanTrongNgay(id, dateTimePickerTrongNgay.Value);
                }
                else
                    if (i == "Theo tháng")
                {
                    try
                    {
                       
                        DateTime date = new DateTime(dateTimePickerTheoThang.Value.Year, dateTimePickerTheoThang.Value.Month, 1);

                        chart1.DataSource = thongkea.SPBanTheoTG(id, date, date.AddMonths(1).AddDays(-1));
                    }
                    catch { }
                }

                else if (i == "Trong quý")
                {
                  
                    string ids = comboBoxQuy.SelectedItem.ToString();
                    if (ids == null)
                        return;
                    if (ids == "Quý I")
                    {
                        DateTime date1 = new DateTime(dateTimePickerNam.Value.Year, 1, 1);
                        DateTime date2 = new DateTime(dateTimePickerNam.Value.Year, 3, 31);
                        chart1.DataSource = thongkea.SPBanTheoTG(id, date1, date2);
                    }
                    else
                        if (ids == "Quý II")
                    {
                        DateTime date1 = new DateTime(dateTimePickerNam.Value.Year, 4, 1);
                        DateTime date2 = new DateTime(dateTimePickerNam.Value.Year, 6, 30);
                        chart1.DataSource = thongkea.SPBanTheoTG(id, date1, date2);
                    }
                    else
                        if (ids == "Quý III")
                    {
                        DateTime date1 = new DateTime(dateTimePickerNam.Value.Year, 7, 1);
                        DateTime date2 = new DateTime(dateTimePickerNam.Value.Year, 9, 30);
                        chart1.DataSource = thongkea.SPBanTheoTG(id, date1, date2);
                    }
                    else
                        if (ids == "Quý VI")
                    {
                        DateTime date1 = new DateTime(dateTimePickerNam.Value.Year, 10, 1);
                        DateTime date2 = new DateTime(dateTimePickerNam.Value.Year, 12, 31);
                        chart1.DataSource = thongkea.SPBanTheoTG(id, date1, date2);
                    }

                }

            }
            catch { MessageBox.Show("Bạn Chưa Chọn Đối Tượng Tìm Kiếm!"); return; }
           
            chart1.ChartAreas[0].AxisY.Title = "Số lượng";
            chart1.ChartAreas[0].AxisX.Title = "Tên sản phẩm";
            chart1.Series["Số lượng"].XValueMember = "TenSP";
            chart1.Series["Số lượng"].XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.String;
            chart1.Series["Số lượng"].YValueMembers = "SoLuong";
            chart1.Series["Số lượng"].YValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Int32;
        }

        private void comboBoxTKTheoThoiGian_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                string i = comboBoxTKTheoThoiGian.SelectedItem.ToString();

                if (i == "Trong ngày")
                {
                    dateTimePickerTrongNgay.Visible = true;
                    dateTimePickerNam.Visible = false;
                    dateTimePickerTheoThang.Visible = false;
                    comboBoxQuy.Visible = false;

                }
                else
                    if (i == "Theo tháng")
                {
                    dateTimePickerTrongNgay.Visible = false;
                    dateTimePickerNam.Visible = false;
                    dateTimePickerTheoThang.Visible = true;
                    comboBoxQuy.Visible = false;
                    DateTime d= new DateTime(dateTimePickerTheoThang.Value.Year, dateTimePickerTheoThang.Value.Month, 1);
                    dateTimePickerTheoThang.Value = d;

                }

                else if (i == "Trong quý")
                {
                    dateTimePickerTrongNgay.Visible = false;
                    dateTimePickerNam.Visible = true;
                    dateTimePickerTheoThang.Visible = false;
                    comboBoxQuy.Visible = true;


                }
            }
            catch { }
        }
    }
}

