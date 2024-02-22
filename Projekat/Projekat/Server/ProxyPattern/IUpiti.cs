using Projekat.Server.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekat.Server.ProxyPattern
{
    public interface IUpiti
    {
        List<Klijent> getAllClients();
        List<Paket> getAllPackages();
        void addNewClient(Klijent novKlijent);
        void addNewPackage(Paket package);
        Paket getPackageByPackageId(int paketId);
        int UkupanIznosPretplateKorisnika(int klijentId);
        int DajIdTipa(string naziv);
        void dodajPretplatu(int id_klijenta, int id_paketa);
        void obrisiPaket(int id_paketa);
        void izbacivanjePretplate(int id_klijenta, int id_paketa);
        TipPaketa getPackageTypeById(int id);
        Klijent getClientByUsername(string clientUsername);
        List<Paket> getSubscribedPackagesByClientId(int klijentId);

    }
}
