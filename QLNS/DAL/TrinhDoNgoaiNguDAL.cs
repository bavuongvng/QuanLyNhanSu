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
    public class TrinhDoNgoaiNguDAL
    {
        public List<TrinhDoNgoaiNguDTO> DemTrinhDoTheoTen()
        {
            List<TrinhDoNgoaiNguDTO> ds = new List<TrinhDoNgoaiNguDTO>();
            KetNoiCSDL.MoKetNoi();
            string sqlSelect = "select ngoaingu,count(*) as 'tong' from TrinhDoNgoaiNgu group by ngoaingu";
            SqlCommand cmd = new SqlCommand(sqlSelect, KetNoiCSDL.KetNoi);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                TrinhDoNgoaiNguDTO nn = new TrinhDoNgoaiNguDTO(dr["ngoaingu"].ToString(), Convert.ToInt32(dr["tong"]));
                ds.Add(nn);
            }
            KetNoiCSDL.DongKetNoi();
            return ds;
        }
        public List<TrinhDoNgoaiNguDTO> LayBangTrinhDoNgoaiNgu()
        {
            List<TrinhDoNgoaiNguDTO> ds = new List<TrinhDoNgoaiNguDTO>();
            KetNoiCSDL.MoKetNoi();

            string sqlSelect = "select ngoaingu from trinhdongoaingu group by ngoaingu";
            SqlCommand cmd = new SqlCommand(sqlSelect, KetNoiCSDL.KetNoi);
            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                TrinhDoNgoaiNguDTO nn = new TrinhDoNgoaiNguDTO(
                                                                0,
                                                                dr["ngoaingu"].ToString(),
                                                                ""
                                                                );
                ds.Add(nn);
            }

            KetNoiCSDL.DongKetNoi();
            return ds;
        }
        public DataTable LayThongTinTrinhDoNN()
        {
            DataTable dtTrinhDo = new DataTable();
            KetNoiCSDL.MoKetNoi();
            string sqlSelect = "select trinhdongoaingu.manhanvien, hodem,TenDem, ngoaingu, trinhdo from " +
                "trinhdongoaingu inner join hoso on trinhdongoaingu.manhanvien=hoso.manhanvien ";
            SqlDataAdapter daTrinhDo = new SqlDataAdapter(sqlSelect, KetNoiCSDL.KetNoi);
            daTrinhDo.Fill(dtTrinhDo);
            KetNoiCSDL.DongKetNoi();
            return dtTrinhDo;
        }
        public DataTable LayThongTinTrinhDoNNGopMa()
        {
            DataTable dtTrinhDo = new DataTable();
            KetNoiCSDL.MoKetNoi();
            string sqlSelect = "select trinhdongoaingu.manhanvien from " +
                "trinhdongoaingu inner join hoso on trinhdongoaingu.manhanvien=hoso.manhanvien group by trinhdongoaingu.manhanvien";
            SqlDataAdapter daTrinhDo = new SqlDataAdapter(sqlSelect, KetNoiCSDL.KetNoi);
            daTrinhDo.Fill(dtTrinhDo);
            KetNoiCSDL.DongKetNoi();
            return dtTrinhDo;
        }
        public DataTable LayThongTinTrinhDoNNtheoMa(int maNV)
        {
            DataTable dtTrinhDoNN = new DataTable();
            KetNoiCSDL.MoKetNoi();
            string sqlSelect = "select trinhdongoaingu.manhanvien, hodem,TenDem, ngoaingu, trinhdo from " +
                "trinhdongoaingu inner join hoso on trinhdongoaingu.manhanvien=hoso.manhanvien where trinhdongoaingu.manhanvien=@ma";
            SqlDataAdapter daTrinhDoCM = new SqlDataAdapter(sqlSelect, KetNoiCSDL.KetNoi);
            daTrinhDoCM.SelectCommand.Parameters.AddWithValue("ma", maNV);
            daTrinhDoCM.Fill(dtTrinhDoNN);
            KetNoiCSDL.DongKetNoi();
            return dtTrinhDoNN;
        }
        public DataTable LayThongTinTrinhDoNNGopNN()
        {
            DataTable dtTrinhDo = new DataTable();
            KetNoiCSDL.MoKetNoi();
            string sqlSelect = "select ngoaingu  from trinhdongoaingu group by ngoaingu";
            SqlDataAdapter daTrinhDo = new SqlDataAdapter(sqlSelect, KetNoiCSDL.KetNoi);
            daTrinhDo.Fill(dtTrinhDo);
            KetNoiCSDL.DongKetNoi();
            return dtTrinhDo;
        }
        public bool themTDNN(int maNV, string ngoaingu, string trinhdo)
        {
            try
            {
                KetNoiCSDL.MoKetNoi();
                string sqlInsert = "insert into TrinhDoNgoaiNgu values (@ma, @ngoaingu, @trinhdo)";
                SqlCommand cmd = new SqlCommand(sqlInsert, KetNoiCSDL.KetNoi);

                cmd.Parameters.AddWithValue("ma", maNV);
                cmd.Parameters.AddWithValue("ngoaingu", ngoaingu);
                cmd.Parameters.AddWithValue("trinhdo", trinhdo);
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
        public List<TrinhDoNgoaiNguDTO> LayNgoaiNguTheoMa(int MaNV)
        {
            List<TrinhDoNgoaiNguDTO> ds = new List<TrinhDoNgoaiNguDTO>();
            KetNoiCSDL.MoKetNoi();
            string sqlSelect = "select * from trinhdongoaingu where manhanvien=@ma";
            SqlCommand cmd = new SqlCommand(sqlSelect, KetNoiCSDL.KetNoi);
            cmd.Parameters.AddWithValue("ma", MaNV);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                TrinhDoNgoaiNguDTO td = new TrinhDoNgoaiNguDTO(
                                         Convert.ToInt32(dr["manhanvien"]),
                                         dr["ngoaingu"].ToString(),
                                        dr["trinhdo"].ToString()
                                        );
                ds.Add(td);
            }
            KetNoiCSDL.DongKetNoi();
            return ds;
        }
        public List<TrinhDoNgoaiNguDTO> LaytenTDtheoNgoainguvaMa(int maNV, string nganh)
        {
            List<TrinhDoNgoaiNguDTO> ds = new List<TrinhDoNgoaiNguDTO>();
            KetNoiCSDL.MoKetNoi();
            string sqlSelect = "select * from trinhdongoaingu where manhanvien=@ma and ngoaingu=@ngoaingu";
            SqlCommand cmd = new SqlCommand(sqlSelect, KetNoiCSDL.KetNoi);
            cmd.Parameters.AddWithValue("ma", maNV);
            cmd.Parameters.AddWithValue("ngoaingu", nganh);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                TrinhDoNgoaiNguDTO td = new TrinhDoNgoaiNguDTO(
                                         Convert.ToInt32(dr["manhanvien"]),
                                         dr["ngoaingu"].ToString(),
                                        dr["trinhdo"].ToString()
                                        );
                ds.Add(td);
            }
            KetNoiCSDL.DongKetNoi();
            return ds;
        }
        public List<TrinhDoNgoaiNguDTO> LayThongTinTDNNtheoMa(int maNV)
        {
            List<TrinhDoNgoaiNguDTO> ds = new List<TrinhDoNgoaiNguDTO>();
            KetNoiCSDL.MoKetNoi();
            string sqlSelect = "select * from trinhdongoaingu where manhanvien=@ma ";
            SqlCommand cmd = new SqlCommand(sqlSelect, KetNoiCSDL.KetNoi);
            cmd.Parameters.AddWithValue("ma", maNV);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                TrinhDoNgoaiNguDTO td = new TrinhDoNgoaiNguDTO(
                                         Convert.ToInt32(dr["manhanvien"]),
                                         dr["ngoaingu"].ToString(),
                                        dr["trinhdo"].ToString()
                                        );
                ds.Add(td);
            }
            KetNoiCSDL.DongKetNoi();
            return ds;
        }
        public bool suaTDNN(int maNV, string ngoaingu, string trinhdo)
        {
            try
            {
                KetNoiCSDL.MoKetNoi();
                string sqlUpdate = "Update TrinhDoNgoaiNgu set  trinhdo=@trinhdo where manhanvien=@ma and ngoaingu=@ngoaingu";
                SqlCommand cmd = new SqlCommand(sqlUpdate, KetNoiCSDL.KetNoi);

                cmd.Parameters.AddWithValue("ma", maNV);
                cmd.Parameters.AddWithValue("ngoaingu", ngoaingu);
                cmd.Parameters.AddWithValue("trinhdo", trinhdo);
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
        public bool xoaTDNN(int maNV, string ngoaingu)
        {
            try
            {
                KetNoiCSDL.MoKetNoi();
                string sqlDelete = "delete trinhdongoaingu where manhanvien=@ma and ngoaingu=@ngoaingu";
                SqlCommand cmd = new SqlCommand(sqlDelete, KetNoiCSDL.KetNoi);

                cmd.Parameters.AddWithValue("ma", maNV);
                cmd.Parameters.AddWithValue("ngoaingu", ngoaingu);
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
