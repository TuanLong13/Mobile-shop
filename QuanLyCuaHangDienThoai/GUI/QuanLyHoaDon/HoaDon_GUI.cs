using QuanLyCuaHangDienThoai.BUS;
using QuanLyCuaHangDienThoai.GUI.QuanLyHoaDon;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyCuaHangDienThoai.GUI
{
    public partial class HoaDon_GUI : UserControl
    {
        public string username;
        HoaDon_BUS hd = new HoaDon_BUS();
        KhachHang_BUS kh = new KhachHang_BUS();
        public HoaDon_GUI()
        {
            InitializeComponent();
        }
        private void HoaDon_GUI_Load(object sender, EventArgs e)
        {
            //tab 1
            lsvSanPham.FullRowSelect = true;
            lsvSanPham.View = View.Details;
            lsvSanPham.Columns.Add("Mã sản phẩm");
            lsvSanPham.Columns.Add("Tên sản phẩm");
            lsvSanPham.Columns.Add("Hãng");
            lsvSanPham.Columns.Add("Đơn giá");
            lsvSanPham.Columns.Add("Số lượng");


            lsvCTHoaDon.FullRowSelect = true;
            lsvCTHoaDon.View = View.Details;
            lsvCTHoaDon.Columns.Add("Mã sản phẩm");
            lsvCTHoaDon.Columns.Add("Tên sản phẩm");
            lsvCTHoaDon.Columns.Add("Đơn giá");
            lsvCTHoaDon.Columns.Add("Số lượng mua");
            lsvCTHoaDon.Columns.Add("Thành tiền");
            lsvCTHoaDon.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
            lsvCTHoaDon.Columns[0].Width = 0;

            txtNgayLap.Text = DateTime.Now.ToString();
            loadSanPham();
            btnXoa.Enabled = btnThanhToan.Enabled = txtTienTra.Enabled = txtDiaChi.Enabled = false;
            cboTrangThai.SelectedIndex = 1;

            //Khuyến mãi
            cboKhuyenMai.SelectedIndexChanged -= cboKhuyenMai_SelectedIndexChanged;
            lsvCTKhuyenMai.FullRowSelect = true;
            lsvCTKhuyenMai.View = View.Details;
            lsvCTKhuyenMai.Columns.Add("Mã sản phẩm");
            lsvCTKhuyenMai.Columns.Add("Tên sản phẩm");
            lsvCTKhuyenMai.Columns.Add("% giảm giá");
            lsvCTKhuyenMai.Columns.Add("Ngày bắt đầu");
            lsvCTKhuyenMai.Columns.Add("Ngày kết thúc");
            lsvCTKhuyenMai.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
            loadKhuyenMai();
            cboKhuyenMai.SelectedIndexChanged += cboKhuyenMai_SelectedIndexChanged;
            cboKhuyenMai.SelectedIndex = 0;
            loadCTKhuyenMai();
            btnBoApDung.Enabled = false;

            //tab 2
            lsvHoaDon.FullRowSelect = true;
            lsvHoaDon.View = View.Details;
            lsvHoaDon.Columns.Add("Mã hóa đơn");
            lsvHoaDon.Columns.Add("Khách hàng");
            lsvHoaDon.Columns.Add("Nhân viên");
            lsvHoaDon.Columns.Add("Ngày lập");
            lsvHoaDon.Columns.Add("Địa chỉ giao");
            lsvHoaDon.Columns.Add("Tổng tiền");
            lsvHoaDon.Columns.Add("Trạng thái");
            lsvHoaDon.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
            lsvHoaDon.Columns[0].Width = 0;
            cboTrangThai2.Enabled = false;
        }
        //tab lập
        private void loadSanPham()
        {
            lsvSanPham.Items.Clear();
            DataTable dt = hd.layDanhSachSanPham();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ListViewItem lvi = lsvSanPham.Items.Add(dt.Rows[i][0].ToString());
                lvi.SubItems.Add(dt.Rows[i][1].ToString());
                lvi.SubItems.Add(dt.Rows[i][2].ToString());
                lvi.SubItems.Add(dt.Rows[i][3].ToString());
                lvi.SubItems.Add(dt.Rows[i][4].ToString());
            }
            lsvSanPham.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
            lsvSanPham.AutoResizeColumn(3, ColumnHeaderAutoResizeStyle.HeaderSize);
            lsvSanPham.AutoResizeColumn(4, ColumnHeaderAutoResizeStyle.HeaderSize);
            lsvSanPham.Columns[0].Width = 0;
            btnThem.Enabled = false;
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            lsvSanPham.Items.Clear();
            DataTable dt = hd.timKiemSanPham(txtTimKiem.Text);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ListViewItem lvi = lsvSanPham.Items.Add(dt.Rows[i][0].ToString());
                lvi.SubItems.Add(dt.Rows[i][1].ToString());
                lvi.SubItems.Add(dt.Rows[i][2].ToString());
                lvi.SubItems.Add(dt.Rows[i][3].ToString());
                lvi.SubItems.Add(dt.Rows[i][4].ToString());
            }
            lsvSanPham.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
            lsvSanPham.AutoResizeColumn(4, ColumnHeaderAutoResizeStyle.HeaderSize);
            lsvSanPham.Columns[0].Width = 0;
            nudSoLuong.Enabled = false;
            btnThem.Enabled = false;

            for (int i = 0; i < lsvCTHoaDon.Items.Count; i++)
            {
                string ma = lsvCTHoaDon.Items[i].SubItems[0].Text;
                for (int j = 0; j < lsvSanPham.Items.Count; j++)
                {
                    if (ma.Equals(lsvSanPham.Items[j].SubItems[0].Text))
                    {
                        int soLuongHienTai = Int32.Parse(lsvSanPham.Items[j].SubItems[4].Text) - Int32.Parse(lsvCTHoaDon.Items[i].SubItems[3].Text);
                        lsvSanPham.Items[j].SubItems[4].Text = soLuongHienTai.ToString();
                        break;
                    }
                }
            }
        }
        private void lsvSanPham_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lsvSanPham.SelectedIndices.Count > 0)
            {
                btnThem.Enabled = true;
                nudSoLuong.Enabled = true;
                nudSoLuong.Maximum = Int32.Parse(lsvSanPham.SelectedItems[0].SubItems[4].Text);
                nudSoLuong.Value = 0;
            }
            else
            {
                btnThem.Enabled = false;
                nudSoLuong.Enabled = false;
            }
        }
        private void tinhTongTien()
        {
            double tongtien = 0;
            for (int i = 0; i < lsvCTHoaDon.Items.Count; i++)
            {
                tongtien += double.Parse(lsvCTHoaDon.Items[i].SubItems[4].Text);
            }

            if (tongtien == 0)
            {
                txtTienTra.Enabled = false;
                btnThanhToan.Enabled = false;
            }
            else
            {
                txtTienTra.Enabled = true;
                btnThanhToan.Enabled = true;
            }
            txtTongTien.Text = tongtien.ToString();
        }
        private void btnThem_Click(object sender, EventArgs e)
        {
            int soluong = Int32.Parse(nudSoLuong.Value.ToString());
            if (lsvSanPham.SelectedIndices.Count > 0 && soluong > 0)
            {
                if (soluong <= Int32.Parse(lsvSanPham.SelectedItems[0].SubItems[4].Text))
                {
                    for(int i = 0; i < lsvCTHoaDon.Items.Count; i++)
                    {
                        if (lsvCTHoaDon.Items[i].SubItems[0].Text.Equals(lsvSanPham.SelectedItems[0].SubItems[0].Text))
                        {
                            lsvCTHoaDon.Items[i].SubItems[3].Text = (Int32.Parse(lsvCTHoaDon.Items[i].SubItems[3].Text) + soluong).ToString();
                            double thanhtienmoi = double.Parse(lsvCTHoaDon.Items[i].SubItems[2].Text) * Int32.Parse(lsvCTHoaDon.Items[i].SubItems[3].Text);
                            lsvCTHoaDon.Items[i].SubItems[4].Text = thanhtienmoi.ToString();

                            lsvSanPham.SelectedItems[0].SubItems[4].Text = (Int32.Parse(lsvSanPham.SelectedItems[0].SubItems[4].Text) - soluong).ToString();
                            nudSoLuong.Enabled = false;
                            btnThem.Enabled = false;
                            btnThanhToan.Enabled = true;

                            tinhTongTien();
                            return;
                        }    
                    }    

                    ListViewItem lvi = lsvCTHoaDon.Items.Add(lsvSanPham.SelectedItems[0].SubItems[0].Text);
                    lvi.SubItems.Add(lsvSanPham.SelectedItems[0].SubItems[1].Text);
                    lvi.SubItems.Add(lsvSanPham.SelectedItems[0].SubItems[3].Text);
                    lvi.SubItems.Add(nudSoLuong.Value.ToString());
                    double thanhtien = double.Parse(lsvSanPham.SelectedItems[0].SubItems[3].Text) * soluong;
                    lvi.SubItems.Add(thanhtien.ToString());
                    lsvCTHoaDon.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
                    lsvCTHoaDon.Columns[0].Width = 0;
                    lsvCTHoaDon.AutoResizeColumn(3, ColumnHeaderAutoResizeStyle.HeaderSize);

                    lsvSanPham.SelectedItems[0].SubItems[4].Text = (Int32.Parse(lsvSanPham.SelectedItems[0].SubItems[4].Text) - soluong).ToString();
                    nudSoLuong.Enabled = false;
                    btnThem.Enabled = false;
                    btnThanhToan.Enabled = true;

                    tinhTongTien();
                }
                else
                {
                    MessageBox.Show("Số lượng mua không được lớn hơn số lượng tồn", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Số lượng mua phải lớn hơn 0", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void lsvCTHoaDon_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lsvCTHoaDon.SelectedIndices.Count > 0)
            {
                btnXoa.Enabled = true;
            }
            else
            {
                btnXoa.Enabled = false;
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (lsvCTHoaDon.SelectedIndices.Count > 0)
            {
                string ma = lsvCTHoaDon.SelectedItems[0].SubItems[0].Text;
                for (int i = 0; i < lsvSanPham.Items.Count; i++)
                {
                    if (ma.Equals(lsvSanPham.Items[i].SubItems[0].Text))
                    {
                        int soLuongBanDau = Int32.Parse(lsvSanPham.Items[i].SubItems[4].Text) + Int32.Parse(lsvCTHoaDon.SelectedItems[0].SubItems[3].Text);
                        lsvSanPham.Items[i].SubItems[4].Text = soLuongBanDau.ToString();
                        break;
                    }
                }
                lsvCTHoaDon.Items.Remove(lsvCTHoaDon.SelectedItems[0]);
                btnXoa.Enabled = false;
                tinhTongTien();
            }
        }

        private void txtTienTra_TextChanged(object sender, EventArgs e)
        {
            if (!txtTienTra.Text.Trim().Equals(""))
            {
                if (txtTienTra.Text.All(Char.IsDigit))
                {
                    txtTienThoi.Text =  (double.Parse(txtTienTra.Text) - double.Parse(txtTongTien.Text)).ToString();
                }
                else
                {
                    MessageBox.Show("Số tiền trả chỉ được phép nhập số dương", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtTienTra.Text = txtTienTra.Text.Remove(txtTienTra.Text.Length - 1);
                }
            }
            else
            {
                txtTienThoi.Text = "";
            }
        }

        private void cboTrangThai_SelectedIndexChanged(object sender, EventArgs e)
        {
            if( cboTrangThai.SelectedIndex == 1 )
            {
                txtDiaChi.Enabled = false;
                txtDiaChi.Text = "";
            }    
            else
            {
                txtDiaChi.Enabled = true;
            }    
        }
        private void txtSDT_TextChanged(object sender, EventArgs e)
        {
            if( !txtSDT.Text.Trim().Equals(""))
            {
                DataTable dt = hd.timKhachHang(txtSDT.Text);
                if( dt.Rows.Count > 0 )
                {
                    txtKhachHang.Text = dt.Rows[0][0].ToString();
                }    
            }    
        }
        private void btnKhuyenMai_Click(object sender, EventArgs e)
        {
            groupBox3.Visible = true;
            groupBox1.Visible = false;
        }
        private void btnThanhToan_Click(object sender, EventArgs e)
        {
            string ten = txtKhachHang.Text.Trim();
            string sdt = txtSDT.Text;
            DateTime ngaylap = DateTime.Now;
            int trangthai;
            if (cboTrangThai.Text.Equals("Đã thanh toán"))
            {
                trangthai = 1;
            }
            else
            {
                trangthai = 0;
            }
            string diachi;
            if (trangthai == 1)
            {
                diachi = "Mua tại chỗ";
            }
            else
            {
                diachi = txtDiaChi.Text.Trim();
            }
            double tongtien = double.Parse(txtTongTien.Text);
            if (ten.Equals("") || sdt.Equals("") || diachi.Equals("") || txtTienTra.Text.Equals("") )
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin trước khi thanh toán", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }    
            else
            {
                if (ten.All(s => Char.IsLetter(s) || s == ' '))
                {
                    Regex regex = new Regex(@"^0\d{9}$");
                    if (regex.IsMatch(txtSDT.Text))
                    {

                        double tientra = double.Parse(txtTienTra.Text);
                        if (tientra - tongtien >= 0)
                        {
                            if (kh.kiemTraSDT(sdt))
                            {
                                kh.themKhachHang(ten, sdt);
                            }
                            string mahd = hd.thanhToan(ten, sdt, username,ngaylap, diachi, tongtien, trangthai);
                            for (int i = 0; i < lsvCTHoaDon.Items.Count; i++)
                            {
                                hd.themCTHoaDon(mahd, lsvCTHoaDon.Items[i].SubItems[0].Text, lsvCTHoaDon.Items[i].SubItems[2].Text, lsvCTHoaDon.Items[i].SubItems[3].Text);
                            }
                            loadSanPham();
                            lsvCTHoaDon.Items.Clear();
                            btnThanhToan.Enabled = false;
                            txtTienThoi.Text = "";
                            txtTienTra.Text = "";
                            txtTongTien.Text = "";
                            txtTenKhachHang.Text = "";
                            txtSDT.Text = "";
                            txtDiaChi.Text = "";
                            txtNgayLap.Text = DateTime.Now.ToString();
                            MessageBox.Show("Lập hóa đơn thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("Số tiền trả không được nhỏ hơn tổng tiền", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            txtTienTra.Focus();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Số điện thoại không hợp lệ. Số điện thoại hợp lệ phải bắt đầu từ 0 và đủ 10 số.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txtSDT.Focus();
                    }
                }
                else
                {
                    MessageBox.Show("Tên khách hàng chỉ được phép nhập chữ", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtKhachHang.Focus();
                }
            }    
        }
        //Chọn khuyến mãi
        private void loadKhuyenMai()
        {
            cboKhuyenMai.DataSource = hd.layDanhSachMoTa();
            cboKhuyenMai.ValueMember = "MAKM";
            cboKhuyenMai.DisplayMember = "MOTA";
        }
        private void loadCTKhuyenMai()
        {
            lsvCTKhuyenMai.Items.Clear();
            DataTable dt = hd.layDanhSachChiTietKM(cboKhuyenMai.SelectedValue.ToString());
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ListViewItem lvi = lsvCTKhuyenMai.Items.Add(dt.Rows[i][0].ToString());
                lvi.SubItems.Add(dt.Rows[i][1].ToString());
                lvi.SubItems.Add(dt.Rows[i][2].ToString());
                lvi.SubItems.Add(dt.Rows[i][3].ToString());
                lvi.SubItems.Add(dt.Rows[i][4].ToString());
            }
            lsvCTKhuyenMai.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
            lsvCTKhuyenMai.Columns[0].Width = 0;
            lsvCTKhuyenMai.AutoResizeColumn(2, ColumnHeaderAutoResizeStyle.HeaderSize);
        }
        private void cboKhuyenMai_SelectedIndexChanged(object sender, EventArgs e)
        {
            loadCTKhuyenMai();
        }
        private void btnThoat_Click(object sender, EventArgs e)
        {
            groupBox3.Visible = false;
            groupBox1.Visible = true;
        }
        private void huyBoKhuyenMai()
        {
            loadSanPham();
            for (int i = 0; i < lsvCTHoaDon.Items.Count; i++)
            {
                string ma = lsvCTHoaDon.Items[i].SubItems[0].Text;
                for (int j = 0; j < lsvSanPham.Items.Count; j++)
                {
                    if (ma.Equals(lsvSanPham.Items[j].SubItems[0].Text))
                    {
                        int soLuongHienTai = Int32.Parse(lsvSanPham.Items[j].SubItems[4].Text) - Int32.Parse(lsvCTHoaDon.Items[i].SubItems[3].Text);
                        lsvSanPham.Items[j].SubItems[4].Text = soLuongHienTai.ToString();
                        lsvCTHoaDon.Items[i].SubItems[2].Text = lsvSanPham.Items[j].SubItems[3].Text;
                        double thanhtien = double.Parse(lsvCTHoaDon.Items[i].SubItems[2].Text) * Int32.Parse(lsvCTHoaDon.Items[i].SubItems[3].Text);
                        lsvCTHoaDon.Items[i].SubItems[4].Text = thanhtien.ToString();
                        break;
                    }
                }
            }
            tinhTongTien();
        }
        private void btnApDung_Click(object sender, EventArgs e)
        {
            huyBoKhuyenMai();
            for(int i = 0; i < lsvCTKhuyenMai.Items.Count; i++)
            {
                string masp = lsvCTKhuyenMai.Items[i].SubItems[0].Text;
                for (int j = 0; j < lsvSanPham.Items.Count; j++)
                {
                    if (lsvSanPham.Items[j].SubItems[0].Text.Equals(masp))
                    {
                        double dongiamoi = double.Parse(lsvSanPham.Items[j].SubItems[3].Text) * (100 - double.Parse(lsvCTKhuyenMai.Items[i].Text)) / 100.0;
                        lsvSanPham.Items[j].SubItems[3].Text = dongiamoi.ToString();
                        for (int k = 0; k < lsvCTHoaDon.Items.Count; k++)
                        {
                            if (lsvCTHoaDon.Items[k].SubItems[0].Text.Equals(masp))
                            {
                                lsvCTHoaDon.Items[k].SubItems[2].Text = lsvSanPham.Items[j].SubItems[3].Text;
                                double thanhtienmoi = double.Parse(lsvCTHoaDon.Items[k].SubItems[2].Text) * Int32.Parse(lsvCTHoaDon.Items[k].SubItems[3].Text);
                                lsvCTHoaDon.Items[k].SubItems[4].Text = thanhtienmoi.ToString();
                                break;
                            }

                        }
                        break;
                    }
                }

                
            }
            tinhTongTien();
            btnBoApDung.Enabled = true;
            btnKhuyenMai.Text = "Đang áp dụng";
            MessageBox.Show("Áp dụng khuyến mãi thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        private void btnBoApDung_Click(object sender, EventArgs e)
        {
            huyBoKhuyenMai();
            btnBoApDung.Enabled = false;
            btnKhuyenMai.Text = "Khuyến mãi";
        }
        //tab quản lý
        private void tabPage2_Click(object sender, EventArgs e)
        {
            loadHoaDon();
        }
        private void loadHoaDon()
        {
            lsvHoaDon.Items.Clear();
            DataTable dt = hd.layDanhSachHoaDon(checkBox1.Checked);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ListViewItem lvi = lsvHoaDon.Items.Add(dt.Rows[i][0].ToString());
                lvi.SubItems.Add(dt.Rows[i][1].ToString());
                lvi.SubItems.Add(dt.Rows[i][2].ToString());
                lvi.SubItems.Add(dt.Rows[i][3].ToString());
                lvi.SubItems.Add(dt.Rows[i][4].ToString());
                lvi.SubItems.Add(dt.Rows[i][5].ToString());
                lvi.Tag = dt.Rows[i][0].ToString();
                if (dt.Rows[i][6].ToString() == "1")
                {
                    lvi.SubItems.Add("Đã thanh toán");
                }
                else
                {
                    lvi.SubItems.Add("Chưa thanh toán");
                }
            }
            lsvHoaDon.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
            lsvHoaDon.Columns[0].Width = 0;
            btnSuaTrangThai.Enabled = false;
        }

        private void btnTimTheoTen_Click(object sender, EventArgs e)
        {
            lsvHoaDon.Items.Clear();
            DataTable dt = hd.timHoaDon(txtTenKhachHang.Text, checkBox1.Checked);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ListViewItem lvi = lsvHoaDon.Items.Add(dt.Rows[i][0].ToString());
                lvi.SubItems.Add(dt.Rows[i][1].ToString());
                lvi.SubItems.Add(dt.Rows[i][2].ToString());
                lvi.SubItems.Add(dt.Rows[i][3].ToString());
                lvi.SubItems.Add(dt.Rows[i][4].ToString());
                lvi.SubItems.Add(dt.Rows[i][5].ToString());
                if(dt.Rows[i][6].ToString() == "1")
                {
                    lvi.SubItems.Add("Đã thanh toán");
                }
                else
                {
                    lvi.SubItems.Add("Chưa thanh toán");
                }    
            }
            lsvHoaDon.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
            lsvHoaDon.Columns[0].Width = 0;
            btnSuaTrangThai.Enabled = false;
        }

        private void lsvHoaDon_SelectedIndexChanged(object sender, EventArgs e)
        {
            if( lsvHoaDon.SelectedIndices.Count > 0 )
            {
                if (lsvHoaDon.SelectedItems[0].SubItems[6].Text.Equals("Đã thanh toán"))
                {
                    cboTrangThai2.Enabled = false;
                    cboTrangThai2.SelectedIndex = cboTrangThai2.FindString(lsvHoaDon.SelectedItems[0].SubItems[6].Text);
                    btnSuaTrangThai.Enabled = false;
                }    
                else
                {
                    cboTrangThai2.Enabled = true;
                    cboTrangThai2.SelectedIndex = cboTrangThai2.FindString(lsvHoaDon.SelectedItems[0].SubItems[6].Text);
                    btnSuaTrangThai.Enabled = true;
                }    
            }
            else
            {
                btnSuaTrangThai.Enabled = false;
            }    
        }
        private void btnSuaTrangThai_Click(object sender, EventArgs e)
        {
            int trangthai;
            if(cboTrangThai2.Text.Equals("Đã thanh toán"))
            {
                trangthai = 1;
            }    
            else
            {
                trangthai = 0;
            }
            hd.suaHoaDon(lsvHoaDon.SelectedItems[0].SubItems[0].Text, trangthai);
            MessageBox.Show("Sửa hóa đơn thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            loadHoaDon();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            loadHoaDon();
        }

        private void lsvHoaDon_DoubleClick(object sender, EventArgs e)
        {
            if (lsvHoaDon.SelectedIndices.Count > 0)
            {
                int mahd = Int32.Parse(lsvHoaDon.SelectedItems[0].Tag.ToString());
                new CTHoaDon(mahd).Show();
            }
        }
    }
}