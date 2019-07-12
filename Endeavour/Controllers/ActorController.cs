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

        // GET api/actor
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

        // GET api/actor/5
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
    }
}
