using Example.Domain.Events;
using Example.Domain.Events.Interface;
using Example.Domain.Model;
using Example.Domain.Validation;
using Example.Domain.Validation.Interface;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Example.API.Models
{
    public class MessageHttpResponse
    {
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public Object data { get; set; }
        public typeMessage type { get; set; }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public List<ValidationMessage> messages { get; set; }

        public MessageHttpResponse(Object data, DomainNotificationHandler domainNotification)
        {
            this.data = data;
            this.messages = domainNotification.HasNotifications() ? domainNotification.GetNotifications() : null;
            this.type = domainNotification.HasNotifications() ? typeMessage.VALIDATION_ERROR : typeMessage.SUCCESS;
        }

        public MessageHttpResponse(string code, string message, typeMessage type)
        {
            this.messages = new List<ValidationMessage>();
            this.messages.Add(new ValidationMessage(code, message));
            this.type = type;
        }
    }

    [JsonConverter(typeof(StringEnumConverter))]
    public enum typeMessage{
        SUCCESS,
        EXCEPTION_ERROR,
        VALIDATION_ERROR,
        NOT_FOUND
    }
}
