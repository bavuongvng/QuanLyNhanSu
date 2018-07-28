using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class HoSoDTO
    {
        private int maNhanVien;
        private string hoDem;
        private string tenDem;
        private string ngaySinh;
        private string gioiTinh;
        private string soDienThoai;
        private string email;
        private string ngayTuyenDung;
        private int maPhongBan;
        public HoSoDTO() { }
        public HoSoDTO(int maNhanVien, string hoDem, string tenDem,
            string ngaySinh, string gioiTinh, string soDienThoai,
            string email, string ngayTuyenDung, int maPhongBan)
        {
            this.maNhanVien = maNhanVien;
            this.hoDem = hoDem;
            this.tenDem = tenDem;
            this.ngaySinh = ngaySinh;
            this.gioiTinh = gioiTinh;
            this.soDienThoai = soDienThoai;
            this.email = email;
            this.ngayTuyenDung = ngayTuyenDung;
            this.maPhongBan = maPhongBan;
        }

        public int MaNhanVien { get => maNhanVien; set => maNhanVien = value; }
        public string HoDem { get => hoDem; set => hoDem = value; }
        public string TenDem { get => tenDem; set => tenDem = value; }
        public string NgaySinh { get => ngaySinh; set => ngaySinh = value; }
        public string GioiTinh { get => gioiTinh; set => gioiTinh = value; }
        public string SoDienThoai { get => soDienThoai; set => soDienThoai = value; }
        public string Email { get => email; set => email = value; }
        public string NgayTuyenDung { get => ngayTuyenDung; set => ngayTuyenDung = value; }
        public int MaPhongBan { get => maPhongBan; set => maPhongBan = value; }
    }
}
