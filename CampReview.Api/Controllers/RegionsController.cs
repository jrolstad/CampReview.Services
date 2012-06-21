using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CampReview.Api.Controllers
{
    public class RegionsController : ApiController
    {
        // GET api/regions
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/regions/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/regions
        public void Post(string value)
        {
        }

        // PUT api/regions/5
        public void Put(int id, string value)
        {
        }

        // DELETE api/regions/5
        public void Delete(int id)
        {
        }
    }
}
