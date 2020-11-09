using Microsoft.EntityFrameworkCore;
using ProcessOrderService.Api.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProcessOrderService.Api.Data.Context
{
    public class ProcessDbContext : DbContext
    {
        public ProcessDbContext(DbContextOptions options) : base(options)
        {

        }

        public ProcessDbContext()
        {

        }
        public DbSet<ProcessOrderLog> ProcessOrderLogs { get; set; }
    }
}
