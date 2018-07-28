using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class NhanVienChucVuDTO
    {
        private int maNhanVien;
        private int maChucVu;
        private string tuNgay;
        private string denNgay;

        public NhanVienChucVuDTO() { }



        public NhanVienChucVuDTO(int maNhanVien, int maChucVu, string tuNgay, string denNgay)
        {
            this.maNhanVien = maNhanVien;
            this.maChucVu = maChucVu;
            this.tuNgay = tuNgay;
            this.denNgay = denNgay;
        }


        public int MaNhanVien { get => maNhanVien; set => maNhanVien = value; }
        public int MaChucVu { get => maChucVu; set => maChucVu = value; }
        public string TuNgay { get => tuNgay; set => tuNgay = value; }
        public string DenNgay { get => denNgay; set => denNgay = value; }
    }
}
