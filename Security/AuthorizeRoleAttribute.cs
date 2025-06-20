using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace GymManagement.Security
{
    [AttributeUsage(AttributeTargets.Method | AttributeTargets.Class)]
    public class AuthorizeRoleAttribute : Attribute, IAuthorizationFilter
    {
        private readonly string[] _roles;

        public AuthorizeRoleAttribute(params string[] roles)
        {
            _roles = roles;
        }

        public void OnAuthorization(AuthorizationFilterContext context)
        {
            var dbContext = context.HttpContext.RequestServices.GetService(typeof(Data.ApplicationDbContext)) as Data.ApplicationDbContext;
            var userId = context.HttpContext.User.Identity?.Name;

            if (string.IsNullOrEmpty(userId))
            {
                context.Result = new ForbidResult();
                return;
            }

            var user = dbContext?.Users.Include(u => u.Role).FirstOrDefault(u => u.ID_User == userId);
            if (user == null || !_roles.Contains(user.Role?.tenRole))
            {
                context.Result = new ForbidResult();
            }
        }
    }
}
