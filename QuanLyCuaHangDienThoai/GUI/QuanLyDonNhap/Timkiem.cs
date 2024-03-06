using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QuanLyCuaHangDienThoai.BUS;
using QuanLyCuaHangDienThoai.GUI;

namespace QuanLyCuaHangDienThoai.GUI.QuanLyDonNhap
{
    public partial class Timkiem : Form
    {
        DonNhapBUS busDN = new DonNhapBUS();
       // private string value;
        public delegate void SendValueDelegate(string label, string value);
        public event SendValueDelegate SendValue;
        public Timkiem()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SendValue?.Invoke(comboBox2.DisplayMember, comboBox2.Text);
            this.Close();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedValue = comboBox1.SelectedItem.ToString();
            switch (selectedValue)
            {
                case "Mã đơn nhập":
                    {   
                        comboBox2.DataSource = busDN.LayDataCB("madn", "DonNhap");
                        comboBox2.DisplayMember = "madn";
                         break;
                    }
                case "Mã nhà cung cấp":
                    {
                        comboBox2.DataSource = busDN.LayDataCB("mancc", "NhaCungCap");
                        comboBox2.DisplayMember = "mancc";
                        break;
                    }
                case "Mã nhân viên":
                    {
                        comboBox2.DataSource = busDN.LayDataCB("manv", "NhanVien");
                        comboBox2.DisplayMember = "manv";
                        break;
                    }
            }
        }
    }
}
