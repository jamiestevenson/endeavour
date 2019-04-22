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
    /// Note that Actors are a combination of player characters, NPCs. retainers and extras, this allows
    /// the system to generate a 'crowd' of Actors that contains unknown danger an opportunity.
    /// </summary>
    [Route("api/[controller]")]
    public class ActorController : Controller
    {
        private readonly IApiFulfillment _backingService;

        public ActorController (IApiFulfillment backingService)
        {
            _backingService = backingService; 
        }

        // GET api/character
        [HttpGet]
        public ActorDirectoryResponseModel Get()
        {
            var actors = _backingService.AllPublicActors();

            return new ActorDirectoryResponseModel()
            {
                Directory = actors.Select(c => ResponseMapper.ToResponseActorDirectoryEntry(c))
                            .Cast<ResponseActorDirectoryEntry>().ToArray<ResponseActorDirectoryEntry>()
            };
        }

        // GET api/domain/5
        [HttpGet("{id}")]
        public ActorDirectoryResponseModel Get(string id)
        {
            if (String.IsNullOrEmpty(id.Trim()))
            {
                return null;
            }

            var actor = _backingService.GetActorById(id);

            if (actor == null)
            {
                return null;
            }

            // Get a resource
            return new ActorDirectoryResponseModel()
            {
                Directory = new ResponseActorDirectoryEntry[] { ResponseMapper.ToResponseActorDirectoryEntry(actor) }
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
