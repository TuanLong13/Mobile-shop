using DocumentFormat.OpenXml.Wordprocessing;
using QuanLyCuaHangDienThoai.BUS;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyCuaHangDienThoai.GUI.QuanLyKhuyenMai
{
    public partial class QuanLyKhuyenMaiFrm : UserControl
    {
        public KhuyenMaiBUS km_bus;

        public int ascending = 0;
        public string sortingColumn = null;

        public UI parent_f;
        private Them_Sua_KM them_sua_km;

        public QuanLyKhuyenMaiFrm()
        {
            InitializeComponent();
            km_bus = new KhuyenMaiBUS();
            HienThiKhuyenMai();
        }

        public void HienThiKhuyenMai()
        {
            KhuyenMaiListView.Clear();
            KhuyenMaiListView.Columns.Add("Mô tả khuyến mãi");
            KhuyenMaiListView.Columns.Add("Ngày bắt đầu");
            KhuyenMaiListView.Columns.Add("Ngày kết thúc");
            KhuyenMaiListView.Columns.Add("Tình trạng");

            for(int i = 0; i< km_bus.DsHienThi.Rows.Count; i++)
            {
                ListViewItem lvi = KhuyenMaiListView.Items.Add(km_bus.DsHienThi.Rows[i][1].ToString().Trim());
                lvi.SubItems.Add(DateTime.Parse(km_bus.DsHienThi.Rows[i][2].ToString()).ToString("dd/MM/yyyy HH:mm:ss"));
                lvi.SubItems.Add(DateTime.Parse(km_bus.DsHienThi.Rows[i][3].ToString()).ToString("dd/MM/yyyy HH:mm:ss"));
                if (DateTime.Parse(km_bus.DsHienThi.Rows[i][2].ToString()) <= DateTime.Now && DateTime.Now <= DateTime.Parse(km_bus.DsHienThi.Rows[i][3].ToString()))
                {
                    lvi.SubItems.Add("Đang diễn ra");
                }
                else if (DateTime.Now < DateTime.Parse(km_bus.DsHienThi.Rows[i][2].ToString()))
                {
                    lvi.SubItems.Add("Sắp diễn ra");
                }
                else if (DateTime.Now > DateTime.Parse(km_bus.DsHienThi.Rows[i][3].ToString()))
                {
                    lvi.SubItems.Add("Kết thúc");
                }
                lvi.Tag = km_bus.DsHienThi.Rows[i][0].ToString();
            }

            resizeTableKhuyenMai();
        }

        public void resizeTableKhuyenMai()
        {
            for (int i = 0; i < 4; i++)
            {
                KhuyenMaiListView.Columns[i].Width = KhuyenMaiListView.Width / 4;
            }
        }

        private void refreshBtn_Click(object sender, EventArgs e)
        {
            ReLoad();
        }
        public void ReLoad()
        {
            km_bus = new KhuyenMaiBUS();
            HienThiKhuyenMai();
        }

        private void KhuyenMaiListView_SizeChanged(object sender, EventArgs e)
        {
            resizeTableKhuyenMai();
        }

        private void timKiemBtn_Click(object sender, EventArgs e)
        {
            km_bus.timKiem(timKiemKMtxt.Text);
            HienThiKhuyenMai();
        }

        private void KhuyenMaiListView_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            ColumnHeader columnHeader = KhuyenMaiListView.Columns[e.Column];

            if(columnHeader.Text == sortingColumn)
            {
                switch (ascending)
                {
                    case 0: ascending = 1;break;
                    case 1: ascending = 2; break;
                    case 2: ascending = 0; break;
                }
            }
            else
            {
                if(columnHeader.Text == "Tình trạng")
                {
                    return;
                }
                sortingColumn = columnHeader.Text;
                ascending = 1;
            }
            km_bus.sapXep(sortingColumn, ascending);
            HienThiKhuyenMai();
        }
        // Gắn hành động cho nút Thêm
        private void themBtn_Click(object sender, EventArgs e)
        {
            them_sua_km = new Them_Sua_KM(this, km_bus);
            them_sua_km.Dock = DockStyle.Fill;
            parent_f.splitContainer2.Panel2.Controls.Clear();
            parent_f.splitContainer2.Panel2.Controls.Add(them_sua_km);
        }

        // Gắn hành động cho nút Cập nhật
        private void button2_Click(object sender, EventArgs e)
        {
            if (KhuyenMaiListView.SelectedIndices.Count > 0)
            {

                if (KhuyenMaiListView.SelectedItems[0].SubItems[3].Text == "Sắp diễn ra" || KhuyenMaiListView.SelectedItems[0].SubItems[3].Text == "Đang diễn ra")
                {
                    km_bus.khuyenMaiChon = km_bus.dsKhuyenMai.Rows[KhuyenMaiListView.SelectedIndices[0]];
                    Them_Sua_KM them_sua_km = new Them_Sua_KM(this, km_bus, true);
                    them_sua_km.Dock = DockStyle.Fill;
                    parent_f.splitContainer2.Panel2.Controls.Clear();
                    parent_f.splitContainer2.Panel2.Controls.Add(them_sua_km);
                }
                else
                {
                    MessageBox.Show("Chỉ chỉnh sửa các đợt khuyến mãi chưa diễn ra");
                }
            }
            else
            {
                MessageBox.Show("Bạn phải chọn 1 khuyến mãi");
            }
        }
        // lấy khuyến mãi đã chọn 
        private void KhuyenMaiListView_Click(object sender, EventArgs e)
        {
            if (KhuyenMaiListView.SelectedIndices.Count > 0)
            {
                km_bus.khuyenMaiChon = km_bus.dsKhuyenMai.Rows[KhuyenMaiListView.SelectedIndices[0]];
            }
        }

        // Gắn hành động cho nút Xóa
        private void button1_Click(object sender, EventArgs e)
        {
            if (KhuyenMaiListView.SelectedIndices.Count > 0)
            {
                if (KhuyenMaiListView.Items[KhuyenMaiListView.SelectedIndices[0]].SubItems[3].Text == "Sắp diễn ra")
                {
                    int makm_xoa = Int32.Parse(KhuyenMaiListView.Items[KhuyenMaiListView.SelectedIndices[0]].Tag.ToString());
                    /*MessageBox.Show(makm_xoa + "");*/
                    try
                    {
                        km_bus.xoaDotKhuyenMai(makm_xoa);
                        MessageBox.Show("Xóa 1 đợt khuyến mãi thành công");
                        ReLoad();
                    }
                    catch (Exception ex)
                    { MessageBox.Show("Xóa thất bại lỗi : "+ ex.Message); }
                    
                }
                else
                    MessageBox.Show("Bản phải chọn đợt khuyến mãi chưa xảy ra");
            }
            else
                MessageBox.Show("Bạn phải chọn 1 khuyến mãi");
        }

        private void KhuyenMaiListView_DoubleClick(object sender, EventArgs e)
        {
            if(KhuyenMaiListView.SelectedIndices.Count > 0)
            {
                new ChiTietKhuyenMai(Int32.Parse(KhuyenMaiListView.SelectedItems[0].Tag.ToString())).Show();
            }
        }
    }
}
