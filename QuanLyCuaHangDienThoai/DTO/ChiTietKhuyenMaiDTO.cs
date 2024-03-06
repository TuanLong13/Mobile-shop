using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyCuaHangDienThoai.DTO
{
    internal class ChiTietKhuyenMaiDTO
    {
        private int maKM;
        private int maSP;
        private int phanTram;

        public ChiTietKhuyenMaiDTO(int maKM, int maSP, int phanTram)
        {
            this.maKM = maKM;
            this.maSP = maSP;
            this.phanTram = phanTram;
        }

        public int MaKM { get => maKM; set => maKM = value; }
        public int MaSP { get => maSP; set => maSP = value; }
        public int PhanTram { get => phanTram; set => phanTram = value; }
    }
}
