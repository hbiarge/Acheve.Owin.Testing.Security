using System.Linq;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.Infrastructure;

namespace Acheve.Owin.Testing.Security
{
    public class TestServerAuthenticationHandler
        : AuthenticationHandler<TestServerAuthenticationOptions>
    {
        protected override Task<AuthenticationTicket> AuthenticateCoreAsync()
        {
            string[] authHeaderString;
            var existAuthorizationHeader =
                Context.Request.Headers.TryGetValue(Constants.AuthenticationHeaderName, out authHeaderString);

            if (existAuthorizationHeader == false)
            {
                return Task.FromResult(AnonymousTicket());
            }

            AuthenticationHeaderValue authHeader;
            var canParse = AuthenticationHeaderValue.TryParse(authHeaderString[0], out authHeader);

            if (canParse == false || authHeader.Scheme != TestServerAuthenticationDefaults.AuthenticationType)
            {
                return Task.FromResult(AnonymousTicket());
            }

            var headerClaims = DefautClaimsEncoder.Decode(authHeader.Parameter);
            var identity = new ClaimsIdentity(
                claims: Options.CommonClaims.Union(headerClaims),
                authenticationType: Options.AuthenticationType,
                nameType: Options.NameClaimType,
                roleType: Options.RoleClaimType);

            var ticket = new AuthenticationTicket(identity, new AuthenticationProperties());
            return Task.FromResult(ticket);
        }

        private AuthenticationTicket AnonymousTicket()
        {
            // Note: Default Anonymous User is new ClaimsPrincipal(new ClaimsIdentity())
            return new AuthenticationTicket(new ClaimsIdentity(), new AuthenticationProperties());
        }
    }
}