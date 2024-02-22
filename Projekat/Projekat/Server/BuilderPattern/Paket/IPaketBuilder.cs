using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekat.Server.Models
{
    public interface IPaketBuilder
    {
        IPaketBuilder SetId(int id);
        IPaketBuilder SetNaziv(string naziv);
        IPaketBuilder SetCena(int cena);
        IPaketBuilder SetBrojKanala(int brojKanala);
        IPaketBuilder SetBrzinaInterneta(int brzinaInterneta);
        IPaketBuilder SetTipId(int tipId);
        Paket Build();
    }
}
