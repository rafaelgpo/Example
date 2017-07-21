using Example.Domain.Validation.Interface;
using FluentValidation;
using FluentValidation.Results;
using System.Collections.Generic;

namespace Example.Domain.Validation
{
    public class BaseValidation<T> : AbstractValidator<T>, IBaseValidation<T>
    {
        public bool isValid { get { return this.messages.Count > 0 ? false : true; }}

        public List<ValidationMessage> messages { get; set; }

        public void Validate(T entity)
        {
            AddErrors(base.Validate(entity).Errors);
        }

        public BaseValidation()
        {
            this.messages = new List<ValidationMessage>();
        }

        public void AddErrors(IList<ValidationFailure> errors)
        {
            new List<ValidationFailure>(errors).ForEach(e => this.AddError(new ValidationMessage(e.ErrorCode, e.ErrorMessage)));
        }

        public void AddErrors(List<ValidationMessage> errors)
        {
            new List<ValidationMessage>(errors).ForEach(e => this.AddError(new ValidationMessage(e.cod, e.message)));
        }

        public void AddError(ValidationMessage error)
        {
            this.messages.Add(error);
        }

    }
}
