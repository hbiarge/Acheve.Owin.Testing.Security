using System.Collections.Generic;
using System.Security.Claims;
using Microsoft.Owin.Security;

namespace Acheve.Owin.Testing.Security
{
    public class TestServerAuthenticationOptions : AuthenticationOptions
    {
        public TestServerAuthenticationOptions()
            : base(TestServerAuthenticationDefaults.AuthenticationType)
        {
            CommonClaims = new Claim[0];
        }

        public IEnumerable<Claim> CommonClaims { get; set; }

        public string NameClaimType { get; set; } = ClaimTypes.Name;

        public string RoleClaimType { get; set; } = ClaimTypes.Role;
    }
}