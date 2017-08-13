using Example.Application.ViewModel;
using Example.Domain.Response;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Example.Application.Interface
{
    public interface IUserApplication
    {
        Task<Response<int?>> Add(UserViewModel user);
        Task Delete(int id);
        Task<UserViewModel> Get(int id);
        Task Update(UserViewModel user);
        Task<IEnumerable<UserViewModel>> GetAll();
        Task<Response<UserViewModel>> GetGeneric(int id);
    }
}
