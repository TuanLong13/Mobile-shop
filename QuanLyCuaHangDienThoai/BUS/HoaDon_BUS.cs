using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Media;

namespace QuanLyCuaHangDienThoai.BUS
{
    internal class HoaDon_BUS
    {
        Database db;
        public HoaDon_BUS()
        {
            db = new Database();
        }
        public DataTable layDanhSachSanPham()
        {
            string sql = "select MASP, TENSP, HANG, DONGIA, SOLUONG  from SanPham";
            return db.Execute(sql);
        }
        public DataTable layDanhSachKhachHang()
        {
            string sql = "select MAKH, TENKH from KhachHang";
            return db.Execute(sql);
        }
        public DataTable timKiemSanPham(string ten)
        {
            string sql = String.Format("select MASP, TENSP, HANG, DONGIA, SOLUONG  from SanPham where TENSP like N'%{0}%'", ten);
            return db.Execute(sql);
        }
        public DataTable timKhachHang(string sdt)
        {
            string sql = String.Format("select TENKH from KhachHang where SDT = '{0}'", sdt);
            return db.Execute(sql);
        }
        public string timMaKhachHang(string ten, string sdt)
        {;
            string sql = String.Format("select * from KhachHang where TENKH = N'{0}' and SDT = '{1}'", ten, sdt);
            DataTable dt = db.Execute(sql);
            return dt.Rows[0][0].ToString();
        }
        public string timMaNhanVien(string username)
        {
            string sql = String.Format("select MANV, USERNAME from TAIKHOAN where USERNAME = N'{0}'", username);
            DataTable dt = db.Execute(sql);
            return dt.Rows[0][0].ToString();
        }
        public string thanhToan(string tenKH, string sdt, string username, DateTime ngaylap, string diachi, double tongtien, int trangthai)
        {
            string makh = timMaKhachHang(tenKH, sdt);
            string manv = timMaNhanVien(username);
            string sql = String.Format("insert into HOADON(MAKH, MANV, NGAYLAP, DIACHIGIAO, TONGTIEN, TRANGTHAI) values ({0}, {1}, '{2}', N'{3}', {4}, {5})", Int32.Parse(makh), Int32.Parse(manv), ngaylap.ToString(), diachi, tongtien, trangthai);
            db.ExecuteNonQuery(sql);
            sql = String.Format("select * from HOADON where MAKH = {0} and MANV = {1} and NGAYLAP = '{2}' and DIACHIGIAO = N'{3}' and TONGTIEN = {4} and TRANGTHAI = {5}", Int32.Parse(makh), Int32.Parse(manv), ngaylap.ToString(), diachi, tongtien, trangthai);
            DataTable dt = db.Execute(sql);
            return dt.Rows[0][0].ToString();
        }
        public void themCTHoaDon(string mahd, string masp, string dongia, string soluong)
        {
            string sql = String.Format("insert into CT_HOADON values({0}, {1}, {2}, {3})", Int32.Parse(mahd), Int32.Parse(masp), double.Parse(dongia), Int32.Parse(soluong));
            db.ExecuteNonQuery(sql);
            giamSoLuong(masp, soluong);
        }
        public void giamSoLuong(string masp, string soluong)
        {
            string sql = String.Format("select MASP, SOLUONG from SANPHAM where MASP = {0}", Int32.Parse(masp));
            DataTable dt = db.Execute(sql);
            string soluongbandau = dt.Rows[0][1].ToString();
            int soluongsau = Int32.Parse(soluongbandau) - Int32.Parse(soluong);
            sql = String.Format("update SANPHAM set SOLUONG = {0} where MASP = {1}", soluongsau, Int32.Parse(masp));
            db.ExecuteNonQuery(sql);
        }    
        public DataTable layDanhSachMoTa()
        {
            string sql = "select MAKM, MOTA from KhuyenMai";
            return db.Execute(sql);
        }
        public DataTable layDanhSachChiTietKM(string ma)
        {
            string sql = String.Format("select C.MASP, S.TENSP, C.PHANTRAM, K.NGAYBD, K.NGAYKT, C.MAKM, C.MASP from KhuyenMai K, CT_KhuyenMai C, SanPham S where C.MAKM = K.MAKM and C.MASP = S.MASP and C.MAKM = {0}", Int32.Parse(ma));
            return db.Execute(sql);
        }
        public DataTable layDanhSachHoaDon(bool sort)
        {
            string sql;
            if (sort)
            {
                sql = "select H.MAHD, K.TENKH, N.TENNV, H.NGAYLAP, H.DIACHIGIAO, H.TONGTIEN, H.TRANGTHAI, H.MAKH, H.MANV from HoaDon H, KhachHang K, NhanVien N where H.MANV = N.MANV and H.MAKH = K.MAKH order by TRANGTHAI";
            }
            else
            {
                sql = "select H.MAHD, K.TENKH, N.TENNV, H.NGAYLAP, H.DIACHIGIAO, H.TONGTIEN, H.TRANGTHAI, H.MAKH, H.MANV from HoaDon H, KhachHang K, NhanVien N where H.MANV = N.MANV and H.MAKH = K.MAKH";
            }
            return db.Execute(sql);
        }
        public DataTable timHoaDon(string ten, bool sort)
        {
            string sql;
            if (sort)
            {
                sql = String.Format("select H.MAHD, K.TENKH, N.TENNV, H.NGAYLAP, H.DIACHIGIAO, H.TONGTIEN, H.TRANGTHAI, H.MAKH, H.MANV from HoaDon H, KhachHang K, NhanVien N where H.MANV = N.MANV and H.MAKH = K.MAKH and TENKH like N'%{0}%' order by TRANGTHAI", ten);
            }
            else
            {
                sql = String.Format("select H.MAHD, K.TENKH, N.TENNV, H.NGAYLAP, H.DIACHIGIAO, H.TONGTIEN, H.TRANGTHAI, H.MAKH, H.MANV from HoaDon H, KhachHang K, NhanVien N where H.MANV = N.MANV and H.MAKH = K.MAKH and TENKH like N'%{0}%'", ten);
            }    
            return db.Execute(sql);
        }
        public void suaHoaDon(string ma, int trangthai)
        {
            string sql = String.Format("update HOADON set TRANGTHAI = {0} where MAHD = {1}", trangthai, Int32.Parse(ma));
            db.ExecuteNonQuery(sql);
        }
    }
}
