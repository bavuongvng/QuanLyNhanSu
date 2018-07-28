using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using DTO;
using System.Data;

namespace BUL
{
    public class NhanVienChucVuBUL
    {
        NhanVienChucVuDAL nhanVienChucVuDAL = new NhanVienChucVuDAL();
        public DataTable LayThongTinNhanVienChucVu()
        {
            return nhanVienChucVuDAL.LayThongTinNhanVienChucVu();
        }
        public DataTable LayDSNhanVienChucVuTheoMaNV(int ma)
        {
            return nhanVienChucVuDAL.LayThongTinNhanVienChucVuTheoMaNV(ma);
        }
        public bool ThemNhanVienchucVu(int maNhanVien, int maChucVu, string tuNgay, string denNgay)
        {
            return nhanVienChucVuDAL.ThemNhanVienChucVu(maNhanVien, maChucVu, tuNgay, denNgay);
        }
        public bool SuaNhanVienChucVu(int maNV, int maCV, string tuNgay, string denNgay)
        {
            return nhanVienChucVuDAL.SuaNhanVienChucVu(maNV, maCV, tuNgay, denNgay);
        }
        public bool XoaNhanVienChucVu(int maNV, int maCV, string tuNgay)
        {
            return nhanVienChucVuDAL.XoaNhanVienChucVu(maNV, maCV, tuNgay);
        }
        public NhanVienChucVuDTO LayNhanVienChucVuTheoMaNVMaCVTuNgay(int maNV, int maCV, string tungay)
        {
            return nhanVienChucVuDAL.LayNhanVienChucVuTheoMaNVMaCVTuNgay(maNV, maCV, tungay);
        }
        public List<NhanVienChucVuDTO> LayNhanVienChucVuTheoMaNVMaCV(int manv, int macv)
        {
            return nhanVienChucVuDAL.LayNhanVienChucVuTheoMaNVMaCV(manv, macv);
        }
    }
}
