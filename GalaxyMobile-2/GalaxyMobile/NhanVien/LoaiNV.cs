using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GalaxyMobile
{
    public partial class LoaiNV : Form
    {
        bool Them = false;
        public LoaiNV()
        {
            InitializeComponent();
        }
        void LoadData()
        {

        }
        private void dgvLoaiNV_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Thứ tự dòng hiện hành 
            int r = dgvLoaiNV.CurrentCell.RowIndex;
            // Chuyển thông tin lên panel 
            txtMaLoai.Text = dgvLoaiNV.Rows[r].Cells[0].Value.ToString();
            txtTenLoai.Text = dgvLoaiNV.Rows[r].Cells[1].Value.ToString();
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            // Xóa trống các đối tượng trong Panel 
            txtMaLoai.ResetText();
            txtTenLoai.ResetText();
            // Cho thao tác trên các nút Thêm / Sửa / Xóa / Thoát 
            btnThem.Enabled = true;
            btnSua.Enabled = true;
            btnXoa.Enabled = true;
            bthThoat.Enabled = true;
            // Không cho thao tác trên các nút Lưu / Hủy / Panel 
            btnLuu.Enabled = false;
            btnHuy.Enabled = false;
            panel.Enabled = false;
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            // Kích hoạt biến Sửa
            Them = false;
            dgvLoaiNV_CellClick(null, null);
            // Cho phép thao tác trên Panel 
            panel.Enabled = true;
            // Cho thao tác trên các nút Lưu / Hủy / Panel 
            btnLuu.Enabled = true;
            btnHuy.Enabled = true;
            // Không cho thao tác trên các nút Thêm / Xóa / Thoát 
            btnThem.Enabled = false;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            bthThoat.Enabled = false;
            // Đưa con trỏ đến TextField txtTenKH          
            txtMaLoai.Enabled = false;
            txtTenLoai.Focus();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            Them = true;
            txtMaLoai.Enabled = true;
            // Xóa trống các đối tượng trong Panel 
            txtMaLoai.ResetText();
            txtTenLoai.ResetText();
            // Cho thao tác trên các nút Lưu / Hủy / Panel 
            btnLuu.Enabled = true;
            btnHuy.Enabled = true;
            panel.Enabled = true;
            // Không cho thao tác trên các nút Thêm / Xóa / Thoát 
            btnThem.Enabled = false;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            bthThoat.Enabled = false;
            txtMaLoai.Focus();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                // Lấy thứ tự record hiện hành                 
                int r = dgvLoaiNV.CurrentCell.RowIndex;
                // Lấy MaKH của record hiện hành 
                string strMaloai =
                dgvLoaiNV.Rows[r].Cells[0].Value.ToString();
               // DBLoaiNV.DelLoaiNV(strMaloai);
                LoadData();
                dgvLoaiNV_CellClick(null, null);
                MessageBox.Show("Đã xóa xong!");
            }
            catch
            {
                MessageBox.Show("Loại nhân viên này không thể xóa vì vẫn còn nhân viên ở chức vụ này");
            }
        }

        private void btnReload_Click(object sender, EventArgs e)
        {
            LoadData();
            dgvLoaiNV_CellClick(null, null);
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (Them)
            {
               //if (DBLoaiNV.KtLoai(txtMaLoai.Text) > 0)
               // {
               //     MessageBox.Show("Mã khách hàng tồn tai. Nhập Mã khách hàng khác !");
               //     txtMaLoai.ResetText();
               //     txtTenLoai.ResetText();
               //     txtMaLoai.Focus();
               // }
                //else
                {
                    //decimal tien = Convert.ToDecimal(txtTien.Text);
                   // DBLoaiNV.InsertLoaiNV(txtMaLoai.Text, txtTenLoai.Text, tien);
                    LoadData();
                    // Thông báo
                    MessageBox.Show("Đã thêm xong!");
                }
            }
            else
            {
                int r = dgvLoaiNV.CurrentCell.RowIndex;

                string strMA =
                dgvLoaiNV.Rows[r].Cells[0].Value.ToString();
                //decimal tien = Convert.ToDecimal(txtTien.Text);
                //DBLoaiNV.UpdateLoaiNV(strMA, txtTenLoai.Text, tien);
                LoadData();
                // Thông báo 
                MessageBox.Show("Đã sửa xong!");
            }
        }

        private void bthThoat_Click(object sender, EventArgs e)
        {
            // Khai báo biến traloi 
            DialogResult traloi;
            // Hiện hộp thoại hỏi đáp 
            traloi = MessageBox.Show("Chắc không?", "Trả lời",
            MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            // Kiểm tra có nhắp chọn nút Ok không? 
            if (traloi == DialogResult.OK) this.Close();
        }
    }
}
