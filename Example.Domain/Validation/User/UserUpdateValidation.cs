using Example.Domain.Events.Interface;
using Example.Domain.Model;
using Example.Domain.Repository.Interface;
using Example.Domain.Validation.Interface;
using FluentValidation;

namespace Example.Domain.Validation
{
    public class UserUpdateValidation : EntityValidation<User>, IUserUpdateValidation
    {
        public UserUpdateValidation(IBus bus, IUserRepository repository) : base(bus, repository)
        {
        }

        public new void Validate(User user)
        {
            EmptyNameValidationRules();
            base.Validate(user);
        }

        private void EmptyNameValidationRules()
        {
            RuleFor(user => user.Name).NotEmpty().WithMessage("Please specify a name");
        }

    }
}
