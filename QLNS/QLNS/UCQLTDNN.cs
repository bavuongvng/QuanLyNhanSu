using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BUL;

namespace QLNS
{
    public partial class UCQLTDNN : UserControl
    {
        TrinhDoNgoaiNguBUL trinhdoNNBUL = new TrinhDoNgoaiNguBUL();
        HoSoBUL hoSoBUL = new HoSoBUL();
        public UCQLTDNN()
        {
            InitializeComponent();
        }

        private void UCQLTDNN_Load(object sender, EventArgs e)
        {
            hienThi();
            btnEdit.Enabled = false;
            btnDelete.Enabled = false;
        }
        public void hienThi()
        {
            txtMaNV.Focus();
            txtMaNV.text = "";
            dgvTrinhDoNN.DataSource = trinhdoNNBUL.LayThongTinTDNN();
            dgvTrinhDoNN.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }
        private void txtMaNV_OnTextChange_1(object sender, EventArgs e)
        {
            try
            {
                if (txtMaNV.text != null && txtMaNV.text != "")
                {
                    int ma = Convert.ToInt32(txtMaNV.text);
                    dgvTrinhDoNN.DataSource = trinhdoNNBUL.LayThongTinTDNNtheoMa(ma);
                    if (trinhdoNNBUL.LayThongTinTDNNtheoMa(ma).Rows.Count > 0)
                    {
                        btnEdit.Enabled = true;
                        btnDelete.Enabled = true;
                        txtTenNV.Text = hoSoBUL.LayTenTheoMaNhanVien(Convert.ToInt32(ma));
                    }
                    else
                    {
                        btnEdit.Enabled = false;
                        btnDelete.Enabled = false;
                    }
                }
                else
                {
                    hienThi();
                    btnEdit.Enabled = false;
                    btnDelete.Enabled = false;
                }
            }
            catch
            {
                dgvTrinhDoNN.DataSource = trinhdoNNBUL.LayThongTinTDNNtheoMa(-1);
                btnEdit.Enabled = false;
                btnDelete.Enabled = false;
            }
        }

        private void btnAdd_Click_1(object sender, EventArgs e)
        {
            frmAddTDNN themTDNN = new frmAddTDNN();
            themTDNN.ShowDialog();
            hienThi();
        }

        private void btnEdit_Click_1(object sender, EventArgs e)
        {
            string maNV = txtMaNV.text;
            frmSuaTDNN suaTDNN = new frmSuaTDNN();
            suaTDNN.Tag = maNV;
            suaTDNN.ShowDialog();
            hienThi();
        }

        private void btnDelete_Click_1(object sender, EventArgs e)
        {
            string maNV = txtMaNV.text;
            frmXoaTDNN xoaTDNN = new frmXoaTDNN();
            xoaTDNN.Tag = maNV;
            xoaTDNN.ShowDialog();
            hienThi();
        }
    }
}
