using System.Security.Claims;

namespace Lena_AspNetCoreMVC.Authentication.Extensions
{
    public static class UserExtensions
    {
        public static int? GetId(this ClaimsPrincipal user)
        {
            int? userId = null;

            var claim = user.FindFirst(ClaimTypes.NameIdentifier);

            if (claim != null && int.TryParse(claim.Value, out int id)) userId = id;

            return userId;
        }

        public static string? GetUserName(this ClaimsPrincipal user)
        {
            return user.FindFirst(ClaimTypes.Name)?.Value;
        }

        public static IEnumerable<string> GetRoles(this ClaimsPrincipal user)
        {
            return user.FindAll(ClaimTypes.Role).Select(claim => claim.Value);
        }

        public static string? GetMainRole(this ClaimsPrincipal user)
        {
            return user.FindFirst(ClaimTypes.Role)?.Value;
        }

        public static string? GetEmail(this ClaimsPrincipal user)
        {
            return user.FindFirst(ClaimTypes.Email)?.Value;
        }
    }
}
