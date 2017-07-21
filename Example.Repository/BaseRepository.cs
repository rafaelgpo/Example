using System;
using System.Data;
using System.Data.SqlClient;

namespace Example.Repository
{
    public abstract class BaseRepository
    {
        public static string ConnectionString = "Data Source=localhost;Initial Catalog=example;Integrated Security=SSPI;";

        protected IDbConnection _connection;
        protected IDbConnection connection => _connection ?? (_connection = GetOpenConnection());

        public static IDbConnection GetOpenConnection(bool mars = false)
        {
            var cs = ConnectionString;
            if (mars)
            {
                var scsb = new SqlConnectionStringBuilder(cs)
                {
                    MultipleActiveResultSets = true
                };
                cs = scsb.ConnectionString;
            }
            var connection = new SqlConnection(cs);
            connection.Open();
            return connection;
        }

        public SqlConnection GetClosedConnection()
        {
            var conn = new SqlConnection(ConnectionString);
            if (conn.State != ConnectionState.Closed) throw new InvalidOperationException("should be closed!");
            return conn;
        }



        public void Dispose()
        {
            _connection?.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
