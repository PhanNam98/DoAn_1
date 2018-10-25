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
        public frmChiTietHoaDonNhapHang(string idHd, string manv, bool isChange)
        {
            InitializeComponent();
            IDHDNH = idHd;
            IsChange = isChange;
            MaNV = manv;
        }
        private string IDHDNH;//null if add
        private HoaDonNhapHang hdn;
        private bool IsChange;// true Add new, Edit
        private string MaNV;
        private bool Luu = false;
        private void frmChiTietHoaDonNhapHang_Load(object sender, EventArgs e)
        {
            if (IsChange == true)
            {
                btnLuuThongTInHD.Visible = true;
                btnHuyThongTinHD.Visible = true;
                //btnLuuSPHDNH.Visible = true;
                btnThemSPHDNH.Visible = true;
                btnXoaSPHDNH.Visible = true;
                btnSuaSPHDNH.Visible = true;
                numUpDownSLNhap.Visible = true;
                // btnHuySPHDNH.Visible = true;
            }
            else
            {
                Luu = true;
                
            }
            LoadCTHDNH();
            LoadComboBox();
        }
        #region methods
        void LoadCTHDNH()
        {
            try
            {
                chiTietHDNhapHangBindingSource.DataSource = ChiTietHoaDonNhapHangBUS.GetAllSanPham(IDHDNH);
                hdn = HoaDonNhapHangBUS.GetGetHoaDonNhapByID(IDHDNH);
                txtBoxMaHDNH.Text = hdn.MaHoaDonNH;
                txtBoxMaNVNH.Text = hdn.MaNV;
                dateNhapHang.Value = hdn.NgayNhapHang;
                lbTongTien.Text = ChiTietHoaDonNhapHangBUS.TinhTien_ByMaHD(txtBoxMaHDNH.Text).ToString();
            }
            catch { }


        }
        void LoadComboBox()
        {
            cmBoxDSP.DataSource = DongSanPhamBUS.GetAllDongSP();
            cmBoxDSP.DisplayMember = "TenDong";
            cmBoxDSP.ValueMember = "MaDSP";
            cmBoxNSX.DataSource = HSXBUS.GetAllHSX();
            cmBoxNSX.ValueMember = "MaHSX";
            cmBoxNSX.DisplayMember = "TenHSX";
            cmBoxLoaiSP.DataSource = LoaiSPBUS.GetAllLoaiSP();
            cmBoxLoaiSP.DisplayMember = "TenLSP";
            cmBoxLoaiSP.ValueMember = "MaLSP";
            comboBoxNoiNhapHang.DataSource = CuaHangBUS.GetAllCuaHang();
            comboBoxNoiNhapHang.DisplayMember = "TenCuaHang";
            comboBoxNoiNhapHang.ValueMember = "MaCuaHang";
            comboBoxNoiNhapHang.SelectedValue = "ts";
            if (IDHDNH == null)
            {
                //txtboxHSX.Visible = false;
                //txtBoxLSP.Visible = false;
                //txtBoxDSP.Visible = false;
                //txtboxGiaBan.Visible = false;
                //txtBoxKieuSP.Visible = false;
                //txtboxSP.Visible = false;
                txtBoxMaHDNH.ReadOnly = false;
                txtBoxMaNVNH.Text = MaNV;
                groupBox2.Enabled = false;
                //txtboxGiaBan.ReadOnly = false;
                //txtboxGiaNhap.ReadOnly = false;
                //txtboxGiaBan.Visible = true;

            }
        }
        #endregion

        #region events
        private void dgvNhapHang_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {

                txtboxHSX.Visible = true;
                txtBoxLSP.Visible = true;
                txtBoxDSP.Visible = true;
                txtboxGiaBan.Visible = true;
                txtBoxKieuSP.Visible = true;
                txtboxSP.Visible = true;



                txtboxGiaBan.ReadOnly = true;
                txtboxGiaNhap.ReadOnly = true;
                txtboxGiaBan.Visible = true;

                int r = dgvNhapHang.CurrentCell.RowIndex;
                string id = dgvNhapHang.Rows[r].Cells[0].Value.ToString();
                USP_GETAllInfoSPNew_Result sp = ChiTietSPBUS.GetMaSPByMaKieuSP(id);
                txtboxHSX.Text = sp.TenHSX;
                txtBoxLSP.Text = sp.TenLSP;
                txtBoxDSP.Text = sp.TenDong;
                txtboxGiaBan.Text = sp.Gia.ToString();
                txtBoxSLTon.Text = sp.SoluongSP.ToString();
                txtBoxKieuSP.Text = sp.MaKieu;
                txtboxSP.Text = sp.TenSP;
                txtboxGiaNhap.Text = dgvNhapHang.Rows[r].Cells[2].Value.ToString();
                textBoxSLNhap.Text = dgvNhapHang.Rows[r].Cells[1].Value.ToString();





            }
            catch { }
        }
        private void btnLuuThongTInHD_Click(object sender, EventArgs e)
        {
            try
            {
                HoaDonNhapHang hd = new HoaDonNhapHang();
                hd.MaHoaDonNH = txtBoxMaHDNH.Text;
                hd.NgayNhapHang = dateNhapHang.Value;
                hd.MaNV = MaNV;
                HoaDonNhapHangBUS.ThemHDNhap(hd);
                MessageBox.Show("Thêm Thành Công!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadCTHDNH();
                groupBox2.Enabled = true;
                btnLuuFullHDNhap.Visible = true;
                btnHuyFullHDN.Visible = true;
                btnLuuThongTInHD.Visible = false;
                btnHuyThongTinHD.Visible = false;
            }
            catch
            {
                MessageBox.Show("Không Thể Thực Hiện Thao Tác!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

        }

        #endregion

        private void cmBoxNSX_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                cmBoxDSP.DataSource = null;
                string id = cmBoxNSX.SelectedValue.ToString();
                cmBoxDSP.DataSource = DongSanPhamBUS.GetAllDongSPByMaHSX(id);
                cmBoxDSP.DisplayMember = "TenDong";
                cmBoxDSP.ValueMember = "MaDSP";
            }
            catch { }
        }

        private void cmBoxLoaiSP_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                cmBoxDSP.DataSource = null;
                string id = cmBoxNSX.SelectedValue.ToString();
                string idloai = cmBoxLoaiSP.SelectedValue.ToString();

                if (DongSanPhamBUS.GetAllDongSPByMaHSXAndMaLoai(id, idloai).Count != 0)
                {
                    cmBoxDSP.DataSource = DongSanPhamBUS.GetAllDongSPByMaHSXAndMaLoai(id, idloai);
                    cmBoxDSP.DisplayMember = "TenDong";
                    cmBoxDSP.ValueMember = "MaDSP";
                }
                else
                    cmBoxDSP.DataSource = null;
            }
            catch { cmBoxDSP.DataSource = null; }
        }

        private void cmBoxDSP_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                cmBoxSP.DataSource = null;
                string id = cmBoxDSP.SelectedValue.ToString();


                if (SanPhamBUS.GetSanPhamByMaDSP(id).Count != 0)
                {
                    cmBoxSP.DataSource = SanPhamBUS.GetSanPhamByMaDSP(id);
                    cmBoxSP.DisplayMember = "TenSP";
                    cmBoxSP.ValueMember = "MaSP";
                }
                else
                    cmBoxSP.DataSource = null;
            }
            catch { cmBoxSP.DataSource = null; }
        }

        private void cmBoxSP_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {

                string id = cmBoxSP.SelectedValue.ToString();


                if (ChiTietSPBUS.GetChiTietSPByIDSP(id).Count != 0)
                {
                    cmBoxKieuSP.DataSource = ChiTietSPBUS.GetChiTietSPByIDSP(id);
                    cmBoxKieuSP.DisplayMember = "MaKieu";
                    cmBoxKieuSP.ValueMember = "MaKieu";
                }
                else
                    cmBoxKieuSP.DataSource = null;
            }
            catch { cmBoxKieuSP.DataSource = null; }
        }

        private void cmBoxKieuSP_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {

                string id = cmBoxKieuSP.SelectedValue.ToString();

                ChiTietSP ct = ChiTietSPBUS.Get1ChiTietSPByIDMaKieu(id);
                if (ct != null)
                {
                    txtBoxSLTon.Text = ct.SoluongSP.ToString();
                    txtboxGiaBan.Text = ct.Gia.ToString();
                }
                else
                {
                    txtBoxSLTon.Text = "";
                    txtboxGiaBan.Text = "";
                }

            }
            catch
            {
                txtBoxSLTon.Text = "";
                txtboxGiaBan.Text = "";
            }
        }

        private void btnThemDSP_Click(object sender, EventArgs e)
        {

        }

        private void btnThemSP_Click(object sender, EventArgs e)
        {
            frmChiTietSanPham ctsp = new frmChiTietSanPham(null, "ts", null, false);
            ctsp.ShowDialog();

        }
        private bool IsAddSP;
        private void btnThemSPHDNH_Click(object sender, EventArgs e)
        {
            txtboxHSX.Visible = false;
            txtBoxLSP.Visible = false;
            txtBoxDSP.Visible = false;
            txtboxGiaBan.Visible = false;
            txtBoxKieuSP.Visible = false;
            txtboxSP.Visible = false;
            txtboxGiaBan.ReadOnly = true;


            txtboxGiaBan.ReadOnly = false;
            txtboxGiaNhap.ReadOnly = false;


            txtboxHSX.Visible = false;
            txtBoxLSP.Visible = false;
            txtBoxDSP.Visible = false;
            txtboxGiaBan.Visible = false;
            txtBoxKieuSP.Visible = false;
            txtboxSP.Visible = false;
            txtboxGiaBan.ReadOnly = false;
            txtboxGiaNhap.ReadOnly = false;
            txtboxGiaBan.Visible = true;

            btnLuuSPHDNH.Visible = true;
            btnHuySPHDNH.Visible = true;
            btnSuaSPHDNH.Visible = false;
            btnXoaSPHDNH.Visible = false;
            btnThemSPHDNH.Visible = false;
            IsAddSP = true;

            textBoxSLNhap.Text = "";
            txtBoxSLTon.Text = "";
            txtboxGiaBan.Text = "";
            txtboxGiaNhap.Text = "";
            cmBoxSP.DataSource = null;
            cmBoxKieuSP.DataSource = null;
        }

        private void numUpDownSLNhap_ValueChanged(object sender, EventArgs e)
        {
            //textBoxSLNhap.Text = numUpDownSLNhap.Value.ToString();
        }

        private void btnHuySPHDNH_Click(object sender, EventArgs e)
        {
            btnLuuSPHDNH.Visible = false;
            btnHuySPHDNH.Visible = false;
            btnSuaSPHDNH.Visible = true;
            btnXoaSPHDNH.Visible = true;
            btnThemSPHDNH.Visible = true;
            txtboxGiaBan.ReadOnly = true;
        }

        private void btnLuuSPHDNH_Click(object sender, EventArgs e)
        {
            try
            {
                if (IsAddSP)
                {
                    ChiTietHDNhapHang ct = new ChiTietHDNhapHang();
                    ct.MaHoaDonNH = txtBoxMaHDNH.Text;
                    ct.MaKieu = cmBoxKieuSP.SelectedValue.ToString();
                    ct.SoLuongNhap = Convert.ToInt32(numUpDownSLNhap.Value);
                    ct.GiaNSX = Convert.ToDecimal(txtboxGiaNhap.Text);
                    ChiTietHDNhapHang ct1 = ChiTietHoaDonNhapHangBUS.KiemTRaTonTaiSPinCTNH(ct.MaHoaDonNH, ct.MaKieu);
                    if (ct1 == null)
                    {
                        ChiTietHoaDonNhapHangBUS.ThemSPintoCTNH(ct);
                    }
                    else
                    {
                        if (ct1.GiaNSX == ct.GiaNSX)
                        {
                            ct.SoLuongNhap += ct1.SoLuongNhap;
                            ChiTietHoaDonNhapHangBUS.ThayDoiSLNhap(ct);
                            
                        }
                        else { MessageBox.Show("Sản Phẩm Có Trong Hóa Đơn Có Giá Khác Giá Bạn Nhập", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning); }
                    }
                }
                else
                {
                    ChiTietHDNhapHang ct = new ChiTietHDNhapHang();
                    ct.MaHoaDonNH = txtBoxMaHDNH.Text;
                    ct.MaKieu = cmBoxKieuSP.SelectedValue.ToString();
                    ct.SoLuongNhap = Convert.ToInt32(numUpDownSLNhap.Value) + Convert.ToInt32(textBoxSLNhap.Text);
                    ct.GiaNSX = Convert.ToDecimal(txtboxGiaNhap.Text);
                    ChiTietHoaDonNhapHangBUS.ThayDoiSLNhap(ct);
                    
                }
                txtboxHSX.Visible = true;
                txtBoxLSP.Visible = true;
                txtBoxDSP.Visible = true;
                txtboxGiaBan.Visible = true;
                txtBoxKieuSP.Visible = true;
                txtboxSP.Visible = true;
                lbTongTien.Text = ChiTietHoaDonNhapHangBUS.TinhTien_ByMaHD(txtBoxMaHDNH.Text).ToString();
                Clear();

            }
            catch { MessageBox.Show("Không Thể Thực Hiện Thao Tác", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            btnLuuSPHDNH.Visible = false;
            btnHuySPHDNH.Visible = false;
            btnSuaSPHDNH.Visible = true;
            btnXoaSPHDNH.Visible = true;
            btnThemSPHDNH.Visible = true;
            numUpDownSLNhap.Value = 0;
            chiTietHDNhapHangBindingSource.DataSource = ChiTietHoaDonNhapHangBUS.GetAllSanPham(txtBoxMaHDNH.Text);
            numUpDownSLNhap.Minimum = 0;
        }

        private void btnSuaSPHDNH_Click(object sender, EventArgs e)
        {
            btnLuuSPHDNH.Visible = false;
            btnHuySPHDNH.Visible = false;
            btnSuaSPHDNH.Visible = true;
            btnXoaSPHDNH.Visible = true;
            btnThemSPHDNH.Visible = true;
            txtboxGiaBan.ReadOnly = true;
            txtboxGiaNhap.ReadOnly = false;
            txtboxGiaBan.Visible = true;

            btnLuuSPHDNH.Visible = true;
            btnHuySPHDNH.Visible = true;
            btnSuaSPHDNH.Visible = false;
            btnXoaSPHDNH.Visible = false;
            btnThemSPHDNH.Visible = false;
            IsAddSP = false;
            numUpDownSLNhap.Minimum = -1000;
        }

        private void btnThayDoiGia_Click(object sender, EventArgs e)
        {

            if (btnThayDoiGia.Text == "Đổi Giá")
            {
                btnThayDoiGia.Text = "Lưu";
                txtboxGiaBan.ReadOnly = false;

            }
            else
            {
                if (btnThayDoiGia.Text == "Lưu")
                {
                    try
                    {
                        btnThayDoiGia.Text = "Đổi Giá";
                        txtboxGiaBan.ReadOnly = true;
                        string id = cmBoxKieuSP.SelectedValue.ToString();
                        decimal gia = Convert.ToDecimal(txtboxGiaBan.Text);
                        ChiTietSPBUS.ThayDoiGiaChiTietSO(id, gia);
                    }
                    catch { }
                }
            }

        }
        public void Clear()
        {
            txtboxGiaBan.Clear();
            txtboxGiaNhap.Clear();
            textBoxSLNhap.Clear();
            txtBoxSLTon.Clear();
            txtBoxKieuSP.Clear();
            txtboxSP.Clear();
            txtBoxDSP.Clear();
            txtBoxLSP.Clear();
            txtboxHSX.Clear();

        }

        private void btnLuuFullHDNhap_Click(object sender, EventArgs e)
        {

            if (MessageBox.Show("Bạn có đồng ý Lưu hóa đơn này không?\n Khi lưu bạn sẽ không thể thay đổi hóa đơn!", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                try
                {
                    ChiTietHoaDonNhapHangBUS.LuuHoaDonNhap(txtBoxMaHDNH.Text);
                    MessageBox.Show("Lưu Thành Công!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    KhoHangBUS.ThemSL_SP_Kho_ByCuaHangBy_MaKieu(txtBoxMaHDNH.Text, comboBoxNoiNhapHang.SelectedValue.ToString());
                    Luu = true;
                    this.Close();
                    
                }
                catch
                {
                    MessageBox.Show("Không Thể Thực Hiện Thao Tác", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnHuyFullHDN_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có đồng ý Hủy hóa đơn này không?\n Khi Hủy, Hóa Đơn Sẽ bị xóa, dữ liệu sẽ bị mất!", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                try
                {
                    ChiTietHoaDonNhapHangBUS.XoaAll(txtBoxMaHDNH.Text);
                    HoaDonNhapHangBUS.XoaHDNhap(HoaDonNhapHangBUS.GetGetHoaDonNhapByID(txtBoxMaHDNH.Text));
                    Luu = true;
                }
                catch
                {

                }
            }
        }

       
        private void frmChiTietHoaDonNhapHang_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (Luu == false)
            {

                if (MessageBox.Show("Bạn có đồng ý Hủy hóa đơn này không?\n Khi Hủy, Hóa Đơn Sẽ bị xóa, dữ liệu sẽ bị mất!", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                {
                    try
                    {
                        ChiTietHoaDonNhapHangBUS.XoaAll(txtBoxMaHDNH.Text);
                        HoaDonNhapHangBUS.XoaHDNhap(HoaDonNhapHangBUS.GetGetHoaDonNhapByID(txtBoxMaHDNH.Text));

                    }
                    catch
                    {

                    }
                }
                else
                {
                    e.Cancel = true;
                }

            }
        }

        private void btnXoaSPHDNH_Click(object sender, EventArgs e)
        {
            try
            {
                ChiTietHoaDonNhapHangBUS.XoaSPfromCTNH(txtBoxMaHDNH.Text, txtBoxKieuSP.Text);
                chiTietHDNhapHangBindingSource.DataSource = ChiTietHoaDonNhapHangBUS.GetAllSanPham(txtBoxMaHDNH.Text);
            }
            catch
            {
                MessageBox.Show("Không Thể Thực Hiện Thao Tác", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}