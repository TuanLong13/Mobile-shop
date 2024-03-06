using QuanLyCuaHangDienThoai.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyCuaHangDienThoai.BUS
{
    internal class CTDonNhapBUS
    {
        Database db;
        private string strSQL;
        public CTDonNhapBUS()
        {
            db = new Database();
        }
        public DataTable LayDSChiTietDonNhap(int madn)
        {
            strSQL = string.Format("Select  S.Tensp, C.Soluong, C.Dongia From CT_DonNhap C, SanPham S Where C.Madn = {0} and S.Masp = C.Masp", madn);
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

        public DataTable layMa(string name)
        {
            string sql = String.Format("select masp from SanPham where tensp like '{0}'", name);
            DataTable dt = db.Execute(sql);
            return dt;
        }
        public void ThemCTDonNhap(ChiTietDonNhapDTO dn)
        {
            strSQL = string.Format("Insert Into CT_DonNhap(Madn, Masp, Soluong,Dongia) Values('{0}', '{1}', '{2}', {3})", dn.MaDN, dn.MaSP, dn.SoLuong, dn.DonGia);
            db.ExecuteNonQuery(strSQL);
            tangSoLuong(dn.MaSP, dn.SoLuong, dn.DonGia);
        }
        public void tangSoLuong(string masp, int soluong, double dongia)
        {
            string sql = String.Format("select MASP, SOLUONG from SANPHAM where MASP = {0}", Int32.Parse(masp));
            DataTable dt = db.Execute(sql);
            string soluongbandau = dt.Rows[0][1].ToString();
            int soluongsau = Int32.Parse(soluongbandau) + soluong;
            double dongiamoi = dongia * 1.15;
            sql = String.Format("update SANPHAM set SOLUONG = {0}, DONGIA = {1} where MASP = {2}", soluongsau, dongiamoi, Int32.Parse(masp));
            db.ExecuteNonQuery(sql);
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
