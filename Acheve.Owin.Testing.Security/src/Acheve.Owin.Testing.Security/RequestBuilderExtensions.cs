using System.Collections.Generic;
using System.Security.Claims;
using Acheve.Owin.Testing.Security;

namespace Microsoft.Owin.Testing
{
    public static class RequestBuilderExtensions
    {
        public static RequestBuilder WithIdentity(this RequestBuilder requestBuilder, IEnumerable<Claim> claims)
        {
            requestBuilder.AddHeader(
                Constants.AuthenticationHeaderName,
                $"{TestServerAuthenticationDefaults.AuthenticationType} {DefautClaimsEncoder.Encode(claims)}");

            return requestBuilder;
        }
    }
}