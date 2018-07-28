using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using DTO;

namespace BUL
{
    public class ChucVuBUL
    {
        ChucVuDAL chucVuDAL = new ChucVuDAL();
        public List<ChucVuDTO> LayDSChucVu()
        {
            return chucVuDAL.LayBangChucVu();
        }
        public List<ChucVuDTO> LayTenChucVuTheoMaNhanVien(int manv)
        {
            return chucVuDAL.LayTenChucVuTheoMaNhanVien(manv);
        }
        public bool XoaChucVu(int maCV)
        {
            return chucVuDAL.XoaChucVu(maCV);
        }
        public List<ChucVuDTO> LayDSChucVuTheoMaCV(int maCV)
        {
            return chucVuDAL.LayDSChucVuTheoMaCV(maCV);
        }
        public bool ThemChucVu(string tenCV, float heSoPhuCap)
        {
            return chucVuDAL.ThemChucVu(tenCV, heSoPhuCap);
        }
        public bool SuaChucVu(int maCV, string tenCV, float heSoPhuCap)
        {
            return chucVuDAL.SuaChucVu(maCV, tenCV, heSoPhuCap);
        }
    }
}
