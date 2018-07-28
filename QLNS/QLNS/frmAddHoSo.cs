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

namespace QLNS
{
    public partial class frmAddHoSo : Form
    {
        private HoSoBUL hosoBUL = new HoSoBUL();
        private PhongBanBUL phongBanBUL = new PhongBanBUL();
        private ChucVuBUL chucVuBUL = new ChucVuBUL();
        private TrinhDoChuyenMonBUL trinhDoChuyenMonBUL = new TrinhDoChuyenMonBUL();
        private NhanVienChucVuBUL nhanVienChucVuBUL = new NhanVienChucVuBUL();
        private TrinhDoNgoaiNguBUL trinhdoNNBUL = new TrinhDoNgoaiNguBUL();
        private QuaTrinhCongTacBUL quaTrinhCongTacBUL = new QuaTrinhCongTacBUL();
        public frmAddHoSo()
        {
            InitializeComponent();
        }

        private void cbbMaPhongBan_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void frmAddHoSo_Load(object sender, EventArgs e)
        {
            cbbMaPhongBan.DataSource = phongBanBUL.LayDSPhongBan();
            cbbMaPhongBan.DisplayMember = "TenPhongBan";
            cbbMaPhongBan.ValueMember = "MaPhongBan";
            dtNgaySinh.Format = DateTimePickerFormat.Custom;
            dtNgaySinh.CustomFormat = "dd/MM/yyyy";
            dtNgayTD.Format = DateTimePickerFormat.Custom;
            dtNgayTD.CustomFormat = "dd/MM/yyyy";

        }
        private void btnThemTDCM_Click(object sender, EventArgs e)
        {

        }

        private void btnThem_Click_1(object sender, EventArgs e)
        {
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
            bool kt = hosoBUL.ThemHoSo(hodem, ten, ns, gioitinh, sdt, email, ntd, maphongban);
            if (kt)
            {
                MessageBox.Show("Thêm thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Thêm thất bại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            UCQLHoSo ucQLHS = new UCQLHoSo();
            int ma = hosoBUL.LayMaHoSoMoiThem();
            lbMaNhanVien.Text = ma.ToString();

            cbbMaChucVu.DataSource = chucVuBUL.LayDSChucVu();
            cbbMaChucVu.DisplayMember = "tenchucvu";
            cbbMaChucVu.ValueMember = "machucvu";
            dtTuNgay.Format = DateTimePickerFormat.Custom;
            dtTuNgay.CustomFormat = "dd/MM/yyyy";
            dtDenNgay.Format = DateTimePickerFormat.Custom;
            dtDenNgay.CustomFormat = "dd/MM/yyyy";
            lblTen.Text = hosoBUL.LayTenTheoMaNhanVien(ma);

            lbMaNhanVienTDCM.Text = ma.ToString();
            lbTenNhanVienTDCM.Text = hosoBUL.LayTenTheoMaNhanVien(ma);
            cboTrinhDo.DataSource = trinhDoChuyenMonBUL.LayThongTinTrinhDoCHuyenMongopTD();
            cboTrinhDo.DisplayMember = "TrinhDo";
            cboTrinhDo.ValueMember = "TrinhDo";
            cbbLoaihinhDaoTao.DataSource = trinhDoChuyenMonBUL.LayThongTinTrinhDoCHuyenMongopLHDT();
            cbbLoaihinhDaoTao.DisplayMember = "LoaiHinhDaoTao";
            cbbLoaihinhDaoTao.ValueMember = "LoaiHinhDaoTao";

            lbMaNhanVienTDNN.Text = ma.ToString();
            lbTenNhanVienTDNN.Text = hosoBUL.LayTenTheoMaNhanVien(ma);
            cboNgoaiNgu.DataSource = trinhdoNNBUL.LayThongTinTDNNgopNN();
            cboNgoaiNgu.DisplayMember = "NgoaiNgu";
            cboNgoaiNgu.ValueMember = "NgoaiNgu";

            lbMaNhanvienQTCT.Text = ma.ToString();

            dtTuNgay.Format = DateTimePickerFormat.Custom;
            dtTuNgay.CustomFormat = "dd/MM/yyyy";
            dtDenNgay.Format = DateTimePickerFormat.Custom;
            dtDenNgay.CustomFormat = "dd/MM/yyyy";
            cbbChucVu.DataSource = chucVuBUL.LayDSChucVu();
            cbbChucVu.DisplayMember = "tenchucvu";
            cbbChucVu.ValueMember = "tenchucvu";
            lbTenNhanVienQTCT.Text = hosoBUL.LayTenTheoMaNhanVien(ma);

            ucQLHS.HienThi();
        }

        private void btnHuy_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void bunifuThinButton23_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void bunifuThinButton24_Click(object sender, EventArgs e)
        {
            int maNhanvien = Convert.ToInt32(lbMaNhanVien.Text);
            int machucVu = Convert.ToInt32(cbbMaChucVu.SelectedValue);
            DateTime tuNgay = dtTuNgay.Value;
            string tu = tuNgay.ToString("MM/dd/yyyy");
            DateTime denNgay = dtDenNgay.Value;
            string den = denNgay.ToString("MM/dd/yyyy");

            bool kt = nhanVienChucVuBUL.ThemNhanVienchucVu(maNhanvien, machucVu, tu, den);
            if (kt)
            {
                MessageBox.Show("Thêm thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Thêm thất bại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnThemTDCM_Click_1(object sender, EventArgs e)
        {
            int maNV = Convert.ToInt32(lbMaNhanVienTDCM.Text);
            string nganh = txtNganh.Text.ToString();
            string trinhdo = cboTrinhDo.SelectedValue.ToString();
            string loaihinhDT = cbbLoaihinhDaoTao.SelectedValue.ToString();
            string truongDT = txtTruongDaoTao.Text.ToString();
            bool kt = trinhDoChuyenMonBUL.ThemTDCM(maNV, nganh, trinhdo, loaihinhDT, truongDT);
            if (kt)
            {
                MessageBox.Show("Thêm thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Thêm thất bại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            UCQLTrinhDoChuyenMon uCQLTrinhDoChuyen = new UCQLTrinhDoChuyenMon();
        }

        private void btnHuyTDCM_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnThemTDNN_Click(object sender, EventArgs e)
        {
            int maNV = Convert.ToInt32(lbMaNhanVienTDNN.Text);
            string ngoaingu = cboNgoaiNgu.SelectedValue.ToString();
            string trinhdo = txtTrinhDo.Text.ToString();
            bool kt = trinhdoNNBUL.themTrinhDoNN(maNV, ngoaingu, trinhdo);
            if (kt)
            {
                MessageBox.Show("Thêm thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Thêm thất bại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnHuyTDNN_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void bunifuThinButton22_Click(object sender, EventArgs e)
        {
            int maNhanvien = Convert.ToInt32(lbMaNhanvienQTCT.Text);
            DateTime tuNgay = dtTuNgay.Value;
            string tu = tuNgay.ToString("MM/dd/yyyy");
            DateTime denNgay = dtDenNgay.Value;
            string den = denNgay.ToString("MM/dd/yyyy");
            string noiCT = txtNCT.Text;
            string chucvu = cbbChucVu.SelectedValue.ToString();

            bool kt = quaTrinhCongTacBUL.ThemQuaTrinhCongTac(maNhanvien, tu, den, noiCT, chucvu);
            if (kt)
            {
                MessageBox.Show("Thêm thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Thêm thất bại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void bunifuThinButton21_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tabPage1_Click_1(object sender, EventArgs e)
        {

        }
    }
}
