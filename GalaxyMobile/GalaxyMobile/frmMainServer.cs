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
        private void btnLSP_Click(object sender, EventArgs e)
        {
            Form frm = new frmLoaiSP();
            frm.ShowDialog();
        }
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
  
        #region Thongke(tabControllHere)

        private void tabControlMainServer_Selected(object sender, TabControlEventArgs e)
        {
            // Hiện biểu đồ 
            chart1.DataSource = ThongKeBUS.getProductSale(User.MaCuaHang);
            chart1.ChartAreas[0].AxisY.Title = "Số lượng";
            chart1.ChartAreas[0].AxisX.Title = "Tên sản phẩm";
            chart1.Series["Series1"].XValueMember = "TenSP";
            chart1.Series["Series1"].XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.String;
            chart1.Series["Series1"].YValueMembers = "SoLuong";
            chart1.Series["Series1"].YValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Int32;
            // hiện dữ liệu hóa đơn tất cả.
            LoadHD();
            LoadButtonHD();
        }
        #endregion
        #region Hoa Don
        bool ThemHD = false;
        private void btnLuuHD_Click(object sender, EventArgs e)
        {
            if (Them)
            {
                try
                {
                    HoaDon hd = new HoaDon();
                    hd.MaHoaDon = txtMaHD.Text;
                    hd.MaKH = cboKhachHangHD.SelectedValue.ToString();
                    hd.MaNV = cboNhanVienHD.SelectedValue.ToString();
                    hd.MaCuaHang = cboCuaHangHD.SelectedValue.ToString();
                    hd.TinhTrang = int.Parse(txtTinhTrangHD.Text);
                    hd.HTGiaoHang = txtHinhThucGH.Text;
                    hd.NgayLapHD = DatePickerHD.Value.Date;
                    HoaDonBUS.ThemHD(hd);
                    LoadHD();
                    LoadButtonHD();
                    // Thông báo 
                    MessageBox.Show("Đã thêm xong!");
                }
                catch
                {
                    MessageBox.Show("Mã hóa đơn tồn tại không thể thêm !");
                    txtMaHD.ResetText();
                    cboKhachHangHD.ResetText();
                    cboNhanVienHD.ResetText();
                    cboCuaHangHD.ResetText();
                    txtTinhTrangHD.ResetText();
                    txtHinhThucGH.ResetText();

                }
            }
            else
            {
                HoaDon hd = new HoaDon();
                hd.MaHoaDon = txtMaHD.Text;
                hd.MaKH = cboKhachHangHD.SelectedValue.ToString();
                hd.MaNV = cboNhanVienHD.SelectedValue.ToString();
                hd.MaCuaHang = cboCuaHangHD.SelectedValue.ToString();
                hd.TinhTrang = int.Parse(txtTinhTrangHD.Text);
                hd.HTGiaoHang = txtHinhThucGH.Text;
                hd.NgayLapHD = DatePickerHD.Value.Date;
                HoaDonBUS.ChinhSuaHD(hd);
                LoadHD();
                LoadButtonHD();
                // Thông báo 
                MessageBox.Show("Đã sửa xong!");
            }
        }

        private void btnXoaHD_Click(object sender, EventArgs e)
        {
            try
            {
                HoaDon hd = new HoaDon();
                hd.MaHoaDon = txtMaHD.Text;
                hd.MaKH = cboKhachHangHD.SelectedValue.ToString();
                hd.MaNV = cboNhanVienHD.SelectedValue.ToString();
                hd.MaCuaHang = cboCuaHangHD.SelectedValue.ToString();
                hd.TinhTrang = int.Parse(txtTinhTrangHD.Text);
                hd.HTGiaoHang = txtHinhThucGH.Text;
                hd.NgayLapHD = DatePickerHD.Value.Date;
                HoaDonBUS.XoaHD(hd);
                //hd.GiaoHang = txtHinhThucGH.Text;
                //LoaiNvBUS.XoaLNV(strMaLNV);
                LoadHD();
                LoadButtonHD();
                dgvHoaDon_CellClick(null, null);
                MessageBox.Show("Đã xóa xong!");
        }
            catch
            {
                MessageBox.Show("Không được phép xóa nhân viên này");
            }
}

        private void btnThemHD_Click(object sender, EventArgs e)
        {
            ThemHD = true;
            txtMaHD.Enabled = true;
            // Xóa trống các đối tượng trong Panel 
            txtMaHD.ResetText();
            cboKhachHangHD.ResetText();
            cboNhanVienHD.ResetText();
            cboCuaHangHD.ResetText();
            txtTinhTrangHD.ResetText();
            txtHinhThucGH.ResetText();
            // Cho thao tác trên các nút Lưu / Hủy / Panel 
            btnLuuHD.Enabled = true;
            btnHuyHD.Enabled = true;
            panelHD.Enabled = true;
            // Không cho thao tác trên các nút Thêm / Xóa / Thoát 
            btnThemHD.Enabled = false;
            btnSuaHD.Enabled = false;
            btnXoaHD.Enabled = false;
            txtMaHD.Focus();
        }

        private void btnSuaHD_Click(object sender, EventArgs e)
        {
            // Kích hoạt biến Sửa
            ThemHD = false;
            dgvHoaDon_CellClick(null, null);
            // Cho phép thao tác trên Panel 
            panelHD.Enabled = true;
            // Cho thao tác trên các nút Lưu / Hủy / Panel 
            btnLuuHD.Enabled = true;
            btnHuyHD.Enabled = true;
            // Không cho thao tác trên các nút Thêm / Xóa / Thoát 
            btnThemHD.Enabled = false;
            btnSuaHD.Enabled = false;
            btnXoaHD.Enabled = false;
            // Đưa con trỏ đến TextField txtTenNV         
            txtMaHD.Enabled = false;
          
        }

        private void btnHuyHD_Click(object sender, EventArgs e)
        {
            // Xóa trống các đối tượng trong Panel 
            txtMaHD.ResetText();
            cboKhachHangHD.ResetText();
            cboNhanVienHD.ResetText();
            cboCuaHangHD.ResetText();
            txtTinhTrangHD.ResetText();
            txtHinhThucGH.ResetText();
            // Cho thao tác trên các nút Thêm / Sửa / Xóa / Thoát 
            btnThemHD.Enabled = true;
            btnSuaHD.Enabled = true;
            btnXoaHD.Enabled = true;
            // Không cho thao tác trên các nút Lưu / Hủy / Panel 
            btnLuuHD.Enabled = false;
            btnHuyHD.Enabled = false;
            panelHD.Enabled = false;
        }
        private void dgvHoaDon_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int r = dgvHoaDon.CurrentCell.RowIndex;
            cboKhachHangHD.DataSource = KHBUS.GetKH();
            cboKhachHangHD.DisplayMember = "TenKH";
            cboKhachHangHD.ValueMember = "MaKH";
            cboNhanVienHD.DataSource = NhanVienBUS.GetNV();
            cboNhanVienHD.DisplayMember = "TenNV";
            cboNhanVienHD.ValueMember = "MaNV";
            cboCuaHangHD.DataSource= CuaHangBUS.GetAllCuaHang();
            cboCuaHangHD.DisplayMember = "TenCuaHang";
            cboCuaHangHD.ValueMember = "MaCuaHang";
            //mapping
            txtMaHD.Text= dgvHoaDon.Rows[r].Cells[0].Value.ToString();
            cboKhachHangHD.SelectedValue= dgvHoaDon.Rows[r].Cells[1].Value.ToString();
            cboNhanVienHD.SelectedValue= dgvHoaDon.Rows[r].Cells[2].Value.ToString();
            cboCuaHangHD.SelectedValue= dgvHoaDon.Rows[r].Cells[3].Value.ToString();
            txtTinhTrangHD.Text= dgvHoaDon.Rows[r].Cells[4].Value.ToString();
            txtHinhThucGH.Text= dgvHoaDon.Rows[r].Cells[5].Value.ToString();
            DatePickerHD.Text= dgvHoaDon.Rows[r].Cells[6].Value.ToString();
        }
        private void cboHDbyMonth_TextChanged(object sender, EventArgs e)
        {
            string thang = ((KeyValuePair<string, string>)cboHDbyMonth.SelectedItem).Key;
            if (int.Parse(thang) == 0)
            {
                hoaDonBindingSource.DataSource = HoaDonBUS.GetAllHoaDon();
                dgvHoaDon_CellClick(null, null);
            }
            else
            {
                try
                {
                    hoaDonBindingSource.DataSource = HoaDonBUS.GetHoaDonTheoThang(int.Parse(thang));
                    dgvHoaDon_CellClick(null, null);
                }
                catch
                {
                    txtMaHD.ResetText();
                    cboKhachHangHD.ResetText();
                    cboNhanVienHD.ResetText();
                    cboCuaHangHD.ResetText();
                    txtTinhTrangHD.ResetText();
                    txtHinhThucGH.ResetText();
                }
            }
        }
        public void LoadButtonHD()
        {
           
            txtMaHD.ResetText();
            cboKhachHangHD.ResetText();
            cboNhanVienHD.ResetText();
            cboCuaHangHD.ResetText();
            txtTinhTrangHD.ResetText();
            txtHinhThucGH.ResetText();
            // Không cho thao tác trên các nút Lưu / Hủy 
            btnLuuHD.Enabled = false;
            btnHuyHD.Enabled = false;
            panelHD.Enabled = false;
            // Cho thao tác trên các nút Thêm / Sửa / Xóa / Thoát 
            btnThemHD.Enabled = true;
            btnSuaHD.Enabled = true;
            btnXoaHD.Enabled = true;
            dgvHoaDon_CellClick(null, null);
        }
        public void LoadHD()
        {
            // tạo dictionary chứa value and key cho combo box 
            Dictionary<string,string > combosource = new Dictionary<string, string>();
            combosource.Add("0", "Tất cả");
            combosource.Add("1", "Tháng 1");
            combosource.Add("2", "Tháng 2");
            combosource.Add("3", "Tháng 3");
            combosource.Add("4", "Tháng 4");
            combosource.Add("5", "Tháng 5");
            combosource.Add("6", "Tháng 6");
            combosource.Add("7", "Tháng 7");
            combosource.Add("8", "Tháng 8");
            combosource.Add("9", "Tháng 9");
            combosource.Add("10", "Tháng 10");
            combosource.Add("11", "Tháng 11");
            combosource.Add("12", "Tháng 12");
            cboHDbyMonth.DataSource = new BindingSource(combosource,null);
            cboHDbyMonth.DisplayMember = "Value";
            cboHDbyMonth.ValueMember = "Key";
            string key = ((KeyValuePair<string, string>)cboHDbyMonth.SelectedItem).Key;
            string value = ((KeyValuePair<string, string>)cboHDbyMonth.SelectedItem).Key;
            hoaDonBindingSource.DataSource = HoaDonBUS.GetAllHoaDon();
            dgvHoaDon_CellClick(null, null);

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

        #region NSX
        bool ThemNSX = false;
        public void LoadNSX()
        {
            hSXBindingSource.DataSource = HSXBUS.GetAllHSX();
            txtMaNSX.ResetText();
            txtTenNSX.ResetText();
            // Không cho thao tác trên các nút Lưu / Hủy 
            btnLuuNSX.Enabled = false;
            btnHuyNSX.Enabled = false;
            panelNSX.Enabled = false;
            // Cho thao tác trên các nút Thêm / Sửa / Xóa / Thoát 
            btnThemNSX.Enabled = true;
            btnSuaNSX.Enabled = true;
            btnXoaNSX.Enabled = true;
        }
        private void btnThemNSX_Click(object sender, EventArgs e)
        {
            ThemNSX = true;
            txtMaNSX.Enabled = true;
            // Xóa trống các đối tượng trong Panel 
            txtMaNSX.ResetText();
            txtTenNSX.ResetText();
            // Cho thao tác trên các nút Lưu / Hủy / Panel 
            btnLuuNSX.Enabled = true;
            btnHuyNSX.Enabled = true;
            panelNSX.Enabled = true;
            // Không cho thao tác trên các nút Thêm / Xóa / Thoát 
            btnThemNSX.Enabled = false;
            btnSuaNSX.Enabled = false;
            btnXoaNSX.Enabled = false;
            txtMaNSX.Focus();
        }
        private void btnSuaNSX_Click(object sender, EventArgs e)
        {
            // Kích hoạt biến Sửa
            ThemNSX = false;
            dgvNSX_CellClick(null, null);
            
            // Cho phép thao tác trên Panel 
            panelNSX.Enabled = true;
            // Cho thao tác trên các nút Lưu / Hủy / Panel 
            btnLuuNSX.Enabled = true;
            btnHuyNSX.Enabled = true;
            // Không cho thao tác trên các nút Thêm / Xóa / Thoát 
            btnThemNSX.Enabled = false;
            btnSuaNSX.Enabled = false;
            btnXoaNSX.Enabled = false;
            // Đưa con trỏ đến TextField txtTenNV         
            txtMaNSX.Enabled = false;
            txtTenNSX.Focus();
        }

        private void btnXoaNSX_Click(object sender, EventArgs e)
        {
            try
            {
               
                HSX a = new HSX();
                a.MaHSX = txtMaNSX.Text;
                a.TenHSX = txtTenNSX.Text;
                HSXBUS.XoaHSX(a);
                LoadNSX();
                dgvNSX_CellClick(null, null);
                MessageBox.Show("Đã xóa xong!");
            }
            catch
            {
                MessageBox.Show("Không được phép xóa nhà sản xuất này");
            }
        }

        private void btnHuyNSX_Click(object sender, EventArgs e)
        {
            txtMaNSX.ResetText();
            txtTenNSX.ResetText();
            // Không cho thao tác trên các nút Lưu / Hủy 
            btnLuuNSX.Enabled = false;
            btnHuyNSX.Enabled = false;
            panelNSX.Enabled = false;
            // Cho thao tác trên các nút Thêm / Sửa / Xóa / Thoát 
            btnThemNSX.Enabled = true;
            btnSuaNSX.Enabled = true;
            btnXoaNSX.Enabled = true;
        }

        private void btnLuuNSX_Click(object sender, EventArgs e)
        {
            if (ThemNSX)
            {
                
                try
                {
                    HSX a = new HSX();
                    a.MaHSX = txtMaNSX.Text;
                    a.TenHSX = txtTenNSX.Text;
                    HSXBUS.ThemHSX(a);
                    LoadNSX();
                    // Thông báo 
                    MessageBox.Show("Đã thêm xong!");
                }
            catch
                  {
                MessageBox.Show("Mã nhà sản xuất tồn tai. Nhập Mã nhân viên khác !");
                txtMaNSX.ResetText();
                txtTenNSX.ResetText();
                txtMaNSX.Focus();
                 }
            }
            else
            {
                HSX a = new HSX();
                a.TenHSX = txtTenNSX.Text;
                a.MaHSX = txtMaNSX.Text;
                HSXBUS.ChinhSuaHXS(a);
                LoadNSX();
                // Thông báo 
                MessageBox.Show("Đã sửa xong!");
            }
        }
        private void btnLoadNSX_Click(object sender, EventArgs e)
        {
            LoadNSX();
            dgvNSX_CellClick(null, null);
        }
        private void dgvNSX_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int r = dgvNSX.CurrentCell.RowIndex;
            txtMaNSX.Text = dgvNSX.Rows[r].Cells[0].Value.ToString();
            txtTenNSX.Text = dgvNSX.Rows[r].Cells[1].Value.ToString();

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

       
    }
}
