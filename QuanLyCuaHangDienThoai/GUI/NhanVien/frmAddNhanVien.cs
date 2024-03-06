using QuanLyCuaHangDienThoai.BUS;
using QuanLyCuaHangDienThoai.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace QuanLyCuaHangDienThoai.GUI.NhanVien
{
    public partial class frmAddNhanVien : Form
    {
 
        NhanVien_GUI NVG = new NhanVien_GUI();
        NhanVien_BUS nvBus = new NhanVien_BUS();
        public frmAddNhanVien()
        {
            InitializeComponent();
        }
        private void btnThoat_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string tenNV = txtTenNV.Text;
            string sdt = txtSDT.Text;
            string email = txtEmail.Text;
            string diaChi = txtDiaChi.Text;
            string chucVu = cbChucVu.Text;

            try
            {
                if (!tenNV.Equals("") && !sdt.Equals(""))
                {
                    if (tenNV.All(s => Char.IsLetter(s) || s == ' '))
                    {
                        if (sdt.All(Char.IsDigit) && txtSDT.Text.Length == 10)
                        {
                            Regex emailFormat = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,})+)$");
                            if (emailFormat.IsMatch(txtEmail.Text))
                            {
                                nvBus.themNhanVien(tenNV, sdt, email, diaChi, chucVu);
                                MessageBox.Show("Thêm nhân viên thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                Close();
                            }
                            else
                            {
                                MessageBox.Show("Email phải nhập đúng định dạng abc@mail.com", "Lỗi");
                            }
                        }
                        else
                        {
                            MessageBox.Show("Số điện thoại phải có đúng 10 ký tự số", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            txtSDT.Focus();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Tên nhân viên chỉ được phép nhập chữ", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txtTenNV.Focus();
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

        private bool KiemTraThongTinNhap(string tenNV, string sdt, string email, string diaChi, string chucVu)
        {
            return !string.IsNullOrWhiteSpace(tenNV) &&
                   !string.IsNullOrWhiteSpace(sdt) &&
                   !string.IsNullOrWhiteSpace(email) &&
                   !string.IsNullOrWhiteSpace(diaChi) &&
                   !string.IsNullOrWhiteSpace(chucVu);
        }

        private void frmAddNhanVien_Load(object sender, EventArgs e)
        {
            DataTable dt = nvBus.layDanhSachChucVu();
            if (dt != null && dt.Rows.Count > 0)
            {
                cbChucVu.DataSource = dt;
                cbChucVu.ValueMember = "TENCHUCVU";
                cbChucVu.DisplayMember = "TENCHUCVU";
            }
        }
    }
}
