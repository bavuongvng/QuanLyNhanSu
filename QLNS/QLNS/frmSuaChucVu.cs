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
    public partial class frmSuaChucVu : Form
    {
        private ChucVuBUL chucVuBul = new ChucVuBUL();
        public frmSuaChucVu()
        {
            InitializeComponent();
        }
        private void frmSuaChucVu_Load(object sender, EventArgs e)
        {
            txtMaChucVu.Text = this.Tag.ToString();
        }

        private void btnSua_Click_1(object sender, EventArgs e)
        {
            int maCV = Convert.ToInt32(txtMaChucVu.Text);
            string tenCV = txtTenChucVu.Text.ToString();
            float heSo = float.Parse(txtHeSoPhuCap.Text.ToString());

            bool kt = chucVuBul.SuaChucVu(maCV, tenCV, heSo);

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

        private void bunifuThinButton21_Click_1(object sender, EventArgs e)
        {
            DialogResult tl = MessageBox.Show("Bạn Có Chắc Chắn Muốn Hủy Thao Tác?", "Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (tl == DialogResult.Yes)
            {
                this.Close();
            }
        }
    }
}
