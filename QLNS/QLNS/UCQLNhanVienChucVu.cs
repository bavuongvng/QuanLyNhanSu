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
    public partial class UCQLNhanVienChucVu : UserControl
    {
        private NhanVienChucVuBUL nhanVienChucVuBUL = new NhanVienChucVuBUL();
        public UCQLNhanVienChucVu()
        {
            InitializeComponent();
            dvgNhanVienChucVu.DataSource = nhanVienChucVuBUL.LayThongTinNhanVienChucVu();
        }

        private void UCQLNhanVienChucVu_Load(object sender, EventArgs e)
        {
            HienThi();
            btnDelete.Enabled = false;
            btnEdit.Enabled = false;
        }

        public void HienThi()
        {
            txtMaNV.Focus();
            txtMaNV.text = "";
            dvgNhanVienChucVu.DataSource = nhanVienChucVuBUL.LayThongTinNhanVienChucVu();
            for (int i = 0; i < dvgNhanVienChucVu.Rows.Count - 1; i++)
            {
                dvgNhanVienChucVu.Rows[i].Cells[0].Value = (i + 1);
            }
            dvgNhanVienChucVu.Columns[5].DefaultCellStyle.Format = "dd/MM/yyyy";
            dvgNhanVienChucVu.Columns[6].DefaultCellStyle.Format = "dd/MM/yyyy";
            dvgNhanVienChucVu.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void dvgNhanVienChucVu_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            frmThemNVCV addNVCV = new frmThemNVCV();
            addNVCV.ShowDialog();
            HienThi();
        }

        private void txtMaNV_OnTextChange(object sender, EventArgs e)
        {
            try
            {
                if (txtMaNV.text != null && txtMaNV.text != "")
                {
                    int ma = Convert.ToInt32(txtMaNV.text);
                    dvgNhanVienChucVu.DataSource = nhanVienChucVuBUL.LayDSNhanVienChucVuTheoMaNV(ma);
                    for (int i = 0; i < dvgNhanVienChucVu.Rows.Count - 1; i++)
                    {
                        dvgNhanVienChucVu.Rows[i].Cells[0].Value = (i + 1);
                    }
                    if (nhanVienChucVuBUL.LayDSNhanVienChucVuTheoMaNV(ma).Rows.Count > 0)
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
                dvgNhanVienChucVu.DataSource = nhanVienChucVuBUL.LayDSNhanVienChucVuTheoMaNV(-1);
                btnEdit.Enabled = false;
                btnDelete.Enabled = false;
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            string manv = txtMaNV.text;
            frmSuaNVCV suaNhanVienChucVu = new frmSuaNVCV();
            suaNhanVienChucVu.Tag = manv;
            suaNhanVienChucVu.ShowDialog();
            txtMaNV.text = "";
            HienThi();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            string manv = txtMaNV.text;
            frmXoaNVCV xoaNVCV = new frmXoaNVCV();
            xoaNVCV.Tag = manv;
            xoaNVCV.ShowDialog();

            txtMaNV.text = "";
            HienThi();
        }
    }
}
