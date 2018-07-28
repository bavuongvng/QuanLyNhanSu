using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BUL;
using System.Windows.Forms;

namespace QLNS
{
    public partial class UCQLPhongBan : UserControl
    {
        private PhongBanBUL phongBanBUL = new PhongBanBUL();
        public UCQLPhongBan()
        {
            InitializeComponent();
            dvgPhongBan.DataSource = phongBanBUL.LayDSPhongBan();
        }

        private void UCQLPhongBan_Load(object sender, EventArgs e)
        {
            hienthi();
            btnDelete.Enabled = false;
            btnEdit.Enabled = false;
        }
        public void hienthi()
        {
            txtMaPB.Focus();
            txtMaPB.text = "";
            dvgPhongBan.DataSource = phongBanBUL.LayDSPhongBan();
            dvgPhongBan.Columns[2].DefaultCellStyle.Format = "dd/MM/yyyy";
            dvgPhongBan.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void txtMaPB_OnTextChange_1(object sender, EventArgs e)
        {
            try
            {
                if (txtMaPB.text != null && txtMaPB.text != "")
                {
                    int ma = Convert.ToInt32(txtMaPB.text);
                    dvgPhongBan.DataSource = phongBanBUL.LayDSPhongBanTheoMaPB(ma);
                    if (phongBanBUL.LayDSPhongBanTheoMaPB(ma).Count > 0)
                    {
                        btnEdit.Enabled = true;
                        btnDelete.Enabled = true;
                    }
                    else
                    {
                        btnDelete.Enabled = false;
                        btnEdit.Enabled = false;
                    }
                }
                else
                {
                    hienthi();
                    btnEdit.Enabled = false;
                    btnDelete.Enabled = false;
                }
            }
            catch
            {
                dvgPhongBan.DataSource = phongBanBUL.LayDSPhongBanTheoMaPB(-1);
                btnDelete.Enabled = false;
                btnEdit.Enabled = false;
            }
        }

        private void btnAdd_Click_1(object sender, EventArgs e)
        {
            frmThemPhongBan addPB = new frmThemPhongBan();
            addPB.ShowDialog();
            hienthi();
        }

        private void btnEdit_Click_1(object sender, EventArgs e)
        {
            string mapb = txtMaPB.text;
            frmSuaPhongBan suaPB = new frmSuaPhongBan();
            suaPB.Tag = mapb;
            suaPB.ShowDialog();
            txtMaPB.text = "";
            hienthi();
        }

        private void btnDelete_Click_1(object sender, EventArgs e)
        {
            int mapb = Convert.ToInt32(txtMaPB.text);
            DialogResult tl = MessageBox.Show("Bạn Chắc Chắn Muốn Xóa Phòng Ban?", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (tl == DialogResult.Yes)
            {
                phongBanBUL.XoaPhongBan(mapb);
                hienthi();
            }
        }
    }
}
