using QuanLyCuaHangDienThoai.BUS;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyCuaHangDienThoai.GUI
{
    public partial class TaiKhoan_GUI : UserControl
    {
        TaiKhoan_BUS tk = new TaiKhoan_BUS();
        public TaiKhoan_GUI()
        {
            InitializeComponent();
        }

        private void lvsTaiKhoan_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lsvTaiKhoan.SelectedIndices.Count > 0)
            {
                txtUser.Text = lsvTaiKhoan.SelectedItems[0].SubItems[2].Text;
                txtPassword.Text = lsvTaiKhoan.SelectedItems[0].SubItems[3].Text;
                cbbNhanVien.SelectedIndex = cbbNhanVien.FindString(lsvTaiKhoan.SelectedItems[0].SubItems[1].Text);
                cbbTinhTrang.SelectedIndex = cbbTinhTrang.FindString(lsvTaiKhoan.SelectedItems[0].SubItems[4].Text);
                btnSua.Enabled = true;
                btnXoa.Enabled = true;
                txtUser.Enabled = false;
            }
            else
            {
                txtUser.Enabled = true;
            }    
        }

        private void TaiKhoan_GUI_Load(object sender, EventArgs e)
        {
            lsvTaiKhoan.FullRowSelect = true;
            lsvTaiKhoan.View = View.Details;
            lsvTaiKhoan.Columns.Add("Mã tài khoản");
            lsvTaiKhoan.Columns.Add("Tên nhân viên");
            lsvTaiKhoan.Columns.Add("Tên tài khoản");
            lsvTaiKhoan.Columns.Add("Mật khẩu");
            lsvTaiKhoan.Columns.Add("Tình trạng");
            lsvTaiKhoan.Columns[0].Width = 0;
            lsvTaiKhoan.Columns[1].Width = lsvTaiKhoan.Width /3;
            lsvTaiKhoan.Columns[2].Width = lsvTaiKhoan.Width / 3;
            lsvTaiKhoan.Columns[3].Width = lsvTaiKhoan.Width / 3; 
            lsvTaiKhoan.Columns[4].Width = lsvTaiKhoan.Width / 3;
            loadTaiKhoan();
            loadNhanVien();
        }
        private void loadTaiKhoan()
        {
            lsvTaiKhoan.Items.Clear();
            if (cbKhoa.Checked)
            {
                DataTable dt = tk.layDanhSachTaiKhoanKhongKhoa();
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    ListViewItem lvi = lsvTaiKhoan.Items.Add(dt.Rows[i][0].ToString());
                    lvi.SubItems.Add(dt.Rows[i][1].ToString());
                    lvi.SubItems.Add(dt.Rows[i][2].ToString());
                    lvi.SubItems.Add(dt.Rows[i][3].ToString());
                    lvi.SubItems.Add("Không khóa");
                }
            }
            else
            {
                DataTable dt = tk.layDanhSachTaiKhoan();
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    ListViewItem lvi = lsvTaiKhoan.Items.Add(dt.Rows[i][0].ToString());
                    lvi.SubItems.Add(dt.Rows[i][1].ToString());
                    lvi.SubItems.Add(dt.Rows[i][2].ToString());
                    lvi.SubItems.Add(dt.Rows[i][3].ToString());
                    if (dt.Rows[i][4].ToString().Equals("1"))
                    {
                        lvi.SubItems.Add("Không khóa");
                    }
                    else
                    {
                        lvi.SubItems.Add("Khóa");
                    }
                }
            }
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
        }
        private void loadNhanVien()
        {
            DataTable dt = tk.layDanhSachNhanVien();
            cbbNhanVien.DataSource = dt;
            cbbNhanVien.ValueMember = "MANV";
            cbbNhanVien.DisplayMember = "TENNV";
        }
        private void btnThem_Click(object sender, EventArgs e)
        {
            string username = txtUser.Text;
            string password = txtPassword.Text;
            int manv = Int32.Parse(cbbNhanVien.SelectedValue.ToString());

            if (username.Trim() != "" && password.Trim() != "" && manv != 0)
            {
                if (tk.kiemTraTaiKhoan(username))
                {
                    tk.themTaiKhoan(manv, username, password, 1);
                    MessageBox.Show("Thêm tài khoản thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    loadTaiKhoan();
                }
                else
                {
                    MessageBox.Show("Tên tài khoản này đã tồn tại. Vui lòng nhập lại tên khác", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }    
            }
            else
            {

                MessageBox.Show("Vui lòng nhập đầy đủ thông tin.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }


        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult dr = MessageBox.Show("Bạn có chắc muốn xóa tai khoan này?", "Xóa thông tin", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dr == DialogResult.Yes)
                {
                    tk.xoaTaiKhoan(lsvTaiKhoan.SelectedItems[0].SubItems[0].Text);
                    loadTaiKhoan();
                    txtUser.Enabled = true;
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Đã có lỗi xảy ra, xin vui lòng thử lại\n" + ex.ToString(), "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            lsvTaiKhoan.Items.Clear();
            DataTable dt;
            if (cbKhoa.Checked)
            {
                dt = tk.timKiemTaiKhoanKhongKhoa(txtTimKiem.Text);
            }
            else
            {
                dt = tk.timKiemTaiKhoan(txtTimKiem.Text);
            }    
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ListViewItem lvi = lsvTaiKhoan.Items.Add(dt.Rows[i][0].ToString());
                lvi.SubItems.Add(dt.Rows[i][1].ToString());
                lvi.SubItems.Add(dt.Rows[i][2].ToString());
                lvi.SubItems.Add(dt.Rows[i][3].ToString());
                if (dt.Rows[i][4].ToString().Equals("1"))
                {
                    lvi.SubItems.Add("Không khóa");
                }
                else
                {
                    lvi.SubItems.Add("Khóa");
                }
            }
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            string username = txtUser.Text;
            string password = txtPassword.Text;
            int tinhtrang;
            if( cbbTinhTrang.Text.Equals("Không khóa"))
            {
                tinhtrang = 1;
            }    
            else
            {
                tinhtrang = 0;
            }    
            try
            {
                if (username.Trim() != "" && password.Trim() != "")
                {
                    tk.suaTaiKhoan(username, password, tinhtrang);
                    MessageBox.Show("Sửa tài khoản thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    loadTaiKhoan();
                    txtUser.Enabled = true;
                }
                else
                {
                    MessageBox.Show("Vui lòng nhập đầy đủ thông tin.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }    
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Đã có lỗi xảy ra, xin vui lòng thử lại\n" + ex,"Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cbKhoa_CheckedChanged(object sender, EventArgs e)
        {
                loadTaiKhoan();
        }

    }
}
