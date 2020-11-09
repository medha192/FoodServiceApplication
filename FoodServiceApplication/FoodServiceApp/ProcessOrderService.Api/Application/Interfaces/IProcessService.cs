using ProcessOrderService.Api.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProcessOrderService.Api.Application.Interfaces
{
    public interface IProcessService
    {
        public IEnumerable<ProcessOrderLog> GetOrderLogs();
    }
}
