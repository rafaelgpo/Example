using System;
using System.Data;
using System.Data.SqlClient;

namespace Example.Repository
{
    public abstract class BaseRepository : IBaseRepository
    {
        private static string ConnectionString = "Data Source=localhost;Initial Catalog=example;Integrated Security=SSPI;";

        protected IDbConnection _connection { get { return GetOpenConnection(); } }
        public IDbTransaction _transaction { get; set; }

        public void Begin()
        {
            var transaction = _connection.BeginTransaction();
            _transaction = transaction;
        }

        public void Rollback()
        {
            _transaction.Rollback();
            Dispose();
        }

        public void Commit()
        {
            try
            {
               _transaction.Commit();
            }
            catch
            {
                _transaction.Rollback();
                throw;
            }
            finally
            {
                Dispose();
            }
        }

        private IDbConnection GetOpenConnection()
        {
            if(_transaction == null)
            {
                var connection = new SqlConnection(ConnectionString);
                connection.Open();
                return connection;
            }
            else
            {
                return _transaction.Connection;
            }
        }

        private void Dispose()
        {
            _transaction = null;
            _transaction?.Dispose();
            _connection.Close();
            _connection?.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
