using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekat.Server.Models
{
    public class KlijentBuilder : IKlijentBuilder
    {
        private string username;
        private string ime;
        private string prezime;
        private int id;

        public IKlijentBuilder SetUsername(string username)
        {
            this.username = username;
            return this;
        }

        public IKlijentBuilder SetIme(string ime)
        {
            this.ime = ime;
            return this;
        }

        public IKlijentBuilder SetPrezime(string prezime)
        {
            this.prezime = prezime;
            return this;
        }

        public IKlijentBuilder SetId(int id)
        {
            this.id = id;
            return this;
        }

        public Klijent Build()
        {
            return new Klijent(username, ime, prezime, id);
        }
    }
}
