using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyCuaHangDienThoai.DTO
{
    internal class KhachHangDTO
    {
        private string maKH;
        private string tenKH;
        private string sdt;

        public KhachHangDTO(string maKH, string tenKH, string sdt)
        {
            this.maKH = maKH;
            this.tenKH = tenKH;
            this.sdt = sdt;
        }

        public string MaKH { get => maKH; set => maKH = value; }
        public string TenKH { get => tenKH; set => tenKH = value; }
        public string Sdt { get => sdt; set => sdt = value; }
    }
}
