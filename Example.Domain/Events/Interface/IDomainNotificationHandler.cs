using Example.Domain.Validation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Example.Domain.Events.Interface
{
    public interface IDomainNotificationHandler<T> : IHandler<T> where T : ValidationMessage
    {
        bool HasNotifications();
        List<T> GetNotifications();
    }
}
