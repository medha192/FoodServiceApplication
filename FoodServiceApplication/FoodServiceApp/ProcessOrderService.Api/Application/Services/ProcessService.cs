using FoodServiceApp.Domain.Core.Bus;
using ProcessOrderService.Api.Application.Interfaces;
using ProcessOrderService.Api.Domain.Interfaces;
using ProcessOrderService.Api.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProcessOrderService.Api.Application.Services
{
    public class ProcessService : IProcessService
    {
        private readonly IProcessRepository _processRepository;
        private readonly IEventBus _bus;

        public ProcessService(IProcessRepository processRepository, IEventBus bus)
        {
            _processRepository = processRepository;
            _bus = bus;
        }
        public IEnumerable<ProcessOrderLog> GetOrderLogs()
        {
            return _processRepository.GetProcessLogs();
        }
    }
}
