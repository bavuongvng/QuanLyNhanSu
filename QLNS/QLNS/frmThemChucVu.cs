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
    public partial class frmThemChucVu : Form
    {
        ChucVuBUL chucVuBUL = new ChucVuBUL();
        public frmThemChucVu()
        {
            InitializeComponent();
        }

        private void frmThemChucVu_Load(object sender, EventArgs e)
        {

        }

        private void btnThem_Click_2(object sender, EventArgs e)
        {
            string tenChucVu = txtTenChucVu.Text.ToString();
            float heSo = float.Parse(txtHeSoPhuCap.Text);

            bool kt = chucVuBUL.ThemChucVu(tenChucVu, heSo);

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

        private void btnHuy_Click_1(object sender, EventArgs e)
        {
            DialogResult tl = MessageBox.Show("Bạn Có Chắc Chắn Muốn Hủy Thao Tác?", "Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (tl == DialogResult.Yes)
            {
                this.Close();
            }
        }
    }
}
