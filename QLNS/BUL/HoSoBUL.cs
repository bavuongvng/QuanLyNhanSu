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
    public class HoSoBUL
    {
        HoSoDAL hoSoDAL = new HoSoDAL();
        public int TongSoHoSo()
        {
            return hoSoDAL.TongSoHoSo();
        }
        public List<HoSoDTO> LayDSHoSo()
        {
            List<HoSoDTO> ds = hoSoDAL.LayBangHoSo();
            return hoSoDAL.LayBangHoSo();
        }
        public string LayTenTheoMaNhanVien(int maNV)
        {
            string ten = hoSoDAL.LayTenTheoMaNhanVien(maNV);
            return hoSoDAL.LayTenTheoMaNhanVien(maNV);
        }
        public DataTable LayThongTinHoSo()
        {
            return hoSoDAL.LayThongTinHoSo();
        }
        public DataTable LayDSHoSoTheoMaNV(int ma)
        {
            return hoSoDAL.layThongTinHoSoTheoMaNV(ma);
        }
        public bool ThemHoSo(string hoDem, string ten, string ngaySinh, string gioiTinh, string sdt, string email, string ngayTuyenDung, int maPhongBan)
        {
            return hoSoDAL.themHoSo(hoDem, ten, ngaySinh, gioiTinh, sdt, email, ngayTuyenDung, maPhongBan);
        }
        public HoSoDTO LayNhanVienTheoMa(int maNhanVien)
        {
            return hoSoDAL.LayNhanVienTheoMa(maNhanVien);
        }
        public List<HoSoDTO> LayDSHoSoTheoMa(int maNV)
        {
            List<HoSoDTO> ds = hoSoDAL.LayDSHoSoTheoMaNV(maNV);
            return hoSoDAL.LayDSHoSoTheoMaNV(maNV);
        }
        public bool SuaHoSo(string manv, string hoDem, string ten, string ngaySinh, string gioiTinh, string sdt, string email, string ngayTuyenDung, int maPhongBan)
        {
            return hoSoDAL.suaHoSo(manv, hoDem, ten, ngaySinh, gioiTinh, sdt, email, ngayTuyenDung, maPhongBan);
        }
        public bool xoaHoSo(string manv)
        {
            return hoSoDAL.xoaHoSo(manv);
        }
        public int LayMaHoSoMoiThem()
        {
            return hoSoDAL.LayMaHoSoMoiThem();
        }
    }
}
