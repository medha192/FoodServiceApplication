using ProcessOrderService.Api.Application.Interfaces;
using ProcessOrderService.Api.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProcessOrderService.Api.Tests
{
    public class MockProcessService : IProcessService
    {
        public IEnumerable<ProcessOrderLog> GetOrderLogs()
        {
            ProcessOrderLog processOrderLog = new ProcessOrderLog();
            processOrderLog.OrderFrom = "From User";
            processOrderLog.OrderName = "Abc";
            processOrderLog.OderDetails = "Large Pizza";
            processOrderLog.OrderQuantity = 1;
            processOrderLog.Amount = 10;
            return (IEnumerable<ProcessOrderLog>)processOrderLog;
        }
    }
}
