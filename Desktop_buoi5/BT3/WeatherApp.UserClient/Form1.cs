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
using System.Drawing; // Để dùng Color
using System.Media; // Để dùng âm thanh

namespace WeatherApp.UserClient
{
    public partial class Form1 : Form
    {
        private HubConnection connection;
        public Form1()
        {
            InitializeComponent();
        }
        private async void Form1_Load(object sender, EventArgs e)
        {
            // 1. Cấu hình kết nối
            connection = new HubConnectionBuilder()
                .WithUrl("http://localhost:5123/weatherHub") // <-- DÙNG CÙNG ĐỊA CHỈ
                .Build();

            // 2. Đăng ký lắng nghe sự kiện "ReceiveWarning"
            // Tên sự kiện này PHẢI KHỚP với tên trên Hub (Bước 1)
            connection.On<string, int>("ReceiveWarning", (location, temp) =>
            {
                // Cập nhật UI. Rất quan trọng!
                // Vì sự kiện này chạy trên luồng khác (background thread),
                // chúng ta phải dùng 'Invoke' để cập nhật UI một cách an toàn.
                this.Invoke((Action)(() =>
                {
                    UpdateWeatherUI(location, temp);
                }));
            });

            // 3. Bắt đầu kết nối
            try
            {
                await connection.StartAsync();
                lblTemperature.Text = "Đã kết nối. Đang chờ cảnh báo...";
            }
            catch (Exception ex)
            {
                lblTemperature.Text = $"Kết nối thất bại: {ex.Message}";
            }
        }

        // Tách riêng hàm cập nhật UI
        private void UpdateWeatherUI(string location, int temp)
        {
            // Cập nhật nội dung Label
            lblTemperature.Text = $"Nhiệt độ {location}: {temp}°C";

            // --- Bổ sung hiệu ứng (Yêu cầu của bạn) ---

            // 1. Đổi màu Label
            if (temp > 35) // Nóng
            {
                lblTemperature.ForeColor = Color.Red;
            }
            else if (temp < 15) // Lạnh
            {
                lblTemperature.ForeColor = Color.Blue;
            }
            else // Bình thường
            {
                lblTemperature.ForeColor = Color.Black;
            }

            // 2. Âm thanh "Ting"
            // Dùng âm thanh "Asterisk" (dấu sao) có sẵn của Windows
            SystemSounds.Asterisk.Play();

            // Hoặc, nếu bạn có file âm thanh "ting.wav":
            // SoundPlayer player = new SoundPlayer("đường_dẫn_đến_file_ting.wav");
            // player.Play();
        }
    }
}
