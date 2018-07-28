using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using DTO;

namespace BUL
{
    public class PhongBanBUL
    {
        PhongBanDAL phongBanDAL = new PhongBanDAL();
        public int TongSoPhongBan()
        {
            return phongBanDAL.TongSoPhongBan();
        }
        public List<PhongBanDTO> LayDSPhongBan()
        {
            return phongBanDAL.LayPhongBan();
        }
        public bool XoaPhongBan(int maPB)
        {
            return phongBanDAL.XoaPhongBan(maPB);
        }
        public List<PhongBanDTO> LayDSPhongBanTheoMaPB(int ma)
        {
            return phongBanDAL.LayPhongBanTheoMaPB(ma);
        }
        public bool ThemPhongBan(string tenPB, string ngayLap)
        {
            return phongBanDAL.ThemPhongBan(tenPB, ngayLap);
        }
        public bool SuaPhongBan(int maPB, string tenPB, string ngayLap)
        {
            return phongBanDAL.SuaPhongBan(maPB, tenPB, ngayLap);
        }
        public PhongBanDTO LayPhongBanTheoMaNV(int manv)
        {
            return phongBanDAL.LayPhongBanTheoMaNV(manv);
        }
    }
}
