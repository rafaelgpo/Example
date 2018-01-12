using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Example.Domain.Repository.Interface
{
    public interface IBaseRepository<TEntity> : IDisposable where TEntity : class
    {
        Task Add(TEntity obj);
        Task<TEntity> GetById(Guid id);
        Task<List<TEntity>> GetAll();
        void Update(TEntity obj);
        Task Remove(Guid id);
        Task<int> Commit();
    }
}