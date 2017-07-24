using Example.Domain.Messaging;
using Example.Domain.Model;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Example.Domain.Service.Interface
{
    public interface IUserService 
    {
        Task<AddResponse> Add(User user);
        Task Delete(int user);
        Task<User> Get(int id);
        Task<User> Get(string email);
        Task<UpdateResponse> Update(User user);
        Task<IEnumerable<User>> GetAll();
    }
}
