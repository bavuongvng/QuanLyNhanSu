using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class TrinhDoChuyenMonDTO
    {
        private int maNhanVien;
        private string nganh;
        private string trinhDo;
        private string loaiHinhDaoTao;
        private string truongDaoTao;

        private int soTrinhDoTheoTen;
        public TrinhDoChuyenMonDTO() { }

        public TrinhDoChuyenMonDTO(string trinhDo)
        {
            this.trinhDo = trinhDo;
        }

        public TrinhDoChuyenMonDTO(string trinhDo, int soTrinhDoTheoTen)
        {
            this.trinhDo = trinhDo;
            this.soTrinhDoTheoTen = soTrinhDoTheoTen;
        }

        public TrinhDoChuyenMonDTO(int maNhanVien, string nganh, string trinhDo, string loaiHinhDaoTao, string truongDaoTao)
        {
            this.maNhanVien = maNhanVien;
            this.nganh = nganh;
            this.trinhDo = trinhDo;
            this.loaiHinhDaoTao = loaiHinhDaoTao;
            this.truongDaoTao = truongDaoTao;
        }

        public int MaNhanVien { get => maNhanVien; set => maNhanVien = value; }
        public string Nganh { get => nganh; set => nganh = value; }
        public string TrinhDo { get => trinhDo; set => trinhDo = value; }
        public string LoaiHinhDaoTao { get => loaiHinhDaoTao; set => loaiHinhDaoTao = value; }
        public string TruongDaoTao { get => truongDaoTao; set => truongDaoTao = value; }
        public int SoTrinhDoTheoTen { get => soTrinhDoTheoTen; set => soTrinhDoTheoTen = value; }
    }
}
