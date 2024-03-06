using System;
using QuanLyCuaHangDienThoai.BUS;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace QuanLyCuaHangDienThoai.BUS
{
    internal class NhanVien_BUS
    {
        Database db;
        public NhanVien_BUS()
        {
            db = new Database();
        }
        public DataTable layDanhSachTenNhanVien()
        {
            string sql = "Select TENNV from NHANVIEN";
            return db.Execute(sql);
        }
        public DataTable layDanhSachNhanVien()
        {
            string sql = "SELECT NHANVIEN.MANV, NHANVIEN.TENNV, NHANVIEN.SDT, NHANVIEN.EMAIL, NHANVIEN.DIACHI, CHUCVU.TENCHUCVU AS TENCHUCVU FROM NHANVIEN JOIN CHUCVU ON NHANVIEN.MACHV = CHUCVU.MACHV;";
            return db.Execute(sql);
        }
        public DataTable layDanhSachChucVu()
        {
            string sql = "Select TENCHUCVU from CHUCVU";
            return db.Execute(sql);
        }
        public DataRow layThongTinNhanVien(string tenNV)
        {
            string sql = $"SELECT * FROM NHANVIEN WHERE TENNV = N'{tenNV}'";

            DataTable dt = db.Execute(sql);

            if (dt.Rows.Count > 0)
            {
                return dt.Rows[0];
            }

            return null;
        }

        public void updateNhanVien(string tenNV, string sdt, string email, string diaChi, string chucVu)
        {
            string sql = string.Format(@"
                                        UPDATE NHANVIEN 
                                        SET SDT = '{0}', EMAIL = '{1}', DIACHI = N'{2}', MACHV = (SELECT MACHV FROM CHUCVU WHERE TENCHUCVU = N'{3}')
                                        WHERE TENNV = N'{4}';
                                        ", sdt, email, diaChi, chucVu, tenNV);

            db.ExecuteNonQuery(sql);
        }


        public void themNhanVien(string tenNV, string sdt, string email, string diaChi, string chucVu)
        {
            string sql = string.Format(@"
                            INSERT INTO NHANVIEN (TENNV, SDT, EMAIL, DIACHI, MACHV)
                            SELECT N'{0}', '{1}', '{2}', N'{3}', CHUCVU.MACHV
                            FROM CHUCVU
                            WHERE CHUCVU.TENCHUCVU = N'{4}';
                            ", tenNV, sdt, email, diaChi, chucVu);

            db.ExecuteNonQuery(sql);
        }

        public void xoaNhanVien(string ma)
        {
            string sql = String.Format("delete from NHANVIEN where MANV = {0}", Int32.Parse(ma));
            db.ExecuteNonQuery(sql);
        }
        public DataTable timKiemNhanVien(string name)
        {
            string sql = String.Format("select * from NHANVIEN where TENNV like N'%{0}%'", name);
            return db.Execute(sql);
        }
    }
}
