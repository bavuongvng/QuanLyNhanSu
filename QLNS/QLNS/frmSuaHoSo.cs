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
    public partial class frmSuaHoSo : Form
    {
        private HoSoBUL hoSoBUL = new HoSoBUL();
        private PhongBanBUL phongBanBUL = new PhongBanBUL();
        private QuaTrinhCongTacBUL quaTrinhCongTacBUL = new QuaTrinhCongTacBUL();
        private ChucVuBUL chucVuBUL = new ChucVuBUL();
        private NhanVienChucVuBUL nhanVienChucVuBUL = new NhanVienChucVuBUL();
        private TrinhDoChuyenMonBUL trinhdoCMBUL = new TrinhDoChuyenMonBUL();
        private TrinhDoNgoaiNguBUL trinhdoNNBUL = new TrinhDoNgoaiNguBUL();
        public frmSuaHoSo()
        {
            InitializeComponent();
        }

        private void frmSuaHoSo_Load(object sender, EventArgs e)
        {

            lblMaNV.Text = this.Tag.ToString();
            lbMaNhanVienTDCM.Text = this.Tag.ToString();
            lbMaNhanVienTDNN.Text = this.Tag.ToString();
            cbbMaPhongBan.DataSource = phongBanBUL.LayDSPhongBan();
            cbbMaPhongBan.DisplayMember = "TenPhongBan";
            cbbMaPhongBan.ValueMember = "MaPhongBan";
            lbTenNhanVienTDCM.Text = hoSoBUL.LayTenTheoMaNhanVien(Convert.ToInt32(this.Tag.ToString()));
            lbTenNhanVienTDNN.Text = hoSoBUL.LayTenTheoMaNhanVien(Convert.ToInt32(this.Tag.ToString()));
            dtNgaySinh.Format = DateTimePickerFormat.Custom;
            dtNgaySinh.CustomFormat = "dd/MM/yyyy";
            dtNgayTD.Format = DateTimePickerFormat.Custom;
            dtNgayTD.CustomFormat = "dd/MM/yyyy";
            HoSoDTO ds = hoSoBUL.LayDSHoSoTheoMa(Convert.ToInt32(this.Tag.ToString()))[0];
            txtHodem.Text = ds.HoDem;
            txtTen.Text = ds.TenDem;
            DateTime dt = DateTime.ParseExact(ds.NgaySinh, "dd/MM/yyyy", null);
            dtNgaySinh.Value = dt;
            if (rdoNam.Text == ds.GioiTinh)
            {
                rdoNam.Checked = true;
            }
            if (rdoNu.Text == ds.GioiTinh)
            {
                rdoNu.Checked = true;
            }
            txtSodt.Text = ds.SoDienThoai;
            txtEmail.Text = ds.Email;
            dt = DateTime.ParseExact(ds.NgayTuyenDung, "dd/MM/yyyy", null);
            dtNgayTD.Value = dt;
            cbbMaPhongBan.SelectedValue = ds.MaPhongBan;


            ////////qua trinh cong tac
            lbMaNhanVienQTCT.Text = this.Tag.ToString();
            cbbTuNgay.DataSource = quaTrinhCongTacBUL.LayDSQuaTrinhCongTacTheoMaNV(Convert.ToInt32(this.Tag.ToString()));
            if (quaTrinhCongTacBUL.LayDSQuaTrinhCongTacTheoMaNV(Convert.ToInt32(this.Tag.ToString())).Count > 0)
            {
                cbbTuNgay.DisplayMember = "tungay";
                cbbTuNgay.ValueMember = "tungay";
                cbbTuNgay.SelectedIndex = 0;
                dtDenNgay.Format = DateTimePickerFormat.Custom;
                dtDenNgay.CustomFormat = "dd/MM/yyyy";
                DateTime dtqtct = DateTime.Parse(cbbTuNgay.SelectedValue.ToString());
                string txt = dtqtct.ToString("MM/dd/yyyy");
                QuaTrinhCongTacDTO qtct = quaTrinhCongTacBUL.LayBangQuaTrinhCongTacTheoMaNVTuNgay(Convert.ToInt32(this.Tag.ToString()), dtqtct.ToString("MM/dd/yyyy"));
                lbChucVu.Text = qtct.ChucVu;
                lbTenNhanVienQTCT.Text = hoSoBUL.LayTenTheoMaNhanVien(Convert.ToInt32(this.Tag.ToString()));
                txtNCT.Text = qtct.NoiCongTac;
            }


            /////////////////nhan vien chuc vu
            lbMaNhanVienCV.Text = this.Tag.ToString();
            cbbMaChucVu.DataSource = chucVuBUL.LayTenChucVuTheoMaNhanVien(Convert.ToInt32(this.Tag.ToString()));
            if (chucVuBUL.LayTenChucVuTheoMaNhanVien(Convert.ToInt32(this.Tag.ToString())).Count > 0)
            {
                cbbMaChucVu.DisplayMember = "tenchucvu";
                cbbMaChucVu.ValueMember = "machucvu";
                cbbMaChucVu.SelectedIndex = 0;
                lbTenNhanVienCV.Text = hoSoBUL.LayTenTheoMaNhanVien(Convert.ToInt32(this.Tag.ToString())); ;
                cbbTuNgayNVCV.DataSource = nhanVienChucVuBUL.LayNhanVienChucVuTheoMaNVMaCV(Convert.ToInt32(this.Tag.ToString()), Convert.ToInt32(cbbMaChucVu.SelectedValue));
                cbbTuNgayNVCV.DisplayMember = "tungay";
                cbbTuNgayNVCV.ValueMember = "tungay";
            }


            ////////////// trinh do chuyen mon
            lbMaNhanVienTDCM.Text = this.Tag.ToString();
            lbTenNhanVienTDCM.Text = hoSoBUL.LayTenTheoMaNhanVien(Convert.ToInt32(this.Tag.ToString()));
            cbbLoaiHinhDT.DataSource = trinhdoCMBUL.LayThongTinTrinhDoCHuyenMongopLHDT();
            cbbLoaiHinhDT.DisplayMember = "LoaiHinhDaoTao";
            cbbLoaiHinhDT.ValueMember = "LoaiHinhDaoTao";
            cboTrinhDo.DataSource = trinhdoCMBUL.LayThongTinTrinhDoCHuyenMongopTD();
            cboTrinhDo.DisplayMember = "TrinhDo";
            cboTrinhDo.ValueMember = "TrinhDo";
            cboNganh.DataSource = trinhdoCMBUL.LayThongTinnganhTheoMa(Convert.ToInt32(lbMaNhanVienTDCM.Text));
            cboNganh.DisplayMember = "nganh";
            cboNganh.ValueMember = "nganh";
            if (trinhdoCMBUL.LayDSTDCMtheoMa(Convert.ToInt32(this.Tag.ToString())).Count > 0)
            {
                TrinhDoChuyenMonDTO dsTDCM = trinhdoCMBUL.layDStrinhdoCMtheomavanganh(Convert.ToInt32(this.Tag.ToString()), cboNganh.SelectedValue.ToString())[0];
                cbbLoaiHinhDT.SelectedValue = dsTDCM.LoaiHinhDaoTao;
                cboTrinhDo.SelectedValue = dsTDCM.TrinhDo;
                txtTruongDaoTao.Text = dsTDCM.TruongDaoTao;
            }

            /////////// trinh do ngoai ngu
            lbMaNhanVienTDNN.Text = this.Tag.ToString();
            lbTenNhanVienTDNN.Text = hoSoBUL.LayTenTheoMaNhanVien(Convert.ToInt32(this.Tag.ToString()));
            cboNgoaiNgu.DataSource = trinhdoNNBUL.layNgoaiNguTheoMa(Convert.ToInt32(this.Tag.ToString()));
            cboNgoaiNgu.DisplayMember = "NgoaiNgu";
            cboNgoaiNgu.ValueMember = "NgoaiNgu";
            //List<TrinhDoNgoaiNguDTO> nn = trinhdoNNBUL.layDStrinhdoCMtheomavanganh(Convert.ToInt32(this.Tag.ToString()), cboNgoaiNgu.SelectedValue.ToString());
            if (trinhdoNNBUL.LayTTTrinhDoNNTheoMaNhanVien(Convert.ToInt32(this.Tag.ToString())).Count > 0)
            {
                TrinhDoNgoaiNguDTO dstdnn = trinhdoNNBUL.layDStrinhdoCMtheomavanganh(Convert.ToInt32(this.Tag.ToString()), cboNgoaiNgu.SelectedValue.ToString())[0];
                txtTrinhDo.Text = dstdnn.TrinhDo;
            }
        }

        private void btnSuaTDCM_Click(object sender, EventArgs e)
        {

        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }
        private void btnSua_Click_1(object sender, EventArgs e)
        {
            string ma = lblMaNV.Text;
            string hodem = txtHodem.Text.ToString();
            string ten = txtTen.Text.ToString();
            DateTime ngaysinh = dtNgaySinh.Value;
            string ns = ngaysinh.ToString("MM/dd/yyyy");
            string gioitinh = "";
            if (rdoNam.Checked)
            {
                gioitinh = rdoNam.Text;
            }
            else if (rdoNu.Checked)
            {
                gioitinh = rdoNu.Text;
            }
            string sdt = txtSodt.Text.ToString();
            string email = txtEmail.Text.ToString();
            DateTime ngaytd = dtNgayTD.Value;
            string ntd = ngaytd.ToString("MM/dd/yyyy");
            int maphongban = Convert.ToInt32(cbbMaPhongBan.SelectedValue);
            bool kt = hoSoBUL.SuaHoSo(ma, hodem, ten, ns, gioitinh, sdt, email, ntd, maphongban);
            if (kt)
            {
                MessageBox.Show("Sửa thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Sửa thất bại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnHuy_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSuaQTCT_Click(object sender, EventArgs e)
        {
            int maNhanvien = Convert.ToInt32(lbMaNhanVienQTCT.Text);

            DateTime tuNgay = DateTime.Parse(cbbTuNgay.SelectedValue.ToString());

            DateTime denNgay = dtDenNgay.Value;
            string den = denNgay.ToString("MM/dd/yyyy");
            string noiCT = txtNCT.Text;
            string chucvu = lbChucVu.Text;

            bool kt = quaTrinhCongTacBUL.SuaQuaTrinhCongTac(maNhanvien, tuNgay.ToString("MM/dd/yyyy"), den, noiCT, chucvu);
            if (kt)
            {
                MessageBox.Show("Sửa thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Sửa thất bại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void btnSuaNVCV_Click(object sender, EventArgs e)
        {
            int manv = Convert.ToInt32(lbMaNhanVienCV.Text);
            int macv = Convert.ToInt32(cbbMaChucVu.SelectedValue);
            DateTime dt1 = DateTime.Parse(cbbTuNgayNVCV.SelectedValue.ToString());
            DateTime dt2 = dtDenNgayNVCV.Value;

            bool kt = nhanVienChucVuBUL.SuaNhanVienChucVu(manv, macv, dt1.ToString("MM/dd/yyyy"), dt2.ToString("MM/dd/yyyy"));

            if (kt)
            {
                MessageBox.Show("Sửa thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Sửa thất bại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void bunifuThinButton21_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void bunifuThinButton22_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnHuyTDCM_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSuaTDCM_Click_1(object sender, EventArgs e)
        {
            int maNV = Convert.ToInt32(lbMaNhanVienTDCM.Text);
            string nganh = cboNganh.SelectedValue.ToString();
            string trinhdo = cboTrinhDo.SelectedValue.ToString();
            string loaihinhDT = cbbLoaiHinhDT.SelectedValue.ToString();
            string truongDT = txtTruongDaoTao.Text.ToString();
            bool kt = trinhdoCMBUL.suaTDCM(maNV, nganh, trinhdo, loaihinhDT, truongDT);
            if (kt)
            {
                MessageBox.Show("Sửa thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Sửa thất bại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnSuaTDNN_Click(object sender, EventArgs e)
        {
            int maNV = Convert.ToInt32(lbMaNhanVienTDNN.Text);
            lbMaNhanVienTDNN.Text = hoSoBUL.LayTenTheoMaNhanVien(maNV);
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
        }
    }
}
