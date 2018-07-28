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
    public partial class frmThemNVCV : Form
    {
        NhanVienChucVuBUL nhanVienChucVuBUL = new NhanVienChucVuBUL();
        private HoSoBUL hoSoBUL = new HoSoBUL();
        private ChucVuBUL chucVuBUL = new ChucVuBUL();
        public frmThemNVCV()
        {
            InitializeComponent();
        }

        private void frmAddNVCV_Load(object sender, EventArgs e)
        {
            cbbMaNhanVien.DataSource = hoSoBUL.LayDSHoSo();
            cbbMaNhanVien.DisplayMember = "manhanvien";
            cbbMaNhanVien.ValueMember = "manhanvien";
            cbbMaNhanVien.SelectedIndex = 0;
            cbbMaChucVu.DataSource = chucVuBUL.LayDSChucVu();
            cbbMaChucVu.DisplayMember = "tenchucvu";
            cbbMaChucVu.ValueMember = "machucvu";
            dtTuNgay.Format = DateTimePickerFormat.Custom;
            dtTuNgay.CustomFormat = "dd/MM/yyyy";
            dtDenNgay.Format = DateTimePickerFormat.Custom;
            dtDenNgay.CustomFormat = "dd/MM/yyyy";
            txtTenNhanVien.Text = hoSoBUL.LayTenTheoMaNhanVien(Convert.ToInt32(cbbMaNhanVien.SelectedValue.ToString()));
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            int maNhanvien = Convert.ToInt32(cbbMaNhanVien.SelectedValue);
            int machucVu = Convert.ToInt32(cbbMaChucVu.SelectedValue);
            DateTime tuNgay = dtTuNgay.Value;
            string tu = tuNgay.ToString("MM/dd/yyyy");
            DateTime denNgay = dtDenNgay.Value;
            string den = denNgay.ToString("MM/dd/yyyy");

            if (tuNgay > denNgay)
            {
                MessageBox.Show("Ngày không hợp lệ");
            }
            else
            {
                bool kt = nhanVienChucVuBUL.ThemNhanVienchucVu(maNhanvien, machucVu, tu, den);
                if (kt)
                {
                    MessageBox.Show("Thêm thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Thêm thất bại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                this.Close();
            }
        }

        private void bunifuThinButton21_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cbbMaNhanVien_SelectionChangeCommitted(object sender, EventArgs e)
        {
            txtTenNhanVien.Text = hoSoBUL.LayTenTheoMaNhanVien(Convert.ToInt32(cbbMaNhanVien.SelectedValue.ToString()));
        }
    }
}
