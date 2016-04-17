using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Claims;

namespace Acheve.Owin.Testing.Security
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

        public static Microsoft.Owin.Testing.RequestBuilder WithIdentity(this Microsoft.Owin.Testing.RequestBuilder requestBuilder, IEnumerable<Claim> claims)
        {
            requestBuilder.AddHeader(
                Constants.AuthenticationHeaderName,
                $"{TestServerAuthenticationDefaults.AuthenticationType} {DefautClaimsEncoder.Encode(claims)}");

            return requestBuilder;
        }
    }
}