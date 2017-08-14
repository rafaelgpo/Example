using Example.Domain.Events;
using MediatR;
using System;
using System.Text;

namespace Example.Domain.Validation
{
    public class ValidationMessage : INotification
    {
        public string cod { get; set; }
        public string message { get; set; }

        public ValidationMessage(string _cod, string _message)
        {
            this.cod = _cod;
            this.message = _message;
        }
    }
}
