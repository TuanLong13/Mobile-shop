using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace QuanLyCuaHangDienThoai.DTO
{
    public class SanPhamDTO
    {
        private int maSP;
        private string tenSP;
        private string imageURL;
        private int mau;
        private string hang;
        private long donGia;
        private int soLuong;
        private string cpu;
        private string gpu;
        private string ram;
        private string boNho;
        private string heDieuHanh;
        private string manHinh;
        private int namSX;
        private int thoiGianBaoHanh;
        private string pin;
        private string phuKien;
        private string camera;

        public SanPhamDTO(int maSP, string tenSP, string imageURL, string hang, long donGia, int soLuong, string cpu, string gpu, string ram, string boNho, string heDieuHanh, string manHinh, int namSX, int thoiGianBaoHanh, string pin, string phuKien, string camera)
        {
            this.maSP = maSP;
            this.tenSP = tenSP;
            this.imageURL = imageURL;
            this.hang = hang;
            this.donGia = donGia;
            this.soLuong = soLuong;
            this.cpu = cpu;
            this.gpu = gpu;
            this.ram = ram;
            this.boNho = boNho;
            this.heDieuHanh = heDieuHanh;
            this.namSX = namSX;
            this.thoiGianBaoHanh = thoiGianBaoHanh;
            this.pin = pin;
            this.phuKien = phuKien;
            this.camera = camera;
            this.manHinh = manHinh;
        }
        public SanPhamDTO(int maSP, string tenSP, string imageURL, int id_mau, string hang, long donGia, int soLuong, string cpu, string gpu, string ram, string boNho, string heDieuHanh, string manHinh, int namSX, int thoiGianBaoHanh, string pin, string phuKien, string camera)
        {
            this.maSP = maSP;
            this.tenSP = tenSP;
            this.imageURL = imageURL;
            this.Mau = id_mau;
            this.hang = hang;
            this.donGia = donGia;
            this.soLuong = soLuong;
            this.cpu = cpu;
            this.gpu = gpu;
            this.ram = ram;
            this.boNho = boNho;
            this.heDieuHanh = heDieuHanh;
            this.namSX = namSX;
            this.thoiGianBaoHanh = thoiGianBaoHanh;
            this.pin = pin;
            this.phuKien = phuKien;
            this.camera = camera;
            this.manHinh = manHinh;
        }

        public int MaSP { get => maSP; set => maSP = value; }
        public string TenSP { get => tenSP; set => tenSP = value; }
        public string ImageURL { get => imageURL; set => imageURL = value; }
        public int Mau { get => mau; set => mau = value; }
        public string Hang { get => hang; set => hang = value; }
        public long DonGia { get => donGia; set => donGia = value; }
        public int SoLuong { get => soLuong; set => soLuong = value; }
        public string CPU { get => cpu; set => cpu = value; }
        public string GPU { get => gpu; set => gpu = value; }
        public string RAM { get => ram; set => ram = value; }
        public string BoNho { get => boNho; set => boNho = value; }
        public string ManHinh { get => manHinh; set => manHinh = value; }
        public string HeDieuHanh { get => heDieuHanh; set => heDieuHanh = value; }
        public int NamSX { get => namSX; set => namSX = value; }
        public int ThoiGianBaoHanh { get => thoiGianBaoHanh; set => thoiGianBaoHanh = value; }
        public string Pin { get => pin; set => pin = value; }
        public string PhuKien { get => phuKien; set => phuKien = value; }
        public string Camera { get => camera; set => camera = value; }

        public string insertString()
        {
            return String.Format("insert into SanPham values(N'{0}',N'{1}',{2},N'{3}',{4},{5},N'{6}',N'{7}',N'{8}',N'{9}',N'{10}',N'{11}',{12},{13},N'{14}',N'{15}',N'{16}')",
                TenSP, ImageURL, Mau, Hang, 0, 0, CPU, GPU, RAM, BoNho, ManHinh, HeDieuHanh, NamSX, ThoiGianBaoHanh, Pin, PhuKien, Camera);
        }

        public string updateString()
        {
            return String.Format("Update SanPham " +
                "set " +
                "tensp = N'{0}', IMAGE = N'{1}',ID_MAU = {2}, hang=N'{3}',  cpu=N'{4}', gpu=N'{5}', ram=N'{6}', bonho=N'{7}', manhinh=N'{8}', os=N'{9}', namsx={10}, thoigianbaohanh={11}, pin=N'{12}', phukien=N'{13}', camera=N'{14}' " +
                "where masp = {15}", TenSP, ImageURL, Mau, Hang, CPU, GPU, RAM, BoNho, ManHinh, HeDieuHanh, NamSX, ThoiGianBaoHanh, Pin, PhuKien, Camera, MaSP);
        }

        public string deleteString()
        {
            return "Delete Sanpham where masp = " + maSP;
        }
    }
}
