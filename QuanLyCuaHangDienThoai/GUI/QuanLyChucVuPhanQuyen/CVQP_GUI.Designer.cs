namespace QuanLyCuaHangDienThoai.GUI.QuanLyChucVu
{
    partial class CVPQ_GUI
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.lsvChucVu = new System.Windows.Forms.ListView();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnLoadCV = new System.Windows.Forms.Button();
            this.btnTimKiemCV = new System.Windows.Forms.Button();
            this.btnThemCV = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.txtTimKiemCV = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnCTPhanQuyen = new System.Windows.Forms.Button();
            this.btnSuaCV = new System.Windows.Forms.Button();
            this.btnXoaCV = new System.Windows.Forms.Button();
            this.txtTenCV = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.panel4 = new System.Windows.Forms.Panel();
            this.lsvPhanQuyen = new System.Windows.Forms.ListView();
            this.panel5 = new System.Windows.Forms.Panel();
            this.btnLoadPQ = new System.Windows.Forms.Button();
            this.btnTimkiemPQ = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtTimkiemPQ = new System.Windows.Forms.TextBox();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel5.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1038, 585);
            this.tabControl1.TabIndex = 1;
            this.tabControl1.Tag = "";
            this.tabControl1.SelectedIndexChanged += new System.EventHandler(this.tabPage2_Click);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.groupBox1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3, 3, 3, 3);
            this.tabPage1.Size = new System.Drawing.Size(1030, 559);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Chức vụ";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.panel3);
            this.groupBox1.Controls.Add(this.panel2);
            this.groupBox1.Controls.Add(this.panel1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.groupBox1.Size = new System.Drawing.Size(1024, 553);
            this.groupBox1.TabIndex = 20;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Quản lý chức vụ";
            // 
            // panel3
            // 
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.lsvChucVu);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(3, 102);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(784, 451);
            this.panel3.TabIndex = 31;
            // 
            // lsvChucVu
            // 
            this.lsvChucVu.BackColor = System.Drawing.SystemColors.Info;
            this.lsvChucVu.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lsvChucVu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lsvChucVu.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lsvChucVu.GridLines = true;
            this.lsvChucVu.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.lsvChucVu.HideSelection = false;
            this.lsvChucVu.Location = new System.Drawing.Point(0, 0);
            this.lsvChucVu.Name = "lsvChucVu";
            this.lsvChucVu.Size = new System.Drawing.Size(782, 449);
            this.lsvChucVu.TabIndex = 28;
            this.lsvChucVu.UseCompatibleStateImageBehavior = false;
            this.lsvChucVu.Click += new System.EventHandler(this.lsvChucVu_SelectedIndexChanged);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel2.Controls.Add(this.btnLoadCV);
            this.panel2.Controls.Add(this.btnTimKiemCV);
            this.panel2.Controls.Add(this.btnThemCV);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.txtTimKiemCV);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(3, 22);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(784, 80);
            this.panel2.TabIndex = 30;
            // 
            // btnLoadCV
            // 
            this.btnLoadCV.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnLoadCV.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnLoadCV.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLoadCV.ForeColor = System.Drawing.Color.DarkCyan;
            this.btnLoadCV.Image = global::QuanLyCuaHangDienThoai.Properties.Resources.refresh1;
            this.btnLoadCV.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnLoadCV.Location = new System.Drawing.Point(519, 14);
            this.btnLoadCV.Name = "btnLoadCV";
            this.btnLoadCV.Size = new System.Drawing.Size(94, 53);
            this.btnLoadCV.TabIndex = 29;
            this.btnLoadCV.Text = "Load";
            this.btnLoadCV.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnLoadCV.UseVisualStyleBackColor = false;
            this.btnLoadCV.Click += new System.EventHandler(this.btnLoadCV_Click);
            // 
            // btnTimKiemCV
            // 
            this.btnTimKiemCV.AutoSize = true;
            this.btnTimKiemCV.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnTimKiemCV.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTimKiemCV.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btnTimKiemCV.Image = global::QuanLyCuaHangDienThoai.Properties.Resources.search__1_;
            this.btnTimKiemCV.Location = new System.Drawing.Point(366, 17);
            this.btnTimKiemCV.Name = "btnTimKiemCV";
            this.btnTimKiemCV.Size = new System.Drawing.Size(47, 46);
            this.btnTimKiemCV.TabIndex = 24;
            this.btnTimKiemCV.UseVisualStyleBackColor = false;
            this.btnTimKiemCV.Click += new System.EventHandler(this.btnTimKiemCV_Click);
            // 
            // btnThemCV
            // 
            this.btnThemCV.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnThemCV.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnThemCV.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThemCV.ForeColor = System.Drawing.Color.DarkGreen;
            this.btnThemCV.Image = global::QuanLyCuaHangDienThoai.Properties.Resources.plus1;
            this.btnThemCV.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnThemCV.Location = new System.Drawing.Point(663, 14);
            this.btnThemCV.Name = "btnThemCV";
            this.btnThemCV.Size = new System.Drawing.Size(94, 53);
            this.btnThemCV.TabIndex = 27;
            this.btnThemCV.Text = "Thêm";
            this.btnThemCV.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnThemCV.UseVisualStyleBackColor = false;
            this.btnThemCV.Click += new System.EventHandler(this.btnThemCV_Click);
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(24, 33);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(138, 20);
            this.label3.TabIndex = 19;
            this.label3.Text = "Tìm kiếm theo tên:";
            // 
            // txtTimKiemCV
            // 
            this.txtTimKiemCV.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTimKiemCV.Location = new System.Drawing.Point(168, 30);
            this.txtTimKiemCV.Name = "txtTimKiemCV";
            this.txtTimKiemCV.Size = new System.Drawing.Size(183, 26);
            this.txtTimKiemCV.TabIndex = 22;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ControlLight;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.btnCTPhanQuyen);
            this.panel1.Controls.Add(this.btnSuaCV);
            this.panel1.Controls.Add(this.btnXoaCV);
            this.panel1.Controls.Add(this.txtTenCV);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel1.Location = new System.Drawing.Point(787, 22);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(234, 531);
            this.panel1.TabIndex = 29;
            // 
            // btnCTPhanQuyen
            // 
            this.btnCTPhanQuyen.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnCTPhanQuyen.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnCTPhanQuyen.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCTPhanQuyen.ForeColor = System.Drawing.Color.Brown;
            this.btnCTPhanQuyen.Image = global::QuanLyCuaHangDienThoai.Properties.Resources.invoice;
            this.btnCTPhanQuyen.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCTPhanQuyen.Location = new System.Drawing.Point(8, 238);
            this.btnCTPhanQuyen.Name = "btnCTPhanQuyen";
            this.btnCTPhanQuyen.Size = new System.Drawing.Size(214, 53);
            this.btnCTPhanQuyen.TabIndex = 28;
            this.btnCTPhanQuyen.Text = "Chi tiết phân quyền";
            this.btnCTPhanQuyen.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCTPhanQuyen.UseVisualStyleBackColor = false;
            this.btnCTPhanQuyen.Click += new System.EventHandler(this.btnCTPhanQuyen_Click);
            // 
            // btnSuaCV
            // 
            this.btnSuaCV.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnSuaCV.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnSuaCV.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSuaCV.ForeColor = System.Drawing.Color.Coral;
            this.btnSuaCV.Image = global::QuanLyCuaHangDienThoai.Properties.Resources.service;
            this.btnSuaCV.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSuaCV.Location = new System.Drawing.Point(14, 152);
            this.btnSuaCV.Name = "btnSuaCV";
            this.btnSuaCV.Size = new System.Drawing.Size(94, 53);
            this.btnSuaCV.TabIndex = 26;
            this.btnSuaCV.Text = "Sửa";
            this.btnSuaCV.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSuaCV.UseVisualStyleBackColor = false;
            this.btnSuaCV.Click += new System.EventHandler(this.btnSuaCV_Click);
            // 
            // btnXoaCV
            // 
            this.btnXoaCV.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnXoaCV.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnXoaCV.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnXoaCV.ForeColor = System.Drawing.Color.Red;
            this.btnXoaCV.Image = global::QuanLyCuaHangDienThoai.Properties.Resources.clear;
            this.btnXoaCV.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnXoaCV.Location = new System.Drawing.Point(129, 152);
            this.btnXoaCV.Name = "btnXoaCV";
            this.btnXoaCV.Size = new System.Drawing.Size(93, 53);
            this.btnXoaCV.TabIndex = 25;
            this.btnXoaCV.Text = "Xóa";
            this.btnXoaCV.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnXoaCV.UseVisualStyleBackColor = false;
            this.btnXoaCV.Click += new System.EventHandler(this.btnXoaCV_Click);
            // 
            // txtTenCV
            // 
            this.txtTenCV.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTenCV.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTenCV.Location = new System.Drawing.Point(13, 66);
            this.txtTenCV.Name = "txtTenCV";
            this.txtTenCV.Size = new System.Drawing.Size(210, 26);
            this.txtTenCV.TabIndex = 21;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(10, 43);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(102, 20);
            this.label2.TabIndex = 18;
            this.label2.Text = "Tên chức vụ :";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.groupBox2);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3, 3, 3, 3);
            this.tabPage2.Size = new System.Drawing.Size(1030, 559);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Phân quyền";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.panel4);
            this.groupBox2.Controls.Add(this.panel5);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(3, 3);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.groupBox2.Size = new System.Drawing.Size(1024, 553);
            this.groupBox2.TabIndex = 21;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Quản lý phân quyền";
            // 
            // panel4
            // 
            this.panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel4.Controls.Add(this.lsvPhanQuyen);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(3, 102);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(1018, 451);
            this.panel4.TabIndex = 31;
            // 
            // lsvPhanQuyen
            // 
            this.lsvPhanQuyen.BackColor = System.Drawing.SystemColors.Info;
            this.lsvPhanQuyen.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lsvPhanQuyen.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lsvPhanQuyen.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lsvPhanQuyen.GridLines = true;
            this.lsvPhanQuyen.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.lsvPhanQuyen.HideSelection = false;
            this.lsvPhanQuyen.Location = new System.Drawing.Point(0, 0);
            this.lsvPhanQuyen.Name = "lsvPhanQuyen";
            this.lsvPhanQuyen.Size = new System.Drawing.Size(1016, 449);
            this.lsvPhanQuyen.TabIndex = 28;
            this.lsvPhanQuyen.UseCompatibleStateImageBehavior = false;
            this.lsvPhanQuyen.SelectedIndexChanged += new System.EventHandler(this.lsvPhanQuyen_SelectedIndexChanged);
            this.lsvPhanQuyen.Click += new System.EventHandler(this.lsvPhanQuyen_SelectedIndexChanged);
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.panel5.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel5.Controls.Add(this.btnLoadPQ);
            this.panel5.Controls.Add(this.btnTimkiemPQ);
            this.panel5.Controls.Add(this.label1);
            this.panel5.Controls.Add(this.txtTimkiemPQ);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel5.Location = new System.Drawing.Point(3, 22);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(1018, 80);
            this.panel5.TabIndex = 30;
            // 
            // btnLoadPQ
            // 
            this.btnLoadPQ.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnLoadPQ.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnLoadPQ.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLoadPQ.ForeColor = System.Drawing.Color.DarkCyan;
            this.btnLoadPQ.Image = global::QuanLyCuaHangDienThoai.Properties.Resources.refresh;
            this.btnLoadPQ.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnLoadPQ.Location = new System.Drawing.Point(892, 14);
            this.btnLoadPQ.Name = "btnLoadPQ";
            this.btnLoadPQ.Size = new System.Drawing.Size(94, 53);
            this.btnLoadPQ.TabIndex = 28;
            this.btnLoadPQ.Text = "Load";
            this.btnLoadPQ.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnLoadPQ.UseVisualStyleBackColor = false;
            this.btnLoadPQ.Click += new System.EventHandler(this.btnLoadPQ_Click);
            // 
            // btnTimkiemPQ
            // 
            this.btnTimkiemPQ.AutoSize = true;
            this.btnTimkiemPQ.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnTimkiemPQ.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTimkiemPQ.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btnTimkiemPQ.Image = global::QuanLyCuaHangDienThoai.Properties.Resources.search__1_;
            this.btnTimkiemPQ.Location = new System.Drawing.Point(366, 17);
            this.btnTimkiemPQ.Name = "btnTimkiemPQ";
            this.btnTimkiemPQ.Size = new System.Drawing.Size(47, 46);
            this.btnTimkiemPQ.TabIndex = 24;
            this.btnTimkiemPQ.UseVisualStyleBackColor = false;
            this.btnTimkiemPQ.Click += new System.EventHandler(this.btnTimKiemPQ_Click);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(24, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(138, 20);
            this.label1.TabIndex = 19;
            this.label1.Text = "Tìm kiếm theo tên:";
            // 
            // txtTimkiemPQ
            // 
            this.txtTimkiemPQ.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTimkiemPQ.Location = new System.Drawing.Point(168, 30);
            this.txtTimkiemPQ.Name = "txtTimkiemPQ";
            this.txtTimkiemPQ.Size = new System.Drawing.Size(183, 26);
            this.txtTimkiemPQ.TabIndex = 22;
            // 
            // CVPQ_GUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tabControl1);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "CVPQ_GUI";
            this.Size = new System.Drawing.Size(1038, 585);
            this.Load += new System.EventHandler(this.CVPQ_GUI_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.ListView lsvChucVu;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnTimKiemCV;
        private System.Windows.Forms.Button btnThemCV;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtTimKiemCV;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnSuaCV;
        private System.Windows.Forms.Button btnXoaCV;
        private System.Windows.Forms.TextBox txtTenCV;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.ListView lsvPhanQuyen;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Button btnTimkiemPQ;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtTimkiemPQ;
        private System.Windows.Forms.Button btnLoadPQ;
        private System.Windows.Forms.Button btnLoadCV;
        private System.Windows.Forms.Button btnCTPhanQuyen;
    }
}
