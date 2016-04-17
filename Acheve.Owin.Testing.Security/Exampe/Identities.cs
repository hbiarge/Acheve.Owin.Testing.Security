using System.Collections.Generic;
using System.Security.Claims;

namespace Exampe
{
    public static class Identities
    {
        public static IEnumerable<Claim> User = new[]
        {
            new Claim(ClaimTypes.NameIdentifier, "1"),
            new Claim(ClaimTypes.Name, "User"),
        };
    }
}
