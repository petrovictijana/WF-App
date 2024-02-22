using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekat.Server.Models
{
    public class Klijent
    {
        [Key]
        public int Id { get; set; }
        public string Username { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        

        public Klijent(string username, string ime, string prezime, int id)
        {
            Username = username;
            Ime = ime;
            Prezime = prezime;
            Id = id;
        }
    }
}
