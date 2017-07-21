using Dapper;
using Dapper.Contrib.Extensions;
using Example.Domain.Model;
using Example.Domain.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Example.Repository
{
    public class UserRepository : BaseRepository, IUserRepository
    {

        public async Task<int> Add(User user)
        {
            using (var connection = GetOpenConnection())
            {
                return await connection.InsertAsync(user);
            }
        }

        public async Task Delete(User user)
        {
            using (var connection = GetOpenConnection())
            {
                await connection.DeleteAsync(user);
            }
        }

        public async Task<User> Get(int id)
        {
            using (var connection = GetOpenConnection())
            {
                return await connection.GetAsync<User>(id);
            }
        }

        public async Task<User> Get(string email)
        {
            using (var connection = GetOpenConnection())
            {
                return await connection.QuerySingleOrDefaultAsync<User>("SELECT * FROM Users WHERE Email = @email And Active = @active", new {email = email, active = true });
            }
        }

        public async Task<IEnumerable<User>> GetAll()
        {
            using (var connection = GetOpenConnection())
            {
                return await connection.GetAllAsync<User>();
            }
        }

        public async Task Update(User user)
        {
            using (var connection = GetOpenConnection())
            {
                await connection.UpdateAsync(user);
            }
        }
    }
}
