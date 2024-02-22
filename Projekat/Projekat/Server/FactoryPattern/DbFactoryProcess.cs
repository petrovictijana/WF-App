using System;

namespace Projekat.Server.FactoryPattern
{
    public class DbFactoryProcess
    {
        public static IDbConnectionFactory getConnectionFactory(string connectionString)
        {
            if (connectionString.ToUpper().Contains("SERVER"))
                return new MySqlConnectionFactory();
            else if (connectionString.ToUpper().Contains("SQLITE"))
                return new SqliteConnectionFactory();
            else
                throw new NotSupportedException("Nije podrzan ovaj tip baze!");
        }
    }
}
