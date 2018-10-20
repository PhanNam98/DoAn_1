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
using DAO;
using Model;
namespace GalaxyMobile
{
    public partial class frmLoaiSP : Form
    {
        bool Them = false;
        public frmLoaiSP()
        {
            InitializeComponent();
        }
        public void LoadData()
        {
            loaiSPBindingSource.DataSource = LoaiSPBUS.GetAllLoaiSP();
            txtMa.ResetText();
            txtTenLoai.ResetText();
            // Không cho thao tác trên các nút Lưu / Hủy 
            btnLuu.Enabled = false;
            btnHuy.Enabled = false;
            panel.Enabled = false;
            // Cho thao tác trên các nút Thêm / Sửa / Xóa / Thoát 
            btnThem.Enabled = true;
            btnSua.Enabled = true;
            btnXoa.Enabled = true;
        }
        private void LoaiSP_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            Them = true;
            txtMa.Enabled = true;
            // Xóa trống các đối tượng trong Panel 
            txtMa.ResetText();
            txtTenLoai.ResetText();
            // Cho thao tác trên các nút Lưu / Hủy / Panel 
            btnLuu.Enabled = true;
            btnHuy.Enabled = true;
            panel.Enabled = true;
            // Không cho thao tác trên các nút Thêm / Xóa / Thoát 
            btnThem.Enabled = false;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            txtMa.Focus();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            // Kích hoạt biến Sửa
            Them = false;
            dgvLSP_CellClick(null, null);
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
            txtMa.Enabled = false;
            txtTenLoai.Focus();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                // Lấy thứ tự record hiện hành 
                int r = dgvLSP.CurrentCell.RowIndex;
                // Lấy MaKH của record hiện hành 
                LoaiSP a = new LoaiSP();
                a.TenLSP = txtTenLoai.Text;
                a.MaLSP = txtMa.Text;
                LoaiSPBUS.XoaLSP(a);            
                LoadData();
                //dgvNV_CellClick(null, null);
                MessageBox.Show("Đã xóa xong!");
            }
            catch
            {
                MessageBox.Show("Không được phép xóa nhân viên này");
            }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            // Xóa trống các đối tượng trong Panel 
            txtMa.ResetText();
            txtTenLoai.ResetText();
            // Cho thao tác trên các nút Thêm / Sửa / Xóa / Thoát 
            btnThem.Enabled = true;
            btnSua.Enabled = true;
            btnXoa.Enabled = true;
            // Không cho thao tác trên các nút Lưu / Hủy / Panel 
            btnLuu.Enabled = false;
            btnHuy.Enabled = false;
            panel.Enabled = false;
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (Them)
            {
                try
                {
                    LoaiSP sp = new LoaiSP();
                    sp.MaLSP = txtMa.Text;sp.TenLSP = txtTenLoai.Text;
                    LoaiSPBUS.ThemLSP(sp);
                    LoadData();
                    // Thông báo 
                    MessageBox.Show("Đã thêm xong!");
                }
                catch
                {
                    MessageBox.Show("Mã loại sản phẩm tồn tai. Nhập Mã loại sản phẩm khác !");
                    txtMa.ResetText();
                    txtTenLoai.ResetText();
                    txtMa.Focus();
                }
            }
            else
            {
                LoaiSP sp = new LoaiSP();
                sp.MaLSP = txtMa.Text; sp.TenLSP = txtTenLoai.Text;
                LoaiSPBUS.SuaLSP(sp);
                LoadData();
                // Thông báo 
                MessageBox.Show("Đã sửa xong!");
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgvLSP_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Lấy thứ tự record hiện hành 
            int r = dgvLSP.CurrentCell.RowIndex;
            txtMa.Text = dgvLSP.Rows[r].Cells[0].Value.ToString();
            txtTenLoai.Text= dgvLSP.Rows[r].Cells[1].Value.ToString();
        }
    }
}
