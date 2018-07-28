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
    public partial class frmXoaHoSo : Form
    {
        private HoSoBUL hoSoBUL = new HoSoBUL();
        private PhongBanBUL phongBanBUL = new PhongBanBUL();
        public frmXoaHoSo()
        {
            InitializeComponent();
        }

        private void frmXoaHoSo_Load(object sender, EventArgs e)
        {
            lblMaNV.Text = this.Tag.ToString();
            HoSoDTO ds = hoSoBUL.LayDSHoSoTheoMa(Convert.ToInt32(this.Tag.ToString()))[0];
            txtHo.Text = ds.HoDem;
            txtTen.Text = ds.TenDem;
            txtNgaySInh.Text = ds.NgaySinh;
            txtGT.Text = ds.GioiTinh;
            txtSoDT.Text = ds.SoDienThoai;
            txtEmail.Text = ds.Email;
            txtNgayTD.Text = ds.NgayTuyenDung;
            PhongBanDTO pb = phongBanBUL.LayPhongBanTheoMaNV(Convert.ToInt32(this.Tag.ToString()));
            txtMaPhongBan.Text = pb.TenPhongBan;
        }
        private void btnXoa_Click(object sender, EventArgs e)
        {
            DialogResult tl = MessageBox.Show("Bạn có chắc chắn muốn xóa?", "Xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (tl == DialogResult.Yes)
            {
                string maNV = lblMaNV.Text;
                hoSoBUL.xoaHoSo(maNV);
                this.Close();
                UCQLHoSo uCQLHo = new UCQLHoSo();
                uCQLHo.HienThi();
            }
            else
            {
                this.Close();
            }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
