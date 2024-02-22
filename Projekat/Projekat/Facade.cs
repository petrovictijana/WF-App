using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Projekat.Server;
using Projekat.Server.Models;
using Projekat.Server.ProxyPattern;
using Projekat.Server.ObserverPattern;

namespace Projekat
{
    class Facade
    {
        IObserver observer;

        IUpiti svi_upiti;
        public Facade(DbConnection connection, IObserver observer)
        {
            svi_upiti = new UpitiProxy(connection);
            this.observer = observer;
        }

        public void AddNewUser(string username, string firstname, string surname)
        {
            Klijent k = new KlijentBuilder().SetIme(firstname).SetPrezime(surname).SetUsername(username).Build();
            svi_upiti.addNewClient(k);

            observer.UpdateUserView();
            
        }
        public void AddNewPackage(string name, int price, int type, int internet_speed, int channel_count)
        {
            Paket p = new PaketBuilder().SetNaziv(name).SetCena(price).SetTipId(type).SetBrzinaInterneta(internet_speed).SetBrojKanala(channel_count).Build();
            svi_upiti.addNewPackage(p);

            observer.UpdatePackagesView();
        }

        public List<Paket> getAllPackagesByTypeId(int type_id)
        {
            List<Paket> svi_paketi = svi_upiti.getAllPackages();
            List<Paket> svi_paketi_filtrirani = new List<Paket>();
            foreach (Paket paket in  svi_paketi)
            {
                if(paket.PackageTypeId == type_id)
                {
                    svi_paketi_filtrirani.Add(paket);
                }
            }
            return svi_paketi_filtrirani;
        }

        public List<Klijent> getAllClients()
        {
            List<Klijent> svi_klijenti = svi_upiti.getAllClients();

            return svi_klijenti;
        }

        public void deletePackageById(int packageId)
        {
            svi_upiti.obrisiPaket(packageId);

            observer.UpdatePackagesView();
            
        }

        public Klijent getClientByUsername(string clientUsername)
        {
            return svi_upiti.getClientByUsername(clientUsername);
        }

        public List<Paket> getSubscribedPackagesByClientId(Klijent klijent)
        {
            return svi_upiti.getSubscribedPackagesByClientId(klijent.Id);
        }

        public int getPackagePriceAmount(string clientUsername)
        {
            Klijent klijent = svi_upiti.getClientByUsername(clientUsername);
            return svi_upiti.UkupanIznosPretplateKorisnika(klijent.Id);
        }

        public void addNewSubscription(string clientUsername, int id_paketa)
        {
            Klijent klijent = svi_upiti.getClientByUsername(clientUsername);
            svi_upiti.dodajPretplatu(klijent.Id, id_paketa);

            observer.updateSubscribersView();
            observer.updateTotalPrice();
        }

        public void deleteSubscription(string clientUsername, int id_paketa)
        {
            Klijent klijent = svi_upiti.getClientByUsername(clientUsername);
            svi_upiti.izbacivanjePretplate(klijent.Id, id_paketa);

            observer.updateSubscribersView();
            observer.updateTotalPrice();
        }

    }
}
