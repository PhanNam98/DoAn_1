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
using System.IO;

namespace GalaxyMobile
{
    public partial class frmChiTietHoaDon : Form
    {
        public frmChiTietHoaDon(HoaDon hd, string idch, string manv, bool isedit)
        {
            InitializeComponent();
            HD = hd;
            IDCH = idch;
            MaNV = manv;
            IsEdit = isedit;
            LoadHD();
        }
        private HoaDon HD;
        private string IDCH;
        private string MaNV;
        private bool IsEdit;
        void LoadHD()
        {
            if (IsEdit == false)
            {
                btnHuyHD.Visible = false;
                btnLuuHD.Visible = false;
                btnThemSPMua.Visible = false;
                btnLuuEditSL.Visible = false;
                btnXoaSPMua.Visible = false;
                btnThanhToan.Visible = false;
                btnLuuTam.Visible = false;
            }
            if (HD == null)
            {
                textBoxNSX.Visible = false;
                textBoxLoaiSP.Visible = false;
                textBoxDSP.Visible = false;
                textBoxMauKieu.Visible = false;
                textBoxMaKieuSP.Visible = false;
                textBoxSP.Visible = false;

                textBoxTinhTrangHD.Text = "Chưa Thanh Toán";
                textBoxMaNV.Text = MaNV;
                textBoxMaCH.Text = IDCH;
                comboBoxMaKH.DataSource = KHBUS.GetKH();
                comboBoxMaKH.DisplayMember = "MaKH";
                comboBoxMaKH.ValueMember = "MaKH";
                groupBox2.Enabled = false;
                btnLuuTam.Visible = false;
                btnThanhToan.Visible = false;

            }
            else
            {

                textBoxMaHD.ReadOnly = true;
                textBoxMaKH.ReadOnly = true;
                comboBoxMaKH.Visible = false;

                textBoxHTGH.ReadOnly = true;
                btnHuyHD.Visible = false;
                btnLuuHD.Visible =false;
                btnThemKH.Visible = false;

                textBoxMaCH.Text = HD.MaCuaHang;
                textBoxMaHD.Text = HD.MaHoaDon;
                textBoxMaNV.Text = HD.MaNV;
                textBoxHTGH.Text = HD.HTGiaoHang;
                if (HD.TinhTrang == 1)
                {
                    textBoxTinhTrangHD.Text = "Đã Thanh Toán";
                    btnThemSPMua.Visible = false;
                    btnLuuEditSL.Visible = false;
                    btnXoaSPMua.Visible = false;
                    btnLuuTam.Visible = false;
                    btnThanhToan.Visible = false;
                    btnLuuHD.Visible = false;
                    btnHuyHD.Visible = false;
                    btnThemSPMua.Visible = false;
                    btnLuuEditSL.Visible = false;
                    btnXoaSPMua.Visible = false;
                    btnThanhToan.Visible = false;
                    btnLuuTam.Visible = false;
                }
                else
                {
                    textBoxTinhTrangHD.Text = "Chưa Thanh Toán";
                    btnThanhToan.Visible = true;
                }
                if (HD.HTGiaoHang.ToLower() != "Trực Tiếp".ToLower())
                {
                    textBoxTinhTrangGiaHang.Visible = true;
                    lbTrangGiaoHang.Visible = true;
                    linkLbChiTietGiaoHang.Visible = true;
                    try {
                        textBoxTinhTrangGiaHang.Text = GiaoHangBUS.GetGiaoHangByMaHD_MaCH(HD.MaHoaDon, HD.MaCuaHang).TinhTrangGH.ToString();
                        if(textBoxTinhTrangGiaHang.Text== "Đang Giao Hàng")
                        {
                            btnThanhToan.Visible = false;
                            btnLuuTam.Visible = false;
                        }
                    }
                    catch { }
                    radioGiaoHang.Checked = true;
                    
                }
                else

                {
                    textBoxTinhTrangGiaHang.Visible = false;
                    lbTrangGiaoHang.Visible = false;
                    linkLbChiTietGiaoHang.Visible = false;
                }
                radioGiaoHang.Enabled = false;
                radioMuaTT.Enabled = false;
                dateTimePickerNgayVietHD.Value = HD.NgayLapHD;
                KhachHang kh = KHBUS.GetKHByMAKH(HD.MaKH);
                textBoxTenKH.Text = kh.TenKH;
                textBoxDiaChi.Text = kh.DiaChi;
                txtboxSDT.Text = kh.SDT;
                textBoxMaKH.Text = kh.MaKH;

                chiTietHoaDonBindingSource.DataSource = ChiTietHoaDonBUS.GetChieTietHD_ByMaHD(HD.MaHoaDon, HD.MaCuaHang);

                lbTongTien.Text = ChiTietHoaDonBUS.TinhTien_ByMaHD(HD.MaHoaDon, HD.MaCuaHang).ToString();

            }
        }

        private void dgvHoaDon_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            textBoxNSX.Visible = true;
            textBoxLoaiSP.Visible = true;
            textBoxDSP.Visible = true;
            textBoxMauKieu.Visible = true;
            textBoxMaKieuSP.Visible = true;
            textBoxSP.Visible = true;

            int r = dgvHoaDon.CurrentCell.RowIndex;
            string id = dgvHoaDon.Rows[r].Cells[1].Value.ToString();
            USP_GETAllInfoSPNew_Result sp = ChiTietSPBUS.GetMaSPByMaKieuSP(id);
            textBoxNSX.Text = sp.TenHSX;
            textBoxLoaiSP.Text = sp.TenLSP;
            textBoxDSP.Text = sp.TenDong;
            textboxGiaBan.Text = dgvHoaDon.Rows[r].Cells[3].Value.ToString();
            textBoxSLTon.Text = ChiTietSPBUS.GetChiTietSPOderByMaCHByIDKieuSP(textBoxMaCH.Text, id).SoluongSP.ToString();
            textBoxMaKieuSP.Text = sp.MaKieu;
            textBoxTenSP.Text = sp.TenSP;
            textBoxSLMua.Text = dgvHoaDon.Rows[r].Cells[2].Value.ToString();
            ChiTietSP ct = ChiTietSPBUS.Get1ChiTietSPByIDMaKieu(id);
            textBoxSP.Text = ct.MaSP.ToString();
            textBoxMauKieu.Text = ct.MaMau.ToString();

            try
            {
                pictureBox.BackgroundImage = ConverBinaryToImage(ct.Anh);
            }
            catch
            { pictureBox.BackgroundImage = null; }
        }
        Image ConverBinaryToImage(byte[] data)
        {
            using (MemoryStream ms = new MemoryStream(data))
            {
                return Image.FromStream(ms);
            }
        }

        private void comboBoxMaKH_SelectedIndexChanged(object sender, EventArgs e)
        {
            try {
                string id = comboBoxMaKH.SelectedValue.ToString();
                KhachHang kh = KHBUS.GetKHByMAKH(id);
                textBoxTenKH.Text = kh.TenKH;
                textBoxDiaChi.Text = kh.DiaChi;
                txtboxSDT.Text = kh.SDT;
            }
            catch { }
        }

        private void btnLuuHD_Click(object sender, EventArgs e)
        {
            HoaDon hd = new HoaDon();
            hd.MaHoaDon = textBoxMaHD.Text;
            hd.MaKH = comboBoxMaKH.SelectedValue.ToString();
            hd.MaNV = textBoxMaNV.Text;
            hd.MaCuaHang = textBoxMaCH.Text;
            hd.NgayLapHD = dateTimePickerNgayVietHD.Value;
            hd.TinhTrang = 0;
            if (radioMuaTT.Checked)
            {
                hd.HTGiaoHang = "Trực Tiếp";
            }
            else
            {
                hd.HTGiaoHang = "Giao Hàng";
            }
            try
            {
                HoaDonBUS.ThemHoaDon(hd);
                MessageBox.Show("Thêm Thành Công!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                groupBox2.Enabled = true;
                btnLuuTam.Visible = true;
                btnThanhToan.Visible = true;
                comboBoxNSX.DataSource = HSXBUS.GetAllHSX();
                comboBoxNSX.ValueMember = "MaHSX";
                comboBoxNSX.DisplayMember = "TenHSX";
                comboBoxMau.DataSource = ChiTietSPBUS.GetAllMauSP();
                comboBoxMau.DisplayMember = "Mau";
                comboBoxMau.ValueMember = "MaMau";
                comboBoxLoaiSP.DataSource = LoaiSPBUS.GetAllLoaiSP();
                comboBoxLoaiSP.DisplayMember = "TenLSP";
                comboBoxLoaiSP.ValueMember = "MaLSP";
            }
            catch
            {
                MessageBox.Show("Không Thể Thực Hiện Thao Tác!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void comboBoxNSX_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                //comboBoxNSX.DataSource = null;
                string id = comboBoxNSX.SelectedValue.ToString();
                comboBoxDSP.DataSource = DongSanPhamBUS.GetAllDongSPByMaHSX(id);
                comboBoxDSP.DisplayMember = "TenDong";
                comboBoxDSP.ValueMember = "MaDSP";
            }
            catch { }
        }

        private void comboBoxLoaiSP_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                comboBoxDSP.DataSource = null;
                string id = comboBoxNSX.SelectedValue.ToString();
                string idloai = comboBoxLoaiSP.SelectedValue.ToString();

                if (DongSanPhamBUS.GetAllDongSPByMaHSXAndMaLoai(id, idloai).Count != 0)
                {
                    comboBoxDSP.DataSource = DongSanPhamBUS.GetAllDongSPByMaHSXAndMaLoai(id, idloai);
                    comboBoxDSP.DisplayMember = "TenDong";
                    comboBoxDSP.ValueMember = "MaDSP";
                }
                else
                    comboBoxDSP.DataSource = null;
            }
            catch { comboBoxDSP.DataSource = null; }
        }

        private void comboBoxDSP_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                comboBoxSP.DataSource = null;
                string id = comboBoxDSP.SelectedValue.ToString();


                if (SanPhamBUS.GetSanPhamByMaDSP(id).Count != 0)
                {
                    comboBoxSP.DataSource = SanPhamBUS.GetSanPhamByMaDSP(id);
                    comboBoxSP.DisplayMember = "TenSP";
                    comboBoxSP.ValueMember = "MaSP";
                }
                else
                    comboBoxSP.DataSource = null;
            }
            catch { comboBoxSP.DataSource = null; }
        }

        private void comboBoxSP_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {

                string id = comboBoxSP.SelectedValue.ToString();

                textBoxTenSP.Text = SanPhamBUS.GetSanPhamByID(id).TenSP.ToString();
                if (ChiTietSPBUS.GetChiTietSPByIDSP(id).Count != 0)
                {
                    comboBoxMaKieu.DataSource = ChiTietSPBUS.GetChiTietSPByIDSP(id);
                    comboBoxMaKieu.DisplayMember = "MaKieu";
                    comboBoxMaKieu.ValueMember = "MaKieu";
                }
                else
                    comboBoxMaKieu.DataSource = null;
            }
            catch { comboBoxMaKieu.DataSource = null; }
        }

        private void comboBoxMaKieu_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {

                string id = comboBoxMaKieu.SelectedValue.ToString();

                ChiTietSP ct = ChiTietSPBUS.GetChiTietSPOderByMaCHByIDKieuSP(textBoxMaCH.Text, id);
                if (ct != null)
                {
                    textBoxSLTon.Text = ct.SoluongSP.ToString();
                    textboxGiaBan.Text = ct.Gia.ToString();
                    comboBoxMau.SelectedValue = ct.MaMau;
                    try
                    {
                        pictureBox.BackgroundImage = ConverBinaryToImage(ct.Anh);
                    }
                    catch
                    {
                        pictureBox.BackgroundImage = null;
                    }

                }
                else
                {
                    textBoxSLTon.Text = "";
                    textboxGiaBan.Text = "";
                }

            }
            catch
            {
                textBoxSLTon.Text = "";
                textboxGiaBan.Text = "";
            }
        }

        private void comboBoxMau_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }
        private bool IsAdd;
        private void btnThemSPMua_Click(object sender, EventArgs e)
        {
            IsAdd = true;
            textBoxNSX.Visible = false;
            textBoxLoaiSP.Visible = false;
            textBoxDSP.Visible = false;
            textBoxMauKieu.Visible = false;
            textBoxMaKieuSP.Visible = false;
            textBoxSP.Visible = false;
            numericSL.Value = 1;
            numericSL.Minimum = 0;

            comboBoxNSX.DataSource = HSXBUS.GetAllHSX();
            comboBoxNSX.ValueMember = "MaHSX";
            comboBoxNSX.DisplayMember = "TenHSX";
            comboBoxMau.DataSource = ChiTietSPBUS.GetAllMauSP();
            comboBoxMau.DisplayMember = "Mau";
            comboBoxMau.ValueMember = "MaMau";
            comboBoxLoaiSP.DataSource = LoaiSPBUS.GetAllLoaiSP();
            comboBoxLoaiSP.DisplayMember = "TenLSP";
            comboBoxLoaiSP.ValueMember = "MaLSP";
        }

        private void btnThanhToan_Click(object sender, EventArgs e)
        {
            if (btnThanhToan.Text == "Giao Hàng")
            {
                if (GiaoHangBUS.KiemTraGiaoHang(textBoxMaHD.Text, textBoxMaCH.Text))
                {
                    MessageBox.Show("Đã Có Thông Tin Giao Hàng!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    frmThongTinGiaoHang frm = new frmThongTinGiaoHang(textBoxMaHD.Text, textBoxMaCH.Text, true);
                    frm.Show();
                    btnThemSPMua.Visible = false;
                    btnLuuEditSL.Visible = false;
                    btnXoaSPMua.Visible = false;
                    btnLuuTam.Visible = false;
                }
            }
            else if (btnThanhToan.Text == "Thanh Toán")
            {
                if (MessageBox.Show("Bạn Muốn Thanh Toán?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                {
                    try
                    {
                        HoaDonBUS.ThanhToanHoaDon(textBoxMaHD.Text, textBoxMaCH.Text);
                        MessageBox.Show("Thanh Toán Thành Công!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        btnThemSPMua.Visible = false;
                        btnLuuEditSL.Visible = false;
                        btnXoaSPMua.Visible = false;
                        btnLuuTam.Visible = false;
                        this.Close();
                    }
                    catch { MessageBox.Show("Không Thể Thực Hiện Thao Tác!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                }
            }
        }

        private void btnLuuEditSL_Click(object sender, EventArgs e)
        {
            if (IsAdd)
            {
                ChiTietHoaDon ct = new ChiTietHoaDon();
                ct.MaCuaHang = textBoxMaCH.Text;
                ct.MaHoaDon = textBoxMaHD.Text;
                ct.MaKieu = comboBoxMaKieu.SelectedValue.ToString();
                ct.GiaSP = Convert.ToDecimal(textboxGiaBan.Text);
                ct.SoluongSP = Convert.ToInt32(numericSL.Value);
                if (ChiTietHoaDonBUS.KiemTraTonTaiChiTietHoaDon(ct))
                {
                    //try
                    //{
                        ChiTietHoaDonBUS.ThemChiTietHoaDon(ct);
                        chiTietHoaDonBindingSource.DataSource = ChiTietHoaDonBUS.GetChieTietHD_ByMaHD(textBoxMaHD.Text, textBoxMaCH.Text);
                    //}
                    //catch
                    //{
                    //    MessageBox.Show("Không Thể Thực Hiện Thao Tác!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    //}
                }
                else
                {
                    //try
                    //{
                        ChiTietHoaDonBUS.thayDoiSLChiTietHoaDon(textBoxMaHD.Text, textBoxMaCH.Text, comboBoxMaKieu.SelectedValue.ToString(), Convert.ToInt32(numericSL.Value));
                        chiTietHoaDonBindingSource.DataSource = ChiTietHoaDonBUS.GetChieTietHD_ByMaHD(textBoxMaHD.Text, textBoxMaCH.Text);
                    //}
                    //catch { MessageBox.Show("Không Thể Thực Hiện Thao Tác!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                }
            }
            else
            {
                try
                {
                    ChiTietHoaDonBUS.thayDoiSLChiTietHoaDon(textBoxMaHD.Text, textBoxMaCH.Text, comboBoxMaKieu.SelectedValue.ToString(), Convert.ToInt32(numericSL.Value));
                    chiTietHoaDonBindingSource.DataSource = ChiTietHoaDonBUS.GetChieTietHD_ByMaHD(textBoxMaHD.Text, textBoxMaCH.Text);
                }
                catch { MessageBox.Show("Không Thể Thực Hiện Thao Tác!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            }
            lbTongTien.Text = ChiTietHoaDonBUS.TinhTien_ByMaHD(textBoxMaHD.Text, textBoxMaCH.Text).ToString();
            numericSL.Value = 0;
            numericSL.Minimum = -100;
            IsAdd = false;
        }

        private void btnXoaSPMua_Click(object sender, EventArgs e)
        {
            try
            {
                ChiTietHoaDonBUS.XoaChiTietHoaDon(textBoxMaHD.Text, textBoxMaCH.Text, textBoxMaKieuSP.Text);
                chiTietHoaDonBindingSource.DataSource = ChiTietHoaDonBUS.GetChieTietHD_ByMaHD(textBoxMaHD.Text, textBoxMaCH.Text);
                textBoxSLMua.Text = "";

            }
            catch { MessageBox.Show("Không Thể Thực Hiện Thao Tác!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            lbTongTien.Text = ChiTietHoaDonBUS.TinhTien_ByMaHD(textBoxMaHD.Text,textBoxMaCH.Text).ToString();

        }

        private void radioGiaoHang_CheckedChanged(object sender, EventArgs e)
        {
            if (radioGiaoHang.Checked == true)
            {
                btnThanhToan.Text = "Giao Hàng";
                //textBoxTinhTrangGiaHang.Visible = true;
                //lbTrangGiaoHang.Visible = true;
                //linkLbChiTietGiaoHang.Visible = true;
            }
            else
            {
                btnThanhToan.Text = "Thanh Toán";
                //textBoxTinhTrangGiaHang.Visible = false;
                //lbTrangGiaoHang.Visible = false;
                //linkLbChiTietGiaoHang.Visible = false;
            }
        }

        private void linkLbChiTietGiaoHang_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try {
                if (HD.TinhTrang == 1)
                {
                    frmThongTinGiaoHang frm = new frmThongTinGiaoHang(textBoxMaHD.Text, textBoxMaCH.Text, false);
                    frm.Show();
                }
                else
                {
                    frmThongTinGiaoHang frm = new frmThongTinGiaoHang(textBoxMaHD.Text, textBoxMaCH.Text, true);
                    frm.Show();
                }
            }
            catch {
               
            }
        }

        private void btnLuuTam_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
