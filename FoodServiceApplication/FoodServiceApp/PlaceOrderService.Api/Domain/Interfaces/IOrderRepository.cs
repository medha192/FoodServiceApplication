using PlaceOrderService.Api.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlaceOrderService.Api.Domain.Interfaces
{
    public interface IOrderRepository
    {
        IEnumerable<Order> GetOrders();
    }
}
