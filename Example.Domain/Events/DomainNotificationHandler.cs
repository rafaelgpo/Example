using Example.Domain.Events.Interface;
using Example.Domain.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Example.Domain.Events
{
    public class DomainNotificationHandler : IDomainNotificationHandler<ValidationMessage>
    {
        private List<ValidationMessage> _notifications;

        public DomainNotificationHandler()
        {
            _notifications = new List<ValidationMessage>();
        }

        public void Handle(ValidationMessage message)
        {
            _notifications.Add(message);
        }

        public List<ValidationMessage> GetNotifications()
        {
            return _notifications;
        }

        public bool HasNotifications()
        {
            return GetNotifications().Any();
        }

        public void Dispose()
        {
            _notifications = new List<ValidationMessage>();
        }
    }
}
