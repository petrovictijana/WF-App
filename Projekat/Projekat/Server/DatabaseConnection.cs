using Projekat.Server.FactoryPattern;
using Projekat.Server.Models;
using System;
using System.Data.Common;
using System.Data.Entity;
using System.Data.SQLite;
using System.Linq;

namespace Projekat.Server
{
    public class DatabaseConnection : DbContext
    {
        private static string _connectionString;
        private static DbConnection _connection;

        /*public DbSet<Klijent> Klijenti { get; set; }
        public DbSet<Paket> Paketi { get; set; }
        public DbSet<Pretplate> Pretplate { get; set; }
        public DbSet<TipPaketa> TipPaketa { get; set; }*/

        private DatabaseConnection() { }

        public static DbConnection GetDbConnection(string connectionString)
        {
            if (_connectionString == null)
                _connectionString = connectionString;

            if (_connection == null)
            {
                IDbConnectionFactory connectionFactory = DbFactoryProcess.getConnectionFactory(connectionString);
                _connection = connectionFactory.createConnection(connectionString);

                _connection.Open();

                //Popunjavanje baze podataka (kreiranje tabela i popunjavanje podacima) 
                createTablesAndFillData();
            }

            return _connection;
        }

        public static void closeConnection()
        {
            _connection.Close();
        }

        private static void createTablesAndFillData()
        {
            using (var command = _connection.CreateCommand())
            {
                command.CommandText = @"
                    DROP TABLE IF EXISTS `clients`;
CREATE TABLE IF NOT EXISTS `clients` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `firstname` text NOT NULL,
  `surname` text NOT NULL,
  `username` text NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=utf8mb4;

INSERT INTO `clients` (`id`, `firstname`, `surname`, `username`) VALUES
(1, 'Tijana', 'Petrovic', 'tijana.petrovic'),
(2, 'Miljana', 'Bjelic', 'miljana.bjelic'),
(3, 'Aleksandra', 'Stanic', 'aleksandra.stanic'),
(4, 'Filip', 'Boskovic', 'filip.boskovic'),
(5, 'Mikica', 'Popovic', 'mikica.popovic');";

                command.ExecuteNonQuery();

                command.CommandText = @"
                    DROP TABLE IF EXISTS `package`;
CREATE TABLE IF NOT EXISTS `package` (
  `id_package` int(11) NOT NULL AUTO_INCREMENT,
  `name` text NOT NULL,
  `price` int(11) NOT NULL,
  `channel_number` int(11) NOT NULL,
  `amount_of_internet` int(11) NOT NULL,
  `id_package_type` int(11) NOT NULL,
  PRIMARY KEY (`id_package`)
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=utf8mb4;

INSERT INTO `package` (`id_package`, `name`, `price`, `channel_number`, `amount_of_internet`, `id_package_type`) VALUES
(1, 'EON_TV', 2000, 1000, 300, 1),
(2, 'NET_6', 1500, 0, 200, 2),
(3, 'BOX_TV', 2000, 1000, 300, 1), 
(4, 'KOMBO_200', 2400, 200, 200, 3);

                    ";

                command.ExecuteNonQuery();

                command.CommandText = @"
                    DROP TABLE IF EXISTS `package_type`;
                    CREATE TABLE IF NOT EXISTS `package_type` (
                      `id_package_type` int(11) NOT NULL AUTO_INCREMENT,
                      `name` text NOT NULL,
                      PRIMARY KEY (`id_package_type`)
                    ) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=utf8mb4;


                    INSERT INTO `package_type` (`name`) VALUES
                    ('tv_paket'),
                    ('internet_paket'),
                    ('kombinovani_paket');";

                command.ExecuteNonQuery();

                command.CommandText = @"
DROP TABLE IF EXISTS `subscription`;
                    CREATE TABLE IF NOT EXISTS `subscription` (
                    `id_client` int(11) NOT NULL,
                    `id_package` int(11) NOT NULL
                    ) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;
                    
                    INSERT INTO `subscription` (`id_client`, `id_package`) VALUES
                    (1, 1),
                    (1, 2),
                    (2, 1);";
                command.ExecuteNonQuery();

                Console.WriteLine("Tables created successfully.");
            }
        }

    }
}
