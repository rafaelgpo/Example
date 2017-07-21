using Example.Domain.Model;
using Example.Domain.Validation;
using FluentValidation.Results;
using System.Collections.Generic;

namespace Example.Domain.Messaging
{
    public class AddResponse : BaseValidation<User>
    {
        public int? Id { get; set; }

        public AddResponse(int _id)
        {
            this.Id = _id;
        }

        public AddResponse(List<ValidationMessage> messages)
        {
            this.messages = messages;
        }
    }
}
