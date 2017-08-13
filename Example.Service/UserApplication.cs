using Example.Application.Interface;
using Example.Application.ViewModel;
using System.Collections.Generic;
using AutoMapper;
using Example.Domain.Model;
using Example.Domain.Service.Interface;
using System.Threading.Tasks;
using Example.Domain.Response;

namespace Example.Application
{
    public class UserApplication : IUserApplication
    {
        private readonly IUserService _service;

        public UserApplication(IUserService service)
        {
            this._service = service;
        }

        public async Task<Response<int?>> Add(UserViewModel user)
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

        public async Task<Response<UserViewModel>> GetGeneric(int id)
        {
            return Mapper.Map<Response<User>, Response<UserViewModel>>(await _service.GetGeneric(id));
        }

        public async Task<IEnumerable<UserViewModel>> GetAll()
        {
            return Mapper.Map<IEnumerable<User>, IEnumerable<UserViewModel>>(await _service.GetAll());
        }

        public async Task Update(UserViewModel user)
        {
            await _service.Update(Mapper.Map<UserViewModel, User>(user));
        }
    }
}
