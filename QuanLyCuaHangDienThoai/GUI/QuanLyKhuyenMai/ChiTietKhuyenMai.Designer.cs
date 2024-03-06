namespace QuanLyCuaHangDienThoai.GUI.QuanLyKhuyenMai
{
    partial class ChiTietKhuyenMai
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.motaLbl = new System.Windows.Forms.Label();
            this.ngayBdLbl = new System.Windows.Forms.Label();
            this.ngayKtLbl = new System.Windows.Forms.Label();
            this.listView1 = new System.Windows.Forms.ListView();
            this.SuspendLayout();
            // 
            // motaLbl
            // 
            this.motaLbl.AutoSize = true;
            this.motaLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.motaLbl.Location = new System.Drawing.Point(12, 9);
            this.motaLbl.Name = "motaLbl";
            this.motaLbl.Size = new System.Drawing.Size(370, 37);
            this.motaLbl.TabIndex = 0;
            this.motaLbl.Text = "Chi tiết đợt khuyến mãi : ";
            // 
            // ngayBdLbl
            // 
            this.ngayBdLbl.AutoSize = true;
            this.ngayBdLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ngayBdLbl.Location = new System.Drawing.Point(19, 60);
            this.ngayBdLbl.Name = "ngayBdLbl";
            this.ngayBdLbl.Size = new System.Drawing.Size(139, 25);
            this.ngayBdLbl.TabIndex = 1;
            this.ngayBdLbl.Text = "Ngày bắt đầu :";
            // 
            // ngayKtLbl
            // 
            this.ngayKtLbl.AutoSize = true;
            this.ngayKtLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ngayKtLbl.Location = new System.Drawing.Point(335, 60);
            this.ngayKtLbl.Name = "ngayKtLbl";
            this.ngayKtLbl.Size = new System.Drawing.Size(139, 25);
            this.ngayKtLbl.TabIndex = 2;
            this.ngayKtLbl.Text = "Ngày bắt đầu :";
            // 
            // listView1
            // 
            this.listView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listView1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listView1.FullRowSelect = true;
            this.listView1.HideSelection = false;
            this.listView1.Location = new System.Drawing.Point(19, 112);
            this.listView1.MultiSelect = false;
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(809, 544);
            this.listView1.TabIndex = 3;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            // 
            // ChiTietKhuyenMai
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(849, 681);
            this.Controls.Add(this.listView1);
            this.Controls.Add(this.ngayKtLbl);
            this.Controls.Add(this.ngayBdLbl);
            this.Controls.Add(this.motaLbl);
            this.Name = "ChiTietKhuyenMai";
            this.Text = "ChiTietKhuyenMai";
            this.Load += new System.EventHandler(this.ChiTietKhuyenMai_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label motaLbl;
        private System.Windows.Forms.Label ngayBdLbl;
        private System.Windows.Forms.Label ngayKtLbl;
        private System.Windows.Forms.ListView listView1;
    }
}