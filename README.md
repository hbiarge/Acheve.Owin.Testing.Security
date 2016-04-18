# Acheve.Owin.Testing.Security

Unit testing your WebApi controllers is not enougth to verify the correctness of your WebApi. Are the filters working? The correct status code is sent 
when that condition is reached? Is the user authorized to request that endpoint? 


The NuGet package [Microsoft.Owin.Testing](https://www.nuget.org/packages/Microsoft.Owin.Testing/) allows you to create an in memory owin server that
exposes an HttpCient to be able to send request to the server. All in memory, all in the same process. Fast. It's the best way to 
create integration test in your WebApi.

But when your WebApi requires authenticated request it could be a little more dificult...

What if I have an easy way to indicate the claims in the request? 

This package implements an owin authentication middleware and several extension methods to easiy indicate
the claims for authenticated calls to the WebApi.

In the TestServer startup class you shoud incude the authentication middleware:

    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.UseTestServerAuthentication();

            var config = new HttpConfiguration();
            Sample.Api.WebApiConfiguration.Configure(config);
            app.UseWebApi(config);
        }
    }

And in your tests you can use an HttpClient with default credentials or build 
the request with the server RequestBuilder and with the specified claims:

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

Both methods (WithDefaultIdentity and WithIdentity) accept as the ony parameter an IEnumerabe&lt;Claim&gt; that should include the
desired user claims in the request.

You can find a complete example in the [samples](https://github.com/hbiarge/Acheve.Owin.Testing.Security/tree/master/Acheve.Owin.Testing.Security/samples) directory.