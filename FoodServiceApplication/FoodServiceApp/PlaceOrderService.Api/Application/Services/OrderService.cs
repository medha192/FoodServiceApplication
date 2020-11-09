using FoodServiceApp.Domain.Core.Bus;
using PlaceOrderService.Api.Application.Interfaces;
using PlaceOrderService.Api.Application.Models;
using PlaceOrderService.Api.Domain.Commands;
using PlaceOrderService.Api.Domain.Interfaces;
using PlaceOrderService.Api.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlaceOrderService.Api.Application.Services
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IEventBus _bus;
        public OrderService(IOrderRepository orderRepository, IEventBus bus)
        {
            _orderRepository = orderRepository;
            _bus = bus;
        }
        public IEnumerable<Order> GetOrders()
        {
            return _orderRepository.GetOrders();
        }

        public void PlaceOnlineOrder(PlaceOrder placeOrder)
        {
            CreateOrderCommand createOrderCommand = new CreateOrderCommand(
                placeOrder.OrderFrom,
            placeOrder.OrderName,
            placeOrder.OderDetails,
            placeOrder.OrderQuantity,
            placeOrder.Amount
            );

            _bus.SendCommand(createOrderCommand);
        }
    }
}
