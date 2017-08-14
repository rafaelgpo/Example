using Example.Domain.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Example.Domain.Validation.Interface
{
    public interface IUserValidation
    {
        bool IsValidForAdd(User user);
        bool IsValidForUpdate(User user);
        bool IsValidForGet(User user);
        bool Exists(User user);
    }
}
