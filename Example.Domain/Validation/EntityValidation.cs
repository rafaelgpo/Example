using Example.Domain.Repository.Interface;
using FluentValidation;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Text;

namespace Example.Domain.Validation
{
    public class EntityValidation<T> : AbstractValidator<T>, IEntityValidation<T>
    {
        public ValidationMessages messages { get; set; }
        public bool isValid { get { return messages.Count == 0 ? true : false; } }

        public EntityValidation()
        {
            messages = new ValidationMessages();
        }

        public new bool Validate(T entity)
        {
            if (entity != null)
            {
                foreach (var error in base.Validate(entity).Errors)
                    messages.Add(new ValidationMessage(error.ErrorCode, error.ErrorMessage));
            }else
                messages.Add(new ValidationMessage("NullValue", "Object not found"));

            return isValid;
        }
    }
}
