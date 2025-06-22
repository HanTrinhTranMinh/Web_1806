using System.Security.Claims;
using System.Threading.Tasks;
using FirebaseAdmin.Auth;
using Microsoft.AspNetCore.Http;
using System;

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
                    var email = decoded.Claims.ContainsKey("email") ? decoded.Claims["email"].ToString() : "";
                    var role = decoded.Claims.ContainsKey("role") ? decoded.Claims["role"].ToString() : "";

                    var claims = new List<Claim>
                    {
                        new Claim(ClaimTypes.Name, uid),
                        new Claim(ClaimTypes.Email, email),
                        new Claim(ClaimTypes.Role, role)
                    };

                    var identity = new ClaimsIdentity(claims, "Firebase");
                    context.User = new ClaimsPrincipal(identity);
                }
                catch (Exception ex)
                {
                    context.Response.StatusCode = 401;
                    await context.Response.WriteAsync("401 – Token không hợp lệ hoặc hết hạn.");
                    return;
                }
            }

            await _next(context);
        }
    }
}
