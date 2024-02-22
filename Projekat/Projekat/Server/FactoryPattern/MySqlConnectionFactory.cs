using System.Data.Common;
using MySql.Data.MySqlClient;

namespace Projekat.Server.FactoryPattern
{
    public class MySqlConnectionFactory : IDbConnectionFactory
    {
        public DbConnection createConnection(string connectionString)
        {
            return new MySqlConnection(connectionString);
        }
    }
}
