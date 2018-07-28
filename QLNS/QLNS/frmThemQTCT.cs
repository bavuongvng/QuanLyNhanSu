using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DTO;
using BUL;


namespace QLNS
{
    public partial class frmThemQTCT : Form
    {
        QuaTrinhCongTacBUL quaTrinhCongTacBUL = new QuaTrinhCongTacBUL();
        private HoSoBUL hoSoBUL = new HoSoBUL();
        private ChucVuBUL chucVuBUL = new ChucVuBUL();
        public frmThemQTCT()
        {
            InitializeComponent();
        }


        private void txtTenNV_TextChanged(object sender, EventArgs e)
        {
            txtTenNV.Text = hoSoBUL.LayTenTheoMaNhanVien(Convert.ToInt32(cbbMa.SelectedValue.ToString()));
        }

        private void frmThemQTCT_Load(object sender, EventArgs e)
        {
            cbbMa.DataSource = hoSoBUL.LayDSHoSo();
            cbbMa.DisplayMember = "manhanvien";
            cbbMa.ValueMember = "manhanvien";
            cbbMa.SelectedIndex = 0;
            //txtTenNV.Text = hoSoBUL.LayTenTheoMaNhanVien(Convert.ToInt32(cbbMa.SelectedValue.ToString()));
            dtTuNgay.Format = DateTimePickerFormat.Custom;
            dtTuNgay.CustomFormat = "dd/MM/yyyy";
            dtDenNgay.Format = DateTimePickerFormat.Custom;
            dtDenNgay.CustomFormat = "dd/MM/yyyy";
            cbbChucVu.DataSource = chucVuBUL.LayDSChucVu();
            cbbChucVu.DisplayMember = "tenchucvu";
            cbbChucVu.ValueMember = "tenchucvu";
            txtTenNV.Text = hoSoBUL.LayTenTheoMaNhanVien(Convert.ToInt32(cbbMa.SelectedValue.ToString()));


        }

        private void cbbMa_SelectedIndexChanged(object sender, EventArgs e)
        {
            //txtTenNV.Text = hoSoBUL.LayTenTheoMaNhanVien(Convert.ToInt32(cbbMa.SelectedValue.ToString()));
        }

        private void txtNCT_TextChanged(object sender, EventArgs e)
        {

        }

        private void cbbMa_SelectionChangeCommitted(object sender, EventArgs e)
        {
            txtTenNV.Text = hoSoBUL.LayTenTheoMaNhanVien(Convert.ToInt32(cbbMa.SelectedValue.ToString()));
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dtTuNgay_ValueChanged(object sender, EventArgs e)
        {

        }

        private void btnThem_Click_1(object sender, EventArgs e)
        {
            int maNhanvien = Convert.ToInt32(cbbMa.SelectedValue);
            DateTime tuNgay = dtTuNgay.Value;
            string tu = tuNgay.ToString("MM/dd/yyyy");
            DateTime denNgay = dtDenNgay.Value;
            string den = denNgay.ToString("MM/dd/yyyy");
            string noiCT = txtNCT.Text;
            string chucvu = cbbChucVu.SelectedValue.ToString();

            bool kt = quaTrinhCongTacBUL.ThemQuaTrinhCongTac(maNhanvien, tu, den, noiCT, chucvu);
            if (kt)
            {
                MessageBox.Show("Thêm thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Thêm thất bại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            this.Close();
        }

        private void cbbMa_SelectionChangeCommitted_1(object sender, EventArgs e)
        {
            txtTenNV.Text = hoSoBUL.LayTenTheoMaNhanVien(Convert.ToInt32(cbbMa.SelectedValue.ToString()));
        }
    }
}
