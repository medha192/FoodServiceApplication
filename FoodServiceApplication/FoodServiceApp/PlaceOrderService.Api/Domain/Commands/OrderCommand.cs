using FoodServiceApp.Domain.Core.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlaceOrderService.Api.Domain.Commands
{
    public class OrderCommand : Command
    {
        public string OrderFrom { get; set; }

        public string OrderName { get; set; }

        public string OrderDetails { get; set; }

        public int OrderQuantity { get; set; }

        public decimal Amount { get; set; }
    }
}
