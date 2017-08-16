using Example.Repository.UoW.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace Example.Repository.UoW
{
    public class UserUoW : UnitOfWork<UserRepository>, IUserUoW
    {
    }
}
