using ClosedXML.Excel;
using QuanLyCuaHangDienThoai.BUS;
using QuanLyCuaHangDienThoai.GUI.QuanLySanPham;
using System;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace QuanLyCuaHangDienThoai.GUI.ThongKe
{
    public partial class ThongKeForm : UserControl
    {
        public ThongKeBUS tk_bus;
        public UI parent_f;
        private Series series;
        private string title_chart;

        public ThongKeForm()
        {
            tk_bus = new ThongKeBUS();
            InitializeComponent();
            this.namCmbx.Items.AddRange(tk_bus.ds_nam);
            this.namCmbx.SelectedIndex = this.namCmbx.Items.Count-1;
            nhanVienRad.Checked = true;
            this.nhanvienCmbx.SelectedIndex = 0;
            initThongKeNhanVien(Int32.Parse(this.namCmbx.Items[this.namCmbx.Items.Count-1].ToString()), 0, true);
            chart1.Font = new System.Drawing.Font("Tahoma", 12);
        }
        public void initThongKeNhanVien(int nam, int thang, bool doanhso)
        {
            tk_bus.initThongKeTheoNhanVien(nam, thang, doanhso);

            // TODO : thống kê chung
            string tieuchi = (doanhso) ? "doanh số" : "doanhthu";
            if (tk_bus.tk_table.Rows.Count > 0)
            {
                thapNhatLbl.Text = "Nhân viên có " + tieuchi + " thấp nhất :" + tk_bus.tk_table.Rows[tk_bus.tk_table.Rows.Count - 1][0].ToString();
                caoNhatLbl.Text = "Nhân viên có " + tieuchi + " cao nhất :" + tk_bus.tk_table.Rows[0][0].ToString();
            }
            else {
                thapNhatLbl.Text = "";
                caoNhatLbl.Text = "";
            }
            // TODO : chuẩn bị bảng thống kê
            this.thongKeListView.Clear();
            thongKeListView.Columns.Add("Tên nhân viên");
            if (doanhso)
            {
                thongKeListView.Columns.Add("số hóa đơn");
            }
            else
            {
                thongKeListView.Columns.Add("tổng doanh thu");
            }

            // TODO : chuẩn bị biểu đồ 
            chart1.Legends.Clear();
            chart1.Series.Clear();
            chart1.Titles.Clear();
            chart1.ResetAutoValues();

            title_chart = "";
            if (doanhso)
            {
                title_chart = "Doanh số";
            }
            else
            {
                title_chart = "Doanh thu";
            }
            if(nam > 0)
            {
                title_chart += " năm " + nam;
                if (thang > 0)
                {
                    title_chart += " tháng " + thang;
                }
            }

            chart1.Titles.Add(title_chart).Font = new System.Drawing.Font("Tahoma", 15);
            // vẽ và điền bảng
            veBieuDo_DienBang();
            resizeListView();
        }

        public void initThongKeTheoSanPham(int nam, int thang)
        {
            tk_bus.initThongKeTheoSanPham(nam, thang);

            // TODO : thống kê chung
            thapNhatLbl.Text = "Sản phẩm có doanh số bán ra thấp nhất : " + tk_bus.tk_table.Rows[0][0].ToString();
            caoNhatLbl.Text = "Sản phẩm có doanh số bán ra cao nhất : " + tk_bus.tk_table.Rows[tk_bus.tk_table.Rows.Count - 1][0].ToString();

            // TODO : chuẩn bị bảng thống kê
            this.thongKeListView.Clear();
            this.thongKeListView.Columns.Add("Sản phẩm");
            this.thongKeListView.Columns.Add("Doanh số bán ra");

            title_chart = "Doanh số sản phẩm bán ra ";
            if(nam > 0)
            {
                title_chart += "năm " + nam;
                if(thang > 0)
                {
                    title_chart += "tháng " + thang;
                }
            }
            chart1.Titles.Add(title_chart).Font = new System.Drawing.Font("Tahoma", 15);

            // TODO : chuẩn bị biểu đồ 
            chart1.Legends.Clear();
            chart1.Series.Clear();
            chart1.Titles.Clear();

            // vẽ và điền bảng
            veBieuDo_DienBang();
            resizeListView();
        }

        public void initThongKeTheoDoanhThu(int nam)
        {
            tk_bus.initThongKeTheoDoanhThu(nam);
            // TODO : thống kê chung
            thapNhatLbl.Text = "Tháng có doanh thu thấp nhất : " + tk_bus.tk_table.Rows[0][0].ToString();
            caoNhatLbl.Text = "Tháng có doanh thu cao nhất : " + tk_bus.tk_table.Rows[tk_bus.tk_table.Rows.Count - 1][0].ToString();

            // TODO : chuẩn bị bảng thống kê
            this.thongKeListView.Clear();
            this.thongKeListView.Columns.Add("Tháng");
            this.thongKeListView.Columns.Add("Doanh thu");

            title_chart = "Doanh thu";
            if (nam > 0)
            {
                title_chart += "năm " + nam;
            }
            chart1.Titles.Add(title_chart).Font = new System.Drawing.Font("Tahoma", 15);
            

            // TODO : chuẩn bị biểu đồ 
            chart1.Legends.Clear();
            chart1.Series.Clear();
            chart1.Titles.Clear();



            // vẽ và điền bảng
            veBieuDo_DienBang();
            series.ChartType = SeriesChartType.Spline;
            resizeListView();
        }

        public void resizeListView()
        {
            for(int i = 0; i<thongKeListView.Columns.Count; i++)
            {
                thongKeListView.Columns[i].Width = thongKeListView.Width / thongKeListView.Columns.Count;
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int nam = Int32.Parse(namCmbx.SelectedItem.ToString());
            tk_bus.layCacThangTheoNam(nam);
            thangCmbx.Items.Clear();
            thangCmbx.Items.AddRange(tk_bus.ds_thang);

            int thang;
            if(thangCmbx.SelectedIndex > 0)
            {
                thang = Int32.Parse(thangCmbx.SelectedItem.ToString());
            }
            else
            {
                thang = 0;
            }


            if (nhanVienRad.Checked)
            {
                if(nhanvienCmbx.SelectedItem.ToString().Equals("doanh số"))
                {
                    initThongKeNhanVien(nam, thang, true);
                }
                else
                {
                    initThongKeNhanVien(nam, thang, false);
                }
            }else if(sanPhamRad.Checked)
            {
                initThongKeTheoSanPham(nam, thang);
            }else if (doanhThuRad.Checked)
            {
                initThongKeTheoDoanhThu(nam);
            }
        }

        private void thangCmbx_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(thangCmbx.SelectedIndex >= 0)
            {
                int thang = Int32.Parse(thangCmbx.SelectedItem.ToString());
                int nam = Int32.Parse(namCmbx.SelectedItem.ToString());

                if (nhanVienRad.Checked)
                {
                    if(nhanvienCmbx.SelectedIndex == 0)
                    {
                        initThongKeNhanVien(nam, thang, true);
                    }
                    else
                    {
                        initThongKeNhanVien(nam, thang, false);
                    }
                }else if (sanPhamRad.Checked)
                {
                    initThongKeTheoSanPham(nam, thang);
                }else if (doanhThuRad.Checked)
                {
                    initThongKeTheoDoanhThu(nam);
                }
            }
            else
            {
                int nam = Int32.Parse(namCmbx.SelectedItem.ToString());
            }
        }

        public void veBieuDo_DienBang()
        {
            series = new Series();
            chart1.Series.Add(series);
            chart1.ChartAreas["ChartArea1"].AxisX.LabelStyle.Font = new System.Drawing.Font("Arial", 12, System.Drawing.FontStyle.Regular);

            for (int i = 0; i < tk_bus.tk_table.Rows.Count; i++)
            {
                if (Int64.Parse(tk_bus.tk_table.Rows[i][1].ToString().Split('.')[0]) > 0)
                {
                    if (series.ChartType == SeriesChartType.Pie && i == 10)
                        break;
                    // Vẽ biểu đồ
                    DataPoint dataPoint = new DataPoint();
                    dataPoint.BorderWidth = 5;
                    dataPoint.SetValueXY(tk_bus.tk_table.Rows[i][0].ToString(), Int64.Parse(tk_bus.tk_table.Rows[i][1].ToString().Split('.')[0]));
                    dataPoint.Color = chart1.PaletteCustomColors[i % chart1.PaletteCustomColors.Count()];
                    dataPoint.ToolTip = tk_bus.tk_table.Rows[i][0].ToString();
                    series.Points.Add(dataPoint);
                }

                // thêm vào bảng
                ListViewItem lvi = thongKeListView.Items.Add(tk_bus.tk_table.Rows[i][0].ToString());
                lvi.SubItems.Add(tk_bus.tk_table.Rows[i][1].ToString());
            }
        }

        private void nhanVienRad_CheckedChanged(object sender, EventArgs e)
        {
            if (thangCmbx.Enabled == false)
            {
                thangCmbx.Enabled = true;
            }
            if (nhanVienRad.Checked)
            {
                nhanvienCmbx.Enabled = true;
                nhanvienCmbx.SelectedIndex = 0;
                int thang;
                if (thangCmbx.SelectedIndex >= 0)
                {
                    thang = Int32.Parse(thangCmbx.SelectedItem.ToString());
                }
                else
                {
                    thang = 0;
                }
                int nam = Int32.Parse(namCmbx.SelectedItem.ToString());
                initThongKeNhanVien(nam, thang, true);
            }
            else
            {
                nhanvienCmbx.Enabled = false;
            }
        }

        private void sanPhamRad_CheckedChanged(object sender, EventArgs e)
        {
            if(thangCmbx.Enabled == false)
            {
                thangCmbx.Enabled = true;
            }
            int nam = Int32.Parse(namCmbx.SelectedItem.ToString());
            int thang;
            if (thangCmbx.SelectedIndex >= 0)
            {
                thang = Int32.Parse(thangCmbx.SelectedItem.ToString());
            }
            else
            {
                thang = 0;
            }
            initThongKeTheoSanPham(nam, thang);
        }

        private void doanhThuRad_CheckedChanged(object sender, EventArgs e)
        {
            thangCmbx.Enabled = false;
            int nam = Int32.Parse(namCmbx.SelectedItem.ToString());
            initThongKeTheoDoanhThu(nam);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Excel Files|*.xlsx|All Files|*.*";
            openFileDialog.Title = "Chọn file Excel";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string selectedFile = openFileDialog.FileName;
                using (var workbook = new XLWorkbook())
                {
                    var worksheet = workbook.Worksheets.Add("Sheet1");

                    // Copy the data from the DataTable to the worksheet
                    worksheet.Cell(1, 1).Value = title_chart.ToString();
                    worksheet.Cell(2, 1).InsertTable(tk_bus.tk_table.AsEnumerable());

                    chart1.SaveImage("chart_image.png", ChartImageFormat.Png);
                    worksheet.AddPicture("chart_image.png").MoveTo(worksheet.Cell(tk_bus.tk_table.Rows.Count + 4, 1),1, 1);

                    // Save the workbook to a file
                    workbook.SaveAs(selectedFile);

                    Process.Start(selectedFile);
                }

            }
            
        }
    }
}
