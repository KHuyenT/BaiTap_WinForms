using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LMS_tuan4
{
    public partial class Form1 : Form
    {
        // Tên file DB (tạo nếu chưa có)
        string dbFile = "shop.db";
        string connString = "Data Source=shop.db";
        public Form1()
        {
            InitializeComponent();
        }

        private void btnTaoCSDL_Click(object sender, EventArgs e)
        {
            // Thực thi các bước: tạo table nếu chưa có, 
            // insert sample data (nếu table rỗng), rồi query
            using (var connection = new SqliteConnection(connString))
            {
                connection.Open();
                using (var transaction = connection.BeginTransaction())
                {
                    // 1) Tạo table Product nếu chưa có
                    var createCmd = connection.CreateCommand();
                    createCmd.Transaction = transaction;
                    createCmd.CommandText = @"
                        CREATE TABLE IF NOT EXISTS Product (
                            Id INTEGER PRIMARY KEY AUTOINCREMENT,
                            Name TEXT NOT NULL,
                            Price INTEGER NOT NULL,
                            Stock INTEGER NOT NULL
                        );";
                    createCmd.ExecuteNonQuery();
                    transaction.Commit();
                }
                connection.Close();
            }

            // Bạn có thể thêm 1 thông báo để biết đã chạy xong
            MessageBox.Show("Đã tạo bảng 'Product' (nếu chưa có).");
            // Dòng mới: Cập nhật label trạng thái
            lblTrangThai.Text = "Trạng thái: Đã tạo CSDL và Table";
        }

        private void btnTaoDuLieu_Click(object sender, EventArgs e)
        {
            // Thực thi các bước: tạo table nếu chưa có, 
            // insert sample data (nếu table rỗng), rồi query
            using (var connection = new SqliteConnection(connString))
            {
                connection.Open();
                using (var transaction = connection.BeginTransaction())
                {
                    // 2) Kiểm tra nếu table rỗng thì insert dữ liệu mẫu
                    var checkCmd = connection.CreateCommand();
                    checkCmd.Transaction = transaction;
                    checkCmd.CommandText = @"SELECT COUNT(1) FROM Product;";
                    long count = (long)checkCmd.ExecuteScalar();

                    if (count == 0)
                    {
                        var insertCmd = connection.CreateCommand();
                        insertCmd.Transaction = transaction;
                        insertCmd.CommandText = @"
                            INSERT INTO Product (Name, Price, Stock) VALUES (@p1, @s1, @q1);
                            INSERT INTO Product (Name, Price, Stock) VALUES (@p2, @s2, @q2);
                            INSERT INTO Product (Name, Price, Stock) VALUES (@p3, @s3, @q3);
                        ";

                        insertCmd.CommandText = @"
                            INSERT INTO Product (Name, Price, Stock) VALUES (@p0, @s0, @q0);
                            INSERT INTO Product (Name, Price, Stock) VALUES (@p1, @s1, @q1);
                            INSERT INTO Product (Name, Price, Stock) VALUES (@p2, @s2, @q2);
                            INSERT INTO Product (Name, Price, Stock) VALUES (@p3, @s3, @q3);
                        ";

                        insertCmd.Parameters.AddWithValue("@p0", "Trà Sữa Trân Châu");
                        insertCmd.Parameters.AddWithValue("@s0", 25000);
                        insertCmd.Parameters.AddWithValue("@q0", 50);

                        insertCmd.Parameters.AddWithValue("@p1", "Cà phê sữa đá");
                        insertCmd.Parameters.AddWithValue("@s1", 20000);
                        insertCmd.Parameters.AddWithValue("@q1", 60);

                        insertCmd.Parameters.AddWithValue("@p2", "Bánh mì pate");
                        insertCmd.Parameters.AddWithValue("@s2", 15000);
                        insertCmd.Parameters.AddWithValue("@q2", 120);

                       
                        insertCmd.Parameters.AddWithValue("@p3", "Ox3"); 
                        insertCmd.Parameters.AddWithValue("@s3", 120); 
                        insertCmd.Parameters.AddWithValue("@q3", 0);   
                       
                    }

                 
                    if (count == 0)
                    {
                        var insertCmd = connection.CreateCommand();
                        insertCmd.Transaction = transaction;
                        insertCmd.CommandText = @"
                            INSERT INTO Product (Name, Price, Stock) VALUES (@p1, @s1, @q1);
                            INSERT INTO Product (Name, Price, Stock) VALUES (@p2, @s2, @q2);
                            INSERT INTO Product (Name, Price, Stock) VALUES (@p3, @s3, @q3);
                        "; // Lệnh SQL trong hình thiếu sản phẩm 1, tôi bổ sung lại

                        insertCmd.CommandText = @"
                            INSERT INTO Product (Name, Price, Stock) VALUES (@p0, @s0, @q0);
                            INSERT INTO Product (Name, Price, Stock) VALUES (@p1, @s1, @q1);
                            INSERT INTO Product (Name, Price, Stock) VALUES (@p2, @s2, @q2);
                            INSERT INTO Product (Name, Price, Stock) VALUES (@p3, @s3, @q3);
                        ";

                        insertCmd.Parameters.AddWithValue("@p0", "Trà Sữa Trân Châu");
                        insertCmd.Parameters.AddWithValue("@s0", 25000);
                        insertCmd.Parameters.AddWithValue("@q0", 50);

                        insertCmd.Parameters.AddWithValue("@p1", "Cà phê sữa đá");
                        insertCmd.Parameters.AddWithValue("@s1", 20000);
                        insertCmd.Parameters.AddWithValue("@q1", 60);

                        insertCmd.Parameters.AddWithValue("@p2", "Bánh mì pate");
                        insertCmd.Parameters.AddWithValue("@s2", 15000);
                        insertCmd.Parameters.AddWithValue("@q2", 120);

                        insertCmd.Parameters.AddWithValue("@p3", "Ox3"); // Đây là sản phẩm thứ 4 trong hình
                        insertCmd.Parameters.AddWithValue("@s3", 120);   // Dòng này bị cắt, tôi tự điền
                        insertCmd.Parameters.AddWithValue("@q3", 0);     // Dòng này bị cắt, tôi tự điền

                        insertCmd.ExecuteNonQuery();

                        // Thêm thông báo
                        MessageBox.Show("Đã thêm 4 sản phẩm mẫu vào bảng 'Product'.");
                        // Dòng mới: Cập nhật label trạng thái
                        lblTrangThai.Text = "Trạng thái: Đã tạo/seed dữ liệu";
                    }
                    else
                    {
                        MessageBox.Show("Bảng 'Product' đã có dữ liệu. Không thêm gì.");
                    }

                    transaction.Commit();
                }
                connection.Close();
            }
        }

        private void btnTruyVanDuLieu_Click(object sender, EventArgs e)
        {
            using (var connection = new SqliteConnection(connString))
            {
                connection.Open();

                var selectCmd = connection.CreateCommand();
                selectCmd.CommandText = "SELECT Id, Name, Price, Stock FROM Product ORDER BY Id;";

                // Tạo một DataTable để chứa dữ liệu
                var dt = new DataTable();

                using (var reader = selectCmd.ExecuteReader())
                {

                    dt.Load(reader);
                }


                dgvData.DataSource = dt;

                if (dgvData.Columns["Price"] != null)
                {
                    dgvData.Columns["Price"].DefaultCellStyle.Format = "N0";
                    dgvData.Columns["Price"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                }
                if (dgvData.Columns["Id"] != null)
                {
                    dgvData.Columns["Id"].Width = 50;
                }


                Console.WriteLine("Danh sách sản phẩm:");
                Console.WriteLine("---------------------------------------------------------");
                Console.WriteLine("{0,-3} | {1,-25} | {2,7} | {3,5}", "Id", "Name", "Price", "Stock");
                Console.WriteLine("---------------------------------------------------------");

                // Duyệt qua từng dòng (DataRow) trong DataTable (dt)
                foreach (DataRow row in dt.Rows)
                {
                    // Lấy dữ liệu từ row và in ra
                    Console.WriteLine("{0,-3} | {1,-25} | {2,7:N0} | {3,5}",
                        row["Id"],
                        row["Name"],
                        row["Price"],
                        row["Stock"]
                    );
                }

                connection.Close();
            }

            // Cập nhật label trạng thái
            lblTrangThai.Text = "Trạng thái: Đã load dữ liệu";
        }
    }
}
