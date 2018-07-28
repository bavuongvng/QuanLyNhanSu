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
    public partial class UCQLChucVu : UserControl
    {
        private ChucVuBUL chucVuBUL = new ChucVuBUL();
        public UCQLChucVu()
        {
            InitializeComponent();
        }

        private void UCQLChucVu_Load(object sender, EventArgs e)
        {
            hienthi();
            btnSuaChucVu.Enabled = false;
            btnXoaChucVu.Enabled = false;
        }
        public void hienthi()
        {
            txtMaCV.Focus();
            txtMaCV.text = "";
            dvgChucVu.DataSource = chucVuBUL.LayDSChucVu();

            dvgChucVu.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void txtMaCV_OnTextChange_1(object sender, EventArgs e)
        {
            try
            {
                if (txtMaCV.text != null && txtMaCV.text != "")
                {
                    int ma = Convert.ToInt32(txtMaCV.text);
                    dvgChucVu.DataSource = chucVuBUL.LayDSChucVuTheoMaCV(ma);
                    if (chucVuBUL.LayDSChucVuTheoMaCV(ma).Count > 0)
                    {
                        btnSuaChucVu.Enabled = true;
                        btnXoaChucVu.Enabled = true;
                    }
                    else
                    {
                        btnSuaChucVu.Enabled = false;
                        btnXoaChucVu.Enabled = false;
                    }
                }
                else
                {
                    hienthi();
                    btnSuaChucVu.Enabled = false;
                    btnXoaChucVu.Enabled = false;
                }

            }
            catch
            {
                dvgChucVu.DataSource = chucVuBUL.LayDSChucVuTheoMaCV(-1);
                btnSuaChucVu.Enabled = false;
                btnXoaChucVu.Enabled = false;
            }
        }

        private void btnThemCV_Click_1(object sender, EventArgs e)
        {
            frmThemChucVu addCV = new frmThemChucVu();
            addCV.ShowDialog();
            hienthi();
        }

        private void btnSuaChucVu_Click_1(object sender, EventArgs e)
        {
            frmSuaChucVu suaCV = new frmSuaChucVu();
            string macv = txtMaCV.text;
            suaCV.Tag = macv;
            suaCV.ShowDialog();
            hienthi();
        }

        private void btnXoaChucVu_Click_1(object sender, EventArgs e)
        {
            int macv = Convert.ToInt32(txtMaCV.text.ToString());
            DialogResult tl = MessageBox.Show("Bạn Chắc Chắn Muốn Xóa Chức Vụ Này?", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (tl == DialogResult.Yes)
            {
                chucVuBUL.XoaChucVu(macv);
                hienthi();
            }
        }
    }

}
