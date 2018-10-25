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
    public partial class frmThongTinGiaoHang : Form
    {
        public frmThongTinGiaoHang(string mahd,string mach,bool isEdit)
        {
            InitializeComponent();
            MaHD = mahd;
            MaCH = mach;
            IsEdit = isEdit;
            LoadGiaoHang();
        }
        private string MaHD;
        private string MaCH;
        private bool IsEdit;
        void LoadGiaoHang()
        {
            if(IsEdit)
            {
                textBoxMaCH.Text = MaCH;
                textBoxMaHD.Text = MaHD;
                comboBoxMaNVGH.DataSource = NhanVienBUS.GetNVShiper();
                comboBoxMaNVGH.DisplayMember = "MaNV";
                comboBoxMaNVGH.ValueMember = "MaNV";
                dateTimeGiaoHang.Value = DateTime.Now;
                try {
                    GiaoHang gh = GiaoHangBUS.GetGiaoHangByMaHD_MaCH(MaHD, MaCH);
                    textBoxNgayGiaoHang.Visible = false;
                    textBoxTinhTrangGiaoHang.Visible = false;
                    textBoxNgayGiaoHang.Text = gh.NgayGiaoHang.ToString();
                    comboBoxMaNVGH.SelectedValue = gh.MaNVGH;
                    //gh.TinhTrangGH = "Đang Giao Hàng";

                }
                catch
                {

                }
                

            }else
            {
                textBoxMaCH.Text = MaCH;
                textBoxMaHD.Text = MaHD;
                comboBoxMaNVGH.DataSource = NhanVienBUS.GetNVShiper();
                textBoxNgayGiaoHang.Visible = true;
                comboBoxMaNVGH.DisplayMember = "MaNV";
                comboBoxMaNVGH.ValueMember = "MaNV";
                btnGiaoHang.Visible = false;
                GiaoHang gh = GiaoHangBUS.GetGiaoHangByMaHD_MaCH(MaHD, MaCH);
                textBoxNgayGiaoHang.Text = gh.NgayGiaoHang.ToString();
                comboBoxMaNVGH.SelectedValue = gh.MaNVGH;
                 if( gh.TinhTrangGH == "Đã Giao Hàng")
                {
                    textBoxTinhTrangGiaoHang.Visible = true;
                    btnHuyGiaoHang.Visible = false;
                }

            }
        }

        private void btnGiaoHang_Click(object sender, EventArgs e)
        {
            if(checkBoxGiaoHang.Checked)
            {
                try {
                    GiaoHang gh = new GiaoHang();
                    gh.MaCuaHang = MaCH;
                    gh.MaHoaDon = MaHD;
                    gh.MaNVGH = comboBoxMaNVGH.SelectedValue.ToString();
                    gh.TinhTrangGH = "Đã Giao Hàng";
                    gh.NgayGiaoHang = dateTimeGiaoHang.Value;
                    GiaoHangBUS.DaGiaoHangGiaoHang(gh);
                    HoaDonBUS.DaThanhToan(MaHD, MaCH);
                    this.Close();
                    //HoaDonBUS.ThanhToanHoaDon(MaHD, MaCH);


                }
                catch { MessageBox.Show("Không Thể Thực Hiện Thao Tác!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error); }

            }
            else
            {
                try
                {
                    GiaoHang gh = new GiaoHang();
                    gh.MaCuaHang = MaCH;
                    gh.MaHoaDon = MaHD;
                    gh.MaNVGH = comboBoxMaNVGH.SelectedValue.ToString();
                    gh.TinhTrangGH = "Đang Giao Hàng";
                    gh.NgayGiaoHang = dateTimeGiaoHang.Value;
                    GiaoHangBUS.ThemGiaoHang(gh);
                    HoaDonBUS.LayHangHoaDon(MaHD, MaCH);
                    this.Close();

                }
                catch { MessageBox.Show("Không Thể Thực Hiện Thao Tác!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error); }


            }
        }

        private void btnHuyGiaoHang_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn Muốn Hủy Giao Hàng?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                try
                {
                    HoaDonBUS.TraHangHoaDon(MaHD, MaCH);
                    GiaoHangBUS.HuyGiaoHang(MaHD, MaCH);
                    MessageBox.Show("Hủy Thành Công!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
                catch { MessageBox.Show("Không Thể Thực Hiện Thao Tác!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            }
        }
    }
}
