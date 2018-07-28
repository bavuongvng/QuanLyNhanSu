using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class QuaTrinhCongTacDTO
    {
        private int maNhanVien;
        private string tuNgay;
        private string denNgay;
        private string noiCongTac;
        private string chucVu;
        public QuaTrinhCongTacDTO() { }
        public QuaTrinhCongTacDTO(int maNhanVien, string tuNgay, string denNgay, string noiCongTac, string chucVu)
        {
            this.maNhanVien = maNhanVien;
            this.tuNgay = tuNgay;
            this.denNgay = denNgay;
            this.noiCongTac = noiCongTac;
            this.chucVu = chucVu;
        }

        public int MaNhanVien { get => maNhanVien; set => maNhanVien = value; }
        public string TuNgay { get => tuNgay; set => tuNgay = value; }
        public string DenNgay { get => denNgay; set => denNgay = value; }
        public string NoiCongTac { get => noiCongTac; set => noiCongTac = value; }
        public string ChucVu { get => chucVu; set => chucVu = value; }
    }
}
