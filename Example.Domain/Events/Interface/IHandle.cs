using Example.Domain.Validation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Example.Domain.Events.Interface
{
    public interface IHandler<in T> where T : ValidationMessage
    {
        void Handle(T message);
    }
}
