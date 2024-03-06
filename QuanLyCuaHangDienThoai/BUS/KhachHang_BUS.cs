using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyCuaHangDienThoai
{
    internal class KhachHang_BUS
    {
        Database db;
        public KhachHang_BUS()
        {
            db = new Database();
        }
        public DataTable layDanhSachKhachHang()
        {
            string sql = "Select * from KhachHang";
            return db.Execute(sql);
        }
        public void themKhachHang(string ten, string sdt)
        {
            string sql = String.Format("insert into KhachHang(TENKH, SDT) values(N'{0}', '{1}')", ten, sdt);
            db.ExecuteNonQuery(sql);
        }
        public void suaKhachHang(string ma, string ten, string sdt)
        {
            string sql = String.Format("update KhachHang set TENKH = N'{0}', SDT = '{1}' where MAKH = {2}", ten, sdt, Int32.Parse(ma));
            db.ExecuteNonQuery(sql);
        }
        public void xoaKhachHang(string ma)
        {
            string sql = String.Format("delete from KhachHang where MAKH = {0}", Int32.Parse(ma));
            db.ExecuteNonQuery(sql);
        }
        public DataTable timKiemKhachHang(string ten)
        {
            string sql = String.Format("select * from KhachHang where TENKH like N'%{0}%'", ten);
            return db.Execute(sql);
        }
        public bool kiemTraSDT(string sdt)
        {
            string sql = String.Format("select SDT from KhachHang where SDT = '{0}'", sdt);
            DataTable dt = db.Execute(sql);
            if (dt.Rows.Count == 0)
            {
                return true;
            }
            return false;
        }

        public bool KiemTraThamChieu(string makh)
        {
            string strSQL = string.Format("SELECT COUNT(*) FROM HoaDon WHERE Makh = {0}", Int32.Parse(makh));
            object result = db.ExecuteScalar(strSQL);
            if (result != null)
            {
                int count = Convert.ToInt32(result);
                return count > 0;
            }
            return false;
        }
        
    }
}
