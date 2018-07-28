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
    public partial class frmXoaNVCV : Form
    {
        public frmXoaNVCV()
        {
            InitializeComponent();
        }
        private ChucVuBUL chucVuBUL = new ChucVuBUL();
        private HoSoBUL hoSoBUL = new HoSoBUL();
        private NhanVienChucVuBUL nhanVienChucVuBUL = new NhanVienChucVuBUL();
        private void frmXoaNVCV_Load(object sender, EventArgs e)
        {
            txtMaNV.Text = this.Tag.ToString();
            cbbMaChucVu.DataSource = chucVuBUL.LayTenChucVuTheoMaNhanVien(Convert.ToInt32(this.Tag.ToString()));
            txtTenNhanVien.Text = hoSoBUL.LayTenTheoMaNhanVien(Convert.ToInt32(this.Tag.ToString()));
            cbbMaChucVu.DisplayMember = "tenchucvu";
            cbbMaChucVu.ValueMember = "machucvu";
            cbbMaChucVu.SelectedIndex = 0;

            cbbTuNgay.DataSource = nhanVienChucVuBUL.LayNhanVienChucVuTheoMaNVMaCV(Convert.ToInt32(this.Tag.ToString()),
                Convert.ToInt32(cbbMaChucVu.SelectedValue.ToString()));
            cbbTuNgay.DisplayMember = "tungay";
            cbbTuNgay.ValueMember = "tungay";
            cbbTuNgay.SelectedIndex = 0;

            txtDenNgay.Text = nhanVienChucVuBUL.LayNhanVienChucVuTheoMaNVMaCVTuNgay(Convert.ToInt32(this.Tag.ToString()),
                Convert.ToInt32(cbbMaChucVu.SelectedValue.ToString()), cbbTuNgay.SelectedValue.ToString()).DenNgay;

        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cbbMaChucVu_SelectionChangeCommitted(object sender, EventArgs e)
        {
            cbbTuNgay.DataSource = nhanVienChucVuBUL.LayNhanVienChucVuTheoMaNVMaCV(Convert.ToInt32(this.Tag.ToString()),
                Convert.ToInt32(cbbMaChucVu.SelectedValue.ToString()));
            cbbTuNgay.DisplayMember = "tungay";
            cbbTuNgay.ValueMember = "tungay";
            cbbTuNgay.SelectedIndex = 0;

            txtDenNgay.Text = nhanVienChucVuBUL.LayNhanVienChucVuTheoMaNVMaCVTuNgay(Convert.ToInt32(this.Tag.ToString()),
                Convert.ToInt32(cbbMaChucVu.SelectedValue.ToString()), cbbTuNgay.SelectedValue.ToString()).DenNgay;
        }

        private void cbbTuNgay_SelectionChangeCommitted(object sender, EventArgs e)
        {
            txtDenNgay.Text = nhanVienChucVuBUL.LayNhanVienChucVuTheoMaNVMaCVTuNgay(Convert.ToInt32(this.Tag.ToString()),
                Convert.ToInt32(cbbMaChucVu.SelectedValue.ToString()), cbbTuNgay.SelectedValue.ToString()).DenNgay;
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            DialogResult tl = MessageBox.Show("Bạn có chắc chắn muốn xóa?", "Xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (tl == DialogResult.Yes)
            {
                int manv = Convert.ToInt32(txtMaNV.Text);
                int macv = Convert.ToInt32(cbbMaChucVu.SelectedValue.ToString());
                DateTime dt1 = DateTime.Parse(cbbTuNgay.SelectedValue.ToString());
                bool kt = nhanVienChucVuBUL.XoaNhanVienChucVu(manv, macv, dt1.ToString("MM/dd/yyyy"));

                if (kt)
                {
                    MessageBox.Show("Xóa thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Xóa thất bại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                this.Close();
            }
            else
            {
                this.Close();
            }
        }
    }
}
