using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using API;
using ApiModels.Request;
using ApiModels.Response;
using GameLogicInterfaces;
using Microsoft.AspNetCore.Mvc;

namespace Endeavour.Controllers
{

    /// <summary>
    /// Note that Orders are composites of other API entities and this Controller is
    /// used to interrogate and update the state of these composites.
    /// </summary>
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class OrdersController : Controller
    {
        private readonly IApiFulfillment _backingService;

        public OrdersController(IApiFulfillment backingService)
        {
            _backingService = backingService; 
        }

        // GET api/order
        [HttpGet]
        public OrdersResponseModel Get()
        {
            var orders = _backingService.GetLastOrders();

            return new OrdersResponseModel()
            {
                Orders = orders.Select(c => ResponseMapper.ToResponseOrder(c)).ToArray<OrderResponseModel>()
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
                Directory = endeavours.Select(c => ResponseMapper.ToResponseEndeavourDirectoryEntry(c))
                            .Cast<ResponseEndeavourDirectoryEntry>().ToArray<ResponseEndeavourDirectoryEntry>()
            };
        }
    }
}
