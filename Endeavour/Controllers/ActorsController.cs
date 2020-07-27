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

    /// <summary>
    /// Actors are a combination of player characters, NPCs. retainers and extras, this allows
    /// the system to generate a 'crowd' of Actors that contains unknown danger an opportunity.
    /// </summary>
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class ActorsController : Controller
    {
        private readonly IApiFulfillment _backingService;

        public ActorsController(IApiFulfillment backingService)
        {
            _backingService = backingService;
        }

        /// <summary>
        /// Get all public actors in the system
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     GET api/actors
        ///
        /// </remarks>
        /// <returns>Zero or more actors</returns>
        /// <response code="200">Returns a response model which may be paged</response>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActorDirectoryResponseModel Get()
        {
            var actors = _backingService.AllPublicActors();

            return new ActorDirectoryResponseModel()
            {
                Directory = actors.Select(c => ResponseMapper.ToResponseActorDirectoryEntry(c))
                            .ToArray<ResponseActorDirectoryEntry>()
            };
        }

        /// <summary>
        /// Get a specific Actor
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     GET api/actor/5
        ///
        /// </remarks>
        /// <returns></returns>
        /// <response code="200">Returns a response model with a single Actor</response>
        /// <response code="400">Returns a response model which may be paged</response>
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActorDirectoryResponseModel Get([Required] string id)
        {
            if (String.IsNullOrEmpty(id.Trim()))
            {
                Response.StatusCode = StatusCodes.Status400BadRequest;
                return null;
            }

            var actor = _backingService.GetActorById(id);

            if (actor == null)
            {
                Response.StatusCode = StatusCodes.Status404NotFound;
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
