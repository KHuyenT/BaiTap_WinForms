using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMS_Desktopbuoi4.DAL
{
    internal class DatabaseHelper
    {
        string strConnect = @"Data Source=HUYENKHANH;Initial Catalog=QLBH;Integrated Security=True";
        public SqlConnection KetNoi()
        {
            return new SqlConnection(strConnect);
        }

        // Hàm lấy dữ liệu (SELECT)
        public DataTable GetDataTable(string sql)
        {
            using (SqlConnection conn = KetNoi())
            {
                conn.Open();
                SqlDataAdapter da = new SqlDataAdapter(sql, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }

        // Hàm thực hiện lệnh (INSERT, UPDATE, DELETE)
        public void ExecuteNonQuery(string sql)
        {
            using (SqlConnection conn = KetNoi())
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.ExecuteNonQuery();
            }
        }
    }
}
