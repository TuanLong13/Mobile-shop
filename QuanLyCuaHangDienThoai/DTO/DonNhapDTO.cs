using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyCuaHangDienThoai.DTO
{
    internal class DonNhapDTO
    {
        private int maDN;
        private string maNCC;
        private string maNV;
        private double tongTien;
        private DateTime ngayNhap;

        public DonNhapDTO(int maDN, string maNCC, string maNV, double tongTien, DateTime ngayNhap)
        {
            this.maDN = maDN;
            this.maNCC = maNCC;
            this.maNV = maNV;
            this.tongTien = tongTien;
            this.ngayNhap = ngayNhap;
        }

        public int MaDN { get => maDN; set => maDN = value; }
        public string MaNCC { get => maNCC; set => maNCC = value; }
        public string MaNV { get => maNV; set => maNV = value; }
        public double TongTien { get => tongTien; set => tongTien = value; }
        public DateTime NgayNhap { get => ngayNhap; set => ngayNhap = value; }
    }
}
