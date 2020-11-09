using Microsoft.EntityFrameworkCore;
using PlaceOrderService.Api.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlaceOrderService.Api.Data.Context
{
    public class PlaceOrderDbContext : DbContext 
    {
        public PlaceOrderDbContext(DbContextOptions options) : base(options)
        {

        }

        public PlaceOrderDbContext()
        {

        }

        public DbSet<Order> Orders { get; set; }
    }
}
