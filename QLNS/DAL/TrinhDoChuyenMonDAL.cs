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
    public class TrinhDoChuyenMonDAL
    {
        public List<TrinhDoChuyenMonDTO> DemTrinhDoTheoTen()
        {
            List<TrinhDoChuyenMonDTO> ds = new List<TrinhDoChuyenMonDTO>();
            KetNoiCSDL.MoKetNoi();
            string sqlSelect = "select trinhdo,count(*) as 'tong' from trinhdochuyenmon group by TrinhDo";
            SqlCommand cmd = new SqlCommand(sqlSelect, KetNoiCSDL.KetNoi);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                TrinhDoChuyenMonDTO cm = new TrinhDoChuyenMonDTO(dr["trinhdo"].ToString(), Convert.ToInt32(dr["tong"]));
                ds.Add(cm);
            }
            KetNoiCSDL.DongKetNoi();
            return ds;
        }
        public DataTable LayThongTinTrinhDoCHuyenMon()
        {
            DataTable dtTrinhDo = new DataTable();
            KetNoiCSDL.MoKetNoi();
            string sqlSelect = "select trinhdochuyenmon.manhanvien, hodem,TenDem, nganh, trinhdo, loaihinhdaotao, truongdaotao from " +
                "trinhdochuyenmon inner join hoso on trinhdochuyenmon.manhanvien=hoso.manhanvien ";
            SqlDataAdapter daTrinhDo = new SqlDataAdapter(sqlSelect, KetNoiCSDL.KetNoi);
            daTrinhDo.Fill(dtTrinhDo);
            KetNoiCSDL.DongKetNoi();
            return dtTrinhDo;
        }
        public DataTable LayThongTinTrinhDoCHuyenMonGopMa()
        {
            DataTable dtTrinhDo = new DataTable();
            KetNoiCSDL.MoKetNoi();
            string sqlSelect = "select trinhdochuyenmon.manhanvien from " +
                "trinhdochuyenmon inner join hoso on trinhdochuyenmon.manhanvien=hoso.manhanvien group by trinhdochuyenmon.manhanvien";
            SqlDataAdapter daTrinhDo = new SqlDataAdapter(sqlSelect, KetNoiCSDL.KetNoi);
            daTrinhDo.Fill(dtTrinhDo);
            KetNoiCSDL.DongKetNoi();
            return dtTrinhDo;
        }
        public DataTable LayThongTinTrinhDoCMtheoMa(int maNV)
        {
            DataTable dtTrinhDoCM = new DataTable();
            KetNoiCSDL.MoKetNoi();
            string sqlSelect = "select trinhdochuyenmon.manhanvien, hodem,TenDem, nganh, trinhdo, loaihinhdaotao, truongdaotao from " +
                "trinhdochuyenmon inner join hoso on trinhdochuyenmon.manhanvien=hoso.manhanvien where hoso.manhanvien=@ma";
            SqlDataAdapter daTrinhDoCM = new SqlDataAdapter(sqlSelect, KetNoiCSDL.KetNoi);
            daTrinhDoCM.SelectCommand.Parameters.AddWithValue("ma", maNV);
            daTrinhDoCM.Fill(dtTrinhDoCM);
            KetNoiCSDL.DongKetNoi();
            return dtTrinhDoCM;
        }
        public DataTable LayThongTinTrinhDoCHuyenMongopTD()
        {
            DataTable dtTrinhDo = new DataTable();
            KetNoiCSDL.MoKetNoi();
            string sqlSelect = "select trinhdo  from trinhdochuyenmon group by trinhdo";
            SqlDataAdapter daTrinhDo = new SqlDataAdapter(sqlSelect, KetNoiCSDL.KetNoi);
            daTrinhDo.Fill(dtTrinhDo);
            KetNoiCSDL.DongKetNoi();
            return dtTrinhDo;
        }
        public DataTable LayThongTinTrinhDoCHuyenMongopLHDT()
        {
            DataTable dtTrinhDo = new DataTable();
            KetNoiCSDL.MoKetNoi();
            string sqlSelect = "select loaihinhdaotao  from trinhdochuyenmon group by loaihinhdaotao";
            SqlDataAdapter daTrinhDo = new SqlDataAdapter(sqlSelect, KetNoiCSDL.KetNoi);
            daTrinhDo.Fill(dtTrinhDo);
            KetNoiCSDL.DongKetNoi();
            return dtTrinhDo;
        }
        public bool themTDCM(int maNV, string nganh, string trinhdo, string loaiHinhDT, string TruongDT)
        {
            try
            {
                KetNoiCSDL.MoKetNoi();
                string sqlInsert = "insert into TrinhDoChuyenMon values (@ma, @nganh, @trinhdo, @loaihinhDT, @truongdt)";
                SqlCommand cmd = new SqlCommand(sqlInsert, KetNoiCSDL.KetNoi);

                cmd.Parameters.AddWithValue("ma", maNV);
                cmd.Parameters.AddWithValue("nganh", nganh);
                cmd.Parameters.AddWithValue("trinhdo", trinhdo);
                cmd.Parameters.AddWithValue("loaihinhDT", loaiHinhDT);
                cmd.Parameters.AddWithValue("truongdt", TruongDT);

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
        public DataTable LayThongTinnganhtheoMa(int maNV)
        {
            DataTable dtTrinhDoCM = new DataTable();
            KetNoiCSDL.MoKetNoi();
            string sqlSelect = "select nganh from trinhdochuyenmon inner join hoso on trinhdochuyenmon.manhanvien=hoso.manhanvien where hoso.manhanvien=@ma ";
            SqlDataAdapter daTrinhDoCM = new SqlDataAdapter(sqlSelect, KetNoiCSDL.KetNoi);
            daTrinhDoCM.SelectCommand.Parameters.AddWithValue("ma", maNV);
            daTrinhDoCM.Fill(dtTrinhDoCM);
            KetNoiCSDL.DongKetNoi();
            return dtTrinhDoCM;
        }

        public List<TrinhDoChuyenMonDTO> LayDSTDCMtheoMavaNganh(int maNV, string nganh)
        {
            List<TrinhDoChuyenMonDTO> ds = new List<TrinhDoChuyenMonDTO>();
            KetNoiCSDL.MoKetNoi();
            string sqlSelect = "select * from trinhdochuyenmon where manhanvien = @ma and nganh=@nganh";
            SqlCommand cmd = new SqlCommand(sqlSelect, KetNoiCSDL.KetNoi);
            cmd.Parameters.AddWithValue("ma", maNV);
            cmd.Parameters.AddWithValue("nganh", nganh);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                TrinhDoChuyenMonDTO td = new TrinhDoChuyenMonDTO(
                                         Convert.ToInt32(dr["manhanvien"]),
                                         dr["nganh"].ToString(),
                                        dr["trinhdo"].ToString(),
                                        dr["loaihinhdaotao"].ToString(),
                                        dr["truongdaotao"].ToString()
                                        );
                ds.Add(td);
            }
            KetNoiCSDL.DongKetNoi();
            return ds;
        }
        public List<TrinhDoChuyenMonDTO> LayDSTDCMtheoMa(int maNV)
        {
            List<TrinhDoChuyenMonDTO> ds = new List<TrinhDoChuyenMonDTO>();
            KetNoiCSDL.MoKetNoi();
            string sqlSelect = "select * from trinhdochuyenmon where manhanvien = @ma";
            SqlCommand cmd = new SqlCommand(sqlSelect, KetNoiCSDL.KetNoi);
            cmd.Parameters.AddWithValue("ma", maNV);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                TrinhDoChuyenMonDTO td = new TrinhDoChuyenMonDTO(
                                         Convert.ToInt32(dr["manhanvien"]),
                                         dr["nganh"].ToString(),
                                        dr["trinhdo"].ToString(),
                                        dr["loaihinhdaotao"].ToString(),
                                        dr["truongdaotao"].ToString()
                                        );
                ds.Add(td);
            }
            KetNoiCSDL.DongKetNoi();
            return ds;
        }
        public bool suaTDCM(int maNV, string nganh, string trinhdo, string loaiHinhDT, string TruongDT)
        {
            try
            {
                KetNoiCSDL.MoKetNoi();
                string sqlUpdate = "update TrinhDoChuyenMon set trinhdo=@trinhdo, loaihinhdaotao=@loaihinhDT, truongdaotao=@truongdt where manhanvien=@ma and nganh=@nganh";
                SqlCommand cmd = new SqlCommand(sqlUpdate, KetNoiCSDL.KetNoi);

                cmd.Parameters.AddWithValue("ma", maNV);
                cmd.Parameters.AddWithValue("nganh", nganh);
                cmd.Parameters.AddWithValue("trinhdo", trinhdo);
                cmd.Parameters.AddWithValue("loaihinhDT", loaiHinhDT);
                cmd.Parameters.AddWithValue("truongdt", TruongDT);

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
        public bool xoaTDCM(int maNV, string nganh)
        {
            try
            {
                KetNoiCSDL.MoKetNoi();
                string sqlDelete = "delete TrinhDoChuyenMon where manhanvien=@ma and nganh=@nganh";
                SqlCommand cmd = new SqlCommand(sqlDelete, KetNoiCSDL.KetNoi);

                cmd.Parameters.AddWithValue("ma", maNV);
                cmd.Parameters.AddWithValue("nganh", nganh);

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
        public List<TrinhDoChuyenMonDTO> LayDSTrinhDo()
        {
            List<TrinhDoChuyenMonDTO> ds = new List<TrinhDoChuyenMonDTO>();
            KetNoiCSDL.MoKetNoi();

            string sqlSelect = "select trinhdo from trinhdochuyenmon group by trinhdo ";
            SqlCommand cmd = new SqlCommand(sqlSelect, KetNoiCSDL.KetNoi);
            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                TrinhDoChuyenMonDTO td = new TrinhDoChuyenMonDTO(dr["trinhdo"].ToString());
                ds.Add(td);
            }

            KetNoiCSDL.DongKetNoi();
            return ds;
        }
    }
}
