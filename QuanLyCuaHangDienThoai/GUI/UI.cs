using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DocumentFormat.OpenXml.Drawing.Charts;
using QuanLyCuaHangDienThoai.BUS;
using QuanLyCuaHangDienThoai.GUI.QuanLyChucVu;
using QuanLyCuaHangDienThoai.GUI.QuanLyKhuyenMai;
using QuanLyCuaHangDienThoai.GUI.QuanLySanPham;
using QuanLyCuaHangDienThoai.GUI.ThongKe;

namespace QuanLyCuaHangDienThoai.GUI
{
    public partial class UI : Form
    {
        private QuanLySanPhamForm qlsp_form = null;
        private QuanLyKhuyenMaiFrm qlkm_form = null;
        private ThongKeForm thongKe_form = null;
        PhanQuyen_BUS pqBus = new PhanQuyen_BUS();
        public string name = "?";
        private DonNhapGUI userControlDN;
        private NhaCungCapGUI userControlNCC;
       

        public UI()
        {
            InitializeComponent();
            splitContainer2.Panel2.AutoSize = true;
        }

        private void UI_Load(object sender, EventArgs e)
        {
            lbUsername.Text = name;
            lblDateTime.Text = timerDateandTime.ToString();
            timerDateandTime.Start();
            System.Data.DataTable dataTable = new System.Data.DataTable();
            dataTable = pqBus.layDanhSachMenuTheoQuyen(frmLogIn.sUSERNAME);

            for (int i = 0; i < dataTable.Rows.Count; i++)
            {
                if (dataTable.Rows[i][0].ToString() == "1")
                {
                    menu.Controls.Add(tabSanPham);
                }
                if (dataTable.Rows[i][0].ToString() == "2")
                {
                    menu.Controls.Add(tabKhuyenMai);
                }
                if (dataTable.Rows[i][0].ToString() == "3")
                {
                    menu.Controls.Add(tabNhanVien);
                }
                if (dataTable.Rows[i][0].ToString() == "4")
                {
                    menu.Controls.Add(tabTaiKhoan);
                }
                if (dataTable.Rows[i][0].ToString() == "5")
                {
                    menu.Controls.Add(tabDonNhap);
                }
                if (dataTable.Rows[i][0].ToString() == "6")
                {
                    menu.Controls.Add(tabNhaCungCap);
                }
                if (dataTable.Rows[i][0].ToString() == "7")
                {
                    menu.Controls.Add(tabHoaDon);
                }
                if (dataTable.Rows[i][0].ToString() == "8")
                {
                    menu.Controls.Add(tabKhachHang);
                }
                if (dataTable.Rows[i][0].ToString() == "9")
                {
                    menu.Controls.Add(tabThongKe);
                }
                if (dataTable.Rows[i][0].ToString() == "10")
                {
                    menu.Controls.Add(tabChucVu);
                }
            }

            UserControlDashboard db = new UserControlDashboard();
            db.Dock = DockStyle.Fill;
            splitContainer2.Panel2.Controls.Add(db);
        }
        private void activeTab(Control sender)
        {
            foreach (Control button in menu.Controls)
            {
                if (button.Equals(sender))
                {
                    button.BackColor = SystemColors.GradientActiveCaption;
                }
                else
                {
                    button.BackColor = SystemColors.ButtonHighlight;
                }
            }
        }

        private void tabSanPham_Click(object sender, EventArgs e)
        {
            initQuanLySanPham();
            activeTab((Control)sender);
        }

        private void tabKhuyenMai_Click(object sender, EventArgs e)
        {
            initQuanLyKhuyenMai();
            activeTab((Control)sender);
        }

        public void initQuanLySanPham()
        {
            if (qlsp_form == null)
            {
                splitContainer2.Panel2.Controls.Clear();
                qlsp_form = new QuanLySanPhamForm();
                qlsp_form.Dock = DockStyle.Fill;
                splitContainer2.Panel2.Controls.Add(qlsp_form);
                qlsp_form.parent_f = this;
            }
            else
            {
                splitContainer2.Panel2.Controls.Clear();
                splitContainer2.Panel2.Controls.Add(qlsp_form);
            }
        }

        public void initQuanLyKhuyenMai()
        {
            if (qlkm_form == null)
            {
                splitContainer2.Panel2.Controls.Clear();
                qlkm_form = new QuanLyKhuyenMaiFrm();
                qlkm_form.Dock = DockStyle.Fill;
                splitContainer2.Panel2.Controls.Add(qlkm_form);
                qlkm_form.parent_f = this;
            }
            else
            {
                splitContainer2.Panel2.Controls.Clear();
                splitContainer2.Panel2.Controls.Add(qlkm_form);
            }

        }

        private void tabThongKe_Click(object sender, EventArgs e)
        {
            if (thongKe_form == null)
            {
                splitContainer2.Panel2.Controls.Clear();
                thongKe_form = new ThongKeForm();
                thongKe_form.Dock = DockStyle.Fill;
                thongKe_form.parent_f = this;
                splitContainer2.Panel2.Controls.Add(thongKe_form);
            }
            else
            {
                splitContainer2.Panel2.Controls.Clear();
                splitContainer2.Panel2.Controls.Add(thongKe_form);
            }
            activeTab((Control)sender);
        }
        private void tabNhaCungCap_Click(object sender, EventArgs e)
        {
            this.splitContainer2.Panel2.Controls.Clear();
            this.userControlNCC = new NhaCungCapGUI();
            userControlNCC.Dock = DockStyle.Fill;
            userControlNCC.Visible = true;
            this.splitContainer2.Panel2.Controls.Add(this.userControlNCC);
            activeTab((Control)sender);
        }

        private void tabDonNhap_Click(object sender, EventArgs e)
        {
            this.splitContainer2.Panel2.Controls.Clear();
            this.userControlDN = new DonNhapGUI();
            userControlDN.Dock = DockStyle.Fill;
            userControlDN.Visible = true;
            userControlDN.username = lbUsername.Text;
            this.splitContainer2.Panel2.Controls.Add(this.userControlDN);
            activeTab((Control)sender);
        }

        private void tabKhachHang_Click(object sender, EventArgs e)
        {
            splitContainer2.Panel2.Controls.Clear();
            KhachHang_GUI kh = new KhachHang_GUI();
            kh.Dock = DockStyle.Fill;
            splitContainer2.Panel2.Controls.Add(kh);
            activeTab((Control)sender);
        }

        private void tabHoaDon_Click(object sender, EventArgs e)
        {
            splitContainer2.Panel2.Controls.Clear();
            HoaDon_GUI hd = new HoaDon_GUI();
            hd.username = lbUsername.Text;
            hd.Dock = DockStyle.Fill;
            splitContainer2.Panel2.Controls.Add(hd);
            activeTab((Control)sender);
        }

        private void timerDateandTime_Tick(object sender, EventArgs e)
        {
            lblDateTime.Text = DateTime.Now.ToString("dd-MM-yyyy hh:mm:ss ");
        }
        bool dangxuat = false;
        private void btnDangXuat_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Bạn muốn đăng xuất ?", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialogResult == DialogResult.Yes)
            {
                dangxuat = true;
                Close();
            }
        }

        private void UI_FormClosed(object sender, FormClosedEventArgs e)
        {
            if( !dangxuat )
            {
                Application.Exit();
            }    
        }
        private void tabNhanVien_Click(object sender, EventArgs e)
        {
            splitContainer2.Panel2.Controls.Clear();
            NhanVien_GUI hd = new NhanVien_GUI();
            hd.Dock = DockStyle.Fill;
            splitContainer2.Panel2.Controls.Add(hd);
            activeTab((Control)sender);
        }

        private void tabTaiKhoan_Click(object sender, EventArgs e)
        {
            splitContainer2.Panel2.Controls.Clear();
            TaiKhoan_GUI hd = new TaiKhoan_GUI();
            hd.Dock = DockStyle.Fill;
            splitContainer2.Panel2.Controls.Add(hd);
            activeTab((Control)sender);
        }
        private void tabChucVu_Click(object sender, EventArgs e)
        {
            splitContainer2.Panel2.Controls.Clear();
            CVPQ_GUI cv = new CVPQ_GUI();
            cv.Dock = DockStyle.Fill;
            splitContainer2.Panel2.Controls.Add(cv);
            activeTab((Control)sender);
        }
    }
}
