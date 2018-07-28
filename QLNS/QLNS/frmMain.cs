using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLNS
{
    public partial class frmMain : Form
    {

        private bool showQLDanhMuc = true;
        private bool showQLTTNhanVien = false;
        private bool showTKBaoCao = false;
        public frmMain()
        {
            InitializeComponent();

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            UCMain ucMain = new UCMain();      //khởi tạo user control main
            pnMain.Controls.Clear();     //Xóa bỏ những gì nằm trên panel
            pnMain.Controls.Add(ucMain);  //Add user control login vào panel
            ucMain.Dock = DockStyle.Fill;    //Chỉnh lại thuộc tính dock cho user control main

        }

        private void btnQuanLyDanhMuc_Click(object sender, EventArgs e)
        {
        }

        private void bunifuFlatButton6_Click(object sender, EventArgs e)
        {

        }

        private void btnQuanLyTTNhanVien_Click(object sender, EventArgs e)
        {
        }

        private void btnThongKeBaoCao_Click(object sender, EventArgs e)
        {
        }
        private void setColorBtnCon(Bunifu.Framework.UI.BunifuFlatButton btn)
        {
            btnPhongBan.Normalcolor = Color.FromArgb(33, 38, 41);
            btnChucVu.Normalcolor = Color.FromArgb(33, 38, 41);
            btnQLHoSo.Normalcolor = Color.FromArgb(33, 38, 41);
            btnQLTrinhDoChuyenMon.Normalcolor = Color.FromArgb(33, 38, 41);
            btnQLTrinhDoNgoaiNgu.Normalcolor = Color.FromArgb(33, 38, 41);
            btnQLQuaTrinhCongTac.Normalcolor = Color.FromArgb(33, 38, 41);
            btnQLNhanVienChucVu.Normalcolor = Color.FromArgb(33, 38, 41);
            btnInHoSo1NV.Normalcolor = Color.FromArgb(33, 38, 41);
            btnInThongKeTrinhDoChuyenMon.Normalcolor = Color.FromArgb(33, 38, 41);
            btnInThongKeTrinhDoNgoaiNgu.Normalcolor = Color.FromArgb(33, 38, 41);

            btn.Normalcolor = Color.FromArgb(0, 172, 193);
        }
        private void ResetColorBtnCon()
        {
            btnPhongBan.Normalcolor = Color.FromArgb(33, 38, 41);
            btnChucVu.Normalcolor = Color.FromArgb(33, 38, 41);
            btnQLHoSo.Normalcolor = Color.FromArgb(33, 38, 41);
            btnQLTrinhDoChuyenMon.Normalcolor = Color.FromArgb(33, 38, 41);
            btnQLTrinhDoNgoaiNgu.Normalcolor = Color.FromArgb(33, 38, 41);
            btnQLQuaTrinhCongTac.Normalcolor = Color.FromArgb(33, 38, 41);
            btnQLNhanVienChucVu.Normalcolor = Color.FromArgb(33, 38, 41);
            btnInHoSo1NV.Normalcolor = Color.FromArgb(33, 38, 41);
            btnInThongKeTrinhDoChuyenMon.Normalcolor = Color.FromArgb(33, 38, 41);
            btnInThongKeTrinhDoNgoaiNgu.Normalcolor = Color.FromArgb(33, 38, 41);
        }

        private void btnPhongBan_Click(object sender, EventArgs e)
        {
            setColorBtnCon(btnPhongBan);
            pnMain.Controls.Clear();
            pnMain.Controls.Add(new UCQLPhongBan());
        }

        private void btnChucVu_Click(object sender, EventArgs e)
        {
            setColorBtnCon(btnChucVu);
            pnMain.Controls.Clear();
            pnMain.Controls.Add(new UCQLChucVu());
        }

        private void btnQLHoSo_Click(object sender, EventArgs e)
        {
            setColorBtnCon(btnQLHoSo);
            pnMain.Controls.Clear();
            pnMain.Controls.Add(new UCQLHoSo());
        }

        private void btnQLTrinhDoChuyenMon_Click(object sender, EventArgs e)
        {
            setColorBtnCon(btnQLTrinhDoChuyenMon);
            pnMain.Controls.Clear();
            pnMain.Controls.Add(new UCQLTrinhDoChuyenMon());
        }

        private void btnQLTrinhDoNgoaiNgu_Click(object sender, EventArgs e)
        {
            setColorBtnCon(btnQLTrinhDoNgoaiNgu);
            pnMain.Controls.Clear();
            pnMain.Controls.Add(new UCQLTDNN());
        }

        private void btnQLQuaTrinhCongTac_Click(object sender, EventArgs e)
        {
            setColorBtnCon(btnQLQuaTrinhCongTac);
            pnMain.Controls.Clear();
            pnMain.Controls.Add(new UCQLQuaTrinhCongTac());
        }

        private void btnQLNhanVienChucVu_Click(object sender, EventArgs e)
        {
            setColorBtnCon(btnQLNhanVienChucVu);
            UCQLNhanVienChucVu uCQLNhanVienChucVu = new UCQLNhanVienChucVu();
            pnMain.Controls.Clear();
            pnMain.Controls.Add(uCQLNhanVienChucVu);
        }

        private void btnInHoSo1NV_Click(object sender, EventArgs e)
        {
            setColorBtnCon(btnInHoSo1NV);
            pnMain.Controls.Clear();
            pnMain.Controls.Add(new UCInHoSo());
        }

        private void btnInThongKeTrinhDoChuyenMon_Click(object sender, EventArgs e)
        {
            setColorBtnCon(btnInThongKeTrinhDoChuyenMon);
            pnMain.Controls.Clear();
            pnMain.Controls.Add(new UCInTrinhDoCM());
        }

        private void btnInThongKeTrinhDoNgoaiNgu_Click(object sender, EventArgs e)
        {
            setColorBtnCon(btnInThongKeTrinhDoNgoaiNgu);
            pnMain.Controls.Clear();
            pnMain.Controls.Add(new UCInThongKeTrinhDoNN());
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void panel2_MouseDown(object sender, MouseEventArgs e)
        {
        }

        private void panel2_MouseUp(object sender, MouseEventArgs e)
        {
        }

        private void bunifuCustomLabel1_Click(object sender, EventArgs e)
        {
            UCMain ucMain = new UCMain();      //khởi tạo user control main
            pnMain.Controls.Clear();     //Xóa bỏ những gì nằm trên panel
            pnMain.Controls.Add(ucMain);  //Add user control login vào panel
            ucMain.Dock = DockStyle.Fill;    //Chỉnh lại thuộc tính dock cho user control main
            ResetColorBtnCon();
        }

        private void btnMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void pnMain_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
