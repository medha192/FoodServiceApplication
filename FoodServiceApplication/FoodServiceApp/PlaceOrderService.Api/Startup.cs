using FoodServiceApp.Domain.Core.Bus;
using FoodServiceApp.Infra.Bus;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using PlaceOrderService.Api.Application.Interfaces;
using PlaceOrderService.Api.Application.Services;
using PlaceOrderService.Api.Data.Context;
using PlaceOrderService.Api.Data.Repository;
using PlaceOrderService.Api.Domain.CommandHandlers;
using PlaceOrderService.Api.Domain.Commands;
using PlaceOrderService.Api.Domain.Interfaces;
using Prometheus;

namespace PlaceOrderService.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            var connString = Configuration.GetConnectionString("PlaceOrderDbConnection");
            services.AddDbContext<PlaceOrderDbContext>(options =>
            {
                options.UseSqlServer(connString);
            }
          );
            services.AddControllers();
            services.AddTransient<IOrderService, OrderService>();
            services.AddTransient<IOrderRepository, OderRepository>();
            services.AddSingleton<IEventBus, RabbitMQBus>(sp =>
            {
                var scopeFactory = sp.GetRequiredService<IServiceScopeFactory>();
                return new RabbitMQBus(sp.GetService<IMediator>(), scopeFactory);
            });

            //Domain Banking Commands
            services.AddTransient<IRequestHandler<CreateOrderCommand, bool>, OrderCommandHandler>();
            services.AddSwaggerGen();
            services.AddMediatR(typeof(Startup));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseSwagger();
            if (env.IsDevelopment())
            {
                app.UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Order Food service V1");
                });
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseHttpMetrics();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapMetrics();
            });
        }
    }
}