using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using System.Data.SqlClient;
using System.Data;
namespace DAL
{
    public class NhanVienChucVuDAL
    {
        public DataTable LayThongTinNhanVienChucVu()
        {
            DataTable dtNhanVienChucVu = new DataTable();
            KetNoiCSDL.MoKetNoi();
            string sqlSelect = "select hoso.manhanvien,trim({ fn CONCAT(HoSo.HoDem + ' ', HoSo.TenDem) }) AS TenNhanVien,tenchucvu,phongban.tenphongban,tungay,denngay from " +
                "nhanvien_chucvu inner join hoso on nhanvien_chucvu.manhanvien=hoso.manhanvien " +
                "inner join phongban on hoso.maphongban=phongban.maphongban " +
                "inner join chucvu on chucvu.machucvu=nhanvien_chucvu.machucvu";
            SqlDataAdapter daNhanVienChucVu = new SqlDataAdapter(sqlSelect, KetNoiCSDL.KetNoi);
            daNhanVienChucVu.Fill(dtNhanVienChucVu);
            KetNoiCSDL.DongKetNoi();
            return dtNhanVienChucVu;
        }

        public DataTable LayThongTinNhanVienChucVuTheoMaNV(int maNV)
        {
            DataTable dtNhanVienChucVu = new DataTable();
            KetNoiCSDL.MoKetNoi();
            string sqlSelect = "select hoso.manhanvien, trim({ fn CONCAT(HoSo.HoDem + ' ', HoSo.TenDem) }) AS TenNhanVien,tenchucvu,phongban.tenphongban,tungay,denngay from " +
                "nhanvien_chucvu inner join hoso on nhanvien_chucvu.manhanvien=hoso.manhanvien " +
                "inner join phongban on hoso.maphongban=phongban.maphongban " +
                "inner join chucvu on chucvu.machucvu=nhanvien_chucvu.machucvu where  nhanvien_chucvu.manhanvien=@ma ";
            SqlDataAdapter daNhanVienChucVu = new SqlDataAdapter(sqlSelect, KetNoiCSDL.KetNoi);
            daNhanVienChucVu.SelectCommand.Parameters.Add("ma", maNV);
            daNhanVienChucVu.Fill(dtNhanVienChucVu);
            KetNoiCSDL.DongKetNoi();
            return dtNhanVienChucVu;
        }
        public bool ThemNhanVienChucVu(int maNhanVien, int maChucVu, string tuNgay, string denNgay)
        {
            try
            {
                KetNoiCSDL.MoKetNoi();
                string sqlInsert = "insert into nhanvien_chucvu values(@maNV,@maCV,@tuNgay,@denNgay)";
                SqlCommand cmd = new SqlCommand(sqlInsert, KetNoiCSDL.KetNoi);

                cmd.Parameters.Add("maNV", maNhanVien);
                cmd.Parameters.Add("maCV", maChucVu);
                cmd.Parameters.Add("tuNgay", tuNgay);
                cmd.Parameters.Add("denNgay", denNgay);

                cmd.ExecuteNonQuery();

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
            finally
            {
                KetNoiCSDL.DongKetNoi();
            }

        }
        public bool SuaNhanVienChucVu(int maNV, int maCV, string tuNgay, string denNgay)
        {
            try
            {
                KetNoiCSDL.MoKetNoi();
                string sqlUpdate = "update nhanvien_chucvu set denngay=@den where manhanvien=@maNV and machucvu=@maCV and tungay=@tu";
                SqlCommand cmd = new SqlCommand(sqlUpdate, KetNoiCSDL.KetNoi);
                cmd.Parameters.Add("maNV", maNV);
                cmd.Parameters.Add("maCV", maCV);
                cmd.Parameters.Add("tu", tuNgay);
                cmd.Parameters.Add("den", denNgay);
                cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
            finally
            {
                KetNoiCSDL.DongKetNoi();
            }
        }
        public bool XoaNhanVienChucVu(int maNV, int maCV, string tuNgay)
        {
            try
            {
                KetNoiCSDL.MoKetNoi();
                string sqlDelete = "delete from nhanvien_chucvu where manhanvien=@maNV and machucvu=@maCV and tungay=@tu";
                SqlCommand cmd = new SqlCommand(sqlDelete, KetNoiCSDL.KetNoi);
                cmd.Parameters.Add("maNV", maNV);
                cmd.Parameters.Add("maCV", maCV);
                cmd.Parameters.Add("tu", tuNgay);
                cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
            finally
            {
                KetNoiCSDL.DongKetNoi();
            }
        }
        public List<NhanVienChucVuDTO> LayNhanVienChucVuTheoMaNVMaCV(int manv, int macv)
        {
            List<NhanVienChucVuDTO> ds = new List<NhanVienChucVuDTO>();
            KetNoiCSDL.MoKetNoi();

            string sqlSelect = "select tungay from nhanvien_chucvu where manhanvien=@manv and machucvu=@macv";
            SqlCommand cmd = new SqlCommand(sqlSelect, KetNoiCSDL.KetNoi);
            cmd.Parameters.Add("manv", manv);
            cmd.Parameters.Add("macv", macv);

            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                DateTime dt = DateTime.Parse(dr["tungay"].ToString());
                NhanVienChucVuDTO nv = new NhanVienChucVuDTO(
                                                             manv, macv,
                                                             dt.ToString("dd/MM/yyyy"),
                                                             ""
                                                            );
                ds.Add(nv);
            }

            KetNoiCSDL.DongKetNoi();
            return ds;
        }
        public NhanVienChucVuDTO LayNhanVienChucVuTheoMaNVMaCVTuNgay(int maNV, int maCV, string tungay)
        {
            NhanVienChucVuDTO nhanVienChucVu = new NhanVienChucVuDTO();
            KetNoiCSDL.MoKetNoi();
            DateTime dt = DateTime.ParseExact(tungay, "dd/MM/yyyy", null);
            string sqlSelect = "Select * from nhanvien_chucvu where manhanvien=@manv and machucvu=@macv and tungay=@ngay";
            SqlCommand cmd = new SqlCommand(sqlSelect, KetNoiCSDL.KetNoi);
            cmd.Parameters.Add("manv", maNV);
            cmd.Parameters.Add("macv", maCV);
            cmd.Parameters.Add("ngay", dt.ToString("MM/dd/yyyy"));

            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                DateTime date = DateTime.Parse(dr["denngay"].ToString());
                nhanVienChucVu.MaNhanVien = maNV;
                nhanVienChucVu.MaChucVu = maCV;
                nhanVienChucVu.TuNgay = tungay;
                nhanVienChucVu.DenNgay = date.ToString("dd/MM/yyyy");
            }

            KetNoiCSDL.DongKetNoi();
            return nhanVienChucVu;
        }
    }
}
