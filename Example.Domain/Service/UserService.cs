using Example.Domain.Service.Interface;
using System.Collections.Generic;
using Example.Domain.Model;
using Example.Domain.Repository.Interface;
using System.Threading.Tasks;
using System;
using Example.Domain.Validation;
using Example.Domain.Validation.Interface;

namespace Example.Domain.Service
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _repository;
        private readonly IUserAddValidation _addValidation;
        private readonly IUserUpdateValidation _updateValidation;

        public UserService(IUserRepository repository, IUserAddValidation addValidation, IUserUpdateValidation updateValidation)
        {
            this._repository = repository;
            this._addValidation = addValidation;
            this._updateValidation = updateValidation;
        }

        public async Task<int?> Add(User user)
        {
            if (_addValidation.IsValid(user))
            {
                return await _repository.Add(user);
            }

            return null;
        }

        public async Task Delete(int id)
        {
            var user = await Get(id);
            await _repository.Delete(user);
        }

        public async Task<User> Get(int id)
        {
            return await _repository.Get(id);
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
            if (_updateValidation.IsValid(user))
                await _repository.Update(user);
        }
    }
}
