using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyCuaHangDienThoai.DTO
{
    internal class KhuyenMaiDTO
    {
        private string maKM;
        private string moTa;
        private DateTime ngayBD;
        private DateTime ngayKT;

        public KhuyenMaiDTO(string maKM, string moTa, DateTime ngayBD, DateTime ngayKT)
        {
            this.maKM = maKM;
            this.moTa = moTa;
            this.ngayBD = ngayBD;
            this.ngayKT = ngayKT;
        }

        public string MaKM { get => maKM; set => maKM = value; }
        public string MoTa { get => moTa; set => moTa = value; }
        public DateTime NgayBD { get => ngayBD; set => ngayBD = value; }
        public DateTime NgayKT { get => ngayKT; set => ngayKT = value; }
    }
}
