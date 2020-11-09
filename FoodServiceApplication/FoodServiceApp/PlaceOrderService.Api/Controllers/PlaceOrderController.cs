using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FoodServiceApp.Domain.Core.Bus;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PlaceOrderService.Api.Application.Interfaces;
using PlaceOrderService.Api.Application.Models;
using PlaceOrderService.Api.Domain.Models;

namespace PlaceOrderService.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlaceOrderController : ControllerBase
    {
        private readonly IEventBus _bus;
        private readonly IOrderService _orderService;

        public PlaceOrderController(IOrderService orderService, IEventBus bus)
        {
            _orderService = orderService;
            _bus = bus;
        }

        
        [HttpGet]
        public ActionResult<IEnumerable<Order>> Get()
        {
            return Ok(_orderService.GetOrders());
        }

        [HttpPost]
        public IActionResult Post([FromBody] PlaceOrder placeOrder)
        {
            _orderService.PlaceOnlineOrder(placeOrder);
            return Ok(placeOrder);
        }
    }
}
