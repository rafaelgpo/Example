using Example.Domain.Events;
using Example.Domain.Events.Interface;
using Example.Domain.Repository.Interface;
using FluentValidation;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Text;

namespace Example.Domain.Validation
{
    public class EntityValidation<T> : AbstractValidator<T>
    {
        public readonly IUserRepository _repository;
        private readonly IBus _bus;

        public EntityValidation(IBus bus, IUserRepository repository)
        {
            _bus = bus;
            _repository = repository;
        }

        public bool IsValid(T entity)
        {
            if (entity == null)
            {
                _bus.RaiseEvent(new ValidationMessage("NullObject", "Object not exists"));
                return false;
            }
            else
            {
                var result = base.Validate(entity);

                foreach (var error in base.Validate(entity).Errors)
                    _bus.RaiseEvent(new ValidationMessage(error.ErrorCode, error.ErrorMessage));
                return result.IsValid;
            }
        }
    }
}
