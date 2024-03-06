using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QuanLyCuaHangDienThoai.BUS;
using QuanLyCuaHangDienThoai.DTO;

namespace QuanLyCuaHangDienThoai.GUI
{
    public partial class CTDonNhapGUI : Form
    {
        CTDonNhapBUS busDN = new CTDonNhapBUS();
        ErrorProvider errSonguyen = new ErrorProvider();
        private int id;
        private string tencc, tennv;
        private double total = 0;
        //public delegate void SendTotalDelegate(double total);
        //public event SendTotalDelegate SendTotal;
        public CTDonNhapGUI(int index, string ncc, string nv)
        {
            InitializeComponent();
            id = index;
            tencc = ncc;
            tennv = nv;
        }
        private void CTDonNhap_GUI_Load(object sender, EventArgs e)
        {
            dgvCT.DataSource = busDN.LayDSChiTietDonNhap(id);
            lblMadn.Text = Convert.ToString(id);
            lblNcc.Text = tencc;
            lblNv.Text = tennv;
            lblTotal.Text = dgvCT.Rows.Count.ToString();
            //cbSP.DisplayMember = "masp";
            //cbSP.DataSource = busDN.LayDataCB("masp", "SanPham");
            //txtDongia.Clear();
            total = 0;
            for (int i = 0; i < dgvCT.Rows.Count; ++i)
            {
                total += (Convert.ToDouble(dgvCT.Rows[i].Cells[1].Value) * Convert.ToDouble(dgvCT.Rows[i].Cells[2].Value));
            }
            lblTong.Text = Convert.ToString(total);

            HienThiChiTiet();
        }

        private void HienThiChiTiet()
        {
            DataTable data = new Database().Execute("select N'tên sản phẩm' = sp.TENSP, N'số lượng' = ctdn.SOLUONG, N'đơn giá' = ctdn.DONGIA, N'thành tiền' =ctdn.SOLUONG *  ctdn.DONGIA " +
                "\r\nfrom sanpham as sp join ct_donnhap as ctdn on sp.MASP = ctdn.MASP" +
                "\r\njoin DONNHAP as dn on ctdn.MADN = dn.MADN" +
                "\r\nwhere dn.madn = " + this.id);
            dgvCT.DataSource = data;
            lblTotal.Text = data.Rows.Count+"";
        }
    }
}
