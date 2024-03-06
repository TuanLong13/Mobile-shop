using QuanLyCuaHangDienThoai.BUS;
using QuanLyCuaHangDienThoai.GUI.NhanVien;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace QuanLyCuaHangDienThoai.GUI
{
    public partial class NhanVien_GUI : UserControl
    {
        public UI parent_f;
        frmAddNhanVien addNV ;
        frmEditNhanVien editNV ;
        NhanVien_BUS nv = new NhanVien_BUS();
        public NhanVien_GUI()
        {
            InitializeComponent();
            lsvNhanVien.SelectedIndexChanged += lsvNhanVien_SelectedIndexChanged;

        }

        private void lsvNhanVien_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lsvNhanVien.SelectedIndices.Count > 0)
            {
                btnSua.Enabled = true;
                btnXoa.Enabled = true;
                txtTenNhanVien.Text = lsvNhanVien.SelectedItems[0].SubItems[1].Text;
                txtSDT.Text = lsvNhanVien.SelectedItems[0].SubItems[2].Text;
                txtEmail.Text = lsvNhanVien.SelectedItems[0].SubItems[3].Text;
                txtDiaChi.Text = lsvNhanVien.SelectedItems[0].SubItems[4].Text;
                cbChucVu.Text = lsvNhanVien.SelectedItems[0].SubItems[5].Text;

            }
            else
            {
                btnSua.Enabled = false;
                btnXoa.Enabled = false;
            }
        }


        public void NhanVien_GUI_Load(object sender, EventArgs e)
        {
            lsvNhanVien.FullRowSelect = true;
            lsvNhanVien.View = View.Details;
            lsvNhanVien.Columns.Add("Mã nhân viên");
            lsvNhanVien.Columns.Add("Tên nhân viên");
            lsvNhanVien.Columns.Add("Số điện thoại");
            lsvNhanVien.Columns.Add("Email");
            lsvNhanVien.Columns.Add("Địa chỉ");
            lsvNhanVien.Columns.Add("Chức vụ");
            lsvNhanVien.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
            loadNhanVien();
            loadChucVu();
        }
        public void loadNhanVien()
        {
            lsvNhanVien.Items.Clear();
            DataTable dt = nv.layDanhSachNhanVien();

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ListViewItem lvi = lsvNhanVien.Items.Add(dt.Rows[i][0].ToString());
                lvi.SubItems.Add(dt.Rows[i][1].ToString());
                lvi.SubItems.Add(dt.Rows[i][2].ToString());
                lvi.SubItems.Add(dt.Rows[i][3].ToString());
                lvi.SubItems.Add(dt.Rows[i][4].ToString());
                lvi.SubItems.Add(dt.Rows[i][5].ToString());
            }
            lsvNhanVien.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
            lsvNhanVien.Columns[0].Width = 0;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
        }

        private void loadChucVu()
        {
            DataTable dt = nv.layDanhSachChucVu();
            if (dt != null && dt.Rows.Count > 0)
            {
                cbChucVu.DataSource = dt;
                cbChucVu.ValueMember = "TENCHUCVU";
                cbChucVu.DisplayMember = "TENCHUCVU";
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            addNV = new frmAddNhanVien();
            addNV.ShowDialog();
            loadNhanVien();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {

            string tenNV = txtTenNhanVien.Text;
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
                                nv.updateNhanVien(tenNV, sdt, email, diaChi, chucVu);
                                MessageBox.Show("Sửa nhân viên thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                loadNhanVien();
                            }
                            else
                            {
                                MessageBox.Show("Email phải nhập đúng định dạng abc@mail.com", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                        txtTenNhanVien.Focus();
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
            loadNhanVien();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult dr = MessageBox.Show("Bạn có chắc muốn xóa nhân viên này?", "Xóa thông tin", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dr == DialogResult.Yes)
                {
                    nv.xoaNhanVien(lsvNhanVien.SelectedItems[0].SubItems[0].Text);
                    loadNhanVien();
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Đã có lỗi xảy ra, xin vui lòng thử lại\n" + ex.ToString(), "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            lsvNhanVien.Items.Clear();
            DataTable dt = nv.timKiemNhanVien(txtTimKiem.Text);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ListViewItem lvi = lsvNhanVien.Items.Add(dt.Rows[i][0].ToString());
                lvi.SubItems.Add(dt.Rows[i][1].ToString());
                lvi.SubItems.Add(dt.Rows[i][2].ToString());
                lvi.SubItems.Add(dt.Rows[i][3].ToString());
                lvi.SubItems.Add(dt.Rows[i][4].ToString());
                lvi.SubItems.Add(dt.Rows[i][5].ToString());
            }
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
        }

    }
}
