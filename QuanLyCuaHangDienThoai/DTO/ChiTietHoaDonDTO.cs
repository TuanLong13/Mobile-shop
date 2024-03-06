using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyCuaHangDienThoai.DTO
{
    internal class ChiTietHoaDonDTO
    {
        private string maHD;
        private string maSP;
        private long donGia;
        private int soLuong;

        public ChiTietHoaDonDTO(string maHD, string maSP, long donGia, int soLuong)
        {
            this.maHD = maHD;
            this.maSP = maSP;
            this.donGia = donGia;
            this.soLuong = soLuong;
        }

        public string MaHD { get => maHD; set => maHD = value; }
        public string MaSP { get => maSP; set => maSP = value; }
        public long DonGia { get => donGia; set => donGia = value; }
        public int SoLuong { get => soLuong; set => soLuong = value; }
    }
}
