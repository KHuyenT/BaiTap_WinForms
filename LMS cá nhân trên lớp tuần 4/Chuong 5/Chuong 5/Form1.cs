using Microsoft.Data.Sqlite;
using System.Data;
using System.Windows.Forms;

namespace Chuong_5
{
    public partial class Form1 : Form
    {
        string dbFile = "shop.db";
        string connString = "Data Source=shop.db";
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (var connection = new
            SqliteConnection(connString))
            {
                connection.Open();
                using (var transaction =
                connection.BeginTransaction())
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
                            );
                            ";
                    createCmd.ExecuteNonQuery();
                    transaction.Commit();
                }
                connection.Close();
            }
            lblTrangThai.Text = "Trạng thái: Đã tạo CSDL và Table";
        }

        private void btnTaoDuLieu_Click(object sender, EventArgs e)
        {
            using (var connection = new SqliteConnection(connString))
            {
                connection.Open();
                using (var transaction = connection.BeginTransaction())
                {
                    // 2) Kiểm tra nếu table rỗng thì insert dữ liệu mẫu
                    var countCmd = connection.CreateCommand();
                    countCmd.Transaction = transaction;
                    countCmd.CommandText = @"SELECT COUNT(1) FROM Product;";
                    long count = (long)countCmd.ExecuteScalar();
                    if (count == 0)
                    {
                        var insertCmd = connection.CreateCommand();
                        insertCmd.Transaction = transaction;
                        insertCmd.CommandText = @"
                            INSERT INTO Product (Name, Price, Stock) VALUES (@n1, @p1, @s1);
                            INSERT INTO Product (Name, Price, Stock) VALUES (@n2, @p2, @s2);
                            INSERT INTO Product (Name, Price, Stock) VALUES (@n3, @p3, @s3);
                            ";
                        insertCmd.Parameters.AddWithValue("@n1", "Trà Sữa Trân Châu");
                        insertCmd.Parameters.AddWithValue("@p1", 25000);
                        insertCmd.Parameters.AddWithValue("@s1", 50);
                        insertCmd.Parameters.AddWithValue("@n2", "Cà phê sữa đá");
                        insertCmd.Parameters.AddWithValue("@p2", 20000);
                        insertCmd.Parameters.AddWithValue("@s2", 80);
                        insertCmd.Parameters.AddWithValue("@n3", "Bánh mì pate");
                        insertCmd.Parameters.AddWithValue("@p3", 15000);
                        insertCmd.Parameters.AddWithValue("@s3", 120);
                        insertCmd.ExecuteNonQuery();
                    }
                    else
                    {
                        // --- THÊM DÒNG NÀY ĐỂ THÔNG BÁO ---
                        lblTrangThai.Text = "Trạng thái: Dữ liệu đã có sẵn.";
                    }
                    transaction.Commit();
                    transaction.Commit();
                }
                connection.Close();
            }
            lblTrangThai.Text = "Trạng thái: Đã tạo/seed dữ liệu";
        }

        private void btnTruyVanDuLieu_Click(object sender, EventArgs e)
        {

            // Thực thi các bước: tạo table nếu chưa có, insert sample data (nếu table rỗng), rồi query
            using (var connection = new SqliteConnection(connString))
            {
                connection.Open();
                // 3) Query và hiển thị
                using (var queryCmd = connection.CreateCommand())
                {
                    queryCmd.CommandText = @"SELECT Id, Name, Price, Stock FROM Product ORDER BY Id;";

                    //using (var reader = queryCmd.ExecuteReader())
                    //{
                    //    Console.WriteLine("Danh sách sản phẩm:");
                    //    Console.WriteLine("-------------------------------------------");
                    //    Console.WriteLine("{0,-3} | {1,-25} | {2,7} | {3,5}", "Id", "Name", "Price",

                    //    "Stock");

                    //    Console.WriteLine("-------------------------------------------");
                    //    while (reader.Read())
                    //    {
                    //        int id = reader.GetInt32(0);
                    //        string name = reader.GetString(1);
                    //        int price = reader.GetInt32(2);
                    //        int stock = reader.GetInt32(3);
                    //        Console.WriteLine("{0,-3} | {1,-25} | {2,7:N0} | {3,5}", id, name, price,

                    //        stock);

                    //    }
                    //}
                    using (var reader = queryCmd.ExecuteReader())
                    {
                        // DataTable có thể load trực tiếp từ reader
                        var dt = new DataTable();
                        dt.Load(reader);
                        // Tùy chọn format cột
                        dgvData.DataSource = dt;
                        // Format hiển thị: Price với dấu phân cách hàng nghìn
                        if (dgvData.Columns["Price"] != null)
                        {
                            dgvData.Columns["Price"].DefaultCellStyle.Format = "N0";
                            dgvData.Columns["Price"].DefaultCellStyle.Alignment =
                            DataGridViewContentAlignment.MiddleRight;
                        }
                        if (dgvData.Columns["Id"] != null)
                        {
                            dgvData.Columns["Id"].Width = 50;
                        }
                    }
                }
                connection.Close();
            }
            lblTrangThai.Text = "Trạng thái: Đã load dữ liệu";
        }
    }
}