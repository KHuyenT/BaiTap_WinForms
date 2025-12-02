using Microsoft.AspNetCore.SignalR;
namespace WeatherApp.server
{
    public class WeatherHub : Hub
    {
        // App 1 (Admin) sẽ gọi hàm này
        public async Task SendTemperatureUpdate(string location, int temperature)
        {
            // Hub sẽ "phát sóng" (broadcast) thông báo này đến TẤT CẢ các client (App 2)
            // đang lắng nghe sự kiện tên là "ReceiveWarning"
            await Clients.All.SendAsync("ReceiveWarning", location, temperature);
        }
    }
}
