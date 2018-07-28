using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BUL;
using Microsoft.Reporting.WinForms;
using DTO;

namespace QLNS
{
    public partial class UCInHoSo : UserControl
    {
        private HoSoBUL hoSoBUL = new HoSoBUL();
        public UCInHoSo()
        {
            InitializeComponent();
        }

        private void UCInHoSo_Load(object sender, EventArgs e)
        {
            this.V_HOSONVTableAdapter.Fill(this.QUANLYNHANSUDataSet.V_HOSONV);
            this.reportViewer1.SetDisplayMode(Microsoft.Reporting.WinForms.DisplayMode.PrintLayout);
            this.reportViewer1.ZoomMode = Microsoft.Reporting.WinForms.ZoomMode.PageWidth;
            this.reportViewer1.RefreshReport();

            cbbMaNhanVien.DataSource = hoSoBUL.LayDSHoSo();
            cbbMaNhanVien.DisplayMember = "manhanvien";
            cbbMaNhanVien.ValueMember = "manhanvien";
            lbTen.Text = hoSoBUL.LayTenTheoMaNhanVien(Convert.ToInt32(cbbMaNhanVien.SelectedValue.ToString()));

            HoSoDTO hs = hoSoBUL.LayNhanVienTheoMa(Convert.ToInt32(cbbMaNhanVien.SelectedValue.ToString()));

            SetParameter(Convert.ToInt32(cbbMaNhanVien.SelectedValue.ToString()), hs.MaPhongBan);
            reportViewer1.RefreshReport();
        }

        public void SetParameter(int maNhanVien, int maPhongBan)
        {
            ReportParameter[] pr = new ReportParameter[2];
            pr[0] = new ReportParameter("maNhanVien");
            pr[1] = new ReportParameter("maphongban");
            pr[0].Values.Add(maNhanVien.ToString());
            pr[1].Values.Add(maPhongBan.ToString());
            reportViewer1.LocalReport.SetParameters(pr);
        }

        private void cbbMaNhanVien_SelectionChangeCommitted(object sender, EventArgs e)
        {
            lbTen.Text = hoSoBUL.LayTenTheoMaNhanVien(Convert.ToInt32(cbbMaNhanVien.SelectedValue.ToString()));
        }

        private void btnThongKe_Click(object sender, EventArgs e)
        {
            HoSoDTO hs = hoSoBUL.LayNhanVienTheoMa(Convert.ToInt32(cbbMaNhanVien.SelectedValue.ToString()));
            SetParameter(Convert.ToInt32(cbbMaNhanVien.SelectedValue.ToString()), hs.MaPhongBan);
            reportViewer1.RefreshReport();
        }
    }
}
