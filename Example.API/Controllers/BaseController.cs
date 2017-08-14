using Example.API.Models;
using Example.Domain.Events;
using Example.Domain.Events.Interface;
using Example.Domain.Validation;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Example.API.Controllers
{
    public class BaseController : Controller
    {
        private readonly DomainNotificationHandler _notifications;

        public BaseController(INotificationHandler<ValidationMessage> notifications)
        {
            this._notifications = (DomainNotificationHandler)notifications;
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
