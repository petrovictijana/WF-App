using Projekat.Server.Models;
using Projekat.Server.ObserverPattern;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Projekat
{
    public partial class Paketi_pocetna : Form, IObserver
    {
        Button addNewPackageBtn = createPrimaryButton("Dodaj paket", new Point(830, 70), 180);
        Button addNewClientBtn = createPrimaryButton("Dodaj klijenta", new Point(830, 80), 180);
        Button deletePackageButton = new Button();
        DataGridView packagesTable = new DataGridView();
        DataGridView packagesTableKlijentiPanel = new DataGridView();
        DataGridView subscribedPackages = new DataGridView();

        Facade userFacade;
        DbConnection konekcija;
        Memento memento;

        public Paketi_pocetna(DbConnection connection, string providerName)
        {
            konekcija = connection;
            userFacade = new Facade(konekcija, this);
            //Definisanje onClick funkcija za button-e
            addNewPackageBtn.Click += otvoriOverlayPackage;
            addNewClientBtn.Click += otvoriOverlayClient;

            //Dodavanje button-a
            this.Controls.Add(addNewPackageBtn);
            this.Controls.Add(addNewClientBtn);

            //Inicijalizacija forme
            InitializeComponent();
            providerNameLabel.Text = providerName;

            //button3.Click += button3_Click;
            //button4.Click += button4_Click;

            dodajButton.Click += dodajPretplatu;
            izbaciButton.Click += izbaciPretplatu;

            /*Button button = new Button();
            button.Text = "Delete";
            button.Location = new Point(30, 50);
            button.Click += deletePackage;
            paketiPanel.Controls.Add(button);*/

            //Tabela sa paketima
            setujPackagesTableForPaketiPanel();
            setujDeletePackageButton();

            //Dodavanje dogadjaja za radio button
            radioButton1.CheckedChanged += showPackages;
            radioButton2.CheckedChanged += showPackages;
            radioButton3.CheckedChanged += showPackages;

            //RadioButton1.Checked = true;
            //Setovanje pocetnog skrina
            paketiPanel.Visible = true;

            //Sakriven skrin sa klijentima 
            addNewClientBtn.Visible = false;
            korisniciPanel.Visible = false;
            korisniciZelenaTraka.Visible = false;

            //Definisanje ponasanja menu-a 
            KorisniciLabel.Click += switchToKorisniciPanel;
            korisniciMenuPanel.Click += switchToKorisniciPanel;
            paketiMenuPanel.Click += switchToPaketiPanel;

            //Setovanje prikaza tabele sa paketima za klijente
            setujPackagesTableForKlijentiPanel();

            paketiComboBox.SelectedIndexChanged += paketiComboBox_SelectedIndexChanged;
            popuniKlijentiComboBox();
            paketiComboBox.SelectedIndex = 0;


            //Klijenti panel
            
            setujSubscribedPackages();
            ukupnaCenaLabel.Text = "" + userFacade.getPackagePriceAmount((string)klijentiComboBox.SelectedItem);


            klijentiComboBox.SelectedIndexChanged += klijentiComboBox_SelectedIndexChanged;
        }

        private void izbaciPretplatu(object sender, EventArgs e)
        {
            int rowIndex = packagesTableKlijentiPanel.SelectedRows[0].Index;
            int packageId = (int)packagesTableKlijentiPanel.Rows[rowIndex].Cells[0].Tag;

            userFacade.deleteSubscription((string)klijentiComboBox.SelectedItem, packageId);
        }

        private void dodajPretplatu(object sender, EventArgs e)
        {
            int rowIndex = packagesTableKlijentiPanel.SelectedRows[0].Index;
            int packageId = (int)packagesTableKlijentiPanel.Rows[rowIndex].Cells[0].Tag;

            userFacade.addNewSubscription((string)klijentiComboBox.SelectedItem, packageId);
        }

        private void setujDeletePackageButton()
        {
            deletePackageButton.Location = new Point(30, 50);
            deletePackageButton.Text = "Obrisi selektovani paket";

            deletePackageButton.Click += deletePackage;

            paketiPanel.Controls.Add(deletePackageButton);
        }

        private void deletePackage(object sender, EventArgs e)
        {
            int rowIndex = packagesTable.SelectedRows[0].Index;
            int packageId = (int)packagesTable.Rows[rowIndex].Cells[0].Tag;

            userFacade.deletePackageById(packageId);
        }

        public void setujPackagesTableForPaketiPanel()
        {
            packagesTable.Location = new Point(40, 80);
            packagesTable.Width = 550;

            List<Paket> packages = userFacade.getAllPackagesByTypeId(1); //prikaz TV paketa
            packagesTable.Columns.Add("Column1", "Naziv paketa");
            packagesTable.Columns.Add("Column2", "Cena");
            packagesTable.Columns.Add("Column3", "Broj kanala");
            packagesTable.Columns.Add("Column4", "Kolicina interneta");

            packagesTable.Rows.Clear();
            foreach (var item in packages)
            {
                DataGridViewRow row = new DataGridViewRow();

                row.CreateCells(packagesTable);
                row.Cells[0].Value = item.Naziv; // Postavite vrijednost za prvu kolonu
                row.Cells[0].Tag = item.Id;
                row.Cells[1].Value = item.Cena; // Postavite vrijednost za drugu kolonu
                row.Cells[2].Value = item.BrojKanala; // Postavite vrijednost za treću kolonu
                row.Cells[3].Value = "Nedostupno";

                packagesTable.Rows.Add(row);
            }

            paketiPanel.Controls.Add(packagesTable);
        }

        public void setujSubscribedPackages()
        {
            subscribedPackages.Location = new Point(20, 120);
            subscribedPackages.Width = 170;
            subscribedPackages.Height = 230;

            subscribedPackages.Columns.Clear();
            subscribedPackages.Columns.Add("Column1", "Naziv paketa");

            Klijent klijent = userFacade.getClientByUsername(klijentiComboBox.SelectedItem.ToString());
            Console.WriteLine("Username selected: " + klijent.Username);

            List<Paket> packages = userFacade.getSubscribedPackagesByClientId(klijent);
  
            subscribedPackages.Rows.Clear();
            foreach (var item in packages)
            {
                DataGridViewRow row = new DataGridViewRow();

                row.CreateCells(subscribedPackages);
                row.Cells[0].Value = item.Naziv; // Postavite vrijednost za prvu kolonu
                row.Cells[0].Tag = item.Id;

                subscribedPackages.Rows.Add(row);
            }

            korisniciPanel.Controls.Add(subscribedPackages);
        }

        public void setujPackagesTableForKlijentiPanel()
        {
            packagesTableKlijentiPanel.Location = new Point(200, 120);
            packagesTableKlijentiPanel.Width = 420;

            List<Paket> packages = userFacade.getAllPackagesByTypeId(1); //prikaz TV paketa
            packagesTableKlijentiPanel.Columns.Add("Column1", "Naziv paketa");
            packagesTableKlijentiPanel.Columns.Add("Column2", "Cena");
            packagesTableKlijentiPanel.Columns.Add("Column3", "Broj kanala");
            packagesTableKlijentiPanel.Columns.Add("Column4", "Kolicina interneta");

            foreach (var item in packages)
            {
                DataGridViewRow row = new DataGridViewRow();

                row.CreateCells(packagesTable);
                row.Cells[0].Value = item.Naziv; // Postavite vrijednost za prvu kolonu
                row.Cells[0].Tag = item.Id;
                row.Cells[1].Value = item.Cena; // Postavite vrijednost za drugu kolonu
                row.Cells[2].Value = item.BrojKanala; // Postavite vrijednost za treću kolonu
                row.Cells[3].Value = "Nedostupno";

                packagesTableKlijentiPanel.Rows.Add(row);
            }

            korisniciPanel.Controls.Add(packagesTableKlijentiPanel);
        }


        public void popuniKlijentiComboBox()
        {
            klijentiComboBox.Items.Clear();

            List<Klijent> klijenti = userFacade.getAllClients();

            foreach(Klijent klijent in klijenti)
            {
                klijentiComboBox.Items.Add(klijent.Username);
            }

            klijentiComboBox.SelectedIndex = 0;
        }

        private void showPackages(object sender, EventArgs e)
        {
            List<Paket> packages = new List<Paket>();

            packagesTable.Rows.Clear();
            if (radioButton1.Checked == true)
            {
                packages = userFacade.getAllPackagesByTypeId(1);


                foreach (var item in packages)
                {
                    Console.WriteLine("*********** " + item.Naziv);
                    DataGridViewRow row = new DataGridViewRow();
                    row.CreateCells(packagesTable);
                    row.Cells[0].Value = item.Naziv; // Postavite vrijednost za prvu kolonu
                    row.Cells[1].Value = item.Cena; // Postavite vrijednost za drugu kolonu
                    row.Cells[2].Value = item.BrojKanala; // Postavite vrijednost za treću kolonu
                    row.Cells[3].Value = "Nedostupno";

                    packagesTable.Rows.Add(row);
                }

            }
            else if (radioButton2.Checked == true)
            {
                packages = userFacade.getAllPackagesByTypeId(2);

                foreach (var item in packages)
                {
                    DataGridViewRow row = new DataGridViewRow();
                    row.CreateCells(packagesTable);
                    row.Cells[0].Value = item.Naziv; // Postavite vrijednost za prvu kolonu
                    row.Cells[1].Value = item.Cena; // Postavite vrijednost za drugu kolonu
                    row.Cells[2].Value = "Nedostupno"; // Postavite vrijednost za treću kolonu
                    row.Cells[3].Value = item.BrzinaInterneta;

                    packagesTable.Rows.Add(row);
                }
            }
            else
            {
                packages = userFacade.getAllPackagesByTypeId(3);

                foreach (var item in packages)
                {
                    DataGridViewRow row = new DataGridViewRow();
                    row.CreateCells(packagesTable);
                    row.Cells[0].Value = item.Naziv; // Postavite vrijednost za prvu kolonu
                    row.Cells[1].Value = item.Cena; // Postavite vrijednost za drugu kolonu
                    row.Cells[2].Value = item.BrojKanala; // Postavite vrijednost za treću kolonu
                    row.Cells[3].Value = item.BrzinaInterneta;

                    packagesTable.Rows.Add(row);
                }
            }
        }

        private void updateSubscription()
        {
            subscribedPackages.Rows.Clear();

            Klijent klijent = userFacade.getClientByUsername(klijentiComboBox.SelectedItem.ToString());

            List<Paket> packages = userFacade.getSubscribedPackagesByClientId(klijent);

            foreach (var item in packages)
            {
                DataGridViewRow row = new DataGridViewRow();

                row.CreateCells(subscribedPackages);
                row.Cells[0].Value = item.Naziv; // Postavite vrijednost za prvu kolonu
                row.Cells[0].Tag = item.Id;

                subscribedPackages.Rows.Add(row);
            }

            korisniciPanel.Controls.Add(subscribedPackages);
        }

        private void switchToPaketiPanel(object sender, EventArgs e)
        {
            //Setovanje zelene trake 
            paketiZelenaTraka.Visible = true;
            korisniciZelenaTraka.Visible = false;

            //Iskljucivanje vidljivosti dela za korisnike
            korisniciPanel.Visible = false;
            addNewClientBtn.Visible = false;

            //Rotiranje boja 
            paketiMenuPanel.BackColor = Color.White;
            korisniciMenuPanel.BackColor = Color.WhiteSmoke;

            //Ukljucivanje vidljivosti dela za pakete 
            paketiPanel.Visible = true;
            addNewPackageBtn.Visible = true;
        }

        private void switchToKorisniciPanel(object sender, EventArgs e)
        {
            //Podesavanje zelene trake 
            korisniciZelenaTraka.Visible = true;
            paketiZelenaTraka.Visible = false;

            //Ukljucivanje vidljivosti panela za korisnike
            korisniciPanel.Visible = true;
            addNewClientBtn.Visible = true;

            //Rotiranje boja 
            korisniciMenuPanel.BackColor = Color.White;
            paketiMenuPanel.BackColor = Color.WhiteSmoke;

            //Iskljucivanje vidljivosti dugmeta
            addNewPackageBtn.Visible = false;
        }

        private void otvoriOverlayClient(object sender, EventArgs e)
        {
            DodajKorisnikaOverlay dodajKorisnikaOverlay = new DodajKorisnikaOverlay(konekcija);
            dodajKorisnikaOverlay.ShowDialog();
        }

        private void otvoriOverlayPackage(object sender, EventArgs e)
        {
            DodajPaketOverlay dodajPaketOverlay = new DodajPaketOverlay(konekcija);
            dodajPaketOverlay.ShowDialog();
        }

        private void panel2_Click(object sender, EventArgs e)
        {
            Korisnici korisniciForma = new Korisnici();

            // Dodajte događaj Shown
            korisniciForma.Shown += (s, args) => {
                // Ovo će se pokrenuti kada se nova Forma u potpunosti prikaže
                this.Close();
            };

            korisniciForma.Show();
        }



        public static Button createPrimaryButton(String buttonText, Point buttonPosition, int width)
        {
            Button button = new Button();

            button.Text = buttonText;
            button.Size = new Size(width, 35);
            button.Font = new Font("Microsoft Sans Serif", 9.25f, FontStyle.Bold);
            button.FlatStyle = FlatStyle.Flat;
            button.FlatAppearance.BorderColor = Color.Teal;

            button.BackColor = Color.Teal;
            button.ForeColor = Color.White;

            button.Cursor = Cursors.Hand;

            //Efekti na hover
            button.MouseEnter += mouseEnterEvent;
            button.MouseLeave += mouseLeaveEvent;

            button.Location = buttonPosition;

            return button;
        }

        public static Button createSecondaryButton(String buttonText, Point buttonPosition)
        {
            Button button = new Button();

            button.Text = buttonText;
            button.Size = new Size(130, 35);
            button.Font = new Font("Microsoft Sans Serif", 9.25f, FontStyle.Bold);
            button.FlatStyle = FlatStyle.Flat;
            button.FlatAppearance.BorderColor = Color.Teal;

            button.BackColor = Color.White;
            button.ForeColor = Color.Teal;

            button.Cursor = Cursors.Hand;

            //Efekti na hover
            button.MouseEnter += mouseLeaveEvent;
            button.MouseLeave += mouseEnterEvent;

            button.Location = buttonPosition;

            return button;
        }

        private static void mouseLeaveEvent(object sender, EventArgs e)
        {
            if (sender is Button button)
            {
                button.BackColor = Color.Teal;
                button.ForeColor = Color.White;
            }
        }

        private static void mouseEnterEvent(object sender, EventArgs e)
        {
            if (sender is Button button)
            {
                button.BackColor = Color.White;
                button.FlatAppearance.BorderColor = Color.Teal;
                button.ForeColor = Color.Teal;
            }
        }

        private void paketiComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            List<Paket> packages = new List<Paket>();

            packagesTableKlijentiPanel.Rows.Clear();
            if (paketiComboBox.SelectedIndex == 0)
            {
                packages = userFacade.getAllPackagesByTypeId(1);

                foreach (var item in packages)
                {
                    Console.WriteLine("*********** " + item.Naziv);
                    DataGridViewRow row = new DataGridViewRow();
                    row.CreateCells(packagesTableKlijentiPanel);
                    row.Cells[0].Value = item.Naziv; // Postavite vrijednost za prvu kolonu
                    row.Cells[0].Tag = item.Id;
                    row.Cells[1].Value = item.Cena; // Postavite vrijednost za drugu kolonu
                    row.Cells[2].Value = item.BrojKanala; // Postavite vrijednost za treću kolonu
                    row.Cells[3].Value = "Nedostupno";

                    packagesTableKlijentiPanel.Rows.Add(row);
                }

            }
            else if (paketiComboBox.SelectedIndex == 1)
            {
                packages = userFacade.getAllPackagesByTypeId(2);

                foreach (var item in packages)
                {
                    DataGridViewRow row = new DataGridViewRow();
                    row.CreateCells(packagesTableKlijentiPanel);
                    row.Cells[0].Value = item.Naziv; // Postavite vrijednost za prvu kolonu
                    row.Cells[0].Tag = item.Id;
                    row.Cells[1].Value = item.Cena; // Postavite vrijednost za drugu kolonu
                    row.Cells[2].Value = "Nedostupno"; // Postavite vrijednost za treću kolonu
                    row.Cells[3].Value = item.BrzinaInterneta;

                    packagesTableKlijentiPanel.Rows.Add(row);
                }
            }
            else
            {
                packages = userFacade.getAllPackagesByTypeId(3);

                foreach (var item in packages)
                {
                    DataGridViewRow row = new DataGridViewRow();
                    row.CreateCells(packagesTableKlijentiPanel);
                    row.Cells[0].Value = item.Naziv; // Postavite vrijednost za prvu kolonu
                    row.Cells[0].Tag = item.Id;
                    row.Cells[1].Value = item.Cena; // Postavite vrijednost za drugu kolonu
                    row.Cells[2].Value = item.BrojKanala; // Postavite vrijednost za treću kolonu
                    row.Cells[3].Value = item.BrzinaInterneta;

                    packagesTableKlijentiPanel.Rows.Add(row);
                }
            }

            ukupnaCenaLabel.Text = "" + 10000;
        }

        private void klijentiComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            ukupnaCenaLabel.Text = "" + userFacade.getPackagePriceAmount((string)klijentiComboBox.SelectedItem);
            setujSubscribedPackages();
        }

        /*private void button3_Click(object sender, EventArgs e)
        {
            Klijent k = userFacade.getClientByUsername((string)klijentiComboBox.SelectedItem);
            Stanje stanje = new Stanje();
            stanje.Username = k.Username;

            setujSubscribedPackages();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Klijent k = userFacade.getClientByUsername((string)klijentiComboBox.SelectedItem);
            Stanje stanje = new Stanje();
            stanje.Username = k.Username;

            setujSubscribedPackages();
        }*/

        public void UpdatePackagesView()
        {
            setujPackagesTableForPaketiPanel();
        }

        public void UpdateUserView()
        {
            popuniKlijentiComboBox();
        }

        public void updateSubscribersView()
        {
            setujSubscribedPackages();
        }

        public void updateTotalPrice()
        {
            ukupnaCenaLabel.Text = "" + userFacade.getPackagePriceAmount((string)klijentiComboBox.SelectedItem);
        }
    }
}
