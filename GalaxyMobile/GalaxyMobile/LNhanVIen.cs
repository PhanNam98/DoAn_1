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
namespace GalaxyMobile
{
    public partial class LNhanVIen : Form
    {
        bool Them = false;
        public LNhanVIen()
        {
            InitializeComponent();
        }
        // chưa có xác trùng khóa 

        public void LoadData()
        {
            loaiNVBindingSource.DataSource = LoaiNvBUS.GetLNV();
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

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnCancelLNV_Click(object sender, EventArgs e)
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

        private void btnDelLNV_Click(object sender, EventArgs e)
        {
            try
            {
                // Lấy thứ tự record hiện hành 
                int r = dgvLNV.CurrentCell.RowIndex;
                // Lấy MaKH của record hiện hành 
                string strMaLNV =
                dgvLNV.Rows[r].Cells[0].Value.ToString();
                LoaiNvBUS.XoaLNV(strMaLNV);
                LoadData();
                //dgvNV_CellClick(null, null);
                MessageBox.Show("Đã xóa xong!");
            }
            catch
            {
                MessageBox.Show("Không được phép xóa nhân viên này");
            }
        }

        private void LNhanVIen_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            // Kích hoạt biến Sửa
            Them = false;
            dgvLNV_CellClick(null, null);
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
            txtMa.Enabled = false;
            txtTenLoai.Focus();
        }

        private void dgvLNV_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Lấy thứ tự record hiện hành 
            int r = dgvLNV.CurrentCell.RowIndex;
            txtMa.Text = dgvLNV.Rows[r].Cells[0].Value.ToString();
            txtTenLoai.Text = dgvLNV.Rows[r].Cells[1].Value.ToString();
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

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (Them)
            {
                if (LoaiNvBUS.KtMaLNV(txtMa.Text) > 0)
                {
                    MessageBox.Show("Mã nhân viên tồn tai. Nhập Mã nhân viên khác !");
                    txtMa.ResetText();
                    txtTenLoai.ResetText();
                    txtMa.Focus();
                }
                else
                {
                    LoaiNvBUS.ThemLNV(txtMa.Text, txtTenLoai.Text);
                    LoadData();
                    // Thông báo 
                    MessageBox.Show("Đã thêm xong!");
                }
            }
            else
            {
                int r = dgvLNV.CurrentCell.RowIndex;
                // MaNV hiện hành 
                string strMaNV = dgvLNV.Rows[r].Cells[0].Value.ToString();
                LoaiNvBUS.SuaLNV(txtMa.Text, txtTenLoai.Text);
                LoadData();
                // Thông báo 
                MessageBox.Show("Đã sửa xong!");
            }
        }
    }
}
