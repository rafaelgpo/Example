using Example.Domain.Model;
using Example.Domain.Repository.Interface;
using Example.Repository.Context;

namespace Example.Repository
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        public UserRepository(ExampleContext context) : base(context)
        {
        }
    }
}
