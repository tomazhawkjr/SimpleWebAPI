using SimpleWebAPI.API.Infrastructure.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SimpleWebAPI.Controllers
{
    [RoutePrefix("api/Values")]
    public class ValuesController : BaseApiController
    {
        // GET api/Values/Get
        [Route("Get")]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

   
        [Route("Post")]
        // POST api/Values/Post
        public void Post(string value)
        {
        }

    }
}
