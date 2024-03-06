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

namespace QuanLyCuaHangDienThoai.GUI.QuanLyChucVu
{
    public partial class CTPQ_GUI : Form
    {
        CTPQ_BUS ctpq = new CTPQ_BUS();
        public string tenCV;
        public CTPQ_GUI()
        {
            InitializeComponent();

        }
        private void lvsCTPQ_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lsvCTPQ.SelectedIndices.Count > 0)
            {
                tenCV = lsvCTPQ.SelectedItems[0].SubItems[1].Text;
                cbMaPQ.SelectedIndex = cbMaPQ.FindString(lsvCTPQ.SelectedItems[0].SubItems[0].Text);
                cbTenPQ.SelectedIndex = cbTenPQ.FindString(lsvCTPQ.SelectedItems[0].SubItems[2].Text);
                btnThem.Enabled = true;
                btnXoa.Enabled = true;
                
            }
            else
            {
                cbMaPQ.Enabled = true;
            }
        }

        private void CTPQ_GUI_Load(object sender, EventArgs e)
        {
            lbTenCV.Text = tenCV;
            lsvCTPQ.FullRowSelect = true;
            lsvCTPQ.View = View.Details;
            
            lsvCTPQ.Columns.Add("Mã phân quyền");
            lsvCTPQ.Columns.Add("Tên chức vụ");
            lsvCTPQ.Columns.Add("Tên phân quyền");
            
            lsvCTPQ.Columns[0].Width = lsvCTPQ.Width / 3;
            lsvCTPQ.Columns[1].Width = lsvCTPQ.Width / 3;
            lsvCTPQ.Columns[2].Width = lsvCTPQ.Width / 3;

            loadCTPQ();
            loadPhanQuyen();
        }
        private void loadCTPQ()
        {
            lsvCTPQ.Items.Clear();
            DataTable dt = ctpq.laydanhsachPQ(tenCV);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ListViewItem lvi = lsvCTPQ.Items.Add(dt.Rows[i][0].ToString());
                lvi.SubItems.Add(dt.Rows[i][1].ToString());
                lvi.SubItems.Add(dt.Rows[i][2].ToString());
            }
        }
        private void loadPhanQuyen()
        {
            DataTable dt = ctpq.layDanhSachPhanQuyen();
            if (dt != null && dt.Rows.Count > 0)
            {
                cbMaPQ.DataSource = dt;
                cbMaPQ.ValueMember = "MAPQ";
                cbMaPQ.DisplayMember = "MAPQ";
                cbTenPQ.DataSource = dt;
                cbTenPQ.ValueMember = "TENPQ";
                cbTenPQ.DisplayMember = "TENPQ";
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                string maPhanQuyen = cbMaPQ.Text;
                string tenPhanQuyen = cbTenPQ.Text;

                if (!string.IsNullOrEmpty(maPhanQuyen) && !string.IsNullOrEmpty(tenPhanQuyen))
                {
                    
                    CTPQ_BUS ctpqBus = new CTPQ_BUS();
                    ctpqBus.themCTPQ(tenCV, maPhanQuyen);
                    MessageBox.Show("Đã thêm phân quyền thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    loadCTPQ();
                }
                else
                {
                    MessageBox.Show("Vui lòng chọn phân quyền và chức vụ trước khi thêm.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Phân quyền này tồn tại !!! ", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                if (lsvCTPQ.SelectedItems.Count > 0)
                {
                    string maPhanQuyen = lsvCTPQ.SelectedItems[0].SubItems[0].Text; // Lấy mã phân quyền từ dòng được chọn

                    CTPQ_BUS ctpqBus = new CTPQ_BUS();
                    ctpqBus.xoaCTPQ(maPhanQuyen);
                    MessageBox.Show("Đã xóa phân quyền thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    loadCTPQ(); // Gọi hàm loadCTPQ để cập nhật dữ liệu sau khi xóa
                }
                else
                {
                    MessageBox.Show("Vui lòng chọn phân quyền trước khi xóa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Có lỗi xảy ra: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


    }
}
