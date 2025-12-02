using WeatherApp.server;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddSignalR();
var app = builder.Build();
app.UseRouting();
app.MapControllers();

app.MapGet("/", () => "Hello World!");
app.MapHub<WeatherHub>("/weatherHub"); // "/weatherHub" là địa chỉ để client kết nối vào
app.UseHttpsRedirection();
app.Run();
