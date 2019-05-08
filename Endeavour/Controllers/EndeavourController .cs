using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API;
using ApiModels.Response;
using GameLogicInterfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ResponseModels;
using ResponseModels.Domain;

namespace Endeavour.Controllers
{

    /// <summary>
    /// Note that Endeavours are composites of other API entities and this Controller is
    /// used to interrogate and update the state of these composites.
    /// </summary>
    [Route("api/[controller]")]
    public class EndeavourController : Controller
    {
        private readonly IApiFulfillment _backingService;

        public EndeavourController(IApiFulfillment backingService)
        {
            _backingService = backingService; 
        }

        // GET api/endeavour
        [HttpGet]
        public ActorDirectoryResponseModel Get()
        {
            var endeavours = _backingService.GetPublicEndeavours();

            return new EndeavourDirectoryResponseModel()
            {
                Directory = endeavours.Select(c => ResponseMapper.ToResponseEndeavourDirectoryEntry(c))
                            .Cast<ResponseEndeavourDirectoryEntry>().ToArray<ResponseEndeavourDirectoryEntry>()
            };
        }

        // GET api/endeavour/5
        [HttpGet("{id}")]
        public EndeavourDirectoryResponseModel Get(string userId)
        {
            if (String.IsNullOrEmpty(userId.Trim()))
            {
                return null;
            }

            var endeavour = _backingService.GetMyEndeavours(userId);

            if (endeavour == null)
            {
                return null;
            }

            // Get a resource
            return new EndeavourDirectoryResponseModel()
            {
                Directory = new ResponseEndeavourDirectoryEntry[] { ResponseMapper.ToResponseEndeavourDirectoryEntry(actor) }
            };
        }
    }
}
