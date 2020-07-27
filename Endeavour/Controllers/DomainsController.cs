using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using API;
using ApiModels.Response;
using GameLogicInterfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Endeavour.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class DomainsController : Controller
    {
        // TODO add injected backing service implementation
        private readonly IApiFulfillment _backingService;

        public DomainsController (IApiFulfillment backingService)
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
                Domains = domains.Select(d => ResponseMapper.ToResponseDomain(d)).ToArray<ResponseDomain>()
            };
        }

        // GET api/domain/5
        [HttpGet("{id}")]
        public DomainResponseModel Get([Required]string id)
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
            // Update to have request model
        }

        // PUT api/domain/5
        [HttpPut("{id}")]
        public void Put([Required]int id, [FromBody]string value)
        {
            // Update existing resource
            // Update to have request model
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
