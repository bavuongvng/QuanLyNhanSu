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
    public partial class frmSuaTDNN : Form
    {
        TrinhDoNgoaiNguBUL trinhdoNNBUL = new TrinhDoNgoaiNguBUL();
        HoSoBUL hoSoBUL = new HoSoBUL();
        public frmSuaTDNN()
        {
            InitializeComponent();
        }

        private void frmSuaTDNN_Load(object sender, EventArgs e)
        {
            txtMaNV.Text = this.Tag.ToString();
            txtTenNV2.Text = hoSoBUL.LayTenTheoMaNhanVien(Convert.ToInt32(this.Tag.ToString()));
            cboNgoaiNgu.DataSource = trinhdoNNBUL.layNgoaiNguTheoMa(Convert.ToInt32(this.Tag.ToString()));
            cboNgoaiNgu.DisplayMember = "NgoaiNgu";
            cboNgoaiNgu.ValueMember = "NgoaiNgu";
            //List<TrinhDoNgoaiNguDTO> nn = trinhdoNNBUL.layDStrinhdoCMtheomavanganh(Convert.ToInt32(this.Tag.ToString()), cboNgoaiNgu.SelectedValue.ToString());
            TrinhDoNgoaiNguDTO ds = trinhdoNNBUL.layDStrinhdoCMtheomavanganh(Convert.ToInt32(this.Tag.ToString()), cboNgoaiNgu.SelectedValue.ToString())[0];
            txtTrinhDo.Text = ds.TrinhDo;
        }
        private void cboNgoaiNgu_SelectionChangeCommitted_1(object sender, EventArgs e)
        {
            TrinhDoNgoaiNguDTO ds = trinhdoNNBUL.layDStrinhdoCMtheomavanganh(Convert.ToInt32(this.Tag.ToString()), cboNgoaiNgu.SelectedValue.ToString())[0];
            txtTrinhDo.Text = ds.TrinhDo;
        }

        private void btnHuyTDNN_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSuaTDNN_Click_1(object sender, EventArgs e)
        {
            int maNV = Convert.ToInt32(txtMaNV.Text);
            txtTenNV2.Text = hoSoBUL.LayTenTheoMaNhanVien(maNV);
            string ngoaingu = cboNgoaiNgu.SelectedValue.ToString();
            string trinhdo = txtTrinhDo.Text.ToString();
            bool kt = trinhdoNNBUL.suaTrinhDoNN(maNV, ngoaingu, trinhdo);
            if (kt)
            {
                MessageBox.Show("Sửa thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Sửa thất bại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            UCQLTDNN ucQLTDNgoaiNgu = new UCQLTDNN();
            ucQLTDNgoaiNgu.hienThi();
            this.Close();
        }
    }
}
