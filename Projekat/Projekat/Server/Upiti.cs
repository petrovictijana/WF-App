using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using MySqlX.XDevAPI;
using MySqlX.XDevAPI.Common;
using Projekat.Server.ProxyPattern;

namespace Projekat.Server.Models
{
    public class Upiti : IUpiti
    {
        private DbConnection connection;
        public Upiti(DbConnection connection)
        {
            this.connection = connection;
        }
        public List<Klijent> getAllClients()
        {
            List<Klijent> listaKlijenata = new List<Klijent>();
            if (connection.State != ConnectionState.Open)
            {
                connection.Open();
            }
            try
            {
                if (connection.State == ConnectionState.Open)
                {
                    Console.WriteLine("Veza sa bazom podataka uspostavljena.");

                    string query = "SELECT * FROM clients";

                    using (DbCommand command = connection.CreateCommand())
                    {
                        command.CommandText = query;

                        using (DbDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Klijent klijent = new KlijentBuilder()
                                    .SetId(reader.GetInt32(0))
                                    .SetIme(reader.GetString(1))
                                    .SetPrezime(reader.GetString(2))
                                    .SetUsername(reader.GetString(3))
                                    .Build();

                                listaKlijenata.Add(klijent);
                            }

                        }
                       
                    }
                }
                else
                {
                    Console.WriteLine("Veza sa bazom podataka nije uspostavljena.");
                }
            }
            catch (DbException ex)
            {
                Console.WriteLine($"Greška prilikom komunikacije sa bazom podataka: {ex.Message}");
            }

            if (connection.State == ConnectionState.Open)
            {
                connection.Close();
            }
            return listaKlijenata;
        }

        public List<Paket> getAllPackages()
        {

            if (connection.State != ConnectionState.Open)
            {
                connection.Open();
            }
            List<Paket> packages = new List<Paket> ();

            if(connection.State == ConnectionState.Open)
            {
                string query = "SELECT * FROM package";

                using (DbCommand command = connection.CreateCommand())
                {
                    command.CommandText= query;

                    using(DbDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Paket paket = new PaketBuilder()
                                .SetId(reader.GetInt32(0))
                                .SetNaziv(reader.GetString(1))
                                .SetCena(reader.GetInt32(2))
                                .SetBrojKanala(reader.GetInt32(3))
                                .SetBrzinaInterneta(reader.GetInt32(4))
                                .SetTipId(reader.GetInt32(5))
                                .Build();

                            packages.Add(paket);
                        }

                    }
                }
            }

            if (connection.State == ConnectionState.Open)
            {
                connection.Close();
            }
            return packages;

        }

        public Paket getPackageByPackageId(int paketId)
        {
            try
            {
                if (connection.State != ConnectionState.Open)
                {
                    connection.Open();
                }

                string query = $"SELECT * FROM package " +
                                $"WHERE id_package = {paketId}";

                using (DbCommand command = connection.CreateCommand())
                {
                    command.CommandText = query;

                    using (DbDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            int id = reader.GetInt32(0);
                            string naziv = reader.GetString(1);
                            int cena = reader.GetInt32(2);
                            int brojKanala = reader.GetInt32(3);
                            int brzinaInterneta = reader.GetInt32(4);
                            int tipId = reader.GetInt32(5);

                            //TipPaketa tipPaketa = getPackageTypeById(tipId);
                            //string nazivTipa = reader.GetString(7);


                            return new PaketBuilder()
                                .SetId(id)
                                .SetNaziv(naziv)
                                .SetCena(cena)
                                .SetBrojKanala(brojKanala)
                                .SetBrzinaInterneta(brzinaInterneta)
                                .SetTipId(tipId)
                                .Build();
                        }

                    }
                }

                return null;
            }

            catch (Exception ex)
            {
                Console.WriteLine($"Greška u funkciji getPackageByPackageId: {ex.Message}");
                return null;
            }
            finally
            {
                if (connection.State == ConnectionState.Open)
                {
                    connection.Close();
                }
            }
        }

        public int UkupanIznosPretplateKorisnika(int klijentId)
        {
            try
            {
                if (connection.State != ConnectionState.Open)
                {
                    connection.Open();
                }

                string query = "SELECT * FROM clients " +
                               "INNER JOIN subscription ON clients.id = subscription.id_client " +
                               "INNER JOIN package ON subscription.id_package = package.id_package " +
                               $"WHERE clients.id = {klijentId}";

                int ukupanIznos = 0;

                using (DbCommand command = connection.CreateCommand())
                {
                    command.CommandText = query;

                    using (DbDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            ukupanIznos += new PretplataBuilder()
                                .SetIznos(reader.GetInt32(8))
                                .Build().Iznos;
                        }

                    }
                }

                return ukupanIznos;
            }
            catch (DbException ex)
            {
                Console.WriteLine($"Greška prilikom komunikacije sa bazom podataka: {ex.Message}");
                return 0;
            }
            finally
            {
                if (connection.State == ConnectionState.Open)
                {
                    connection.Close();
                }
            }
        }

        public int DajIdTipa(string naziv)
        {
            int id = 0;

            if (connection.State != ConnectionState.Open)
            {
                connection.Open();
            }

            string query = "SELECT id_package_type FROM package_type " +
                           "WHERE name = @naziv";

            using (DbCommand command = connection.CreateCommand())
            {
                command.CommandText = query;

                DbParameter parameter = command.CreateParameter();
                parameter.ParameterName = "@naziv";
                parameter.Value = naziv;
                command.Parameters.Add(parameter);

                using (DbDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        id = reader.GetInt32(0);
                    }

                }
            }

            if (connection.State == ConnectionState.Open)
            {
                connection.Close();
            }

            return id;
        }



        public void addNewClient(Klijent k )
        {
            if (connection.State != ConnectionState.Open)
            {
                connection.Open();
            }

            using (DbCommand command = connection.CreateCommand())
            {

                string query= "INSERT INTO clients (username, firstname, surname) VALUES (@Username, @Ime, @Prezime)";
                command.CommandText = query;

                DbParameter paramUsername = command.CreateParameter();
                paramUsername.ParameterName = "@Username";
                paramUsername.Value = k.Username;
                command.Parameters.Add(paramUsername);

                DbParameter paramIme = command.CreateParameter();
                paramIme.ParameterName = "@Ime";
                paramIme.Value = k.Ime;
                command.Parameters.Add(paramIme);

                DbParameter paramPrezime = command.CreateParameter();
                paramPrezime.ParameterName = "@Prezime";
                paramPrezime.Value = k.Prezime;
                command.Parameters.Add(paramPrezime);


                int dodatKorisnik = command.ExecuteNonQuery();

                if (dodatKorisnik > 0)
                {
                    Console.WriteLine("Korisnik uspješno dodan u bazu podataka.");
                }
                else
                {
                    Console.WriteLine("Došlo je do problema prilikom dodavanja korisnika u bazu podataka.");
                }
            }

            if (connection.State == ConnectionState.Open)
            {
                connection.Close();
            }

        }

        public void addNewPackage(Paket paket)
        {
            if (connection.State != ConnectionState.Open)
            {
                connection.Open();
            }

            int id_tipa_paketa = DajIdTipa(paket.Naziv);

            connection.Open();
            using (DbTransaction transaction = connection.BeginTransaction())
            {
                using (DbCommand command = connection.CreateCommand())
                {      
                    //unos u tabelu palet
                    command.Transaction = transaction;

                    string query = "INSERT INTO package (name,price,channel_number,amount_of_internet,id_package_type ) VALUES (@Name, @Cena, @Broj_kanala,@Kolicina_neta,@Tip)";

                    command.CommandText = query;

                    DbParameter paramTip = command.CreateParameter();
                    paramTip.ParameterName = "@Tip";
                    paramTip.Value = paket.PackageTypeId;
                    //paramTip.Value = id_tipa_paketa;
                    command.Parameters.Add(paramTip);

                    DbParameter paramNaziv = command.CreateParameter();
                    paramNaziv.ParameterName = "@Name";
                    paramNaziv.Value = paket.Naziv;
                    command.Parameters.Add(paramNaziv);

                    DbParameter paramCena = command.CreateParameter();
                    paramCena.ParameterName = "@Cena";
                    paramCena.Value = paket.Cena;
                    command.Parameters.Add(paramCena);

                    DbParameter paramKolicina = command.CreateParameter();
                    paramKolicina.ParameterName = "@Kolicina_neta";
                    paramKolicina.Value = paket.BrzinaInterneta;
                    command.Parameters.Add(paramKolicina);

                    DbParameter brKanala = command.CreateParameter();
                    brKanala.ParameterName = "@Broj_kanala";
                    brKanala.Value = paket.BrojKanala;
                    command.Parameters.Add(brKanala);

                    int dodatPaket = command.ExecuteNonQuery();
       

                    transaction.Commit();
                    Console.WriteLine("Podaci uspešno uneti.");
                }
            }
            if (connection.State == ConnectionState.Open)
            {
                connection.Close();
            }
        }

        public void dodajPretplatu(int id_klijenta, int id_paketa)
        {
            if (connection.State != ConnectionState.Open)
            {
                connection.Open();
            }

            using (DbCommand command = connection.CreateCommand())
            {
                string query = "INSERT INTO subscription (id_client,id_package) VALUES (@id,@id_paketa) ";

                command.CommandText = query;

                DbParameter id_korisnika=command.CreateParameter();
                id_korisnika.ParameterName = "@id";
                id_korisnika.Value = id_klijenta;
                command.Parameters.Add(id_korisnika);

                DbParameter paramIdPaketa = command.CreateParameter();
                paramIdPaketa.ParameterName = "@id_paketa";
                paramIdPaketa.Value=id_paketa;
                command.Parameters.Add(paramIdPaketa);

                int dodataPretplata = command.ExecuteNonQuery();

                if(dodataPretplata>0)
                {
                    Console.WriteLine("Pretplata uspesno dodata");
                }
                else
                {
                    Console.WriteLine("Pretplata nije dodata");
                }
            }

            if (connection.State == ConnectionState.Open)
            {
                connection.Close();
            }
        }

        public void obrisiPaket(int id_paketa)
        {
            if (connection.State != ConnectionState.Open)
            {
                connection.Open();
            }

            using (DbCommand command = connection.CreateCommand())
            {
                string query = "DELETE FROM package " +
                    $"WHERE id_package = {id_paketa}";

                command.CommandText = query;

               int brisanje= command.ExecuteNonQuery();

               if(brisanje>0)
               {
                    Console.WriteLine("Uspesno brisanje");
               }
                else Console.WriteLine("Neuspesno brisanje");
            }

            if (connection.State == ConnectionState.Open)
            {
                connection.Close();
            }
        }

        public void izbacivanjePretplate(int id_klijenta, int id_paketa)
        {
            if (connection.State != ConnectionState.Open)
            {
                connection.Open();
            }

            using (DbCommand command = connection.CreateCommand())
            {
                string query = "DELETE FROM subscription " +
                    $"WHERE id_package = {id_paketa} AND id_client = {id_klijenta}";

                command.CommandText = query;

                int brisanje = command.ExecuteNonQuery();

                if (brisanje > 0)
                {
                    Console.WriteLine("Uspesno brisanje");
                }
                else Console.WriteLine("Neuspesno brisanje");
            }

            if (connection.State == ConnectionState.Open)
            {
                connection.Close();
            }
        }

        public TipPaketa getPackageTypeById(int id)
        {
            TipPaketa tipPaketa = null;

            if (connection.State != ConnectionState.Open)
            {
                connection.Open();
            }

            using (DbCommand command = connection.CreateCommand())
            {
                string query = "SELECT * FROM package_type " +
                    $"WHERE id_package_type = {id}";

                command.CommandText = query;

                using (DbDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        // Čitanje podataka iz reda rezultata
                        int packageTypeId = reader.GetInt32(0);
                        string packageName = reader.GetString(1);

                        tipPaketa = new TipPaketa(packageTypeId, packageName);
                        
                    }

                }
            }

            if (connection.State == ConnectionState.Open)
            {
                connection.Close();
            }

            return tipPaketa;
        }

        public Klijent getClientByUsername(string clientUsername)
        {
            Klijent klijent = null;

            if (connection.State != ConnectionState.Open)
            {
                connection.Open();
            }

            using (DbCommand command = connection.CreateCommand())
            {
                string query = "SELECT * FROM clients " +
                    $"WHERE username = '{clientUsername}'";

                command.CommandText = query;

                using (DbDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        // Čitanje podataka iz reda rezultata
                        int id = reader.GetInt32(0);
                        string firstName = reader.GetString(1);
                        string lastName = reader.GetString(2);
                        string username = reader.GetString(3);

                        klijent = new KlijentBuilder()
                            .SetId(id)
                            .SetIme(firstName)
                            .SetPrezime(lastName)
                            .SetUsername(username)
                            .Build();
                    }

                }
            }

            if (connection.State == ConnectionState.Open)
            {
                connection.Close();
            }

            return klijent;
        }

        public List<Paket> getSubscribedPackagesByClientId(int klijentId)
        {

                if (connection.State != ConnectionState.Open)
                {
                    connection.Open();
                }

                string query = $"SELECT p.* FROM subscription s " +
                                $"JOIN package p ON s.id_package = p.id_package " +
                                $"WHERE s.id_client = {klijentId}";

                using (DbCommand command = connection.CreateCommand())
                {
                    command.CommandText = query;

                    List<Paket> packages = new List<Paket>();

                    using (DbDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int id = reader.GetInt32(0);
                            string naziv = reader.GetString(1);
                            int cena = reader.GetInt32(2);
                            int brojKanala = reader.GetInt32(3);
                            int brzinaInterneta = reader.GetInt32(4);
                            int tipId = reader.GetInt32(5);

                            //TipPaketa tipPaketa = getPackageTypeById(tipId);
                            //string nazivTipa = reader.GetString(7);

                            Paket paket = new PaketBuilder()
                                .SetId(id)
                                .SetNaziv(naziv)
                                .SetCena(cena)
                                .SetBrojKanala(brojKanala)
                                .SetBrzinaInterneta(brzinaInterneta)
                                .SetTipId(tipId)
                                .Build();

                            packages.Add(paket);
                        }
                    }

                    return packages;
                }


        }



        /*public List<Paket> getListOfSubscribedPackagesByClient(Klijent klijent)
        {
            if (connection.State != ConnectionState.Open)
            {
                connection.Open();
            }

            List<Paket> packages = new List<Paket>();

            try
            {
                using (DbCommand command = connection.CreateCommand())
                {
                    string query = $"SELECT * FROM subscription WHERE id_client = {klijent.Id}"; 

                    using (DbDataReader reader = command.ExecuteReader())
                    {
                       
                        while (reader.Read())
                        {
                           
                            int packageId = reader.GetInt32(1);

                            Paket paket = getPackageByPackageId(packageId);

                            packages.Add(paket);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Obrada izuzetaka
                Console.WriteLine("Greška prilikom čitanja podataka iz baze: " + ex.Message);
            }
            finally
            {
                if (connection.State == ConnectionState.Open)
                {
                    connection.Close();
                }
            }

            return packages;
        }*/

    }

}
