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

namespace QuanLyCuaHangDienThoai.GUI.QuanLyChucVu
{
    public partial class CVPQ_GUI : UserControl
    {
        ChucVu_BUS cv = new ChucVu_BUS();
        PhanQuyen_BUS pq = new PhanQuyen_BUS();
        public string maPQ;
        public CVPQ_GUI()
        {
            InitializeComponent();
        }
        private void CVPQ_GUI_Load(object sender, EventArgs e)
        {
            //TabChucVu
            lsvChucVu.FullRowSelect = true;
            lsvChucVu.View = View.Details;
            lsvChucVu.Columns.Add("Mã chức vụ");
            lsvChucVu.Columns.Add("Tên chức vụ");
            lsvChucVu.Columns[0].Width = this.Width / 2;
            lsvChucVu.Columns[1].Width = this.Width / 2;
            loadChucVu();
            //TabPhanQuyen
            lsvPhanQuyen.FullRowSelect = true;
            lsvPhanQuyen.View = View.Details;
            lsvPhanQuyen.Columns.Add("Mã phân quyền");
            lsvPhanQuyen.Columns.Add("Tên phân quyền");
            lsvPhanQuyen.Columns[0].Width = this.Width / 2;
            lsvPhanQuyen.Columns[1].Width = this.Width / 2;
            loadPhanQuyen();
        }
        //ChucVu
        private void loadChucVu()
        {
            lsvChucVu.Items.Clear();
            DataTable dt = cv.layDanhSachChucVu();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ListViewItem lvi = lsvChucVu.Items.Add(dt.Rows[i][0].ToString());
                lvi.SubItems.Add(dt.Rows[i][1].ToString());
            }
            btnSuaCV.Enabled = false;
            btnXoaCV.Enabled = false;
            btnCTPhanQuyen.Enabled = false;

        }
        private void lsvChucVu_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lsvChucVu.SelectedIndices.Count > 0)
            {
                string maChucVu = lsvChucVu.SelectedItems[0].SubItems[0].Text;
                txtTenCV.Text = lsvChucVu.SelectedItems[0].SubItems[1].Text;
                btnSuaCV.Enabled = true;
                btnXoaCV.Enabled = true;
                btnCTPhanQuyen.Enabled = true;
            }
        }
        private void btnThemCV_Click(object sender, EventArgs e)
        {
            string ten = txtTenCV.Text;
            if (!ten.Equals(""))
            {
                cv.themChucVu(ten);
                MessageBox.Show("Thêm chức vụ thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                loadChucVu();
            }
            else
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin trước khi thêm", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnSuaCV_Click(object sender, EventArgs e)
        {
            string ten = txtTenCV.Text;
            if (!ten.Equals(""))
            {
                if (ten.All(s => Char.IsLetter(s) || s == ' '))
                {
                    cv.suaChucVu(lsvChucVu.SelectedItems[0].SubItems[0].Text, ten);
                    MessageBox.Show("Sửa chức vụ thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    loadChucVu();
                }
                else
                {
                    MessageBox.Show("Tên chức vụ chỉ được phép nhập chữ", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtTenCV.Focus();
                }
            }
            else
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin trước khi thêm", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }
        private void btnXoaCV_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult dr = MessageBox.Show("Bạn có chắc muốn xóa khách hàng này?", "Xóa thông tin", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dr == DialogResult.Yes)
                {
                    cv.xoaChucVu(lsvChucVu.SelectedItems[0].SubItems[0].Text);
                    loadChucVu();
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Đã có lỗi xảy ra, xin vui lòng thử lại\n" + ex.ToString(), "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnTimKiemCV_Click(object sender, EventArgs e)
        {
            lsvChucVu.Items.Clear();
            DataTable dt = cv.timKiemChucVu(txtTimKiemCV.Text);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ListViewItem lvi = lsvChucVu.Items.Add(dt.Rows[i][0].ToString());
                lvi.SubItems.Add(dt.Rows[i][1].ToString());
            }
            btnSuaCV.Enabled = false;
            btnXoaCV.Enabled = false;
            btnCTPhanQuyen.Enabled = false;
        }
        //PhanQuyen
        private void loadPhanQuyen()
        {
            lsvPhanQuyen.Items.Clear();
            DataTable dt = pq.layDanhSachPhanQuyen();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ListViewItem lvi = lsvPhanQuyen.Items.Add(dt.Rows[i][0].ToString());
                lvi.SubItems.Add(dt.Rows[i][1].ToString());
            }
/*            btnSuaPQ.Enabled = false;
            btnXoaPQ.Enabled = false;*/
            /*btnThemPQ.Enabled = false;*/
        }
        private void lsvPhanQuyen_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lsvPhanQuyen.SelectedIndices.Count > 0)
            {
                maPQ = lsvPhanQuyen.SelectedItems[0].SubItems[0].Text;
/*                txtTenPQ.Text = lsvPhanQuyen.SelectedItems[0].SubItems[1].Text;
                btnSuaPQ.Enabled = false;
                btnXoaPQ.Enabled = false;*/
                /*btnThemPQ.Enabled = false;*/
            }
        }
        private void btnThemPQ_Click(object sender, EventArgs e)
        {
            /*string ten = txtTenPQ.Text;
            if (!ten.Equals(""))
            {
                pq.themPQ(ten);
                MessageBox.Show("Thêm chức vụ thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                loadPhanQuyen();
            }
            else
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin trước khi thêm", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }*/
        }
        private void btnSuaPQ_Click(object sender, EventArgs e)
        {
            /*string ten = txtTenPQ.Text;
            if (!ten.Equals(""))
            {
                if (ten.All(s => Char.IsLetter(s) || s == ' '))
                {
                    pq.suaPQ(lsvPhanQuyen.SelectedItems[0].SubItems[0].Text, ten);
                    MessageBox.Show("Sửa chức vụ thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    loadPhanQuyen();
                }
                else
                {
                    MessageBox.Show("Tên chức vụ chỉ được phép nhập chữ", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtTenPQ.Focus();
                }
            }
            else
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin trước khi thêm", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }*/


        }
        private void btnXoaPQ_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult dr = MessageBox.Show("Bạn có chắc muốn xóa khách hàng này?", "Xóa thông tin", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dr == DialogResult.Yes)
                {
                    pq.xoaPQ(lsvPhanQuyen.SelectedItems[0].SubItems[0].Text);
                    loadPhanQuyen();
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Đã có lỗi xảy ra, xin vui lòng thử lại\n" + ex.ToString(), "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnTimKiemPQ_Click(object sender, EventArgs e)
        {
            lsvPhanQuyen.Items.Clear();
            DataTable dt = pq.timKiemPQ(txtTimkiemPQ.Text);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ListViewItem lvi = lsvPhanQuyen.Items.Add(dt.Rows[i][0].ToString());
                lvi.SubItems.Add(dt.Rows[i][1].ToString());
            }
            /*btnSuaPQ.Enabled = false;
            btnXoaPQ.Enabled = false;*/
            
        }
        private void tabPage2_Click(object sender, EventArgs e)
        {
            loadChucVu();
        }

        private void btnCTPhanQuyen_Click(object sender, EventArgs e)
        {

            CTPQ_GUI ctpq = new CTPQ_GUI();
            ctpq.tenCV = txtTenCV.Text;
            ctpq.ShowDialog();
        }

        private void btnLoadPQ_Click(object sender, EventArgs e)
        {
            loadPhanQuyen();
            /*txtTenPQ.Clear();*/
            txtTimkiemPQ.Clear();
        }

        private void btnLoadCV_Click(object sender, EventArgs e)
        {
            loadChucVu();
            txtTenCV.Clear();
            txtTimKiemCV.Clear();
        }
    }
}
