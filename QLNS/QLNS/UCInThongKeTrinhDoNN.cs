using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;
using BUL;

namespace QLNS
{
    public partial class UCInThongKeTrinhDoNN : UserControl
    {
        public UCInThongKeTrinhDoNN()
        {
            InitializeComponent();
        }
        private TrinhDoNgoaiNguBUL trinhDoNgoaiNguBUL = new TrinhDoNgoaiNguBUL();
        private void UCInThongKeTrinhDoNN_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'QUANLYNHANSUDataSet.View_ThongKeTrinhDoNgoaiNgu' table. You can move, or remove it, as needed.
            this.View_ThongKeTrinhDoNgoaiNguTableAdapter.Fill(this.QUANLYNHANSUDataSet.View_ThongKeTrinhDoNgoaiNgu);
            this.reportViewer1.SetDisplayMode(Microsoft.Reporting.WinForms.DisplayMode.PrintLayout);
            this.reportViewer1.ZoomMode = Microsoft.Reporting.WinForms.ZoomMode.PageWidth;
            this.reportViewer1.RefreshReport();

            cbbNgoaiNgu.DataSource = trinhDoNgoaiNguBUL.LayBangTrinhDoNgoaiNgu();
            cbbNgoaiNgu.DisplayMember = "ngoaingu";
            cbbNgoaiNgu.ValueMember = "ngoaingu";
            cbbNgoaiNgu.SelectedIndex = 0;

            SetParameters(cbbNgoaiNgu.SelectedValue.ToString());
            this.reportViewer1.RefreshReport();

        }

        private void SetParameters(string ngoaiNgu)
        {
            ReportParameter pr = new ReportParameter("NgoaiNgu");
            pr.Values.Add(ngoaiNgu);
            reportViewer1.LocalReport.SetParameters(pr);
        }

        private void btnThongKeNN_Click(object sender, EventArgs e)
        {
            string s = cbbNgoaiNgu.SelectedValue.ToString();
            SetParameters(cbbNgoaiNgu.SelectedValue.ToString());
            reportViewer1.RefreshReport();
        }
    }
}
