using System.Web.Http;

namespace Sample.Api.Controllers
{
    [Authorize]
    [RoutePrefix("api/values")]
    public class ValuesController : ApiController
    {
        [HttpGet]
        [Route]
        public IHttpActionResult Values()
        {
            return Ok(new[] { "Value1", "Value2" });
        }
    }
}
