using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlaceOrderService.Api.Domain.Models
{
    public class Order
    {
        public int Id { get; set; }

        public string OrderFrom { get; set; }

        public string OrderName { get; set; }

        public string OderDetails { get; set; }

        public int OrderQuantity { get; set; }

        public decimal Amount { get; set; }
    }
}
