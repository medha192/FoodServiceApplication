using FoodServiceApp.Domain.Core.Bus;
using MediatR;
using PlaceOrderService.Api.Domain.Commands;
using PlaceOrderService.Api.Domain.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace PlaceOrderService.Api.Domain.CommandHandlers
{
    public class OrderCommandHandler : IRequestHandler<CreateOrderCommand, bool>
    {
        public readonly IEventBus _bus;
        public OrderCommandHandler(IEventBus bus)
        {
            _bus = bus;
        }
        public Task<bool> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
        {
            _bus.Publish(new OrderCreated(request.OrderFrom, request.OrderName, request.OrderDetails, request.OrderQuantity, request.Amount));
            //publish event to rabbitmq
            return Task.FromResult(true);
        }
    }
}
