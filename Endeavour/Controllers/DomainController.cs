using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API;
using ApiModels.Response;
using GameLogicInterfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Endeavour.Controllers
{
    [Route("api/[controller]")]
    public class DomainController : Controller
    {
        // TODO add injected backing service implementation
        private readonly IApiFulfillment _backingService;

        public DomainController (IApiFulfillment backingService)
        {
            _backingService = backingService; 
        }

        // GET api/domain
        [HttpGet]
        public DomainsResponseModel Get()
        {
            var domains = _backingService.AllDomains();

            return new DomainsResponseModel()
            {
                Domains = domains.Select(d => ResponseMapper.ToResponseDomain(d))
                            .Cast<ResponseDomain>().ToArray<ResponseDomain>()
            };
        }

        // GET api/domain/5
        [HttpGet("{id}")]
        public DomainResponseModel Get(string id)
        {
            if (String.IsNullOrEmpty(id.Trim()))
            {
                return null;
            }

            var domain = _backingService.GetDomainById(id);

            if (domain == null)
            {
                return null;
            }

            // Get a resource
            return new DomainResponseModel()
            {
                Domain = ResponseMapper.ToResponseDomain(domain)
            };
        }

        // POST api/domain
        [HttpPost]
        public void Post([FromBody]string value)
        {
            // Create new resource
        }

        // PUT api/domain/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
            // Update existing resource
        }

        //// DELETE api/domain/5
        //[HttpDelete("{id}")]
        //public void Delete(string id)
        //{
        //    if (String.IsNullOrEmpty(id))
        //    {
        //        return;
        //    }

        //    bool success = _backingService.DeleteDomain(id);
        //    return; // TODO Add in controller responses for failure
        //}
    }
}
