using QuanLyCuaHangDienThoai.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyCuaHangDienThoai.BUS
{
    internal class DonNhapBUS
    {
        Database db;
        private string strSQL;
        public DonNhapBUS()
        {
            db = new Database();
        }
        public DataTable LayDSDonNhap()
        {
            strSQL = "Select Madn, C.Tencc, N.Tennv, Tongtien, Ngaylap From DonNhap D, NhanVien N, NhaCungCap C where D.mancc = C.mancc and D.manv = N.manv";
            DataTable dt = db.Execute(strSQL); //Goi phuong thuc truy xuat du lieu
            return dt;
        }
        public DataTable LayDSSanPham()
        {
            strSQL = "Select Masp, Tensp, Hang, Dongia, Soluong From SanPham";
            DataTable dt = db.Execute(strSQL); //Goi phuong thuc truy xuat du lieu
            return dt;
        }
        public DataTable LayDataCB(string ma, string table)
        {
            strSQL = string.Format("Select DISTINCT {0} From {1} Order by {0} ASC", ma, table);
            DataTable dt = db.Execute(strSQL); //Goi phuong thuc truy xuat du lieu
            return dt;
        }
        public DataTable timKiemSanPham(string ten)
        {
            string sql = String.Format("select MASP, TENSP, HANG, DONGIA, SOLUONG  from SanPham where TENSP like N'%{0}%'", ten);
            return db.Execute(sql);
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

        public DataTable layMa(string table, string attribute, string code, string name)
        {
            string sql = String.Format("select {0} from {1} where {2} = N'{3}'", code, table, attribute, name);
            DataTable dt = db.Execute(sql);
            return dt;
        }
        public int ThemDonNhap(DonNhapDTO dn)
        {
            strSQL = string.Format("Insert Into DonNhap(Mancc, Manv,Tongtien, Ngaylap) Values('{0}', '{1}', '{2}', '{3}')", dn.MaNCC, dn.MaNV, dn.TongTien, dn.NgayNhap.ToString());
            db.ExecuteNonQuery(strSQL);
            strSQL = string.Format("Select madn from DonNhap ORDER BY madn DESC");
            DataTable dt = db.Execute(strSQL);
            return Int32.Parse(dt.Rows[0][0].ToString());
        }

        public void CapNhatDonNhap(DonNhapDTO dn)
        {
            DataTable username = layMa("NhanVien", "tennv", "manv", dn.MaNV);
            string manv = username.Rows[0][0].ToString();
            DataTable nhacc = layMa("NhaCungCap", "tencc", "mancc", dn.MaNCC);
            string mancc = nhacc.Rows[0][0].ToString();
            //Chuẩn bị câu lẹnh truy vấn
            strSQL = string.Format("Update DonNhap set Mancc = {0}, Manv = {1}  where Madn = {2}", mancc, manv, dn.MaDN);
            db.ExecuteNonQuery(strSQL);
        }
        string ma, giatri;
        public DataTable TimDonNhap(string lable, string value)
        {
            //string ma;
            switch (lable)
            {
                case "Nhà cung cấp":
                    {
                        DataTable nhacc = layMa("NhaCungCap", "tencc", "mancc", value);
                        ma = "mancc";
                        giatri = nhacc.Rows[0][0].ToString();
                        break;
                    }
                case "Nhân viên":
                    {
                        DataTable username = layMa("NhanVien", "tennv", "manv", value);
                        ma = "manv";
                        giatri = username.Rows[0][0].ToString();
                        break;
                    }
            }
            strSQL = string.Format("Select Madn, C.Tencc, N.Tennv, Tongtien, Ngaylap From DonNhap D, NhanVien N, NhaCungCap C Where D.mancc = C.mancc and D.manv = N.manv and D.{0} = N'{1}'", ma, giatri);
            DataTable dt = db.Execute(strSQL); //Goi phuong thuc truy xuat du lieu
            return dt;
        }

        public DataTable layNCC()
        {
            strSQL = "select MANCC, TENCC from NhaCungCap";
            return db.Execute(strSQL);
        }
    }
}
