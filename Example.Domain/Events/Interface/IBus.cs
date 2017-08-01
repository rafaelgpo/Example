using System;
using System.Collections.Generic;
using System.Text;

namespace Example.Domain.Events.Interface
{
    public interface IBus
    {
        void RaiseEvent<T>(T theEvent) where T : Event;
    }
}
