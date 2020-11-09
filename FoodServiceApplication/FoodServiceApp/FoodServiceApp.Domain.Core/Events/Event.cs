using System;
using System.Collections.Generic;
using System.Text;

namespace FoodServiceApp.Domain.Core.Events
{
    public abstract class Event
    {
        public DateTime TimeStamp { get; protected set; }

        public Event()
        {
            TimeStamp = DateTime.Now;
        }
    }
}
