using QuanLyCuaHangDienThoai.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyCuaHangDienThoai.GUI.QuanLySanPham
{
    public partial class ChiTietSanPham : Form
    {
        public ChiTietSanPham()
        {
            InitializeComponent();
        }
        public ChiTietSanPham(SanPhamDTO sp, string tenMau, string mamau)
        {
            InitializeComponent();

            this.StartPosition = FormStartPosition.CenterScreen;
            // hiển thị thông tin
            if (File.Exists(AppDomain.CurrentDomain.BaseDirectory + "\\..\\..\\img\\dienthoai\\" + sp.ImageURL + ".png"))
                HinhAnhPic.BackgroundImage = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "\\..\\..\\img\\dienthoai\\" + sp.ImageURL + ".png");
            else
                HinhAnhPic.BackgroundImage = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "\\..\\..\\img\\dienthoai\\notfound.png");
            txtTenSp.Text = "Tên sản phẩm :" + sp.TenSP;
            txtHang.Text = "Hãng : " + sp.Hang.Trim();

            txtGia.Text = "Giá : " + sp.DonGia.ToString("C", System.Globalization.CultureInfo.GetCultureInfo("vi-Vn"));
            txtCpu.Text = "Chip : " + sp.CPU.Trim();
            txtGpu.Text = "GPU : " + sp.GPU.Trim();
            txtRam.Text = "Ram : " + sp.RAM.Trim();
            txtBoNho.Text = "Bộ nhớ :" + sp.BoNho.Trim();
            txtManHinh.Text = "Màn hình : " + sp.ManHinh.Trim();
            txtHeDieuHanh.Text = "Hệ điều hành : " + sp.HeDieuHanh.Trim();
            txtNamSx.Text = "Năm sản xuất : " + sp.NamSX;
            txtThangBaoHanh.Text = "Thời gian bảo hàng : " + sp.ThoiGianBaoHanh + " tháng";
            txtPin.Text = "Pin : " + sp.Pin.Trim();
            txtPhuKien.Text = "Phụ kiện : " + sp.PhuKien.Trim();
            txtCamera.Text = "Camera : " + sp.Camera.Trim();


            tenMauLbl.Text = tenMau;
            mauBox.BackColor = (Color)new ColorConverter().ConvertFromString(mamau);
        }

    }
}

