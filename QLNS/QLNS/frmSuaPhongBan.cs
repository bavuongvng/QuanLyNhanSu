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
using System.Data.SqlClient;

namespace QLNS
{
    public partial class frmSuaPhongBan : Form
    {
        private PhongBanBUL phongBanBUL = new PhongBanBUL();

        public frmSuaPhongBan()
        {
            InitializeComponent();
        }

        private void bunifuThinButton21_Click(object sender, EventArgs e)
        {
            DialogResult tl = MessageBox.Show("Bạn Có Chắc Muốn Hủy Thao Tác?", "Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (tl == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void frmSuaPhongBan_Load(object sender, EventArgs e)
        {
            txtmaPB.Text = this.Tag.ToString();
            dtngayLap.Format = DateTimePickerFormat.Custom;
            dtngayLap.CustomFormat = "dd/MM/yyyy";
        }

        private void btnSua_Click_1(object sender, EventArgs e)
        {
            int mapb = Convert.ToInt32(txtmaPB.Text);
            string tenpb = txttenPB.Text.ToString();
            DateTime date = dtngayLap.Value;

            bool kt = phongBanBUL.SuaPhongBan(mapb, tenpb, date.ToString("MM/dd/yyyy"));

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

        private void btnHuy_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
