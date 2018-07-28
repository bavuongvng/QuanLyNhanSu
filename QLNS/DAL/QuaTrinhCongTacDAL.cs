using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using DTO;

namespace DAL
{
    public class QuaTrinhCongTacDAL
    {
        public DataTable LayThongTinQuaTrinhCongTac()
        {
            DataTable dtQuaTrinhCongTac = new DataTable();
            KetNoiCSDL.MoKetNoi();
            string sqlselect = "select  QuaTrinhCongTac.MaNhanVien,{ fn concat(hodem + ' ',TenDem) } as 'Hoten', " +
                "QuaTrinhCongTac.TuNgay, QuaTrinhCongTac.DenNgay, QuaTrinhCongTac.NoiCongTac," +
                " QuaTrinhCongTac.ChucVu from QuaTrinhCongTac" +
                " inner join HoSo on QuaTrinhCongTac.MaNhanVien=HoSo.MaNhanVien";

            SqlDataAdapter adQuaTrinhCongTac = new SqlDataAdapter(sqlselect, KetNoiCSDL.KetNoi);
            adQuaTrinhCongTac.Fill(dtQuaTrinhCongTac);
            KetNoiCSDL.DongKetNoi();
            return dtQuaTrinhCongTac;
        }
        public DataTable LayThongTinQuaTrinhCongTacTheoMaNV(int maNV)
        {
            DataTable dtQuaTrinhCongTac = new DataTable();
            KetNoiCSDL.MoKetNoi();
            string sqlselect = "select  QuaTrinhCongTac.MaNhanVien,{ fn concat(hodem + ' ',TenDem) } as 'Hoten', " +
                "QuaTrinhCongTac.TuNgay, QuaTrinhCongTac.DenNgay, QuaTrinhCongTac.NoiCongTac," +
                " QuaTrinhCongTac.ChucVu from QuaTrinhCongTac" +
                " inner join HoSo on QuaTrinhCongTac.MaNhanVien=HoSo.MaNhanVien where QuaTrinhCongTac.MaNhanVien=@ma";

            SqlDataAdapter adQuaTrinhCongTac = new SqlDataAdapter(sqlselect, KetNoiCSDL.KetNoi);
            adQuaTrinhCongTac.SelectCommand.Parameters.AddWithValue("ma", maNV);
            adQuaTrinhCongTac.Fill(dtQuaTrinhCongTac);
            KetNoiCSDL.DongKetNoi();
            return dtQuaTrinhCongTac;
        }
        public List<QuaTrinhCongTacDTO> LayDSQuaTrinhCongTacTheoMaNV(int maNV)
        {
            List<QuaTrinhCongTacDTO> ds = new List<QuaTrinhCongTacDTO>();

            KetNoiCSDL.MoKetNoi();
            string sqlselect = "select * from QuaTrinhCongTac" +
                " inner join HoSo on QuaTrinhCongTac.MaNhanVien=HoSo.MaNhanVien where QuaTrinhCongTac.MaNhanVien=@ma";

            SqlCommand cmd = new SqlCommand(sqlselect, KetNoiCSDL.KetNoi);
            cmd.Parameters.Add("ma", maNV);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                DateTime dt = DateTime.Parse(dr["tungay"].ToString());
                DateTime dt2 = DateTime.Parse(dr["denngay"].ToString());
                QuaTrinhCongTacDTO qt = new QuaTrinhCongTacDTO(
                                                                Convert.ToInt32(dr["manhanvien"].ToString()),
                                                                dt.ToString("dd/MM/yyyy"),
                                                                dt2.ToString("dd/MM/yyyy"),
                                                                dr["noicongtac"].ToString(),
                                                                dr["chucvu"].ToString()
                                                                );
                ds.Add(qt);
            }

            KetNoiCSDL.DongKetNoi();
            return ds;
        }
        public bool ThemQuaTrinhCongTac(int maNhanVien, string tuNgay, string denNgay, string noiCongTac, string chucvu)
        {
            try
            {
                KetNoiCSDL.MoKetNoi();
                string sqlInsert = "insert into QuaTrinhCongTac values(@maNV,@tuNgay,@denNgay, @noict, @chucvu)";
                SqlCommand cmd = new SqlCommand(sqlInsert, KetNoiCSDL.KetNoi);

                cmd.Parameters.Add("maNV", maNhanVien);
                cmd.Parameters.Add("tuNgay", tuNgay);
                cmd.Parameters.Add("denNgay", denNgay);
                cmd.Parameters.Add("noict", noiCongTac);
                cmd.Parameters.Add("chucvu", chucvu);

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
        public List<QuaTrinhCongTacDTO> LayBangQuaTrinhCongTacTheoMaNV(int maNV)
        {
            List<QuaTrinhCongTacDTO> ds = new List<QuaTrinhCongTacDTO>();
            KetNoiCSDL.MoKetNoi();

            string sqlSelect = "select  * from QuaTrinhcongTac where manhanvien=@ma";
            SqlCommand cmd = new SqlCommand(sqlSelect, KetNoiCSDL.KetNoi);
            cmd.Parameters.Add("ma", maNV);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {

                DateTime date1 = DateTime.Parse(dr["tungay"].ToString());
                DateTime date2 = DateTime.Parse(dr["denngay"].ToString());

                QuaTrinhCongTacDTO ct = new QuaTrinhCongTacDTO(

                                                            Convert.ToInt32(dr["manhanvien"]),
                                                            date1.ToString("dd/MM/yyyy"),
                                                            date2.ToString("dd/MM/yyyy"),
                                                            dr["noicongtac"].ToString(),
                                                            dr["chucvu"].ToString());
                ds.Add(ct);
            }
            KetNoiCSDL.DongKetNoi();
            return ds;
        }
        public QuaTrinhCongTacDTO LayBangQuaTrinhCongTacTheoMaNVTuNgay(int maNV, string tuNgay)
        {
            QuaTrinhCongTacDTO ds = null;
            KetNoiCSDL.MoKetNoi();

            string sqlSelect = "select  * from QuaTrinhcongTac where manhanvien=@ma and tungay=@tungay";
            SqlCommand cmd = new SqlCommand(sqlSelect, KetNoiCSDL.KetNoi);
            cmd.Parameters.Add("ma", maNV);
            cmd.Parameters.Add("tungay", tuNgay);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                DateTime date1 = DateTime.Parse(dr["tungay"].ToString());
                DateTime date2 = DateTime.Parse(dr["denngay"].ToString());

                ds = new QuaTrinhCongTacDTO(

                                                            Convert.ToInt32(dr["manhanvien"]),
                                                            date1.ToString("dd/MM/yyyy"),
                                                            date2.ToString("dd/MM/yyyy"),
                                                            dr["noicongtac"].ToString(),
                                                            dr["chucvu"].ToString());
            }
            KetNoiCSDL.DongKetNoi();
            return ds;
        }
        public bool XoaQuaTrinhCongTac(int maNhanVien, string tuNgay, string denNgay, string noiCongTac, string chucvu)
        {
            try
            {
                KetNoiCSDL.MoKetNoi();
                string sqlDelete = "delete QuaTrinhCongTac where maNhanVien=@maNV and tungay=@tungay";
                SqlCommand cmd = new SqlCommand(sqlDelete, KetNoiCSDL.KetNoi);
                cmd.Parameters.Add("maNV", maNhanVien);
                cmd.Parameters.Add("tungay", tuNgay);
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
        public bool SuaQuaTrinhCongTac(int maNhanVien, string tuNgay, string denNgay, string noiCongTac, string chucvu)
        {
            try
            {
                KetNoiCSDL.MoKetNoi();
                string sqlUpdate = "update QuaTrinhCongTac set  denNgay=@denNgay, noicongtac=@noict, chucVu= @chucvu where maNhanVien=@maNV and tuNgay=@tuNgay";
                SqlCommand cmd = new SqlCommand(sqlUpdate, KetNoiCSDL.KetNoi);

                cmd.Parameters.Add("maNV", maNhanVien);
                cmd.Parameters.Add("tuNgay", tuNgay);
                cmd.Parameters.Add("denNgay", denNgay);
                cmd.Parameters.Add("noict", noiCongTac);
                cmd.Parameters.Add("chucvu", chucvu);

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
    }
}
