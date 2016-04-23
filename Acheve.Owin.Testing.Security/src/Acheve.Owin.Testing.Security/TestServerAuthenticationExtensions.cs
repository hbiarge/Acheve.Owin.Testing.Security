using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Claims;
using Microsoft.Owin.Testing;

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

        public static RequestBuilder WithIdentity(this RequestBuilder requestBuilder, IEnumerable<Claim> claims)
        {
            requestBuilder.AddHeader(
                Constants.AuthenticationHeaderName,
                $"{TestServerAuthenticationDefaults.AuthenticationType} {DefautClaimsEncoder.Encode(claims)}");

            return requestBuilder;
        }
    }
}