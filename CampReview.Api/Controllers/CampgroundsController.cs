using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CampReview.Api.Controllers
{
    public class CampgroundsController : ApiController
    {

        // GET api/campgrounds/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/campgrounds
        public void Post(string value)
        {
        }

        // PUT api/campgrounds/5
        public void Put(int id, string value)
        {
        }

        // DELETE api/campgrounds/5
        public void Delete(int id)
        {
        }
    }
}
