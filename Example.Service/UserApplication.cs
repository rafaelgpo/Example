using Example.Application.Interface;
using Example.Application.ViewModel;
using System.Collections.Generic;
using AutoMapper;
using Example.Domain.Model;
using System.Threading.Tasks;
using Example.Domain.Repository.Interface;
using System;
using Example.Domain.Validation.Interface;

namespace Example.Application
{
    public class UserApplication : IUserApplication
    {
        private readonly IUserValidation _userValidation;
        private readonly IUserRepository _repository;

        public UserApplication(IUserValidation validation, IUserRepository repository) 
        {
            this._userValidation = validation;
            this._repository = repository;
        }

        public async Task<Guid> Add(UserViewModel userViewModel)
        {
            var user = Mapper.Map<UserViewModel, User>(userViewModel);

            if (_userValidation.IsValidForAdd(user))
                await _repository.Add(user);

            await _repository.SaveChanges();

            return user.Id;
        }

        public async Task Delete(Guid id)
        {
            var user = await _repository.GetById(id);

            if (_userValidation.Exists(user))
            {
                _repository.Remove(id);
                await _repository.SaveChanges();
            }
        }

        public async Task<UserViewModel> Get(Guid id)
        {
            var user = await _repository.GetById(id);

            if (_userValidation.Exists(user))
                return Mapper.Map<User, UserViewModel>(user);

            return null;
        }

        public async Task<IEnumerable<UserViewModel>> GetAll()
        {
            var users = await _repository.GetAll();
            return Mapper.Map<IEnumerable<User>, IEnumerable<UserViewModel>>(users);
        }

        public async Task Update(UserViewModel userViewModel)
        {
            var user = Mapper.Map<UserViewModel, User>(userViewModel);
            var userOld = await _repository.GetById(user.Id);

            if (_userValidation.Exists(userOld) && _userValidation.IsValidForUpdate(user))
            {
                _repository.Update(user);
                await _repository.SaveChanges();
            }
        }
    }
}
