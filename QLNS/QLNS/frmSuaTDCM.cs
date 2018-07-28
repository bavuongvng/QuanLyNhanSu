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
    public partial class frmSuaTDCM : Form
    {
        HoSoBUL hoSoBUL = new HoSoBUL();
        TrinhDoChuyenMonBUL trinhdoCMBUL = new TrinhDoChuyenMonBUL();
        TrinhDoChuyenMonDTO TrinhDoChuyenMonDTO = new TrinhDoChuyenMonDTO();
        public frmSuaTDCM()
        {
            InitializeComponent();
        }

        private void frmSuaTDCM_Load(object sender, EventArgs e)
        {
            txtMaNV.Text = this.Tag.ToString();
            txtTenNV.Text = hoSoBUL.LayTenTheoMaNhanVien(Convert.ToInt32(this.Tag.ToString()));
            cboLoaiHinhDT.DataSource = trinhdoCMBUL.LayThongTinTrinhDoCHuyenMongopLHDT();
            cboLoaiHinhDT.DisplayMember = "LoaiHinhDaoTao";
            cboLoaiHinhDT.ValueMember = "LoaiHinhDaoTao";
            cboTrinhDo.DataSource = trinhdoCMBUL.LayThongTinTrinhDoCHuyenMongopTD();
            cboTrinhDo.DisplayMember = "TrinhDo";
            cboTrinhDo.ValueMember = "TrinhDo";
            cboNganh.DataSource = trinhdoCMBUL.LayThongTinnganhTheoMa(Convert.ToInt32(txtMaNV.Text));
            cboNganh.DisplayMember = "nganh";
            cboNganh.ValueMember = "nganh";
            TrinhDoChuyenMonDTO ds = trinhdoCMBUL.layDStrinhdoCMtheomavanganh(Convert.ToInt32(this.Tag.ToString()), cboNganh.SelectedValue.ToString())[0];
            cboLoaiHinhDT.SelectedValue = ds.LoaiHinhDaoTao;
            cboTrinhDo.SelectedValue = ds.TrinhDo;
            txtTruongDT.Text = ds.TruongDaoTao;
        }

        private void btnSuaTDCM_Click_1(object sender, EventArgs e)
        {
            int maNV = Convert.ToInt32(txtMaNV.Text);
            string nganh = cboNganh.SelectedValue.ToString();
            string trinhdo = cboTrinhDo.SelectedValue.ToString();
            string loaihinhDT = cboLoaiHinhDT.SelectedValue.ToString();
            string truongDT = txtTruongDT.Text.ToString();
            bool kt = trinhdoCMBUL.suaTDCM(maNV, nganh, trinhdo, loaihinhDT, truongDT);
            if (kt)
            {
                MessageBox.Show("Sửa thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Sửa thất bại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            UCQLTrinhDoChuyenMon uCQLTrinhDoChuyen = new UCQLTrinhDoChuyenMon();
            uCQLTrinhDoChuyen.hienThi();
            this.Close();
        }

        private void btnHuyTDCM_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cboNganh_SelectionChangeCommitted_1(object sender, EventArgs e)
        {
            TrinhDoChuyenMonDTO ds = trinhdoCMBUL.layDStrinhdoCMtheomavanganh(Convert.ToInt32(this.Tag.ToString()), cboNganh.SelectedValue.ToString())[0];
            cboLoaiHinhDT.SelectedValue = ds.LoaiHinhDaoTao;
            cboTrinhDo.SelectedValue = ds.TrinhDo;
            txtTruongDT.Text = ds.TruongDaoTao;
        }

        private void cboTrinhDo_SelectionChangeCommitted(object sender, EventArgs e)
        {

        }

        private void cboLoaiHinhDT_SelectionChangeCommitted(object sender, EventArgs e)
        {

        }
    }
}
