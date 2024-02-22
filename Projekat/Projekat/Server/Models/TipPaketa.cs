using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekat.Server.Models
{
    public class TipPaketa
    {
        [Key]
        public int id_tipa_paketa { get; set; }
        public string naziv { get; set; }

        public TipPaketa(int id_tipa_paketa, string naziv)
        {
            this.id_tipa_paketa = id_tipa_paketa;
            this.naziv = naziv;
        }
    }
}
