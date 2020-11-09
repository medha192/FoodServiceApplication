using FoodServiceApp.Domain.Core.Events;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FoodServiceApp.Domain.Core.Bus
{
    public interface IEventHandler<in TEvents> : IEventHandler
        where TEvents : Event
    {
        Task Handler(TEvents @events);
    }

    public interface IEventHandler
    {
    }
}
