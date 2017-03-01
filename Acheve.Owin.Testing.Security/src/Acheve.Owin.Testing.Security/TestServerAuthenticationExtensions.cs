using System.Collections.Generic;
using System.Net.Http.Headers;
using System.Security.Claims;
using Acheve.Owin.Testing.Security;

namespace System.Net.Http
{
    public static class TestServerAuthenticationExtensions
    {
        public static HttpClient WithDefaultIdentity(this HttpClient httpClient, IEnumerable<Claim> claims)
        {
            httpClient.DefaultRequestHeaders.Authorization =
                new AuthenticationHeaderValue(
                    TestServerAuthenticationDefaults.AuthenticationType,
                    DefautClaimsEncoder.Encode(claims));

            return httpClient;
        }
    }
}