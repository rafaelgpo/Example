using System.Data;

namespace Example.Repository
{
    public interface IBaseRepository
    {
        //IDbTransaction _transaction { get; set; }
        void Begin();
        void Commit();
        void Rollback();
    }
}