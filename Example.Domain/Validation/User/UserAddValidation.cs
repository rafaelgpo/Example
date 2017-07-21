using Example.Domain.Validation.Interface;
using FluentValidation;

namespace Example.Domain.Validation
{
    public class UserAddValidation : BaseValidation<Model.User>, IUserAddValidation
    {
        public UserAddValidation()
        {
            EmptyNameValidationRules();
            EmptyEmailValidationRules();
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
