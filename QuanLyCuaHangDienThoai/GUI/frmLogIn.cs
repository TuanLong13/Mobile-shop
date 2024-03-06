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
using QuanLyCuaHangDienThoai.BUS;
using QuanLyCuaHangDienThoai.DTO;

namespace QuanLyCuaHangDienThoai.GUI
{
    public partial class frmLogIn : Form
    {
        public frmLogIn()
        {
            InitializeComponent();
        }
        public static string sUSERNAME;
        private void frmLogIn_Load(object sender, EventArgs e)
        {
            this.AcceptButton = btnLogIn;
        }

        private void picExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void picShow_Click(object sender, EventArgs e)
        {

            if (picShow.Visible == true)
            {
                txtPass.UseSystemPasswordChar = false;
                picShow.Visible = false;
                picHide.Visible = true;
            }
        }

        private void picHide_Click(object sender, EventArgs e)
        {
            if (picHide.Visible == true)
            {
                txtPass.UseSystemPasswordChar = true;
                picShow.Visible = true;
                picHide.Visible = false;
            }
        }

        private void btnLogIn_Click(object sender, EventArgs e)
        {
            string username = txtUserName.Text;
            string password = txtPass.Text;

            if (!string.IsNullOrEmpty(username) && !string.IsNullOrEmpty(password))
            {
                TaiKhoan_BUS taiKhoan = new TaiKhoan_BUS();
                DataTable result = taiKhoan.CheckUser(username, password);

                if (result.Rows.Count > 0)
                {
                    this.Hide();
                    UI ui = new UI();
                    ui.name = txtUserName.Text;
                    sUSERNAME = txtUserName.Text;
                    ui.ShowDialog();
                    this.Show();
                    txtUserName.Text = "";
                    txtPass.Text = "";
                }
                else
                {
                    MessageBox.Show("No account available with this username and password or this account is locked", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Please enter a value in all fields.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtUserName_Enter(object sender, EventArgs e)
        {
            txtUserName.BackColor = SystemColors.GradientActiveCaption;
        }

        private void txtUserName_Leave(object sender, EventArgs e)
        {
            txtUserName.BackColor = SystemColors.GradientInactiveCaption;
        }

        private void txtPass_Enter(object sender, EventArgs e)
        {
            txtPass.BackColor = SystemColors.GradientActiveCaption;
        }

        private void txtPass_Leave(object sender, EventArgs e)
        {
            txtPass.BackColor = SystemColors.GradientInactiveCaption;
        }


    }
}
