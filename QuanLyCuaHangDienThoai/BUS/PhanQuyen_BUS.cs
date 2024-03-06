using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.ComponentModel.Design.ObjectSelectorEditor;

namespace QuanLyCuaHangDienThoai.BUS
{
    internal class PhanQuyen_BUS
    {
        Database db;
        public PhanQuyen_BUS()
        {
            db = new Database();
        }
        public DataTable layDanhSachMenuTheoQuyen(string USERNAME)
        {
            string sql = "SELECT d.MAPQ,TENPQ FROM TAIKHOAN a";
            sql += " INNER JOIN NHANVIEN b ON a.MANV = b.MANV";
            sql += " INNER JOIN CT_PHANQUYEN c ON b.MACHV = c.MACHV";
            sql += " INNER JOIN PHANQUYEN d ON c.MAPQ = d.MAPQ";
            sql += " WHERE USERNAME = '" + USERNAME + "'";
            return db.Execute(sql);
        }
        public DataTable layDanhSachPhanQuyen()
        {
            string sql = "Select * from PHANQUYEN";
            return db.Execute(sql);
        }
        public void themPQ(string ten)
        {
            string sql = String.Format("insert into PHANQUYEN(TENPQ) values(N'{0}')", ten);
            db.ExecuteNonQuery(sql);
        }
        public void suaPQ(string ma, string ten)
        {
            string sql = String.Format("update PHANQUYEN set TENPQ = N'{0}' where MAPQ = {1}", ten, Int32.Parse(ma));
            db.ExecuteNonQuery(sql);
        }
        public void xoaPQ(string ma)
        {
            string sql = String.Format("delete from PHANQUYEN where MAPQ = {0}", Int32.Parse(ma));
            db.ExecuteNonQuery(sql);
        }
        public DataTable timKiemPQ(string ten)
        {
            string sql = String.Format("select * from PHANQUYEN where TENPQ like N'%{0}%'", ten);
            return db.Execute(sql);
        }
    }
}
