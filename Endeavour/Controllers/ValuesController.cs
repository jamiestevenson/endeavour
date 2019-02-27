using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Endeavour.Controllers
{
    [Route("api/[controller]")]
    public class DomainsController : Controller
    {
        // GET api/domains
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "domain1", "domain2" };
        }

        // GET api/domains/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "domain"+id;
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
