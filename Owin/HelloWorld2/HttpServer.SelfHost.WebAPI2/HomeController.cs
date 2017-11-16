using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace HttpServer.SelfHost.WebAPI2
{
    public class HomeController : ApiController
    {
        // GET api/values 
        public IHttpActionResult Get()
        {
            return Ok(125);
        }
        // GET api/values/5 
        public string Get(int id)
        {
            return "value";
        }
        // POST api/values 
        public void Post([FromBody]string value)
        {
        }
        // PUT api/values/5 
        public void Put(int id, [FromBody]string value)
        {
        }
        // DELETE api/values/5 
        public void Delete(int id)
        {
        }
    }
}
