using PlaceOrderService.Api.Application.Models;
using PlaceOrderService.Api.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlaceOrderService.Api.Application.Interfaces
{
    public interface IOrderService
    {
        public IEnumerable<Order> GetOrders();

        public void PlaceOnlineOrder(PlaceOrder placeOrder);
    }
}
