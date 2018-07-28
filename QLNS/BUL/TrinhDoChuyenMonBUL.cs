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
    public class TrinhDoChuyenMonBUL
    {
        TrinhDoChuyenMonDAL trinhDoChuyenMonDAL = new TrinhDoChuyenMonDAL();
        public List<TrinhDoChuyenMonDTO> DemTrinhDoChuyenMonTheoTen()
        {
            return trinhDoChuyenMonDAL.DemTrinhDoTheoTen();
        }
        public List<TrinhDoChuyenMonDTO> LayDSTrinhDo()
        {
            return trinhDoChuyenMonDAL.LayDSTrinhDo();
        }
        public DataTable LayThongTinTrinhDoCHuyenMon()
        {
            return trinhDoChuyenMonDAL.LayThongTinTrinhDoCHuyenMon();
        }
        public DataTable LayThongTinTrinhDoCHuyenMongopMa()
        {
            return trinhDoChuyenMonDAL.LayThongTinTrinhDoCHuyenMonGopMa();
        }
        public DataTable LayThongTinTrinhDoChuyenMonTheoMa(int ma)
        {
            return trinhDoChuyenMonDAL.LayThongTinTrinhDoCMtheoMa(ma);
        }
        public DataTable LayThongTinTrinhDoCHuyenMongopTD()
        {
            return trinhDoChuyenMonDAL.LayThongTinTrinhDoCHuyenMongopTD();
        }
        public DataTable LayThongTinTrinhDoCHuyenMongopLHDT()
        {
            return trinhDoChuyenMonDAL.LayThongTinTrinhDoCHuyenMongopLHDT();
        }
        public bool ThemTDCM(int maNV, string nganh, string trinhdo, string loaiHinhDT, string TruongDT)
        {
            return trinhDoChuyenMonDAL.themTDCM(maNV, nganh, trinhdo, loaiHinhDT, TruongDT);
        }
        public DataTable LayThongTinnganhTheoMa(int ma)
        {
            return trinhDoChuyenMonDAL.LayThongTinnganhtheoMa(ma);
        }
        public List<TrinhDoChuyenMonDTO> layDStrinhdoCMtheomavanganh(int ma, string nganh)
        {
            return trinhDoChuyenMonDAL.LayDSTDCMtheoMavaNganh(ma, nganh);
        }
        public bool suaTDCM(int maNV, string nganh, string trinhdo, string loaiHinhDT, string TruongDT)
        {
            return trinhDoChuyenMonDAL.suaTDCM(maNV, nganh, trinhdo, loaiHinhDT, TruongDT);
        }
        public bool xoaTDCM(int maNV, string nganh)
        {
            return trinhDoChuyenMonDAL.xoaTDCM(maNV, nganh);
        }
        public List<TrinhDoChuyenMonDTO> LayDSTDCMtheoMa(int maNV)
        {
            return trinhDoChuyenMonDAL.LayDSTDCMtheoMa(maNV);
        }
    }
}
