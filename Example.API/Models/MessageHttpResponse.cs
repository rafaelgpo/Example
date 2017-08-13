using Example.Domain.Model;
using Example.Domain.Response;
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

        public static MessageHttpResponse Response(string code, string message, typeMessage type)
        {
            var httpResponse = new MessageHttpResponse();
            httpResponse.messages.Add(new ValidationMessage(code, message));
            httpResponse.type = type;
            return httpResponse;
        }

        public static MessageHttpResponse Response<T>(Response<T> response)
        {
            var httpResponse = new MessageHttpResponse();

            httpResponse.data = response.Data;
            httpResponse.messages = !response.IsValid ? response.Messages : null;
            httpResponse.type = !response.IsValid ? typeMessage.VALIDATION_ERROR : typeMessage.SUCCESS;

            return httpResponse;
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
