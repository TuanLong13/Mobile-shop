namespace QuanLyCuaHangDienThoai.GUI.QuanLyKhuyenMai
{
    partial class QuanLyKhuyenMaiFrm
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.timKiemKMtxt = new System.Windows.Forms.TextBox();
            this.KhuyenMaiListView = new System.Windows.Forms.ListView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.timKiemBtn = new System.Windows.Forms.Button();
            this.refreshBtn = new System.Windows.Forms.Button();
            this.themBtn = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // timKiemKMtxt
            // 
            this.timKiemKMtxt.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.timKiemKMtxt.Location = new System.Drawing.Point(151, 37);
            this.timKiemKMtxt.Name = "timKiemKMtxt";
            this.timKiemKMtxt.Size = new System.Drawing.Size(280, 30);
            this.timKiemKMtxt.TabIndex = 10;
            // 
            // KhuyenMaiListView
            // 
            this.KhuyenMaiListView.BackColor = System.Drawing.SystemColors.Info;
            this.KhuyenMaiListView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.KhuyenMaiListView.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.KhuyenMaiListView.FullRowSelect = true;
            this.KhuyenMaiListView.GridLines = true;
            this.KhuyenMaiListView.HideSelection = false;
            this.KhuyenMaiListView.Location = new System.Drawing.Point(0, 0);
            this.KhuyenMaiListView.Margin = new System.Windows.Forms.Padding(10);
            this.KhuyenMaiListView.MultiSelect = false;
            this.KhuyenMaiListView.Name = "KhuyenMaiListView";
            this.KhuyenMaiListView.Size = new System.Drawing.Size(793, 478);
            this.KhuyenMaiListView.TabIndex = 13;
            this.KhuyenMaiListView.UseCompatibleStateImageBehavior = false;
            this.KhuyenMaiListView.View = System.Windows.Forms.View.Details;
            this.KhuyenMaiListView.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.KhuyenMaiListView_ColumnClick);
            this.KhuyenMaiListView.SizeChanged += new System.EventHandler(this.KhuyenMaiListView_SizeChanged);
            this.KhuyenMaiListView.Click += new System.EventHandler(this.KhuyenMaiListView_Click);
            this.KhuyenMaiListView.DoubleClick += new System.EventHandler(this.KhuyenMaiListView_DoubleClick);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ControlLight;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.button2);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel1.Location = new System.Drawing.Point(795, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(234, 580);
            this.panel1.TabIndex = 30;
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.ForeColor = System.Drawing.Color.LightSalmon;
            this.button2.Image = global::QuanLyCuaHangDienThoai.Properties.Resources.service1;
            this.button2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button2.Location = new System.Drawing.Point(16, 28);
            this.button2.Margin = new System.Windows.Forms.Padding(0);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(96, 49);
            this.button2.TabIndex = 17;
            this.button2.Text = "Sửa";
            this.button2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.Red;
            this.button1.Image = global::QuanLyCuaHangDienThoai.Properties.Resources.clear;
            this.button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button1.Location = new System.Drawing.Point(123, 28);
            this.button1.Margin = new System.Windows.Forms.Padding(0);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(98, 49);
            this.button1.TabIndex = 18;
            this.button1.Text = "Xóa";
            this.button1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.timKiemKMtxt);
            this.panel2.Controls.Add(this.timKiemBtn);
            this.panel2.Controls.Add(this.refreshBtn);
            this.panel2.Controls.Add(this.themBtn);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(795, 100);
            this.panel2.TabIndex = 31;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(27, 41);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(118, 20);
            this.label3.TabIndex = 13;
            this.label3.Text = "Tìm theo mô tả:";
            // 
            // timKiemBtn
            // 
            this.timKiemBtn.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.timKiemBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.timKiemBtn.Image = global::QuanLyCuaHangDienThoai.Properties.Resources.search__1_;
            this.timKiemBtn.Location = new System.Drawing.Point(459, 30);
            this.timKiemBtn.Name = "timKiemBtn";
            this.timKiemBtn.Size = new System.Drawing.Size(50, 49);
            this.timKiemBtn.TabIndex = 11;
            this.timKiemBtn.UseVisualStyleBackColor = false;
            this.timKiemBtn.Click += new System.EventHandler(this.timKiemBtn_Click);
            // 
            // refreshBtn
            // 
            this.refreshBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.refreshBtn.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.refreshBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.refreshBtn.ForeColor = System.Drawing.Color.Teal;
            this.refreshBtn.Image = global::QuanLyCuaHangDienThoai.Properties.Resources.refresh1;
            this.refreshBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.refreshBtn.Location = new System.Drawing.Point(665, 30);
            this.refreshBtn.Name = "refreshBtn";
            this.refreshBtn.Size = new System.Drawing.Size(111, 49);
            this.refreshBtn.TabIndex = 12;
            this.refreshBtn.Text = "Làm mới";
            this.refreshBtn.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.refreshBtn.UseVisualStyleBackColor = false;
            this.refreshBtn.Click += new System.EventHandler(this.refreshBtn_Click);
            // 
            // themBtn
            // 
            this.themBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.themBtn.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.themBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.themBtn.ForeColor = System.Drawing.Color.ForestGreen;
            this.themBtn.Image = global::QuanLyCuaHangDienThoai.Properties.Resources.plus1;
            this.themBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.themBtn.Location = new System.Drawing.Point(543, 30);
            this.themBtn.Margin = new System.Windows.Forms.Padding(0);
            this.themBtn.Name = "themBtn";
            this.themBtn.Size = new System.Drawing.Size(102, 49);
            this.themBtn.TabIndex = 14;
            this.themBtn.Text = "Thêm";
            this.themBtn.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.themBtn.UseVisualStyleBackColor = false;
            this.themBtn.Click += new System.EventHandler(this.themBtn_Click);
            // 
            // panel3
            // 
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.KhuyenMaiListView);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 100);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(795, 480);
            this.panel3.TabIndex = 32;
            // 
            // QuanLyKhuyenMaiFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "QuanLyKhuyenMaiFrm";
            this.Size = new System.Drawing.Size(1029, 580);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button refreshBtn;
        private System.Windows.Forms.Button timKiemBtn;
        private System.Windows.Forms.TextBox timKiemKMtxt;
        private System.Windows.Forms.ListView KhuyenMaiListView;
        private System.Windows.Forms.Button themBtn;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel3;
    }
}
