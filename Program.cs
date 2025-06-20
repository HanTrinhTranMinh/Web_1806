using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using GymManagement.Data;
using Microsoft.EntityFrameworkCore;
using FirebaseAdmin;
using Google.Apis.Auth.OAuth2;

var builder = WebApplication.CreateBuilder(args);

//Lấy đường dẫn đến file JSON chứa thông tin xác thực Firebase
var firebaseCredentialsPath = builder.Configuration["Firebase:CredentialsPath"];
//Kiểm tra nếu đường dẫn không hợp lệ
if (string.IsNullOrEmpty(firebaseCredentialsPath) || !System.IO.File.Exists(firebaseCredentialsPath))
{
    throw new InvalidOperationException("Firebase credentials file not found or path is invalid.");
}

//Khởi tạo Firebase Admin SDK với thông tin xác thực từ file JSON
FirebaseApp.Create(new AppOptions
{
    Credential = GoogleCredential.FromFile(firebaseCredentialsPath)
});
Console.WriteLine("Firebase Admin SDK đã được khởi tạo thành công!");
//Lấy chuỗi kết nối từ file appsettings.json
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

//Đăng ký ApplicationDbContext với Dependency Injection
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));
// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();



var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

// Cho Razor Pages (nếu có)
app.MapRazorPages();

// Cho Blazor Server (tùy chọn nếu bạn dùng .razor component)
app.MapBlazorHub();
app.MapFallbackToPage("/_Host");
app.Run();
