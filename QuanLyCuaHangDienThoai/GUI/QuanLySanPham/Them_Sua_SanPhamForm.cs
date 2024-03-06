using QuanLyCuaHangDienThoai.BUS;
using QuanLyCuaHangDienThoai.DTO;
using SixLabors.Fonts;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyCuaHangDienThoai.GUI.QuanLySanPham
{
    public partial class Them_Sua_SanPhamForm : UserControl
    {

        SanPhamBUS sp_bus;
        QuanLySanPhamForm qlsp_form;
        private string sourceImage;
        private bool capnhat;


        private string maMau;
        private string tenMau;
        public Them_Sua_SanPhamForm()
        {
            InitializeComponent();
        }
        public Them_Sua_SanPhamForm(QuanLySanPhamForm quanLySanPhamForm, SanPhamBUS sanPhamBUS, bool capnhat = false)
        {
            InitializeComponent();
            this.sp_bus = sanPhamBUS;
            this.qlsp_form = quanLySanPhamForm;
            this.hinhAnhLbl.Text = "";

            object[] danhSachMau = new object[sp_bus.DsMau.Rows.Count];
            for (int i = 0; i < sp_bus.DsMau.Rows.Count; i++)
            {
                danhSachMau[i] = sp_bus.DsMau.Rows[i][1].ToString();
            }

            this.txtMau.Items.AddRange(danhSachMau);

            this.capnhat = capnhat;
            if (capnhat)
            {
                hienThiSua();
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = AppDomain.CurrentDomain.BaseDirectory + "\\..\\..\\img\\dienthoai";

            DialogResult result = openFileDialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                // Get the selected file's path
                sourceImage = openFileDialog.FileName;

                // Do something with the file path, e.g., display it in a TextBox
                string[] image_file_split = sourceImage.Split('\\');
                string image_file = image_file_split[image_file_split.Length - 1];
                string image = image_file.Split('.')[0];
                pictureBox1.BackgroundImage = Image.FromFile(sourceImage);
                hinhAnhLbl.Text = image;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {   // validate 
            if (txtTenSp.Text.Trim() == "" || hinhAnhLbl.Text.Trim() == "" || txtHang.Text.Trim() == "" || txtMau.Text == "" || txtCPU.Text.Trim() == "" ||
                 txtGPU.Text.Trim() == "" || txtRam.Text.Trim() == "" || txtBoNho.Text.Trim() == "" || txtHeDieuHanh.Text.Trim() == "" || txtNamSanXuat.Text == "" || txtThangBaoHanh.Text.Trim() == ""
                 || txtPin.Text.Trim() == "" || txtPhuKien.Text.Trim() == "" || txtCamera.Text.Trim() == "")
            {
                MessageBox.Show("Vui lòng điền đủ thông tin");
                return;
            }

            if (!checkDulicate())
            {
                MessageBox.Show("Sản phẩm bị trùng tên, vui lòng chọn tên khác");
                return;
            }
            // kiểm tra năm
            try
            {
                int namsx = Int32.Parse(txtNamSanXuat.Text);
            }
            catch
            {
                MessageBox.Show("Vui lòng nhập năm sản xuất hợp lệ");
                return;
            }
            // kiểm tra tháng bảo hành
            try
            {
                int thangBh = Int32.Parse(txtThangBaoHanh.Text);
            }
            catch
            {
                MessageBox.Show("Vui lòng nhập năm sản xuất hợp lệ");
                return;
            }

            // thêm hoặc cập nhật

            var confirmResult = DialogResult.Yes;
            if (capnhat == false)
            {
                confirmResult = MessageBox.Show("Xác nhận thêm sản phẩm ?",
                                     null,
                                     MessageBoxButtons.YesNo);
            }
            else
            {
                confirmResult = MessageBox.Show("Xác nhận cập nhật sản phẩm ?",
                                     null,
                                     MessageBoxButtons.YesNo);
            }

            if (confirmResult == DialogResult.Yes)
            {
                try
                {
                    // Thêm màu (nếu cần)
                    bool mau_exist = false;
                    int id_mau = 1;
                    tenMau = txtMau.Text;
                    maMau = txtMauHexCode.Text;
                    for (int i = 0; i < sp_bus.DsMau.Rows.Count; i++)
                    {
                        if (sp_bus.DsMau.Rows[i][1].ToString().Equals(tenMau) || sp_bus.DsMau.Rows[i][2].ToString().Equals(maMau))
                        {
                            mau_exist = true;
                            DialogResult dr = MessageBox.Show("màu đã có sẵn, bạn có muốn tiếp tục hay quay lại để chỉnh sửa", "cảnh báo", MessageBoxButtons.OKCancel);
                            if (dr == DialogResult.OK)
                            {
                                id_mau = Int32.Parse(sp_bus.DsMau.Rows[i][0].ToString());
                                break;
                            }
                            else if (dr == DialogResult.No)
                            {
                                return;
                            }
                        }
                    }
                    if (mau_exist == false)
                    {
                        sp_bus.ThemMau(tenMau, maMau);
                        sp_bus.layDanhSachMau();
                        id_mau = Int32.Parse(sp_bus.DsMau.Rows[sp_bus.DsMau.Rows.Count - 1][0].ToString());
                    }
                      

                    string ram = txtRam.Text;
                    while (ram.Length < 5)
                    {
                        ram = " " + ram;
                    }

                    SanPhamDTO sanpham = new SanPhamDTO(0, txtTenSp.Text, hinhAnhLbl.Text, id_mau, txtHang.Text, 0, 0,
                    txtCPU.Text, txtGPU.Text, ram, txtBoNho.Text, txtHeDieuHanh.Text, txtManHinh.Text, Int32.Parse(txtNamSanXuat.Text),
                    Int32.Parse(txtThangBaoHanh.Text),
                    txtPin.Text, txtPhuKien.Text, txtCamera.Text);

                    if (capnhat)
                    {
                        sanpham.MaSP = Int32.Parse(sp_bus.sanPhamDangChon[0].ToString());
                        sp_bus.CapNhatSanPham(sanpham);
                    }
                    else
                    {
                        sp_bus.ThemSanPham(sanpham);
                    }



                    string destinationImage = AppDomain.CurrentDomain.BaseDirectory + "\\..\\..\\img\\dienthoai\\" + hinhAnhLbl.Text + ".png";
                    // Copy hình ảnh khi cần
                    if (!File.Exists(destinationImage))
                    {
                        File.Copy(sourceImage, destinationImage);
                    }
                    // Kết quả 
                    if (capnhat)
                    {
                        MessageBox.Show("Cập nhật sản phẩm thành công");
                    }
                    else
                    {
                        MessageBox.Show("Thêm sản phẩm thành công");
                    }

                    this.qlsp_form.ReLoad();
                    this.qlsp_form.parent_f.initQuanLySanPham();
                }
                catch (Exception ex)
                {
                    if (capnhat)
                    {
                        MessageBox.Show("Cập nhật sản phẩm không thành công lỗi :" + ex);
                    }
                    else
                        MessageBox.Show("Thêm sản phẩm không thành công lỗi :" + ex);
                }

            }
        }

        private void onlyReceiveNumber(object sender, KeyPressEventArgs e)
        {
            if (char.IsLetter(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void refreshImageBtn_Click(object sender, EventArgs e)
        {
            this.pictureBox1.BackgroundImage = global::QuanLyCuaHangDienThoai.Properties.Resources.smartphone__2_;
            sourceImage = "";
            hinhAnhLbl.Text = "";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.qlsp_form.ReLoad();
            this.qlsp_form.parent_f.initQuanLySanPham();
        }

        public void hienThiSua()
        {
            titleLbl.Text = "Cập nhật sản phẩm";

            txtTenSp.Text = sp_bus.sanPhamDangChon[1].ToString();
            txtHang.Text = sp_bus.sanPhamDangChon[4].ToString();
            txtCPU.Text = sp_bus.sanPhamDangChon[7].ToString();
            txtGPU.Text = sp_bus.sanPhamDangChon[8].ToString();
            txtRam.Text = sp_bus.sanPhamDangChon[9].ToString();
            txtBoNho.Text = sp_bus.sanPhamDangChon[10].ToString();
            txtManHinh.Text = sp_bus.sanPhamDangChon[11].ToString();
            txtHeDieuHanh.Text = sp_bus.sanPhamDangChon[12].ToString();
            txtNamSanXuat.Text = sp_bus.sanPhamDangChon[13].ToString();
            txtThangBaoHanh.Text = sp_bus.sanPhamDangChon[14].ToString();
            txtPin.Text = sp_bus.sanPhamDangChon[15].ToString();
            txtPhuKien.Text = sp_bus.sanPhamDangChon[16].ToString();
            txtCamera.Text = sp_bus.sanPhamDangChon[17].ToString();

            hinhAnhLbl.Text = sp_bus.sanPhamDangChon[2].ToString();
            if (File.Exists(AppDomain.CurrentDomain.BaseDirectory + "\\..\\..\\img\\dienthoai\\" + hinhAnhLbl.Text + ".png"))
                pictureBox1.BackgroundImage = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "\\..\\..\\img\\dienthoai\\" + hinhAnhLbl.Text + ".png");
            else
                pictureBox1.BackgroundImage = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "\\..\\..\\img\\dienthoai\\notfound.png");

            for (int i = 0; i < sp_bus.DsMau.Rows.Count; i++)
            {
                if (sp_bus.DsMau.Rows[i][0].ToString().Equals(sp_bus.sanPhamDangChon[3].ToString()))
                {
                    btnMauDisplay.BackColor = (Color)new ColorConverter().ConvertFromString(sp_bus.DsMau.Rows[i][2].ToString());
                    txtMauHexCode.Text = sp_bus.DsMau.Rows[i][2].ToString();
                    txtMau.SelectedIndex = i;
                }
            }
        }

        public bool checkDulicate()
        {
            for (int i = 0; i < sp_bus.DsSanPham.Rows.Count; i++)
            {
                if (!capnhat)
                {
                    if (sp_bus.DsSanPham.Rows[i][1].ToString().Equals(txtTenSp.Text))
                    {
                        return false;
                    }
                }
                else
                {
                    if (sp_bus.DsSanPham.Rows[i][1].ToString().Equals(txtTenSp.Text) && !sp_bus.sanPhamDangChon[0].ToString().Equals(sp_bus.DsSanPham.Rows[i][0].ToString()))
                    {
                        return false;
                    }
                }

            }
            return true;
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            using (ColorDialog colorDialog = new ColorDialog())
            {
                DialogResult result = colorDialog.ShowDialog();

                if (result == DialogResult.OK)
                {
                    // Get the selected color
                    Color selectedColor = colorDialog.Color;

                    btnMauDisplay.BackColor = selectedColor;
                    // Convert the color to hex format
                    maMau = ColorToHex(selectedColor);
                    txtMauHexCode.Text = maMau;
                    txtMau.SelectedIndex = -1;
                }
            }
        }
        private string ColorToHex(Color color)
        {
            return $"#{color.R:X2}{color.G:X2}{color.B:X2}";
        }

        private void txtMau_SelectedIndexChanged(object sender, EventArgs e)
        {
            /*MessageBox.Show(((ComboBox)sender).SelectedIndex+"");*/
            if (txtMau.SelectedIndex != -1)
            {
                string backcolor_hex = sp_bus.color_dic[txtMau.SelectedItem.ToString()];
                Color backcolor = (Color)new ColorConverter().ConvertFromString(backcolor_hex);
                btnMauDisplay.BackColor = backcolor;
                txtMauHexCode.Text = backcolor_hex;
            }
        }
    }
}
