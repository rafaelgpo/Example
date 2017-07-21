using Example.Domain.Model;
using Example.Domain.Validation;
using FluentValidation.Results;
using System.Collections.Generic;

namespace Example.Domain.Messaging
{
    public class UpdateResponse : BaseValidation<User>
    {
        public UpdateResponse(List<ValidationMessage> messages)
        {
            this.messages = messages;
        }
    }
}
