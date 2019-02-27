using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GameLogicInterfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ResponseModels;

namespace Endeavour.Controllers
{
    [Route("api/[controller]")]
    public class DomainsController : Controller
    {
        // TODO add injected backing service implementation
        private IApiFulfillment backingService;

        DomainsController ()
        {
            
        }

        // GET api/domains
        [HttpGet]
        public IEnumerable<DomainResponseModel> Get()
        {
            DomainResponseModel d1 = new DomainResponseModel()
            {
                Id = Guid.NewGuid(),
                Name = "An abandoned lot",
                Description = "This domain is not very interesting"
            };
            DomainResponseModel d2 = new DomainResponseModel()
            {
                Id = Guid.NewGuid(),
                Name = "A small park",
                Description = "This is well maintained and popular"
            };

            return new List<DomainResponseModel>() {d1, d2};
        }

        // GET api/domains/5
        [HttpGet("{id}")]
        public string Get(string id)
        {
            // Get a resource
            return "domain"+id;
        }

        // POST api/domains
        [HttpPost]
        public void Post([FromBody]string value)
        {
            // Create new resource
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
            // Update existing resource
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(string id)
        {
            if (String.IsNullOrEmpty(id))
            {
                return;
            }

            bool success = backingService.DeleteDomain(id);
            return; // Add in controller responses for failure
        }
    }
}
