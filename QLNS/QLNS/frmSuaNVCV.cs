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
    public partial class frmSuaNVCV : Form
    {
        private NhanVienChucVuBUL nhanVienChucVuBUL = new NhanVienChucVuBUL();
        private ChucVuBUL chucVuBUL = new ChucVuBUL();
        private HoSoBUL hoSoBUL = new HoSoBUL();
        public frmSuaNVCV()
        {
            InitializeComponent();
        }

        private void frmSuaNhanVienChucVu_Load(object sender, EventArgs e)
        {
            txtMaNV.Text = this.Tag.ToString();
            cbbMaChucVu.DataSource = chucVuBUL.LayTenChucVuTheoMaNhanVien(Convert.ToInt32(this.Tag.ToString()));
            cbbMaChucVu.DisplayMember = "tenchucvu";
            cbbMaChucVu.ValueMember = "machucvu";
            cbbMaChucVu.SelectedIndex = 0;

            cbbTuNgay.DataSource = nhanVienChucVuBUL.LayNhanVienChucVuTheoMaNVMaCV(Convert.ToInt32(this.Tag.ToString()), Convert.ToInt32(cbbMaChucVu.SelectedValue));
            cbbTuNgay.DisplayMember = "tungay";
            cbbTuNgay.ValueMember = "tungay";
            cbbTuNgay.SelectedIndex = 0;

            string denNgay = nhanVienChucVuBUL.LayNhanVienChucVuTheoMaNVMaCVTuNgay(Convert.ToInt32(this.Tag.ToString()),
                Convert.ToInt32(cbbMaChucVu.SelectedValue.ToString()), cbbTuNgay.SelectedValue.ToString()).DenNgay;
            DateTime dt = DateTime.ParseExact(denNgay, "dd/MM/yyyy", null);
            dtDenNgay.Value = dt;

            txtTenNhanVien.Text = hoSoBUL.LayTenTheoMaNhanVien(Convert.ToInt32(this.Tag.ToString()));
        }

        private void bunifuThinButton21_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            int manv = Convert.ToInt32(txtMaNV.Text);
            int macv = Convert.ToInt32(cbbMaChucVu.SelectedValue);
            DateTime dt1 = DateTime.Parse(cbbTuNgay.SelectedValue.ToString());
            DateTime dt2 = dtDenNgay.Value;

            if (dt1 > dt2)
            {
                MessageBox.Show("Ngày không hợp lệ");
            }
            else
            {
                bool kt = nhanVienChucVuBUL.SuaNhanVienChucVu(manv, macv, dt1.ToString("MM/dd/yyyy"), dt2.ToString("MM/dd/yyyy"));
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


        }

        private void cbbMaChucVu_SelectionChangeCommitted(object sender, EventArgs e)
        {
            cbbTuNgay.DataSource = nhanVienChucVuBUL.LayNhanVienChucVuTheoMaNVMaCV(Convert.ToInt32(this.Tag.ToString()), Convert.ToInt32(cbbMaChucVu.SelectedValue));
            cbbTuNgay.DisplayMember = "tungay";
            cbbTuNgay.ValueMember = "tungay";

            string denNgay = nhanVienChucVuBUL.LayNhanVienChucVuTheoMaNVMaCVTuNgay(Convert.ToInt32(this.Tag.ToString()),
                Convert.ToInt32(cbbMaChucVu.SelectedValue.ToString()), cbbTuNgay.SelectedValue.ToString()).DenNgay;
            DateTime dt = DateTime.ParseExact(denNgay, "dd/MM/yyyy", null);
            dtDenNgay.Value = dt;
        }

        private void cbbTuNgay_SelectionChangeCommitted(object sender, EventArgs e)
        {
            string denNgay = nhanVienChucVuBUL.LayNhanVienChucVuTheoMaNVMaCVTuNgay(Convert.ToInt32(this.Tag.ToString()),
                Convert.ToInt32(cbbMaChucVu.SelectedValue.ToString()), cbbTuNgay.SelectedValue.ToString()).DenNgay;
            DateTime dt = DateTime.ParseExact(denNgay, "dd/MM/yyyy", null);
            dtDenNgay.Value = dt;
        }
    }
}
