using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekat.Server.Models
{
    public interface IKlijentBuilder
    {
        IKlijentBuilder SetUsername(string username);
        IKlijentBuilder SetIme(string ime);
        IKlijentBuilder SetPrezime(string prezime);
        IKlijentBuilder SetId(int id);
        Klijent Build();
    }
}
