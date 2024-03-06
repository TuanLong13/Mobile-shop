namespace QuanLyCuaHangDienThoai.GUI.ThongKe
{
    partial class ThongKeForm
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea3 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend3 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.thangCmbx = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.namCmbx = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.nhanvienCmbx = new System.Windows.Forms.ComboBox();
            this.doanhThuRad = new System.Windows.Forms.RadioButton();
            this.sanPhamRad = new System.Windows.Forms.RadioButton();
            this.nhanVienRad = new System.Windows.Forms.RadioButton();
            this.panel2 = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.thongKeListView = new System.Windows.Forms.ListView();
            this.thapNhatLbl = new System.Windows.Forms.Label();
            this.caoNhatLbl = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            this.panel1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // chart1
            // 
            this.chart1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            chartArea3.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea3);
            legend3.Name = "Legend1";
            this.chart1.Legends.Add(legend3);
            this.chart1.Location = new System.Drawing.Point(16, 182);
            this.chart1.Name = "chart1";
            this.chart1.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.None;
            this.chart1.PaletteCustomColors = new System.Drawing.Color[] {
        System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255))))),
        System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128))))),
        System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128))))),
        System.Drawing.Color.Yellow,
        System.Drawing.Color.Blue,
        System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255))))),
        System.Drawing.Color.Magenta,
        System.Drawing.Color.Red,
        System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(0))))),
        System.Drawing.Color.Lime,
        System.Drawing.Color.Gray,
        System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0))))),
        System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(64))))),
        System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(192))))),
        System.Drawing.Color.Silver,
        System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))))};
            this.chart1.Size = new System.Drawing.Size(737, 600);
            this.chart1.TabIndex = 0;
            this.chart1.Text = "chart1";
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.SystemColors.ControlLight;
            this.panel1.Controls.Add(this.groupBox2);
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Location = new System.Drawing.Point(16, 19);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1463, 143);
            this.panel1.TabIndex = 2;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.thangCmbx);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.namCmbx);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(3, 4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(1443, 61);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "thời gian";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(381, 26);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(80, 25);
            this.label2.TabIndex = 3;
            this.label2.Text = "Tháng :";
            // 
            // thangCmbx
            // 
            this.thangCmbx.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.thangCmbx.FormattingEnabled = true;
            this.thangCmbx.Location = new System.Drawing.Point(467, 23);
            this.thangCmbx.Name = "thangCmbx";
            this.thangCmbx.Size = new System.Drawing.Size(121, 33);
            this.thangCmbx.TabIndex = 2;
            this.thangCmbx.SelectedIndexChanged += new System.EventHandler(this.thangCmbx_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(156, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 25);
            this.label1.TabIndex = 1;
            this.label1.Text = "Năm :";
            // 
            // namCmbx
            // 
            this.namCmbx.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.namCmbx.FormattingEnabled = true;
            this.namCmbx.Location = new System.Drawing.Point(226, 22);
            this.namCmbx.Name = "namCmbx";
            this.namCmbx.Size = new System.Drawing.Size(121, 33);
            this.namCmbx.TabIndex = 0;
            this.namCmbx.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.nhanvienCmbx);
            this.groupBox1.Controls.Add(this.doanhThuRad);
            this.groupBox1.Controls.Add(this.sanPhamRad);
            this.groupBox1.Controls.Add(this.nhanVienRad);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(3, 71);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1443, 66);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "đối tượng";
            // 
            // nhanvienCmbx
            // 
            this.nhanvienCmbx.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.nhanvienCmbx.FormattingEnabled = true;
            this.nhanvienCmbx.Items.AddRange(new object[] {
            "doanh số",
            "doanh thu"});
            this.nhanvienCmbx.Location = new System.Drawing.Point(226, 25);
            this.nhanvienCmbx.Name = "nhanvienCmbx";
            this.nhanvienCmbx.Size = new System.Drawing.Size(121, 33);
            this.nhanvienCmbx.TabIndex = 3;
            this.nhanvienCmbx.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // doanhThuRad
            // 
            this.doanhThuRad.AutoSize = true;
            this.doanhThuRad.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.doanhThuRad.Location = new System.Drawing.Point(597, 29);
            this.doanhThuRad.Name = "doanhThuRad";
            this.doanhThuRad.Size = new System.Drawing.Size(160, 29);
            this.doanhThuRad.TabIndex = 2;
            this.doanhThuRad.TabStop = true;
            this.doanhThuRad.Text = "theo doanh thu";
            this.doanhThuRad.UseVisualStyleBackColor = true;
            this.doanhThuRad.CheckedChanged += new System.EventHandler(this.doanhThuRad_CheckedChanged);
            // 
            // sanPhamRad
            // 
            this.sanPhamRad.AutoSize = true;
            this.sanPhamRad.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sanPhamRad.Location = new System.Drawing.Point(386, 29);
            this.sanPhamRad.Name = "sanPhamRad";
            this.sanPhamRad.Size = new System.Drawing.Size(159, 29);
            this.sanPhamRad.TabIndex = 1;
            this.sanPhamRad.TabStop = true;
            this.sanPhamRad.Text = "theo sản phẩm";
            this.sanPhamRad.UseVisualStyleBackColor = true;
            this.sanPhamRad.CheckedChanged += new System.EventHandler(this.sanPhamRad_CheckedChanged);
            // 
            // nhanVienRad
            // 
            this.nhanVienRad.AutoSize = true;
            this.nhanVienRad.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nhanVienRad.Location = new System.Drawing.Point(62, 26);
            this.nhanVienRad.Name = "nhanVienRad";
            this.nhanVienRad.Size = new System.Drawing.Size(158, 29);
            this.nhanVienRad.TabIndex = 0;
            this.nhanVienRad.TabStop = true;
            this.nhanVienRad.Text = "theo nhân viên";
            this.nhanVienRad.UseVisualStyleBackColor = true;
            this.nhanVienRad.CheckedChanged += new System.EventHandler(this.nhanVienRad_CheckedChanged);
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.BackColor = System.Drawing.SystemColors.Control;
            this.panel2.Controls.Add(this.button1);
            this.panel2.Controls.Add(this.thongKeListView);
            this.panel2.Controls.Add(this.thapNhatLbl);
            this.panel2.Controls.Add(this.caoNhatLbl);
            this.panel2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel2.Location = new System.Drawing.Point(759, 182);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(720, 600);
            this.panel2.TabIndex = 3;
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.Location = new System.Drawing.Point(601, 546);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(107, 42);
            this.button1.TabIndex = 7;
            this.button1.Text = "in";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // thongKeListView
            // 
            this.thongKeListView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.thongKeListView.FullRowSelect = true;
            this.thongKeListView.HideSelection = false;
            this.thongKeListView.Location = new System.Drawing.Point(8, 98);
            this.thongKeListView.Name = "thongKeListView";
            this.thongKeListView.Size = new System.Drawing.Size(700, 442);
            this.thongKeListView.TabIndex = 6;
            this.thongKeListView.UseCompatibleStateImageBehavior = false;
            this.thongKeListView.View = System.Windows.Forms.View.Details;
            // 
            // thapNhatLbl
            // 
            this.thapNhatLbl.AutoSize = true;
            this.thapNhatLbl.ForeColor = System.Drawing.Color.OrangeRed;
            this.thapNhatLbl.Location = new System.Drawing.Point(3, 39);
            this.thapNhatLbl.Name = "thapNhatLbl";
            this.thapNhatLbl.Size = new System.Drawing.Size(314, 25);
            this.thapNhatLbl.TabIndex = 4;
            this.thapNhatLbl.Text = "Nhân viên có doanh số thấp  nhất :";
            // 
            // caoNhatLbl
            // 
            this.caoNhatLbl.AutoSize = true;
            this.caoNhatLbl.ForeColor = System.Drawing.Color.Lime;
            this.caoNhatLbl.Location = new System.Drawing.Point(3, 4);
            this.caoNhatLbl.Name = "caoNhatLbl";
            this.caoNhatLbl.Size = new System.Drawing.Size(303, 25);
            this.caoNhatLbl.TabIndex = 2;
            this.caoNhatLbl.Text = "Nhân viên có doanh số cao nhất :";
            // 
            // ThongKeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.chart1);
            this.Name = "ThongKeForm";
            this.Size = new System.Drawing.Size(1500, 800);
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton sanPhamRad;
        private System.Windows.Forms.RadioButton nhanVienRad;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton doanhThuRad;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox thangCmbx;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox namCmbx;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label thapNhatLbl;
        private System.Windows.Forms.Label caoNhatLbl;
        private System.Windows.Forms.ComboBox nhanvienCmbx;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ListView thongKeListView;
    }
}
