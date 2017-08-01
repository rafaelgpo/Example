using Example.Domain.Model;
using Example.Domain.Validation.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace Example.Domain.Validation.Interface
{
    public interface IUserUpdateValidation : IEntityValidation<User>
    {
        
    }
}
