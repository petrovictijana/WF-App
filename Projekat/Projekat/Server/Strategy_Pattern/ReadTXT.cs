using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekat.Server.Strategy_Pattern
{
    public class ReadTXT : IStrategy
    {
        public string provider;
        public string connString;
        public void execute()
        {
            try
            {
                string[] linije = File.ReadAllLines("C:\\Users\\hp\\Desktop\\DS projekat\\tim-12\\Projekat\\Projekat\\Server\\Strategy_Pattern\\config.txt");

                this.provider = linije[0];
                this.connString = linije[1];

                Console.WriteLine("Ucitan konekcioni string: " + provider);
                Console.WriteLine("Ucitan konekcioni string: " + connString);
            }
            catch (IOException e)
            {
                Console.WriteLine("Došlo je do greške prilikom čitanja fajla: " + e.Message);
            }
        }
    }
}
