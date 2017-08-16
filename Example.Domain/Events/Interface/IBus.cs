using Example.Domain.Validation;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Example.Domain.Events.Interface
{
    public interface IMediatorHandler
    {
        Task RaiseEvent<T>(T @event) where T : ValidationMessage;
    }
}
