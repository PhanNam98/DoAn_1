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
    public partial class frmChiTietSanPham : Form
    {
        public frmChiTietSanPham(string id, string idmod, string idDSP, bool ischange)
        {
            InitializeComponent();
            ID = id;
            IDMode = idmod;
            //IDMode = "ts";
            Ischange = ischange;
            IDDSP = idDSP;
            LoadSP();
        }
        private string ID;
        private string IDMode;
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
                    cmBoxMaSP.DataSource = sp;
                    cmBoxMaSP.ValueMember = "MaSP";
                    cmBoxMaSP.DisplayMember = "MaSP";


                }
                else
                {
                    cmBoxSP.DataSource = null;
                    cmBoxMaSP.DataSource = null;
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
                    cmBoxMaSP.SelectedValue = id;
                    cmBoxSP.SelectedValue = id;
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
                    if (IDMode == "ts")
                        chiTietSPBindingSource.DataSource = ChiTietSPBUS.GetChiTietSPByIDSP(id);
                    else
                    {
                        chiTietSPBindingSource.DataSource = ChiTietSPBUS.GetChiTietSPOderByMaCHByIDSP(IDMode, id);
                    }
                    //chiTietSPBindingSource.DataSource = ChiTietSPBUS.GetChiTietSPByIDSP(ID);
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
                try
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
            //cmBoxMauSP.DataSource = ChiTietSPBUS.GetAllMauSP();
            //cmBoxSP.DataSource = SanPhamBUS.GetSanPhamByMaDSP();
            cmBoxTenMau.DataSource = ChiTietSPBUS.GetAllMauSP();
            cmBoxTenMau.DisplayMember = "Mau";
            cmBoxTenMau.ValueMember = "MaMau";

            if (IDMode.Trim(' ') != "ts")
            {
                btnAnh.Visible = false;
                btnThemSP.Visible = false;
                btnLuuThayDoi.Visible = false;
                btnLuuKieuSP.Visible = false;
                btnHuyKieuSP.Visible = false;
                btnThemKieuSP.Visible = false;
                btnChinhSuaKieuSP.Visible = false;
                btnXoaKieuSP.Visible = false;
                btnThemMau.Visible = false;
                btnXoaMau.Visible = false;
                btnLuuMau.Visible = false;
            }
            //Xem Chi tiết
            if (ID != null && Ischange == false)
            {
                btnThemSP.Visible = false;
                btnLuuThayDoi.Visible = false;
                SanPham sp = BUS.SanPhamBUS.GetSanPhamByID(ID);
                cmBoxSP.DataSource = SanPhamBUS.GetSanPhamByMaDSP(sp.MaDSP);
                cmBoxSP.ValueMember = "MaSP";
                cmBoxSP.DisplayMember = "TenSP";
                cmBoxSP.SelectedValue = ID;
                cmBoxDongSP.DisplayMember = "TenDong";
                cmBoxDongSP.ValueMember = "MaDSP";
                cmBoxDongSP.SelectedValue = sp.MaDSP;
                cmBoxSP.SelectedValue = ID;
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
            if (ID == null && Ischange == false)
            {
                cmBoxSP.Enabled = false;
                cmBoxDongSP.DisplayMember = "TenDong";
                cmBoxDongSP.ValueMember = "MaDSP";
                if (IDDSP != null)
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
            if (ID != null && Ischange == true)
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
        #region Kieu San Pham
        private void cmBoxMaSP_SelectedIndexChanged(object sender, EventArgs e)
        {
            string id = cmBoxMaSP.SelectedValue.ToString();
            //cmBoxMaKieuSP.DataSource = ChiTietSPBUS.GetChiTietSPByIDSP(id);
            //cmBoxMaKieuSP.DisplayMember = "MaKieu";
            //cmBoxMaKieuSP.ValueMember = "MaKieu";
            //cmBoxMauSP.DataSource = ChiTietSPBUS.GetAllMauSP();
            //cmBoxMauSP.ValueMember = "MaMau";
            //cmBoxMauSP.DisplayMember = "Mau";
            if (IDMode == "ts")
            {
                chiTietSPBindingSource.DataSource = ChiTietSPBUS.GetChiTietSPByIDSP(id);
                cmBoxMaKieuSP.DataSource = ChiTietSPBUS.GetChiTietSPByIDSP(id);
                cmBoxMaKieuSP.DisplayMember = "MaKieu";
                cmBoxMaKieuSP.ValueMember = "MaKieu";
                cmBoxMauSP.DataSource = ChiTietSPBUS.GetAllMauSP();
                cmBoxMauSP.ValueMember = "MaMau";
                cmBoxMauSP.DisplayMember = "Mau";
            }
            else
            {
                chiTietSPBindingSource.DataSource = ChiTietSPBUS.GetChiTietSPOderByMaCHByIDSP(IDMode, id);
                //cmBoxMaKieuSP.DataSource = ChiTietSPBUS.GetChiTietSPOderByMaCHByIDSP(IDMode,id);
                if (ChiTietSPBUS.GetChiTietSPOderByMaCHByIDSP(IDMode, id).Count != 0)
                {
                    cmBoxMaKieuSP.DataSource = ChiTietSPBUS.GetChiTietSPOderByMaCHByIDSP(IDMode, id);
                    cmBoxMaKieuSP.DisplayMember = "MaKieu";
                    cmBoxMaKieuSP.ValueMember = "MaKieu";
                }
                else { cmBoxMaKieuSP.DataSource = null; }
                cmBoxMauSP.DataSource = ChiTietSPBUS.GetAllMauSP();
                cmBoxMauSP.ValueMember = "MaMau";
                cmBoxMauSP.DisplayMember = "Mau";
            }
        }
        private void cmBoxMauSP_SelectedIndexChanged(object sender, EventArgs e)
        {

            try
            {
                //if (NewCTSP == true)
                //{
                //    string id = cmBoxMaKieuSP.SelectedValue.ToString();
                //    if (IDMode == "ts")
                //    {
                //        ChiTietSP sp = ChiTietSPBUS.Get1ChiTietSPByIDMaKieu(id);
                //        cmBoxMauSP.SelectedValue = sp.MaMau;
                //        txtBoxGiaSP.Text = sp.Gia.ToString();
                //        txtboxSoLuongAll.Text = sp.SoluongSP.ToString();
                //        //picBoxKieuSP.Image = ConverBinaryToImage(sp.Anh);
                //        picBoxKieuSP.BackgroundImage = ConverBinaryToImage(sp.Anh);
                //        textBoxPathAnh.Text = "";
                //    }
                //    else
                //    {
                //        ChiTietSP sp = ChiTietSPBUS.GetChiTietSPOderByMaCHByIDKieuSP(IDMode, id);
                //        cmBoxMauSP.SelectedValue = sp.MaMau;
                //        txtBoxGiaSP.Text = sp.Gia.ToString();
                //        txtboxSoLuongAll.Text = sp.SoluongSP.ToString();
                //        //picBoxKieuSP.Image = ConverBinaryToImage(sp.Anh);
                //        picBoxKieuSP.BackgroundImage = ConverBinaryToImage(sp.Anh);
                //        textBoxPathAnh.Text = "";
                //    }
                //}
            }
            catch { }


        }
        private void cmBoxMaKieuSP_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                string id = cmBoxMaKieuSP.SelectedValue.ToString();
                //ChiTietSP sp = ChiTietSPBUS.Get1ChiTietSPByIDMaKieu(id);
                if (IDMode == "ts")
                {
                    ChiTietSP sp = ChiTietSPBUS.Get1ChiTietSPByIDMaKieu(id);
                    cmBoxMauSP.DataSource = ChiTietSPBUS.GetAllMauSP();
                    cmBoxMauSP.ValueMember = "MaMau";
                    cmBoxMauSP.DisplayMember = "Mau";
                    cmBoxMauSP.SelectedValue = sp.MaMau;
                    txtBoxGiaSP.Text = sp.Gia.ToString();
                    txtboxSoLuongAll.Text = sp.SoluongSP.ToString();
                    //picBoxKieuSP.Image = null;
                    picBoxKieuSP.BackgroundImage = null;
                    textBoxPathAnh.Text = "";
                    //picBoxKieuSP.Image = ConverBinaryToImage(sp.Anh);
                    picBoxKieuSP.BackgroundImage = ConverBinaryToImage(sp.Anh);
                }
                else
                {
                    ChiTietSP sp = ChiTietSPBUS.GetChiTietSPOderByMaCHByIDKieuSP(IDMode, id);

                    cmBoxMauSP.SelectedValue = sp.MaMau;
                    txtBoxGiaSP.Text = sp.Gia.ToString();
                    txtboxSoLuongAll.Text = sp.SoluongSP.ToString();
                    //picBoxKieuSP.Image = null;
                    picBoxKieuSP.BackgroundImage = null;
                    textBoxPathAnh.Text = "";
                    //picBoxKieuSP.Image = ConverBinaryToImage(sp.Anh);
                    picBoxKieuSP.BackgroundImage = ConverBinaryToImage(sp.Anh);
                }
                //cmBoxMauSP.SelectedValue = sp.MaMau;
                //txtBoxGiaSP.Text = sp.Gia.ToString();
                //txtboxSoLuongAll.Text = sp.SoluongSP.ToString();
                //picBoxKieuSP.Image = null;
                //textBoxPathAnh.Text = "";
                //picBoxKieuSP.Image = ConverBinaryToImage(sp.Anh);

            }
            catch { }
        }
        string filename;
        Image ConverBinaryToImage(byte[] data)
        {
            using (MemoryStream ms = new MemoryStream(data))
            {
                return Image.FromStream(ms);
            }
        }
        byte[] CovertImageToBinary(Image img)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                img.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                return ms.ToArray();
            }
        }

        private void btnAnh_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog() { Filter = "JPEG|*.jpg", ValidateNames = true, Multiselect = false })
            {
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    filename = ofd.FileName;
                    textBoxPathAnh.Text = filename;
                    //picBoxKieuSP.Image = Image.FromFile(filename);
                    picBoxKieuSP.BackgroundImage = Image.FromFile(filename);
                }
            }
        }

        #endregion
        private bool NewCTSP;
        private async void btnLuuKieuSP_Click(object sender, EventArgs e)
        {
            using (GalaxyMobileEntities db = new GalaxyMobileEntities())
            {
                ChiTietSP sp = new ChiTietSP();
                try
                {
                    // sp.Anh = CovertImageToBinary(picBoxKieuSP.Image);
                    sp.Anh = CovertImageToBinary(picBoxKieuSP.BackgroundImage);
                }
                catch
                {
                    
                }
                sp.Gia = 0;
                sp.SoluongSP = 0;
                sp.MaKieu = textBoxMaKieu.Text;
                sp.MaSP = /*textBoxMaSP.Text;*/ cmBoxMaSP.SelectedValue.ToString();
                sp.MaMau = cmBoxMauSP.SelectedValue.ToString();
                try
                {
                    if (NewCTSP)
                    {

                        db.ChiTietSPs.Add(sp);
                    db.SaveChanges();
                    //    await db.SaveChangesAsync();
                        MessageBox.Show("Thêm Thành Công!", "Thông Báo");

                        ChiTietSPBUS.Them_CTSPMoi_Into_KhoHang_(sp.MaKieu);
                    }
                    else
                    {
                        try
                        {
                            // sp.Anh = CovertImageToBinary(picBoxKieuSP.Image);
                            sp.Anh = CovertImageToBinary(picBoxKieuSP.BackgroundImage);
                        }
                        catch
                        {
                            sp.Anh = ChiTietSPBUS.LayAnhKieuSP(cmBoxMaKieuSP.SelectedValue.ToString(), cmBoxMaSP.SelectedValue.ToString());
                        }
                       
                        int r = dgvCTSP.CurrentCell.RowIndex;
                        //sp.Gia = Convert.ToDecimal(dgvCTSP.Rows[r].Cells[3].Value.ToString());
                        sp.Gia = Convert.ToDecimal(txtBoxGiaSP.Text);
                        sp.SoluongSP = Convert.ToInt32(txtboxSoLuongAll.Text);
                        db.ChiTietSPs.Attach(sp);
                        db.Entry(sp).State = System.Data.Entity.EntityState.Modified;
                        await db.SaveChangesAsync();
                        MessageBox.Show("Thay Đổi Thành Công!", "Thông Báo");
                        string id = cmBoxMaSP.SelectedValue.ToString();
                        chiTietSPBindingSource.DataSource = ChiTietSPBUS.GetChiTietSPByIDSP(id);
                    }

            }
                catch { MessageBox.Show("Không Thể Thực Hiện Thao Tác!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error); }

        }
            btnLuuKieuSP.Visible = false;
            btnHuyKieuSP.Visible = false;
            btnThemKieuSP.Visible = true;
            btnChinhSuaKieuSP.Visible = true;
            btnXoaKieuSP.Visible = true;
            textBoxMaKieu.ReadOnly = false;
            textBoxMaSP.ReadOnly = false;
            textBoxMaKieu.Visible = false;
            textBoxMaSP.Visible = false;
            txtBoxGiaSP.ReadOnly = true;
            textBoxMau.Visible = false;
            dgvCTSP.Enabled = true;
        }

        private void btnThemKieuSP_Click(object sender, EventArgs e)
        {
            NewCTSP = true;

            dgvCTSP.Enabled = false;

            cmBoxMauSP.DataSource = ChiTietSPBUS.GetAllMauSP();
            cmBoxMauSP.ValueMember = "MaMau";
            cmBoxMauSP.DisplayMember = "Mau";
            textBoxMaKieu.Visible = true;
            textBoxMaKieu.Text = "";
            textBoxMaSP.Visible = true;
            txtBoxGiaSP.Text = "0";
            txtboxSoLuongAll.Text = "0";
            btnLuuKieuSP.Visible = true;
            btnHuyKieuSP.Visible = true;
            btnThemKieuSP.Visible = false;
            btnChinhSuaKieuSP.Visible = false;
            btnXoaKieuSP.Visible = false;
            textBoxMaSP.Text = cmBoxMaSP.SelectedValue.ToString();
        }

        private void btnChinhSuaKieuSP_Click(object sender, EventArgs e)
        {
            NewCTSP = false;
            dgvCTSP.Enabled = false;

            textBoxMaKieu.Visible = true;
            textBoxMaSP.Visible = true;
            textBoxMaKieu.ReadOnly = true;
            textBoxMaSP.ReadOnly = true;
            //cmBoxMauSP.DataSource = ChiTietSPBUS.GetAllMauSP();
            //cmBoxMauSP.ValueMember = "MaMau";
            //cmBoxMauSP.DisplayMember = "Mau";
            btnLuuKieuSP.Visible = true;
            btnHuyKieuSP.Visible = true;
            btnThemKieuSP.Visible = false;
            btnChinhSuaKieuSP.Visible = false;
            btnXoaKieuSP.Visible = false;
            txtBoxGiaSP.ReadOnly = false;
            textBoxMaSP.Text = cmBoxMaSP.SelectedValue.ToString();
            textBoxMaKieu.Text = cmBoxMaKieuSP.SelectedValue.ToString();
            textBoxMau.Text = cmBoxMauSP.SelectedValue.ToString();
            textBoxMau.Visible = true;
        }

        private void dgvCTSP_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {

              
                    int r = dgvCTSP.CurrentCell.RowIndex;
                    textBoxMaKieu.Text = dgvCTSP.Rows[r].Cells[1].Value.ToString();
                    cmBoxMaKieuSP.SelectedValue = dgvCTSP.Rows[r].Cells[1].Value.ToString();
                    textBoxMaSP.Text = dgvCTSP.Rows[r].Cells[0].Value.ToString();
                    cmBoxMaSP.SelectedValue = dgvCTSP.Rows[r].Cells[0].Value.ToString();
                    txtBoxGiaSP.Text = dgvCTSP.Rows[r].Cells[3].Value.ToString();
                    txtboxSoLuongAll.Text = dgvCTSP.Rows[r].Cells[4].Value.ToString();
                    cmBoxMauSP.SelectedValue = dgvCTSP.Rows[r].Cells[2].Value.ToString();
              
            }
            catch { }
        }

        private void btnHuyKieuSP_Click(object sender, EventArgs e)
        {
            dgvCTSP.Enabled = true;
            btnLuuKieuSP.Visible = false;
            btnHuyKieuSP.Visible = false;
            btnThemKieuSP.Visible = true;
            btnChinhSuaKieuSP.Visible = true;
            btnXoaKieuSP.Visible = true;
            textBoxMaKieu.ReadOnly = false;
            textBoxMaSP.ReadOnly = false;
            textBoxMaKieu.Visible = false;
            textBoxMaSP.Visible = false;
            cmBoxMauSP.DataSource = ChiTietSPBUS.GetAllMauSP();
            cmBoxMauSP.ValueMember = "MaMau";
            cmBoxMauSP.DisplayMember = "Mau";
            textBoxMau.Visible = false;
            int r = dgvCTSP.CurrentCell.RowIndex;
            textBoxMaKieu.Text = dgvCTSP.Rows[r].Cells[1].Value.ToString();
            cmBoxMaKieuSP.SelectedValue = dgvCTSP.Rows[r].Cells[1].Value.ToString();
            textBoxMaSP.Text = dgvCTSP.Rows[r].Cells[0].Value.ToString();
            cmBoxMaSP.SelectedValue = dgvCTSP.Rows[r].Cells[0].Value.ToString();
            txtBoxGiaSP.Text = dgvCTSP.Rows[r].Cells[3].Value.ToString();
            txtboxSoLuongAll.Text = dgvCTSP.Rows[r].Cells[4].Value.ToString();
            cmBoxMauSP.SelectedValue = dgvCTSP.Rows[r].Cells[2].Value.ToString();
        }

        private void btnXoaKieuSP_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc muốn xóa dòng này không?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
              
                try
                {
                    ChiTietSPBUS.XoaKieuSp(cmBoxMaKieuSP.SelectedValue.ToString());
                    MessageBox.Show("Xóa Thành Công!", "Thông Báo");
                    string id = cmBoxMaSP.SelectedValue.ToString();
                    chiTietSPBindingSource.DataSource = ChiTietSPBUS.GetChiTietSPByIDSP(id);


                }
                catch { MessageBox.Show("Không Thể Thực Hiện Thao Tác!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            }
        }

        private void cmBoxTenMau_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmBoxTenMau.DisplayMember = "Mau";
            cmBoxTenMau.ValueMember = "MaMau";
            try {
                txtboxMaMau.Text = cmBoxTenMau.SelectedValue.ToString();
            }
            catch { txtboxMaMau.Text = " "; }
     
        }

        private void btnThemMau_Click(object sender, EventArgs e)
        {
            MauSP mau = new MauSP();
            mau.MaMau = txtboxMaMau.Text;
            mau.Mau = txtBoxTenMau.Text;

            try
            {
                MauBUS.ThemMauSP(mau);
                MessageBox.Show("Thêm Thành Công!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                
            }
            catch { MessageBox.Show("Không Thể Thực Hiện Thao Tác", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            txtBoxTenMau.Visible = false;

        }

        private void btnXoaMau_Click(object sender, EventArgs e)
        {
            MauSP mau = new MauSP();
            mau.MaMau = txtboxMaMau.Text;
            mau.Mau = txtBoxTenMau.Text;
            try
            {
                MauBUS.XoaMauSP(mau);
                MessageBox.Show("Xóa Thành Công!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch { MessageBox.Show("Không Thể Thực Hiện Thao Tác", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            txtBoxTenMau.Visible = true;
        }

        private void btnLuuMau_Click(object sender, EventArgs e)
        {
            txtBoxTenMau.Visible = true;
            txtboxMaMau.Text=" ";
            txtBoxTenMau.Text=" ";
            
        }
    }

}
