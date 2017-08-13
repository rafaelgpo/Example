using Example.Domain.Validation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Example.Domain.Response
{
    public class Response<T>
    {
        public ValidationMessages Messages { get; set; }
        public bool IsValid { get { return Messages != null && Messages.Count > 0 ? false : true; } }
        public T Data { get; set; }

        public Response(T _data)
        {
            this.Data = _data;
        }

        public Response(ValidationMessages _messages)
        {
            this.Messages = _messages;
        }
    }
}
