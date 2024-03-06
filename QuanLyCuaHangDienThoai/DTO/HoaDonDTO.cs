using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyCuaHangDienThoai.DTO
{
    internal class HoaDonDTO
    {
        private string maHD;
        private string maKH;
        private string maNV;
        private DateTime ngayLap;
        private string diaChiGiao;
        private int tongTien;
        private string trangThai;

        public HoaDonDTO(string maHD, string maKH, string maNV, DateTime ngayLap, string diaChiGiao, int tongTien, string trangThai)
        {
            this.maHD = maHD;
            this.maKH = maKH;
            this.maNV = maNV;
            this.ngayLap = ngayLap;
            this.diaChiGiao = diaChiGiao;
            this.tongTien = tongTien;
            this.trangThai = trangThai;
        }

        public string MaHD { get => maHD; set => maHD = value; }
        public string MaKH { get => maKH; set => maKH = value; }
        public string MaNV { get => maNV; set => maNV = value; }
        public DateTime NgayLap { get => ngayLap; set => ngayLap = value; }
        public string DiaChiGiao { get => diaChiGiao; set => diaChiGiao = value; }
        public int TongTien { get => tongTien; set => tongTien = value; }
        public string TrangThai { get => trangThai; set => trangThai = value; }
    }
}
