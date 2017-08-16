using Example.Domain.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Example.Repository.UoW.Interface
{
    public interface IUnitOfWork<T> : IBaseRepository
    {
        T repository { get;}
    }
}
