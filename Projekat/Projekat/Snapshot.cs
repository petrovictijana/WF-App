using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekat
{
    public class Snapshot
    {
        string username;
        Stanje stanje;
        public string Username { get => username; set => username = value; }

        public Snapshot(string username, Stanje stanje)
        {
            this.username = username;
            this.stanje = stanje;
        }
    }
}
