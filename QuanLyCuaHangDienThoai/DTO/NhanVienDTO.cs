using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyCuaHangDienThoai.DTO
{
    internal class NhanVienDTO
    {
        private string maNV;
        private string tenNV;
        private string sdt;
        private string email;
        private string diaChi;
        private string chucVu;

        public NhanVienDTO(string maNV, string tenNV, string sdt, string email, string diaChi, string chucVu)
        {
            this.maNV = maNV;
            this.tenNV = tenNV;
            this.sdt = sdt;
            this.email = email;
            this.diaChi = diaChi;
            this.chucVu = chucVu;
        }

        public string MaNV { get => maNV; set => maNV = value; }
        public string TenNV { get => tenNV; set => tenNV = value; }
        public string Sdt { get => sdt; set => sdt = value; }
        public string Email { get => email; set => email = value; }
        public string DiaChi { get => diaChi; set => diaChi = value; }
        public string ChucVu { get => chucVu; set => chucVu = value; }
    }
}
