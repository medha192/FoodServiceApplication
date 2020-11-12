using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using FoodService.MVC.Models;
using FoodService.MVC.Services;
using FoodService.MVC.Models.DTO;

namespace FoodService.MVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly IOrderService _orderService;

        public HomeController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [HttpPost]
        public async Task<IActionResult> Order(OrderViewModel orderViewModel)
        {
            OrderDto orderDto = new OrderDto() {
                OderDetails = orderViewModel.OderDetails,
                OrderName = orderViewModel.OrderName,
                OrderFrom = orderViewModel.OrderFrom,
                OrderQuantity = orderViewModel.OrderQuantity,
                Amount = orderViewModel.Amount
            };

            await _orderService.Order(orderDto);

            return View("Index");
        }
    }
}
