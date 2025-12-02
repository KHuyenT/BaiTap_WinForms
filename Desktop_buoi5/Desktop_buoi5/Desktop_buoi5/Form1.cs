using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Http;
using Newtonsoft.Json;

namespace Desktop_buoi5
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void cboCity_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboCity.SelectedItem.ToString() == "Khác")
            {
                // Hiện các ô nhập liệu
                txtLat.Visible = true;
                txtLon.Visible = true;
                // (Bạn có thể thêm cả 2 Label "Kinh độ", "Vĩ độ" vào đây)
            }
            else
            {
                // Ẩn các ô nhập liệu
                txtLat.Visible = false;
                txtLon.Visible = false;
            }
        }

        private async void btnRefresh_Click(object sender, EventArgs e)
        {
            // 1. Chuẩn bị gọi API
            string apiKey = "66272feb4471b9fefc07c7fd53fc5679"; 
            string lat = "";
            string lon = "";

            string selectedCity = cboCity.SelectedItem.ToString();

            // 2. Lấy kinh độ, vĩ độ
            if (selectedCity == "TP. HCM")
            {
                lat = "10.762622";
                lon = "106.660172";
            }
            else if (selectedCity == "Hà Nội")
            {
                lat = "21.027763";
                lon = "105.834160";
            }
            else if (selectedCity == "Đà Nẵng")
            {
                lat = "16.054456";
                lon = "108.202164";
            }
            else if (selectedCity == "Khác")
            {
                lat = txtLat.Text;
                lon = txtLon.Text;
                // (Bạn nên thêm kiểm tra xem người dùng đã nhập số hợp lệ chưa)
            }

            if (string.IsNullOrEmpty(lat) || string.IsNullOrEmpty(lon))
            {
                MessageBox.Show("Vui lòng chọn thành phố hoặc nhập kinh độ/vĩ độ.");
                return;
            }

            // Bắt đầu hiệu ứng fade-out (chuẩn bị cho fade-in)
            this.Opacity = 0.0;

            // 3. Gọi API
            try
            {
                // Dùng HttpClient để gọi API
                HttpClient client = new HttpClient();
                string url = $"https://api.openweathermap.org/data/2.5/weather?lat={lat}&lon={lon}&appid={apiKey}&units=metric&lang=vi";

                HttpResponseMessage response = await client.GetAsync(url);
                response.EnsureSuccessStatusCode(); // Đảm bảo gọi thành công

                string json = await response.Content.ReadAsStringAsync();

                // 4. Dùng Newtonsoft.Json để chuyển JSON thành object C#
                var weatherData = JsonConvert.DeserializeObject<RootObject>(json);

                // 5. Cập nhật giao diện
                UpdateUI(weatherData);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi lấy dữ liệu: " + ex.Message);
                // Nếu lỗi cũng phải cho form hiện lại
                this.Opacity = 1.0;
            }
        }
        // 6. Hàm cập nhật giao diện
        private void UpdateUI(RootObject data)
        {
            if (data == null) return;

            // Lấy thông tin
            double temp = data.main.temp;
            double windSpeed = data.wind.speed;
            string weatherMain = data.weather[0].main; // "Rain", "Clear", "Clouds"...

            // Cập nhật Label
            lblTemp.Text = $"Nhiệt độ: {temp}°C";
            lblWind.Text = $"Gió: {windSpeed} m/s";
            lblUpdated.Text = $"Cập nhật lúc: {DateTime.Now:HH:mm:ss}";

            // Mặc định reset màu và icon
            lblTemp.ForeColor = Color.Black;
            picWeatherIcon.Image = null;

            // Logic điều kiện
            if (temp > 27)
            {
                lblTemp.ForeColor = Color.Red;
                picWeatherIcon.Image = Properties.Resources.sun; // Lấy icon từ Resources
            }

            if (weatherMain.Contains("Rain"))
            {
                picWeatherIcon.Image = Properties.Resources.rain;
            }

            // Giả sử gió mạnh là > 10 m/s
            if (windSpeed > 10)
            {
                picWeatherIcon.Image = Properties.Resources.wind;
            }

            // Bắt đầu chạy Timer để làm hiệu ứng Fade In
            fadeTimer.Start();
        }

        private void fadeTimer_Tick(object sender, EventArgs e)
        {
            if (this.Opacity < 1.0)
            {
                this.Opacity += 0.05; // Tăng dần độ trong suốt
            }
            else
            {
                this.Opacity = 1.0; // Đảm bảo là 1
                fadeTimer.Stop(); // Dừng timer khi đã hoàn thành
            }
        }
    }
    // Các class này khớp với cấu trúc JSON của OpenWeatherMap
    public class Weather
    {
        public string main { get; set; } // Ví dụ: "Rain", "Clouds", "Clear"
        public string description { get; set; }
    }

    public class Main
    {
        public double temp { get; set; } // Nhiệt độ
    }

    public class Wind
    {
        public double speed { get; set; } // Tốc độ gió (m/s)
    }

    public class RootObject
    {
        public List<Weather> weather { get; set; }
        public Main main { get; set; }
        public Wind wind { get; set; }
    }
}
