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

namespace QLNS
{

    public partial class UCMain : UserControl
    {
        private PhongBanBUL phongBanBUL = new PhongBanBUL();
        private HoSoBUL hoSoBUL = new HoSoBUL();
        private TrinhDoChuyenMonBUL trinhDoChuyenMonBUL = new TrinhDoChuyenMonBUL();
        private TrinhDoNgoaiNguBUL trinhDoNgoaiNguBUL = new TrinhDoNgoaiNguBUL();

        public UCMain()
        {
            InitializeComponent();
        }
        private void UCMain_Load(object sender, EventArgs e)
        {
            InitChartTrinhDoChuyenMon();
            InitChartTrinhDoNgoaiNgu();
            InitLabelHoSo();
            InitLabelPhongBan();
            DateTime dt = DateTime.Now;
            lbTime.Text = "Hà Nội, ngày " + dt.Day + " tháng " + dt.Month + " năm " + dt.Year;
        }
        public void InitLabelHoSo()
        {
            lbTongHoSo.Text = hoSoBUL.TongSoHoSo().ToString();
        }
        public void InitLabelPhongBan()
        {
            lbTongPhongBan.Text = phongBanBUL.TongSoPhongBan().ToString();
        }
        private void InitChartTrinhDoChuyenMon()
        {
            chartTrinhDoChuyenMon.DataSource = trinhDoChuyenMonBUL.DemTrinhDoChuyenMonTheoTen();
        }
        private void InitChartTrinhDoNgoaiNgu()
        {
            chartTrinhDoNgoaiNgu.DataSource = trinhDoNgoaiNguBUL.DemTrinhDoNgoaiNguTheoTen(); ;
        }
    }
}
