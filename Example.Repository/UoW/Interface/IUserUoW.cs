using System;
using System.Collections.Generic;
using System.Text;

namespace Example.Repository.UoW.Interface
{
    public interface IUserUoW : IUnitOfWork<UserRepository>
    {
    }
}
