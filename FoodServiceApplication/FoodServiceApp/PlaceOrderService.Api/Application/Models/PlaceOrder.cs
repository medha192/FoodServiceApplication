using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlaceOrderService.Api.Application.Models
{
    public class PlaceOrder
    {
        public string OrderFrom { get; set; }

        public string OrderName { get; set; }

        public string OderDetails { get; set; }

        public int OrderQuantity { get; set; }

        public decimal Amount { get; set; }
    }
}
