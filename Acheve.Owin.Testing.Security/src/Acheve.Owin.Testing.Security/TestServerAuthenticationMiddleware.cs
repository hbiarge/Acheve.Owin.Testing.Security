using Microsoft.Owin;
using Microsoft.Owin.Security.Infrastructure;

namespace Acheve.Owin.Testing.Security
{
    public class TestServerAuthenticationMiddleware : AuthenticationMiddleware<TestServerAuthenticationOptions>
    {
        public TestServerAuthenticationMiddleware(OwinMiddleware next, TestServerAuthenticationOptions options)
            : base(next, options)
        {
        }

        protected override AuthenticationHandler<TestServerAuthenticationOptions> CreateHandler()
        {
            return new TestServerAuthenticationHandler();
        }
    }
}