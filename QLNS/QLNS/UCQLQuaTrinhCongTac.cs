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
using System.Data;
using System.Data.SqlClient;

namespace QLNS
{

    public partial class UCQLQuaTrinhCongTac : UserControl
    {
        private QuaTrinhCongTacBUL quaTrinhCongTacBUL = new QuaTrinhCongTacBUL();
        public UCQLQuaTrinhCongTac()
        {
            InitializeComponent();
        }

        private void dgvQuaTrinhCongTac_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }


        private void UCQLQuaTrinhCongTac_Load(object sender, EventArgs e)
        {
            dgvQuaTrinhCongTac.DataSource = quaTrinhCongTacBUL.LayThongTinQuaTrinhCongTac();
            btnDelete.Enabled = false;
            btnEdit.Enabled = false;
        }

        public void HienThi()
        {
            txtMaNV.Focus();
            txtMaNV.text = "";
            dgvQuaTrinhCongTac.DataSource = quaTrinhCongTacBUL.LayThongTinQuaTrinhCongTac();
            dgvQuaTrinhCongTac.Columns[3].DefaultCellStyle.Format = "dd/MM/yyyy";
            dgvQuaTrinhCongTac.Columns[4].DefaultCellStyle.Format = "dd/MM/yyyy";
            dgvQuaTrinhCongTac.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }
        private void txtMaNV_OnTextChange_1(object sender, EventArgs e)
        {
            try
            {
                if (txtMaNV.text != null && txtMaNV.text != "")
                {
                    int ma = Convert.ToInt32(txtMaNV.text);
                    dgvQuaTrinhCongTac.DataSource = quaTrinhCongTacBUL.LayThongTinQuaTrinhCongTacTheoMaNV(ma);
                    if (quaTrinhCongTacBUL.LayThongTinQuaTrinhCongTacTheoMaNV(ma).Rows.Count > 0)
                    {
                        btnEdit.Enabled = true;
                        btnDelete.Enabled = true;
                    }
                    else
                    {
                        btnEdit.Enabled = false;
                        btnDelete.Enabled = false;
                    }
                }
                else
                {
                    HienThi();
                    btnEdit.Enabled = false;
                    btnDelete.Enabled = false;
                }
            }
            catch
            {
                dgvQuaTrinhCongTac.DataSource = quaTrinhCongTacBUL.LayThongTinQuaTrinhCongTacTheoMaNV(-1);
                btnEdit.Enabled = false;
                btnDelete.Enabled = false;
            }
        }

        private void btnAdd_Click_1(object sender, EventArgs e)
        {
            frmThemQTCT frmthemQTCT = new frmThemQTCT();
            frmthemQTCT.ShowDialog();
            HienThi();
        }

        private void btnEdit_Click_1(object sender, EventArgs e)
        {
            string manv = txtMaNV.text;
            frmSuaQTCT suaQTCT = new frmSuaQTCT();
            suaQTCT.Tag = manv;
            suaQTCT.ShowDialog();
            txtMaNV.text = "";
            HienThi();
        }

        private void btnDelete_Click_1(object sender, EventArgs e)
        {
            string manv = txtMaNV.text;
            frmXoaQTCT xoaQTCT = new frmXoaQTCT();
            xoaQTCT.Tag = manv;
            xoaQTCT.ShowDialog();
            txtMaNV.text = "";
            HienThi();
        }
    }
}
