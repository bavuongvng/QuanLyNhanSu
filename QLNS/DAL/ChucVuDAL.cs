using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using DTO;

namespace DAL
{
    public class ChucVuDAL
    {
        public List<ChucVuDTO> LayBangChucVu()
        {
            List<ChucVuDTO> ds = new List<ChucVuDTO>();
            KetNoiCSDL.MoKetNoi();
            string sqlSelect = "select * from chucvu";
            SqlCommand cmd = new SqlCommand(sqlSelect, KetNoiCSDL.KetNoi);
            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                ChucVuDTO cv = new ChucVuDTO(
                                            Convert.ToInt32(dr["machucvu"]),
                                            dr["tenchucvu"].ToString(),
                                            float.Parse(dr["HeSoPhuCap"].ToString())
                                            );
                ds.Add(cv);
            }

            KetNoiCSDL.DongKetNoi();
            return ds;
        }
        public List<ChucVuDTO> LayTenChucVuTheoMaNhanVien(int manv)
        {
            List<ChucVuDTO> ds = new List<ChucVuDTO>();
            KetNoiCSDL.MoKetNoi();
            string sqlSelect = "select chucvu.machucvu as 'machucvu',tenchucvu from nhanvien_chucvu " +
                "inner join chucvu on nhanvien_chucvu.machucvu=chucvu.machucvu " +
                "where nhanvien_chucvu.manhanvien=@ma " +
                "group by chucvu.machucvu,TenChucVu";
            SqlCommand cmd = new SqlCommand(sqlSelect, KetNoiCSDL.KetNoi);
            cmd.Parameters.Add("ma", manv);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                ChucVuDTO nvcv = new ChucVuDTO(
                                            Convert.ToInt32(dr["machucvu"]),
                                            dr["tenchucvu"].ToString()
                                            );
                ds.Add(nvcv);
            }
            KetNoiCSDL.DongKetNoi();

            return ds;
        }
        public bool XoaChucVu(int maCV)
        {
            try
            {
                KetNoiCSDL.MoKetNoi();
                string sqlDelete = "delete from ChucVu where MaChucVu=@ma";
                SqlCommand cmd = new SqlCommand(sqlDelete, KetNoiCSDL.KetNoi);
                cmd.Parameters.AddWithValue("ma", maCV);
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
        public List<ChucVuDTO> LayDSChucVuTheoMaCV(int maCV)
        {
            List<ChucVuDTO> ds = new List<ChucVuDTO>();
            KetNoiCSDL.MoKetNoi();
            string sqlselect = "select *from ChucVu where MaChucVu=@ma";
            SqlCommand cmd = new SqlCommand(sqlselect, KetNoiCSDL.KetNoi);
            cmd.Parameters.Add("ma", maCV);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                ChucVuDTO cv = new ChucVuDTO(
                    Convert.ToInt32(dr["MaChucVu"]),
                    dr["TenChucVu"].ToString(),
                    float.Parse(dr["HeSoPhuCap"].ToString())
                        );
                ds.Add(cv);
            }
            KetNoiCSDL.DongKetNoi();
            return ds;

        }
        public bool ThemChucVu(string tenChucVu, float heSoPhuCap)
        {
            try
            {
                KetNoiCSDL.MoKetNoi();
                string sqlInsert = "Insert into ChucVu values(@tenCV,@heSo)";
                SqlCommand cmd = new SqlCommand(sqlInsert, KetNoiCSDL.KetNoi);
                cmd.Parameters.AddWithValue("tenCV", tenChucVu);
                cmd.Parameters.AddWithValue("heSo", heSoPhuCap);
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
        public bool SuaChucVu(int maCV, string tenCV, float heSoPhuCap)
        {
            try
            {
                KetNoiCSDL.MoKetNoi();
                string sqlUpdate = "update ChucVu set TenChucVu=@ten,HeSoPhuCap=@heSo where MaChucVu=@ma";
                SqlCommand cmd = new SqlCommand(sqlUpdate, KetNoiCSDL.KetNoi);
                cmd.Parameters.AddWithValue("ma", maCV);
                cmd.Parameters.AddWithValue("ten", tenCV);
                cmd.Parameters.AddWithValue("heSo", heSoPhuCap);
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
