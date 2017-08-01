using Example.Domain.Events.Interface;
using Example.Domain.Model;
using Example.Domain.Repository.Interface;
using Example.Domain.Validation.Interface;
using FluentValidation;

namespace Example.Domain.Validation
{
    public class UserAddValidation : EntityValidation<User>, IUserAddValidation
    {
        public UserAddValidation(IBus bus, IUserRepository repository) : base(bus, repository)
        {
        }

        public new bool IsValid(User user)
        {
            EmptyNameValidationRules();
            EmptyEmailValidationRules();

            return base.IsValid(user);
        }

        private void EmptyNameValidationRules()
        {
            RuleFor(user => user.Name).NotEmpty().WithMessage("Please specify a name");
        }

        private void EmptyEmailValidationRules()
        {
            _repository.Get("rafaelgpo@gmail.com");

            RuleFor(user => user.Email).NotEmpty().WithMessage("Please specify a e-mail");
        }
    }
}
