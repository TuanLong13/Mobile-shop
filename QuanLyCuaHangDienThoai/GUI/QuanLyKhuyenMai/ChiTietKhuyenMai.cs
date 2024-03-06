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

namespace QuanLyCuaHangDienThoai.GUI.QuanLyKhuyenMai
{
    public partial class ChiTietKhuyenMai : Form
    {
        private  int makm;
        public ChiTietKhuyenMai(int makm)
        {
            this.makm = makm;
            InitializeComponent();
        }

        private void ChiTietKhuyenMai_Load(object sender, EventArgs e)
        {
            listView1.Columns.Add("Hình ảnh");
            listView1.Columns.Add("Tên sản phẩm");
            listView1.Columns.Add("Giá");
            listView1.Columns.Add("Phần trăm giảm giá");
            listView1.Columns.Add("Giá khuyến mãi");
            for(int i = 0; i<listView1.Columns.Count; i++)
            {
                listView1.Columns[i].Width = listView1.Width / 5;
            }
            HienThiBangKhuyenMai();
            HienThiThongTinKhuyenMai();
        }
        private void HienThiThongTinKhuyenMai()
        {
            DataTable data = new Database().Execute("select * from khuyenmai where makm ="+this.makm);
            if (data.Rows.Count > 0)
            {
                motaLbl.Text = "Chi tiết đợt khuyến mãi :" + data.Rows[0][0].ToString();
                ngayBdLbl.Text = "Ngày bắt đầu :" + data.Rows[0][1].ToString();
                ngayKtLbl.Text = "Ngày kết thúc :" + data.Rows[0][2].ToString();
            }
           

        }
        private void HienThiBangKhuyenMai()
        {
            DataTable data = new Database().Execute("select  image,tensp,dongia,phantramgiam = ctkm.PHANTRAM ,giakhuyenmai = dongia * (100 - ctkm.PHANTRAM)/100" +
                "\r\nfrom sanpham as sp join CT_KHUYENMAI as ctkm on sp.MASP = ctkm.MASP" +
                "\r\njoin khuyenmai as km on km.MAKM = ctkm.MAKM" +
                "\r\nwhere km.makm ="+this.makm);
            ImageList imageList = new ImageList();
            imageList.ImageSize = new Size(32, 32);
            listView1.SmallImageList = imageList;
            for (int i = 0; i< data.Rows.Count; i++)
            {
                ListViewItem lvi = new ListViewItem();
                if (File.Exists(AppDomain.CurrentDomain.BaseDirectory + "\\..\\..\\img\\dienthoai\\" + data.Rows[i][0].ToString() + ".png"))
                {
                    imageList.Images.Add(Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "\\..\\..\\img\\dienthoai\\" + data.Rows[i][0].ToString() + ".png"));
                }
                else
                {
                    imageList.Images.Add(Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "\\..\\..\\img\\dienthoai\\notfound.png"));
                }
                lvi.ImageIndex = imageList.Images.Count - 1;
                lvi.SubItems.Add(data.Rows[i][1].ToString());
                lvi.SubItems.Add(Int64.Parse(data.Rows[i][2].ToString().Split('.')[0]).ToString("C", System.Globalization.CultureInfo.GetCultureInfo("vi-Vn")));
                lvi.SubItems.Add(data.Rows[i][3].ToString()+"%");
                lvi.SubItems.Add(Int64.Parse(data.Rows[i][4].ToString().Split('.')[0]).ToString("C", System.Globalization.CultureInfo.GetCultureInfo("vi-Vn")));
                listView1.Items.Add(lvi);
            }
        }
    }
}
