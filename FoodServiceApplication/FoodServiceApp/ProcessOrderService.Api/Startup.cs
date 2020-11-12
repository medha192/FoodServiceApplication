using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FoodServiceApp.Domain.Core.Bus;
using FoodServiceApp.Infra.Bus;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using ProcessOrderService.Api.Application.Interfaces;
using ProcessOrderService.Api.Application.Services;
using ProcessOrderService.Api.Data.Context;
using ProcessOrderService.Api.Data.Repository;
using ProcessOrderService.Api.Domain.EventHandlers;
using ProcessOrderService.Api.Domain.Events;
using ProcessOrderService.Api.Domain.Interfaces;
using Prometheus;

namespace ProcessOrderService.Api
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

            var connString = Configuration.GetConnectionString("ProcessOrderDbConnection");
            services.AddDbContext<ProcessDbContext>(options =>
            {
                options.UseSqlServer(connString);
            }
          );

            services.AddControllers();
            services.AddTransient<IProcessService, ProcessService>();
            services.AddTransient<IProcessRepository, ProcessRepository>();
            services.AddSingleton<IEventBus, RabbitMQBus>(sp =>
            {
                var scopeFactory = sp.GetRequiredService<IServiceScopeFactory>();
                return new RabbitMQBus(sp.GetService<IMediator>(), scopeFactory);
            });
            //Subscriptions
            services.AddTransient<ProcessEventHandler>();
            services.AddTransient<IEventHandler<OrderCreated>, ProcessEventHandler>();

            services.AddSwaggerGen();
            services.AddMediatR(typeof(Startup));
            services.AddSwaggerGen();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseSwagger();
            if (env.IsDevelopment())
            {
                app.UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Process order service V1");
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

            ConfigureEventBus(app);
        }

        private void ConfigureEventBus(IApplicationBuilder app)
        {
            var eventBus = app.ApplicationServices.GetRequiredService<IEventBus>();
            eventBus.Subscribe<OrderCreated, ProcessEventHandler>();
        }
    }
}
