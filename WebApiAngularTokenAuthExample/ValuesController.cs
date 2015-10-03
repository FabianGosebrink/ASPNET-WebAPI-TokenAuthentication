using System.Linq;
using System.Security.Claims;
using System.Web.Http;

namespace WebApiAngularTokenAuthExample
{
    [Authorize(Roles = "user")]
    public class ValuesController : ApiController
    {
        // GET api/<controller>
        public IHttpActionResult Get()
        {
            ClaimsIdentity claimsIdentity = User.Identity as ClaimsIdentity;

            var claims = claimsIdentity.Claims.Select(x => new { type = x.Type, value = x.Value });

            return Ok(claims);
        }
    }
}