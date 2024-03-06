using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyCuaHangDienThoai.BUS
{
    internal class CTPQ_BUS
    {
        Database db;
        public CTPQ_BUS()
        {
            db = new Database();
        }
        public DataTable layDanhSachCTPQ()
        {
            string sql = "Select * from CT_PHANQUYEN";
            return db.Execute(sql);
        }
        public DataTable laydanhsachPQ(string tenChucVu)
        {
            string sql = string.Format("SELECT CT_PHANQUYEN.MAPQ, CHUCVU.TENCHUCVU AS TENCV, PHANQUYEN.TENPQ FROM CT_PHANQUYEN JOIN CHUCVU ON CT_PHANQUYEN.MACHV = CHUCVU.MACHV JOIN PHANQUYEN ON CT_PHANQUYEN.MAPQ = PHANQUYEN.MAPQ WHERE CHUCVU.TENCHUCVU = N'{0}' AND CHUCVU.MACHV = (SELECT MACHV FROM CHUCVU WHERE TENCHUCVU = N'{0}');", tenChucVu);

            return db.Execute(sql);
        }
        public DataTable layDanhSachPhanQuyen()
        {
            string sql = "SELECT MAPQ,TENPQ FROM PHANQUYEN;";
            return db.Execute(sql);
        }
        public void themCTPQ(string tenChucVu, string mapq)
        {
            string sql = string.Format(
                "INSERT INTO CT_PHANQUYEN (MACHV, MAPQ) " +
                "SELECT CHUCVU.MACHV, '{0}' AS MAPQ " +
                "FROM CHUCVU " +
                "WHERE CHUCVU.TENCHUCVU = N'{1}'; " +

                "SELECT CT_PHANQUYEN.MAPQ, CHUCVU.TENCHUCVU AS TENCV, PHANQUYEN.TENPQ " +
                "FROM CT_PHANQUYEN " +
                "JOIN CHUCVU ON CT_PHANQUYEN.MACHV = CHUCVU.MACHV " +
                "JOIN PHANQUYEN ON CT_PHANQUYEN.MAPQ = PHANQUYEN.MAPQ " +
                "WHERE CT_PHANQUYEN.MAPQ = '{0}';", mapq, tenChucVu);

            db.ExecuteNonQuery(sql);
        }

        public void xoaCTPQ(string mapq)
        {
            string sql = string.Format(
                "DELETE FROM CT_PHANQUYEN WHERE MAPQ = '{0}';", mapq);
            db.ExecuteNonQuery(sql);
        }

    }
}
