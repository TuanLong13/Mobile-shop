using QuanLyCuaHangDienThoai.BUS;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyCuaHangDienThoai.GUI
{
    public partial class KhachHang_GUI : UserControl
    {
        KhachHang_BUS kh = new KhachHang_BUS();
        public KhachHang_GUI()
        {
            InitializeComponent();
        }

        private void KhachHang_GUI_Load(object sender, EventArgs e)
        {
            lsvKhachHang.FullRowSelect = true;
            lsvKhachHang.View = View.Details;
            lsvKhachHang.Columns.Add("Mã khách hàng");
            lsvKhachHang.Columns.Add("Tên khách hàng");
            lsvKhachHang.Columns.Add("Số điện thoại");
            lsvKhachHang.Columns[0].Width = 0;
            lsvKhachHang.Columns[1].Width = this.Width / 2;
            lsvKhachHang.Columns[2].Width = this.Width / 2 ;
            loadKhachHang();
        }

        private void loadKhachHang()
        {
            lsvKhachHang.Items.Clear();
            DataTable dt = kh.layDanhSachKhachHang();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ListViewItem lvi = lsvKhachHang.Items.Add(dt.Rows[i][0].ToString());
                lvi.SubItems.Add(dt.Rows[i][1].ToString());
                lvi.SubItems.Add(dt.Rows[i][2].ToString());
            }
            btnSua.Enabled = false;
            btnXoa.Enabled = false;

        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            string ten = txtTenKhachHang.Text.Trim();
            string sdt = txtSDT.Text;
            try
            {
                if (!ten.Equals("") && !sdt.Equals(""))
                {
                    if (ten.All(s => Char.IsLetter(s) || s == ' '))
                    {
                        Regex regex = new Regex(@"^0\d{9}$");
                        if (regex.IsMatch(txtSDT.Text))
                        {
                            if (kh.kiemTraSDT(txtSDT.Text))
                            {
                                kh.themKhachHang(ten, sdt);
                                MessageBox.Show("Thêm khách hàng thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                loadKhachHang();
                            }
                            else
                            {
                                MessageBox.Show("Số điện thoại này đã tồn tại. Vui lòng nhập lại số khác", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                txtSDT.Focus();
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
                        txtTenKhachHang.Focus();
                    }
                }
                else
                {
                    MessageBox.Show("Vui lòng nhập đầy đủ thông tin trước khi thêm", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Đã có lỗi xảy ra, xin vui lòng thử lại\n" + ex.ToString(), "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            string ten = txtTenKhachHang.Text.Trim();
            string sdt = txtSDT.Text;
            try
            {
                if (!ten.Equals("") && !sdt.Equals(""))
                {
                    if (ten.All(s => Char.IsLetter(s) || s == ' '))
                    {
                        Regex regex = new Regex(@"^0\d{9}$");
                        if (regex.IsMatch(txtSDT.Text))
                        {
                            if (kh.kiemTraSDT(sdt) || txtSDT.Text.Equals(lsvKhachHang.SelectedItems[0].SubItems[2].Text))
                            {
                                kh.suaKhachHang(lsvKhachHang.SelectedItems[0].SubItems[0].Text, ten, sdt);
                                MessageBox.Show("Sửa khách hàng thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                loadKhachHang();
                            }
                            else
                            {
                                MessageBox.Show("Số điện thoại này đã tồn tại. Vui lòng nhập lại số khác", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                txtSDT.Focus();
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
                        txtTenKhachHang.Focus();
                    }
                }
                else
                {
                    MessageBox.Show("Vui lòng nhập đầy đủ thông tin trước khi thêm", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Đã có lỗi xảy ra, xin vui lòng thử lại\n" + ex.ToString(), "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                if (kh.KiemTraThamChieu(lsvKhachHang.SelectedItems[0].SubItems[0].Text))
                {
                    MessageBox.Show("Không thể xóa vì khách hàng này đã tồn tại trong danh sách hóa đơn", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    DialogResult dr = MessageBox.Show("Bạn có chắc muốn xóa khách hàng này?", "Xóa thông tin", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (dr == DialogResult.Yes)
                    {
                        kh.xoaKhachHang(lsvKhachHang.SelectedItems[0].SubItems[0].Text);
                        loadKhachHang();
                    }
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Đã có lỗi xảy ra, xin vui lòng thử lại\n" + ex.ToString(), "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            lsvKhachHang.Items.Clear();
            DataTable dt = kh.timKiemKhachHang(txtTimKiem.Text);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ListViewItem lvi = lsvKhachHang.Items.Add(dt.Rows[i][0].ToString());
                lvi.SubItems.Add(dt.Rows[i][1].ToString());
                lvi.SubItems.Add(dt.Rows[i][2].ToString());
            }
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
        }

        private void lsvKhachHang_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lsvKhachHang.SelectedIndices.Count > 0)
            {
                txtTenKhachHang.Text = lsvKhachHang.SelectedItems[0].SubItems[1].Text;
                txtSDT.Text = lsvKhachHang.SelectedItems[0].SubItems[2].Text;
                btnSua.Enabled = true;
                btnXoa.Enabled = true;
            }
        }

    }
}

