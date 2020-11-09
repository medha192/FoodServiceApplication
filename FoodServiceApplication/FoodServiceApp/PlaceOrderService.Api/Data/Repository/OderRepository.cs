using PlaceOrderService.Api.Data.Context;
using PlaceOrderService.Api.Domain.Interfaces;
using PlaceOrderService.Api.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlaceOrderService.Api.Data.Repository
{
    public class OderRepository : IOrderRepository
    {
        private PlaceOrderDbContext _context;

        public OderRepository(PlaceOrderDbContext context)
        {
            this._context = context;
        }
        public IEnumerable<Order> GetOrders()
        {
            return _context.Orders;
        }
    }
}
