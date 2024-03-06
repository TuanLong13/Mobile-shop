using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.Data;
using System.Windows.Forms;
using QuanLyCuaHangDienThoai.DTO;
using System.Collections.Specialized;
using System.ComponentModel;
using System.IO;
using OfficeOpenXml;
using System.Security.Policy;
using DocumentFormat.OpenXml.Drawing;

namespace QuanLyCuaHangDienThoai.BUS
{
    public class SanPhamBUS
    {
        public DataTable DsSanPham;
        public DataTable DsHienThi;
        public ArrayList DsHang = new ArrayList();
        Database db;
        Dictionary<string, string> dic;

        public int ascending = 0;
        public string sortingColumn = null;

        public DataTable DsMau;

        public DataRow sanPhamDangChon;
        public Dictionary<string, string> color_dic;

        public SanPhamBUS()
        {
            db = new Database();
            layDanhSachSanPham();
            layDanhSachHang();
            layDanhSachMau();
            // dictionary hỗ trợ sắp xếp datatable
            dic = new Dictionary<string, string>();
            dic.Add("Tên sản phẩm", "TENSP");
            dic.Add("Hệ điều hành", "OS");
            dic.Add("Camera", "CAMERA");
            dic.Add("Chip", "CPU");
            dic.Add("Ram", "RAM");
            dic.Add("Dung lượng", "BONHO");
            dic.Add("Pin", "PIN");
            dic.Add("Giá", "DONGIA");
            dic.Add("Số lượng", "SOLUONG");
        }

        public void layDanhSachHang()
        {
            DsHang.Clear();
            for (int i = 0; i < DsHienThi.Rows.Count; i++)
            {
                if (!DsHang.Contains(DsHienThi.Rows[i][4].ToString()))
                {
                    DsHang.Add(DsHienThi.Rows[i][4].ToString());
                }
            }
        }

        public void layDanhSachSanPham()
        {
            String query = "Select * from sanpham";
            DsSanPham = db.Execute(query);
            DsHienThi = DsSanPham.Clone();
            DsHienThi.Clear();
            foreach (DataRow originalRow in DsSanPham.Rows)
            {
                DataRow clonedRow = DsHienThi.NewRow();
                clonedRow.ItemArray = originalRow.ItemArray;
                DsHienThi.Rows.Add(clonedRow);
            }

        }

        public void layDanhSachMau()
        {
            color_dic = new Dictionary<string, string>();
            color_dic.Clear();
            String query = "Select * from MAU";
            DsMau = db.Execute(query);

            for (int i = 0; i < DsMau.Rows.Count; i++)
            {
                if(!color_dic.ContainsKey(DsMau.Rows[i][1].ToString()))
                    color_dic.Add(DsMau.Rows[i][1].ToString(), DsMau.Rows[i][2].ToString());
            }
        }

        public void ThemSanPham(SanPhamDTO sanpham)
        {
            db.ExecuteNonQuery(sanpham.insertString());
        }


        public void ThemMau(String tenMau, String maMau)
        {
            db.ExecuteNonQuery(String.Format("Insert into Mau values(N'{0}','{1}')", tenMau, maMau));
        }
        public string ThemSanPhamBangExcel(string filepath)
        {
            bool confirm = false;
            List<string> ds_sanpham_loi = new List<string>();
            using (var package = new ExcelPackage(new FileInfo(filepath)))
            {
                var worksheet = package.Workbook.Worksheets[0];

                int rowCount = worksheet.Dimension.Rows;
                int colCount = worksheet.Dimension.Columns;
              /*  MessageBox.Show(rowCount + " : " + colCount);*/

                for (int row = 2; row <= rowCount; row++)
                {
                    for (int col = 1; col <= colCount; col++)
                    {
                        if (worksheet.Cells[row, col].Text == "")
                        {
                            if(!ds_sanpham_loi.Contains(worksheet.Cells[row, col].Text))
                                ds_sanpham_loi.Add(worksheet.Cells[row, 1].Text);
                            DialogResult dialogResult = MessageBox.Show("Có khoản trắng trong file, bạn vẫn muốn nhập bằng Excel chứ?", "Cảnh báo", MessageBoxButtons.YesNo);
                            if (dialogResult == DialogResult.Yes)
                            {
                                confirm = true;
                                break;
                            }
                            else
                            {
                                return "hủy";
                            }
                        }
                    }
                    if (confirm)
                    {
                        break;
                    }
                }


                for (int row = 2; row <= rowCount; row++)
                {
                        // Thêm màu
                        int id_mau = 1;
                        string tenmau = worksheet.Cells[row, 2].Text;
                        string mamau = worksheet.Cells[row, 3].Text;
                        bool color_exist = false;
                        for (int i = 0; i < DsMau.Rows.Count; i++)
                        {
                            if (DsMau.Rows[i][1].ToString().Equals(tenmau))
                            {
                                id_mau = Int32.Parse(DsMau.Rows[i][0].ToString());
                                color_exist = true;
                                break;
                            }
                        }

                        // kiểm tra trùng tên 
                        string tensp = worksheet.Cells[row, 1].Text;
                        bool sp_exist = false;
                        for (int i = 0; i < DsSanPham.Rows.Count; i++)
                        {
                            if (tensp.Equals(DsSanPham.Rows[i][1].ToString()))
                            {
                                if (!ds_sanpham_loi.Contains(tensp))
                                    ds_sanpham_loi.Add(tensp);
                                sp_exist = true;
                                break;
                            }
                        }
                        string hang = worksheet.Cells[row, 4].Text;
                        string cpu = worksheet.Cells[row, 5].Text;
                        string gpu = worksheet.Cells[row, 6].Text;
                        string ram = worksheet.Cells[row, 7].Text;
                        string bonho = worksheet.Cells[row, 8].Text;
                        string manhinh = worksheet.Cells[row, 9].Text;
                        string hedieuhanh = worksheet.Cells[row, 10].Text;
                        int namsx = Int32.Parse(worksheet.Cells[row, 11].Text);
                        int baohanh = Int32.Parse(worksheet.Cells[row, 12].Text);
                        string pin = worksheet.Cells[row, 13].Text;
                        string phukien = worksheet.Cells[row, 14].Text;
                        string camera = worksheet.Cells[row, 15].Text;

                        if (!sp_exist && !ds_sanpham_loi.Contains(tensp) && tensp!="")
                        {
                            if (!color_exist)
                            {
                                ThemMau(tenmau, mamau);
                                layDanhSachMau();
                                id_mau = Int32.Parse(DsMau.Rows[DsMau.Rows.Count - 1][0].ToString());
                            }
                            SanPhamDTO sp = new SanPhamDTO(0, tensp, "notfound", id_mau, hang, 0, 0, cpu, gpu, ram, bonho, manhinh, hedieuhanh, namsx, baohanh, pin, phukien, camera);
                            ThemSanPham(sp);
                            layDanhSachSanPham();
                        }
                }
            }
            if (ds_sanpham_loi.Count > 0)
            {
                string thongBaoLoi = "Danh sách sản phẩm nhập bị lỗi :";
                for (int i = 0; i < ds_sanpham_loi.Count; i++)
                {
                    thongBaoLoi += "\n" + ds_sanpham_loi[i];
                }
                return thongBaoLoi;
            }
            else
            {
                return "";
            }
        }

        public void CapNhatSanPham(SanPhamDTO sanpham)
        {
            db.ExecuteNonQuery(sanpham.updateString());
        }

        public bool xoaDuocKhong(int masp)
        {
            DataTable dataTable = db.Execute("Select Sanpham.MaSP" +
                "\r\nfrom Sanpham" +
                "\r\nwhere Sanpham.MASP" +
                "\r\nin " +
                "\r\n(select sp.masp" +
                "\r\nfrom CT_DONNHAP as ctdn join  Sanpham as sp on ctdn.MASP = sp.MASP)" +
                "\r\nor" +
                "\r\nSanpham.MASP" +
                " \r\nin" +
                "\r\n(select sp.masp" +
                "\r\nfrom CT_HOADON as cthd join  Sanpham as sp on cthd.MASP = sp.MASP)");
            for (int i = 0; i < dataTable.Rows.Count; i++)
            {
                if (masp == Int32.Parse(dataTable.Rows[i][0].ToString()))
                {
                    return false;
                }
            }
            return true;
        }

        public void XoaSanPham(int masp)
        {
            db.ExecuteNonQuery("Delete sanpham where masp = " + masp);
        }

        public void timKiem(string timKiemStr)
        {
            DsHienThi.Clear();
            for (int i = 0; i < DsSanPham.Rows.Count; i++)
            {
                if (DsSanPham.Rows[i][1].ToString().Trim().ToLower().Contains(timKiemStr))
                {
                    DataRow clonedRow = DsHienThi.NewRow();
                    clonedRow.ItemArray = DsSanPham.Rows[i].ItemArray;
                    DsHienThi.Rows.Add(clonedRow);
                }
            }
        }

        public void sapXep(string sortColumn)
        {
            if (sortColumn.Trim() != "" && !sortColumn.Equals("Hình ảnh"))
                if (sortColumn.Equals(sortingColumn))
                {
                    switch (ascending)
                    {
                        case 0: ascending = 1; break;
                        case 1: ascending = 2; break;
                        case 2: ascending = 0; break;
                    }
                }
                else
                {
                    ascending = 1;
                    sortingColumn = sortColumn;
                }

            DataView dataView = DsHienThi.DefaultView;
            switch (ascending)
            {
                case 0:
                    dataView.Sort = "MASP"; break;
                case 1:
                    dataView.Sort = $"{dic[sortColumn]} ASC"; break;

                case 2:
                    dataView.Sort = $"{dic[sortColumn]} DESC"; break;
            }

            DsHienThi = dataView.ToTable();
        }
        public void filterByBrand(ArrayList HangArray, String timKiemStr)
        {
            timKiem(timKiemStr);
            for (int i = 0; i < DsHienThi.Rows.Count; i++)
            {
                if (!HangArray.Contains(DsHienThi.Rows[i][4].ToString()))
                {
                    DsHienThi.Rows.RemoveAt(i);
                    i--;
                }
            }
        }
    }
}

