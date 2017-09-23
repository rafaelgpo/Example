using Example.Application.ViewModel;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Example.Application.Interface
{
    public interface IUserApplication
    {
        Task<Guid> Add(UserViewModel user);
        Task Delete(Guid id);
        Task<UserViewModel> Get(Guid id);
        Task Update(UserViewModel user);
        Task<IEnumerable<UserViewModel>> GetAll();
    }
}
