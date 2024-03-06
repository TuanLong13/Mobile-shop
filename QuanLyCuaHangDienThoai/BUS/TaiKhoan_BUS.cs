using QuanLyCuaHangDienThoai.BUS;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyCuaHangDienThoai.BUS
{
    internal class TaiKhoan_BUS
    {
        Database db;
        public TaiKhoan_BUS() 
        {
            db = new Database();
        }
        public DataTable CheckUser(string username, string password)
        {
            string sql = $"SELECT * FROM TAIKHOAN WHERE USERNAME = '{username}' AND PASSWORD = '{password}' and tinhtrang =1";
            return db.Execute(sql);
        }
        public DataTable checkPhanQuyen(string username)
        {
            string sql = String.Format("SELECT CHUCVU.MACHV, PHANQUYEN.MAPQ FROM TAIKHOAN JOIN NHANVIEN ON TAIKHOAN.MANV = NHANVIEN.MANV JOIN CHUCVU ON NHANVIEN.MACHV = CHUCVU.MACHV JOIN PHANQUYEN ON CHUCVU.MACHV = PHANQUYEN.MACHV WHERE TAIKHOAN.USERNAME = {0};",username );
            return db.Execute(sql);
        }
        public DataTable layDanhSachTaiKhoan()
        {
            string sql = "Select T.MATK, N.TENNV, T.USERNAME, T.PASSWORD, T.TINHTRANG, T.MANV from TAIKHOAN T, NHANVIEN N where T.MANV = N.MANV";
            return db.Execute(sql);
        }
        public DataTable layDanhSachNhanVien()
        {
            string sql = "Select MANV, TENNV from NHANVIEN";
            return db.Execute(sql);
        }
        public DataTable layDanhSachMaPQ()
        {
            string sql = "SELECT MAPQ FROM PHANQUYEN";
            return db.Execute(sql);
        }

        public void themTaiKhoan(int manv,string username, string password,int tinhtrang)
        {
            string sql = String.Format("insert into TAIKHOAN(MANV,USERNAME,PASSWORD,TINHTRANG) values( '{0}','{1}','{2}','{3}')", manv,username, password, tinhtrang);
            db.ExecuteNonQuery(sql);
        }
        public void suaTaiKhoan(string username, string password, int tinhtrang)
        {
            string sql = String.Format("update TAIKHOAN set PASSWORD = {0}, TINHTRANG = {1} where USERNAME = '{2}'",password,tinhtrang, username);
            db.ExecuteNonQuery(sql);
        }
        public void xoaTaiKhoan(string ma)
        {
            string sql = String.Format("delete from TAIKHOAN where MATK = {0}", Int32.Parse(ma));
            db.ExecuteNonQuery(sql);
        }
        public DataTable timKiemTaiKhoan(string username)
        {
            string sql = String.Format("select T.MATK, N.TENNV, T.USERNAME, T.PASSWORD, T.TINHTRANG, T.MANV from TAIKHOAN T, NHANVIEN N where T.MANV = N.MANV and T.USERNAME like N'%{0}%'", username);
            return db.Execute(sql);
        }
        public DataTable timKiemTaiKhoanKhongKhoa(string username)
        {
            string sql = String.Format("select T.MATK, N.TENNV, T.USERNAME, T.PASSWORD, T.TINHTRANG, T.MANV from TAIKHOAN T, NHANVIEN N where T.MANV = N.MANV and TINHTRANG = 1 and T.USERNAME like N'%{0}%'", username);
            return db.Execute(sql);
        }
        public bool kiemTraTaiKhoan(string username)
        {
            string sql = String.Format("select * from TAIKHOAN where USERNAME = '{0}'", username);
            DataTable dt = db.Execute(sql);
            if( dt.Rows.Count == 0 )
            {
                return true;
            }
            return false;
        }
        public DataTable layDanhSachTaiKhoanKhongKhoa()
        {
            string sql = "Select T.MATK, N.TENNV, T.USERNAME, T.PASSWORD, T.TINHTRANG, T.MANV from TAIKHOAN T, NHANVIEN N where T.MANV = N.MANV and TINHTRANG = 1";
            return db.Execute(sql);
        }
    }
}
