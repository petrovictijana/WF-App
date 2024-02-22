using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekat.Server.Models
{
    public class PaketBuilder : IPaketBuilder
    {
        private int id;
        private string naziv;
        private int cena;
        private int brojKanala;
        private int brzinaInterneta;
        private int idTipaPaketa;

        public IPaketBuilder SetId(int id)
        {
            this.id = id;
            return this;
        }

        public IPaketBuilder SetNaziv(string naziv)
        {
            this.naziv = naziv;
            return this;
        }

        public IPaketBuilder SetCena(int cena)
        {
            this.cena = cena;
            return this;
        }

        public IPaketBuilder SetBrojKanala(int brojKanala)
        {
            this.brojKanala = brojKanala;
            return this;
        }

        public IPaketBuilder SetBrzinaInterneta(int brzinaInterneta)
        {
            this.brzinaInterneta = brzinaInterneta;
            return this;
        }

        public IPaketBuilder SetNazivTipa(int idTipaPaketa)
        {
            this.idTipaPaketa = idTipaPaketa;
            return this;
        }

        public Paket Build()
        {
            return new Paket(id, naziv, cena, brojKanala, brzinaInterneta, idTipaPaketa);
        }

        public IPaketBuilder SetTipId(int tipId)
        {
            this.idTipaPaketa = tipId; return this;
        }
    }
}
