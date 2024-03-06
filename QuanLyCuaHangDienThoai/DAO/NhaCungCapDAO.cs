using QuanLyCuaHangDienThoai.DAO;
using QuanLyCuaHangDienThoai.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyCuaHangDienThoai.DAO
{
    internal class NhaCungCap_DAO : Database
    {
        Database db;
        private string strSQL;
        public NhaCungCap_DAO()
        {
            db = new Database();
        }
        public DataTable LayDSNhaCungCap()
        {
            strSQL = "Select Mancc, Tencc, Diachi, Sdt From NhaCungCap";
            DataTable dt = db.Execute(strSQL); //Goi phuong thuc truy xuat du lieu
            return dt;
        }

        public void XoaNhaCungCap(int cc)
        {
            strSQL = string.Format("Update NhaCungCap set Trangthai = 0 where Mancc = '{0}'", cc);
            db.ExecuteNonQuery(strSQL);
        }
        public void KhoiPhucNhaCungCap(string tencc)
        {
            strSQL = string.Format("Update NhaCungCap set Trangthai = 1 where Tencc like '{0}'", tencc);
            db.ExecuteNonQuery(strSQL);
        }

        public void ThemNhaCungCap(NhaCungCapDTO cc)
        {
            strSQL = string.Format("Insert Into NhaCungCap(Tencc,Diachi, Sdt) Values('{0}', '{1}', '{2}')", cc.TenNCC, cc.DiaChi, cc.Sdt);
            db.ExecuteNonQuery(strSQL);
        }

        public void CapNhatNhaCungCap(NhaCungCapDTO cc)
        {
            //Chuẩn bị câu lẹnh truy vấn
            strSQL = string.Format("Update NhaCungCap set Tencc = '{0}', Diachi ='{1}', Sdt = '{2}' where Mancc = {3}", cc.TenNCC, cc.DiaChi, cc.Sdt, cc.MaNCC);
            db.ExecuteNonQuery(strSQL);
        }
        public DataTable TimKiemNhaCungCap(string tencc)
        {
            strSQL = string.Format("Select Mancc, Tencc, Diachi, Sdt  From NhaCungCap Where Tencc like '%{0}%'", tencc);
            DataTable dt = db.Execute(strSQL); //Goi phuong thuc truy xuat du lieu
            return dt;
        }
        public bool KiemTraThamChieu(string mancc)
        {
            strSQL = string.Format("SELECT COUNT(*) FROM DonNhap WHERE Mancc = '{0}'", mancc);
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
            strSQL = string.Format("SELECT COUNT(*) FROM NhaCungCap WHERE Tencc like '{0}'", tencc);
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
