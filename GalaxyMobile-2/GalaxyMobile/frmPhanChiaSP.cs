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
    public partial class frmPhanChiaSP : Form
    {
        public frmPhanChiaSP(string id)
        {
            InitializeComponent();
            IDMaKieu = id;
        }
        private string IDMaKieu;
        private DongSanPham DSp;
        private SanPham Sp;
        private ChiTietSP CtSp;
        public void LoadChiTietSP()
        {

            //try
            //{
            LoadSP();
            //}
            //catch
            //{

            //}
            comboBoxCHNhan.DataSource = CuaHangBUS.GetAllCuaHang();
            comboBoxCHNhan.DisplayMember = "TenCuaHang";
            comboBoxCHNhan.ValueMember = "MaCuaHang";
            comboBoxCHPP.DataSource = CuaHangBUS.GetAllCuaHang();
            comboBoxCHPP.DisplayMember = "TenCuaHang";
            comboBoxCHPP.ValueMember = "MaCuaHang";
            comboBoxNXS.DataSource = HSXBUS.GetAllHSX();
            comboBoxNXS.DisplayMember = "TenHSX";
            comboBoxNXS.ValueMember = "MaHSX";
            comboBoxNXS.SelectedValue = DSp.MaHSX;
            comboBoxDSP.DataSource = DongSanPhamBUS.GetAllDongSPByMaHSX(DSp.MaHSX);
            comboBoxDSP.DisplayMember = "TenDong";
            comboBoxDSP.ValueMember = "MaDSP";
            comboBoxDSP.SelectedValue = DSp.MaDSP;
            comboBoxSP.DataSource = SanPhamBUS.GetSanPhamByMaDSP(DSp.MaDSP);
            comboBoxSP.DisplayMember = "TenSP";
            comboBoxSP.ValueMember = "MaSP";
            comboBoxSP.SelectedValue = Sp.MaSP;
            comboBoxMaKieu.DataSource = ChiTietSPBUS.GetChiTietSPByIDSP(Sp.MaSP);
            comboBoxMaKieu.DisplayMember = "MaKieu";
            comboBoxMaKieu.ValueMember = "MaKieu";
            CtSp = ChiTietSPBUS.Get1ChiTietSPByIDMaKieu(IDMaKieu);
            comboBoxMaKieu.SelectedValue = CtSp.MaKieu;
            textBoxSLTonKieu.Text = CtSp.SoluongSP.ToString();
            pictureBox.BackgroundImage = ConverBinaryToImage(CtSp.Anh);
            khoHangBindingSource.DataSource = KhoHangBUS.GetAllKhoHangByMaKieu(CtSp.MaKieu);
        }
        void LoadSP()
        {
            try
            {
                Sp = ChiTietSPBUS.GetMaSPByIDKieuSP(IDMaKieu);
                CtSp = ChiTietSPBUS.Get1ChiTietSPByIDMaKieu(IDMaKieu);
                DSp = DongSanPhamBUS.Get1DongSPByMaSP(Sp.MaDSP);
            }
            catch { }

        }

        private void frmPhanChiaSP_Load(object sender, EventArgs e)
        {
            LoadChiTietSP();
        }

        private void comboBoxNXS_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                comboBoxDSP.DataSource = null;
                string id = comboBoxNXS.SelectedValue.ToString();
                comboBoxDSP.DataSource = DongSanPhamBUS.GetAllDongSPByMaHSX(id);
                comboBoxDSP.DisplayMember = "TenDong";
                comboBoxDSP.ValueMember = "MaDSP";
            }
            catch { }
        }

        private void comboBoxDSP_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                comboBoxSP.DataSource = null;
                string id = comboBoxDSP.SelectedValue.ToString();
                comboBoxSP.DataSource = SanPhamBUS.GetSanPhamByMaDSP(id);
                comboBoxSP.DisplayMember = "TenSP";
                comboBoxSP.ValueMember = "MaSP";
            }
            catch { }
        }

        private void comboBoxMaKieu_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                textBoxSLTonKieu.Text = "";
                pictureBox.BackgroundImage = null;
                khoHangBindingSource.DataSource = null;
                textBoxMaKieu.Text = "";
                string id = comboBoxMaKieu.SelectedValue.ToString();
                CtSp = ChiTietSPBUS.Get1ChiTietSPByIDMaKieu(id);
                textBoxMaKieu.Text = CtSp.MaKieu;
                textBoxSLTonKieu.Text = CtSp.SoluongSP.ToString();
                try
                {
                    pictureBox.BackgroundImage = ConverBinaryToImage(CtSp.Anh);
                }
                catch { pictureBox.BackgroundImage = null; }
                khoHangBindingSource.DataSource = KhoHangBUS.GetAllKhoHangByMaKieu(CtSp.MaKieu);
            }
            catch { }
        }

        private void comboBoxSP_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                comboBoxMaKieu.DataSource = null;
                string id = comboBoxSP.SelectedValue.ToString();
                comboBoxMaKieu.DataSource = ChiTietSPBUS.GetChiTietSPByIDSP(id);
                comboBoxMaKieu.DisplayMember = "MaKieu";
                comboBoxMaKieu.ValueMember = "MaKieu";
            }
            catch { }
        }

        Image ConverBinaryToImage(byte[] data)
        {
            try
            {
                using (MemoryStream ms = new MemoryStream(data))
                {
                    return Image.FromStream(ms);
                }
            }
            catch { }
            return null;
        }
        byte[] CovertImageToBinary(Image img)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                img.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                return ms.ToArray();
            }
        }

        private void dgvKho_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                textBoxSLTonCHNhan.Text = "";
                int r = dgvKho.CurrentCell.RowIndex;
                string id = dgvKho.Rows[r].Cells[0].Value.ToString();
                comboBoxCHNhan.SelectedValue = dgvKho.Rows[r].Cells[1].Value.ToString();
                textBoxMaKieu.Text = id;
                textBoxSLTonCHNhan.Text = dgvKho.Rows[r].Cells[2].Value.ToString();
                comboBoxCHPP.SelectedValue = "ts";
            }
            catch { }
        }

        private void comboBoxCHPP_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                textBoxSLTonCHPP.Text = "";
                string id = comboBoxCHPP.SelectedValue.ToString();
                ChiTietSP ct = new ChiTietSP();
                if (textBoxMaKieu.Text.Trim(' ') != "")
                    ct = ChiTietSPBUS.GetChiTietSPOderByMaCHByIDKieuSP(id, textBoxMaKieu.Text);
                else
                    ct = null;
                textBoxSLTonCHPP.Text = ct.SoluongSP.ToString();

            }
            catch { }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (comboBoxCHNhan.SelectedValue.ToString() == comboBoxCHPP.SelectedValue.ToString())
            {
                MessageBox.Show("Lỗi! Hai Cửa Hàng Trùng Nhau.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if(numericUpDownThemBotSL.Value<=Convert.ToInt32( textBoxSLTonCHPP.Text) && numericUpDownThemBotSL.Value>0)
                {
                    string id1 = comboBoxCHNhan.SelectedValue.ToString();
                    string id2 = comboBoxCHPP.SelectedValue.ToString();
                    string id = textBoxMaKieu.Text;
                    KhoHangBUS.KiemTraKho_CuaHang_MaKieu(id, id1);
                    KhoHangBUS.KiemTraKho_CuaHang_MaKieu(id, id2);
                    int sl = Convert.ToInt32( numericUpDownThemBotSL.Value);
                    try{
                        ChiTietSPBUS.PhanChiSP(id, id1, id2, sl);
                        MessageBox.Show("Thành Công! Sản Phẩm Đã Được Phân Phối.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        khoHangBindingSource.DataSource = KhoHangBUS.GetAllKhoHangByMaKieu(id);
                    }
                    catch
                    {
                        MessageBox.Show("Lỗi! Không Thể Thực Hiện Thao Tác.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                }
                else
                {
                    MessageBox.Show("Lỗi! Số Lượng Phân Phối Không Phù Hợp.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                      
            }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            numericUpDownThemBotSL.Value = 0;
        }
    }
}
