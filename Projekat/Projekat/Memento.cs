using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekat
{
    public class Memento
    {

        private List<Snapshot> lista_stanja = null;
        private int trenutno_stanje;

        public Memento()
        {
            lista_stanja = new List<Snapshot>();
            trenutno_stanje = 0;
        }

        public void dodajStanje(Stanje s)
        {
            lista_stanja.Add(s.createSnapshot());
            trenutno_stanje++;
        }

        public Snapshot dajPrethodnoStanje()
        {
            if (trenutno_stanje > 0)
            {
                return lista_stanja[--trenutno_stanje];   //obrisi
            }
            return null;
        }

        public Snapshot dajNarednoStanje()
        {
            if (trenutno_stanje < lista_stanja.Count())
            {
                return lista_stanja[trenutno_stanje++];
            }
            return null;
        }

    }
}
