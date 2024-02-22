using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Projekat.Server;
using System.Data.Common;

namespace Projekat.Server.Strategy_Pattern
{
    
    public class UseDB : IStrategy
    {
        public static DbConnection connection;
        string connectionString;

        public UseDB(string connectionString) 
        {
            this.connectionString = connectionString;
        }

        public void execute()
        {
            connection = DatabaseConnection.GetDbConnection(connectionString);
        }
    }
}
