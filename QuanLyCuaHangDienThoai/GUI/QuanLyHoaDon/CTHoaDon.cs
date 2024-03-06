using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyCuaHangDienThoai.GUI.QuanLyHoaDon
{
    public partial class CTHoaDon : Form
    {
        public int mahd;
        public CTHoaDon(int mahd)
        {
            InitializeComponent();
            this.mahd = mahd;
        }

        private void CTHoaDon_Load(object sender, EventArgs e)
        {
            HienThiThongTin();
            HienThiChiTiet();
        }

        private void HienThiThongTin()
        {
            DataTable data = new Database().Execute("select hd.*, nv.TENNV\r\nfrom hoadon as hd join nhanvien as nv on hd.MANV = nv.MANV \r\nwhere hd.mahd = " + this.mahd);
            lblMaHD.Text = data.Rows[0][0].ToString();
            lblKhachHang.Text = data.Rows[0][1].ToString();
            lblNv.Text = data.Rows[0][7].ToString();
            lblNgay.Text = data.Rows[0][3].ToString();
            if (data.Rows[0][4].ToString() != "")
            {
                lblDiaChi.Text = data.Rows[0][4].ToString();
            }
            else{
                lblDiaChi.Text = "Tại chỗ";
            }
           
            lblTong.Text = data.Rows[0][5].ToString();
        }
        private void HienThiChiTiet()
        {
            DataTable data = new Database().Execute("select sp.tensp, cthd.DONGIA, cthd.SOLUONG, cthd.DONGIA * cthd.SOLUONG\r\nfrom sanpham as sp join ct_hoadon as cthd on sp.masp = cthd.masp\r\njoin hoadon as hd on cthd.mahd = hd.mahd\r\nwhere hd.mahd = " + this.mahd);
            listView1.Columns.Add("Tên sản phẩm");
            listView1.Columns.Add("đơn giá");
            listView1.Columns.Add("Số lượng");
            listView1.Columns.Add("Thành tiền");

            for(int i = 0;i < data.Rows.Count;i++)
            {
                ListViewItem lvi = listView1.Items.Add(data.Rows[i][0].ToString());
                lvi.SubItems.Add(Int64.Parse(data.Rows[i][1].ToString().Split('.')[0]).ToString("C", System.Globalization.CultureInfo.GetCultureInfo("vi-Vn")));
                lvi.SubItems.Add(data.Rows[i][2].ToString());
                lvi.SubItems.Add(Int64.Parse(data.Rows[i][3].ToString().Split('.')[0]).ToString("C", System.Globalization.CultureInfo.GetCultureInfo("vi-Vn")));
            }

            for(int i =0; i<listView1.Columns.Count; i++)
            {
                listView1.Columns[i].Width = listView1.Width / listView1.Columns.Count;
            }
        }
    }
}
