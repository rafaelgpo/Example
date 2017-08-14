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
        private readonly IMediatorHandler _bus;

        public EntityValidation(IMediatorHandler bus, IUserRepository repository)
        {
            _bus = bus;
            _repository = repository;
        }

        public bool IsValid(T entity)
        {
            var result = base.Validate(entity);

            foreach (var error in base.Validate(entity).Errors)
                _bus.RaiseEvent(new ValidationMessage(error.ErrorCode, error.ErrorMessage));
            return result.IsValid;
        }

        public bool Exists(T entity)
        {
            var exists = entity != null ? true : false;

            if(!exists)
                _bus.RaiseEvent(new ValidationMessage("NotExists", "The object not exists."));

            return exists;
        }
    }
}
