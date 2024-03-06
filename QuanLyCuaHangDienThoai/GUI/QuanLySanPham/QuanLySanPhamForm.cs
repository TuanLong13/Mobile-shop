using QuanLyCuaHangDienThoai.BUS;
using QuanLyCuaHangDienThoai.DTO;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace QuanLyCuaHangDienThoai.GUI.QuanLySanPham
{
    public partial class QuanLySanPhamForm : UserControl
    {
        SanPhamBUS sp_bus;
        Them_Sua_SanPhamForm themSpForm;
        public UI parent_f;
        public QuanLySanPhamForm()
        {
            InitializeComponent();
            sp_bus = new SanPhamBUS();
            hienThiSanPham();
            loadHang();
        }

        public void loadHang()
        {
            sp_bus.layDanhSachHang();
            ArrayList dsHang = sp_bus.DsHang;
            HangPanel.Controls.Clear();
            for (int i = 0; i < dsHang.Count; i++)
            {
                CheckBox checkBox = new CheckBox();
                checkBox.Text = dsHang[i].ToString();
                checkBox.Font = new Font("Arial", 12);
                checkBox.Checked = true;
                checkBox.CheckStateChanged += new EventHandler(this.locBoiHang);
                HangPanel.Controls.Add(checkBox);
            }
        }

        public void hienThiSanPham()
        {
            SanPhamListView.Clear();
            SanPhamListView.Columns.Add("Hình ảnh");
            SanPhamListView.Columns.Add("Tên sản phẩm");
            SanPhamListView.Columns.Add("Hệ điều hành");
            SanPhamListView.Columns.Add("Camera");
            SanPhamListView.Columns.Add("Chip");
            SanPhamListView.Columns.Add("Ram");
            SanPhamListView.Columns.Add("Dung lượng");
            SanPhamListView.Columns.Add("Pin");

            SanPhamListView.Columns.Add("Giá");
            SanPhamListView.Columns[7].TextAlign = HorizontalAlignment.Right;

            SanPhamListView.Columns.Add("Số lượng");
            SanPhamListView.Columns[8].TextAlign = HorizontalAlignment.Right;

            ImageList imageList = new ImageList();
            imageList.ImageSize = new Size(32, 32);
            SanPhamListView.SmallImageList = imageList;

            for (int i = 0; i < sp_bus.DsHienThi.Rows.Count; i++)
            {

                ListViewItem lvi = new ListViewItem();
                if (File.Exists(AppDomain.CurrentDomain.BaseDirectory + "\\..\\..\\img\\dienthoai\\" + sp_bus.DsHienThi.Rows[i][2].ToString() + ".png"))
                {
                    imageList.Images.Add(Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "\\..\\..\\img\\dienthoai\\" + sp_bus.DsHienThi.Rows[i][2].ToString() + ".png"));
                }
                else
                {
                    imageList.Images.Add(Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "\\..\\..\\img\\dienthoai\\notfound.png"));
                }
                lvi.ImageIndex = imageList.Images.Count - 1;
                lvi.SubItems.Add(sp_bus.DsHienThi.Rows[i][1].ToString());
                lvi.SubItems.Add(sp_bus.DsHienThi.Rows[i][12].ToString());
                lvi.SubItems.Add(sp_bus.DsHienThi.Rows[i][17].ToString());
                lvi.SubItems.Add(sp_bus.DsHienThi.Rows[i][7].ToString());
                lvi.SubItems.Add(sp_bus.DsHienThi.Rows[i][9].ToString());
                lvi.SubItems.Add(sp_bus.DsHienThi.Rows[i][10].ToString());
                lvi.SubItems.Add(sp_bus.DsHienThi.Rows[i][15].ToString());
                lvi.SubItems.Add(Int64.Parse(sp_bus.DsHienThi.Rows[i][5].ToString().Split('.')[0]).ToString("C", System.Globalization.CultureInfo.GetCultureInfo("vi-Vn")));
                lvi.SubItems.Add(sp_bus.DsHienThi.Rows[i][6].ToString());
                SanPhamListView.Items.Add(lvi);
            }
            resizeTableSanPham();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            themSpForm = new Them_Sua_SanPhamForm(this, sp_bus);
            themSpForm.Dock = DockStyle.Fill;
            parent_f.splitContainer2.Panel2.Controls.Clear();
            parent_f.splitContainer2.Panel2.Controls.Add(themSpForm);
        }

        public void resizeTableSanPham()
        {
            SanPhamListView.Columns[0].Width = SanPhamListView.Width / 100 * 7;
            SanPhamListView.Columns[1].Width = SanPhamListView.Width / 100 * 20;
            SanPhamListView.Columns[2].Width = SanPhamListView.Width / 100 * 10;
            SanPhamListView.Columns[3].Width = SanPhamListView.Width / 100 * 20;
            SanPhamListView.Columns[4].Width = SanPhamListView.Width / 100 * 10;
            SanPhamListView.Columns[5].Width = SanPhamListView.Width / 100 * 5;
            SanPhamListView.Columns[6].Width = SanPhamListView.Width / 100 * 8;
            SanPhamListView.Columns[7].Width = SanPhamListView.Width / 100 * 10;
            SanPhamListView.Columns[8].Width = SanPhamListView.Width / 100 * 10;
            SanPhamListView.Columns[9].Width = SanPhamListView.Width / 100 * 5;
        }

        private void button3_Click(object sender, EventArgs e)
        {

            if (SanPhamListView.SelectedIndices.Count > 0)
            {
                themSpForm = new Them_Sua_SanPhamForm(this, sp_bus, true);
                themSpForm.Dock = DockStyle.Fill;
                parent_f.splitContainer2.Panel2.Controls.Clear();
                parent_f.splitContainer2.Panel2.Controls.Add(themSpForm);
            }
            else
            {
                MessageBox.Show("Bạn phải chọn sản phẩm muốn chỉnh sửa");
            }
        }

        private void SanPhamListView_SizeChanged(object sender, EventArgs e)
        {
            resizeTableSanPham();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            sp_bus.timKiem(timKiemSPtxt.Text.Trim().ToLower());
            hienThiSanPham();
            loadHang();
        }

        private void SanPhamListView_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            ColumnHeader clickedColumn = SanPhamListView.Columns[e.Column];
            sp_bus.sapXep(clickedColumn.Text);
            hienThiSanPham();
        }

        public void ReLoad()
        {
            sp_bus = new SanPhamBUS();
            hienThiSanPham();
        }

        private void locBoiHang(object sender, EventArgs e)
        {
            ArrayList hang = new ArrayList();
            for (int i = 0; i < HangPanel.Controls.Count; i++)
            {
                if (((CheckBox)HangPanel.Controls[i]).Checked)
                {
                    hang.Add(((CheckBox)HangPanel.Controls[i]).Text);
                }
            }
            sp_bus.filterByBrand(hang, timKiemSPtxt.Text.ToLower().Trim());
            hienThiSanPham();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            ReLoad();
        }

        private void SanPhamListView_Click(object sender, EventArgs e)
        {
            if (SanPhamListView.SelectedIndices.Count > 0)
            {
                DataRow data = sp_bus.DsHienThi.Rows[SanPhamListView.SelectedIndices[0]];
                SanPhamDTO sanpham = new SanPhamDTO(
                    Int32.Parse(data[0].ToString()), data[1].ToString(), data[2].ToString(), Int32.Parse(data[3].ToString()), data[4].ToString(), Int64.Parse(data[5].ToString().Split('.')[0]),
                    Int32.Parse(data[6].ToString()), data[7].ToString(), data[8].ToString(), data[9].ToString(), data[10].ToString(),
                    data[11].ToString(), data[12].ToString(), Int32.Parse(data[13].ToString()), Int32.Parse(data[14].ToString()), data[15].ToString(),
                    data[16].ToString(), data[17].ToString());

                string tenmau = "", mamau = "";
                for (int i = 0; i < sp_bus.DsMau.Rows.Count; i++)
                {
                    if (Int32.Parse(sp_bus.DsMau.Rows[i][0].ToString()) == Int32.Parse(data[3].ToString()))
                    {
                        tenmau = sp_bus.DsMau.Rows[i][1].ToString();
                        mamau = sp_bus.DsMau.Rows[i][2].ToString();
                    }
                }
                new ChiTietSanPham(sanpham, tenmau, mamau).Show();
            }
        }

        private void chonSanPham(object sender, EventArgs e)
        {
            if (SanPhamListView.SelectedIndices.Count > 0)
            {
                sp_bus.sanPhamDangChon = sp_bus.DsHienThi.Rows[SanPhamListView.SelectedIndices[0]];
                /*MessageBox.Show(sp_bus.sanPhamDangChon[1].ToString());*/
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (SanPhamListView.SelectedIndices.Count > 0)
            {
                if (sp_bus.xoaDuocKhong(Int32.Parse(sp_bus.sanPhamDangChon[0].ToString())))
                {
                    DialogResult xacNhan = MessageBox.Show("Bạn có chắc chắn muốn xóa sản phẩm",
                                     "Xác nhận!",
                                     MessageBoxButtons.YesNo);
                    if (xacNhan == DialogResult.Yes)
                    {
                        sp_bus.XoaSanPham(Int32.Parse(sp_bus.sanPhamDangChon[0].ToString()));
                        ReLoad();
                    }
                }
                else
                {
                    MessageBox.Show("Sản phẩm này đã có dữ liệu kinh doanh, không thể xóa");
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn 1 sản phẩm trong bảng");
            }
        }
        private void importByExcel()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Excel Files|*.xlsx|All Files|*.*";
            openFileDialog.Title = "Chọn file Excel";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string selectedFile = openFileDialog.FileName;
                string thong_bao = sp_bus.ThemSanPhamBangExcel(selectedFile);
                if(thong_bao != ""){
                    MessageBox.Show(thong_bao);
                }
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            importByExcel();
            hienThiSanPham();
        }
    }
}
