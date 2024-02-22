using System.Data.Common;
using System.Data.SQLite;

namespace Projekat.Server.FactoryPattern
{
    public class SqliteConnectionFactory : IDbConnectionFactory
    {
        public DbConnection createConnection(string connectionString)
        {
            return new SQLiteConnection(connectionString);
        }
    }
}
