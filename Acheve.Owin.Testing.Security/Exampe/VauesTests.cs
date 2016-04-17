using System;
using System.Net.Http;
using System.Threading.Tasks;
using Acheve.Owin.Testing.Security;
using Microsoft.Owin.Testing;
using Xunit;

namespace Exampe
{
    public class VauesWithDefaultUserTests : IDisposable
    {
        private readonly TestServer _server;
        private readonly HttpClient _userHttpCient;

        public VauesWithDefaultUserTests()
        {
            _server = TestServer.Create<Startup>();
            _userHttpCient = _server.HttpClient
                .WithDefaultIdentity(Identities.User);
        }

        [Fact]
        public async Task WithHttpClientWithDefautIdentity()
        {
            var response = await _userHttpCient.GetAsync("api/values");

            response.EnsureSuccessStatusCode();
        }

        [Fact]
        public async Task WithRequestBuilder()
        {
            var response = await _server.CreateRequest("api/values")
                .WithIdentity(Identities.User)
                .GetAsync();

            response.EnsureSuccessStatusCode();
        }

        public void Dispose()
        {
            _server.Dispose();
            _userHttpCient.Dispose();
        }
    }
}
