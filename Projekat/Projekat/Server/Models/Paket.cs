using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Projekat.Server.Models
{
    public class Paket
    {
        [Key]
        public int Id { get; }
        public string Naziv { get; }
        public int Cena { get; }
        public int BrojKanala { get; }
        public int BrzinaInterneta { get; }
        public int PackageTypeId { get; set; }

        [ForeignKey("PackageTypeId")]
        public TipPaketa TipPaketa { get; }

        public Paket(int id, string naziv, int cena, int brojKanala, int brzinaInterneta, int packageTypeId)
        {
            Id = id;
            Naziv = naziv;
            Cena = cena;
            BrojKanala = brojKanala;
            BrzinaInterneta = brzinaInterneta;
            PackageTypeId = packageTypeId;
        }
    }
}
