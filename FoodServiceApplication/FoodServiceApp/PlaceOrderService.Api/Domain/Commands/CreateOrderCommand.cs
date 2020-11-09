using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlaceOrderService.Api.Domain.Commands
{
    public class CreateOrderCommand : OrderCommand
    {
        public CreateOrderCommand(string orderFrom, string orderName, string orderDetails, int orderQuantity, decimal amount)
        {
            OrderFrom = orderFrom;
            OrderName = orderName;
            OrderDetails = orderDetails;
            OrderQuantity = orderQuantity;
            Amount = amount;
        }
    }
}
