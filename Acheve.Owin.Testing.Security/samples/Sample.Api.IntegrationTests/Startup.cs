using System;
using System.Security.Claims;
using System.Web.Http;
using Acheve.Owin.Testing.Security;
using Owin;

namespace Sample.Api.IntegrationTests
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.UseTestServerAuthentication(options =>
            {
                options.CommonClaims = new[]
                {
                    new Claim(ClaimTypes.DateOfBirth,
                        new DateTimeOffset(1971, 12, 20, 2, 0, 0, 0, TimeSpan.FromHours(1)).ToString()),
                };
            });

            var config = new HttpConfiguration();
            Sample.Api.WebApiConfiguration.Configure(config);
            app.UseWebApi(config);
        }
    }
}