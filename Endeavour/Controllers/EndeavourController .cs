﻿using System;
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
    /// Note that Endeavours are composites of other API entities and this Controller is
    /// used to interrogate and update the state of these composites.
    /// </summary>
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class EndeavoursController : Controller
    {
        private readonly IApiFulfillment _backingService;

        public EndeavoursController(IApiFulfillment backingService)
        {
            _backingService = backingService; 
        }

        // GET api/endeavour
        [HttpGet]
        public EndeavourDirectoryResponseModel Get()
        {
            var endeavours = _backingService.GetPublicEndeavours();

            return new EndeavourDirectoryResponseModel()
            {
                Directory = endeavours.Select(c => ResponseMapper.ToResponseEndeavourDirectoryEntry(c)).ToArray<ResponseEndeavourDirectoryEntry>()
            };
        }

        // GET api/endeavour/5
        [HttpGet("{id}")]
        public EndeavourDirectoryResponseModel Get([Required] string userId)
        {
            if (String.IsNullOrEmpty(userId.Trim()))
            {
                return null;
            }

            var endeavours = _backingService.GetMyEndeavours(userId);

            if (endeavours == null)
            {
                return null;
            }

            // Get a resource
            return new EndeavourDirectoryResponseModel()
            {
                Directory = endeavours.Select(c => ResponseMapper.ToResponseEndeavourDirectoryEntry(c)).ToArray<ResponseEndeavourDirectoryEntry>()
            };
        }
    }
}
