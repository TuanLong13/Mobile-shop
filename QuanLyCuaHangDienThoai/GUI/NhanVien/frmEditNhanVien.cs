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

namespace QuanLyCuaHangDienThoai.GUI.NhanVien
{
    public partial class frmEditNhanVien : Form
    {
        private bool UpdateMode = false;
        private bool AddMode = false;
        NhanVien_GUI NVG = new NhanVien_GUI();
        NhanVien_BUS nvBus = new NhanVien_BUS();
        public frmEditNhanVien()
        {
            InitializeComponent();
        }
        public void SetNhanVienInfo(DataRow nhanVienInfo)
        {

            txtTenNV.Text = nhanVienInfo["TENNV"].ToString();
            txtSDT.Text = nhanVienInfo["SDT"].ToString();
            txtEmail.Text = nhanVienInfo["EMAIL"].ToString();
            txtDiaChi.Text = nhanVienInfo["DIACHI"].ToString();
            txtChucVu.Text = nhanVienInfo["CHUCVU"].ToString();

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
            string chucVu = txtChucVu.Text;

            if (KiemTraThongTinNhap(tenNV, sdt, email, diaChi, chucVu))
            {
                if(tenNV == txtTenNV.Text)
                {
                    nvBus.updateNhanVien(tenNV, sdt, email, diaChi, chucVu);
                    MessageBox.Show("Cập nhật thông tin nhân viên thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Close();
                    NVG.loadNhanVien();
                }
                else
                {
                    MessageBox.Show("Cập nhật thông tin nhân viên khong thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Close();
                }
            }
            else
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
    }
}
