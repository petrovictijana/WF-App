using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Projekat
{
    public partial class PaketiPocetna : Form
    {
        Button addNewPackageBtn = createPrimaryButton("Dodaj paket", new Point(830, 70), 180);
        Button addNewClientBtn = createPrimaryButton("Dodaj klijenta", new Point(830, 80), 180);
        public PaketiPocetna()
        {
            //Definisanje onClick funkcija za button-e
            addNewPackageBtn.Click += otvoriOverlayPackage;
            addNewClientBtn.Click += otvoriOverlayClient;

            //Dodavanje button-a
            this.Controls.Add(addNewPackageBtn);
            this.Controls.Add(addNewClientBtn);

            //Inicijalizacija forme
            InitializeComponent();
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
            DodajKorisnikaOverlay dodajKorisnikaOverlay = new DodajKorisnikaOverlay();
            dodajKorisnikaOverlay.ShowDialog();
        }

        private void otvoriOverlayPackage(object sender, EventArgs e)
        {
            DodajPaketOverlay dodajPaketOverlay = new DodajPaketOverlay();
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

        /*public static TableLayoutPanel createTable(int packageId, Point position)
        {
            TableLayoutPanel table = new TableLayoutPanel();

            switch (packageId)
            {
                case 1:
                    //TV paket 
                    table.ColumnCount = 3;

                    Label headerLabel = new Label();
                    headerLabel.Dock = DockStyle.Fill;
                    headerLabel.TextAlign = ContentAlignment.MiddleCenter;

                    //Prva kolona 
                    headerLabel.Text = "Naziv paketa";
                    table.Controls.Add(headerLabel, 0, 0);

                    //Druga kolona 
                    headerLabel.Text = "Broj kanala";
                    table.Controls.Add(headerLabel, 1, 0);

                    //Treca kolona 
                    headerLabel.Text = "Cena paketa";
                    table.Controls.Add(headerLabel, 2, 0);
                    
                    break;
                case 2:
                    //Internet paket 
                    table.ColumnCount = 3;

                    Label label = new Label();
                    label.Dock = DockStyle.Fill;
                    label.TextAlign = ContentAlignment.MiddleCenter;

                    //Prva kolona 
                    label.Text = "Naziv paketa";
                    table.Controls.Add(label, 0, 0);

                    //Druga kolona 
                    label.Text = "Količina interneta";
                    table.Controls.Add(label, 1, 0);

                    //Treca kolona 
                    label.Text = "Cena paketa";
                    table.Controls.Add(label, 2, 0);

                    break;
                case 3:
                    //Kombinovani paket 
                    table.ColumnCount = 4;

                    Label header = new Label();
                    header.Dock = DockStyle.Fill;
                    header.TextAlign = ContentAlignment.MiddleCenter;

                    //Prva kolona 
                    header.Text = "Naziv paketa";
                    table.Controls.Add(header, 0, 0);

                    //Druga kolona 
                    header.Text = "Broj kanala";
                    table.Controls.Add(header, 1, 0);

                    //Treca kolona 
                    header.Text = "Količina interneta";
                    table.Controls.Add(header, 2, 0);

                    //Cetvrta kolona 
                    header.Text = "Cena paketa";
                    table.Controls.Add(header, 3, 0);

                    break;

            }
            table.Location = position;

            return table;
        }*/

        private static void mouseLeaveEvent(object sender, EventArgs e)
        {
            if(sender is Button button)
            {
                button.BackColor = Color.Teal;
                button.ForeColor = Color.White;
            }
        }

        private static void mouseEnterEvent(object sender, EventArgs e)
        {
            if(sender is Button button)
            {
                button.BackColor = Color.White;
                button.FlatAppearance.BorderColor = Color.Teal;
                button.ForeColor = Color.Teal;
            }
        }
    }
}
