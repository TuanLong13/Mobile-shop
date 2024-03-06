using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyCuaHangDienThoai.BUS
{
    internal class ChucVu_BUS
    {
        Database db;
        public ChucVu_BUS()
        {
            db = new Database();
        }
        public DataTable layDanhSachChucVu()
        {
            string sql = "Select * from CHUCVU";
            return db.Execute(sql);
        }
        public void themChucVu(string ten)
        {
            string sql = String.Format("insert into CHUCVU(TENCHUCVU) values(N'{0}')", ten);
            db.ExecuteNonQuery(sql);
        }
        public void suaChucVu(string ma, string ten)
        {
            string sql = String.Format("update CHUCVU set TENCHUCVU = N'{0}' where MACHV = {1}", ten, Int32.Parse(ma));
            db.ExecuteNonQuery(sql);
        }
        public void xoaChucVu(string ma)
        {
            string sql = String.Format("delete from CHUCVU where MACHV = {0}", Int32.Parse(ma));
            db.ExecuteNonQuery(sql);
        }
        public DataTable timKiemChucVu(string ten)
        {
            string sql = String.Format("select * from CHUCVU where TENCHUCVU like N'%{0}%'", ten);
            return db.Execute(sql);
        }
    }
}
