using Example.Domain.Repository.Interface;
using Example.Repository.UoW.Interface;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace Example.Repository.UoW
{

    public class UnitOfWork<T> : BaseRepository, IUnitOfWork<T> where T:BaseRepository, new()
    {
        public T repository { get;}

        public UnitOfWork()
        {
            this.repository = new T();
        }

        public new void Begin()
        {
            base.Begin();
            repository._transaction = base._transaction;
        }
    }
}
