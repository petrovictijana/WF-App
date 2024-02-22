using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekat.Server.Models
{
    public class Pretplata
    {
        public int Iznos { get; }

        public Pretplata(int iznos)
        {
            Iznos = iznos;
        }
    }
}
