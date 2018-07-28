using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class TrinhDoNgoaiNguDTO
    {
        private int maNhanVien;
        private string ngoaiNgu;
        private string trinhDo;

        private int soTrinhDoTheoTen;
        public TrinhDoNgoaiNguDTO() { }

        public TrinhDoNgoaiNguDTO(string trinhDo, int soTrinhDoTheoTen)
        {
            this.trinhDo = trinhDo;
            this.soTrinhDoTheoTen = soTrinhDoTheoTen;
        }

        public TrinhDoNgoaiNguDTO(int maNhanVien, string ngoaiNgu, string trinhDo)
        {
            this.maNhanVien = maNhanVien;
            this.ngoaiNgu = ngoaiNgu;
            this.trinhDo = trinhDo;
        }

        public int MaNhanVien { get => maNhanVien; set => maNhanVien = value; }
        public string NgoaiNgu { get => ngoaiNgu; set => ngoaiNgu = value; }
        public string TrinhDo { get => trinhDo; set => trinhDo = value; }
        public int SoTrinhDoTheoTen { get => soTrinhDoTheoTen; set => soTrinhDoTheoTen = value; }
    }
}
