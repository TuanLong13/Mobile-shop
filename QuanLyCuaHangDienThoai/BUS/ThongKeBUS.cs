using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.DataVisualization.Charting;

namespace QuanLyCuaHangDienThoai.BUS
{

    public class ThongKeBUS
    {
        public DataTable tk_table;
        Database db;
        public Object[] ds_nam = {};
        public Object[] ds_thang = {};

        public ThongKeBUS()
        {
            db = new Database();
            layCacNam();
        }

        public void layCacNam()
        {
            string query = "select distinct YEAR(NGAYLAP) from Hoadon where Hoadon.TRANGTHAI = 1";
            DataTable data = db.Execute(query);
            ds_nam = new Object[data.Rows.Count];
            for (int i =0; i< data.Rows.Count; i++)
            {
                ds_nam[ds_nam.Length - 1] = data.Rows[i][0].ToString();
            }
        }

        public void layCacThangTheoNam(int nam)
        {
            string query = "select distinct MONTH(NGAYLAP) from Hoadon where Hoadon.TRANGTHAI = 1 and YEAR(NGAYLAP) =" +  nam;
            DataTable data = db.Execute(query);
            ds_thang = new Object[data.Rows.Count];
            for (int i = 0; i < data.Rows.Count; i++)
            {
                ds_thang[i] = data.Rows[i][0].ToString();
            }
        }

        public void initThongKeTheoNhanVien(int nam = 0, int thang = 0, bool doanhso = true)
        {
            string query;

            if (doanhso)
            {
                query = "select nv.TENNV, doanhso = count(hd.mahd)" +
                    "\r\nfrom hoadon as hd right join nhanvien as nv on hd.MANV = nv.MANV" +
                    "\r\nwhere nv.MACHV = 1";
            }
            else
            {
                query = "select nv.TENNV, doanhthu =  sum(hd.tongtien)" +
                    "\r\nfrom hoadon as hd right join nhanvien as nv on hd.MANV = nv.MANV" +
                    "\r\nwhere nv.MACHV = 1";
            }

            if(nam != 0)
            {
                query += "and YEAR(hd.ngaylap) = " + nam;
                if(thang != 0)
                {
                    query += "and Month(hd.ngaylap) = " + thang;
                }
            }

            if (doanhso)
            {
                query += "group by nv.TENNV\r\n" +
                        "order by count(hd.mahd) desc";
            }
            else
            {
                query += "group by nv.TENNV\r\n" +
                       "order by sum(hd.tongtien) desc";
            }
            tk_table = db.Execute(query);
        }

        public void initThongKeTheoSanPham(int nam = 0, int thang = 0)
        {
            string query = "select sp.TENSP, solgban = ISNULL(sum(chitiet.SOLUONG),0)" +
                "\r\n from sanpham as sp left join (" +
                "\r\n select cthd.MASP, cthd.SOLUONG" +
                "\r\n from" +
                "\r\n ct_hoadon as cthd" +
                " \r\n join hoadon as hd on hd.MAHD = cthd.MAHD";
                
            if(nam > 0)
            {
            query += "\r\n where Year(hd.NGAYLAP) = " + nam;
                if(thang > 0)
                {
                    query += " and month(hd.NGAYLAP) = " + thang;
                }
            }
            query +=
                "\r\n ) as chitiet" +
                "\r\n on sp.MASP = chitiet.MASP" +
                "\r\n Group by sp.TENSP" +
                "\r\n order by  sum(chitiet.SOLUONG) desc";
            tk_table = db.Execute(query);
        }

        public void initThongKeTheoDoanhThu(int nam = 0)
        {
            string query = "select thang = Month(hd.NGAYLAP), doanhthu = sum(hd.TONGTIEN)" +
                "\r\nfrom Hoadon as hd" +
                "\r\nwhere hd.TRANGTHAI = 1 and Year(hd.NGAYLAP) ="+nam+
                "\r\nGroup by Month(hd.NGAYLAP)";
            tk_table = db.Execute(query);
        }
    }
}
