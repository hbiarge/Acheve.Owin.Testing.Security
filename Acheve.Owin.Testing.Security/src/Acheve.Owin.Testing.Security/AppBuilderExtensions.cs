using System;
using Microsoft.Owin.Extensions;
using Owin;

namespace Acheve.Owin.Testing.Security
{
    public static class AppBuilderExtensions
    {
        public static void UseTestServerAuthentication(this IAppBuilder app)
        {
            var options = new TestServerAuthenticationOptions();
            app.Use<TestServerAuthenticationMiddleware>(options);
            app.UseStageMarker(PipelineStage.Authenticate);
        }

        public static void UseTestServerAuthentication(this IAppBuilder app, Action<TestServerAuthenticationOptions> configuration)
        {
            var options = new TestServerAuthenticationOptions();
            configuration(options);
            app.Use<TestServerAuthenticationMiddleware>(options);
            app.UseStageMarker(PipelineStage.Authenticate);
        }
    }
}