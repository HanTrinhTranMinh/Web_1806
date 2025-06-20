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

        public async Task Invoke(HttpContext context, ApplicationDbContext db)
        {
            var uid = context.User.Identity?.Name;
            if (!string.IsNullOrEmpty(uid))
            {
                var user = await db.Users.Include(u => u.Role)
                                         .FirstOrDefaultAsync(u => u.ID_User == uid);

                var role = user?.Role?.tenRole;
                var path = context.Request.Path.Value?.ToLower() ?? "";

                if (role == "Admin")
                {
                    await _next(context);
                    return;
                }

                if (role == "QuanLy")
                {
                    var allowed = new[] { "/hoivien", "/baocao", "/thehoivien", "/lichtap" };
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
