using ProcessOrderService.Api.Data.Context;
using ProcessOrderService.Api.Domain.Interfaces;
using ProcessOrderService.Api.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProcessOrderService.Api.Data.Repository
{
    public class ProcessRepository : IProcessRepository
    {
        private ProcessDbContext _context;

        public ProcessRepository(ProcessDbContext context)
        {
            _context = context;
        }
        public void Add(ProcessOrderLog processLog)
        {
            _context.ProcessOrderLogs.Add(processLog);
            _context.SaveChanges();
        }

        public IEnumerable<ProcessOrderLog> GetProcessLogs()
        {
            return _context.ProcessOrderLogs;
        }
    }
}
