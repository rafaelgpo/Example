using Example.API.Models;
using Example.Domain.Events;
using Example.Domain.Events.Interface;
using Example.Domain.Validation;
using Microsoft.AspNetCore.Mvc;

namespace Example.API.Controllers
{
    public class BaseController : Controller
    {
        private readonly IDomainNotificationHandler<ValidationMessage> _notifications;

        public BaseController(IDomainNotificationHandler<ValidationMessage> notifications)
        {
            this._notifications = notifications;
        }

        protected MessageHttpResponse HttpResponse()
        {
            return new MessageHttpResponse(null, _notifications);
        }

        protected MessageHttpResponse HttpResponse(object data)
        {
            return new MessageHttpResponse(data, _notifications);
        }


    }
}
