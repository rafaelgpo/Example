using Example.Domain.Model;
using Example.Domain.Repository.Interface;
using Example.Domain.Validation.Interface;
using FluentValidation;

namespace Example.Domain.Validation
{
    public class UserValidation : EntityValidation<User>, IUserValidation
    {
        public bool IsValidForAdd(User user)
        {
            EmptyNameValidationRules();
            EmptyEmailValidationRules();

            return base.Validate(user);
        }

        public bool IsValidForUpdate(User user)
        {
            EmptyNameValidationRules();
            return base.Validate(user);
        }

        public bool IsValidForGet(User user)
        {
            return base.Validate(user);
        }

        private void EmptyNameValidationRules()
        {
            RuleFor(user => user.Name).NotEmpty().WithMessage("Please specify a name");
        }

        private void EmptyEmailValidationRules()
        {
            RuleFor(user => user.Email).NotEmpty().WithMessage("Please specify a e-mail");
        }
    }
}
