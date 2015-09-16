using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebApiAngularTokenAuthExample
{
    [Authorize]
    public class ValuesController : ApiController
    {
        // GET api/<controller>
        public IHttpActionResult Get()
        {
            return Ok(new string[] { "value1", "value2" });
        }
    }
}