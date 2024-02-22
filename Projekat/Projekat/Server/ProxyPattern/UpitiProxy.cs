using Projekat.Server.Models;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekat.Server.ProxyPattern
{
    public class UpitiProxy : IUpiti
    {
        //real object
        Upiti upiti = null;

        //cached objects
        static List<Klijent> clients = new List<Klijent>();
        static List<Paket> packages = new List<Paket>();

        public UpitiProxy(DbConnection connection) {
            upiti = new Upiti(connection);

            clients = null;
            packages = null;
        }

        public List<Klijent> getAllClients()
        {
            //Ukoliko nista nije kesirano pozovi pravi objekat
            if(clients == null)
                clients = upiti.getAllClients();

            return clients;
        }

        public List<Paket> getAllPackages()
        {
            if(packages == null)
                packages = upiti.getAllPackages();

            return packages;
        }

        public void addNewClient(Klijent novKlijent)
        {
            clients = null;
            upiti.addNewClient(novKlijent);
        }

        public void addNewPackage(Paket package)
        {
            packages = null;
            upiti.addNewPackage(package);
        }

        public Paket getPackageByPackageId(int paketId)
        {
            return upiti.getPackageByPackageId(paketId);
        }

        public int UkupanIznosPretplateKorisnika(int klijentId)
        {
            return upiti.UkupanIznosPretplateKorisnika(klijentId);
        }

        public int DajIdTipa(string naziv)
        {
            return upiti.DajIdTipa(naziv);
        }

        public void dodajPretplatu(int id_klijenta, int id_paketa)
        {
            upiti.dodajPretplatu(id_klijenta, id_paketa);
        }

        public void obrisiPaket(int id_paketa)
        {
            packages = null;
            upiti.obrisiPaket(id_paketa);
        }

        public void izbacivanjePretplate(int id_klijenta, int id_paketa)
        {
            upiti.izbacivanjePretplate(id_klijenta, id_paketa);
        }

        public TipPaketa getPackageTypeById(int id)
        {
            return upiti.getPackageTypeById(id);
        }

        public Klijent getClientByUsername(string clientUsername)
        {
            return upiti.getClientByUsername(clientUsername);
        }

        public List<Paket> getSubscribedPackagesByClientId(int clientId)
        {
            return upiti.getSubscribedPackagesByClientId(clientId);
        }

    }
}
