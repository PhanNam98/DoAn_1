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
    public partial class frmInHoaDon : Form
    {
        public frmInHoaDon(string idhd,string idch)
        {
            InitializeComponent();
            IDCH = idch;
            IDHD = idhd;
        }
        private string IDHD;
        private string IDCH;
        private void frmInHoaDon_Load(object sender, EventArgs e)
        {

            InHoaDon_ResultBindingSource.DataSource = HoaDonBUS.InHD(IDHD, IDCH);
            HoaDon hd = HoaDonBUS.Get1HD(IDHD, IDCH);
            KhachHang kh = KHBUS.GetKHByMAKH(hd.MaKH);
            CuaHang ch = CuaHangBUS.GetThongTinCuaHang(hd.MaCuaHang);
            Microsoft.Reporting.WinForms.ReportParameter[] rParams = new Microsoft.Reporting.WinForms.ReportParameter[]
            {
                new Microsoft.Reporting.WinForms.ReportParameter("DateNhap",hd.NgayLapHD.ToShortDateString().ToString()),
                new Microsoft.Reporting.WinForms.ReportParameter("TongTien",ChiTietHoaDonBUS.TinhTien_ByMaHD(IDHD,IDCH).ToString()),
            new Microsoft.Reporting.WinForms.ReportParameter("TenCH",ch.TenCuaHang),
            new Microsoft.Reporting.WinForms.ReportParameter("DiaChi",ch.DiaChi),
            new Microsoft.Reporting.WinForms.ReportParameter("TenNguoiMua",kh.TenKH),
            new Microsoft.Reporting.WinForms.ReportParameter("DiaChiNguoiMua",kh.DiaChi),
                new Microsoft.Reporting.WinForms.ReportParameter("SDT",kh.SDT),
            new Microsoft.Reporting.WinForms.ReportParameter("HtGiaoHang",hd.HTGiaoHang),
            new Microsoft.Reporting.WinForms.ReportParameter("MaHD",IDHD)
            };
            
           
            reportInHD.LocalReport.SetParameters(rParams);
            this.reportInHD.RefreshReport();
        }
    }
}
