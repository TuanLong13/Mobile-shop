using QuanLyCuaHangDienThoai.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyCuaHangDienThoai.DAO
{
    internal class CTDonNhapDAO
    {
        Database db;
        private string strSQL;
        public CTDonNhapDAO()
        {
            db = new Database();
        }
        public DataTable LayDSChiTietDonNhap(int madn)
        {
            strSQL = string.Format("Select Masp, Soluong, Dongia From CT_DonNhap Where Madn = {0}", madn);
            DataTable dt = db.Execute(strSQL); //Goi phuong thuc truy xuat du lieu
            return dt;
        }

        public DataTable LayDataCB(string ma, string table)
        {
            strSQL = string.Format("Select DISTINCT {0} From {1} Order by {0} ASC", ma, table);
            DataTable dt = db.Execute(strSQL); //Goi phuong thuc truy xuat du lieu
            return dt;
        }
        public bool KiemTraSanPham(string maSP)
        {
            strSQL = string.Format("SELECT COUNT(*) FROM CT_DonNhap WHERE MaSP = '{0}'", maSP);
            object result = db.ExecuteScalar(strSQL);
            if (result != null)
            {
                int count = Convert.ToInt32(result);
                return count > 0;
            }
            return false;
        }
        public void XoaCTDonNhap(int dn)
        {
            strSQL = string.Format("Delete from CT_DonNhap where Masp = '{0}'", dn);
            db.ExecuteNonQuery(strSQL);
        }


        public void ThemCTDonNhap(ChiTietDonNhapDTO dn)
        {

            strSQL = string.Format("Insert Into CT_DonNhap(Madn, Masp, Soluong,Dongia) Values('{0}', '{1}', '{2}', {3})", dn.MaDN, dn.MaSP, dn.SoLuong, dn.DonGia);
            db.ExecuteNonQuery(strSQL);
        }

        public void CapNhatCTDonNhap(ChiTietDonNhapDTO dn)
        {
            //Chuẩn bị câu lẹnh truy vấn
            strSQL = string.Format("Update CT_DonNhap set Soluong = {0}, Dongia = {1} where Masp = {2} and Madn = {3}", dn.SoLuong, dn.DonGia, dn.MaSP, dn.MaDN);
            db.ExecuteNonQuery(strSQL);
        }

        public DataTable TimKiemChiTietDonNhap(int madn, int masp)
        {
            strSQL = string.Format("Select Masp, Soluong, Dongia From CT_DonNhap Where Madn = {0} and Masp = {1}", madn, masp);
            DataTable dt = db.Execute(strSQL); //Goi phuong thuc truy xuat du lieu
            return dt;
        }
    }
}
