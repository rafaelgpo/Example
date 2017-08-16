using Dapper;
using Dapper.Contrib.Extensions;
using Example.Domain.Model;
using Example.Domain.Repository.Interface;
using Example.Repository.UoW.Interface;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace Example.Repository
{
    public class UserRepository : BaseRepository, IUserRepository
    {
        public async Task<int> Add(User user)
        {
            return await _connection.InsertAsync(user, base._transaction);
        }

        public async Task Delete(User user)
        {
            await _connection.DeleteAsync(user, base._transaction);
        }

        public async Task<User> Get(int id)
        {
            return await _connection.GetAsync<User>(id, base._transaction);
        }

        public async Task<User> Get(string email)
        {
            return await _connection.QuerySingleOrDefaultAsync<User>("SELECT * FROM Users WHERE Email = @email And Active = @active", new {email = email, active = true }, base._transaction);
        }

        public async Task<IEnumerable<User>> GetAll()
        {
            return await _connection.GetAllAsync<User>(base._transaction);
        }

        public async Task Update(User user)
        {
            await _connection.UpdateAsync(user, base._transaction);
        }
    }
}
