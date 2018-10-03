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
    public partial class frmChiTietTaiKhoan : Form
    {
        public frmChiTietTaiKhoan(TaiKhoan user)
        {
            InitializeComponent();
            User = user;
        }
        private TaiKhoan User;
        private void linklbDoiMK_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            groupBox1.Visible = false;
            groupBox2.Visible = true;
        }

        private void linklbTroLai_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            groupBox1.Visible = true;
            groupBox2.Visible = false;
        }

        private void btnCheckLaiMK_Click(object sender, EventArgs e)
        {
            if(User.Password.Trim(' ') == txtboxReMk.Text )
            {
                groupBox2.Visible = false;
                groupBox3.Visible = true;
            }
            else
            {
                MessageBox.Show("Mật Khẩu Không đúng!"+ User.Password, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnLuuMkMoi_Click(object sender, EventArgs e)
        {
            if(txtboxMkMoi.Text ==  txtBoxReMkMoi.Text)
            {
                if(txtboxMkMoi.Text != User.Password)
                {
                    groupBox1.Visible = true;
                    groupBox3.Visible = false;
                    LoadChiTietTaiKhoan();
                }
                else
                {
                    MessageBox.Show("Hãy Nhập Mật Khẩu Mới Chưa Sử Dụng", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                MessageBox.Show("Mật Khẩu Nhập Lại Không Chính Xác", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void frmChiTietTaiKhoan_Load(object sender, EventArgs e)
        {
            LoadChiTietTaiKhoan();
        }
        void LoadChiTietTaiKhoan()
        {
            txtboxTenTK.Text = User.UserName;
            cmBoxCuaHang.DataSource = CuaHangBUS.GetAllCuaHang();
            cmBoxCuaHang.DisplayMember = "TenCuaHang";
            cmBoxCuaHang.ValueMember = "MaCuaHang";
            cmBoxCuaHang.SelectedValue = User.MaCuaHang;
            cmBoxLoaiTK.DataSource = LoaiTaiKhoanBUS.GetAllLoaiTaiKhoan();
            cmBoxLoaiTK.DisplayMember = "TenLoaiTK";
            cmBoxLoaiTK.ValueMember = "MaLoaiTK";
            cmBoxLoaiTK.SelectedValue = User.MaLoaiTK;
        }
    }
}
