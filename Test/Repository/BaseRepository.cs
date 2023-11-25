using System;
using System.Data;
using System.Linq;
using System.Data.SqlClient;
using System.Threading.Tasks;

using Dapper;
using Microsoft.Extensions.Configuration;

namespace Test.Repository
{
    public interface IBaseRepository
    {
        void SEventdentity<T>(IDbConnection connection, Action<T> sEventd);
        IDbConnection CreateConnection();
        Task SetConnectionString(string resolvedConnectionString);
    }
     
    public class BaseRepository : IBaseRepository
    {
        private string connectionString;

        public async Task SetConnectionString(string resolvedConnectionString)
        {
            await Task.Run(() => {
                connectionString = resolvedConnectionString;
            });
        }
        public BaseRepository(IConfiguration configuration)
        {
            connectionString = configuration.GetValue<string>("EventConnectionString");
        }
        public void SEventdentity<T>(IDbConnection connection, Action<T> sEventd)
        {
            dynamic identity = connection.Query("SELECT @@IDENTITY AS Id").Single();
            T newId = (T)identity.Id;
            sEventd(newId);
        }

        public virtual IDbConnection CreateConnection()
        {
            return new SqlConnection(connectionString);
        }
    }
}