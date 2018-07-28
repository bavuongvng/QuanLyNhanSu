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
    public partial class frmXoaTDCM : Form
    {
        HoSoBUL hoSoBUL = new HoSoBUL();
        TrinhDoChuyenMonBUL trinhdoCMBUL = new TrinhDoChuyenMonBUL();
        TrinhDoChuyenMonDTO TrinhDoChuyenMonDTO = new TrinhDoChuyenMonDTO();
        public frmXoaTDCM()
        {
            InitializeComponent();
        }

        private void frmXoaTDCM_Load(object sender, EventArgs e)
        {
            txtMaNV.Text = this.Tag.ToString();
            txtTenNV.Text = hoSoBUL.LayTenTheoMaNhanVien(Convert.ToInt32(this.Tag.ToString()));

            cboNganh.DataSource = trinhdoCMBUL.LayThongTinnganhTheoMa(Convert.ToInt32(txtMaNV.Text));
            cboNganh.DisplayMember = "nganh";
            cboNganh.ValueMember = "nganh";
            TrinhDoChuyenMonDTO ds = trinhdoCMBUL.layDStrinhdoCMtheomavanganh(Convert.ToInt32(this.Tag.ToString()), cboNganh.SelectedValue.ToString())[0];
            txtLoaiHinhDT.Text = ds.LoaiHinhDaoTao;
            txtTrinhDO.Text = ds.TrinhDo;
            txtTruongDT.Text = ds.TruongDaoTao;
        }

        private void btnXoa_Click_1(object sender, EventArgs e)
        {
            DialogResult tl = MessageBox.Show("Bạn có chắc chắn muốn xóa?", "Xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (tl == DialogResult.Yes)
            {
                int maNV = Convert.ToInt32(txtMaNV.Text);
                string nganh = cboNganh.SelectedValue.ToString();
                bool kt = trinhdoCMBUL.xoaTDCM(maNV, nganh);
                if (kt)
                {
                    MessageBox.Show("Xóa thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Xóa thất bại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                UCQLTrinhDoChuyenMon uCQLTrinhDoChuyen = new UCQLTrinhDoChuyenMon();
                uCQLTrinhDoChuyen.hienThi();
                this.Close();
            }
            else
            {
                this.Close();
            }
        }

        private void btnHuyTDCM_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cboNganh_SelectionChangeCommitted_1(object sender, EventArgs e)
        {
            TrinhDoChuyenMonDTO ds = trinhdoCMBUL.layDStrinhdoCMtheomavanganh(Convert.ToInt32(this.Tag.ToString()), cboNganh.SelectedValue.ToString())[0];
            txtLoaiHinhDT.Text = ds.LoaiHinhDaoTao;
            txtTrinhDO.Text = ds.TrinhDo;
            txtTruongDT.Text = ds.TruongDaoTao;
        }
    }
}
