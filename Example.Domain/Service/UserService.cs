using Example.Domain.Service.Interface;
using System.Collections.Generic;
using Example.Domain.Model;
using Example.Domain.Repository.Interface;
using System.Threading.Tasks;
using System;
using Example.Domain.Validation;
using Example.Domain.Validation.Interface;
using Example.Domain.Events.Interface;


namespace Example.Domain.Service
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _repository;
        private readonly IUserValidation _userValidation;

        public UserService(IUserRepository repository, IUserValidation userValidation)
        {
            this._repository = repository;

            this._userValidation = userValidation;
        }
    }
}
