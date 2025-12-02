using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.AspNetCore.SignalR.Client;

namespace WeatherApp.AdminClient
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        static async Task Main(string[] args)
        {
            // 1. Cấu hình kết nối đến Hub (dùng địa chỉ từ Bước 1)
            var connection = new HubConnectionBuilder()
                .WithUrl("http://localhost:5123/weatherHub") // <-- THAY ĐỔI ĐỊA CHỈ NÀY
                .Build();

            // 2. Bắt đầu kết nối
            try
            {
                await connection.StartAsync();
                Console.WriteLine("Admin connected to Hub.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Connection failed: {ex.Message}");
                return;
            }

            // 3. Giả lập call API mỗi 5 giây
            var timer = new System.Timers.Timer(5000); // 5 giây
            var random = new Random();

            timer.Elapsed += async (sender, e) =>
            {
                int newTemp = random.Next(10, 45); // Giả lập nhiệt độ mới

                // 4. Gọi hàm "SendTemperatureUpdate" trên Hub
                try
                {
                    await connection.InvokeAsync("SendTemperatureUpdate", "Hà Nội", newTemp);
                    Console.WriteLine($"Đã gửi: Hà Nội {newTemp}°C");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Gửi thất bại: {ex.Message}");
                }
            };

            timer.Start();
            Console.WriteLine("Admin đang chạy. Nhấn phím bất kỳ để thoát...");
            Console.ReadKey();
        }
    }
}
