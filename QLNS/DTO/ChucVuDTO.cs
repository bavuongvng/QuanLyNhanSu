using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class ChucVuDTO
    {
        private int maChucVu;
        private string tenChucVu;
        private float heSoPhuCap;
        public ChucVuDTO() { }

        public ChucVuDTO(int maChucVu, string tenChucVu)
        {
            this.maChucVu = maChucVu;
            this.tenChucVu = tenChucVu;
        }

        public ChucVuDTO(int maChucVu, string tenChucVu, float heSoPhuCap)
        {
            this.maChucVu = maChucVu;
            this.tenChucVu = tenChucVu;
            this.heSoPhuCap = heSoPhuCap;
        }

        public int MaChucVu { get => maChucVu; set => maChucVu = value; }
        public string TenChucVu { get => tenChucVu; set => tenChucVu = value; }
        public float HeSoPhuCap { get => heSoPhuCap; set => heSoPhuCap = value; }
    }
}
