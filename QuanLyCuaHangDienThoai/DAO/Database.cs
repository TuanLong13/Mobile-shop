using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyCuaHangDienThoai
{
    public class Database
    {
        SqlConnection sqlConn;
        SqlDataAdapter da;//Bo dieu phoi du lieu
        DataSet ds; //Doi tuong chhua CSDL khi giao tiep 
        static string strCnn = "Data Source=DESKTOP-B92HK9O\\SQLEXPRESS; Database=CuaHangDienThoai; Integrated Security = True";

        public  Database()
        {
            sqlConn =  new SqlConnection(strCnn);
        }

        public DataTable Execute(String sqlStr)
        {

            da = new SqlDataAdapter(sqlStr, sqlConn);
            ds = new DataSet();
            da.Fill(ds);
            return ds.Tables[0];
        }

        public void ExecuteNonQuery(String sqlStr)
        {
            SqlCommand sqlcmd = new SqlCommand(sqlStr, sqlConn);
            sqlConn.Open(); //Mo ket noi
            sqlcmd.ExecuteNonQuery();//Lenh hien lenh Them/Xoa/Sua
            sqlConn.Close();//Dong ket noi
        }
        public int ExecuteScalar(string strSQL)
        {
            int count = 0;
            try
            {
                using (SqlCommand sqlcmd = new SqlCommand(strSQL, sqlConn))
                {
                    sqlConn.Open(); // Mở kết nối
                    count = (int)sqlcmd.ExecuteScalar(); // Thực hiện truy vấn và lấy kết quả
                }
            }
            catch (Exception ex)
            {
                // Xử lý ngoại lệ tại đây
                Console.WriteLine("Có lỗi xảy ra: " + ex.Message);
            }
            finally
            {
                if (sqlConn.State == ConnectionState.Open)
                {
                    sqlConn.Close(); // Đóng kết nối
                }
            }
            return count;
        }

    }
}
