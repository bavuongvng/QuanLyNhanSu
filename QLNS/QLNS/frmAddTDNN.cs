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
    public partial class frmAddTDNN : Form
    {
        TrinhDoNgoaiNguBUL trinhdoNNBUL = new TrinhDoNgoaiNguBUL();
        HoSoBUL hoSoBUL = new HoSoBUL();
        public frmAddTDNN()
        {
            InitializeComponent();
        }

        private void frmAddTDNN_Load(object sender, EventArgs e)
        {
            cbbManv.DataSource = trinhdoNNBUL.LayThongTinTDNNGopMa();
            cbbManv.DisplayMember = "MaNhanVien";
            cbbManv.ValueMember = "MaNhanVien";
            cboNgoaiNgu.DataSource = trinhdoNNBUL.LayThongTinTDNNgopNN();
            cboNgoaiNgu.DisplayMember = "NgoaiNgu";
            cboNgoaiNgu.ValueMember = "NgoaiNgu";
        }



        private void btnThemTDNN_Click_1(object sender, EventArgs e)
        {
            int maNV = Convert.ToInt32(cbbManv.SelectedValue);
            txtTenNV.Text = hoSoBUL.LayTenTheoMaNhanVien(Convert.ToInt32(cbbManv.SelectedValue.ToString()));
            string ngoaingu = cboNgoaiNgu.SelectedValue.ToString();
            string trinhdo = txtTrinhDo.Text.ToString();
            bool kt = trinhdoNNBUL.themTrinhDoNN(maNV, ngoaingu, trinhdo);
            if (kt)
            {
                MessageBox.Show("Thêm thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Thêm thất bại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            UCQLTDNN ucQLTDNgoaiNgu = new UCQLTDNN();
            ucQLTDNgoaiNgu.hienThi();
            this.Close();
        }

        private void btnHuyTDNN_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cbbManv_SelectionChangeCommitted_1(object sender, EventArgs e)
        {
            txtTenNV.Text = hoSoBUL.LayTenTheoMaNhanVien(Convert.ToInt32(cbbManv.SelectedValue));
        }
    }
}
