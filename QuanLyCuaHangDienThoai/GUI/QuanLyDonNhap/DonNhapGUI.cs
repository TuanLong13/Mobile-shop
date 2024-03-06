using QuanLyCuaHangDienThoai.DTO;
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
using QuanLyCuaHangDienThoai.GUI.QuanLyDonNhap;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;
using System.Windows.Media;

namespace QuanLyCuaHangDienThoai.GUI
{
    public partial class DonNhapGUI : UserControl
    {

        DonNhapBUS busDN = new DonNhapBUS();
        CTDonNhapBUS busCT = new CTDonNhapBUS();
        public string username;
        public DonNhapGUI()
        {
            InitializeComponent();
        }
        private void DonNhap_GUI_Load(object sender, EventArgs e)
        {
            lsvSanPham.FullRowSelect = true;
            lsvSanPham.View = View.Details;
            lsvSanPham.Columns.Add("Mã sản phẩm");
            lsvSanPham.Columns.Add("Tên sản phẩm");
            lsvSanPham.Columns.Add("Hãng");
            lsvSanPham.Columns.Add("Đơn giá");
            lsvSanPham.Columns.Add("Số lượng");


            lsvCTDonNhap.FullRowSelect = true;
            lsvCTDonNhap.View = View.Details;
            lsvCTDonNhap.Columns.Add("Mã sản phẩm");
            lsvCTDonNhap.Columns.Add("Tên sản phẩm");
            lsvCTDonNhap.Columns.Add("Đơn giá");
            lsvCTDonNhap.Columns.Add("Số lượng mua");
            lsvCTDonNhap.Columns.Add("Thành tiền");
            lsvCTDonNhap.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
            lsvCTDonNhap.Columns[0].Width = 0;

            loadSanPham();
            btnXoaCT.Enabled = btnNhapHang.Enabled = false;

            cbNCC.DataSource = busDN.layNCC();
            cbNCC.DisplayMember = "tencc";
            cbNCC.ValueMember = "mancc";
            cbNCC.SelectedIndex = 0;

            loadDonNhap();
        }
        //tab lập
        private void loadSanPham()
        {
            lsvSanPham.Items.Clear();
            DataTable dt = busDN.LayDSSanPham();
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
        public void loadDonNhap()
        {
            dgvDN.DataSource = busDN.LayDSDonNhap();
            dgvDN.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvDN.Columns[0].Width = 0;
            cmbNcc.DataSource = busDN.LayDataCB("tencc", "NhaCungCap");
            cmbNcc.DisplayMember = "tencc";
            cmbNv.DataSource = busDN.LayDataCB("tennv", "NhanVien");
            cmbNv.DisplayMember = "tennv";
            btnXoa.Enabled = btnSua.Enabled = false;
        }
        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            lsvSanPham.Items.Clear();
            DataTable dt = busDN.timKiemSanPham(txtTimKiem.Text);
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
            numSoluong.Enabled = false;
            btnThem.Enabled = false;

            for (int i = 0; i < lsvCTDonNhap.Items.Count; i++)
            {
                string ma = lsvCTDonNhap.Items[i].SubItems[0].Text;
                for (int j = 0; j < lsvSanPham.Items.Count; j++)
                {
                    if (ma.Equals(lsvSanPham.Items[j].SubItems[0].Text))
                    {
                        int soLuongHienTai = Int32.Parse(lsvSanPham.Items[j].SubItems[4].Text) - Int32.Parse(lsvCTDonNhap.Items[i].SubItems[3].Text);
                        lsvSanPham.Items[j].SubItems[4].Text = soLuongHienTai.ToString();
                        break;
                    }
                }
            }
        }
        /*        private void btnConfirm_Click(object sender, EventArgs e)
                {
                    if (dgvCT.Rows.Count > 0)
                    {
                        double total = 0;
                        for (int i = 0; i < dgvCT.Rows.Count; ++i)
                        {
                            total += (Convert.ToDouble(dgvCT.Rows[i].Cells[1].Value) * Convert.ToDouble(dgvCT.Rows[i].Cells[2].Value));
                        }
                        //Thêm đơn nhập
                        DonNhapDTO tv = new DonNhapDTO(0, cbNCC.Text, username, long.Parse(Convert.ToString(total)), DateTime.Now);
                        int madn = busDN.ThemDonNhap(tv);
                        foreach (DataGridViewRow row in dgvCT.Rows)
                        {
                            if (!row.IsNewRow)
                            {
                                string[] parts = Convert.ToString(row.Cells[1].Value).Split('.');
                                ChiTietDonNhapDTO ct = new ChiTietDonNhapDTO(madn, (row.Cells[0].Value).ToString(), long.Parse(parts[0]), Convert.ToInt16((row.Cells[2].Value).ToString()));
                                busCT.ThemCTDonNhap(ct);
                            }
                        }
                        dgvCT.Rows.Clear();
                        MessageBox.Show("Thêm thành công");
                        DonNhap_GUI_Load(sender, e);
                    }
                    else
                    {
                        MessageBox.Show("Không có dữ liệu để lập phiếu nhập.");
                    }
                }
        */

        private void btnXoaCT_Click(object sender, EventArgs e)
        {
            if (lsvCTDonNhap.SelectedIndices.Count > 0)
            {
                lsvCTDonNhap.Items.Remove(lsvCTDonNhap.SelectedItems[0]);
                btnXoa.Enabled = false;
                tinhTongTien();
            }
        }
        private void tinhTongTien()
        {
            double tongtien = 0;
            for (int i = 0; i < lsvCTDonNhap.Items.Count; i++)
            {
                tongtien += double.Parse(lsvCTDonNhap.Items[i].SubItems[4].Text);
            }

            if (tongtien == 0)
            {
                btnNhapHang.Enabled = btnXoaCT.Enabled = false;
            }
            else
            {
                btnNhapHang.Enabled = btnXoaCT.Enabled = true;
            }
            txtTongTien.Text = tongtien.ToString();
        }
        private void btnThem_Click(object sender, EventArgs e)
        {
            int soluong = Int32.Parse(numSoluong.Value.ToString());
            double gianhap;
            if (lsvSanPham.SelectedIndices.Count > 0 && soluong > 0)
            {
                if (double.TryParse(txtGiaNhap.Text, out gianhap) )
                {
                    if (gianhap > 0)
                    {
                        for (int i = 0; i < lsvCTDonNhap.Items.Count; i++)
                        {
                            if (lsvCTDonNhap.Items[i].SubItems[0].Text.Equals(lsvSanPham.SelectedItems[0].SubItems[0].Text))
                            {
                                lsvCTDonNhap.Items[i].SubItems[3].Text = (Int32.Parse(lsvCTDonNhap.Items[i].SubItems[3].Text) + soluong).ToString();
                                double thanhtienmoi = double.Parse(lsvCTDonNhap.Items[i].SubItems[2].Text) * Int32.Parse(lsvCTDonNhap.Items[i].SubItems[3].Text);
                                lsvCTDonNhap.Items[i].SubItems[4].Text = thanhtienmoi.ToString();
                                numSoluong.Enabled = false;
                                btnThem.Enabled = false;
                                btnNhapHang.Enabled = true;

                                tinhTongTien();
                                return;
                            }
                        }

                        ListViewItem lvi = lsvCTDonNhap.Items.Add(lsvSanPham.SelectedItems[0].SubItems[0].Text);
                        lvi.SubItems.Add(lsvSanPham.SelectedItems[0].SubItems[1].Text);
                        lvi.SubItems.Add(gianhap.ToString());
                        lvi.SubItems.Add(numSoluong.Value.ToString());
                        double thanhtien = gianhap * soluong;
                        lvi.SubItems.Add(thanhtien.ToString());
                        lsvCTDonNhap.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
                        lsvCTDonNhap.Columns[0].Width = 0;
                        lsvCTDonNhap.AutoResizeColumn(3, ColumnHeaderAutoResizeStyle.HeaderSize);

                        txtGiaNhap.Text = "";
                        numSoluong.Enabled = false;
                        btnThem.Enabled = false;

                        tinhTongTien();
                    }
                    else
                    {
                        MessageBox.Show("Giá nhập chỉ được nhập số lớn hơn 0", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txtGiaNhap.Focus();
                    }    
                }
                else
                {
                    MessageBox.Show("Giá nhập chỉ được nhập số lớn hơn 0", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtGiaNhap.Focus();
                }    
            }
            else
            {
                MessageBox.Show("Số lượng nhập phải lớn hơn 0", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void lsvSanPham_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lsvSanPham.SelectedIndices.Count > 0)
            {
                btnThem.Enabled = true;
                numSoluong.Enabled = true;
                numSoluong.Value = 0;
                txtGiaNhap.Enabled = true;
            }
            else
            {
                btnThem.Enabled = false;
                numSoluong.Enabled = false;
                txtGiaNhap.Enabled = false;
            }
        }

        private void lsvCTDonNhap_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lsvCTDonNhap.SelectedIndices.Count > 0)
            {
                btnXoaCT.Enabled = true;
            }
            else
            {
                btnXoaCT.Enabled = false;
            }
        }

        private void btnNhapHang_Click(object sender, EventArgs e)
        {
            string mancc = cbNCC.SelectedValue.ToString();
            DataTable dt = busDN.layMa("taikhoan", "username", "manv, username", username);
            string manv = dt.Rows[0][0].ToString();
            double tongtien = double.Parse(txtTongTien.Text);
            DonNhapDTO dn = new DonNhapDTO(0, mancc, manv, tongtien, DateTime.Now);
            int madn = busDN.ThemDonNhap(dn);
            for (int i = 0; i < lsvCTDonNhap.Items.Count; i++)
            {
                ChiTietDonNhapDTO ct = new ChiTietDonNhapDTO(madn, lsvCTDonNhap.Items[i].SubItems[0].Text, double.Parse(lsvCTDonNhap.Items[i].SubItems[2].Text), Int32.Parse(lsvCTDonNhap.Items[i].SubItems[3].Text));
                busCT.ThemCTDonNhap(ct);
            }
            MessageBox.Show("Nhập hàng thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            loadSanPham();
            lsvCTDonNhap.Items.Clear();
            btnNhapHang.Enabled = btnXoaCT.Enabled = false;
            txtTongTien.Text = "";
        }
        //tab quản lý
        private void dgvDN_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = dgvDN.Rows[e.RowIndex];
            cmbNcc.Text = Convert.ToString(row.Cells[1].Value);
            cmbNv.Text = Convert.ToString(row.Cells[2].Value);
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            int ID = Convert.ToInt16(dgvDN.SelectedRows[0].Cells[0].Value.ToString());
            DonNhapDTO cc = new DonNhapDTO(ID, cmbNcc.Text, cmbNv.Text, 0, DateTime.Now);
            busDN.CapNhatDonNhap(cc);
            MessageBox.Show("Sửa thành công");
            DonNhap_GUI_Load(sender, e);
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            int indexRow = dgvDN.CurrentCell.RowIndex;
            int ID = Convert.ToInt16(dgvDN.SelectedRows[0].Cells[0].Value.ToString());
            if (MessageBox.Show("Bạn có chắc là muốn xóa không?", "Đang xóa...", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                dgvDN.Rows.RemoveAt(indexRow);
                busDN.XoaDonNhap(ID);

                MessageBox.Show("Xóa thành công");
                DonNhap_GUI_Load(sender, e);
            }
        }
        string ten;
        private void btnTim_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text == "")
            {
                MessageBox.Show("Chọn thông tin cần tìm");
            }
            else
            {
                switch (comboBox1.Text)
                {
                    case "Nhà cung cấp":
                        {
                            ten = cmbNcc.Text;
                            break;
                        }
                    case "Nhân viên":
                        {
                            ten = cmbNv.Text;
                            break;
                        }
                }
                dgvDN.DataSource = busDN.TimDonNhap(comboBox1.Text, ten);
            }
        }
        private void dgvDN_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dgvDN.Rows[e.RowIndex];

                int ID = Convert.ToInt16(row.Cells[0].Value.ToString());
                string ncc = row.Cells[1].Value.ToString();
                string nv = row.Cells[2].Value.ToString();

                CTDonNhapGUI ct = new CTDonNhapGUI(ID, ncc, nv);
                ct.ShowDialog();
            }
        }

        private void dgvDN_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if( dgvDN.SelectedRows.Count > 0)
            {
                btnSua.Enabled = true;
                btnXoa.Enabled = true;
                cmbNcc.SelectedIndex = cmbNcc.FindString(dgvDN.SelectedRows[0].Cells[1].ToString());
                cmbNv.SelectedIndex = cmbNv.FindString(dgvDN.SelectedRows[0].Cells[2].ToString());
            }
            else
            {
                btnSua.Enabled = false;
                btnXoa.Enabled = false;
            }    
        }

        private void tabPage2_Click(object sender, EventArgs e)
        {
            loadDonNhap();
        }
    }

}
