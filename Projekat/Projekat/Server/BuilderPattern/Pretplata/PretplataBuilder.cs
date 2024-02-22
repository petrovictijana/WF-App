using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekat.Server.Models
{
    public class PretplataBuilder : IPretplataBuilder
    {
        private int iznos;

        public IPretplataBuilder SetIznos(int iznos)
        {
            this.iznos = iznos;
            return this;
        }

        public Pretplata Build()
        {
            return new Pretplata(iznos);
        }
    }
}
