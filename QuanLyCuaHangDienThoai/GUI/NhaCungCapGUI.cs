using DocumentFormat.OpenXml.Spreadsheet;
using QuanLyCuaHangDienThoai.BUS;
using QuanLyCuaHangDienThoai.DTO;
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
using System.Xml.Linq;

namespace QuanLyCuaHangDienThoai.GUI.QuanLySanPham
{
    public partial class NhaCungCapGUI : UserControl
    {
        public NhaCungCapGUI()
        {
            InitializeComponent();
        }
        NhaCungCap_BUS busNCC = new NhaCungCap_BUS();

        private void NhaCungCap_GUI_Load(object sender, EventArgs e)
        {
            lsvNCC.FullRowSelect = true;
            lsvNCC.View = View.Details;
            lsvNCC.Columns.Add("Mã nhà cung cấp");
            lsvNCC.Columns.Add("Tên nhà cung cấp");
            lsvNCC.Columns.Add("Địa chỉ");
            lsvNCC.Columns.Add("Số điện thoại");
            lsvNCC.Columns[0].Width = 0;
            lsvNCC.Columns[1].Width = this.Width / 3;
            lsvNCC.Columns[2].Width = this.Width / 3;
            lsvNCC.Columns[3].Width = this.Width / 3;
            loadNhaCungCap();
        }
        public void loadNhaCungCap()
        {
            lsvNCC.Items.Clear();
            DataTable dt = busNCC.LayDSNhaCungCap();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ListViewItem lvi = lsvNCC.Items.Add(dt.Rows[i][0].ToString());
                lvi.SubItems.Add(dt.Rows[i][1].ToString());
                lvi.SubItems.Add(dt.Rows[i][2].ToString());
                lvi.SubItems.Add(dt.Rows[i][3].ToString());
            }
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (txtTenNCC.Text.Trim() == "" || txtDiaChi.Text.Trim() == "" || txtSDT.Text.Trim() == "")
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                Regex regex = new Regex(@"^0\d{9}$");
                if (regex.IsMatch(txtSDT.Text))
                {
                    if (busNCC.kiemTraSDT(txtSDT.Text))
                    {
                        if (busNCC.KiemTraTonTai(txtTenNCC.Text))
                        {
                            NhaCungCapDTO tv = new NhaCungCapDTO(0, txtTenNCC.Text, txtDiaChi.Text, txtSDT.Text);
                            busNCC.themNhaCungCap(tv);
                            MessageBox.Show("Thêm thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            loadNhaCungCap();
                        }
                        else
                        {
                            MessageBox.Show("Tên nhà cung cấp này đã tồn tại. Vui lòng nhập lại tên khác", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            txtTenNCC.Focus();
                        }    
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
        }
        private void btnXoa_Click(object sender, EventArgs e)
        {
            string ID = lsvNCC.SelectedItems[0].SubItems[0].Text;
            if (busNCC.KiemTraThamChieu(ID))
            {
                MessageBox.Show("Không thể xóa vì nhà cung cấp này đã tồn tại trong danh sách đơn nhập", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                //int indexRow = dgvNCC.CurrentCell.RowIndex;

                if (MessageBox.Show("Bạn có chắc là muốn xóa không?", "Đang xóa...", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    //   dgvNCC.Rows.RemoveAt(indexRow);
                    busNCC.xoaNhaCungCap(ID);
                    MessageBox.Show("Xóa thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    loadNhaCungCap();
                }
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (txtTenNCC.Text.Trim() == "" || txtDiaChi.Text.Trim() == "" || txtSDT.Text.Trim() == "")
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                Regex regex = new Regex(@"^0\d{9}$");
                if (regex.IsMatch(txtSDT.Text))
                {
                    if (busNCC.kiemTraSDT(txtSDT.Text) || txtSDT.Text.Equals(lsvNCC.SelectedItems[0].SubItems[3].Text))
                    {
                        if (busNCC.KiemTraTonTai(txtTenNCC.Text) || txtTenNCC.Text.Equals(lsvNCC.SelectedItems[0].SubItems[1].Text))
                        {
                            NhaCungCapDTO tv = new NhaCungCapDTO(Int32.Parse(lsvNCC.SelectedItems[0].SubItems[0].Text), txtTenNCC.Text, txtDiaChi.Text, txtSDT.Text);
                            busNCC.suaNhaCungCap(tv);
                            MessageBox.Show("Sửa nhà cung cấp thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            loadNhaCungCap();
                        }
                        else
                        {
                            MessageBox.Show("Tên nhà cung cấp này đã tồn tại. Vui lòng nhập lại tên khác", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            txtTenNCC.Focus();
                        }    
                         
                    }
                    else
                    {
                        MessageBox.Show("Số điện thoại này đã tồn tại. Vui lòng nhập lại số khác", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txtSDT.Focus();
                    }
                }
                else
                {
                    MessageBox.Show("Số điện thoại không hợp lệ. Số điện thoại hợp lệ phải bắt đầu từ 0 và đủ 10 số. ", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtSDT.Focus();
                }
            }
        }
        private void lsvNCC_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lsvNCC.SelectedIndices.Count > 0)
            {
                txtTenNCC.Text = lsvNCC.SelectedItems[0].SubItems[1].Text;
                txtDiaChi.Text = lsvNCC.SelectedItems[0].SubItems[2].Text;
                txtSDT.Text = lsvNCC.SelectedItems[0].SubItems[3].Text;
                btnSua.Enabled = true;
                btnXoa.Enabled = true;
            }
            else
            {
                btnSua.Enabled = false;
                btnXoa.Enabled = false;
            }    
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            lsvNCC.Items.Clear();
            DataTable dt = busNCC.timKiemNhaCungCap(txtTimKiem.Text);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ListViewItem lvi = lsvNCC.Items.Add(dt.Rows[i][0].ToString());
                lvi.SubItems.Add(dt.Rows[i][1].ToString());
                lvi.SubItems.Add(dt.Rows[i][2].ToString());
                lvi.SubItems.Add(dt.Rows[i][3].ToString());
            }
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
        }
    }  

}


