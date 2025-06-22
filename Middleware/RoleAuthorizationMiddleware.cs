    using Microsoft.AspNetCore.Http;
    using Microsoft.EntityFrameworkCore;
    using System.Linq;
    using System.Threading.Tasks;
    using GymManagement.Data;

    namespace GymManagement.Middleware
    {
        public class RoleAuthorizationMiddleware
        {
            private readonly RequestDelegate _next;

            public RoleAuthorizationMiddleware(RequestDelegate next) => _next = next;

            public async Task InvokeAsync(HttpContext context, ApplicationDbContext db)
            {
                var uid = context.User.Identity?.Name;

                if (!string.IsNullOrEmpty(uid))
                {
                    // Tìm người dùng từ database
                    var user = await db.Users.Include(u => u.Role)
                                            .FirstOrDefaultAsync(u => u.ID_User == uid);

                    var role = user?.Role?.tenRole?.ToLower(); // Lấy vai trò, chuyển về chữ thường
                    var path = context.Request.Path.Value?.ToLower() ?? "";

                    // Cho phép Admin (xác định qua UID) truy cập tất cả
                    if (uid == "PgaXPkz8y7NnkcTXAjwpwcvE3iX2")
                    {
                        await _next(context);
                        return;
                    }

                    // Không cho phép người khác truy cập trang tạo tài khoản (trừ Admin)
                    if (path.StartsWith("/taikhoan/taomoi") || path.StartsWith("/nguoidung/taomoi"))
                    {
                        context.Response.StatusCode = 403;
                        await context.Response.WriteAsync("403 – Chỉ Admin mới được phép tạo tài khoản mới.");
                        return;
                    }

                    // ✅ Cho phép "KhachHang" truy cập toàn bộ khu vực khách hàng, không giới hạn
                    if (role == "khachhang")
                    {
                        await _next(context);
                        return;
                    }

                    // ✅ Các vai trò khác có kiểm tra quyền
                    if (uid == "2BSbaQvFg0bMUCsgDCqWoU8LywK2")
                    {
                        var allowed = new[] { "/hoivien", "/thehoivien", "/goitap", "/lichtap", "/hoadon_thanhtoan", "/phongtap" };
                        if (!allowed.Any(p => path.StartsWith(p)))
                        {
                            context.Response.StatusCode = 403;
                            await context.Response.WriteAsync("403 – Không đủ quyền.");
                            return;
                        }
                    }

                    if (uid == "BYkt7H91SDZoRGlwYpnvj80iZiF2")
                    {
                        var allowed = new[] { "/hoadon_thanhtoan", "/hoadon_thanhly", "/baocao" };
                        if (!allowed.Any(p => path.StartsWith(p)))
                        {
                            context.Response.StatusCode = 403;
                            await context.Response.WriteAsync("403 – Không đủ quyền.");
                            return;
                        }
                    }

                    if (uid == "omOlsVyl0fMJ5gP3X8NVR2Uwak83")
                    {
                        var allowed = new[] { "/hoivien", "/thehoivien", "/lichtap", "/calamviec" };
                        if (!allowed.Any(p => path.StartsWith(p)))
                        {
                            context.Response.StatusCode = 403;
                            await context.Response.WriteAsync("403 – Không đủ quyền.");
                            return;
                        }
                    }

                    if (uid == "M5NNTAR0Vle6CkReB93CIu4NxAu2")
                    {
                        var allowed = new[] { "/thietbi", "/baocao" };
                        if (!allowed.Any(p => path.StartsWith(p)))
                        {
                            context.Response.StatusCode = 403;
                            await context.Response.WriteAsync("403 – Không đủ quyền.");
                            return;
                        }
                    }
                }

                // Cho phép tiếp tục nếu không bị chặn
                await _next(context);
            }
        }
    }
