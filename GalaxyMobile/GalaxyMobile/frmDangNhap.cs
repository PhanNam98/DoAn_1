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
    public partial class frmDangNhap : Form
    {
        public frmDangNhap()
        {
            InitializeComponent();
        }

        private void frmDangNhap_Load(object sender, EventArgs e)
        {
            txtPass._TextBox.PasswordChar = '*';
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            DialogResult traloi;
            traloi = MessageBox.Show("Bạn có muốn thoát không", "Thoát", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (traloi == DialogResult.OK)
                Application.Exit();
        }

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            if ( TaiKhoanBUS.kttk(txtUser._TextBox.Text, txtPass._TextBox.Text) != null)
            {
                //   call(GetAccount(DBTaiKhoan.kttk(txtUser.Text, txtPass.Text)).tenDN);
                this.Hide();
                int ma = TaiKhoanBUS.MaTruyCap(txtUser._TextBox.Text, txtPass._TextBox.Text);
                Form frm;
                if (ma == 0 || ma == 1 || ma == 2)
                {
                    frm = new frmMainServer(TaiKhoanBUS.kttk(txtUser._TextBox.Text, txtPass._TextBox.Text), ma);
                    frm.ShowDialog();
                }
                else
                {
                    frm = new frmMainClient(TaiKhoanBUS.kttk(txtUser._TextBox.Text, txtPass._TextBox.Text), ma);
                    frm.ShowDialog();
                }
                this.Show();
            }
           
            else
            {
                MessageBox.Show("Tên đăng nhặp hoặc mật khẩu đã nhập sai. Mời nhập lại", "Lỗi rồi!!!");
                txtPass._TextBox.ResetText();
                txtUser._TextBox.ResetText();
                txtUser._TextBox.Focus();
            }
        }
    }
}
