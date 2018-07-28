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
    public partial class frmThemPhongBan : Form
    {
        PhongBanBUL phongBanBUL = new PhongBanBUL();
        public frmThemPhongBan()
        {
            InitializeComponent();
        }

        private void bunifuCustomLabel2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void cbbMaChucVu_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void frmThemPhongBan_Load(object sender, EventArgs e)
        {
            dtngayLap.Format = DateTimePickerFormat.Custom;
            dtngayLap.CustomFormat = "dd/MM/yyyy";
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void bunifuCustomLabel5_Click(object sender, EventArgs e)
        {

        }

        private void bunifuThinButton21_Click(object sender, EventArgs e)
        {
            DialogResult tl = MessageBox.Show("Bạn Có Chắc Chắn Muốn Hủy Thao Tác?", "Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (tl == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void bunifuCustomLabel6_Click(object sender, EventArgs e)
        {

        }

        private void bunifuCustomLabel1_Click(object sender, EventArgs e)
        {

        }

        private void txttenPB_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnThem_Click_1(object sender, EventArgs e)
        {
            string tenPhongBan = txttenPB.Text.ToString();
            DateTime ngayLap = dtngayLap.Value;
            string ngay = ngayLap.ToString("MM/dd/yyyy");
            bool kt = phongBanBUL.ThemPhongBan(tenPhongBan, ngay);
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

        private void bunifuThinButton21_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
