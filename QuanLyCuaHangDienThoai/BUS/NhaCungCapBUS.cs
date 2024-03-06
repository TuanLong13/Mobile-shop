using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuanLyCuaHangDienThoai.DAO;
using QuanLyCuaHangDienThoai.DTO;

namespace QuanLyCuaHangDienThoai.BUS
{
    internal class NhaCungCap_BUS
    {
        Database db;
        public NhaCungCap_BUS()
        {
            db = new Database();
        }
        public DataTable LayDSNhaCungCap()
        {
            string strSQL = "Select * From NhaCungCap";
            return db.Execute(strSQL);
        }
        public void themNhaCungCap(NhaCungCapDTO cc)
        {
            string strSQL = string.Format("Insert Into NhaCungCap(Tencc,Diachi, Sdt) Values(N'{0}', N'{1}', '{2}')", cc.TenNCC, cc.DiaChi, cc.Sdt);
            db.ExecuteNonQuery(strSQL);
        }
        public void suaNhaCungCap(NhaCungCapDTO cc)
        {
            string strSQL = string.Format("Update NhaCungCap set Tencc = N'{0}', Diachi = N'{1}', Sdt = '{2}' where Mancc = {3}", cc.TenNCC, cc.DiaChi, cc.Sdt, cc.MaNCC);
            db.ExecuteNonQuery(strSQL);
        }
        public void xoaNhaCungCap(string cc)
        {
            string strSQL = string.Format("Delete from NhaCungCap where Mancc = {0}", Int32.Parse(cc));
            db.ExecuteNonQuery(strSQL);
        }
        public DataTable timKiemNhaCungCap(string ten)
        {
            string strSQL = string.Format("Select *  From NhaCungCap Where Tencc like '%{0}%'", ten);
            return db.Execute(strSQL);
        }
        public bool kiemTraSDT(string sdt)
        {
            string sql = String.Format("select SDT from NhaCungCap where SDT = '{0}'", sdt);
            DataTable dt = db.Execute(sql);
            if (dt.Rows.Count == 0)
            {
                return true;
            }
            return false;
        }

        public bool KiemTraThamChieu(string mancc)
        {
            string strSQL = string.Format("SELECT COUNT(*) FROM DonNhap WHERE Mancc = {0}", Int32.Parse(mancc));
            object result = db.ExecuteScalar(strSQL);
            if (result != null)
            {
                int count = Convert.ToInt32(result);
                return count > 0;
            }
            return false;
        }
        public bool KiemTraTonTai(string tencc)
        {
            string strSQL = string.Format("SELECT TENCC FROM NhaCungCap WHERE Tencc = N'{0}'", tencc);
            DataTable dt = db.Execute(strSQL);
            if ( dt.Rows.Count == 0 )
            {
                return true;
            }
            return false;
        }
    }
}
