using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlTypes;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyCuaHangDienThoai.GUI
{
    public partial class UserControlDashboard : UserControl
    {
        private System.Windows.Forms.Timer timerDateandTime;
        private string[] banners = { "banner1", "banner2", "banner3" };
        private int current_banner;
        public UserControlDashboard()
        {
            InitializeComponent();
            current_banner = 0;
        }

        private void UserControlDashboard_Load(object sender, EventArgs e)
        {
            this.timerDateandTime.Tick += new System.EventHandler(this.timerDateandTime_Tick);
            timerDateandTime.Interval = 3000;
            timerDateandTime.Start();
            // lấy tổng hóa đơn 
            int tongHD = new Database().Execute("Select * from HoaDon").Rows.Count;
            tongHoaDonLbl.Text = "" + tongHD;

            // lấy tổng sản phẩm
            int tongSP = new Database().Execute("Select * from sanpham").Rows.Count;
            tongSanPhamLbl.Text = "" + tongSP;

            // lấy tổng đơn nhập
            int tongDonNhap = new Database().Execute("Select * from DonNhap").Rows.Count;
            tongDonNhapLbl.Text = "" + tongDonNhap;

            // lấy tổng doanh thu
            long tongDoanhThu = Int64.Parse(new Database().Execute("Select sum(tongtien) " +
                "from Hoadon").Rows[0][0].ToString().Split('.')[0]);
            tongDoanhThuLbl.Text = tongDoanhThu.ToString("C", System.Globalization.CultureInfo.GetCultureInfo("vi-Vn"));

        }
        private void timerDateandTime_Tick(object sender, EventArgs e)
        {
            current_banner = (current_banner + 1) % banners.Length;

            // Update the background image of the PictureBox
            pictureBox1.BackgroundImage = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "\\..\\..\\img\\banner\\" + banners[current_banner] + ".png");

        }
    }
}
