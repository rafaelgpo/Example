using Example.Domain.Validation.Interface;
using FluentValidation;

namespace Example.Domain.Validation
{
    public class UserUpdateValidation : BaseValidation<Model.User>, IUserUpdateValidation
    {
        public UserUpdateValidation()
        {
            EmptyNameValidationRules();
        }

        private void EmptyNameValidationRules()
        {
            RuleFor(user => user.Name).NotEmpty().WithMessage("Please specify a name");
        }

    }
}
