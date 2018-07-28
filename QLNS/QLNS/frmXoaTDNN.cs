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
    public partial class frmXoaTDNN : Form
    {
        TrinhDoNgoaiNguBUL trinhdoNNBUL = new TrinhDoNgoaiNguBUL();
        HoSoBUL hoSoBUL = new HoSoBUL();
        public frmXoaTDNN()
        {
            InitializeComponent();
        }

        private void frmXoaTDNN_Load(object sender, EventArgs e)
        {
            txtMaNV.Text = this.Tag.ToString();
            txtTenNV2.Text = hoSoBUL.LayTenTheoMaNhanVien(Convert.ToInt32(this.Tag.ToString()));
            cboNgoaiNgu.DataSource = trinhdoNNBUL.layNgoaiNguTheoMa(Convert.ToInt32(this.Tag.ToString()));
            cboNgoaiNgu.DisplayMember = "NgoaiNgu";
            cboNgoaiNgu.ValueMember = "NgoaiNgu";
            TrinhDoNgoaiNguDTO ds = trinhdoNNBUL.layDStrinhdoCMtheomavanganh(Convert.ToInt32(this.Tag.ToString()), cboNgoaiNgu.SelectedValue.ToString())[0];
            txtTrinhDO.Text = ds.TrinhDo;
        }

        private void cboNgoaiNgu_SelectionChangeCommitted_1(object sender, EventArgs e)
        {
            TrinhDoNgoaiNguDTO ds = trinhdoNNBUL.layDStrinhdoCMtheomavanganh(Convert.ToInt32(this.Tag.ToString()), cboNgoaiNgu.SelectedValue.ToString())[0];
            txtTrinhDO.Text = ds.TrinhDo;
        }

        private void btnXoa_Click_1(object sender, EventArgs e)
        {
            DialogResult tl = MessageBox.Show("Bạn có chắc chắn muốn xóa?", "Xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (tl == DialogResult.Yes)
            {
                int maNV = Convert.ToInt32(txtMaNV.Text);
                txtTenNV2.Text = hoSoBUL.LayTenTheoMaNhanVien(maNV);
                string ngoaingu = cboNgoaiNgu.SelectedValue.ToString();
                string trinhdo = txtTrinhDO.Text.ToString();
                bool kt = trinhdoNNBUL.xoaTrinhDoNN(maNV, ngoaingu);
                if (kt)
                {
                    MessageBox.Show("Xóa thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Xóa thất bại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                UCQLTDNN ucQLTDNgoaiNgu = new UCQLTDNN();
                ucQLTDNgoaiNgu.hienThi();
                this.Close();
            }
            else
            {
                this.Close();
            }
        }

        private void btnHuyTDNN_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
