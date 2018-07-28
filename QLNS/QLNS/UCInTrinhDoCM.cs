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

namespace QLNS
{
    public partial class UCInTrinhDoCM : UserControl
    {
        private TrinhDoChuyenMonBUL trinhDoChuyenMonBUL = new TrinhDoChuyenMonBUL();
        public UCInTrinhDoCM()
        {
            InitializeComponent();
        }

        private void UCInTrinhDoCM_Load(object sender, EventArgs e)
        {
            this.View_InTrinhDoCMTableAdapter.Fill(this.QUANLYNHANSUDataSet.View_InTrinhDoCM);
            this.reportViewer1.SetDisplayMode(Microsoft.Reporting.WinForms.DisplayMode.PrintLayout);
            this.reportViewer1.ZoomMode = Microsoft.Reporting.WinForms.ZoomMode.PageWidth;
            this.reportViewer1.RefreshReport();

            cbbTrinhDo.DataSource = trinhDoChuyenMonBUL.LayDSTrinhDo();
            cbbTrinhDo.DisplayMember = "trinhdo";
            cbbTrinhDo.ValueMember = "trinhdo";
            cbbTrinhDo.SelectedIndex = 0;

            SetParameter(cbbTrinhDo.SelectedValue.ToString());
            reportViewer1.RefreshReport();
        }

        public void SetParameter(string trinhdo)
        {
            ReportParameter pr = new ReportParameter("trinhdo");
            pr.Values.Add(trinhdo);
            reportViewer1.LocalReport.SetParameters(pr);
        }

        private void btnThongKe_Click(object sender, EventArgs e)
        {
            SetParameter(cbbTrinhDo.SelectedValue.ToString());
            reportViewer1.RefreshReport();
        }
    }
}
