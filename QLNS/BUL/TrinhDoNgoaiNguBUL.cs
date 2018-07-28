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
    public class TrinhDoNgoaiNguBUL
    {
        TrinhDoNgoaiNguDAL trinhDoNgoaiNguDAL = new TrinhDoNgoaiNguDAL();
        public List<TrinhDoNgoaiNguDTO> DemTrinhDoNgoaiNguTheoTen()
        {
            return trinhDoNgoaiNguDAL.DemTrinhDoTheoTen();
        }
        public List<TrinhDoNgoaiNguDTO> LayBangTrinhDoNgoaiNgu()
        {
            return trinhDoNgoaiNguDAL.LayBangTrinhDoNgoaiNgu();
        }
        public DataTable LayThongTinTDNN()
        {
            return trinhDoNgoaiNguDAL.LayThongTinTrinhDoNN();
        }
        public DataTable LayThongTinTDNNGopMa()
        {
            return trinhDoNgoaiNguDAL.LayThongTinTrinhDoNNGopMa();
        }
        public DataTable LayThongTinTDNNtheoMa(int ma)
        {
            return trinhDoNgoaiNguDAL.LayThongTinTrinhDoNNtheoMa(ma);
        }
        public DataTable LayThongTinTDNNgopNN()
        {
            return trinhDoNgoaiNguDAL.LayThongTinTrinhDoNNGopNN();
        }
        public bool themTrinhDoNN(int manv, string ngoaingu, string trinhdo)
        {
            return trinhDoNgoaiNguDAL.themTDNN(manv, ngoaingu, trinhdo);
        }
        public List<TrinhDoNgoaiNguDTO> layNgoaiNguTheoMa(int ma)
        {
            return trinhDoNgoaiNguDAL.LayNgoaiNguTheoMa(ma);
        }
        public List<TrinhDoNgoaiNguDTO> layDStrinhdoCMtheomavanganh(int ma, string nganh)
        {
            return trinhDoNgoaiNguDAL.LaytenTDtheoNgoainguvaMa(ma, nganh);
        }
        public bool suaTrinhDoNN(int manv, string ngoaingu, string trinhdo)
        {
            return trinhDoNgoaiNguDAL.suaTDNN(manv, ngoaingu, trinhdo);
        }
        public bool xoaTrinhDoNN(int manv, string ngoaingu)
        {
            return trinhDoNgoaiNguDAL.xoaTDNN(manv, ngoaingu);
        }
        public List<TrinhDoNgoaiNguDTO> LayTTTrinhDoNNTheoMaNhanVien(int maNV)
        {
            return trinhDoNgoaiNguDAL.LayThongTinTDNNtheoMa(maNV);

        }
    }
}
