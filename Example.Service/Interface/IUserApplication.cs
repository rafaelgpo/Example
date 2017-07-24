using Example.Application.ViewModel;
using Example.Domain.Messaging;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Example.Application.Interface
{
    public interface IUserApplication
    {
        Task<AddResponse> Add(UserViewModel user);
        Task Delete(int id);
        Task<UserViewModel> Get(int id);
        Task<UpdateResponse> Update(UserViewModel user);
        Task<IEnumerable<UserViewModel>> GetAll();
    }
}
