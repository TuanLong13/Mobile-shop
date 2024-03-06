using DocumentFormat.OpenXml.Presentation;
using QuanLyCuaHangDienThoai.BUS;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyCuaHangDienThoai.GUI.QuanLyKhuyenMai
{
    public partial class Them_Sua_KM : UserControl
    {
        public KhuyenMaiBUS km_bus;
        QuanLyKhuyenMaiFrm qlkm_form;
        bool capnhat;
        public Them_Sua_KM()
        {
            InitializeComponent();
        }
        public Them_Sua_KM(QuanLyKhuyenMaiFrm qlkm_form,KhuyenMaiBUS km_bus, bool capnhat = false)
        {
            this.qlkm_form = qlkm_form;
            this.km_bus = km_bus;
            this.capnhat = capnhat;

            InitializeComponent();
            this.dateTimePicker1.CustomFormat = "dd/MM/yyyy";
            this.dateTimePicker2.CustomFormat = "dd/MM/yyyy";
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            hienThi2Bang();
            if (this.capnhat)
            {
                this.moTaTxt.Text = km_bus.khuyenMaiChon[1].ToString();
                this.dateTimePicker1.Value = DateTime.Parse(km_bus.khuyenMaiChon[2].ToString());
                this.dateTimePicker2.Value = DateTime.Parse(km_bus.khuyenMaiChon[3].ToString());
                this.km_bus.layDanhSachSanPham(this.dateTimePicker1.Value, this.dateTimePicker2.Value, Int32.Parse(this.km_bus.khuyenMaiChon[0].ToString()));
                this.km_bus.layDanhSachChiTietKhuyenMai();
                hienThiNoiDung2Bang();
               
            }
            else
            {
                loadSanPhamCoTheKhuyenMaiTheoNgay(DateTime.Now, DateTime.Now);
                hienThiNoiDung2Bang();
            }
            this.dateTimePicker2.ValueChanged += new System.EventHandler(this.dateTimePicker2_ValueChanged);
            this.dateTimePicker1.ValueChanged += new System.EventHandler(this.dateTimePicker1_ValueChanged);
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        public void hienThi2Bang()
        {
            sanpham_listview.Clear();

            sanpham_listview.Columns.Add("Tên sản phẩm");
            sanpham_listview.Columns.Add("Đơn giá");
            sanpham_listview.Columns.Add("Số lượng");

            for (int i = 0; i < sanpham_listview.Columns.Count; i++)
            {
                sanpham_listview.Columns[i].Width = sanpham_listview.Width / sanpham_listview.Columns.Count;
            }

            ctkm_listview.Clear();

            ctkm_listview.Columns.Add("Tên sản phẩm");
            ctkm_listview.Columns.Add("Đơn giá");
            ctkm_listview.Columns.Add("Phần trăm giảm");
            ctkm_listview.Columns.Add("Giá khuyến mãi");

            for (int i = 0; i < ctkm_listview.Columns.Count; i++)
            {
                ctkm_listview.Columns[i].Width = ctkm_listview.Width / ctkm_listview.Columns.Count;
            }
        }
        public void hienThiNoiDung2Bang()
        {
            sanpham_listview.Items.Clear();
            ctkm_listview.Items.Clear();
            for (int i = 0; i < km_bus.DsSanPham.Rows.Count; i++)
            {
                // kiểm tra có trong DsChiTietKhuyenMai
                if (km_bus.DsChiTietKhuyenMai.ContainsKey(Int32.Parse(km_bus.DsSanPham.Rows[i][0].ToString())))  // Có
                {
                    int phanTram = km_bus.DsChiTietKhuyenMai[Int32.Parse(km_bus.DsSanPham.Rows[i][0].ToString())];
                    ListViewItem lvi = ctkm_listview.Items.Add(km_bus.DsSanPham.Rows[i][1].ToString());
                    lvi.SubItems.Add(long.Parse(km_bus.DsSanPham.Rows[i][2].ToString().Split('.')[0]).ToString());
                    lvi.SubItems.Add(phanTram + "%");
                    double giaDaGiam = ((100 - phanTram) * 1.0 / 100) * Int64.Parse(km_bus.DsSanPham.Rows[i][2].ToString().Split('.')[0]);
                    /*MessageBox.Show(giaDaGiam+"");*/

                    lvi.SubItems.Add(giaDaGiam.ToString("C", System.Globalization.CultureInfo.GetCultureInfo("vi-Vn")));

                    lvi.Tag = km_bus.DsSanPham.Rows[i][0].ToString(); // lưu lại masp
                }
                else // Không
                {
                    ListViewItem lvi = sanpham_listview.Items.Add(km_bus.DsSanPham.Rows[i][1].ToString());
                    lvi.SubItems.Add(long.Parse(km_bus.DsSanPham.Rows[i][2].ToString().Split('.')[0]).ToString("C", System.Globalization.CultureInfo.GetCultureInfo("vi-Vn")));
                    lvi.SubItems.Add(km_bus.DsSanPham.Rows[i][3].ToString());
                    lvi.Tag = km_bus.DsSanPham.Rows[i][0].ToString();
                }
            }
        }

        private void themBtn_Click(object sender, EventArgs e)
        {
            if (sanpham_listview.SelectedIndices.Count > 0)
            {
                // Thêm vào danh sách ctkm   
                try
                {
                    int phanTram = Int32.Parse(PhanTramTxt.Text);

                    if(phanTram<1 || phanTram > 99)
                    {
                        MessageBox.Show("Phần trăm giảm giá không hợp lệ");
                        return;
                    }


                    int masp = Int32.Parse(sanpham_listview.Items[sanpham_listview.SelectedIndices[0]].Tag.ToString());
                    km_bus.DsChiTietKhuyenMai.Add(masp, phanTram);

                    for(int i = 0; i< km_bus.DsSanPham.Rows.Count; i++)
                    {
                        if (Int32.Parse(km_bus.DsSanPham.Rows[i][0].ToString()) == masp)
                        {
                            ListViewItem lvi = ctkm_listview.Items.Add((km_bus.DsSanPham.Rows[i][1].ToString()));
                            lvi.SubItems.Add(Int64.Parse(km_bus.DsSanPham.Rows[i][2].ToString().Split('.')[0]).ToString("C", System.Globalization.CultureInfo.GetCultureInfo("vi-Vn")));
                            lvi.SubItems.Add(phanTram + "%");
                            double giaDaGiam = ((100 - phanTram) * 1.0 / 100) * Int64.Parse(km_bus.DsSanPham.Rows[i][2].ToString().Split('.')[0]);
                            /*MessageBox.Show(giaDaGiam+"");*/
                            lvi.SubItems.Add(giaDaGiam.ToString("C", System.Globalization.CultureInfo.GetCultureInfo("vi-Vn")));

                            lvi.Tag = masp; // lưu lại masp
                        }
                    }
                   

                    sanpham_listview.Items.RemoveAt(sanpham_listview.SelectedIndices[0]);
                    PhanTramTxt.Text = "";
                    chonLbl.Text = "Sản phẩm đang chọn :";

                    if (dateTimePicker1.Enabled == true)
                    {
                        dateTimePicker1.Enabled = false;
                    }
                    if (dateTimePicker2.Enabled == true)
                    {
                        dateTimePicker2.Enabled = false;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Nhập phần trăm giảm hợp lệ \n"+ex);
                    PhanTramTxt.Focus();
                }
            }
            else
                MessageBox.Show("Bạn phải chọn sản phẩm");
        }

        private void sanpham_listview_Click(object sender, EventArgs e)
        {
            if (sanpham_listview.SelectedItems.Count > 0)
                chonLbl.Text = "Sản phẩm đang chọn :" + sanpham_listview.SelectedItems[0].SubItems[0].Text;

        }

        private void boBtn_Click(object sender, EventArgs e)
        {
            if (ctkm_listview.SelectedItems.Count > 0)
            {
                BoDiSanPhamTrongBangGiamGia(ctkm_listview.SelectedIndices[0]);
            }
            else
            {
                MessageBox.Show("Bạn phải chọn 1 sản phẩm khuyến mãi trong bảng");
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (ctkm_listview.Items.Count == 0)
            {
                MessageBox.Show("Không còn sản phẩm nào trong bảng giảm giá");
                return;
            }
            else
            {
                for (int i = 0; i < ctkm_listview.Items.Count; i++)
                {
                    BoDiSanPhamTrongBangGiamGia(i);
                    i--;
                }
            }
        }

        public void BoDiSanPhamTrongBangGiamGia(int viTriSanPhamTrongBangGiamGia)
        {
            int masp = Int32.Parse(ctkm_listview.Items[viTriSanPhamTrongBangGiamGia].Tag.ToString());

            // Thêm lại vào listview sản phẩm
            for (int i = 0; i < km_bus.DsSanPham.Rows.Count; i++)
            {
                if (Int32.Parse(km_bus.DsSanPham.Rows[i][0].ToString()) == masp)
                {
                    ListViewItem lvi = sanpham_listview.Items.Add(km_bus.DsSanPham.Rows[i][1].ToString());
                    lvi.SubItems.Add(long.Parse(km_bus.DsSanPham.Rows[i][2].ToString().Split('.')[0]).ToString("C", System.Globalization.CultureInfo.GetCultureInfo("vi-Vn")));
                    lvi.SubItems.Add(km_bus.DsSanPham.Rows[i][3].ToString());
                    lvi.Tag = masp;
                }
            }

            //Xóa khỏi danh sách chi tiết sản phẩm
            ctkm_listview.Items.RemoveAt(viTriSanPhamTrongBangGiamGia);
            bool kq = km_bus.DsChiTietKhuyenMai.Remove(masp);
            /*MessageBox.Show(kq + "");*/

            if(km_bus.DsChiTietKhuyenMai.Count == 0)
            {
                if(!dateTimePicker1.Enabled && !dateTimePicker2.Enabled)
                {
                    dateTimePicker1.Enabled = true;
                    dateTimePicker2.Enabled = true;
                }
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            km_bus.DsChiTietKhuyenMai.Clear();
            km_bus.khuyenMaiChon = null;
            qlkm_form.parent_f.initQuanLyKhuyenMai();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if(km_bus.DsChiTietKhuyenMai.Count == 0)
            {
                MessageBox.Show("không có bất kì sản phẩm giảm giá nào");
                return;
            }
            if (moTaTxt.Text == "")
            {
                MessageBox.Show("mô tả khuyến mãi không được để trống");
                moTaTxt.Focus();
                return;
            }
            if (!checkDuplicate())
            {
                MessageBox.Show("mô tả khuyến mãi đã tồn tại");
                return;
            }
            // Thêm 
            if (!this.capnhat)
            {
                km_bus.themKhuyenMai(moTaTxt.Text, dateTimePicker1.Value.Date.ToString("yyyy/MM/dd"), dateTimePicker2.Value.Date.ToString("yyyy/MM/dd"));
                MessageBox.Show("Thêm mới 1 đợt khuyến mãi thành công");
            }
            else // Cập nhật
            {
                km_bus.CapNhatKhuyenMai(moTaTxt.Text, dateTimePicker1.Value.Date.ToString("yyyy/MM/dd"), dateTimePicker2.Value.Date.ToString("yyyy/MM/dd"));
                MessageBox.Show("Cập nhật đợt khuyến mãi thành công");
            }
            this.qlkm_form.parent_f.initQuanLyKhuyenMai();
            this.qlkm_form.ReLoad();
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            if (capnhat)
            {
                List<string> kt = km_bus.kiemTraCoTheThayDoiNgayKhong(dateTimePicker1.Value, dateTimePicker2.Value, Int32.Parse(this.km_bus.khuyenMaiChon[0].ToString()));
                if (kt.Count > 0)
                {
                    string message = "Các sản phẩm đã nằm trong đợt khuyễn mãi khác tại khoản thời gian này :";
                    for (int i = 0; i < kt.Count; i++)
                    {
                        message += "\n" + kt[i];
                    }
                    MessageBox.Show(message);
                }
            }
            else {
                loadSanPhamCoTheKhuyenMaiTheoNgay(dateTimePicker1.Value, dateTimePicker2.Value);
            }
        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {
            if (capnhat)
            {
                List<string> kt = km_bus.kiemTraCoTheThayDoiNgayKhong(dateTimePicker1.Value, dateTimePicker2.Value, Int32.Parse(this.km_bus.khuyenMaiChon[0].ToString()));
                if (kt.Count > 0)
                {
                    string message = "Các sản phẩm đã nằm trong đợt khuyễn mãi khác tại khoản thời gian này :";
                    for (int i = 0; i < kt.Count; i++)
                    {
                        message += "\n" + kt[i];
                    }
                    MessageBox.Show(message);
                }
            }
            else
            {
                loadSanPhamCoTheKhuyenMaiTheoNgay(dateTimePicker1.Value, dateTimePicker2.Value);
            }
        }

        private void loadSanPhamCoTheKhuyenMaiTheoNgay(DateTime dateBd, DateTime dateKt) {
            if(dateBd < DateTime.Now.Date && !capnhat)
            {
                MessageBox.Show("Ngày bắt đầu phải ở tương lai");
                return;
            }

            if(dateKt < dateBd)
            {
                MessageBox.Show("Ngày kết thúc phải lớn hơn hoặc trùng ngày bắt đầu");
                return;
            }

            if (!capnhat)
            {
                km_bus.layDanhSachSanPham(dateBd, dateKt);
            }
            else
            {
                km_bus.layDanhSachSanPham(dateBd, dateKt, Int32.Parse(this.km_bus.khuyenMaiChon[0].ToString()));
            }
                
            hienThiNoiDung2Bang();
        }
        public Boolean  checkDuplicate()
        {
            string txt = moTaTxt.Text;
            for( int i = 0; i< km_bus.dsKhuyenMai.Rows.Count; i++)
            {
                if (capnhat)
                {
                    if (txt.Equals(km_bus.dsKhuyenMai.Rows[i][0].ToString()) && !txt.Equals(km_bus.khuyenMaiChon[1].ToString()))
                    {
                        return false;
                    }
                }
                else
                {
                    if (txt.Equals(km_bus.dsKhuyenMai.Rows[i][0].ToString()))
                    {
                        return false;
                    }
                }
            }
            return true;
        }
    }
}
