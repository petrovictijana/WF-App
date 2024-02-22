using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekat.Server.Models
{
    public interface IPretplataBuilder
    {
        IPretplataBuilder SetIznos(int iznos);
        Pretplata Build();
    }
}
