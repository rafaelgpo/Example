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

        public async Task<int?> Add(User user)
        {
            if (_userValidation.IsValidForAdd(user))
                return await _repository.Add(user);

            return null;
        }

        public async Task Delete(int id)
        {
            var user = await Get(id);
            await _repository.Delete(user);
        }

        public async Task<User> Get(int id)
        {
            var user = await _repository.Get(id);

            if (_userValidation.Exists(user))
                return user;

            return null;
        }

        public async Task<User> Get(string email)
        {
            var user = await _repository.Get(email);

            return user;
        }

        public async Task<IEnumerable<User>> GetAll()
        {
            return await _repository.GetAll();
        }

        public async Task Update(User user)
        {
            var userOld = await _repository.Get(user.Id);

            if (_userValidation.Exists(userOld) && _userValidation.IsValidForUpdate(user))
                await _repository.Update(user);
        }
    }
}
