using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using GymManagement.Data;

namespace GymManagement.Middleware
{
    public class RoleAuthorizationMiddleware
    {
        private readonly RequestDelegate _next; //
        public RoleAuthorizationMiddleware(RequestDelegate next) => _next = next;

        public async Task InvokeAsync(HttpContext context, ApplicationDbContext db)
        {
            var uid = context.User.Identity?.Name; // Kiểm tra người dùng đã đăng nhập hay chưa
            if (!string.IsNullOrEmpty(uid)) // Nếu đã đăng nhập
            {
                var user = await db.Users.Include(u => u.Role) // Lấy thông tin người dùng và vai trò của họ
                                         .FirstOrDefaultAsync(u => u.ID_User == uid); // Tìm người dùng theo ID

                var role = user?.Role?.tenRole; // Lấy tên vai trò của người dùng
                var path = context.Request.Path.Value?.ToLower() ?? ""; // Lấy đường dẫn yêu cầu và chuyển đổi thành chữ thường

                if (role == "quanly" || role == "admin") // Kiểm tra nếu người dùng là quản lý hoặc admin
                {
                    await _next(context); // Nếu là Admin, cho phép truy cập tất cả
                    return;
                }

                if (role == "NhanVien")
                {
                    var allowed = new[] { "/hoivien", "/thehoivien", "/goitap", "/lichtap", "hoadon_thanhtoan","/phongtap" };
                    if (!allowed.Any(p => path.StartsWith(p)))
                    {
                        context.Response.StatusCode = 403;
                        await context.Response.WriteAsync("403 – Không đủ quyền");
                        return;
                    }
                }

                if (role == "ThuNgan")
                {
                    var allowed = new[] { "/hoadon_thanhtoan", "/hoadon_thanhly", "/lichsu","/baocao" };
                    if (!allowed.Any(p => path.StartsWith(p)))
                    {
                        context.Response.StatusCode = 403;
                        await context.Response.WriteAsync("403 – Không đủ quyền");
                        return;
                    }
                }

                if (role == "pt")
                {
                    var allowed = new[] { "/hoivien", "/thehoivien", "/lichtap","calamviec" };
                    if (!allowed.Any(p => path.StartsWith(p)))
                    {
                        context.Response.StatusCode = 403;
                        await context.Response.WriteAsync("403 – Không đủ quyền");
                        return;
                    }
                }

                if (role == "QuanLyThietBi")
                {
                    var allowed = new[] { "/thietbi", "/baocao" };
                    if (!allowed.Any(p => path.StartsWith(p)))
                    {
                        context.Response.StatusCode = 403;
                        await context.Response.WriteAsync("403 – Không đủ quyền");
                        return;
                    }
                }
            }

            await _next(context);
        }
    }
}
