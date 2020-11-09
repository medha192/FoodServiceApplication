using FoodServiceApp.Domain.Core.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProcessOrderService.Api.Domain.Events
{
    public class OrderCreated : Event
    {
        public string OrderFrom { get; set; }

        public string OrderName { get; set; }

        public string OrderDetails { get; set; }

        public int OrderQuantity { get; set; }

        public decimal Amount { get; set; }
        public OrderCreated(string orderFrom, string orderName, string orderDetails, int orderQuantity, decimal amount)
        {
            OrderFrom = orderFrom;
            OrderName = orderName;
            OrderDetails = orderDetails;
            OrderQuantity = orderQuantity;
            Amount = amount;
        }
    }
}
