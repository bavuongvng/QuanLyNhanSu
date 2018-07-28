using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BUL;


namespace QLNS
{
    public partial class frmAddTDCM : Form
    {
        private HoSoBUL hosoBUL = new HoSoBUL();
        private TrinhDoChuyenMonBUL trinhDoChuyenMonBUL = new TrinhDoChuyenMonBUL();
        public frmAddTDCM()
        {
            InitializeComponent();
        }

        private void frmAddTDCM_Load(object sender, EventArgs e)
        {
            cbbMaNV.DataSource = trinhDoChuyenMonBUL.LayThongTinTrinhDoCHuyenMongopMa();
            cbbMaNV.DisplayMember = "MaNhanVien";
            cbbMaNV.ValueMember = "MaNhanVien";
            cboTrinhDo.DataSource = trinhDoChuyenMonBUL.LayThongTinTrinhDoCHuyenMongopTD();
            cboTrinhDo.DisplayMember = "TrinhDo";
            cboTrinhDo.ValueMember = "TrinhDo";
            cbbLoaiHinhDT.DataSource = trinhDoChuyenMonBUL.LayThongTinTrinhDoCHuyenMongopLHDT();
            cbbLoaiHinhDT.DisplayMember = "LoaiHinhDaoTao";
            cbbLoaiHinhDT.ValueMember = "LoaiHinhDaoTao";

        }


        private void btnThemTDCM_Click_1(object sender, EventArgs e)
        {
            int maNV = Convert.ToInt32(cbbMaNV.SelectedValue);
            txtTenNV.Text = hosoBUL.LayTenTheoMaNhanVien(Convert.ToInt32(cbbMaNV.SelectedValue.ToString()));
            string nganh = txtNganh.Text.ToString();
            string trinhdo = cboTrinhDo.SelectedValue.ToString();
            string loaihinhDT = cbbLoaiHinhDT.SelectedValue.ToString();
            string truongDT = txtTruongDT.Text.ToString();
            bool kt = trinhDoChuyenMonBUL.ThemTDCM(maNV, nganh, trinhdo, loaihinhDT, truongDT);
            if (kt)
            {
                MessageBox.Show("Thêm thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Thêm thất bại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            UCQLTrinhDoChuyenMon uCQLTrinhDoChuyen = new UCQLTrinhDoChuyenMon();
            uCQLTrinhDoChuyen.hienThi();
            this.Close();
        }

        private void btnHuyTDCM_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cbbMaNV_SelectionChangeCommitted_1(object sender, EventArgs e)
        {
            txtTenNV.Text = hosoBUL.LayTenTheoMaNhanVien(Convert.ToInt32(cbbMaNV.SelectedValue));
        }
    }
}
