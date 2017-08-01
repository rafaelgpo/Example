using System;
using System.Collections.Generic;
using System.Text;

namespace Example.Domain.Events.Interface
{
    public interface IHandler<in T> where T : Message
    {
        void Handle(T message);
    }
}
