using Example.Application.Interface;
using Example.Application.ViewModel;
using System.Collections.Generic;
using AutoMapper;
using Example.Domain.Model;
using Example.Domain.Service.Interface;
using System.Threading.Tasks;
using Example.Domain.Messaging;
using System;

namespace Example.Application
{
    public class UserApplication : IUserApplication
    {
        private readonly IUserService _service;

        public UserApplication(IUserService service)
        {
            this._service = service;
        }

        public async Task<AddResponse> Add(UserViewModel user)
        {
            return await _service.Add(Mapper.Map<UserViewModel, User>(user));
        }

        public async Task Delete(int id)
        {
            await _service.Delete(id);
        }

        public async Task<UserViewModel> Get(int id)
        {
            return Mapper.Map<User, UserViewModel>(await _service.Get(id));
        }

        public async Task<IEnumerable<UserViewModel>> GetAll()
        {
            return Mapper.Map<IEnumerable<User>, IEnumerable<UserViewModel>>(await _service.GetAll());
        }

        public async Task<UpdateResponse> Update(UserViewModel user)
        {
            return await _service.Update(Mapper.Map<UserViewModel, User>(user));
        }
    }
}
