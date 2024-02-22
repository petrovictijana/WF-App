using Projekat.Server;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Common;
using MySqlX.XDevAPI;
using Projekat.Server.Models;
using Projekat.Server.ProxyPattern;
using Projekat.Server.Strategy_Pattern;

//using Projekat.s;

namespace Projekat
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            //DbConnection connection = DatabaseConnection.GetDbConnection("Server=localhost;Database=dizajniranje_softvera;User ID=root;Password=;");

            ReadTXT readTXT = new ReadTXT();
            Context context = new Context(readTXT);
            context.ExecuteStrategy();

            UseDB useDB = new UseDB(readTXT.connString);
            context.SetStrategy(useDB);
            context.ExecuteStrategy();

            DbConnection connection = UseDB.connection;

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Paketi_pocetna(connection, readTXT.provider));


            connection.Close();
        }
       
    }
}
