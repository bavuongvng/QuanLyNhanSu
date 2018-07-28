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
using DTO;

namespace QLNS
{
    public partial class frmSuaQTCT : Form
    {
        private QuaTrinhCongTacBUL quaTrinhCongTacBUL = new QuaTrinhCongTacBUL();
        private ChucVuBUL chucVuBUL = new ChucVuBUL();
        private HoSoBUL hoSoBUL = new HoSoBUL();
        public frmSuaQTCT()
        {
            InitializeComponent();
        }

        private void frmSuaQTCT_Load(object sender, EventArgs e)
        {
            lbMaNhanVien.Text = this.Tag.ToString();
            List<QuaTrinhCongTacDTO> ds = quaTrinhCongTacBUL.LayDSQuaTrinhCongTacTheoMaNV(Convert.ToInt32(this.Tag.ToString()));
            cbbTuNgay.DataSource = quaTrinhCongTacBUL.LayDSQuaTrinhCongTacTheoMaNV(Convert.ToInt32(this.Tag.ToString()));
            cbbTuNgay.DisplayMember = "tungay";
            cbbTuNgay.ValueMember = "tungay";
            cbbTuNgay.SelectedIndex = 0;
            dtDenNgay.Format = DateTimePickerFormat.Custom;
            dtDenNgay.CustomFormat = "dd/MM/yyyy";

            DateTime dt = DateTime.ParseExact(cbbTuNgay.SelectedValue.ToString(), "dd/MM/yyyy", null);

            QuaTrinhCongTacDTO qtct = quaTrinhCongTacBUL.LayBangQuaTrinhCongTacTheoMaNVTuNgay(Convert.ToInt32(this.Tag.ToString()), dt.ToString("MM/dd/yyyy"));
            lbChucVu.Text = qtct.ChucVu;
            txtTenNV.Text = hoSoBUL.LayTenTheoMaNhanVien(Convert.ToInt32(this.Tag.ToString()));
            txtNCT.Text = qtct.NoiCongTac;
            dtDenNgay.Value = DateTime.Parse(qtct.DenNgay);
        }
        private void btnSua_Click(object sender, EventArgs e)
        {
            int maNhanvien = Convert.ToInt32(lbMaNhanVien.Text);

            DateTime tuNgay = DateTime.Parse(cbbTuNgay.SelectedValue.ToString());

            DateTime denNgay = dtDenNgay.Value;
            string den = denNgay.ToString("MM/dd/yyyy");
            string noiCT = txtNCT.Text;
            string chucvu = lbChucVu.Text;

            bool kt = quaTrinhCongTacBUL.SuaQuaTrinhCongTac(maNhanvien, tuNgay.ToString("MM/dd/yyyy"), den, noiCT, chucvu);
            if (kt)
            {
                MessageBox.Show("Sửa thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Sửa thất bại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            this.Close();
        }

        private void btnHuy_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cbbTuNgay_SelectionChangeCommitted(object sender, EventArgs e)
        {
            DateTime dt = DateTime.Parse(cbbTuNgay.SelectedValue.ToString());
            string txt = dt.ToString("MM/dd/yyyy");

            QuaTrinhCongTacDTO qtct = quaTrinhCongTacBUL.LayBangQuaTrinhCongTacTheoMaNVTuNgay(Convert.ToInt32(this.Tag.ToString()), dt.ToString("MM/dd/yyyy"));
            lbChucVu.Text = qtct.ChucVu;
            txtTenNV.Text = hoSoBUL.LayTenTheoMaNhanVien(Convert.ToInt32(this.Tag.ToString()));
            txtNCT.Text = qtct.NoiCongTac;

            dtDenNgay.Value = DateTime.Parse(qtct.DenNgay);

        }
    }
}
