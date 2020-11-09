using FoodServiceApp.Domain.Core.Bus;
using ProcessOrderService.Api.Domain.Events;
using ProcessOrderService.Api.Domain.Interfaces;
using ProcessOrderService.Api.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProcessOrderService.Api.Domain.EventHandlers
{
    public class ProcessEventHandler : IEventHandler<OrderCreated>
    {
        private readonly IProcessRepository _processRepository;
        public ProcessEventHandler(IProcessRepository processRepository)
        {
            _processRepository = processRepository;
        }
        public Task Handler(OrderCreated @event)
        {
            _processRepository.Add(new ProcessOrderLog()
            {
                OrderFrom = @event.OrderFrom,
                OrderName = @event.OrderName,
                OderDetails = @event.OrderDetails,
                OrderQuantity = @event.OrderQuantity,
                Amount = @event.Amount
            });
            return Task.CompletedTask;
        }
    }
}
