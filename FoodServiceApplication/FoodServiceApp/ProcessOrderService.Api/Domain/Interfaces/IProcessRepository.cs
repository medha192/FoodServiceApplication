using ProcessOrderService.Api.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProcessOrderService.Api.Domain.Interfaces
{
    public interface IProcessRepository
    {
        IEnumerable<ProcessOrderLog> GetProcessLogs();
        void Add(ProcessOrderLog processLog);
    }
}
