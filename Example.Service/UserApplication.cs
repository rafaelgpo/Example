using Example.Application.Interface;
using Example.Application.ViewModel;
using System.Collections.Generic;
using AutoMapper;
using Example.Domain.Model;
using Example.Domain.Service.Interface;
using System.Threading.Tasks;
using Example.Domain.Repository.Interface;
using Example.Repository.UoW;
using Example.Repository.UoW.Interface;
using System;
using Example.Domain.Validation.Interface;

namespace Example.Application
{
    public class UserApplication : IUserApplication
    {
        private readonly IUserUoW _uow;
        private readonly IUserValidation _userValidation;
        private readonly IUserRepository _repository;


        public UserApplication(IUserUoW uow, IUserValidation validation, IUserRepository repository) 
        {
            this._userValidation = validation;
            this._repository = repository;
            this._uow = uow;
        }

        public async Task<int?> Add(UserViewModel userViewModel)
        {
            var user = Mapper.Map<UserViewModel, User>(userViewModel);

            if (_userValidation.IsValidForAdd(user))
                return await _repository.Add(user);

            return null;
        }

        public async Task Delete(int id)
        {
            var user = await _repository.Get(id);

            if (_userValidation.Exists(user))
                await _repository.Delete(user);
        }

        public async Task<UserViewModel> Get(int id)
        {
            var user = await _repository.Get(id);

            if (_userValidation.Exists(user))
                return Mapper.Map<User, UserViewModel>(user);

            return null;
        }

        public async Task<UserViewModel> Get(string email)
        {
            var user = await _repository.Get(email);

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
            var userOld = await _repository.Get(user.Id);

            if (_userValidation.Exists(userOld) && _userValidation.IsValidForUpdate(user))
                await _repository.Update(user);
        }

        public async Task Copy(string oldEmail, string newEmail)
        {
            //UnitOfWork flow test

            _uow.Begin();

            var user = await _uow.repository.Get(oldEmail);

            var id = await _uow.repository.Add(user);

            user.Id = id;
            user.Email = newEmail;

            await _uow.repository.Update(user);

            _uow.Commit();
        }
    }
}
