using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using DAL;
using DTO;

namespace BUL
{
    public class QuaTrinhCongTacBUL
    {
        QuaTrinhCongTacDAL quaTrinhCongTacDAL = new QuaTrinhCongTacDAL();
        public DataTable LayThongTinQuaTrinhCongTac()
        {
            return quaTrinhCongTacDAL.LayThongTinQuaTrinhCongTac();
        }
        public DataTable LayThongTinQuaTrinhCongTacTheoMaNV(int maNV)
        {
            return quaTrinhCongTacDAL.LayThongTinQuaTrinhCongTacTheoMaNV(maNV);
        }
        public List<QuaTrinhCongTacDTO> LayDSQuaTrinhCongTacTheoMaNV(int maNV)
        {
            return quaTrinhCongTacDAL.LayDSQuaTrinhCongTacTheoMaNV(maNV);
        }
        public bool ThemQuaTrinhCongTac(int maNV, string tuNgay, string denNgay, string noiCongTac, string chucVu)
        {
            return quaTrinhCongTacDAL.ThemQuaTrinhCongTac(maNV, tuNgay, denNgay, noiCongTac, chucVu);

        }
        public List<QuaTrinhCongTacDTO> LayBangQuaTrinhCongTacTheoMaNV(int maNV)
        {
            return quaTrinhCongTacDAL.LayBangQuaTrinhCongTacTheoMaNV(maNV);
        }
        public QuaTrinhCongTacDTO LayBangQuaTrinhCongTacTheoMaNVTuNgay(int maNV, string tuNgay)
        {
            return quaTrinhCongTacDAL.LayBangQuaTrinhCongTacTheoMaNVTuNgay(maNV, tuNgay);
        }
        public bool XoaQuaTrinhcongTac(int maNV, string tuNgay, string denNgay, string noiCongTac, string chucVu)
        {
            return quaTrinhCongTacDAL.XoaQuaTrinhCongTac(maNV, tuNgay, denNgay, noiCongTac, chucVu);
        }
        public bool SuaQuaTrinhCongTac(int maNV, string tuNgay, string denNgay, string noiCongTac, string chucVu)
        {
            return quaTrinhCongTacDAL.SuaQuaTrinhCongTac(maNV, tuNgay, denNgay, noiCongTac, chucVu);
        }
    }
}
