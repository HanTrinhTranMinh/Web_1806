using System.Security.Claims;
using System.Threading.Tasks;
using FirebaseAdmin.Auth;
using Microsoft.AspNetCore.Http;

namespace GymManagement.Middleware
{
    public class FirebaseAuthMiddleware
    {
        private readonly RequestDelegate _next;
        public FirebaseAuthMiddleware(RequestDelegate next) => _next = next;

        public async Task Invoke(HttpContext context)
        {
            if (context.Request.Headers.TryGetValue("Authorization", out var authHeader) &&
                authHeader.ToString().StartsWith("Bearer "))
            {
                var token = authHeader.ToString().Substring("Bearer ".Length);
                try
                {
                    var decoded = await FirebaseAuth.DefaultInstance.VerifyIdTokenAsync(token);
                    var uid = decoded.Uid;
                    var claims = new[] { new Claim(ClaimTypes.Name, uid) };
                    context.User = new ClaimsPrincipal(new ClaimsIdentity(claims, "Firebase"));
                }
                catch
                {
                    // Token không hợp lệ – bỏ qua đăng nhập
                }
            }

            await _next(context);
        }
    }
}
