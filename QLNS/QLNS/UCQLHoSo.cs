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
    public partial class UCQLHoSo : UserControl
    {
        HoSoBUL hosoBUL = new HoSoBUL();
        public UCQLHoSo()
        {
            InitializeComponent();
        }

        private void UCQLHoSo_Load(object sender, EventArgs e)
        {
            HienThi();
            btnEdit.Enabled = false;
            btnDelete.Enabled = false;
        }
        public void HienThi()
        {
            txtMaNV.Focus();
            txtMaNV.text = "";
            dvgHoSo.DataSource = hosoBUL.LayThongTinHoSo();
            //dvgHoSo.Columns[7].DefaultCellStyle.Format = "dd/mm/yyyy";
            dvgHoSo.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void txtMaNV_OnTextChange_1(object sender, EventArgs e)
        {
            try
            {
                if (txtMaNV.text != null && txtMaNV.text != "")
                {
                    int ma = Convert.ToInt32(txtMaNV.text);
                    dvgHoSo.DataSource = hosoBUL.LayDSHoSoTheoMaNV(ma);
                    if (hosoBUL.LayDSHoSoTheoMaNV(ma).Rows.Count > 0)
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
                dvgHoSo.DataSource = hosoBUL.LayDSHoSoTheoMaNV(-1);
                btnEdit.Enabled = false;
                btnDelete.Enabled = false;
            }
        }

        private void btnAdd_Click_1(object sender, EventArgs e)
        {
            frmAddHoSo addhs = new frmAddHoSo();
            addhs.ShowDialog();
            HienThi();
        }

        private void btnEdit_Click_1(object sender, EventArgs e)
        {
            string maNV = txtMaNV.text;
            frmSuaHoSo suaHoSo = new frmSuaHoSo();
            suaHoSo.Tag = maNV;
            suaHoSo.ShowDialog();
            HienThi();
        }

        private void btnDelete_Click_1(object sender, EventArgs e)
        {
            string maNV = txtMaNV.text;
            frmXoaHoSo xoaHoSo = new frmXoaHoSo();
            xoaHoSo.Tag = maNV;
            xoaHoSo.ShowDialog();
            HienThi();
        }
    }
}
