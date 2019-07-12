using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API;
using ApiModels.Request;
using ApiModels.Response;
using GameLogicInterfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Endeavour.Controllers
{

    /// <summary>
    /// Note that Orders are composites of other API entities and this Controller is
    /// used to interrogate and update the state of these composites.
    /// </summary>
    [Route("api/[controller]")]
    public class OrderController : Controller
    {
        private readonly IApiFulfillment _backingService;

        public OrderController(IApiFulfillment backingService)
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
                Orders = orders.Select(c => ResponseMapper.ToResponseOrder(c))
                            .Cast<OrderResponseModel>().ToArray<OrderResponseModel>()
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
