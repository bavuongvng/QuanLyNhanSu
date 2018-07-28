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
    public partial class frmXoaQTCT : Form
    {
        private ChucVuBUL chucVuBUL = new ChucVuBUL();
        private HoSoBUL hoSoBUL = new HoSoBUL();
        private NhanVienChucVuBUL nhanVienChucVuBUL = new NhanVienChucVuBUL();
        private QuaTrinhCongTacBUL quaTrinhCongTacBUL = new QuaTrinhCongTacBUL();
        public frmXoaQTCT()
        {
            InitializeComponent();
        }

        private void frmXoaQTCT_Load(object sender, EventArgs e)
        {
            txtMaNV.Text = this.Tag.ToString();
            txtTenNV.Text = hoSoBUL.LayTenTheoMaNhanVien(Convert.ToInt32(this.Tag.ToString()));
            cbbTuNgay.DataSource = quaTrinhCongTacBUL.LayBangQuaTrinhCongTacTheoMaNV(Convert.ToInt32(this.Tag.ToString()));
            cbbTuNgay.DisplayMember = "tungay";
            cbbTuNgay.ValueMember = "tungay";
            cbbTuNgay.SelectedIndex = 0;

            DateTime dt = DateTime.ParseExact(cbbTuNgay.SelectedValue.ToString(), "dd/MM/yyyy", null);
            string st = dt.ToString("dd/MM/yyyy");
            QuaTrinhCongTacDTO qt = quaTrinhCongTacBUL.LayBangQuaTrinhCongTacTheoMaNVTuNgay(Convert.ToInt32(this.Tag.ToString()), dt.ToString("MM/dd/yyyy"));
            txtCV.Text = qt.ChucVu;
            txtNCT.Text = qt.NoiCongTac;
            txtDenNgay.Text = qt.DenNgay;

        }

        private void btnXoa_Click_1(object sender, EventArgs e)
        {
            DialogResult tl = MessageBox.Show("Bạn có chắc chắn muốn xóa?", "Xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (tl == DialogResult.Yes)
            {
                int manv = Convert.ToInt32(txtMaNV.Text);
                DateTime dt1 = DateTime.ParseExact(cbbTuNgay.SelectedValue.ToString(), "dd/MM/yyyy", null);
                string dengay = txtDenNgay.Text;
                string noiCT = txtNCT.Text;
                string chucvu = txtCV.Text;
                quaTrinhCongTacBUL.XoaQuaTrinhcongTac(manv, dt1.ToString("MM/dd/yyyy"), dengay, noiCT, chucvu);
                MessageBox.Show("Xóa thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            else
            {
                this.Close();
            }
        }

        private void cbbTuNgay_SelectionChangeCommitted_1(object sender, EventArgs e)
        {
            DateTime dt = DateTime.ParseExact(cbbTuNgay.SelectedValue.ToString(), "dd/MM/yyyy", null);
            string st = dt.ToString("dd/MM/yyyy");
            QuaTrinhCongTacDTO qt = quaTrinhCongTacBUL.LayBangQuaTrinhCongTacTheoMaNVTuNgay(Convert.ToInt32(this.Tag.ToString()), dt.ToString("MM/dd/yyyy"));
            txtCV.Text = qt.ChucVu;
            txtNCT.Text = qt.NoiCongTac;
            txtDenNgay.Text = qt.DenNgay;

        }

        private void btnHuy_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
