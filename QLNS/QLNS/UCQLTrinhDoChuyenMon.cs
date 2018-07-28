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
    public partial class UCQLTrinhDoChuyenMon : UserControl
    {
        TrinhDoChuyenMonBUL trinhDoChuyenMonBUL = new TrinhDoChuyenMonBUL();
        private HoSoBUL hoSoBUL = new HoSoBUL();
        public UCQLTrinhDoChuyenMon()
        {
            InitializeComponent();
        }

        private void UCQLTrinhDoChuyenMon_Load(object sender, EventArgs e)
        {
            hienThi();
            btnEdit.Enabled = false;
            btnDelete.Enabled = false;
        }
        public void hienThi()
        {
            txtMaNV.Focus();
            txtMaNV.text = "";
            dgvTrinhDoChuyenMon.DataSource = trinhDoChuyenMonBUL.LayThongTinTrinhDoCHuyenMon();
            dgvTrinhDoChuyenMon.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void bunifuCustomLabel20_Click(object sender, EventArgs e)
        {

        }

        private void txtTenNV_Click(object sender, EventArgs e)
        {

        }
        private void txtMaNV_OnTextChange_1(object sender, EventArgs e)
        {
            try
            {
                if (txtMaNV.text != null && txtMaNV.text != "")
                {
                    int ma = Convert.ToInt32(txtMaNV.text);
                    dgvTrinhDoChuyenMon.DataSource = trinhDoChuyenMonBUL.LayThongTinTrinhDoChuyenMonTheoMa(ma);
                    if (trinhDoChuyenMonBUL.LayThongTinTrinhDoChuyenMonTheoMa(ma).Rows.Count > 0)
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
                dgvTrinhDoChuyenMon.DataSource = trinhDoChuyenMonBUL.LayThongTinTrinhDoChuyenMonTheoMa(-1);
                btnEdit.Enabled = false;
                btnDelete.Enabled = false;
            }
        }

        private void btnAdd_Click_1(object sender, EventArgs e)
        {
            frmAddTDCM themTDCM = new frmAddTDCM();
            themTDCM.ShowDialog();
            hienThi();
        }

        private void btnDelete_Click_1(object sender, EventArgs e)
        {
            string maNV = txtMaNV.text;
            frmXoaTDCM xoaTDCM = new frmXoaTDCM();
            xoaTDCM.Tag = maNV;
            xoaTDCM.ShowDialog();
            hienThi();
        }

        private void btnEdit_Click_1(object sender, EventArgs e)
        {
            string maNV = txtMaNV.text;
            frmSuaTDCM suaTDCM = new frmSuaTDCM();
            suaTDCM.Tag = maNV;
            suaTDCM.ShowDialog();
            hienThi();
        }
    }
}
