using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using DTO;
using System.Data.SqlClient;
namespace DAL
{
    public class PhongBanDAL
    {
        public int TongSoPhongBan()
        {
            KetNoiCSDL.MoKetNoi();
            string sqlSelectPhongBan = "select count(*) as 'tong' from phongban";

            SqlCommand cmd = new SqlCommand(sqlSelectPhongBan, KetNoiCSDL.KetNoi);
            SqlDataReader dr = cmd.ExecuteReader();
            int sum = 0;
            while (dr.Read())
            {
                sum += Convert.ToInt32(dr["tong"]);
            }
            KetNoiCSDL.DongKetNoi();
            return sum;
        }
        public List<PhongBanDTO> LayPhongBan()
        {
            List<PhongBanDTO> ds = new List<PhongBanDTO>();
            KetNoiCSDL.MoKetNoi();
            string sqlSelect = "select * from phongban";
            SqlCommand cmd = new SqlCommand(sqlSelect, KetNoiCSDL.KetNoi);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                DateTime dt = DateTime.Parse(dr["ngaylap"].ToString());
                PhongBanDTO pb = new PhongBanDTO(Convert.ToInt32(dr["maphongban"]), dr["tenphongban"].ToString(), dt.ToString("dd/MM/yyyy"));
                ds.Add(pb);

            }
            KetNoiCSDL.DongKetNoi();
            return ds;

        }
        public bool XoaPhongBan(int maPB)
        {
            try
            {
                KetNoiCSDL.MoKetNoi();
                string sqlDelete = "delete from phongban where maphongban=@mapb";
                SqlCommand cmd = new SqlCommand(sqlDelete, KetNoiCSDL.KetNoi);
                cmd.Parameters.Add("mapb", maPB);
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
        public List<PhongBanDTO> LayPhongBanTheoMaPB(int mapb)
        {
            List<PhongBanDTO> ds = new List<PhongBanDTO>();
            KetNoiCSDL.MoKetNoi();
            string sqlSelect = "select * from phongban where maphongban = @ma ";
            SqlCommand cmd = new SqlCommand(sqlSelect, KetNoiCSDL.KetNoi);
            cmd.Parameters.Add("ma", mapb);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                DateTime dt = DateTime.Parse(dr["ngaylap"].ToString());
                PhongBanDTO pb = new PhongBanDTO(Convert.ToInt32(dr["maphongban"]), dr["tenphongban"].ToString(), dt.ToString("dd/MM/yyyy"));
                ds.Add(pb);
            }
            KetNoiCSDL.DongKetNoi();
            return ds;
        }
        public bool ThemPhongBan(string tenPhongBan, string ngayLap)
        {
            try
            {
                KetNoiCSDL.MoKetNoi();
                string sqlInsert = "insert into PhongBan values(@tenPB,@nl)";
                SqlCommand cmd = new SqlCommand(sqlInsert, KetNoiCSDL.KetNoi);
                cmd.Parameters.Add("tenPB", tenPhongBan);
                cmd.Parameters.Add("nl", ngayLap);

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
        public bool SuaPhongBan(int maPB, string tenPB, string ngayLap)
        {
            try
            {
                KetNoiCSDL.MoKetNoi();
                string sqlUpdate = "update PhongBan set tenphongban = @ten, ngaylap = @nl where maphongban=@maPB";
                SqlCommand cmd = new SqlCommand(sqlUpdate, KetNoiCSDL.KetNoi);
                cmd.Parameters.AddWithValue("maPB", maPB);
                cmd.Parameters.AddWithValue("ten", tenPB);
                cmd.Parameters.AddWithValue("nl", ngayLap);
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
        public PhongBanDTO LayPhongBanTheoMaNV(int manv)
        {
            PhongBanDTO pb = null;
            KetNoiCSDL.MoKetNoi();

            string sqlSelect = "select phongban.maphongban,tenphongban,ngaylap from hoso " +
                "inner join phongban on hoso.maphongban=phongban.maphongban " +
                "where manhanvien=@ma";
            SqlCommand cmd = new SqlCommand(sqlSelect, KetNoiCSDL.KetNoi);
            cmd.Parameters.Add("ma", manv);
            SqlDataReader dr = cmd.ExecuteReader();
            dr.Read();
            pb = new PhongBanDTO(Convert.ToInt32(dr["maphongban"]),
                                dr["tenphongban"].ToString(),
                                dr["ngaylap"].ToString());
            KetNoiCSDL.DongKetNoi();
            return pb;
        }
    }
}
