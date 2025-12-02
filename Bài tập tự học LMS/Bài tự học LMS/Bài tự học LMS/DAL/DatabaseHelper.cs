using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SQLite;
using System.IO;

namespace Bài_tự_học_LMS.DAL
{
    internal class DatabaseHelper
    {
        private string connectionString = "Data Source=LMS_BaiTap.db;Version=3;";

        public DatabaseHelper()
        {
            KhoiTaoCSDL();
        }

        // Hàm này tự động tạo file DB và Bảng nếu chưa có
        private void KhoiTaoCSDL()
        {
            if (!File.Exists("LMS_BaiTap.db"))
            {
                SQLiteConnection.CreateFile("LMS_BaiTap.db");
                using (SQLiteConnection conn = new SQLiteConnection(connectionString))
                {
                    conn.Open();
                    string sql = @"
                        CREATE TABLE BaiTap (
                            MaBai INTEGER PRIMARY KEY AUTOINCREMENT, 
                            TenBai TEXT, 
                            MonHoc TEXT, 
                            LinkCode TEXT, 
                            TrangThai TEXT, 
                            Diem REAL
                        );
                        -- Thêm mẫu 1 dòng dữ liệu
                        INSERT INTO BaiTap (TenBai, MonHoc, LinkCode, TrangThai, Diem) 
                        VALUES ('LMS cá nhân về nhà - Tuần 1', 'Phát triển ứng dụng Desktop', 'C:\Users\FPT\source\repos\BTVN QLUDDT\Desktop_buoi1', 'Hoàn thành', 8);
                    ";
                    SQLiteCommand cmd = new SQLiteCommand(sql, conn);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public DataTable ExecuteQuery(string query)
        {
            using (SQLiteConnection conn = new SQLiteConnection(connectionString))
            {
                conn.Open();
                SQLiteCommand cmd = new SQLiteCommand(query, conn);
                SQLiteDataAdapter adapter = new SQLiteDataAdapter(cmd);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                return dt;
            }
        }

        public int ExecuteNonQuery(string query)
        {
            using (SQLiteConnection conn = new SQLiteConnection(connectionString))
            {
                conn.Open();
                SQLiteCommand cmd = new SQLiteCommand(query, conn);
                return cmd.ExecuteNonQuery();
            }
        }
    }
}
