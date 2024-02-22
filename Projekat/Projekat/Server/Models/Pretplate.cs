using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekat.Server.Models
{
    public class Pretplate
    {
        [Required]
        public int clientId { get; set; }
        [ForeignKey("clientId")]
        Klijent client { get; set; }
        [Required]
        public int packageId {  get; set; }
        [ForeignKey("packageId")]
        Paket package { get; set; }

        public Pretplate(int clientId, int packageId)
        {
            this.clientId = clientId;
            this.packageId = packageId;
        }
    }
}
