namespace TravelHub.Core.Extensions
{
    using System.Security.Claims;

    public static class UserExtension
    {
        public static string GetId(this ClaimsPrincipal user)
        {
            return user.FindFirstValue(ClaimTypes.NameIdentifier);
        }
    }
}