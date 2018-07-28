using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using DTO;
using System.Data;

namespace DAL
{
    public class HoSoDAL
    {
        public int TongSoHoSo()
        {
            KetNoiCSDL.MoKetNoi();
            string sqlSelectHoSo = "select count(*) as 'tong' from hoso";
            SqlCommand cmd = new SqlCommand(sqlSelectHoSo, KetNoiCSDL.KetNoi);
            SqlDataReader dr = cmd.ExecuteReader();
            int sum = 0;
            while (dr.Read())
            {
                sum += Convert.ToInt32(dr["tong"]);
            }
            KetNoiCSDL.DongKetNoi();
            return sum;
        }
        public List<HoSoDTO> LayBangHoSo()
        {
            List<HoSoDTO> ds = new List<HoSoDTO>();
            KetNoiCSDL.MoKetNoi();
            string sqlSelect = "select * from hoso";
            SqlCommand cmd = new SqlCommand(sqlSelect, KetNoiCSDL.KetNoi);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                DateTime date2 = DateTime.Parse(dr["ngaytuyendung"].ToString());
                DateTime date3 = DateTime.Parse(dr["ngaysinh"].ToString());
                HoSoDTO hs = new HoSoDTO(
                                        Convert.ToInt32(dr["manhanvien"]),
                                        dr["hodem"].ToString(),
                                        dr["tendem"].ToString(),
                                        date3.ToString("dd/MM/yyyy"),
                                        dr["gioitinh"].ToString(),
                                        dr["sodienthoai"].ToString(),
                                        dr["email"].ToString(),
                                        date2.ToString("dd/MM/yyyy"),
                                        Convert.ToInt32(dr["maphongban"])
                                        );
                ds.Add(hs);
            }
            KetNoiCSDL.DongKetNoi();
            return ds;
        }
        public string LayTenTheoMaNhanVien(int maNV)
        {
            List<HoSoDTO> ds = new List<HoSoDTO>();
            KetNoiCSDL.MoKetNoi();
            string sqlSelect = "select hodem,tendem from hoso where manhanvien=@ma ";
            SqlCommand cmd = new SqlCommand(sqlSelect, KetNoiCSDL.KetNoi);
            cmd.Parameters.Add("ma", maNV);
            SqlDataReader dr = cmd.ExecuteReader();
            string ten = "";
            while (dr.Read())
            {
                ten = dr["hodem"].ToString() + " " + dr["tendem"].ToString();
            }
            KetNoiCSDL.DongKetNoi();
            string x = ten;
            return ten;
        }
        public DataTable LayThongTinHoSo()
        {
            DataTable dtHoSo = new DataTable();
            KetNoiCSDL.MoKetNoi();
            string sqlSelect = "select manhanvien, hodem,TenDem, ngaysinh, gioitinh, sodienthoai, email, ngaytuyendung, phongban.tenphongban from " +
                "phongban inner join hoso on phongban.maphongban=hoso.maphongban ";
            SqlDataAdapter daHoSo = new SqlDataAdapter(sqlSelect, KetNoiCSDL.KetNoi);
            daHoSo.Fill(dtHoSo);
            KetNoiCSDL.DongKetNoi();
            return dtHoSo;
        }
        public DataTable layThongTinHoSoTheoMaNV(int MaNV)
        {
            DataTable dtHoSo = new DataTable();
            KetNoiCSDL.MoKetNoi();
            string sqlSelect = "select manhanvien, hodem,TenDem, ngaysinh, gioitinh, sodienthoai, email, ngaytuyendung, phongban.tenphongban from " +
                "phongban inner join hoso on phongban.maphongban=hoso.maphongban where manhanvien=@ma";
            SqlDataAdapter daHoSo = new SqlDataAdapter(sqlSelect, KetNoiCSDL.KetNoi);
            daHoSo.SelectCommand.Parameters.AddWithValue("ma", MaNV);
            daHoSo.Fill(dtHoSo);
            KetNoiCSDL.DongKetNoi();
            return dtHoSo;
        }
        public bool themHoSo(string hoDem, string ten, string ngaySinh, string gioiTinh, string sdt, string email, string ngayTuyenDung, int maPhongBan)
        {
            try
            {
                KetNoiCSDL.MoKetNoi();
                string sqlInsert = "insert into HoSo values (@ho, @ten, @ns, @gt, @sdt, @email, @ntd, @mapb)";
                SqlCommand cmd = new SqlCommand(sqlInsert, KetNoiCSDL.KetNoi);

                cmd.Parameters.AddWithValue("ho", hoDem);
                cmd.Parameters.AddWithValue("ten", ten);
                cmd.Parameters.AddWithValue("ns", ngaySinh);
                cmd.Parameters.AddWithValue("gt", gioiTinh);
                cmd.Parameters.AddWithValue("sdt", sdt);
                cmd.Parameters.AddWithValue("email", email);
                cmd.Parameters.AddWithValue("ntd", ngayTuyenDung);
                cmd.Parameters.AddWithValue("mapb", maPhongBan);

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
        public HoSoDTO LayNhanVienTheoMa(int maNhanVien)
        {
            HoSoDTO hs = null;
            KetNoiCSDL.MoKetNoi();
            string sqlSelect = "Select * from hoso where manhanvien=@ma";
            SqlCommand cmd = new SqlCommand(sqlSelect, KetNoiCSDL.KetNoi);
            cmd.Parameters.AddWithValue("ma", maNhanVien);

            SqlDataReader dr = cmd.ExecuteReader();

            dr.Read();

            hs = new HoSoDTO(
                            Convert.ToInt32(dr["manhanvien"]),
                            dr["hodem"].ToString(),
                            dr["tendem"].ToString(),
                            dr["ngaysinh"].ToString(),
                            dr["gioitinh"].ToString(),
                            dr["sodienthoai"].ToString(),
                            dr["email"].ToString(),
                            dr["ngaytuyendung"].ToString(),
                            Convert.ToInt32(dr["maphongban"])
                            );
            KetNoiCSDL.DongKetNoi();
            return hs;
        }
        public List<HoSoDTO> LayDSHoSoTheoMaNV(int maNV)
        {
            List<HoSoDTO> ds = new List<HoSoDTO>();
            KetNoiCSDL.MoKetNoi();
            string sqlSelect = "select * from HoSo where manhanvien = @ma";
            SqlCommand cmd = new SqlCommand(sqlSelect, KetNoiCSDL.KetNoi);
            cmd.Parameters.AddWithValue("ma", maNV);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                DateTime date2 = DateTime.Parse(dr["ngaysinh"].ToString());
                DateTime date3 = DateTime.Parse(dr["ngaytuyendung"].ToString());
                HoSoDTO hs = new HoSoDTO(
                                         Convert.ToInt32(dr["manhanvien"]),
                                         dr["hodem"].ToString(),
                                        dr["tendem"].ToString(),
                                        date2.ToString("dd/MM/yyyy"),
                                        dr["gioitinh"].ToString(),
                                        dr["sodienthoai"].ToString(),
                                        dr["email"].ToString(),
                                        date3.ToString("dd/MM/yyyy"),
                                        Convert.ToInt32(dr["maphongban"])
                                        );
                ds.Add(hs);
            }
            KetNoiCSDL.DongKetNoi();
            return ds;
        }
        public bool suaHoSo(string manv, string hoDem, string ten, string ngaySinh, string gioiTinh, string sdt, string email, string ngayTuyenDung, int maPhongBan)
        {
            try
            {
                KetNoiCSDL.MoKetNoi();
                string sqlUpdate = "update HoSo set hodem =@ho, tendem= @ten, ngaysinh=@ns, gioitinh=@gt, sodienthoai=@sdt,email=@email, ngaytuyendung=@ntd, maphongban=@mapb where manhanvien=@ma";
                SqlCommand cmd = new SqlCommand(sqlUpdate, KetNoiCSDL.KetNoi);
                cmd.Parameters.AddWithValue("ma", manv);
                cmd.Parameters.AddWithValue("ho", hoDem);
                cmd.Parameters.AddWithValue("ten", ten);
                cmd.Parameters.AddWithValue("ns", ngaySinh);
                cmd.Parameters.AddWithValue("gt", gioiTinh);
                cmd.Parameters.AddWithValue("sdt", sdt);
                cmd.Parameters.AddWithValue("email", email);
                cmd.Parameters.AddWithValue("ntd", ngayTuyenDung);
                cmd.Parameters.AddWithValue("mapb", maPhongBan);

                cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
            finally
            {
                KetNoiCSDL.DongKetNoi();
            }
        }
        public bool xoaHoSo(string manv)
        {

            try
            {
                KetNoiCSDL.MoKetNoi();
                string sqlDelete = "delete from HoSo where manhanvien=@ma";
                SqlCommand cmd = new SqlCommand(sqlDelete, KetNoiCSDL.KetNoi);
                cmd.Parameters.AddWithValue("ma", manv);
                cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
            finally
            {
                KetNoiCSDL.DongKetNoi();
            }

        }
        public int LayMaHoSoMoiThem()
        {
            int ma = -1;
            KetNoiCSDL.MoKetNoi();

            string sqlSelect = "select max(manhanvien) as 'ma' from hoso";
            SqlCommand cmd = new SqlCommand(sqlSelect, KetNoiCSDL.KetNoi);
            SqlDataReader dr = cmd.ExecuteReader();
            dr.Read();
            ma = Convert.ToInt32(dr["ma"]);
            KetNoiCSDL.DongKetNoi();
            return ma;
        }

    }
}
