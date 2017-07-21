using Example.Domain.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Example.Domain.Repository.Interface
{
    public interface IUserRepository 
    {
        Task<int> Add(User user);
        Task Delete(User id);
        Task<User> Get(int id);
        Task<User> Get(string email);
        Task Update(User user);
        Task<IEnumerable<User>> GetAll();
    }
}
