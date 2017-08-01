using System;
using System.Collections.Generic;
using System.Text;

namespace Example.Domain.Events.Interface
{
    public interface IDomainNotificationHandler<T> : IHandler<T> where T : Message
    {
        bool HasNotifications();
        List<T> GetNotifications();
    }
}
