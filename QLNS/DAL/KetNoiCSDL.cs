using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Configuration;

namespace DAL
{
    public class KetNoiCSDL
    {
        private static SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["qlns"].ToString());
        public static SqlConnection KetNoi
        {
            get { return KetNoiCSDL.conn; }
        }
        public static void MoKetNoi()
        {
            conn.Open();
        }
        public static void DongKetNoi()
        {
            conn.Close();
        }
    }
}
