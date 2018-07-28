using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class PhongBanDTO
    {
        private int maPhongBan;
        private string tenPhongBan;
        private string ngayThanhLap;
        public PhongBanDTO() { }
        public PhongBanDTO(int maPhongBan, string tenPhongBan, string ngayThanhLap)
        {
            this.maPhongBan = maPhongBan;
            this.tenPhongBan = tenPhongBan;
            this.ngayThanhLap = ngayThanhLap;
        }

        public int MaPhongBan { get => maPhongBan; set => maPhongBan = value; }
        public string TenPhongBan { get => tenPhongBan; set => tenPhongBan = value; }
        public string NgayThanhLap { get => ngayThanhLap; set => ngayThanhLap = value; }
    }
}
