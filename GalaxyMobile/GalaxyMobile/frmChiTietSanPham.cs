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
    public partial class frmChiTietSanPham : Form
    {
        public frmChiTietSanPham(string id, int idmod,string idDSP,bool ischange)
        {
            InitializeComponent();
            ID = id;
            IDMode = idmod;
            Ischange = ischange;
            IDDSP = idDSP;
            LoadSP();
        }
        private string ID;
        private int IDMode;
        private bool Ischange;
        private string IDDSP;
        #region Event
        private void cmBoxDongSP_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                string id = cmBoxDongSP.SelectedValue.ToString();
                List<SanPham> sp = SanPhamBUS.GetSanPhamByMaDSP(id);
                if (sp.Count() != 0)
                {
                    cmBoxSP.DataSource = null;
                    txtTenSP.Text = " ";
                    txtNamSX.Text = " ";
                    txtboxCPU.Text = " ";
                    txtboxGPU.Text = " ";
                    txtCamera.Text = " ";
                    txtPort.Text = " ";
                    txtboxRam.Text = " ";
                    txtboxManHinh.Text = " ";
                    txtboxOS.Text = " ";
                    txtboxSim.Text = " ";
                    txtboxPin.Text = " ";
                    txtBoxTrongLuong.Text = " ";
                    txtboxBNngoai.Text = " ";
                    txtboxBNtrong.Text = " ";
                    cmBoxSP.DataSource = sp;
                    cmBoxSP.ValueMember = "MaSP";
                    cmBoxSP.DisplayMember = "MaSP";
                    
                }
                else
                {
                    cmBoxSP.DataSource = null;
                    txtTenSP.Text = " ";
                    txtNamSX.Text = " ";
                    txtboxCPU.Text = " ";
                    txtboxGPU.Text = " ";
                    txtCamera.Text = " ";
                    txtPort.Text = " ";
                    txtboxRam.Text = " ";
                    txtboxManHinh.Text = " ";
                    txtboxOS.Text = " ";
                    txtboxSim.Text = " ";
                    txtboxPin.Text = " ";
                    txtBoxTrongLuong.Text = " ";
                    txtboxBNngoai.Text = " ";
                    txtboxBNtrong.Text = " ";
                }

            }
            catch { }

        }
        private void cmBoxSP_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (ID != null)
                {
                    string id = cmBoxSP.SelectedValue.ToString();
                    SanPham sp = SanPhamBUS.GetSanPhamByID(id);
                    txtboxMaSP.Text = sp.MaSP;
                    txtTenSP.Text = sp.TenSP;
                    txtNamSX.Text = sp.NămSX;
                    txtboxCPU.Text = sp.CPU;
                    txtboxGPU.Text = sp.CardManHinh;
                    txtCamera.Text = sp.Camera;
                    txtPort.Text = sp.Port;
                    txtboxRam.Text = sp.Ram;
                    txtboxManHinh.Text = sp.ManHinh;
                    txtboxOS.Text = sp.OS;
                    txtboxSim.Text = sp.Sim;
                    txtboxPin.Text = sp.DungLuongPin;
                    txtBoxTrongLuong.Text = sp.TrongLuong;
                    txtboxBNngoai.Text = sp.BoNhoNgoai;
                    txtboxBNtrong.Text = sp.BoNhoTrong;
                }

            }
            catch { }
        }
        private void btnLuuThayDoi_Click(object sender, EventArgs e)
        {
            if (ID == null)
            {

                SanPham sp = new SanPham();
                sp.MaDSP = cmBoxDongSP.SelectedValue.ToString();
                sp.MaSP = txtboxMaSP.Text;
                sp.TenSP = txtTenSP.Text;
                sp.NămSX = txtNamSX.Text;
                sp.CPU = txtboxCPU.Text;
                sp.CardManHinh = txtboxGPU.Text;
                sp.Camera = txtCamera.Text;
                sp.Port = txtPort.Text;
                sp.Ram = txtboxRam.Text;
                sp.ManHinh = txtboxManHinh.Text;
                sp.OS = txtboxOS.Text;
                sp.Sim = txtboxSim.Text;
                sp.DungLuongPin = txtboxPin.Text;
                sp.TrongLuong = txtBoxTrongLuong.Text;
                sp.BoNhoNgoai = txtboxBNngoai.Text;
                sp.BoNhoTrong = txtboxBNtrong.Text;
                try
                {

                    SanPhamBUS.ThemSP(sp);
                    MessageBox.Show("Thêm Sản Phẩm Thành Công!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch
                {
                    MessageBox.Show("Không Thực Hiện Được Thao Tác!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }


            }
            else
            {
                try {

                    SanPham sp = new SanPham();
                    sp.MaDSP = cmBoxDongSP.SelectedValue.ToString();
                    sp.MaSP = txtboxMaSP.Text;
                    sp.TenSP = txtTenSP.Text;
                    sp.NămSX = txtNamSX.Text;
                    sp.CPU = txtboxCPU.Text;
                    sp.CardManHinh = txtboxGPU.Text;
                    sp.Camera = txtCamera.Text;
                    sp.Port = txtPort.Text;
                    sp.Ram = txtboxRam.Text;
                    sp.ManHinh = txtboxManHinh.Text;
                    sp.OS = txtboxOS.Text;
                    sp.Sim = txtboxSim.Text;
                    sp.DungLuongPin = txtboxPin.Text;
                    sp.TrongLuong = txtBoxTrongLuong.Text;
                    sp.BoNhoNgoai = txtboxBNngoai.Text;
                    sp.BoNhoTrong = txtboxBNtrong.Text;
                    SanPhamBUS.ChinhSuaSP(sp);
                    MessageBox.Show("Chỉnh Sửa Sản Phẩm Thành Công!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    
                }
                catch
                {
                    MessageBox.Show("Không Thực Hiện Được Thao Tác!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        #endregion
        #region methods
        void LoadSP()
        {
            cmBoxDongSP.Enabled = true;
            cmBoxDongSP.DataSource = DongSanPhamBUS.GetAllDongSP();
            cmBoxMauSP.DataSource = ChiTietSPBUS.GetAllMauSP();
            //cmBoxSP.DataSource = SanPhamBUS.GetSanPhamByMaDSP();
            //Xem Chi tiết
            if (ID != null && Ischange == false)
            {
                btnThemSP.Visible = false;
                btnLuuThayDoi.Visible = false;
                SanPham sp = BUS.SanPhamBUS.GetSanPhamByID(ID);
                cmBoxSP.DataSource = SanPhamBUS.GetSanPhamByMaDSP(sp.MaDSP);
                cmBoxSP.ValueMember = "MaSP";
                cmBoxSP.DisplayMember = "MaSP";
                cmBoxSP.SelectedValue = sp.MaSP;
                cmBoxDongSP.DisplayMember = "TenDong";
                cmBoxDongSP.ValueMember = "MaDSP";
                cmBoxDongSP.SelectedValue = sp.MaDSP;
                txtboxMaSP.Text = sp.MaSP;
                txtTenSP.Text = sp.TenSP;
                txtNamSX.Text = sp.NămSX;
                txtboxCPU.Text = sp.CPU;
                txtboxGPU.Text = sp.CardManHinh;
                txtCamera.Text = sp.Camera;
                txtPort.Text = sp.Port;
                txtboxRam.Text = sp.Ram;
                txtboxManHinh.Text = sp.ManHinh;
                txtboxOS.Text = sp.OS;
                txtboxSim.Text = sp.Sim;
                txtboxPin.Text = sp.DungLuongPin;
                txtBoxTrongLuong.Text = sp.TrongLuong;
                txtboxBNngoai.Text = sp.BoNhoNgoai;
                txtboxBNtrong.Text = sp.BoNhoTrong;
            }
            //Thêm Mới
            if (ID == null && Ischange==false)
            {
                cmBoxSP.Enabled = false;
                cmBoxDongSP.DisplayMember = "TenDong";
                cmBoxDongSP.ValueMember = "MaDSP";
                if(IDDSP != null)
                {
                    cmBoxDongSP.SelectedValue = IDDSP;
                }
                btnThemSP.Visible = false;
                btnLuuThayDoi.Visible = true;
                cmBoxSP.Visible = false;
                txtTenSP.ReadOnly = false;
                txtNamSX.ReadOnly = false;
                txtboxCPU.ReadOnly = false;
                txtboxGPU.ReadOnly = false;
                txtCamera.ReadOnly = false;
                txtPort.ReadOnly = false;
                txtboxRam.ReadOnly = false;
                txtboxManHinh.ReadOnly = false;
                txtboxOS.ReadOnly = false;
                txtboxSim.ReadOnly = false;
                txtboxPin.ReadOnly = false;
                txtBoxTrongLuong.ReadOnly = false;
                txtboxBNngoai.ReadOnly = false;
                txtboxBNtrong.ReadOnly = false;

            }
            //Chỉnh sửa
            if (ID != null && Ischange==true)
            {
                cmBoxSP.Enabled = false;
                cmBoxDongSP.DisplayMember = "TenDong";
                cmBoxDongSP.ValueMember = "MaDSP";
                btnThemSP.Visible = false;
                btnLuuThayDoi.Visible = true;
                cmBoxSP.Visible = false;
                txtboxMaSP.Text = ID;
                txtboxMaSP.ReadOnly = true;
                txtTenSP.ReadOnly = false;
                txtNamSX.ReadOnly = false;
                txtboxCPU.ReadOnly = false;
                txtboxGPU.ReadOnly = false;
                txtCamera.ReadOnly = false;
                txtPort.ReadOnly = false;
                txtboxRam.ReadOnly = false;
                txtboxManHinh.ReadOnly = false;
                txtboxOS.ReadOnly = false;
                txtboxSim.ReadOnly = false;
                txtboxPin.ReadOnly = false;
                txtBoxTrongLuong.ReadOnly = false;
                txtboxBNngoai.ReadOnly = false;
                txtboxBNtrong.ReadOnly = false;

                SanPham sp = BUS.SanPhamBUS.GetSanPhamByID(ID);
                cmBoxSP.DataSource = SanPhamBUS.GetSanPhamByMaDSP(sp.MaDSP);
                cmBoxSP.ValueMember = "MaSP";
                cmBoxSP.DisplayMember = "MaSP";
                cmBoxSP.SelectedValue = sp.MaSP;
                cmBoxDongSP.DisplayMember = "TenDong";
                cmBoxDongSP.ValueMember = "MaDSP";
                cmBoxDongSP.SelectedValue = sp.MaDSP;
                txtboxMaSP.Text = sp.MaSP;
                txtTenSP.Text = sp.TenSP;
                txtNamSX.Text = sp.NămSX;
                txtboxCPU.Text = sp.CPU;
                txtboxGPU.Text = sp.CardManHinh;
                txtCamera.Text = sp.Camera;
                txtPort.Text = sp.Port;
                txtboxRam.Text = sp.Ram;
                txtboxManHinh.Text = sp.ManHinh;
                txtboxOS.Text = sp.OS;
                txtboxSim.Text = sp.Sim;
                txtboxPin.Text = sp.DungLuongPin;
                txtBoxTrongLuong.Text = sp.TrongLuong;
                txtboxBNngoai.Text = sp.BoNhoNgoai;
                txtboxBNtrong.Text = sp.BoNhoTrong;
            }


        }


        #endregion


    }
}
