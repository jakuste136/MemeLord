using System.Linq;
using System.Security.Claims;

namespace MemeLord.Logic.Extensions
{
    public static class ClaimsPrincipalWrapper
    {
        public static string GetFromClaim(string types)
        {
            return ClaimsPrincipal.Current.Claims.FirstOrDefault(x => x.Type == types)?.Value ?? "";
        }

        public static int GetIdFromClaim()
        {
            return int.Parse(GetFromClaim(ClaimTypes.NameIdentifier));
        }
    }
}