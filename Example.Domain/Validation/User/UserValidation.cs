using System;
using Example.Domain.Events.Interface;
using Example.Domain.Model;
using Example.Domain.Repository.Interface;
using Example.Domain.Validation.Interface;
using FluentValidation;

namespace Example.Domain.Validation
{
    public class UserValidation : EntityValidation<User>, IUserValidation
    {
        public UserValidation(IMediatorHandler bus, IUserRepository repository) : base(bus, repository)
        {
        }

        public bool IsValidForAdd(User user)
        {
            EmptyNameValidationRules();
            EmptyEmailValidationRules();

            return base.IsValid(user);
        }

        public bool IsValidForUpdate(User user)
        {
            EmptyNameValidationRules();
            return base.IsValid(user);
        }

        public bool IsValidForGet(User user)
        {
            return base.IsValid(user);
        }

        private void EmptyNameValidationRules()
        {
            RuleFor(user => user.Name).NotEmpty().WithMessage("Please specify a name");
        }

        private void EmptyEmailValidationRules()
        {
            RuleFor(user => user.Email).NotEmpty().WithMessage("Please specify a e-mail");
        }

        public new bool Exists(User user)
        {
            return base.Exists(user);
        }
    }
}
