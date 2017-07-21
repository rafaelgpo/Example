using Example.Domain.Service.Interface;
using System.Collections.Generic;
using Example.Domain.Model;
using Example.Domain.Repository.Interface;
using System.Threading.Tasks;
using Example.Domain.Messaging;
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

        public UserService
            (
                IUserRepository repository, 
                IUserAddValidation addValidation, 
                IUserUpdateValidation updateValidation
            )
        {
            this._repository = repository;
            this._addValidation = addValidation;
            this._updateValidation = updateValidation;
        }

        public async Task<AddResponse> Add(User user)
        {
            _addValidation.Validate(user);

            if (_addValidation.isValid)
            {
                var id = await _repository.Add(user);
                return new AddResponse(id);
            }

            return new AddResponse(_addValidation.messages);
        }

        public async Task Delete(User user)
        {
            await _repository.Delete(user);
        }

        public async Task<User> Get(int id)
        {
            return await _repository.Get(id);
        }

        public async Task<User> Get(string email)
        {
            return await _repository.Get(email);
        }

        public async Task<IEnumerable<User>> GetAll()
        {
            return await _repository.GetAll();
        }

        public async Task<UpdateResponse> Update(User user)
        {
            _updateValidation.Validate(user);

            if (_updateValidation.isValid)
            {
                await _repository.Update(user);
            }

            return new UpdateResponse(_updateValidation.messages);
        }
    }
}
