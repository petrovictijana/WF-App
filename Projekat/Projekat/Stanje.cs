using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekat
{
    public class Stanje
    {
        string username;

        public string Username { get => username; set => username = value; }

        public Snapshot createSnapshot()
        {
            return new Snapshot(username, this);
        }
    }
}
