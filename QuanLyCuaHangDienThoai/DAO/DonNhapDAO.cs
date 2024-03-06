using QuanLyCuaHangDienThoai.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyCuaHangDienThoai.DAO
{
    internal class DonNhapDAO
    {
        Database db;
        private string strSQL;
        public DonNhapDAO()
        {
            db = new Database();
        }
        public DataTable LayDSDonNhap()
        {
            strSQL = "Select Madn, Mancc, Manv, Tongtien, Ngaylap From DonNhap";
            DataTable dt = db.Execute(strSQL); //Goi phuong thuc truy xuat du lieu
            return dt;
        }

        public DataTable LayDataCB(string ma, string table)
        {
            strSQL = string.Format("Select DISTINCT {0} From {1} Order by {0} ASC", ma, table);
            DataTable dt = db.Execute(strSQL); //Goi phuong thuc truy xuat du lieu
            return dt;
        }
        public bool KiemTraNhaCungCap(string mancc)
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
        public void XoaDonNhap(int dn)
        {
            strSQL = string.Format("Delete from DonNhap where Madn = '{0}'", dn);
            db.ExecuteNonQuery(strSQL);
        }


        public void ThemDonNhap(DonNhapDTO dn)
        {

            strSQL = string.Format("Insert Into DonNhap(Mancc, Manv,Tongtien, Ngaylap) Values('{0}', '{1}', '{2}', '{3}')", dn.MaNCC, dn.MaNV, dn.TongTien, dn.NgayNhap);
            db.ExecuteNonQuery(strSQL);
        }

        public void CapNhatDonNhap(DonNhapDTO dn)
        {
            //Chuẩn bị câu lẹnh truy vấn
            strSQL = string.Format("Update DonNhap set Mancc = {0}, Manv = {1}, Tongtien = {2}, Ngaylap = '{3}' where Madn = {4}", dn.MaNCC, dn.MaNV, dn.TongTien, dn.NgayNhap, dn.MaDN);
            db.ExecuteNonQuery(strSQL);
        }
        public DataTable TimDonNhap(string lable, int value)
        {
            strSQL = string.Format("Select Madn, Mancc, Manv, Tongtien, Ngaylap From DonNhap Where {0} = {1}", lable, value);
            DataTable dt = db.Execute(strSQL); //Goi phuong thuc truy xuat du lieu
            return dt;
        }
    }
}
