using System.Web.Http;

namespace Sample.Api.Controllers
{
    [RoutePrefix("values")]
    public class ValuesController : ApiController
    {
        [Authorize]
        [HttpGet]
        [Route]
        public IHttpActionResult Values()
        {
            return Ok(new[] { "Value1", "Value2" });
        }

        [HttpGet]
        [Route("public")]
        public IHttpActionResult PublicValues()
        {
            return Ok(new[] { "Value1", "Value2" });
        }
    }
}
